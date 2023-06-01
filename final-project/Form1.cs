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
    public partial class Form1 : Form
    {
        public void draw()
        {
            Label[,] grids = new Label[20, 10];//20列10行
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grids[i, j] = new Label();
                    grids[i, j].Size = new Size(30, 30);//每个格子大小
                    grids[i,j].BorderStyle = BorderStyle.FixedSingle;//邊框樣式
                    grids[i,j].BackColor = Color.Black;//背景顏色
                    grids[i,j].Left = 100+30 * j;//左邊距
                    grids[i,j].Top = 120+30 * i;//上邊距
                    grids[i, j].Visible = true;
                    this.Controls.Add(grids[i, j]);//加到容器
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;//最大化窗體
            draw();
        }
    }
}
