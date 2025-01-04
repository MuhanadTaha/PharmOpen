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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // فتح الاتصال بقاعدة البيانات
            con.Open();

            // استعلام للتحقق من صحة البريد الإلكتروني وكلمة المرور واستخراج الـ id في نفس الوقت
            string stmt = "SELECT id FROM users WHERE email = @Email AND password = @Password";

            SqlCommand objcmd = new SqlCommand(stmt, con);

            // استخدام المعاملات لتحسين الأمان ومنع هجمات SQL Injection
            objcmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            objcmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            // تنفيذ الاستعلام وقراءة البيانات
            SqlDataReader reader = objcmd.ExecuteReader();

            if (reader.Read())
            {
                // تخزين قيمة الـ id في الـ Session
                Session["Email"] = txtEmail.Text;
                Session["id"] = reader["id"]; // استخدم reader["id"] لاستخراج الـ id

                // تأكيد أنه تم تخزين الـ id في الـ Session
                //Response.Write("User ID: " + Session["id"].ToString());

                // إعادة التوجيه إلى الصفحة الرئيسية
                Response.Redirect("Default.aspx");
            }
            else
            {
                // إذا كانت البيانات غير صحيحة، عرض رسالة خطأ
                Response.Write("<script>alert('Invalid Email or Password');</script>");
            }

            // إغلاق الاتصال
            con.Close();
        }


    }
}