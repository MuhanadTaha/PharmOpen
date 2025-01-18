using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace PharmOpen
{
    public partial class AddAd : System.Web.UI.Page
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

        protected void btnAddAd_Click(object sender, EventArgs e)
        {
            string adTitle = txtAdTitle.Text;
            string adContent = txtAdContent.Text;

            // تحقق من تحميل صورة
            string adImagePath = string.Empty;
            if (fileAdImage.HasFile)
            {
                // تعيين مسار الصورة
                string fileName = Path.GetFileName(fileAdImage.PostedFile.FileName);
                adImagePath = "images/" + fileName;

                // حفظ الصورة في المجلد
                string savePath = Server.MapPath("~/images/") + fileName;
                fileAdImage.SaveAs(savePath);
            }
            string email = Session["email"]?.ToString();
            int user_id = Convert.ToInt32(Session["id"].ToString());

            // إضافة البيانات إلى قاعدة البيانات
            SqlCommand cmd = new SqlCommand("INSERT INTO ads (ad_title, ad_content, ad_image, user_id) VALUES (@adTitle, @adContent, @adImage, @user_id)", con);

            cmd.Parameters.AddWithValue("@adTitle", adTitle); // إضافة قيمة للعنوان
            cmd.Parameters.AddWithValue("@adContent", adContent);
            cmd.Parameters.AddWithValue("@adImage", adImagePath);
            cmd.Parameters.AddWithValue("@user_id", user_id); // تحديد user_id بدلاً من email

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Default.aspx"); // إعادة التوجيه إلى الصفحة الرئيسية بعد إضافة الإعلان
            }
            catch (Exception ex)
            {
                // التعامل مع الأخطاء (عرض رسالة أو تسجيل الخطأ)
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
