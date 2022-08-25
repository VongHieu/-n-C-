namespace QLCH
{
    partial class FrmHethong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHethong));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DanhmucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlNhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlKhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlThucdon = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlHoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlHoadonnhap = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlNhacungcap = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlThongtinhang = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mntqlThongtinban = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mntQltaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DanhmucToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem1,
            this.tàiKhoảnToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DanhmucToolStripMenuItem
            // 
            this.DanhmucToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntqlNhanvien,
            this.mntqlKhachhang,
            this.mntqlThucdon});
            this.DanhmucToolStripMenuItem.Font = new System.Drawing.Font("Candara", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DanhmucToolStripMenuItem.Name = "DanhmucToolStripMenuItem";
            this.DanhmucToolStripMenuItem.Size = new System.Drawing.Size(115, 27);
            this.DanhmucToolStripMenuItem.Text = "DANH MỤC";
            // 
            // mntqlNhanvien
            // 
            this.mntqlNhanvien.Name = "mntqlNhanvien";
            this.mntqlNhanvien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mntqlNhanvien.Size = new System.Drawing.Size(301, 28);
            this.mntqlNhanvien.Text = "Quản lý nhân viên";
            this.mntqlNhanvien.Click += new System.EventHandler(this.mntqlNhanvien_Click);
            // 
            // mntqlKhachhang
            // 
            this.mntqlKhachhang.Name = "mntqlKhachhang";
            this.mntqlKhachhang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mntqlKhachhang.Size = new System.Drawing.Size(301, 28);
            this.mntqlKhachhang.Text = "Quản lý khách hàng";
            this.mntqlKhachhang.Click += new System.EventHandler(this.mntqlKhachhang_Click);
            // 
            // mntqlThucdon
            // 
            this.mntqlThucdon.Name = "mntqlThucdon";
            this.mntqlThucdon.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mntqlThucdon.Size = new System.Drawing.Size(301, 28);
            this.mntqlThucdon.Text = "Quản lý thực đơn";
            this.mntqlThucdon.Click += new System.EventHandler(this.mntqlThucdon_Click);
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntqlHoadonban,
            this.mntqlHoadonnhap});
            this.hóaĐơnToolStripMenuItem.Font = new System.Drawing.Font("Candara", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(103, 27);
            this.hóaĐơnToolStripMenuItem.Text = "HÓA ĐƠN";
            // 
            // mntqlHoadonban
            // 
            this.mntqlHoadonban.Name = "mntqlHoadonban";
            this.mntqlHoadonban.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mntqlHoadonban.Size = new System.Drawing.Size(302, 28);
            this.mntqlHoadonban.Text = "Hóa đơn bán hàng ";
            this.mntqlHoadonban.Click += new System.EventHandler(this.mntqlHoadonban_Click);
            // 
            // mntqlHoadonnhap
            // 
            this.mntqlHoadonnhap.Name = "mntqlHoadonnhap";
            this.mntqlHoadonnhap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mntqlHoadonnhap.Size = new System.Drawing.Size(302, 28);
            this.mntqlHoadonnhap.Text = "Hóa đơn nhập hàng";
            this.mntqlHoadonnhap.Click += new System.EventHandler(this.mntqlHoadonnhap_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntqlNhacungcap,
            this.mntqlThongtinhang});
            this.tàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Candara", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(112, 27);
            this.tàiKhoảnToolStripMenuItem.Text = "HÀNG HÓA";
            // 
            // mntqlNhacungcap
            // 
            this.mntqlNhacungcap.Name = "mntqlNhacungcap";
            this.mntqlNhacungcap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.mntqlNhacungcap.Size = new System.Drawing.Size(308, 28);
            this.mntqlNhacungcap.Text = "Nhà cung cấp";
            this.mntqlNhacungcap.Click += new System.EventHandler(this.mntqlNhacungcap_Click);
            // 
            // mntqlThongtinhang
            // 
            this.mntqlThongtinhang.Name = "mntqlThongtinhang";
            this.mntqlThongtinhang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.mntqlThongtinhang.Size = new System.Drawing.Size(308, 28);
            this.mntqlThongtinhang.Text = "Thông tin hàng hóa";
            this.mntqlThongtinhang.Click += new System.EventHandler(this.mntqlThongtinhang_Click);
            // 
            // tàiKhoảnToolStripMenuItem1
            // 
            this.tàiKhoảnToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntqlThongtinban});
            this.tàiKhoảnToolStripMenuItem1.Font = new System.Drawing.Font("Candara", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tàiKhoảnToolStripMenuItem1.Name = "tàiKhoảnToolStripMenuItem1";
            this.tàiKhoảnToolStripMenuItem1.Size = new System.Drawing.Size(99, 27);
            this.tàiKhoảnToolStripMenuItem1.Text = "KHU VỰC";
            // 
            // mntqlThongtinban
            // 
            this.mntqlThongtinban.CheckOnClick = true;
            this.mntqlThongtinban.Name = "mntqlThongtinban";
            this.mntqlThongtinban.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mntqlThongtinban.Size = new System.Drawing.Size(326, 28);
            this.mntqlThongtinban.Text = "Thông tin khu vực bàn";
            this.mntqlThongtinban.Click += new System.EventHandler(this.mntqlThongtinban_Click);
            // 
            // tàiKhoảnToolStripMenuItem2
            // 
            this.tàiKhoảnToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntQltaikhoan});
            this.tàiKhoảnToolStripMenuItem2.Font = new System.Drawing.Font("Candara", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tàiKhoảnToolStripMenuItem2.Name = "tàiKhoảnToolStripMenuItem2";
            this.tàiKhoảnToolStripMenuItem2.Size = new System.Drawing.Size(114, 27);
            this.tàiKhoảnToolStripMenuItem2.Text = "TÀI KHOẢN";
            // 
            // mntQltaikhoan
            // 
            this.mntQltaikhoan.Name = "mntQltaikhoan";
            this.mntQltaikhoan.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mntQltaikhoan.Size = new System.Drawing.Size(285, 28);
            this.mntQltaikhoan.Text = "Quản lý tài khoản";
            this.mntQltaikhoan.Click += new System.EventHandler(this.mntQltaikhoan_Click);
            // 
            // FrmHethong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1484, 813);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmHethong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG";
            this.Load += new System.EventHandler(this.FrmHethong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmHethong_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DanhmucToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntqlNhanvien;
        private System.Windows.Forms.ToolStripMenuItem mntqlKhachhang;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntqlNhacungcap;
        private System.Windows.Forms.ToolStripMenuItem mntqlThongtinhang;
        private System.Windows.Forms.ToolStripMenuItem mntqlHoadonban;
        private System.Windows.Forms.ToolStripMenuItem mntqlHoadonnhap;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mntqlThucdon;
        private System.Windows.Forms.ToolStripMenuItem mntQltaikhoan;
        private System.Windows.Forms.ToolStripMenuItem mntqlThongtinban;
    }
}