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
                Response.Write("<script>alert('البريد الإلكتروني مستخدم مسبقًا');</script>");
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                string authorizedRole = "admin";
                cmd = new SqlCommand("INSERT INTO users (fName, lName, mobile, dob, email, password, cPassword, gender, authorized) VALUES (@FirstName, @LastName, @Mobile, @DOB, @Email, @Password, @CPassword, @Gender, @Authorized)", con);

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@CPassword", txtCPassword.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Authorized", authorizedRole);


                cmd.ExecuteNonQuery();
           
                Response.Redirect("LogIn.aspx");
                con.Close();
            }
            con.Close();
        }

    }
}