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
    public partial class FrmChucVu : Form
    {
        public FrmChucVu()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmChucVu_Load(object sender, EventArgs e)
        {
            loadchucvu();
            DataGridView x = dgvChucvu;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 150;
            }
            dgvChucvu.Columns[0].HeaderText = "Mã chức vụ";
            dgvChucvu.Columns[1].HeaderText = "Tên chức vụ";
            dgvChucvu.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvChucvu.GridColor = Color.Bisque;
            dgvChucvu.BackgroundColor = Color.LightGray;
            dgvChucvu.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvChucvu.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvChucvu.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvChucvu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvChucvu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void loadchucvu()
        {
            string query = @"select * from chucvu";
            SqlDataAdapter da = new SqlDataAdapter(query, data.getConnect());
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            dgvChucvu.DataSource = datatable;

        }
    }
}
