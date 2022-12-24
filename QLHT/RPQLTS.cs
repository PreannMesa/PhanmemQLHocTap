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
    public partial class frmRPQLTS : Form
    {
        public frmRPQLTS()
        {
            InitializeComponent();
        }

        private void frmRPQLTS_Load(object sender, EventArgs e)
        {
            this.reportViewer4.RefreshReport();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");
        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from TUSI", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer4.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet4", dt);
            reportViewer4.LocalReport.ReportPath = "Report4.rdlc";
            reportViewer4.LocalReport.DataSources.Add(source);
            reportViewer4.RefreshReport();
        }
    }
}
