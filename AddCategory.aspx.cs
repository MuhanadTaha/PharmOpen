using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmOpen
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Categories where Name = '" + txtCategory.Text + "' ";

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Response.Write("<script>alert('Category Already Exist');</script>");
                con.Close();
            }
            else
            {
                con.Close();

                con.Open();
                cmd = new SqlCommand("insert into Categories values('" + txtCategory.Text + "' )", con);
                if (txtCategory.Text == "")
                {
                    Response.Write("<script>alert('Please Enter the category name');</script>");
                    
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Response.Redirect("CategoryList.aspx");
                }
                con.Close();
            }
            con.Close();
        }

    }
}