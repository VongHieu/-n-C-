namespace QLCH
{
    partial class FrmReportPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportPhieuNhap));
            this.rpvPhieunhap = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QUANLYBANHANGCOFFEEDataSet1 = new QLCH.QUANLYBANHANGCOFFEEDataSet1();
            this.PHIEUNHAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PHIEUNHAPTableAdapter = new QLCH.QUANLYBANHANGCOFFEEDataSet1TableAdapters.PHIEUNHAPTableAdapter();
            this.NHACUNGCAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NHACUNGCAPTableAdapter = new QLCH.QUANLYBANHANGCOFFEEDataSet1TableAdapters.NHACUNGCAPTableAdapter();
            this.HANGHOABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HANGHOATableAdapter = new QLCH.QUANLYBANHANGCOFFEEDataSet1TableAdapters.HANGHOATableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYBANHANGCOFFEEDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHIEUNHAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHACUNGCAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HANGHOABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvPhieunhap
            // 
            reportDataSource1.Name = "PHIEUNHAP";
            reportDataSource1.Value = this.PHIEUNHAPBindingSource;
            reportDataSource2.Name = "NHACUNGCAP";
            reportDataSource2.Value = this.NHACUNGCAPBindingSource;
            reportDataSource3.Name = "HANGHOA";
            reportDataSource3.Value = this.HANGHOABindingSource;
            this.rpvPhieunhap.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPhieunhap.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvPhieunhap.LocalReport.DataSources.Add(reportDataSource3);
            this.rpvPhieunhap.LocalReport.ReportEmbeddedResource = "QLCH.ReportPhieuNhap.rdlc";
            this.rpvPhieunhap.Location = new System.Drawing.Point(12, 55);
            this.rpvPhieunhap.Name = "rpvPhieunhap";
            this.rpvPhieunhap.ServerReport.BearerToken = null;
            this.rpvPhieunhap.Size = new System.Drawing.Size(1466, 832);
            this.rpvPhieunhap.TabIndex = 0;
            // 
            // QUANLYBANHANGCOFFEEDataSet1
            // 
            this.QUANLYBANHANGCOFFEEDataSet1.DataSetName = "QUANLYBANHANGCOFFEEDataSet1";
            this.QUANLYBANHANGCOFFEEDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PHIEUNHAPBindingSource
            // 
            this.PHIEUNHAPBindingSource.DataMember = "PHIEUNHAP";
            this.PHIEUNHAPBindingSource.DataSource = this.QUANLYBANHANGCOFFEEDataSet1;
            // 
            // PHIEUNHAPTableAdapter
            // 
            this.PHIEUNHAPTableAdapter.ClearBeforeFill = true;
            // 
            // NHACUNGCAPBindingSource
            // 
            this.NHACUNGCAPBindingSource.DataMember = "NHACUNGCAP";
            this.NHACUNGCAPBindingSource.DataSource = this.QUANLYBANHANGCOFFEEDataSet1;
            // 
            // NHACUNGCAPTableAdapter
            // 
            this.NHACUNGCAPTableAdapter.ClearBeforeFill = true;
            // 
            // HANGHOABindingSource
            // 
            this.HANGHOABindingSource.DataMember = "HANGHOA";
            this.HANGHOABindingSource.DataSource = this.QUANLYBANHANGCOFFEEDataSet1;
            // 
            // HANGHOATableAdapter
            // 
            this.HANGHOATableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(600, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "IN PHIẾU NHẬP HÀNG";
            // 
            // FrmReportPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 899);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rpvPhieunhap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo nhập hàng";
            this.Load += new System.EventHandler(this.FrmReportPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYBANHANGCOFFEEDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHIEUNHAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHACUNGCAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HANGHOABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPhieunhap;
        private System.Windows.Forms.BindingSource PHIEUNHAPBindingSource;
        private QUANLYBANHANGCOFFEEDataSet1 QUANLYBANHANGCOFFEEDataSet1;
        private System.Windows.Forms.BindingSource NHACUNGCAPBindingSource;
        private System.Windows.Forms.BindingSource HANGHOABindingSource;
        private QUANLYBANHANGCOFFEEDataSet1TableAdapters.PHIEUNHAPTableAdapter PHIEUNHAPTableAdapter;
        private QUANLYBANHANGCOFFEEDataSet1TableAdapters.NHACUNGCAPTableAdapter NHACUNGCAPTableAdapter;
        private QUANLYBANHANGCOFFEEDataSet1TableAdapters.HANGHOATableAdapter HANGHOATableAdapter;
        private System.Windows.Forms.Label label1;
    }
}