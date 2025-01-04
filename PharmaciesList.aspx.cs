using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace PharmOpen
{
    public partial class PharmaciesList : System.Web.UI.Page
    {
        string connection = (ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPharmacies();
            }
        }

        // تحميل بيانات الصيدليات من قاعدة البيانات
        private void LoadPharmacies()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = @"SELECT p.pharmacy_id, p.pharmacy_name, c.city_id, c.city_name, v.village_name, p.user_id, u.email 
                                FROM pharmacies p 
                                LEFT JOIN villages v ON p.village_id = v.village_id
                                LEFT JOIN cities c ON v.city_id = c.city_id
                                LEFT JOIN users u on u.id = p.user_id ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // التعامل مع التعديل في GridView
        // التعامل مع التعديل في GridView
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadPharmacies(); // إعادة تحميل البيانات مع تمكين وضع التعديل

            // تحميل القيم للمدن والقرى في القوائم المنسدلة
            DropDownList ddlCity = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("ddlCity");
            DropDownList ddlVillage = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("ddlVillage");

            // تحميل المدن في الـ DropDownList
            using (SqlConnection con = new SqlConnection(connection))
            {
                string citiesQuery = "SELECT city_id, city_name FROM cities";
                SqlDataAdapter cityAdapter = new SqlDataAdapter(citiesQuery, con);
                DataTable citiesTable = new DataTable();
                cityAdapter.Fill(citiesTable);

                ddlCity.DataSource = citiesTable;
                ddlCity.DataTextField = "city_name";
                ddlCity.DataValueField = "city_id";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("Select City", ""));
            }

            // تحميل القرى بناءً على المدينة المحددة في الـ DropDownList
            int currentCityId = Convert.ToInt32((GridView1.Rows[e.NewEditIndex].FindControl("city_id") as Label).Text);
            using (SqlConnection con = new SqlConnection(connection))
            {
                string villagesQuery = "SELECT village_id, village_name FROM villages WHERE city_id = @city_id";
                SqlCommand cmd = new SqlCommand(villagesQuery, con);
                cmd.Parameters.AddWithValue("@city_id", currentCityId);
                SqlDataAdapter villageAdapter = new SqlDataAdapter(cmd);
                DataTable villagesTable = new DataTable();
                villageAdapter.Fill(villagesTable);

                ddlVillage.DataSource = villagesTable;
                ddlVillage.DataTextField = "village_name";
                ddlVillage.DataValueField = "village_id";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, new ListItem("Select Village", ""));
            }
        }

        // التعامل مع التحديث في GridView
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // التحقق من أن قيمة الـ pharmacy_id موجودة
            int pharmacyId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // الحصول على قيمة اسم الصيدلية
            string pharmacyName = (GridView1.Rows[e.RowIndex].FindControl("txtEditPharmacyName") as TextBox).Text;

            // التحقق من أن قيمة الـ villageId ليست فارغة قبل التحويل
            DropDownList ddlVillage = (GridView1.Rows[e.RowIndex].FindControl("ddlVillage") as DropDownList);
            int villageId = -1;  // قيمة افتراضية تشير إلى عدم الاختيار
            if (!string.IsNullOrEmpty(ddlVillage.SelectedValue))
            {
                villageId = Convert.ToInt32(ddlVillage.SelectedValue);
            }

            // التحقق من أن قيمة الـ userId ليست فارغة قبل التحويل
            string userIdText = (GridView1.Rows[e.RowIndex].FindControl("txtEditUserId") as TextBox).Text;
            int userId = -1;  // قيمة افتراضية تشير إلى عدم الاختيار
            if (!string.IsNullOrEmpty(userIdText))
            {
                userId = Convert.ToInt32(userIdText);
            }

            // التحقق من أن القيم صالحة قبل المتابعة مع التحديث
            if (villageId != -1 && userId != -1 && !string.IsNullOrEmpty(pharmacyName))
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    string query = "UPDATE pharmacies SET pharmacy_name = @pharmacy_name, village_id = @village_id, user_id = @user_id WHERE pharmacy_id = @pharmacy_id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@pharmacy_id", pharmacyId);
                    cmd.Parameters.AddWithValue("@pharmacy_name", pharmacyName);
                    cmd.Parameters.AddWithValue("@village_id", villageId);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                GridView1.EditIndex = -1;
                lblError.Text = "";
                LoadPharmacies(); // إعادة تحميل البيانات بعد التحديث
            }
            else
            {
                // إذا كانت القيم غير صالحة، يمكنك إضافة رسائل خطأ للمستخدم هنا.
                // يمكنك إضافة رسالة تنبيه أو تخصيص رد فعل لتوضيح سبب الفشل.
                // مثال: 
                lblError.Text = "Please make sure all fields are filled correctly.";
            }
        }



        // التعامل مع الحذف في GridView
        // التعامل مع الحذف في GridView
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    int pharmacyId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

    using (SqlConnection con = new SqlConnection(connection))
    {
        // حذف السجلات المرتبطة في جدول shifts
        string deleteShiftsQuery = "DELETE FROM shifts WHERE pharmacy_id = @pharmacy_id";
        SqlCommand cmdDeleteShifts = new SqlCommand(deleteShiftsQuery, con);
        cmdDeleteShifts.Parameters.AddWithValue("@pharmacy_id", pharmacyId);

        con.Open();
        cmdDeleteShifts.ExecuteNonQuery(); // حذف السجلات المرتبطة في shifts
        con.Close();
        
        // الآن حذف الصيدلية من جدول pharmacies
        string deletePharmacyQuery = "DELETE FROM pharmacies WHERE pharmacy_id = @pharmacy_id";
        SqlCommand cmdDeletePharmacy = new SqlCommand(deletePharmacyQuery, con);
        cmdDeletePharmacy.Parameters.AddWithValue("@pharmacy_id", pharmacyId);

        con.Open();
        cmdDeletePharmacy.ExecuteNonQuery(); // حذف الصيدلية
        con.Close();
    }

    LoadPharmacies(); // إعادة تحميل البيانات بعد الحذف
}


        // التعامل مع إلغاء التعديل في GridView
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadPharmacies(); // إعادة تحميل البيانات بعد إلغاء التعديل
        }
    }
}
