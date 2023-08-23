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

namespace GUI
{
    public partial class BaoCaoPhong : Form
    {
        public BaoCaoPhong()
        {
            InitializeComponent();
        }

        private void BaoCaoPhong_Load(object sender, EventArgs e)
        {
            string[] month = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            comboBox1.Items.AddRange(month);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int currentYear = DateTime.Now.Year;
            string month = comboBox1.Text;
            int daysInMonth = DateTime.DaysInMonth(currentYear, int.Parse(month));
            LoaiPhongBLL lpbll = new LoaiPhongBLL();
            List<LoaiPhong> lps = new List<LoaiPhong>();
            lpbll.LoadPhong(lps);
            List<float> tong = new List<float>();
            foreach (LoaiPhong lp in lps)
            {
                List<string> list = new List<string>();
                PhieuThuBLL ph = new PhieuThuBLL();
                ph.LoadPhieuThueLp(list,lp.Loai,month);
                BaoCaoBLL bcbll = new BaoCaoBLL();
                tong.Add( bcbll.DoanhThuLP(list));
                dataGridView1.Rows.Add((dataGridView1.RowCount + 1).ToString(),lp.Loai, bcbll.DoanhThuLP(list).ToString());
            }
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = tong[i] / (tong.Sum());
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChu trf = new TrangChu();
            trf.ShowDialog();
            this.Close();
        }
    }
}
