using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLCH
{
    public partial class FrmGiaodienchinh : Form
    {
        public FrmGiaodienchinh()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        
        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            
        }
        private void HethongToolStripMenuItem_Click(object sender, EventArgs e)
        {
                FrmHethong fr = new FrmHethong();
                this.Hide();
                fr.ShowDialog();
                this.Show();
        }

        private void mntDoimatkhau_Click(object sender, EventArgs e)
        {
                FrmDoimatkhau fr = new FrmDoimatkhau();
                fr.ShowDialog();
        }

        private void mntDangxuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
