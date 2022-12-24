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
    public partial class frmReportKetquahoctap : Form
    {
        public frmReportKetquahoctap()
        {
            InitializeComponent();
        }

        private void frmReportKetquahoctap_Load(object sender, EventArgs e)
        {
            this.reportViewer8.RefreshReport();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");
        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from KETQUAHOCTAP", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer8.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet8", dt);
            reportViewer8.LocalReport.ReportPath = "Report8.rdlc";
            reportViewer8.LocalReport.DataSources.Add(source);
            reportViewer8.RefreshReport();
        }
    }
}
