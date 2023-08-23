using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Globalization;
using System.Reflection.Emit;

namespace GUI
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

          private void button1_Paint(object sender, PaintEventArgs e)
        {
                GraphicsPath path = new GraphicsPath();
                int radius = 20; // Độ cong của góc
                int diameter = radius * 2;
                // Góc trên cùng bên trái
                path.AddArc(new Rectangle(0, 0, diameter, diameter), 180, 90);

                // Góc trên cùng bên phải
                path.AddArc(new Rectangle(btnLuu.Width - diameter, 0, diameter, diameter), 270, 90);

                // Góc dưới cùng bên phải
                path.AddArc(new Rectangle(btnLuu.Width - diameter, btnLuu.Height - diameter, diameter, diameter), 0, 90);

                // Góc dưới cùng bên trái
                path.AddArc(new Rectangle(0, btnLuu.Height - diameter, diameter, diameter), 90, 90);

                path.CloseAllFigures();

                btnLuu.Region = new Region(path);
        }

        private void btnLuu_Paint(object sender, PaintEventArgs e)
        {
            
                GraphicsPath path = new GraphicsPath();
                int radius = 20; // Độ cong của góc
                int diameter = radius * 2;
                // Góc trên cùng bên trái
                path.AddArc(new Rectangle(0, 0, diameter, diameter), 180, 90);

                // Góc trên cùng bên phải
                path.AddArc(new Rectangle(btnLuu.Width - diameter, 0, diameter, diameter), 270, 90);

                // Góc dưới cùng bên phải
                path.AddArc(new Rectangle(btnLuu.Width - diameter, btnLuu.Height - diameter, diameter, diameter), 0, 90);

                // Góc dưới cùng bên trái
                path.AddArc(new Rectangle(0, btnLuu.Height - diameter, diameter, diameter), 90, 90);

                path.CloseAllFigures();

                btnLuu.Region = new Region(path);
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng điền đầy đủ thông tin");
            else
                this.errorProvider1.Clear();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng điền đầy đủ thông tin");
            else
                this.errorProvider1.Clear();
        }
        static int DonGia(string mp)
        {
            foreach(Phong p in phong)
            {
                if (p.sMaPhong == mp)
                    return p.iDonGia;
            }
            return 0;
        }
        public float heso(string lk)
        {
            LoaiKhachBLL lkbll = new LoaiKhachBLL();
            List<LoaiKhach> llk = new List<LoaiKhach>();
            lkbll.LoadKhach(llk);
         
            foreach(LoaiKhach l in llk)
            {
                if (l.Loai == lk)
                    return l.HeSo;     
            }
            return 1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {

            PhieuThuBLL ptbll = new PhieuThuBLL();
            PhieuThue pt = new PhieuThue();
            ptbll.LoadPhieuThue(pt, comboBox1.Text);
            ChiTietPHieuThueBLL ctpt = new ChiTietPHieuThueBLL();
            List<CHITIETPHIEUTHUE> lctpt = new List<CHITIETPHIEUTHUE>();
            ctpt.loadChiTietPhieuThu(lctpt, pt.MaPT);
            float tong = DonGia(comboBox1.Text)*SoNgayThue(comboBox1.Text, maskedTextBox1.Text);


            List<KhachHang> lkh = new List<KhachHang>();
            List<string> mkh = new List<string>();
            foreach (CHITIETPHIEUTHUE ctp in lctpt)
            {
                string s = ctp.MaKH;
                mkh.Add(s);
            }
            KhachHangBLL khbll = new KhachHangBLL();
            khbll.LoadKhachHang(lkh, mkh);
            float max = 1;
            foreach(KhachHang kh in lkh)
            {
                if (heso(kh.LoaiKH) > max)
                    max = heso(kh.LoaiKH);
            }
            if (lctpt.Count == n&&max>1)
            {
                tong = tong + tong * gtpt / 100 + tong * (max-1);
            } else if (lctpt.Count<n&&max > 1)
            {
                tong = tong * max;
            } else if(lctpt.Count==n && max == 1)
            {
                tong = tong + tong * gtpt / 100;
            }
            dataGridView1.Rows.Add((dataGridView1.RowCount + 1).ToString(),comboBox1.Text,SoNgayThue(comboBox1.Text,maskedTextBox1.Text), DonGia(comboBox1.Text), tong);
             textBox4.Text = (float.Parse(textBox4.Text) + tong).ToString();
        }
        static int SoNgayThue(string mp,string s)
        {
            PhieuThuBLL ptbll = new PhieuThuBLL();
            foreach (Phong p in phong)
            {
                if (p.sMaPhong == mp) {
                    PhieuThue pt = new PhieuThue();
                    ptbll.LoadPhieuThue(pt, mp);
                    DateTime date = DateTime.ParseExact(pt.NgayThue, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string formattedDate = date.ToString("yyyy-MM-dd");
                    DateTime startDate = DateTime.Parse(formattedDate);
                    DateTime endDate = DateTime.Parse(s);
                    TimeSpan span = endDate - startDate;
                    int days = (int)span.TotalDays;
                    return days;
                  }
            }
            return 0;
        }
        static List<Phong> phong = new List<Phong>();
        static QuyDinhBLL qdbll = new QuyDinhBLL();
        static List<QuyDinh> qd = new List<QuyDinh>();
        private void HoaDon_Load(object sender, EventArgs e)
        {
            qdbll.LoadQuyDinh(qd);
            textBox4.Text ="0" ;
            PhongBLL pbll = new PhongBLL();
            pbll.LoadPhongThue(phong);
            foreach (Phong p in phong)
            {
                comboBox1.Items.Add(p.sMaPhong);
            }
            DateTime time = DateTime.Now;
            maskedTextBox1.Text = time.Year.ToString() + "-" + time.ToString("MM") + "-" + time.ToString("dd");
            n = int.Parse(qd[0].GiaTri);
           gtpt = int.Parse(qd[1].GiaTri);
        }
        static int n;
        static int gtpt;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                HoaDon hd = new HoaDon();
                hd.MaNV = GLOBAL.MaNV;
                hd.KhachHang = textBox2.Text;
                hd.DiaChi = textBox1.Text;
                hd.NgayThanhToan = maskedTextBox1.Text;
                hd.TriGia = float.Parse(textBox4.Text);
                HoaDonBLL hdbll = new HoaDonBLL();
                hdbll.SaveHoaDon(hd);
                List<ChiTietHD> lcthd = new List<ChiTietHD>();
                List<string> mp = new List<string>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    PhieuThuBLL ptbll = new PhieuThuBLL();
                    PhieuThue pt = new PhieuThue();
                    ptbll.LoadPhieuThue(pt, row.Cells[1].Value.ToString());
                    ChiTietHD cthd = new ChiTietHD();
                    cthd.MaPhieuThue = pt.MaPT;
                    cthd.SoNgayThue = row.Cells[2].Value.ToString();
                    cthd.MaHD = hd.MaHD;
                    cthd.ThanhTien = row.Cells[4].Value.ToString();
                    lcthd.Add(cthd);
                    mp.Add(row.Cells[1].Value.ToString());

                }
                ChiTietHDBLL cthdbll = new ChiTietHDBLL();
                cthdbll.SaveChiTietHoaDon(lcthd, mp);
                TrangChu ftc = new TrangChu();
                ftc.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }
    }
}
