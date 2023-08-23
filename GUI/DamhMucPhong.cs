using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class DamhMucPhong : Form
    {
        public DamhMucPhong()
        {
            InitializeComponent();
        }
        static LoaiPhongBLL lpbll = new LoaiPhongBLL();
        static List<LoaiPhong> llphong = new List<LoaiPhong>();
        private void DamhMucPhong_Load(object sender, EventArgs e)
        {
            PhongBLL pbb = new PhongBLL();
            List<Phong> phongs = new List<Phong>();
            pbb.LoadPhong(phongs);
            foreach(Phong phong in phongs)
            {
                dataGridView1.Rows.Add((dataGridView1.Rows.Count + 1).ToString(), phong.sMaPhong, phong.sLoaiPhong, phong.iDonGia, phong.sNote);
            }
           
            lpbll.LoadPhong(llphong);
            foreach(LoaiPhong phong in llphong)
            {
                comboBox1.Items.Add(phong.Loai);
            }
            dataGridView1.ClearSelection();
            textBox2.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChu trf = new TrangChu();
                trf.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Text = "Lưu";
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[3].Value.ToString();
            textBox3.Text = row.Cells[4].Value.ToString();
            comboBox1.Text=row.Cells[2].Value.ToString();
            textBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                if (button2.Text == "Thêm")
                {
                    Phong phong = new Phong();
                    phong.sMaPhong = textBox1.Text;
                    phong.sLoaiPhong = comboBox1.Text;
                    phong.iDonGia = int.Parse(textBox2.Text);
                    phong.sNote = textBox3.Text;
                    phong.sTinhTrang = "Trong";
                    PhongBLL pbll = new PhongBLL();
                    pbll.AddPhong(phong);
                    dataGridView1.Rows.Add((dataGridView1.Rows.Count + 1).ToString(), phong.sMaPhong, phong.sLoaiPhong, phong.iDonGia, phong.sNote);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox3.Text = "";

                }
                else
                {

                    Phong phong = new Phong();
                    phong.sMaPhong = textBox1.Text;
                    phong.sLoaiPhong = comboBox1.Text;
                    phong.iDonGia = int.Parse(textBox2.Text);
                    phong.sNote = textBox3.Text;
                    PhongBLL pbll = new PhongBLL();
                    pbll.UpdatePhong(phong);
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    row.Cells[2].Value = comboBox1.Text;
                    row.Cells[3].Value = textBox2.Text;
                    row.Cells[4].Value = textBox3.Text;
                    textBox1.ReadOnly = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox3.Text = "";
                    button2.Text = "Thêm";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            PhongBLL lpbll = new PhongBLL();
            lpbll.DeletePhong(row.Cells[1].Value.ToString());
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = llphong[comboBox1.SelectedIndex].DonGia;
        }
    }
}
