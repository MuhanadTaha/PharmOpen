using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace PharmOpen
{
    public partial class AddVillage : System.Web.UI.Page
    {
        // إعداد الاتصال بقاعدة البيانات
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCities();  // تحميل المدن في الـ DropDownList عند تحميل الصفحة لأول مرة
            }
        }

        // تحميل المدن في الـ DropDownList
        private void LoadCities()
        {
            string query = "SELECT city_id, city_name FROM cities"; // استعلام لجلب المدن
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // إضافة المدن إلى الـ DropDownList
                ddlCity.DataSource = reader;
                ddlCity.DataTextField = "city_name"; // اسم المدينة لعرضه
                ddlCity.DataValueField = "city_id"; // قيمة المدينة لتمريرها
                ddlCity.DataBind();

                con.Close();
            }
            catch (Exception ex)
            {
                // التعامل مع الأخطاء (عرض رسالة أو تسجيل الخطأ)
                Response.Write("Error: " + ex.Message);
            }
        }

        // التعامل مع زر إضافة القرية
        protected void btnAddVillage_Click(object sender, EventArgs e)
        {
            string villageName = txtVillageName.Text;  // الحصول على اسم القرية من المستخدم
            int cityId = int.Parse(ddlCity.SelectedValue);  // الحصول على ID المدينة المختارة

            // التحقق من صحة البيانات
            if (string.IsNullOrEmpty(villageName) || cityId == 0)
            {
                Response.Write("يرجى ملء جميع الحقول.");
                return;
            }

            // إضافة البيانات إلى قاعدة البيانات
            string query = "INSERT INTO villages (village_name, city_id) VALUES (@villageName, @cityId)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@villageName", villageName);
            cmd.Parameters.AddWithValue("@cityId", cityId);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); // تنفيذ الاستعلام لإضافة القرية
                con.Close();

                // إعادة التوجيه إلى صفحة القرى بعد إضافة القرية
                Response.Redirect("VillageList.aspx");
            }
            catch (Exception ex)
            {
                // التعامل مع الأخطاء
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
