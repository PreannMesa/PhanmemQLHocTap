using Microsoft.Reporting.WinForms;
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
    public partial class frmReportKH : Form
    {
        public frmReportKH()
        {
            InitializeComponent();
        }

        private void frmReportKH_Load(object sender, EventArgs e)
        {
            this.reportViewer7.RefreshReport();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");
        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from KHOAHOC", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer7.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet7", dt);
            reportViewer7.LocalReport.ReportPath = "Report7.rdlc";
            reportViewer7.LocalReport.DataSources.Add(source);
            reportViewer7.RefreshReport();
        }
    }
}
