using System;
using System.Data.SqlClient;
using System.Configuration;

namespace PharmOpen
{
    public partial class AdDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // الحصول على معرّف الإعلان من الـ QueryString
                string adId = Request.QueryString["ad_id"];

                // إذا كان المعرّف موجودًا، قم بتحميل البيانات من قاعدة البيانات
                if (!string.IsNullOrEmpty(adId))
                {
                    LoadAdDetails(adId);
                }
            }
        }

        private void LoadAdDetails(string adId)
        {
            SqlCommand cmd = new SqlCommand("SELECT ad_title, ad_content, ad_image FROM ads WHERE ad_id = @adId", con);
            cmd.Parameters.AddWithValue("@adId", adId);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string adTitle = reader["ad_title"].ToString();
                string adContent = reader["ad_content"].ToString();

                // تحقق مما إذا كان العمود يحتوي على مسار الصورة
                string adImagePath = reader["ad_image"].ToString();

                // إذا كان المسار فارغًا أو غير موجود، استخدم صورة افتراضية
                if (!string.IsNullOrEmpty(adImagePath))
                {
                    // استخدم المسار مباشرة
                    imgAdImage.Attributes["src"] = adImagePath;
                }
                else
                {
                    // إذا لم يكن هناك مسار صورة، استخدم صورة افتراضية أو مناسبة
                    imgAdImage.Attributes["src"] = "~/images/default-image.png";
                }

                // تخصيص التفاصيل
                lblAdTitle.InnerText = adTitle;
                lblAdContent.InnerText = adContent;
            }
            con.Close();
        }


    }
}
