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
    public partial class frmReportKN : Form
    {
        public frmReportKN()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");
        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from KHANANG", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer6.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet6", dt);
            reportViewer6.LocalReport.ReportPath = "Report6.rdlc";
            reportViewer6.LocalReport.DataSources.Add(source);
            reportViewer6.RefreshReport();
        }

        private void frmReportKN_Load(object sender, EventArgs e)
        {
            this.reportViewer6.RefreshReport();
        }
    }
}
