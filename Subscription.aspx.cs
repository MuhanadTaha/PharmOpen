using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;

namespace PharmOpen
{
    public partial class Subscription : Page
    {
        // إنشاء الاتصال بقاعدة البيانات باستخدام سلسلة الاتصال
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppDBConnectionString"].ConnectionString);

        // عندما يتم تحميل الصفحة للمرة الأولى
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // لا حاجة لتحميل المدن أو القرى لأنك طلبت فقط البيانات الأساسية
            }
        }

        // عند الضغط على زر "تسجيل الاشتراك"
        protected void SaveSubscription(object sender, EventArgs e)
        {
            // قراءة البيانات المدخلة من النموذج
            string mobile = txtMobile.Text;
            string email = txtEmail.Text;
            DateTime subscriptionDate = DateTime.Now;

            // فتح الاتصال بقاعدة البيانات
            conn.Open();

            // تحقق من وجود البريد الإلكتروني في جدول المستخدمين
            string checkUserQuery = "SELECT ID FROM users WHERE email = @Email";
            SqlCommand checkCmd = new SqlCommand(checkUserQuery, conn);
            checkCmd.Parameters.AddWithValue("@Email", email);

            object result = checkCmd.ExecuteScalar();  // إذا كانت النتيجة ليست null، فإن البريد موجود

            if (result != null)
            {
                // إذا كان البريد موجودًا، نضيف الاشتراك في جدول المشتركين
                int userId = Convert.ToInt32(result);

                string insertSubscriberQuery = "INSERT INTO subscribers (user_id, subscription_date) VALUES (@user_id, @subscription_date)";
                SqlCommand subCmd = new SqlCommand(insertSubscriberQuery, conn);
                subCmd.Parameters.AddWithValue("@user_id", userId);
                subCmd.Parameters.AddWithValue("@subscription_date", subscriptionDate);

                subCmd.ExecuteNonQuery();

                Response.Write("<h3>تم الاشتراك بنجاح!</h3>");
            }
            else
            {
                // إذا كان البريد الإلكتروني غير موجود، نضيف المستخدم الجديد أولاً
                string insertUserQuery = "INSERT INTO users (mobile, email, authorized) VALUES (@mobile, @email, 'no')";
                SqlCommand cmd = new SqlCommand(insertUserQuery, conn);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();

                // الحصول على ID المستخدم الذي تم إدخاله
                string getUserIdQuery = "SELECT ID FROM users WHERE email = @Email";
                SqlCommand getIdCmd = new SqlCommand(getUserIdQuery, conn);
                getIdCmd.Parameters.AddWithValue("@Email", email);

                int userId = Convert.ToInt32(getIdCmd.ExecuteScalar());

                // إضافة الاشتراك للمستخدم الجديد
                string insertSubscriberQuery = "INSERT INTO subscribers (user_id, subscription_date) VALUES (@user_id, @subscription_date)";
                SqlCommand subCmd = new SqlCommand(insertSubscriberQuery, conn);
                subCmd.Parameters.AddWithValue("@user_id", userId);
                subCmd.Parameters.AddWithValue("@subscription_date", subscriptionDate);

                subCmd.ExecuteNonQuery();

                Response.Write("<h3>تم الاشتراك بنجاح!</h3>");
            }

            // إغلاق الاتصال بقاعدة البيانات
            conn.Close();
        }
    }
}
