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
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from users where email = '" + txtEmail.Text + "' ";

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Response.Write("<script>alert('Email Already Exist');</script>");
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("insert into users values('" + txtFirstName.Text + "'  , '" + txtLastName.Text + "' , '" + txtMobile.Text + "' ,  '" + txtDOB.Text + "' ,  '" + txtEmail.Text + "',  '" + txtPassword.Text + "' , '" + txtCPassword.Text + "' , '" + ddlGender.Text + "' ,'admin')", con);

                cmd.ExecuteNonQuery();
           
                Response.Redirect("LogIn.aspx");
                con.Close();
            }
            con.Close();
        }

    }
}