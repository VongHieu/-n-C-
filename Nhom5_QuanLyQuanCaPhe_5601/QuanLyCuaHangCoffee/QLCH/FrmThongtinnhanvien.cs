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
    public partial class FrmThongtinnhanvien : Form
    {
        public FrmThongtinnhanvien()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        DataTable datatable = new DataTable();
        private BindingSource bindingsource;
        private void FrmThongtinnhanvien_Load(object sender, EventArgs e)
        {
            loadNhanvien();
            ShowRecord();
            loadMaChucvu();
            dgvNhanvien.Columns[0].HeaderText = "MaNV";
            dgvNhanvien.Columns[1].HeaderText = "Họ và tên";
            dgvNhanvien.Columns[2].HeaderText = "Phái";
            dgvNhanvien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanvien.Columns[4].HeaderText = "Địa chỉ";
            dgvNhanvien.Columns[5].HeaderText = "Ngày vào làm";
            dgvNhanvien.Columns[6].HeaderText = "Số điện thoại";
            dgvNhanvien.Columns[7].HeaderText = "Email";
            dgvNhanvien.Columns[8].HeaderText = "Mã chức vụ";
            DataGridView x = dgvNhanvien;
            {
                x.Columns[0].Width = 65;
                x.Columns[1].Width = 150;
                x.Columns[2].Width = 50;
                x.Columns[3].Width = 70;
                x.Columns[4].Width = 110;
                x.Columns[5].Width = 70;
                x.Columns[6].Width = 90;
                x.Columns[7].Width = 110;
                x.Columns[8].Width = 60;
            }
            dgvNhanvien.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvNhanvien.GridColor = Color.Bisque;
            dgvNhanvien.BackgroundColor = Color.LightGray;
            dgvNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvNhanvien.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvNhanvien.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvNhanvien.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvNhanvien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        
        private void loadMaChucvu()
        {
            string query = @"select macv from chucvu";
            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbMacv.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void loadNhanvien()
        {
            
            string query = @"SELECT * FROM NHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            datatable = new DataTable();
            da.Fill(datatable);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dgvNhanvien.DataSource = bindingsource;
            txtTong.Text = (dgvNhanvien.Rows.Count - 1).ToString();
            txtHienhanh.Text = (dgvNhanvien.CurrentRow.Index + 1).ToString();
            if (dgvNhanvien.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvNhanvien.CurrentRow.Index + 1 == dgvNhanvien.Rows.Count - 1)
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
            
            txtManv.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[0].Value.ToString();
            txtTennv.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[1].Value.ToString();
            string gt = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[2].Value.ToString();
            txtNgaysinh.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[3].Value.ToString();
            txtDiachi.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[4].Value.ToString();
            txtNgayvaolam.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[5].Value.ToString();
            txtSdt.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[6].Value.ToString();
            txtEmail.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[7].Value.ToString();
            cbbMacv.Text = dgvNhanvien.Rows[dgvNhanvien.CurrentRow.Index].Cells[8].Value.ToString();
            if (gt == "Nam")
                rbtnNam.Checked = true;
            else
                rbtnNu.Checked = true;
            txtHienhanh.Text = (dgvNhanvien.CurrentRow.Index + 1).ToString();
            if (dgvNhanvien.CurrentRow.Index == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            else
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }

            if (dgvNhanvien.CurrentRow.Index + 1 == dgvNhanvien.Rows.Count - 1)
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
                DateTime ngaysinh = Convert.ToDateTime(txtNgaysinh.Text);
                DateTime ngayvaolam = Convert.ToDateTime(txtNgayvaolam.Text);
                gt +=rbtnNam.Checked ? "Nam" :"Nữ";
                data.ExecuteNonQuery(@"INSERT INTO NHANVIEN VALUES
                                        ('" + txtManv.Text + "',N'" + txtTennv.Text + "',N'" + gt + "','"+ngaysinh.ToString("yyyyMMdd")+"',N'" + txtDiachi.Text
                                        + "','" + ngayvaolam.ToString("yyyyMMdd") + "','" + txtSdt.Text + "','" + txtEmail.Text + "','" + cbbMacv.Text + "')");
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                loadNhanvien();
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
                string manv,tennv,gt,dc,sdt,email,macv;
                if (rbtnNam.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nữ";
                manv = txtManv.Text;
                tennv = txtTennv.Text;
                DateTime ngaysinh = Convert.ToDateTime(txtNgaysinh.Text);
                dc = txtDiachi.Text;
                DateTime ngayvaolam = Convert.ToDateTime(txtNgayvaolam.Text);
                sdt = txtSdt.Text;
                email = txtEmail.Text;
                macv = cbbMacv.Text;
                data.ExecuteNonQuery(@"UPDATE NHANVIEN SET MANV='"+manv+"', HOTENNV=N'" +tennv+ "',GIOITINH=N'" +gt+ "',NGAYSINH='"+ngaysinh.ToString("yyyyMMdd")+"',DIACHI=N'"+dc+"',NGAYVAOLAM='"+ ngayvaolam.ToString("yyyyMMdd") + "',SDT='"+sdt+"',EMAIL='"+email+"',MACV='"+macv+"'WHERE MANV='" + manv + "'");
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                loadNhanvien();

            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Bạn chắc chắn muốn xóa?","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
                {
                    data.ExecuteNonQuery(@"DELETE FROM NHANVIEN WHERE MANV = '" + txtManv.Text + "'");
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadNhanvien();

                }
            }
            catch
            {
                MessageBox.Show("Xóa nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK);

            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tennv = txtTimkiem.Text;
                string query = @"SELECT * FROM NHANVIEN WHERE HOTENNV LIKE N'%" + tennv + "%'";
                DataTable DT = data.ExecuteQuery(query);
                dgvNhanvien.DataSource = DT;
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi.", "Thông báo");

            }
        }

        private void btnTrolai_Click(object sender, EventArgs e)
        {
            loadNhanvien();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            dgvNhanvien.ClearSelection();
            int so = dgvNhanvien.Rows.Count - 1;
            dgvNhanvien.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dgvNhanvien.DataSource = bindingsource;
            bindingsource.MoveLast();
            ShowRecord();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dgvNhanvien.CurrentRow.Index;

                if (dgvNhanvien.Rows.Count > IndexNow)
                {
                    dgvNhanvien.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvNhanvien.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }
            ShowRecord();
        }

        private void dgvNhanvien_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            dgvNhanvien.ClearSelection();
            dgvNhanvien.Rows[0].Selected = true;
            bindingsource.DataSource = datatable;
            dgvNhanvien.DataSource = bindingsource;
            bindingsource.MoveFirst();
            
            ShowRecord();

        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dgvNhanvien.CurrentRow.Index;

                if (dgvNhanvien.Rows.Count > IndexNow)
                {
                    dgvNhanvien.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dgvNhanvien.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }
            ShowRecord();
        }

        private void btnChucvu_Click(object sender, EventArgs e)
        {
            FrmChucVu fr = new FrmChucVu();
            fr.ShowDialog();
        }
    }
}
