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
    public partial class FrmHethong : Form
    {
        public FrmHethong()
        {
            InitializeComponent();
        }

        private void mntqlNhanvien_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmThongtinnhanvien"))
            {
                FrmThongtinnhanvien frm = new FrmThongtinnhanvien();
                frm.MdiParent = this;
                frm.Name = "FrmThongtinnhanvien";
                frm.Show();
            }
            else ActiveChildForm("FrmThongtinnhanvien");
        }

        private void mntQltaikhoan_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmQuanlytaikhoan"))
            {
                FrmQuanlytaikhoan frm = new FrmQuanlytaikhoan();
                frm.MdiParent = this;
                frm.Name = "FrmQuanlytaikhoan";
                frm.Show();
            }
            else ActiveChildForm("FrmQuanlytaikhoan");

        }

        private void FrmHethong_Load(object sender, EventArgs e)
        {

        }

        private bool CheckExitsForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void mntqlKhachhang_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmThongtinkhachhang"))
            {
                FrmThongtinkhachhang frm = new FrmThongtinkhachhang();
                frm.MdiParent = this;
                frm.Name = "FrmThongtinkhachhang";
                frm.Show();
            }
            else ActiveChildForm("FrmThongtinkhachhang");
        }

        private void mntqlThucdon_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmQuanlythucdon"))
            {
                FrmQuanlythucdon frm = new FrmQuanlythucdon();
                frm.MdiParent = this;
                frm.Name = "FrmQuanlythucdon";
                frm.Show();
            }
            else ActiveChildForm("FrmQuanlythucdon");
        }

        private void mntqlHoadonban_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmHoaDonBanHang"))
            {
                FrmHoaDonBanHang frm = new FrmHoaDonBanHang();
                frm.MdiParent = this;
                frm.Name = "FrmHoaDonBanHang";
                frm.Show();
            }
            else ActiveChildForm("FrmHoaDonBanHang");
        }

        private void mntqlQuanlykhuvuc_Click(object sender, EventArgs e)
        {

        }

        private void mntqlThongtinban_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmQuanLyBan"))
            {
                FrmQuanLyBan frm = new FrmQuanLyBan();
                frm.MdiParent = this;
                frm.Name = "FrmQuanLyBan";
                frm.Show();
            }
            else ActiveChildForm("FrmQuanLyBan");
        }

        private void mntqlNhacungcap_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmNhaCungCap"))
            {
                FrmNhaCungCap frm = new FrmNhaCungCap();
                frm.MdiParent = this;
                frm.Name = "FrmNhaCungCap";
                frm.Show();
            }
            else ActiveChildForm("FrmNhaCungCap");
        }

        private void mntqlThongtinhang_Click(object sender, EventArgs e)
        {
            if (!CheckExitsForm("FrmQuanLyHangHoa"))
            {
                FrmQuanLyHangHoa frm = new FrmQuanLyHangHoa();
                frm.MdiParent = this;
                frm.Name = "FrmQuanLyHangHoa";
                frm.Show();
            }
            else ActiveChildForm("FrmQuanLyHangHoa");
        }

        private void mntqlHoadonnhap_Click(object sender, EventArgs e)
        {

            if (!CheckExitsForm("FrmNhapHang"))
            {
                FrmNhapHang frm = new FrmNhapHang();
                frm.MdiParent = this;
                frm.Name = "FrmNhapHang";
                frm.Show();
            }
            else ActiveChildForm("FrmNhapHang");
        }

        private void FrmHethong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                if (!CheckExitsForm("FrmThongtinnhanvien"))
                {
                    FrmThongtinnhanvien frm = new FrmThongtinnhanvien();
                    frm.MdiParent = this;
                    frm.Name = "FrmThongtinnhanvien";
                    frm.Show();
                }
                else ActiveChildForm("FrmThongtinnhanvien");
            }

            if (e.Control == true && e.KeyCode == Keys.B)
            {
                if (!CheckExitsForm("FrmThongtinkhachhang"))
                {
                    FrmThongtinkhachhang frm = new FrmThongtinkhachhang();
                    frm.MdiParent = this;
                    frm.Name = "FrmThongtinkhachhang";
                    frm.Show();
                }
                else ActiveChildForm("FrmThongtinkhachhang");

            }
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                if (!CheckExitsForm("FrmQuanlythucdon"))
                {
                    FrmQuanlythucdon frm = new FrmQuanlythucdon();
                    frm.MdiParent = this;
                    frm.Name = "FrmQuanlythucdon";
                    frm.Show();
                }
                else ActiveChildForm("FrmQuanlythucdon");
            }
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                if (!CheckExitsForm("FrmHoaDonBanHang"))
                {
                    FrmHoaDonBanHang frm = new FrmHoaDonBanHang();
                    frm.MdiParent = this;
                    frm.Name = "FrmHoaDonBanHang";
                    frm.Show();
                }
                else ActiveChildForm("FrmHoaDonBanHang");

            }
            if (e.Control == true && e.KeyCode == Keys.F)
            {
                if (!CheckExitsForm("FrmNhapHang"))
                {
                    FrmNhapHang frm = new FrmNhapHang();
                    frm.MdiParent = this;
                    frm.Name = "FrmNhapHang";
                    frm.Show();
                }
                else ActiveChildForm("FrmNhapHang");
                

            }
            if (e.Control == true && e.KeyCode == Keys.F1)
            {
                if (!CheckExitsForm("FrmNhaCungCap"))
                {
                    FrmNhaCungCap frm = new FrmNhaCungCap();
                    frm.MdiParent = this;
                    frm.Name = "FrmNhaCungCap";
                    frm.Show();
                }
                else ActiveChildForm("FrmNhaCungCap"); 
            }
            if (e.Control == true && e.KeyCode == Keys.F2)
            {
                if (!CheckExitsForm("FrmQuanLyHangHoa"))
                {
                    FrmQuanLyHangHoa frm = new FrmQuanLyHangHoa();
                    frm.MdiParent = this;
                    frm.Name = "FrmQuanLyHangHoa";
                    frm.Show();
                }
                else ActiveChildForm("FrmQuanLyHangHoa");

            }
            if (e.Control == true && e.KeyCode == Keys.K)
            {
                if (!CheckExitsForm("FrmQuanLyBan"))
                {
                    FrmQuanLyBan frm = new FrmQuanLyBan();
                    frm.MdiParent = this;
                    frm.Name = "FrmQuanLyBan";
                    frm.Show();
                }
                else ActiveChildForm("FrmQuanLyBan");

            }
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                if (!CheckExitsForm("FrmQuanlytaikhoan"))
                {
                    FrmQuanlytaikhoan frm = new FrmQuanlytaikhoan();
                    frm.MdiParent = this;
                    frm.Name = "FrmQuanlytaikhoan";
                    frm.Show();
                }
                else ActiveChildForm("FrmQuanlytaikhoan");
            }
        }
    }
}
