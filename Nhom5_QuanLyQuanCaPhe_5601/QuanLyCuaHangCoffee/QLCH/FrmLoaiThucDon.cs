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
    public partial class FrmLoaiThucDon : Form
    {
        public FrmLoaiThucDon()
        {
            InitializeComponent();
        }
        kETNOI DATA = new kETNOI();
        private void FrmLoaiThucDon_Load(object sender, EventArgs e)
        {
            LoadLTD();
            DataGridView x = dgvLTD;
            {
                x.Columns[0].Width = 150;
                x.Columns[1].Width = 160;
            }
            dgvLTD.Columns[0].HeaderText = "Mã loại";
            dgvLTD.Columns[1].HeaderText = "Tên loại";
            dgvLTD.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvLTD.GridColor = Color.Bisque;
            dgvLTD.BackgroundColor = Color.LightGray;
            dgvLTD.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvLTD.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvLTD.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLTD.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLTD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadLTD()
        {
            string query = @"select * from loaithucdon";

            SqlDataAdapter da = new SqlDataAdapter(query, DATA.getConnect());
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            dgvLTD.DataSource = datatable;
        }
    }
}
