using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlytiendien
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chuỗi kết nối
            string connStr = "Data Source=DESKTOP-PID86FA;Initial Catalog=QuanLyTienDienDb;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // Kết nối thành công
                    MessageBox.Show("✅ Kết nối SQL Server thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Sau khi kết nối OK, mới chạy form
                Application.Run(new DangNhap());
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Không thể kết nối cơ sở dữ liệu:\n\n" + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Không chạy app nếu kết nối thất bại
            }
        }
    }
}
