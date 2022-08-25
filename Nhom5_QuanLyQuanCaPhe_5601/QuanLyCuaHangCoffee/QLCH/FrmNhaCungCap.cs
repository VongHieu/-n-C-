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
    public partial class FrmNhaCungCap : Form
    {
        public FrmNhaCungCap()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCC();

            DataGridView x = dgvHanghoa;
            {
                x.Columns[0].Width = 75;
                x.Columns[1].Width = 150;
                x.Columns[2].Width = 345;
                x.Columns[3].Width = 90;
                x.Columns[4].Width = 165;
            }
            dgvHanghoa.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvHanghoa.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvHanghoa.Columns[2].HeaderText = "Địa chỉ";
            dgvHanghoa.Columns[3].HeaderText = "Số điện thoại";
            dgvHanghoa.Columns[4].HeaderText = "Email";
            dgvHanghoa.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvHanghoa.GridColor = Color.Bisque;
            dgvHanghoa.BackgroundColor = Color.LightGray;
            dgvHanghoa.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvHanghoa.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvHanghoa.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvHanghoa.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHanghoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadNhaCC()
        {
            string query = @"SELECT * FROM NHACUNGCAP";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            dgvHanghoa.DataSource = datatable;
        }

        private void ShowRecord()
        {
            txtMancc.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[0].Value.ToString();
            txtTenncc.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[1].Value.ToString();
            txtDiachi.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[2].Value.ToString();
            txtsdt.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[3].Value.ToString();
            txtEmail.Text = dgvHanghoa.Rows[dgvHanghoa.CurrentRow.Index].Cells[4].Value.ToString();
        }

        private void dgvHanghoa_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"insert into NHACUNGCAP values('" + txtMancc.Text + "',N'" + txtTenncc.Text + "',N'" + txtDiachi.Text + "',N'" + txtsdt.Text + "','" + txtEmail.Text + "')";
                data.ExecuteNonQuery(query);
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK);
                LoadNhaCC();
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
                string query = @"update NHACUNGCAP set MANCC='" + txtMancc.Text + "',TENNCC=N'" + txtTenncc.Text + "',DIACHI=N'" + txtDiachi.Text + "',DIENTHOAI='" + txtsdt.Text + "',EMAIL='" + txtEmail.Text + "'WHERE MANCC='" + txtMancc.Text + "'";
                data.ExecuteNonQuery(query);
                MessageBox.Show("Sửa thông tin nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK);
                LoadNhaCC();
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
                    string query = @"delete from NHACUNGCAP where MANCC='" + txtMancc.Text + "'";
                    data.ExecuteNonQuery(query);
                    MessageBox.Show("Xoá thông tin nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadNhaCC();
                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMancc.Clear();
            txtTenncc.Clear();
            txtDiachi.Clear();
            txtsdt.Clear();
            txtEmail.Clear();
            txtMancc.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenncc = txtTimkiem.Text;
                string query = @"select * from nhacungcap where tenncc like N'%" + tenncc + "%'";
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
            LoadNhaCC();
        }
    }
}
