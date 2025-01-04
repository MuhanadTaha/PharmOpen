using System;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PharmOpen
{
    public partial class VillageList : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadVillages();
            }
        }

        // تحميل البيانات من قاعدة البيانات لعرضها في GridView
        private void LoadVillages()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT  village_id, village_name, c.city_name, v.city_id FROM villages v LEFT JOIN Cities c on v.[city_id] = c.[city_id]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // التعامل مع التعديل في GridView
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadVillages(); // إعادة تحميل البيانات مع تمكين وضع التعديل
        }

        // التعامل مع التحديث في GridView
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int villageId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string villageName = (GridView1.Rows[e.RowIndex].FindControl("txtEditVillageName") as TextBox).Text;
            int cityId = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("txtEditCityId") as TextBox).Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE villages SET village_name = @village_name, city_id = @city_id WHERE village_id = @village_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@village_id", villageId);
                cmd.Parameters.AddWithValue("@village_name", villageName);
                cmd.Parameters.AddWithValue("@city_id", cityId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            GridView1.EditIndex = -1;
            LoadVillages(); // إعادة تحميل البيانات بعد التحديث
        }

        // التعامل مع الحذف في GridView
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int villageId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM villages WHERE village_id = @village_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@village_id", villageId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadVillages(); // إعادة تحميل البيانات بعد الحذف
        }

        // التعامل مع إلغاء التعديل في GridView
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadVillages(); // إعادة تحميل البيانات بعد إلغاء التعديل
        }
    }
}
