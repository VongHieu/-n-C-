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
    public partial class FrmThongtinkhachhang : Form
    {
        public FrmThongtinkhachhang()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        DataTable datatable = new DataTable();
        private BindingSource bindingsource;
        private void FrmThongtinkhachhang_Load(object sender, EventArgs e)
        {
            loadKhachhang();
            ShowRecord();
            loadMaLKH();
            DataGridView x = dgvKhachhang;
            {
                x.Columns[0].Width = 55;
                x.Columns[1].Width = 70;
                x.Columns[2].Width = 145;
                x.Columns[3].Width = 80;
                x.Columns[4].Width = 45;
                x.Columns[5].Width = 80;
                x.Columns[6].Width = 53;
            }
            dgvKhachhang.Columns[0].HeaderText = "MaKH";
            dgvKhachhang.Columns[1].HeaderText = "MALKH";
            dgvKhachhang.Columns[2].HeaderText = "Họ và tên";
            dgvKhachhang.Columns[3].HeaderText = "Ngày sinh";
            dgvKhachhang.Columns[4].HeaderText = "Phái";
            dgvKhachhang.Columns[5].HeaderText = "Số điện thoại";
            dgvKhachhang.Columns[6].HeaderText = "Điểm tích lũy";
            dgvKhachhang.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvKhachhang.GridColor = Color.Bisque;
            dgvKhachhang.BackgroundColor = Color.LightGray;
            dgvKhachhang.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvKhachhang.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvKhachhang.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvKhachhang.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKhachhang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void loadMaLKH()
        {
            string query = @"select * from loaikhachhang";
            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMalkh.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void loadKhachhang()
        {

            string query = @"SELECT * FROM KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            datatable = new DataTable();
            da.Fill(datatable);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dgvKhachhang.DataSource = bindingsource;
            txtTong.Text = (dgvKhachhang.Rows.Count - 1).ToString();
            txtHienhanh.Text = (dgvKhachhang.CurrentRow.Index + 1).ToString();
            if (dgvKhachhang.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvKhachhang.CurrentRow.Index + 1 == dgvKhachhang.Rows.Count - 1)
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

        private void ShowRecord()
        {

            txtMakh.Text = dgvKhachhang.Rows[dgvKhachhang.CurrentRow.Index].Cells[0].Value.ToString();
            cbbMalkh.Text = dgvKhachhang.Rows[dgvKhachhang.CurrentRow.Index].Cells[1].Value.ToString();
            txthoten.Text = dgvKhachhang.Rows[dgvKhachhang.CurrentRow.Index].Cells[2].Value.ToString();
            txtNgaysinh.Text = dgvKhachhang.Rows[dgvKhachhang.CurrentRow.Index].Cells[3].Value.ToString();
            string gt = dgvKhachhang.Rows[dgvKhachhang.CurrentRow.Index].Cells[4].Value.ToString();
            txtSdt.Text = dgvKhachhang.Rows[dgvKhachhang.CurrentRow.Index].Cells[5].Value.ToString();
            txtDiemtl.Text = dgvKhachhang.Rows[dgvKhachhang.CurrentRow.Index].Cells[6].Value.ToString();
            
            if (gt == "Nam")
                rbtnNam.Checked = true;
            else
                rbtnNu.Checked = true;
            txtHienhanh.Text = (dgvKhachhang.CurrentRow.Index + 1).ToString();
            if (dgvKhachhang.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvKhachhang.CurrentRow.Index + 1 == dgvKhachhang.Rows.Count - 1)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string gt = "";
                int tl;
                tl = int.Parse(txtDiemtl.Text);
                DateTime ngaysinh = Convert.ToDateTime(txtNgaysinh.Text);
                gt += rbtnNam.Checked ? "Nam" : "Nữ";
                data.ExecuteNonQuery(@"INSERT INTO KHACHHANG VALUES
                                        ('" + txtMakh.Text + "','" + cbbMalkh.Text + "',N'"+txthoten.Text+"','"+ngaysinh.ToString("yyyyMMdd")+"',N'" + gt + "','" + txtSdt.Text + "','" + tl + "')");
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                loadKhachhang();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dgvKhachhang_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    data.ExecuteNonQuery(@"DELETE FROM KHACHHANG WHERE MAKH = '" + txtMakh.Text + "'");
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadKhachhang();

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
                string gt;
                if (rbtnNam.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nữ";
                DateTime ngaysinh = Convert.ToDateTime(txtNgaysinh.Text);
                int tl = int.Parse(txtDiemtl.Text);
                data.ExecuteNonQuery(@"UPDATE KHACHHANG SET MAKH='" + txtMakh.Text + "', MALKH='" + cbbMalkh.Text + "',HOTENKH=N'"+txthoten.Text+"',NGAYSINH='" + ngaysinh.ToString("yyyyMMdd") + "',GIOITINH=N'" + gt + "',SODTKH='" + txtSdt.Text + "',DIEMTL='" + tl + "'WHERE MAKH='" + txtMakh.Text + "'");
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                loadKhachhang();

            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnTrolai_Click(object sender, EventArgs e)
        {
            loadKhachhang();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenKH = txtTimkiem.Text;
                string query = @"SELECT * FROM KHACHHANG WHERE HOTENKH LIKE N'%" + tenKH + "%'";
                DataTable DT = data.ExecuteQuery(query);
                dgvKhachhang.DataSource = DT;
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi.", "Thông báo");

            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            dgvKhachhang.ClearSelection();
            int so = dgvKhachhang.Rows.Count - 1;
            dgvKhachhang.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dgvKhachhang.DataSource = bindingsource;
            bindingsource.MoveLast();
            ShowRecord();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dgvKhachhang.CurrentRow.Index;

                if (dgvKhachhang.Rows.Count > IndexNow)
                {
                    dgvKhachhang.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvKhachhang.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }
            ShowRecord();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {

            try
            {
                int IndexNow = dgvKhachhang.CurrentRow.Index;

                if (dgvKhachhang.Rows.Count > IndexNow)
                {
                    dgvKhachhang.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvKhachhang.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }
            ShowRecord();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            dgvKhachhang.ClearSelection();
            dgvKhachhang.Rows[0].Selected = true;
            bindingsource.DataSource = datatable;
            dgvKhachhang.DataSource = bindingsource;
            bindingsource.MoveFirst();

            ShowRecord();
        }

        private void btnLoaikhach_Click(object sender, EventArgs e)
        {
            FrmLoaiKhachHang fr = new FrmLoaiKhachHang();
            fr.ShowDialog();
        }
    }
}
