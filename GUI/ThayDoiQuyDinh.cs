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

namespace GUI
{
    public partial class ThayDoiQuyDinh : Form
    {
        public ThayDoiQuyDinh()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ThayDoiQuyDinh_Load(object sender, EventArgs e)
        {
            List<LoaiKhach> lk = new List<LoaiKhach>();
            LoaiKhachBLL lkbll = new LoaiKhachBLL();
            lkbll.LoadKhach(lk);
            List<LoaiPhong> lk2 = new List<LoaiPhong>();
            LoaiPhongBLL lpbll = new LoaiPhongBLL();
            lpbll.LoadPhong(lk2);
            List<QuyDinh> qds = new List<QuyDinh>();
            QuyDinhBLL qdbll = new QuyDinhBLL();
            qdbll.LoadQuyDinh(qds);
            foreach(LoaiKhach khach in lk)
            {
                dataGridView2.Rows.Add(khach.Loai, khach.Ten, khach.HeSo);
            }
            foreach(LoaiPhong phong in lk2)
            {
                dataGridView1.Rows.Add(phong.Loai, phong.DonGia);
            }
            foreach(QuyDinh qd in qds)
            {
                dataGridView3.Rows.Add(qd.MaQd, qd.TenQD, qd.GiaTri);
            }
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();

            button3.Enabled = false;
        }

        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "Lưu";
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox1.ReadOnly = true;
            textBox2.Text=row.Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                if (button1.Text == "Lưu")
                {
                    LoaiPhong lp = new LoaiPhong();
                    lp.Loai = textBox1.Text;
                    lp.DonGia = textBox2.Text;
                    LoaiPhongBLL lpbll = new LoaiPhongBLL();
                    lpbll.UpdateLoaiPhong(lp);
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    row.Cells[1].Value = textBox2.Text;
                    textBox1.Text = "";
                    textBox1.ReadOnly = false;
                    textBox2.Text = "";
                    button1.Text = "Thêm";
                }
                else
                {

                    LoaiPhong lp = new LoaiPhong();
                    lp.Loai = textBox1.Text;
                    lp.DonGia = textBox2.Text;
                    LoaiPhongBLL lpbll = new LoaiPhongBLL();
                    lpbll.AddLoadPhong(lp);
                    dataGridView1.Rows.Add(textBox1.Text, textBox2.Text);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin để thêm hoặc sửa loại phòng");
            }
        }

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            LoaiPhongBLL lpbll = new LoaiPhongBLL();
            lpbll.DeleteLoaiPhong(row.Cells[0].Value.ToString());
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2.Text = "Lưu";
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            textBox4.Text = row.Cells[0].Value.ToString();
            textBox4.ReadOnly = true;
            textBox3.Text = row.Cells[1].Value.ToString();
            textBox5.Text = row.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0)
            {
                if (button2.Text == "Lưu")
                {
                    LoaiKhach lp = new LoaiKhach();
                    lp.Loai = textBox4.Text;
                    lp.Ten = textBox3.Text;
                    lp.HeSo = float.Parse(textBox5.Text);
                    LoaiKhachBLL lpbll = new LoaiKhachBLL();
                    lpbll.UpdateLoaiKhach(lp);
                    DataGridViewRow row = dataGridView2.SelectedRows[0];
                    row.Cells[1].Value = textBox3.Text;
                    row.Cells[2].Value = textBox5.Text;
                    textBox4.Text = "";
                    textBox4.ReadOnly = false;
                    textBox3.Text = "";
                    textBox5.Text = "";
                    button2.Text = "Thêm";
                }
                else
                {

                    LoaiKhach lp = new LoaiKhach();
                    lp.Loai = textBox4.Text;
                    lp.Ten = textBox3.Text;
                    lp.HeSo = float.Parse(textBox5.Text);
                    LoaiKhachBLL lpbll = new LoaiKhachBLL();
                    lpbll.AddLoaiKhach(lp);
                    dataGridView2.Rows.Add(textBox4.Text, textBox3.Text, textBox5.Text);
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin để thêm hoặc sửa loại khách");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            LoaiKhachBLL lpbll = new LoaiKhachBLL();
            lpbll.DeleteLoaiKhach(row.Cells[0].Value.ToString());
            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            DataGridViewRow row = dataGridView3.SelectedRows[0];
            textBox8.Text = row.Cells[0].Value.ToString();

            textBox8.ReadOnly = true;
            textBox7.Text = row.Cells[1].Value.ToString();
            textBox6.Text = row.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0 && textBox7.Text.Length > 0 && textBox8.Text.Length > 0)
            {
                QuyDinhBLL qdbll = new QuyDinhBLL();
                QuyDinh qd = new QuyDinh();
                qd.MaQd = textBox8.Text;
                qd.TenQD = textBox7.Text;
                qd.GiaTri = textBox6.Text;
                qdbll.UpdateQuyDinh(qd);
                DataGridViewRow row = dataGridView3.SelectedRows[0];
                row.Cells[1].Value = textBox7.Text;
                row.Cells[2].Value = textBox6.Text;
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin để sửa quy định");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrangChu ftr = new TrangChu();
            ftr.ShowDialog();
            this.Close();
        }
    }
}
