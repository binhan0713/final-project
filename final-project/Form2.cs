using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace final_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // 设置背景图像
            this.BackgroundImage = Image.FromFile("./start.png");

            // 设置背景图像布局模式（可选）
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Font ShowFont(string name, float size)
            {
                Font font = null;
                System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
                privateFonts.AddFontFile("./Minecraft.ttf");
                font = new Font(privateFonts.Families[0], size);
                return font;
            }
            void ChangecontrolFont_button1(Font font)
            {
                button1.Font = font;
            }
            void ChangecontrolFont_label1(Font font)
            {
                label1.Font = font;
            }
            ChangecontrolFont_button1(ShowFont("Minecraft", 20));
            ChangecontrolFont_label1(ShowFont("Minecraft", 50));
            button1.FlatStyle = FlatStyle.Flat;//設定button1的樣式為Flat
            button1.FlatAppearance.BorderSize = 2;//設定button1的邊框為2
            button2.FlatStyle = FlatStyle.Flat;//設定button1的樣式為Flat
            button2.FlatAppearance.BorderSize = 2;//設定button1的邊框為2
            button3.FlatStyle = FlatStyle.Flat;//設定button1的樣式為Flat
            button3.FlatAppearance.BorderSize = 2;//設定button1的邊框為2
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Size=new Size(button1.Width + 10, button1.Height + 10);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if(button1.Width>112)
            {
                button1.Width -= 10;
                button1.Height -= 10;
            }
 

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Size = new Size(button3.Width + 10, button3.Height + 10);

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.Width > 112)
            {
                button3.Width -= 10;
                button3.Height -= 10;
            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Size = new Size(button2.Width + 10, button2.Height + 10);

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.Width > 216)
            {
                button2.Width -= 10;
                button2.Height -= 10;
            }
        }
    }
}
