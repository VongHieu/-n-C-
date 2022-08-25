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
    public partial class FrmLoaiKhachHang : Form
    {
        public FrmLoaiKhachHang()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmLoaiKhachHang_Load(object sender, EventArgs e)
        {
            LoadLKH();
            DataGridView x = dgvLKH;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 150;
            }
            dgvLKH.Columns[0].HeaderText = "Mã loại khách hàng";
            dgvLKH.Columns[1].HeaderText = "Tên loại khách hàng";
            dgvLKH.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvLKH.GridColor = Color.Bisque;
            dgvLKH.BackgroundColor = Color.LightGray;
            dgvLKH.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvLKH.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvLKH.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLKH.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadLKH()
        {
            string query = @"select * from loaikhachhang";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            dgvLKH.DataSource = datatable;
        }
    }
}
