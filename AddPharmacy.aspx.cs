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
    public partial class AddPharmacy : System.Web.UI.Page
    {
        // استخدام سلسلة الاتصال من Web.config
        string connStr = ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // تحميل المدن عند تحميل الصفحة لأول مرة
                LoadCities();
            }
        }

        // تحميل المدن
        private void LoadCities()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT city_id, city_name FROM cities", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlCity.DataSource = reader;
                ddlCity.DataTextField = "city_name";
                ddlCity.DataValueField = "city_id";
                ddlCity.DataBind();
            }

            // إضافة خيار افتراضي "اختر المدينة"
            ddlCity.Items.Insert(0, new ListItem("اختر المدينة", "0"));
        }

        // تحميل القرى بناءً على المدينة المختارة
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(ddlCity.SelectedValue);

            if (cityId > 0)
            {
                // تحميل القرى بناءً على المدينة المحددة
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT village_id, village_name FROM villages WHERE city_id = @cityId", conn);
                    cmd.Parameters.AddWithValue("@cityId", cityId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlVillage.DataSource = reader;
                    ddlVillage.DataTextField = "village_name";
                    ddlVillage.DataValueField = "village_id";
                    ddlVillage.DataBind();
                }

                // إضافة خيار افتراضي "اختر القرية"
                ddlVillage.Items.Insert(0, new ListItem("اختر القرية", "0"));
            }
            else
            {
                // إذا لم يتم اختيار مدينة، يتم مسح القرى
                ddlVillage.Items.Clear();
                ddlVillage.Items.Add(new ListItem("اختر القرية", "0"));
            }
        }

        // إضافة الصيدلية
        protected void btnAddPharmacy_Click(object sender, EventArgs e)
        {
            string pharmacyName = txtPharmacyName.Text;
            int villageId = int.Parse(ddlVillage.SelectedValue);
            string shiftDate = txtShiftDate.Text;
            int user_id = Convert.ToInt32(Session["id"].ToString());

            if (!string.IsNullOrEmpty(pharmacyName) && villageId > 0 && !string.IsNullOrEmpty(shiftDate))
            {
                // إضافة الصيدلية إلى قاعدة البيانات
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // أولاً، إضافة الصيدلية
                    SqlCommand cmd = new SqlCommand("INSERT INTO pharmacies (pharmacy_name, village_id,user_id) OUTPUT INSERTED.pharmacy_id VALUES (@pharmacyName, @villageId,@user_id)", conn);
                    cmd.Parameters.AddWithValue("@pharmacyName", pharmacyName);
                    cmd.Parameters.AddWithValue("@villageId", villageId);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    conn.Open();
                    int pharmacyId = (int)cmd.ExecuteScalar();

                    // ثم إضافة المناوبة المرتبطة بالصيدلية
                    SqlCommand cmdShift = new SqlCommand("INSERT INTO shifts (pharmacy_id, shift_day) VALUES (@pharmacyId, @shiftDate)", conn);
                    cmdShift.Parameters.AddWithValue("@pharmacyId", pharmacyId);
                    cmdShift.Parameters.AddWithValue("@shiftDate", DateTime.Parse(shiftDate));
                    cmdShift.ExecuteNonQuery();
                }

                // إعادة تعيين النموذج بعد إضافة الصيدلية
                txtPharmacyName.Text = "";
                ddlCity.SelectedIndex = 0;
                ddlVillage.Items.Clear();
                ddlVillage.Items.Add(new ListItem("اختر القرية", "0"));
                txtShiftDate.Text = "";

                // تأكيد إضافته
                Response.Redirect("PharmaciesList");
            }
            else
            {
                // إذا كانت الحقول فارغة أو تم اختيار قيمة غير صالحة
                Response.Write("<script>alert('يرجى ملء جميع الحقول');</script>");
            }
        }
    }

}