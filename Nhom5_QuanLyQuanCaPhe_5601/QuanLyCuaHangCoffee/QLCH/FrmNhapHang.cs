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

namespace QLCH
{
    public partial class FrmNhapHang : Form
    {
        public FrmNhapHang()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            loadPhieunhap();

            LoadNhacungcap();
            LoadHanghoa();
            DataGridView x = dgvPhieunhap;
            {
                x.Columns[0].Width = 50;
                x.Columns[1].Width = 70;
                x.Columns[2].Width = 70;
                x.Columns[3].Width = 150;
                x.Columns[4].Width = 160;
                x.Columns[5].Width = 90;
                x.Columns[6].Width = 70;
                x.Columns[7].Width = 90;
                x.Columns[8].Width = 90;
                x.Columns[9].Width = 180;
            }
            dgvPhieunhap.Columns[0].HeaderText = "Mã PN";
            dgvPhieunhap.Columns[1].HeaderText = "Mã HH";
            dgvPhieunhap.Columns[2].HeaderText = "Mã NCC";
            dgvPhieunhap.Columns[3].HeaderText = "Tên hàng hóa";
            dgvPhieunhap.Columns[4].HeaderText = "Nhà cung cấp";
            dgvPhieunhap.Columns[5].HeaderText = "Ngày tạo";
            dgvPhieunhap.Columns[6].HeaderText = "Số lượng";
            dgvPhieunhap.Columns[7].HeaderText = "Giá Nhập (vnd)";
            dgvPhieunhap.Columns[8].HeaderText = "Thành tiền (vnd)";
            dgvPhieunhap.Columns[9].HeaderText = "Ghi chú";
            dgvPhieunhap.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvPhieunhap.GridColor = Color.Bisque;
            dgvPhieunhap.BackgroundColor = Color.LightGray;
            dgvPhieunhap.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvPhieunhap.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvPhieunhap.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPhieunhap.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPhieunhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void loadPhieunhap()
        {
            string query = @"select mapn,phieunhap.mahh,phieunhap.mancc,hanghoa.tenhh,nhacungcap.tenncc,ngaynhap,soluong,hanghoa.gia,thanhtien,phieunhap.ghichu from hanghoa,phieunhap,nhacungcap where hanghoa.mahh=phieunhap.mahh and phieunhap.mancc=nhacungcap.mancc";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            dgvPhieunhap.DataSource = datatable;
        }

        private void LoadHanghoa()
        {
            string query = @"SELECT mahh FROM  hanghoa";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMahh.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void LoadNhacungcap()
        {
            string query = @"SELECT MANCC FROM  NHACUNGCAP";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMancc.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void ShowRecord()
        {
            txtMapn.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[0].Value.ToString();
            cbbMahh.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[1].Value.ToString();
            cbbMancc.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[2].Value.ToString();
            txtTenhh.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[3].Value.ToString();
            txtTenncc.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[4].Value.ToString();
            dtpNgaynhap.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[5].Value.ToString();
            txtSoluong.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[6].Value.ToString();
            txtGia.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[7].Value.ToString();
            txtThanhtien.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[8].Value.ToString();
            txtGhichu.Text = dgvPhieunhap.Rows[dgvPhieunhap.CurrentRow.Index].Cells[9].Value.ToString();
        }

        private void dgvPhieunhap_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void cbbMahh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"SELECT tenhh,gia FROM  hanghoa WHERE mahh='" + cbbMahh.Text + "'";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                txtTenhh.Text = Docdulieu[0].ToString();
                txtGia.Text = Docdulieu[1].ToString();
            }
        }

        private void cbbMancc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"SELECT TENNCC FROM  NHACUNGCAP WHERE MANCC='" + cbbMancc.Text + "'";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                txtTenncc.Text = Docdulieu[0].ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMapn.Clear();
            txtTenhh.Clear();
            txtTenncc.Clear();
            dtpNgaynhap.Text ="";
            txtGia.Clear();
            txtThanhtien.Clear();
            txtGhichu.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                float gia = float.Parse(txtGia.Text);
                float tt = float.Parse(txtThanhtien.Text);
                DateTime dt = dtpNgaynhap.Value;
                string query = @"insert into PHIEUNHAP values('" + txtMapn.Text + "','" + cbbMahh.Text + "','" + cbbMancc.Text + "','" + dt.ToString("yyyyMMdd") + "','" + txtSoluong.Text + "','"+ gia+"','" + tt + "',N'" + txtGhichu.Text + "')";
                data.ExecuteNonQuery(query);
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK);
                loadPhieunhap();
            }
            catch
            {
                MessageBox.Show("Lưu không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThanhtien_Click(object sender, EventArgs e)
        {
            int soluong;
            float tt, gia;
            soluong = int.Parse(txtSoluong.Text);
            gia = float.Parse(txtGia.Text);
            tt = gia * soluong;
            txtThanhtien.Text = tt.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    data.ExecuteNonQuery(@"DELETE FROM phieunhap WHERE mapn = '" + txtMapn.Text + "'");
                    MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadPhieunhap();

                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                float gia = float.Parse(txtGia.Text);
                float tt = float.Parse(txtThanhtien.Text);
                DateTime dt = dtpNgaynhap.Value;
                string query = @"update phieunhap set mapn='" + txtMapn.Text + "',mahh='" + cbbMahh.Text + "',mancc='" + cbbMancc.Text + "',ngaynhap='" + dt.ToString("yyyyMMdd") + "',soluong='" + txtSoluong.Text + "',gianhap='" + gia + "',thanhtien='" + tt + "',ghichu=N'" + txtGhichu.Text + "'where mapn='" + txtMapn.Text + "'";
                data.ExecuteNonQuery(query);
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                loadPhieunhap();
            }
            catch
            {
                MessageBox.Show("Sửa thông không tin thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            FrmReportPhieuNhap fr = new FrmReportPhieuNhap();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }
    }
}
