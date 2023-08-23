using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace GUI
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            if (GLOBAL.PhanQuyen.Trim() == "01")
            { 
                BaoCaoItem.Visible = false;
                TTItem.Visible = false;
            } else if(GLOBAL.PhanQuyen.Trim() == "02")
            {
                ThayDoiQDItem.Visible = false;
                TTItem.Visible = false;
            }
            else
            {
                BaoCaoItem.Visible = false;
                ThayDoiQDItem.Visible = false;
            }
            List<Phong> rooms = new List<Phong>();
            PhongBLL loadp =new PhongBLL();
            loadp.LoadPhong(rooms);
            int i = 0,j=0;
            foreach (Phong roomNumber in rooms)
            {
                Button roomButton = new Button();
                roomButton.Name = roomNumber.sMaPhong.Trim();
                roomButton.Text = roomNumber.sMaPhong.Trim() + "." + roomNumber.sLoaiPhong.Trim();
                roomButton.Size = new Size(100, 50);
                roomButton.Location = new Point(110 * i , 60 * j);
                i++;
                if (i > 3)
                {
                    j++;
                    i = 0;
                }
                // Thiết lập màu nền của button dựa trên tình trạng của phòng
                switch (roomNumber.sTinhTrang.Trim())
                {
                    case "Thue":
                        roomButton.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
                        break;
                    case "Chon":
                        roomButton.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(96)))));
                        break;
                    default:
                        roomButton.BackColor = Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(255)))), ((int)(((byte)(144)))));
                        break;
                }
               
                    if (roomNumber.sTinhTrang.Trim() == "Thue")
                    {
                        roomButton.Click += new EventHandler(RoomButtonfalse_Click);
                    }
                    else
                        // Đăng ký sự kiện Click cho button
                        roomButton.Click += new EventHandler(RoomButton_Click);
                    // Thêm button vào panel
                    panel1.Controls.Add(roomButton);
               
            }

        }
        private void RoomButton_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện Click cho button
            
            Button roomButton = sender as Button;
            PhieuTP  ptp = new PhieuTP(roomButton.Name);
            ptp.ShowDialog();
            this.Close();
        }
        private void RoomButtonfalse_Click(object sender, EventArgs e)
        {

            Button roomButton = sender as Button;
            PhieuThuePhongHien ptp = new PhieuThuePhongHien(roomButton.Name);
            ptp.ShowDialog();
            this.Close();
        }
      
            private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DXItem_Click(object sender, EventArgs e)
        {
            DangNhap fmdn = new DangNhap();
            fmdn.ShowDialog();
            this.Close();

        }

        private void TTItem_Click(object sender, EventArgs e)
        {
              frmHoaDon hd = new frmHoaDon();
                hd.ShowDialog();
        }

        private void mậtĐộSửDụngPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoMatDo bcmdf = new BaoCaoMatDo();
            bcmdf.ShowDialog();
            this.Close();
        }

        private void doanhThuPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoPhong frm = new BaoCaoPhong();
            frm.ShowDialog();
            this.Close();
        }

        private void DMPItem_Click(object sender, EventArgs e)
        {
            DamhMucPhong fdmf = new DamhMucPhong();
            fdmf.ShowDialog();
            this.Close();
        }

        private void ThayDoiQDItem_Click(object sender, EventArgs e)
        {
            ThayDoiQuyDinh tdqdf = new ThayDoiQuyDinh();
            tdqdf.ShowDialog();
            this.Close();
        }
    }
}
