using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("./tips3.jpg");
            button1.FlatStyle = FlatStyle.Flat;//設定button1的樣式為Flat
            button1.FlatAppearance.BorderSize = 2;//設定button1的邊框為2
            this.StartPosition = FormStartPosition.CenterScreen;
            // 设置背景图像布局模式（可选）
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = imageList1.Images[0];
            pictureBox2.Image = imageList1.Images[1];
            pictureBox3.Image = imageList1.Images[2];
            pictureBox4.Image = imageList1.Images[3];
            pictureBox5.Image = imageList1.Images[4];
            pictureBox6.Image = imageList2.Images[0];
            pictureBox7.Image = imageList3.Images[0];
            label1.BackColor = Color.Black;
            label2.BackColor = Color.Black;
            label3.BackColor = Color.Black;
            label4.BackColor = Color.Black;
            label5.BackColor = Color.Black;
            label6.BackColor = Color.Black;
            label7.BackColor = Color.Black;
            button1.BackColor = Color.Silver;


        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
