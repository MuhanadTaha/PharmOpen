using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PharmOpen
{
    public partial class _Default : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayProducts();
                DisplayCategories();
            }
           
        }

        public void DisplayProducts()
        {
            con.Open();
            int idCatgeory = Convert.ToInt32(Request.QueryString["Category_ID"]);
            string strProducts;
            if (idCatgeory == 0)
            {
                strProducts = "select * from Products where Quantity <> 0";
            }
            else
            {
                strProducts = "select * from Products where Quantity <> 0 and CategoryId= '" + idCatgeory + "'";
            }
            SqlCommand cmd = new SqlCommand(strProducts, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlProducts.DataSource = ds;
            ddlProducts.DataBind();
            con.Close();
        }

        public void DisplayCategories()
        {
            con.Open();
            string strProducts = "select * from Categories";
            SqlCommand cmd = new SqlCommand(strProducts, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dlCateg.DataSource = ds;
            dlCateg.DataBind();
            con.Close();
        }

        protected void dlReplies_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                if (Session["Email"] == null || Session["Email"].ToString() == "")
                {
                    Response.Redirect("LogIn.aspx");
                }
                else
                {
                    Label IdProduct = (Label)e.Item.FindControl("lblIdProduct");
                    Label Name = (Label)e.Item.FindControl("lblName");
                    Label Price = (Label)e.Item.FindControl("lblPrice");
                    Label alert = (Label)e.Item.FindControl("lblAlert");
                    Label IdCategory = (Label)e.Item.FindControl("lblCategory");
                    TextBox Count = (TextBox)e.Item.FindControl("txtCount");

                    con.Open();

                    if (CheckQuantityProduct(IdProduct.Text) >= Convert.ToInt32(Count.Text))
                    {
                        string str = "insert into Orders (NameProducts,NameCategories,BuyerUser,Price,Arrive,Count) Values (@NameProducts,@NameCategories,@BuyerUser,@Price,@Arrive,@Count)";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.AddWithValue("@NameProducts", Name.Text);
                        cmd.Parameters.AddWithValue("@NameCategories", DisplayCateigores(IdCategory.Text));
                        cmd.Parameters.AddWithValue("@BuyerUser", Session["Email"].ToString());
                        cmd.Parameters.AddWithValue("@Price", Convert.ToSingle(Price.Text));
                        cmd.Parameters.AddWithValue("@Arrive", "No");
                        cmd.Parameters.AddWithValue("@Count", Convert.ToInt32(Count.Text));
                        alert.Text = "Buy Succeeded";
                        cmd.ExecuteNonQuery();
                        increaseProd(IdProduct.Text, Count.Text);
                    }
                    else
                    {
                        alert.Text = "Out of stock";
                        alert.BackColor = Color.Red;
                    }
                    alert.Visible = true;
                    con.Close();
                }
            }
        }

        protected string DisplayCateigores(string IdCategory)
        {
            string str = "select Name from Categories where ID= @ID ";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IdCategory));
            string result = Convert.ToString(cmd.ExecuteScalar());
            return result;
        }

        protected void increaseProd(string IdProduct, string Count)
        {
            string str = "update Products set Quantity = Quantity -" + Convert.ToInt32(Count) + " where ID= @IDProd AND Quantity > 0";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@IDProd", Convert.ToInt32(IdProduct));
            cmd.ExecuteNonQuery();
        }

        protected int CheckQuantityProduct(string IdProduct)
        {
            string str = "select Quantity from Products where ID= @ID ";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IdProduct));
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }


    }
}