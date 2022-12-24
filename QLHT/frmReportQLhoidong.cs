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
    public partial class frmReportHd : Form
    {
        public frmReportHd()
        {
            InitializeComponent();
        }

        private void frmReportHd_Load(object sender, EventArgs e)
        {

            this.reportViewer2.RefreshReport();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");
        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from HOIDONG", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer2.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet2", dt);
            reportViewer2.LocalReport.ReportPath = "Report2.rdlc";
            reportViewer2.LocalReport.DataSources.Add(source);
            reportViewer2.RefreshReport();
        }
    }
}
