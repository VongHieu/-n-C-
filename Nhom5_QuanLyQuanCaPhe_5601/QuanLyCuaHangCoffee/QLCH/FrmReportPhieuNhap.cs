using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH
{
    public partial class FrmReportPhieuNhap : Form
    {
        public FrmReportPhieuNhap()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();
        private void FrmReportPhieuNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QUANLYBANHANGCOFFEEDataSet1.PHIEUNHAP' table. You can move, or remove it, as needed.
            
            this.PHIEUNHAPTableAdapter.Fill(this.QUANLYBANHANGCOFFEEDataSet1.PHIEUNHAP);
            // TODO: This line of code loads data into the 'QUANLYBANHANGCOFFEEDataSet1.NHACUNGCAP' table. You can move, or remove it, as needed.
            this.NHACUNGCAPTableAdapter.Fill(this.QUANLYBANHANGCOFFEEDataSet1.NHACUNGCAP);
            // TODO: This line of code loads data into the 'QUANLYBANHANGCOFFEEDataSet1.HANGHOA' table. You can move, or remove it, as needed.
            this.HANGHOATableAdapter.Fill(this.QUANLYBANHANGCOFFEEDataSet1.HANGHOA);

            this.rpvPhieunhap.RefreshReport();
        }
    }
}
