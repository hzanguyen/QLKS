using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Drawing.Drawing2D;
namespace GUI
{
    public partial class DangNhap : Form
    {
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            taikhoan.sTaiKhoan = txtTaiKhoan.Text;
            taikhoan.sMatKhau = txtMatKhau.Text;

            string getuser = TKBLL.CheckLogic(taikhoan);

            // Thể hiện trả lại kết quả nếu nghiệp vụ không đúng
            switch (getuser)
            {
                case "requeid_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống");
                    txtTaiKhoan.Focus();
                    return;

                case "requeid_password":
                    MessageBox.Show("Mật khẩu không được để trống");
                    txtMatKhau.Focus();
                    return;

                case "Tài khoản hoặc mật khẩu không chính xác!":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    txtTaiKhoan.Focus();
                    return;
            }

           TaiKhoanBLL tkbll = new TaiKhoanBLL();
            TaiKhoan tk = new TaiKhoan();
           tkbll.loadTaiKhoan(tk,txtTaiKhoan.Text);
            GLOBAL.MaNV = tk.sTaiKhoan;
            GLOBAL.HoTen = tk.sHoTen;
            GLOBAL.PhanQuyen = tk.sPhanQuyen;
            TrangChu tc = new TrangChu();
            tc.ShowDialog();
            this.Close();
        }

        private void btnLogic_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Độ cong của góc
            int diameter = radius * 2;
            // Góc trên cùng bên trái
            path.AddArc(new Rectangle(0, 0, diameter, diameter), 180, 90);

            // Góc trên cùng bên phải
            path.AddArc(new Rectangle(btnLogic.Width - diameter, 0, diameter, diameter), 270, 90);

            // Góc dưới cùng bên phải
            path.AddArc(new Rectangle(btnLogic.Width - diameter, btnLogic.Height - diameter, diameter, diameter), 0, 90);

            // Góc dưới cùng bên trái
            path.AddArc(new Rectangle(0, btnLogic.Height - diameter, diameter, diameter), 90, 90);

            path.CloseAllFigures();

            btnLogic.Region = new Region(path);
        }
    }
}
