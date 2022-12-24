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
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLHT
{
    public partial class frmQLTS : Form
    {
        public frmQLTS()
        {
            InitializeComponent();
        }
        string connectDb = "Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True";
        public void load()
        {
            SqlConnection conn = new SqlConnection(connectDb);
            try
            {
                conn.Open();
                string sql = "select * from TUSI";
                SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridViewTusi.DataSource = tb;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }

        }
        private void frmQLTS_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnNhaplai_Click(object sender, EventArgs e)
        {
            txtMatusi.Clear();
            txtTentusi.Clear();
            txtPhai.Clear();
            txtNgaysinh.Clear();
            txtMahoidong.Clear();
            txtQuequan.Clear();
            txtMalophoc.Clear();
        }
        public bool KiemtraMatusi(string IDTS)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            conn.Open();
            string sql = "select IDTS from TUSI where IDTS='" + txtMatusi.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public bool kiemtraMatusi(string IDTS)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            conn.Open();
            string sql = "select IDTS from TUSI where IDTS='" + txtMatusi.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn muốn xóa hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(connectDb);
                conn.Open();
                string sql = "delete from TUSI where IDTS='" + txtMatusi.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công");
                load();
                conn.Close();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            try
            {
                conn.Open();
                string sql = "update TUSI set TENTUSI=N'" + txtTentusi.Text + "',PHAI=N'" + txtPhai.Text + "',NGAYSINH='" + txtNgaysinh.Text + "',MAHOIDONG=N'" + txtMahoidong.Text + "',QUEQUAN='" + txtQuequan.Text + "',MALOPHOC='" + txtMalophoc.Text + "' where IDTS='" + txtMatusi.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = (int)cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành cộng");
                    load();
                }
                else
                {
                    MessageBox.Show("Sửa thật bại!");
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuat file thanh cong!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuat file ko thanh cong!" + ex.Message);
                }

            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Export Excel";
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImportExcel(openFileDialog.FileName);
                    MessageBox.Show("Nhap file thanh cong!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhap file ko thanh cong!" + ex.Message);
                }

            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
           frmRPQLTS rPQLTS= new frmRPQLTS();
            rPQLTS.Show();
        }

        private void dataGridViewTusi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMatusi.Text = dataGridViewTusi.CurrentRow.Cells[0].Value.ToString();
            txtTentusi.Text = dataGridViewTusi.CurrentRow.Cells[1].Value.ToString();
            txtPhai.Text = dataGridViewTusi.CurrentRow.Cells[2].Value.ToString();
            txtNgaysinh.Text = dataGridViewTusi.CurrentRow.Cells[3].Value.ToString();
            txtMahoidong.Text = dataGridViewTusi.CurrentRow.Cells[4].Value.ToString();
            txtQuequan.Text = dataGridViewTusi.CurrentRow.Cells[5].Value.ToString();
            txtMalophoc.Text = dataGridViewTusi.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            try
            {
                if (txtMatusi.Text != "" && txtTentusi.Text != "" && txtPhai.Text != "" && txtNgaysinh.Text != "" && txtQuequan.Text != "" && txtQuequan.Text != "" && txtMalophoc.Text != "")
                {
                    if (kiemtraMatusi(txtMatusi.Text) == true)
                        MessageBox.Show("Mã tu sĩ đã tồn tại");
                    else
                    {
                        conn.Open();
                        string sql = "insert into TUSI values('" + txtMatusi.Text + "',N'" + txtTentusi.Text + "','" + txtPhai.Text + "','" + txtNgaysinh.Text + "','" + txtMahoidong.Text + "',N'" + txtQuequan.Text + "','" + txtMalophoc.Text + "')";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        int kq = (int)cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm thành cộng");
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thật bại!");
                        }
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập đủ dữ liệu");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            try
            {
                conn.Open();
                string sqlTimKiem = "SELECT * FROM TUSI WHERE IDTS=@IDTS";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("IDTS", txtTimKiem.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridViewTusi.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }
        }
        private void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dataGridViewTusi.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridViewTusi.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridViewTusi.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewTusi.Columns.Count; j++)
                    application.Cells[i + 2, j + 1] = dataGridViewTusi.Rows[i].Cells[j].Value;
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }
        private void ImportExcel(string path)
        {
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                DataTable dataTable = new DataTable();
                for (int i = excelWorksheet.Dimension.Start.Column; i <= excelWorksheet.Dimension.End.Column; i++)
                {
                    dataTable.Columns.Add(excelWorksheet.Cells[1, i].Value.ToString());
                }
                for (int i = excelWorksheet.Dimension.Start.Row; i <= excelWorksheet.Dimension.End.Row; i++)
                {
                    List<string> listRows = new List<string>();
                    for (int j = excelWorksheet.Dimension.Start.Column; j <= excelWorksheet.Dimension.End.Column; j++)
                    {
                        listRows.Add(excelWorksheet.Cells[i, j].Value.ToString());
                    }
                    dataTable.Rows.Add(listRows.ToArray());
                }
                dataGridViewTusi.DataSource = dataTable;

            }
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
