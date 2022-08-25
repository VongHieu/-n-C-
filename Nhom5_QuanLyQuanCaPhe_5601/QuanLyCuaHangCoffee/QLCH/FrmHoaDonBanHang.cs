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
    public partial class FrmHoaDonBanHang : Form
    {
        public FrmHoaDonBanHang()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        DataTable datatable = new DataTable();
        private BindingSource bindingsource;
        private void FrmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            LoadThucdon();
            LoadHoadon();
            LoadBan();
            DataGridView x = dgvHoadon;
            {
                x.Columns[0].Width = 80;
                x.Columns[1].Width = 70;
                x.Columns[2].Width = 150;
                x.Columns[3].Width = 90;
                x.Columns[4].Width = 150;
                x.Columns[5].Width = 70;
                x.Columns[6].Width = 90;
                x.Columns[7].Width = 70;
                x.Columns[8].Width = 65;
                x.Columns[9].Width = 75;
                x.Columns[10].Width = 75;
                x.Columns[11].Width = 75;
            }
            dgvHoadon.Columns[0].HeaderText = "MaHD";
            dgvHoadon.Columns[1].HeaderText = "MAKH";
            dgvHoadon.Columns[2].HeaderText = "Tên khách hàng";
            dgvHoadon.Columns[3].HeaderText = "Số DT";
            dgvHoadon.Columns[4].HeaderText = "Tên món";
            dgvHoadon.Columns[5].HeaderText = "Số bàn";
            dgvHoadon.Columns[6].HeaderText = "Ngày tạo";
            dgvHoadon.Columns[7].HeaderText = "Giá bán (vnd)";
            dgvHoadon.Columns[8].HeaderText = "Số lượng";
            dgvHoadon.Columns[9].HeaderText = "Điểm TL";
            dgvHoadon.Columns[10].HeaderText = "Giảm giá (vnd)";
            dgvHoadon.Columns[11].HeaderText = "Thành tiền (vnd)";
            dgvHoadon.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvHoadon.GridColor = Color.Bisque;
            dgvHoadon.BackgroundColor = Color.LightGray;
            dgvHoadon.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvHoadon.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvHoadon.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvHoadon.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHoadon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadThucdon()
        {
            string query = @"SELECT TENLOAI FROM  LOAITHUCDON";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbLoaimon.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void LoadBan()
        {
            string query = @"SELECT MAKV FROM  KHUVUC";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMakv.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void cbbMakv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbMaban.Text = "";
            txtTenban.Text = "";
            cbbMaban.Items.Clear();
            string query = @"SELECT MABAN FROM  BAN INNER JOIN KHUVUC ON BAN.MAKV=KHUVUC.MAKV WHERE KHUVUC.MAKV='"+cbbMakv.Text+"'";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMaban.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void cbbMaban_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"SELECT TENBAN FROM  BAN WHERE MABAN='"+cbbMaban.Text+"'";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                txtTenban.Text = Docdulieu[0].ToString();
            }
        }

        

        private void cbbLoaimon_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtGia.Text = "";
            cbbTenmon.Items.Clear();
            string sql = @"select TENMON from LOAITHUCDON inner join THUCDON on LOAITHUCDON.MALOAI=THUCDON.MALOAI
	                        where LOAITHUCDON.TENLOAI like N'%" + cbbLoaimon.Text + "%'";
            SqlCommand Thuchien = new SqlCommand(sql, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbTenmon.Items.Add(Docdulieu[0].ToString());
            }

        }

        private void cbbTenmon_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGia.Clear();
            string sql = @"select DONGIA from  THUCDON 
	                        where TENMON like N'%" + cbbTenmon.Text + "%'";

            SqlCommand Thuchien = new SqlCommand(sql, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                txtGia.Text = Docdulieu[0].ToString();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql = @"select DIEMTL,MAKH from  KHACHHANG 
	                        where HOTENKH like N'%" + txtTenkh.Text + "%'AND SODTKH='" + txtsdt.Text + "'";
            SqlCommand Thuchien = new SqlCommand(sql, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                txtDtl.Text = Docdulieu[0].ToString();
                txtMakh.Text = Docdulieu[1].ToString();

            }
            if (txtDtl.Text == "")
            {
                MessageBox.Show("Không có trong danh sách khách hàng.", "Thông báo");
            }
            else
            {
                loadGiamgia();
            }
        }
        private void loadGiamgia()
        {
            int dtl = int.Parse(txtDtl.Text);
            if (dtl <= 15)
            {
                txtGiamgiaphantram.Text = 0.ToString();
            }
            if (dtl > 15 & dtl <= 30)
            {
                txtGiamgiaphantram.Text = 10.ToString();
            }
            else if (dtl > 30 & dtl <= 50)
            {
                txtGiamgiaphantram.Text = 20.ToString();
            }
            else if (dtl > 50 & dtl <= 100)
            {
                txtGiamgiaphantram.Text = 30.ToString();
            }
            else if (dtl > 100)
            {
                txtGiamgiaphantram.Text = 50.ToString();
            }
        }
        private void txtTenkh_TextChanged(object sender, EventArgs e)
        {
            txtsdt.Clear();
            txtDtl.Clear();
            txtMakh.Clear();
        }
        
        private void LoadHoadon()
        {
            string query = @"SELECT * FROM HOADON";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            datatable = new DataTable();
            da.Fill(datatable);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dgvHoadon.DataSource = bindingsource;
            txtTong.Text = (dgvHoadon.Rows.Count - 1).ToString();
            txtHienhanh.Text = (dgvHoadon.CurrentRow.Index + 1).ToString();
            if (dgvHoadon.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvHoadon.CurrentRow.Index + 1 == dgvHoadon.Rows.Count - 1)
            {
                btnCuoi.Enabled = false;
                btnSau.Enabled = false;
            }
            else
            {
                btnCuoi.Enabled = true;
                btnSau.Enabled = true;
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            float gia = float.Parse(txtGia.Text);
            int soluong = int.Parse(numericSoluong.Text);
            float giamgia = float.Parse(txtGiamgiaphantram.Text);
            float thanhtien;
            thanhtien = (gia - (giamgia/100f)*gia) * soluong;
            txtThanhtien.Text = thanhtien.ToString();
            txtGiamgiatien.Text = ((float)((giamgia / 100) * gia * soluong)).ToString();
        }

        private void showrecord()
        {
                txtMahoadon.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[0].Value.ToString();
                txtTenkh.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[2].Value.ToString();
                txtsdt.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[3].Value.ToString();
                txtMakh.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[1].Value.ToString();
                txtTenban.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[5].Value.ToString();
                dtpNgaytao.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[6].Value.ToString();
                txtGia.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[7].Value.ToString();
                numericSoluong.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[8].Value.ToString();
                txtDtl.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[9].Value.ToString();
                txtGiamgiatien.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[10].Value.ToString();
                txtThanhtien.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[11].Value.ToString();
                cbbTenmon.Text = dgvHoadon.Rows[dgvHoadon.CurrentRow.Index].Cells[4].Value.ToString();

            txtHienhanh.Text = (dgvHoadon.CurrentRow.Index + 1).ToString();
            if (dgvHoadon.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvHoadon.CurrentRow.Index + 1 == dgvHoadon.Rows.Count - 1)
            {
                btnCuoi.Enabled = false;
                btnSau.Enabled = false;
            }
            else
            {
                btnCuoi.Enabled = true;
                btnSau.Enabled = true;
            }
            loadGiamgia();
        }

        private void btnLuuHoadon_Click(object sender, EventArgs e)
        {
            try
            {

                 DateTime dt = dtpNgaytao.Value;

                data.ExecuteNonQuery(@"INSERT INTO HOADON VALUES
                                        ('" + txtMahoadon.Text + "','" + txtMakh.Text + "',N'" + txtTenkh.Text + "','" + txtsdt.Text + "',N'" + cbbTenmon.Text + "',N'" + txtTenban.Text + "','" + dt.ToString("yyyyMMdd") + "','"+txtGia.Text+"','"+numericSoluong.Text+"','"+txtDtl.Text+"','"+ txtGiamgiatien.Text+"','"+txtThanhtien.Text+"')");
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);
                LoadHoadon();
            }
            catch
            {
                MessageBox.Show("Lưu không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbbLoaimon.Text = "";
            cbbTenmon.Items.Clear();
            cbbTenmon.Text = "";
            txtTenkh.Clear();
            txtsdt.Clear();
            txtGiamgiatien.Clear();
            txtMakh.Clear();
            txtDtl.Clear();
            numericSoluong.Value = 1;
            txtGiamgiaphantram.Clear();
            txtGia.Clear();
            txtThanhtien.Clear();
            txtTenban.Clear();
            txtMahoadon.Clear();
            txtTenkh.Focus();
            cbbLoaimon.Enabled = true;
            cbbTenmon.Enabled = true;
            cbbMakv.Enabled = true;
            cbbMaban.Enabled = true;

        }

        private void dgvHoadon_Click(object sender, EventArgs e)
        {
            showrecord();
            cbbLoaimon.Enabled = false;
            cbbTenmon.Enabled = false;
            cbbMakv.Enabled = false;
            cbbMaban.Enabled = false;
        }

        private void btnXoahoadon_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    data.ExecuteNonQuery(@"DELETE FROM HOADON WHERE MAHD = '" + txtMahoadon.Text + "'");
                    MessageBox.Show("Xóa thông tin hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadHoadon();

                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK);

            }
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            dgvHoadon.ClearSelection();
            dgvHoadon.Rows[0].Selected = true;
            bindingsource.DataSource = datatable;
            dgvHoadon.DataSource = bindingsource;
            bindingsource.MoveFirst();

            showrecord();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dgvHoadon.CurrentRow.Index;

                if (dgvHoadon.Rows.Count > IndexNow)
                {
                    dgvHoadon.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvHoadon.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }
            showrecord();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dgvHoadon.CurrentRow.Index;

                if (dgvHoadon.Rows.Count > IndexNow)
                {
                    dgvHoadon.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvHoadon.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }
            showrecord();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            dgvHoadon.ClearSelection();
            int so = dgvHoadon.Rows.Count - 1;
            dgvHoadon.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dgvHoadon.DataSource = bindingsource;
            bindingsource.MoveLast();
            showrecord();
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            FrmReportHoaDon fr = new FrmReportHoaDon();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }
    }
}
