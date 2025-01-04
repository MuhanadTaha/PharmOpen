using System;
using System.Data.SqlClient;
using System.Configuration;

namespace PharmOpen
{
    public partial class tipDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // الحصول على معرّف الإعلان من الـ QueryString
                string tipId = Request.QueryString["tip_id"];

                // إذا كان المعرّف موجودًا، قم بتحميل البيانات من قاعدة البيانات
                if (!string.IsNullOrEmpty(tipId))
                {
                    LoadAdDetails(tipId);
                }
            }
        }

        private void LoadAdDetails(string tipId)
        {
            SqlCommand cmd = new SqlCommand("SELECT tip_title, tip_content, tip_image FROM tips WHERE tip_id = @tipId", con);
            cmd.Parameters.AddWithValue("@tipId", tipId);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string tipTitle = reader["tip_title"].ToString();
                string tipContent = reader["tip_content"].ToString();

                // تحقق مما إذا كان العمود يحتوي على مسار الصورة
                string tipImagePath = reader["tip_image"].ToString();

                // إذا كان المسار فارغًا أو غير موجود، استخدم صورة افتراضية
                if (!string.IsNullOrEmpty(tipImagePath))
                {
                    // استخدم المسار مباشرة
                    imgtipImage.Attributes["src"] = tipImagePath;
                }
                else
                {
                    // إذا لم يكن هناك مسار صورة، استخدم صورة افتراضية أو مناسبة
                    imgtipImage.Attributes["src"] = "~/images/default-image.png";
                }

                // تخصيص التفاصيل
                lblTipTitle.InnerText = tipTitle;
                lblTipContent.InnerText = tipContent;
            }
            con.Close();
        }


    }
}
