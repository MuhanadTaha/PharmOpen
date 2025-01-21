using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PharmOpen
{
    public partial class TipsList : System.Web.UI.Page
    {
        string connection = (ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAds();
            }
        }

        // تحميل البيانات من قاعدة البيانات لعرضها في GridView
        private void LoadAds()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "SELECT tip_id, tip_title, tip_content, tip_image, user_id, email FROM tips t left join users u on t.user_id=u.ID";
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
            LoadAds(); // إعادة تحميل البيانات مع تمكين وضع التعديل
        }

        // التعامل مع التحديث في GridView
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int tipid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string tipTitle = (GridView1.Rows[e.RowIndex].FindControl("txtEditAdTitle") as TextBox).Text;
            string tipContent = (GridView1.Rows[e.RowIndex].FindControl("txtEditAdContent") as TextBox).Text;

            // الحصول على العنصر الخاص بالصورة الحالية
            Label lblCurrentImage = GridView1.Rows[e.RowIndex].FindControl("lblCurrentImage") as Label;
            string currentImagePath = lblCurrentImage.Text;

            // تحميل الصورة الجديدة إذا تم تحديدها
            string newImagePath = string.Empty;
            FileUpload fileUpload = GridView1.Rows[e.RowIndex].FindControl("fileUploadAdImage") as FileUpload;

            if (fileUpload != null && fileUpload.HasFile)
            {
                // إذا كانت هناك صورة جديدة يتم حفظها
                string fileName = "new_image_" + Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fileUpload.FileName);
                string savePath = Server.MapPath("~/images/tips/") + fileName;
                fileUpload.SaveAs(savePath);
                newImagePath = "images/tips/" + fileName; // بناء المسار الجديد
            }
            else
            {
                // إذا لم يتم تحميل صورة جديدة، استخدم المسار الحالي
                newImagePath = currentImagePath;
            }

            int userId = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("txtEditUserId") as TextBox).Text);

            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "UPDATE tips SET tip_title = @tip_title, tip_content = @tip_content, tip_image = @tip_image, user_id = @user_id WHERE tip_id = @tip_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tip_id", tipid);
                cmd.Parameters.AddWithValue("@tip_title", tipTitle);
                cmd.Parameters.AddWithValue("@tip_content", tipContent);
                cmd.Parameters.AddWithValue("@tip_image", newImagePath); // استخدام المسار الصحيح
                cmd.Parameters.AddWithValue("@user_id", userId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            GridView1.EditIndex = -1;
            LoadAds(); // إعادة تحميل البيانات بعد التحديث
        }




        // التعامل مع الحذف في GridView
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int tipid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "DELETE FROM tips WHERE tip_id = @tip_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tip_id", tipid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadAds(); // إعادة تحميل البيانات بعد الحذف

        }

        // التعامل مع إلغاء التعديل في GridView
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadAds(); // إعادة تحميل البيانات بعد إلغاء التعديل
        }
    }
}