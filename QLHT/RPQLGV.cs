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
    public partial class frmRPGV : Form
    {
        public frmRPGV()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3BVBHQ;Initial Catalog=QUANLYHOCTAP;Integrated Security=True");
        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from GIAOVIEN", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet3", dt);
            reportViewer3.LocalReport.ReportPath = "Report3.rdlc";
            reportViewer3.LocalReport.DataSources.Add(source);
            reportViewer3.RefreshReport();
        }

        private void frmRPGV_Load(object sender, EventArgs e)
        {
            this.reportViewer3.RefreshReport();
        }
    }
}
