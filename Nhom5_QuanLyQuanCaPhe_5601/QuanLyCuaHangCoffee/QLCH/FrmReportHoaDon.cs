using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace QLCH
{
    public partial class FrmReportHoaDon : Form
    {
        public FrmReportHoaDon()
        {
            InitializeComponent();
        }
        kETNOI data = new kETNOI();

        private void FrmReportHoaDon_Load(object sender, EventArgs e)
        {
            data.getConnect();
            string query = @"SELECT * FROM HOADON";
            DataSet ds = data.loadDataSet(query);
            rpvHoaDon.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //rpvHoaDon.SetDisplayMode(DisplayMode.PrintLayout);
            //rpvHoaDon.ZoomMode = ZoomMode.Percent;
            //rpvHoaDon.ZoomPercent = 100;
            rpvHoaDon.LocalReport.ReportEmbeddedResource = "QLCH.ReportHoadon.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "HOADON";
                rds.Value = ds.Tables[0];
                rpvHoaDon.LocalReport.DataSources.Clear();
                rpvHoaDon.LocalReport.DataSources.Add(rds);
                rpvHoaDon.RefreshReport();
            }
            //this.rpvHoaDon.RefreshReport();
            //this.rpvHoaDon.RefreshReport();
        }
    }
}
