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
    public partial class FrmQuanlytaikhoan : Form
    {
        public FrmQuanlytaikhoan()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmQuanlytaikhoan_Load(object sender, EventArgs e)
        {
            loadTaikhoan();
            loadcombobox();
            dgvTaikhoan.Columns[0].HeaderText = "STK";
            dgvTaikhoan.Columns[1].HeaderText = "Mã nhân viên";
            dgvTaikhoan.Columns[2].HeaderText = "Tên nhân viên";
            dgvTaikhoan.Columns[3].HeaderText = "Tài khoản";
            dgvTaikhoan.Columns[4].HeaderText = "Mật khẩu";
            dgvTaikhoan.Columns[5].HeaderText = "Chức vụ";
            DataGridView x = dgvTaikhoan;
            {
                x.Columns[0].Width = 50;
                x.Columns[1].Width = 120;
                x.Columns[2].Width = 150;
                x.Columns[3].Width = 110;
                x.Columns[4].Width = 90;
                x.Columns[5].Width = 90;


            }
            
            dgvTaikhoan.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvTaikhoan.GridColor = Color.Bisque;
            dgvTaikhoan.BackgroundColor = Color.LightGray;
            dgvTaikhoan.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvTaikhoan.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvTaikhoan.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTaikhoan.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTaikhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void loadTaikhoan()
        {
            string str = @"SELECT TKND.STK, TKND.MANV, NV.HOTENNV, TKND.TENTK,TKND.MATKHAU, CV.TENCV
                            FROM TAIKHOANDANGNHAP AS TKND, NHANVIEN AS NV, CHUCVU AS CV
                            WHERE TKND.MANV = NV.MANV AND NV.MACV = CV.MACV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTaikhoan.DataSource = dt;
        }
        
        private void loadcombobox()
        {
            string query = @"SELECT TENCV FROM  CHUCVU 
                           WHERE TENCV Like N'%Thu ngân%'or TENCV like N'%Quản lý%'";

            SqlCommand Thuchien = new SqlCommand(query, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();
            
            while(Docdulieu.Read())
            {
                cbbChucvu.Items.Add(Docdulieu[0].ToString());
            }

        }

        private void cbbChucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbManv.Text = "";
            txtTennv.Text = "";
            cbbManv.Items.Clear();
            string sql = @"SELECT  NHANVIEN.MANV FROM  CHUCVU INNER JOIN NHANVIEN ON CHUCVU.MACV=NHANVIEN.MACV 
                           WHERE TENCV like N'%" + cbbChucvu.Text + "%'";

            SqlCommand Thuchien = new SqlCommand(sql, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                cbbManv.Items.Add(Docdulieu[0].ToString());
            }
        }

        private void cbbManv_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtTennv.Clear();
            string sql = @"SELECT HOTENNV FROM NHANVIEN WHERE MANV = '"+cbbManv.Text+"'";
            SqlCommand Thuchien = new SqlCommand(sql, data.getConnect());
            SqlDataReader Docdulieu = Thuchien.ExecuteReader();

            while (Docdulieu.Read())
            {
                txtTennv.Text = Docdulieu[0].ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtSTT.Clear();
            cbbChucvu.Text = "";
            cbbManv.Items.Clear();
            cbbManv.Text = "";
            txtTennv.Clear();
            txtTaikhoan.Clear();
            txtMatkhau.Clear();
            txtSTT.Focus();
            txtTennv.ReadOnly = false;
            cbbChucvu.Enabled = true;
            cbbManv.Enabled = true;
        }

       
        private void dgvTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                txtSTT.Text = dgvTaikhoan.Rows[numrow].Cells[0].Value.ToString();
                cbbChucvu.Text = dgvTaikhoan.Rows[numrow].Cells[5].Value.ToString();
                txtTennv.Text = dgvTaikhoan.Rows[numrow].Cells[2].Value.ToString();
                txtTaikhoan.Text = dgvTaikhoan.Rows[numrow].Cells[3].Value.ToString();
                txtMatkhau.Text = dgvTaikhoan.Rows[numrow].Cells[4].Value.ToString();
                cbbManv.Text = dgvTaikhoan.Rows[numrow].Cells[1].Value.ToString();
                txtTennv.ReadOnly = true;
                cbbChucvu.Enabled = false;
                cbbManv.Enabled = false;
            }

            catch
            {
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Bạn muốn xóa tài khoản?","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
                {
                    data.ExecuteNonQuery(@"DELETE FROM TAIKHOANDANGNHAP WHERE STK='" + txtSTT.Text + "'");
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadTaikhoan();
                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo",MessageBoxButtons.OK);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                data.ExecuteNonQuery(@"INSERT INTO TAIKHOANDANGNHAP VALUES
                ('" + txtSTT.Text + "','" + cbbManv.Text + "','" + txtTaikhoan.Text + "','" + txtMatkhau.Text + "')");
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
                loadTaikhoan();
            }
            catch
            {
                MessageBox.Show("Thêm tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                data.ExecuteNonQuery(@"UPDATE TAIKHOANDANGNHAP SET STK='" + txtSTT.Text + "',TENTK='" + txtTaikhoan.Text + "',MATKHAU='" + txtMatkhau.Text + "'WHERE STK='" + txtSTT.Text + "'");
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                loadTaikhoan();
                
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dgvTaikhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
