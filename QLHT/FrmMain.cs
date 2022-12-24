using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHT
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void quảnLýLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLLH f = new frmQLLH();
            f.Show();
        }

        private void quảnLýHộiDòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLHoidong frm = new frmQLHoidong();
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmQLGV qLGV=new frmQLGV();
            qLGV.Show();
        }

        private void quảnLýTuSĩToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLTS qlts=new frmQLTS();
            qlts.Show();
        }

        private void danhMụcMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMMH dMMH=new frmDMMH();
            dMMH.Show();
        }

        private void danhMụcKhảNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhmucKN danhmucKN=new DanhmucKN();
            danhmucKN.Show(); 
        }

        private void danhMụcKhoaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDanhmucKH f = new FormDanhmucKH();
            f.Show();
        }

        private void kếtQuảHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKetquahoctap f = new frmKetquahoctap();
            f.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
