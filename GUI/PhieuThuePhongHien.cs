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
using BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Globalization;

namespace GUI
{
    public partial class PhieuThuePhongHien : Form
    {
        public PhieuThuePhongHien(string x)
        {
            InitializeComponent();
            TenPhong = x;
        }
        public static string TenPhong;
        LoaiKhachBLL lkbll = new LoaiKhachBLL();
        List<LoaiKhach> lk = new List<LoaiKhach>();
        private void PhieuThuePhong_Load(object sender, EventArgs e)
        {
            textBox3.Text = TenPhong;
           
            PhieuThuBLL ptbll = new PhieuThuBLL();
            PhieuThue pt = new PhieuThue();
            ptbll.LoadPhieuThue(pt, TenPhong);
            ChiTietPHieuThueBLL ctpt = new ChiTietPHieuThueBLL();
            List<CHITIETPHIEUTHUE> lctpt = new List<CHITIETPHIEUTHUE>();
            ctpt.loadChiTietPhieuThu(lctpt, pt.MaPT);
            List<KhachHang> lkh = new List<KhachHang>();
            List<string> mkh = new List<string>();
            foreach (CHITIETPHIEUTHUE ctp in lctpt)
            {
                string s = ctp.MaKH;
                mkh.Add(s);
            }
            KhachHangBLL khbll = new KhachHangBLL();
            khbll.LoadKhachHang(lkh, mkh);
            foreach(KhachHang kh in lkh)
            {
                dataGridView1.Rows.Add((dataGridView1.RowCount+1).ToString(), kh.TenKH, kh.LoaiKH, kh.CMND, kh.DiaChi);
            }
            DateTime date = DateTime.ParseExact(pt.NgayThue, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            string formattedDate = date.ToString("yyyy-MM-dd");
            DateThue.Text =formattedDate ;
            textBox1.Text = pt.MaNV;
        }

       private void button2_Click(object sender, EventArgs e)
        {
            TrangChu trf = new TrangChu();
            trf.ShowDialog();
            this.Close();
        }
    }
}
