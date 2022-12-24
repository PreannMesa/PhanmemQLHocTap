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
    public partial class frmRPMH : Form
    {
        public frmRPMH()
        {
            InitializeComponent();
        }

        private void frmRPMH_Load(object sender, EventArgs e)
        {
            this.reportViewer5.RefreshReport();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from MONHOC", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer5.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet5", dt);
            reportViewer5.LocalReport.ReportPath = "Report5.rdlc";
            reportViewer5.LocalReport.DataSources.Add(source);
            reportViewer5.RefreshReport();
        }
    }
}
