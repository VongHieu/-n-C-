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
    public partial class FrmDoimatkhau : Form
    {
        public FrmDoimatkhau()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmDoimatkhau_Load(object sender, EventArgs e)
        {

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"select * from TAIKHOANDANGNHAP where TENTK='" + txtTendn.Text + "' and MATKHAU='" + txtMatk.Text + "'";

                if (data.ExeReader(query))
                {
                    if (txtNhapmkmoi.Text == txtNhaplaimk.Text)
                    {
                        data.ExecuteNonQuery(@"update TAIKHOANDANGNHAP set MATKHAU = '" + txtNhapmkmoi.Text + "' where TENTK = '" + txtTendn.Text + "'");
                        MessageBox.Show("Thay đổi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMatk.Text = "";
                        txtNhaplaimk.Text = "";
                        txtNhapmkmoi.Text = "";
                        txtTendn.Text = "";
                        txtTendn.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNhaplaimk.Text = "";
                        txtNhapmkmoi.Text = "";
                        txtNhapmkmoi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtNhapmkmoi.Text = "";
                    txtNhaplaimk.Text = "";
                    txtTendn.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
