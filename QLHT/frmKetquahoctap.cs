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
    public partial class frmKetquahoctap : Form
    {
        public frmKetquahoctap()
        {
            InitializeComponent();
        }
        string connectDb = "Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True";
        private void frmKetquahoctap_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            SqlConnection conn = new SqlConnection(connectDb);
            try
            {
                conn.Open();
                string sql = "select * from KETQUAHOCTAP";
                SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridViewKetquahoctap.DataSource = tb;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }

        }

        private void btnNhaplai_Click(object sender, EventArgs e)
        {
            txtMatusi.Clear();
            txtMakh.Clear();
            txtDiemthi.Clear();
            txtDiemTL.Clear();
        }
        public bool kiemtraMatusi(string IDTS)
        {
            SqlConnection conn = new SqlConnection(connectDb);
            conn.Open();
            string sql = "select IDTS from KETQUAHOCTAP where IDTS='" + txtMatusi.Text + "'";
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
                if (txtMatusi.Text != "" && txtMakh.Text != "" && txtDiemthi.Text != "" && txtDiemTL.Text != "")
                {
                    if (kiemtraMatusi(txtMatusi.Text) == true)
                        MessageBox.Show("Mã tu sĩ đã tồn tại");
                    else
                    {
                        conn.Open();
                        string sql = "insert into KETQUAHOCTAP values('" + txtMatusi.Text + "','" + txtMakh.Text + "','" + txtDiemthi.Text + "','" + txtDiemTL.Text + "')";
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
                string sql = "delete from KETQUAHOCTAP where IDTS='" + txtMatusi.Text + "'";
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
                string sql = "update KETQUAHOCTAP set MAKHOAHOC='" + txtMakh.Text + "',DIEMTHI='" + txtDiemthi.Text + "',DIEMTIEULUAN='" + txtDiemTL.Text + "' where IDTS='" + txtMatusi.Text + "'";
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
            frmReportKetquahoctap frm=new frmReportKetquahoctap();
            frm.Show();
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
                dataGridViewKetquahoctap.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection" + ex.Message);
            }
        }

        private void dataGridViewKetquahoctap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMatusi.Text = dataGridViewKetquahoctap.CurrentRow.Cells[0].Value.ToString();
            txtMakh.Text = dataGridViewKetquahoctap.CurrentRow.Cells[1].Value.ToString();
            txtDiemthi.Text = dataGridViewKetquahoctap.CurrentRow.Cells[2].Value.ToString();
            txtDiemTL.Text = dataGridViewKetquahoctap.CurrentRow.Cells[3].Value.ToString();
        }
        private void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dataGridViewKetquahoctap.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridViewKetquahoctap.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridViewKetquahoctap.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewKetquahoctap.Columns.Count; j++)
                    application.Cells[i + 2, j + 1] = dataGridViewKetquahoctap.Rows[i].Cells[j].Value;
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
                for (int i = excelWorksheet.Dimension.Start.Column; i < excelWorksheet.Dimension.End.Column; i++)
                {
                    dataTable.Columns.Add(excelWorksheet.Cells[1, i].Value.ToString());
                }
                for (int i = excelWorksheet.Dimension.Start.Row; i < excelWorksheet.Dimension.End.Row; i++)
                {
                    List<string> listRows = new List<string>();
                    for (int j = excelWorksheet.Dimension.Start.Column; j < excelWorksheet.Dimension.End.Column; j++)
                    {
                        listRows.Add(excelWorksheet.Cells[i, j].Value.ToString());
                    }
                    dataTable.Rows.Add(listRows.ToArray());
                }
                dataGridViewKetquahoctap.DataSource = dataTable;

            }
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
