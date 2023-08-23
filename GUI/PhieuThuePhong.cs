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
namespace GUI
{
    public partial class PhieuTP : Form
    {
        public PhieuTP(string x)
        {
            InitializeComponent();
            TenPhong = x;
        }
        public static string TenPhong;
        LoaiKhachBLL lkbll = new LoaiKhachBLL();
        List<LoaiKhach> lk = new List<LoaiKhach>();
        static QuyDinhBLL qdbll = new QuyDinhBLL();
        static List<QuyDinh> qd = new List<QuyDinh>();
        static int n;
        private void PhieuThuePhong_Load(object sender, EventArgs e)
        {
            
            qdbll.LoadQuyDinh(qd);
            lkbll.LoadKhach(lk);
            foreach(LoaiKhach loaiKhach in lk)
            {
                comboBox2.Items.Add(loaiKhach.Ten);
            }
            textBox3.Text = TenPhong;
            DateTime time = DateTime.Now;
            DateThue.Text = time.Year.ToString() + "-" + time.ToString("MM") + "-" + time.ToString("dd");
            comboBox2.Text = lk[0].Ten;
            n= int.Parse(qd[0].GiaTri);
        }
       
        private void button1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Độ cong của góc
            int diameter = radius * 2;
            // Góc trên cùng bên trái
            path.AddArc(new Rectangle(0, 0, diameter, diameter), 180, 90);

            // Góc trên cùng bên phải
            path.AddArc(new Rectangle(button1.Width - diameter, 0, diameter, diameter), 270, 90);

            // Góc dưới cùng bên phải
            path.AddArc(new Rectangle(button1.Width - diameter, button1.Height - diameter, diameter, diameter), 0, 90);

            // Góc dưới cùng bên trái
            path.AddArc(new Rectangle(0, button1.Height - diameter, diameter, diameter), 90, 90);

            path.CloseAllFigures();

            button1.Region = new Region(path);
        }

        private void Name_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng điền đầy đủ thông tin");
            else
                this.errorProvider1.Clear();
        }

        private void DiaChi_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng điền đầy đủ thông tin");
            else
                this.errorProvider1.Clear();
        }

        private void DateThue_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng điền đầy đủ thông tin");
            else
                this.errorProvider1.Clear();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Length > 0 && comboBox2.Text.Length > 0 && DiaChi.Text.Length > 0)
            {
                if (n > dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows.Add((dataGridView1.RowCount + 1).ToString(), tbName.Text, comboBox2.Text, CMND.Text, DiaChi.Text);
                    tbName.Text = "";
                    CMND.Text = "";
                    DiaChi.Text = "";
                    comboBox2.Text = lk[0].Ten;
                }
                else
                    MessageBox.Show("Khong được thêm quá " + n + " trong mot phong");
            }
            else
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           List<KhachHang> list = new List<KhachHang>();
           foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.TenKH = row.Cells[1].Value.ToString();
                foreach(LoaiKhach l in lk)
                {
                    if (l.Ten == row.Cells[2].Value.ToString())
                    {
                        kh.LoaiKH = l.Loai;
                    }
                }
                kh.CMND = row.Cells[3].Value.ToString();
                kh.DiaChi = row.Cells[4].Value.ToString();
                list.Add(kh);
            }
            KhachHangBLL khbll = new KhachHangBLL();
            khbll.SaveKhachHang(list);
           PhieuThue pt =new PhieuThue();
            pt.MaPhong = textBox3.Text;
            pt.NgayThue = DateThue.Text;
            pt.MaNV = GLOBAL.MaNV;
            PhieuThuBLL ptbll = new PhieuThuBLL();
            ptbll.SavePhieuThue(pt);
            List<CHITIETPHIEUTHUE> ctpt = new List<CHITIETPHIEUTHUE>();
            foreach(KhachHang kh in list)
            {
                CHITIETPHIEUTHUE ct= new CHITIETPHIEUTHUE();
                ct.MaPT = pt.MaPT;
                ct.MaKH = kh.MaKH;
                ctpt.Add(ct);

            }
            ChiTietPHieuThueBLL ctptbll = new ChiTietPHieuThueBLL();
            ctptbll.SaceChiTietPhieuThu(ctpt);
            MessageBox.Show("Thêm thành công");
            TrangChu tc = new TrangChu();
            tc.ShowDialog();
            this.Close();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            tc.ShowDialog();
            this.Close();
        }
    }
}
