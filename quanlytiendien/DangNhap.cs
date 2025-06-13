using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlytiendien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        // Chuỗi kết nối – bạn có thể lấy từ App.config nếu muốn
        private string connect = @"Data Source=DESKTOP-PID86FA;Initial Catalog=QuanLyTienDienDb;Integrated Security=True";

        public SqlConnection conn;
        public static string username;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                username = txtdangnhap.Text.Trim();
                string pass = txtmatkhau.Text.Trim();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pass))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!");
                    return;
                }

                conn = new SqlConnection(connect);
                conn.Open();

                string sql = "SELECT * FROM NHANVIEN WHERE Tt < 9 AND Tdn = @username";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string dncheck = reader["Tdn"].ToString();
                    string passcheck = reader["Mk"].ToString();

                    if (username.Equals(dncheck) && pass.Equals(passcheck))
                    {
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng.");
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
