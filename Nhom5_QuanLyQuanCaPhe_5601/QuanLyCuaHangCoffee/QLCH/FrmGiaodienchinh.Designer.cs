namespace QLCH
{
    partial class FrmGiaodienchinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiaodienchinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.HethongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaikhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mntDoimatkhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mntDangxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HethongToolStripMenuItem,
            this.TaikhoanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1375, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HethongToolStripMenuItem
            // 
            this.HethongToolStripMenuItem.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HethongToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.HethongToolStripMenuItem.Name = "HethongToolStripMenuItem";
            this.HethongToolStripMenuItem.Size = new System.Drawing.Size(113, 28);
            this.HethongToolStripMenuItem.Text = "HỆ THỐNG";
            this.HethongToolStripMenuItem.Click += new System.EventHandler(this.HethongToolStripMenuItem_Click);
            // 
            // TaikhoanToolStripMenuItem
            // 
            this.TaikhoanToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.TaikhoanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntDoimatkhau,
            this.mntDangxuat});
            this.TaikhoanToolStripMenuItem.Font = new System.Drawing.Font("Candara", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaikhoanToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.TaikhoanToolStripMenuItem.Name = "TaikhoanToolStripMenuItem";
            this.TaikhoanToolStripMenuItem.Size = new System.Drawing.Size(114, 28);
            this.TaikhoanToolStripMenuItem.Text = "TÀI KHOẢN";
            // 
            // mntDoimatkhau
            // 
            this.mntDoimatkhau.BackColor = System.Drawing.Color.Transparent;
            this.mntDoimatkhau.ForeColor = System.Drawing.Color.Black;
            this.mntDoimatkhau.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mntDoimatkhau.Name = "mntDoimatkhau";
            this.mntDoimatkhau.Size = new System.Drawing.Size(234, 28);
            this.mntDoimatkhau.Text = "Thay đổi mật khẩu";
            this.mntDoimatkhau.Click += new System.EventHandler(this.mntDoimatkhau_Click);
            // 
            // mntDangxuat
            // 
            this.mntDangxuat.BackColor = System.Drawing.Color.Transparent;
            this.mntDangxuat.ForeColor = System.Drawing.Color.Black;
            this.mntDangxuat.Name = "mntDangxuat";
            this.mntDangxuat.Size = new System.Drawing.Size(234, 28);
            this.mntDangxuat.Text = "Đăng xuất";
            this.mntDangxuat.Click += new System.EventHandler(this.mntDangxuat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmGiaodienchinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1375, 742);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmGiaodienchinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIAO DIỆN CHÍNH";
            this.Load += new System.EventHandler(this.GiaoDienChinh_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HethongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaikhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntDoimatkhau;
        private System.Windows.Forms.ToolStripMenuItem mntDangxuat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}