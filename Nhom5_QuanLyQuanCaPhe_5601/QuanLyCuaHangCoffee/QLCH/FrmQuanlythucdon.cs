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
    public partial class FrmQuanlythucdon : Form
    {
        public FrmQuanlythucdon()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        DataTable datatable = new DataTable();
        private BindingSource bindingsource;
        private void FrmQuanlythucdon_Load(object sender, EventArgs e)
        {
            loadThucdon();
            ShowRecord();
            loadLoaiThucdon();
            DataGridView x = dgvThucdon;
            {
                x.Columns[0].Width = 70;
                x.Columns[1].Width = 70;
                x.Columns[2].Width = 180;
                x.Columns[3].Width = 80;
                x.Columns[4].Width = 50;
            }
            dgvThucdon.Columns[0].HeaderText = "Mã món";
            dgvThucdon.Columns[1].HeaderText = "Mã loại";
            dgvThucdon.Columns[2].HeaderText = "Tên món";
            dgvThucdon.Columns[3].HeaderText = "Giá bán";
            dgvThucdon.Columns[4].HeaderText = "Đơn vị";
            dgvThucdon.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvThucdon.GridColor = Color.Bisque;
            dgvThucdon.BackgroundColor = Color.LightGray;
            dgvThucdon.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvThucdon.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvThucdon.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvThucdon.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvThucdon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void loadLoaiThucdon()
        {
            string query = @"select maloai from loaithucdon";
            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMaloai.Items.Add(Docdulieu[0].ToString());
            }
        }


        private void loadThucdon()
        {

            string query = @"SELECT * FROM THUCDON";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            datatable = new DataTable();
            da.Fill(datatable);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dgvThucdon.DataSource = bindingsource;
            txtTong.Text = (dgvThucdon.Rows.Count - 1).ToString();
            txtHienhanh.Text = (dgvThucdon.CurrentRow.Index + 1).ToString();
            if (dgvThucdon.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvThucdon.CurrentRow.Index + 1 == dgvThucdon.Rows.Count - 1)
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
            txtMamon.Text = dgvThucdon.Rows[dgvThucdon.CurrentRow.Index].Cells[0].Value.ToString();
            txttenmon.Text = dgvThucdon.Rows[dgvThucdon.CurrentRow.Index].Cells[2].Value.ToString();
            txtGia.Text = dgvThucdon.Rows[dgvThucdon.CurrentRow.Index].Cells[3].Value.ToString();
            txtdvt.Text = dgvThucdon.Rows[dgvThucdon.CurrentRow.Index].Cells[4].Value.ToString();
            cbbMaloai.Text = dgvThucdon.Rows[dgvThucdon.CurrentRow.Index].Cells[1].Value.ToString();
            txtHienhanh.Text = (dgvThucdon.CurrentRow.Index + 1).ToString();
            if (dgvThucdon.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvThucdon.CurrentRow.Index + 1 == dgvThucdon.Rows.Count - 1)
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

        private void dgvThucdon_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                
                float gia;
                gia = float.Parse(txtGia.Text);
                data.ExecuteNonQuery(@"INSERT INTO THUCDON VALUES
                                        ('" + txtMamon.Text + "','" + cbbMaloai.Text + "',N'" + txttenmon.Text + "','" + gia + "','" + txtdvt.Text + "')");
                MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK);
                loadThucdon();
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
                float gia = float.Parse(txtGia.Text);
                data.ExecuteNonQuery(@"UPDATE THUCDON SET MAMON='" + txtMamon.Text + "',MALOAI='" + cbbMaloai.Text + "',TENMON=N'" + txttenmon.Text + "',DONGIA='" + gia + "',DVT='" + txtdvt.Text + "'WHERE MAMON='" + txtMamon.Text + "'");
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK);
                loadThucdon();
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    data.ExecuteNonQuery(@"DELETE FROM THUCDON WHERE MAMON = '" + txtMamon.Text + "'");
                    MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadThucdon();

                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK);

            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenMON = txtTimkiem.Text;
                string query = @"SELECT * FROM THUCDON WHERE TENMON LIKE N'%" + tenMON + "%'";
                DataTable DT = data.ExecuteQuery(query);
                dgvThucdon.DataSource = DT;
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi.", "Thông báo");

            }
        }

        private void btnTrolai_Click(object sender, EventArgs e)
        {
            loadThucdon();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            dgvThucdon.ClearSelection();
            dgvThucdon.Rows[0].Selected = true;
            bindingsource.DataSource = datatable;
            dgvThucdon.DataSource = bindingsource;
            bindingsource.MoveFirst();

            ShowRecord();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dgvThucdon.CurrentRow.Index;

                if (dgvThucdon.Rows.Count > IndexNow)
                {
                    dgvThucdon.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvThucdon.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }
            ShowRecord();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dgvThucdon.CurrentRow.Index;

                if (dgvThucdon.Rows.Count > IndexNow)
                {
                    dgvThucdon.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvThucdon.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }
            ShowRecord();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            dgvThucdon.ClearSelection();
            int so = dgvThucdon.Rows.Count - 1;
            dgvThucdon.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dgvThucdon.DataSource = bindingsource;
            bindingsource.MoveLast();
            ShowRecord();
        }

        private void btnLoaiThucdon_Click(object sender, EventArgs e)
        {
            FrmLoaiThucDon fr = new FrmLoaiThucDon();
            fr.ShowDialog();
        }
    }
}
