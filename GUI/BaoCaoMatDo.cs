using BLL;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Drawing.Drawing2D;

namespace GUI
{
    public partial class BaoCaoMatDo : Form
    {
        public BaoCaoMatDo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BaoCaoMatDo_Load(object sender, EventArgs e)
        {
            string[] month = new string[] {"1","2","3","4","5","6","7","8","9","10","11","12" };
            comboBox1.Items.AddRange(month);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int currentYear = DateTime.Now.Year;
            string month = comboBox1.Text;
            int daysInMonth = DateTime.DaysInMonth(currentYear, int.Parse(month));
            PhongBLL pbll = new PhongBLL();
            PhieuThuBLL ptbll = new PhieuThuBLL();
            List<Phong> phongs = new List<Phong>();
            pbll.LoadPhong(phongs);
            foreach(Phong phong in phongs)
            {
                List<string> list = new List<string>();
                ptbll.LoadPhieuThueMP(list, phong.sMaPhong, month);
                BaoCaoBLL bcbll = new BaoCaoBLL();
                int tong= bcbll.SoNgayThue(list);
                float tln = (float)tong / (float)daysInMonth;
                float tl = (float)(tln* 100);
                dataGridView1.Rows.Add((dataGridView1.RowCount + 1).ToString(), phong.sMaPhong, tong.ToString(),tl.ToString());
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
            TrangChu ftc = new TrangChu();
            ftc.ShowDialog();
            this.Close();
        }
    }
}
