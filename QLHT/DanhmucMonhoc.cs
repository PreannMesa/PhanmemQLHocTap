using DevExpress.CodeParser;
using OfficeOpenXml;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace QLHT
{
    public partial class frmDMMH : Form
    {
        public frmDMMH()
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
                string sql = "select * from MONHOC";
                SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridViewMonhoc.DataSource = tb;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }

        }

        private void btnNhaplai_Click(object sender, EventArgs e)
        {
            txtMamonhoc.Clear();
            txtTenmonhoc.Clear();
            txtSotiet.Clear();
        }

        private void frmDMMH_Load(object sender, EventArgs e)
        {
            load();
        }
        public bool kiemtraMamonhoc(string MAMONHOC)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            conn.Open();
            string sql = "select MAMONHOC from MONHOC where MAMONHOC='" + txtMamonhoc.Text + "'";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            try
            {
                if (txtMamonhoc.Text != "" && txtTenmonhoc.Text != "" && txtSotiet.Text != "")
                {
                    if (kiemtraMamonhoc(txtMamonhoc.Text) == true)
                        MessageBox.Show("Mã môn học đã tồn tại");
                    else
                    {
                        conn.Open();
                        string sql = "insert into MONHOC values('" + txtMamonhoc.Text + "',N'" + txtTenmonhoc.Text + "',N'" + txtSotiet.Text + "')";
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn muốn xóa hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(connectDb);
                conn.Open();
                string sql = "delete from MONHOC where MAMONHOC='" + txtMamonhoc.Text + "'";
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
                string sql = "update MONHOC set TENMONHOC=N'" + txtTenmonhoc.Text + "',SOTIET='" + txtSotiet.Text + "' where MAMONHOC='" + txtMamonhoc.Text + "'";
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
        private void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dataGridViewMonhoc.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridViewMonhoc.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridViewMonhoc.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewMonhoc.Columns.Count; j++)
                    application.Cells[i + 2, j + 1] = dataGridViewMonhoc.Rows[i].Cells[j].Value;
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
                dataGridViewMonhoc.DataSource = dataTable;

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
            frmRPMH f=new frmRPMH();
            f.Show();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            try
            {
                conn.Open();
                string sqlTimKiem = "SELECT * FROM MONHOC WHERE MAMONHOC=@MAMONHOC";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("MAMONHOC", txtTimKiem.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridViewMonhoc.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }
        }

        private void dataGridViewMonhoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMamonhoc.Text = dataGridViewMonhoc.CurrentRow.Cells[0].Value.ToString();
            txtTenmonhoc.Text = dataGridViewMonhoc.CurrentRow.Cells[1].Value.ToString();
            txtSotiet.Text = dataGridViewMonhoc.CurrentRow.Cells[2].Value.ToString();

        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
