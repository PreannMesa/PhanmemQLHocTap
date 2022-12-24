using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHT
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");

            try
            {
                conn.Open();
                string user = txtNguoidung.Text;
                string pass = txtMatkhau.Text;
                string sql = "select * from NGUOIDUNG WHERE TAIKHOAN='" + user + "' AND MATKHAU='" + pass + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành cộng ");
                    frmMain f = new frmMain();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thật bại!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
