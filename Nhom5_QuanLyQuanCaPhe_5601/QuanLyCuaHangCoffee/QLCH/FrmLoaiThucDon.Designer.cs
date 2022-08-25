namespace QLCH
{
    partial class FrmLoaiThucDon
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
            this.dgvLTD = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLTD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLTD
            // 
            this.dgvLTD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLTD.Location = new System.Drawing.Point(12, 73);
            this.dgvLTD.Name = "dgvLTD";
            this.dgvLTD.RowTemplate.Height = 24;
            this.dgvLTD.Size = new System.Drawing.Size(476, 328);
            this.dgvLTD.TabIndex = 0;
            // 
            // FrmLoaiThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 413);
            this.Controls.Add(this.dgvLTD);
            this.Name = "FrmLoaiThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOẠI THỰC ĐƠN";
            this.Load += new System.EventHandler(this.FrmLoaiThucDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLTD;
    }
}