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
    public partial class FrmQuanLyHangHoa : Form
    {
        public FrmQuanLyHangHoa()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmQuanLyHangHoa_Load(object sender, EventArgs e)
        {
            LoadHanghoa();
            LoadLoaihanghoa();
            DataGridView x = dgvHanghoa;
            {
                x.Columns[0].Width = 80;
                x.Columns[1].Width = 80;
                x.Columns[2].Width = 140;
                x.Columns[3].Width = 140;
                x.Columns[4].Width = 95;
                x.Columns[5].Width = 90;
                x.Columns[6].Width = 160;
            }
            dgvHanghoa.Columns[0].HeaderText = "Mã hàng hóa";
            dgvHanghoa.Columns[1].HeaderText = "Mã loại hàng hóa";
            dgvHanghoa.Columns[2].HeaderText = "Tên loại hàng hóa";
            dgvHanghoa.Columns[3].HeaderText = "Tên hàng hóa";
            dgvHanghoa.Columns[4].HeaderText = "Đơn vị tính"; 
            dgvHanghoa.Columns[5].HeaderText = "Giá bán (VND)";
            dgvHanghoa.Columns[6].HeaderText = "Ghi chú";
            dgvHanghoa.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvHanghoa.GridColor = Color.Bisque;
            dgvHanghoa.BackgroundColor = Color.LightGray;
            dgvHanghoa.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvHanghoa.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvHanghoa.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvHanghoa.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHanghoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void LoadHanghoa()
        {
            string query = @"select MAHH,LOAIHANGHOA.MALOAIHH,TENLOAIHH,TENHH,DONVITINH,GIA,HANGHOA.GHICHU from HANGHOA INNER JOIN LOAIHANGHOA ON HANGHOA.MALOAIHH=LOAIHANGHOA.MALOAIHH";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            dgvHanghoa.DataSource = datatable;

        }
        private void LoadLoaihanghoa()
        {
            string query = @"SELECT MALOAIHH FROM  LOAIHANGHOA";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMalhh.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void cbbMalhh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"SELECT TENLOAIHH FROM  LOAIHANGHOA WHERE MALOAIHH='"+cbbMalhh.Text+"'";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
               txtTenlhh.Text = Docdulieu[0].ToString();
            }
        }

        private void ShowRecord()
        {
            txtMahh.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[0].Value.ToString();
            cbbMalhh.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[1].Value.ToString();
            txtTenlhh.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[2].Value.ToString();
            txtTenhh.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[3].Value.ToString();
            txtdvt.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[4].Value.ToString();
            txtGia.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[5].Value.ToString();
            txtGhichu.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[6].Value.ToString();
        }

        private void dgvHanghoa_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"insert into HANGHOA values('" + txtMahh.Text + "','" + cbbMalhh.Text + "',N'" + txtTenhh.Text + "',N'" + txtdvt.Text + "','" + txtGia.Text + "',N'" + txtGhichu.Text + "')";
                data.ExecuteNonQuery(query);
                MessageBox.Show("Thêm hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
                LoadHanghoa();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"update hanghoa set MAHH='" + txtMahh.Text + "',MALOAIHH='" + cbbMalhh.Text + "',TENHH=N'" + txtTenhh.Text + "',DONVITINH=N'" + txtdvt.Text + "',GIA='" + txtGia.Text + "',GHICHU=N'" + txtGhichu.Text + "'WHERE MAHH='"+txtMahh.Text+"'";
                data.ExecuteNonQuery(query);
                MessageBox.Show("Sửa thông tin hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
                LoadHanghoa();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string query = @"delete from hanghoa where MAHH='" + txtMahh.Text + "'";
                    data.ExecuteNonQuery(query);
                    MessageBox.Show("Xoá thông tin hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadHanghoa();
                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMahh.Clear();
            txtTenhh.Clear();
            cbbMalhh.Text = "";
            txtTenlhh.Clear();
            txtdvt.Clear();
            txtGia.Clear();
            txtGhichu.Clear();
            txtMahh.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenhh = txtTimkiem.Text;
                string query = @"select MAHH,LOAIHANGHOA.MALOAIHH,TENLOAIHH,TENHH,DONVITINH,GIA,HANGHOA.GHICHU from HANGHOA INNER JOIN LOAIHANGHOA ON HANGHOA.MALOAIHH=LOAIHANGHOA.MALOAIHH where tenhh like N'%"+tenhh+"%'";
                DataTable DT = data.ExecuteQuery(query);
                dgvHanghoa.DataSource = DT;
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi.", "Thông báo");

            }
        }

        private void btnTrolai_Click(object sender, EventArgs e)
        {
            LoadHanghoa();
        }
    }
}
