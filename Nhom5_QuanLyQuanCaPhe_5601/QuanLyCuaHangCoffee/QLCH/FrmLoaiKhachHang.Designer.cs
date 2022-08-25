namespace QLCH
{
    partial class FrmLoaiKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoaiKhachHang));
            this.dgvLKH = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLKH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLKH
            // 
            this.dgvLKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLKH.Location = new System.Drawing.Point(12, 99);
            this.dgvLKH.Name = "dgvLKH";
            this.dgvLKH.RowTemplate.Height = 24;
            this.dgvLKH.Size = new System.Drawing.Size(460, 300);
            this.dgvLKH.TabIndex = 0;
            // 
            // FrmLoaiKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 413);
            this.Controls.Add(this.dgvLKH);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLoaiKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOẠI KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.FrmLoaiKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLKH;
    }
}