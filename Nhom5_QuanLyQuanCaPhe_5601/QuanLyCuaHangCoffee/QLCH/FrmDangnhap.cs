using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH
{
    public partial class FrmDangnhap : Form
    {
        public FrmDangnhap()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            data.getConnect();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                string taikhoan = txtTaikhoan.Text;
                string matkhau = txtMatkhau.Text;
                string query = "SELECT * FROM TAIKHOANDANGNHAP WHERE TENTK = '"+taikhoan+"' AND MATKHAU = '"+matkhau+"'";
                DataTable result = data.ExecuteQuery(query);
                if (result.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công.");
                    FrmGiaodienchinh fr = new FrmGiaodienchinh();
                    this.Hide();
                    fr.ShowDialog();
                    this.Show();
                }
                else MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
