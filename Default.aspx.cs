using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace PharmOpen
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayShifts();
                DisplayTips();
                DisplayAds();
            }
        }

        private void DisplayShifts()
        {
            // الاستعلام للحصول على البيانات
            SqlCommand cmd = new SqlCommand("SELECT p.pharmacy_name, s.shift_day, v.village_name, c.city_name " +
                                            "FROM shifts s " +
                                            "INNER JOIN pharmacies p ON s.pharmacy_id = p.pharmacy_id " +
                                            "INNER JOIN villages v ON p.village_id = v.village_id " +
                                            "INNER JOIN cities c ON v.city_id = c.city_id " +
                                            "WHERE DATEPART(WEEKDAY, s.shift_day) = 6", con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // تعيين مصدر البيانات للـ GridView
            gvShifts.DataSource = reader;

            // إيقاف AutoGenerateColumns
            gvShifts.AutoGenerateColumns = false;

            // إضافة الأعمدة يدويًا
            gvShifts.Columns.Clear();

            // إضافة عمود اسم الصيدلية
            BoundField pharmacyColumn = new BoundField();
            pharmacyColumn.DataField = "pharmacy_name";  // اسم العمود في قاعدة البيانات
            pharmacyColumn.HeaderText = "اسم الصيدلية";  // النص الذي سيظهر في رأس العمود
            gvShifts.Columns.Add(pharmacyColumn);

            // إضافة عمود يوم المناوبة
            BoundField shiftDayColumn = new BoundField();
            shiftDayColumn.DataField = "shift_day";
            shiftDayColumn.HeaderText = "يوم المناوبة";
            gvShifts.Columns.Add(shiftDayColumn);

            // إضافة عمود اسم القرية
            BoundField villageColumn = new BoundField();
            villageColumn.DataField = "village_name";
            villageColumn.HeaderText = "اسم القرية";
            gvShifts.Columns.Add(villageColumn);

            // إضافة عمود اسم المدينة
            BoundField cityColumn = new BoundField();
            cityColumn.DataField = "city_name";
            cityColumn.HeaderText = "اسم المدينة";
            gvShifts.Columns.Add(cityColumn);

            // ربط البيانات بـ GridView
            gvShifts.DataBind();

            con.Close();
        }


        private void DisplayTips()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tips", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            rptTips.DataSource = reader;
            rptTips.DataBind();
            con.Close();
        }

        private void DisplayAds()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ads", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            rptAds.DataSource = reader;
            rptAds.DataBind();
            con.Close();
        }
    }
}
