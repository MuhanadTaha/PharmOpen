using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace PharmOpen
{
    public partial class AddTips : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // لا حاجة لشيء هنا في حالة عدم وجود طلبات POST
        }

        protected void btnAddTip_Click(object sender, EventArgs e)
        {
            string TipTitle = txtTipTitle.Text;
            string TipContent = txtTipContent.Text;

            // تحقق من تحميل صورة
            string TipImagePath = string.Empty;
            if (fileTipImage.HasFile)
            {
                // تعيين مسار الصورة
                string fileName = Path.GetFileName(fileTipImage.PostedFile.FileName);
                TipImagePath = "images/" + fileName;

                // حفظ الصورة في المجلد
                string savePath = Server.MapPath("~/images/") + fileName;
                fileTipImage.SaveAs(savePath);
            }
            int user_id = Convert.ToInt32(Session["id"]);
            // إضافة البيانات إلى قاعدة البيانات
            SqlCommand cmd = new SqlCommand("INSERT INTO Tips (tip_title, tip_content, tip_image, user_id) VALUES (@tip_title, @tip_content, @tip_image, @user_id)", con);
            cmd.Parameters.AddWithValue("@tip_title", TipTitle);
            cmd.Parameters.AddWithValue("@tip_content", TipContent);
            cmd.Parameters.AddWithValue("@tip_image", TipImagePath);
            cmd.Parameters.AddWithValue("@user_id", user_id); // إذا لم يتم تحميل صورة، سيكون المسار فارغًا

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("tipsList.aspx"); // إعادة التوجيه إلى الصفحة الرئيسية بعد إضافة الإعلان
            }
            catch (Exception ex)
            {
                // التعامل مع الأخطاء (عرض رسالة أو تسجيل الخطأ)
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
