using System.Windows.Forms;

namespace GUI
{
    partial class TrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BaoCaoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mậtĐộSửDụngPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThayDoiQDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TTItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DMPItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DXItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BaoCaoItem,
            this.ThayDoiQDItem,
            this.TTItem,
            this.DMPItem,
            this.DXItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BaoCaoItem
            // 
            this.BaoCaoItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhThuPhòngToolStripMenuItem,
            this.mậtĐộSửDụngPhòngToolStripMenuItem});
            this.BaoCaoItem.Name = "BaoCaoItem";
            this.BaoCaoItem.Size = new System.Drawing.Size(63, 20);
            this.BaoCaoItem.Text = "Báo Cáo";
            // 
            // doanhThuPhòngToolStripMenuItem
            // 
            this.doanhThuPhòngToolStripMenuItem.Name = "doanhThuPhòngToolStripMenuItem";
            this.doanhThuPhòngToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.doanhThuPhòngToolStripMenuItem.Text = "Doanh Thu Phòng";
            this.doanhThuPhòngToolStripMenuItem.Click += new System.EventHandler(this.doanhThuPhòngToolStripMenuItem_Click);
            // 
            // mậtĐộSửDụngPhòngToolStripMenuItem
            // 
            this.mậtĐộSửDụngPhòngToolStripMenuItem.Name = "mậtĐộSửDụngPhòngToolStripMenuItem";
            this.mậtĐộSửDụngPhòngToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.mậtĐộSửDụngPhòngToolStripMenuItem.Text = "Mật Độ Sử Dụng Phòng";
            this.mậtĐộSửDụngPhòngToolStripMenuItem.Click += new System.EventHandler(this.mậtĐộSửDụngPhòngToolStripMenuItem_Click);
            // 
            // ThayDoiQDItem
            // 
            this.ThayDoiQDItem.Name = "ThayDoiQDItem";
            this.ThayDoiQDItem.Size = new System.Drawing.Size(118, 20);
            this.ThayDoiQDItem.Text = "Thay Đổi Quy Định";
            this.ThayDoiQDItem.Click += new System.EventHandler(this.ThayDoiQDItem_Click);
            // 
            // TTItem
            // 
            this.TTItem.Name = "TTItem";
            this.TTItem.Size = new System.Drawing.Size(80, 20);
            this.TTItem.Text = "Thanh Toán";
            this.TTItem.Click += new System.EventHandler(this.TTItem_Click);
            // 
            // DMPItem
            // 
            this.DMPItem.Name = "DMPItem";
            this.DMPItem.Size = new System.Drawing.Size(112, 20);
            this.DMPItem.Text = "Danh Mục Phòng";
            this.DMPItem.Click += new System.EventHandler(this.DMPItem_Click);
            // 
            // DXItem
            // 
            this.DXItem.Name = "DXItem";
            this.DXItem.Size = new System.Drawing.Size(74, 20);
            this.DXItem.Text = "Đăng Xuất";
            this.DXItem.Click += new System.EventHandler(this.DXItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(173, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 300);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(255)))), ((int)(((byte)(144)))));
            this.panel2.Location = new System.Drawing.Point(99, 342);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 24);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
            this.panel3.Location = new System.Drawing.Point(99, 382);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 24);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(96)))));
            this.panel4.Location = new System.Drawing.Point(99, 424);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 24);
            this.panel4.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Phòng Trống";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Phòng Đang Thuê";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Phòng Đang Chọn";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(444, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "A: 150.000Đ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(444, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "B: 170.000Đ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(444, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "C: 200.000Đ";
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 499);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrangChu";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BaoCaoItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mậtĐộSửDụngPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThayDoiQDItem;
        private System.Windows.Forms.ToolStripMenuItem TTItem;
        private System.Windows.Forms.ToolStripMenuItem DXItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem DMPItem;
    }
}