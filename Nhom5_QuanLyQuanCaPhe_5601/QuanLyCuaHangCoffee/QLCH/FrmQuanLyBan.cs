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
    public partial class FrmQuanLyBan : Form
    {
        public FrmQuanLyBan()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmQuanLyBan_Load(object sender, EventArgs e)
        {
            LoadBan();
            Loadkhuvuc();
            dgvBan.Columns[0].HeaderText = "Mã khu vực";
            dgvBan.Columns[1].HeaderText = "Tên khu vực";
            dgvBan.Columns[2].HeaderText = "Mã bàn";
            dgvBan.Columns[3].HeaderText = "Tên bàn";
            dgvBan.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvBan.GridColor = Color.Bisque;
            dgvBan.BackgroundColor = Color.LightGray;
            dgvBan.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvBan.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvBan.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBan.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadBan()
        {
            string query = @"select ban.makv,khuvuc.tenkv,maban,tenban from ban inner join khuvuc on ban.makv=khuvuc.makv";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            dgvBan.DataSource = datatable;

        }

        private void showrecord()
        {
            
            txtTenkv.Text = dgvBan.Rows[dgvBan.CurrentRow.Index].Cells[1].Value.ToString();
            txtMaban.Text = dgvBan.Rows[dgvBan.CurrentRow.Index].Cells[2].Value.ToString();
            txtTenban.Text = dgvBan.Rows[dgvBan.CurrentRow.Index].Cells[3].Value.ToString();
            cbbMakv.Text = dgvBan.Rows[dgvBan.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"insert into ban values('" + txtMaban.Text + "','" + cbbMakv.Text + "',N'" + txtTenban.Text + "')";
                data.ExecuteNonQuery(query);
                MessageBox.Show("Thêm bàn thành công.", "Thông báo", MessageBoxButtons.OK);
                LoadBan();
            }
            catch
            {
                MessageBox.Show("Thêm không bàn thành công.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"update BAN set MABAN='" + txtMaban.Text + "',MAKV='" + cbbMakv.Text + "',TENBAN=N'" + txtTenban.Text + "'where MABAN='" + txtMaban.Text + "'";

                data.ExecuteNonQuery(query);
                MessageBox.Show("Sửa bàn thành công.", "Thông báo", MessageBoxButtons.OK);
                LoadBan();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string query = @"delete from ban where MABAN='" + txtMaban.Text + "'";
                    data.ExecuteNonQuery(query);
                    MessageBox.Show("Xoá bàn hóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadBan();
                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dgvBan_Click(object sender, EventArgs e)
        {
            showrecord();
        }

        private void Loadkhuvuc()
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
            string query = @"SELECT  TENKV FROM  KHUVUC WHERE MAKV='"+cbbMakv.Text+"'";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                txtTenkv.Text= Docdulieu[0].ToString();
            }
        }
    }
}
