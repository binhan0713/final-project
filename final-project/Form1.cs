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
        bool[,] signs = new bool[24, 10];//紀錄每個方塊哪裡有東西
        Label[,] grids = new Label[20, 10];//20列10行
        Color[,] grids_color = new Color[20, 10];
        public void draw()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    signs[i,j] = false;//初始化
                }
            }
        
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grids[i, j] = new Label();
                    grids[i, j].Size = new Size(40, 40);//每个格子大小
                    grids[i,j].BorderStyle = BorderStyle.FixedSingle;//邊框樣式
                    grids[i,j].BackColor = Color.Black;//背景顏色
                    grids[i,j].Left = 750+40 * j;//左邊距
                    grids[i,j].Top = 150+40 * i;//上邊距
                    grids[i, j].Visible = true;
                    this.Controls.Add(grids[i, j]);//加到容器
                }
            }
        }
        void update_block(uint i, uint j, uint type)//方塊有37種對應哪個case把位置轉乘true並塗色
        {
            switch (type)
            {
                case 1:     //   ----
                    signs[i, j] = signs[i + 1, j] = signs[i + 2, j] = signs[i + 3, j] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i + 2, j] = grids_color[i + 3, j] = Color.Blue;
                    break;
                case 11:    //  |
                    signs[i, j] = signs[i, j + 1] = signs[i, j + 2] = signs[i, j + 3] = true;
                    grids_color[i, j] = grids_color[i, j + 1] = grids_color[i, j + 2] = grids_color[i, j + 3] = Color.Blue;
                    break;
                case 2:     //  口
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i + 1, j + 1] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i, j + 1] = grids_color[i + 1, j + 1] = Color.Yellow;
                    break;
                case 3:     // ㄣ
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i, j + 1] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i + 1, j - 1] = grids_color[i, j + 1] = Color.Red;
                    break;
                case 13:    //  _|一
                    signs[i, j] = signs[i - 1, j] = signs[i, j + 1] = signs[i + 1, j + 1] = true;
                    grids_color[i, j] = grids_color[i - 1, j] = grids_color[i, j + 1] = grids_color[i + 1, j + 1] = Color.Red;
                    break;
                case 4:     //  |-|
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j] = signs[i + 1, j + 1] = true;
                    grids_color[i, j] = grids_color[i, j - 1] = grids_color[i + 1, j] = grids_color[i + 1, j + 1] = Color.Green;
                    break;
                case 14:   //累了以此類推
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i - 1, j + 1] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i, j + 1] = grids_color[i - 1, j + 1] = Color.Green;
                    break;
                case 5:
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j + 1] = signs[i + 1, j + 2] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i + 1, j + 1] = grids_color[i + 1, j + 2] = Color.Orange;
                    break;
                case 15:
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j - 1] = signs[i + 2, j - 1] = true;
                    grids_color[i, j] = grids_color[i, j - 1] = grids_color[i + 1, j - 1] = grids_color[i + 2, j - 1] = Color.Orange;
                    break;
                case 25:
                    signs[i, j] = signs[i - 1, j] = signs[i - 1, j - 1] = signs[i - 1, j - 2] = true;
                    grids_color[i, j] = grids_color[i - 1, j] = grids_color[i - 1, j - 1] = grids_color[i - 1, j - 2] = Color.Orange;
                    break;
                case 35:
                    signs[i, j] = signs[i, j + 1] = signs[i - 1, j + 1] = signs[i - 2, j + 1] = true;
                    grids_color[i, j] = grids_color[i, j + 1] = grids_color[i - 1, j + 1] = grids_color[i - 2, j + 1] = Color.Orange;
                    break;
                case 6:
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i + 1, j - 2] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i + 1, j - 1] = grids_color[i + 1, j - 2] = Color.LightBlue;
                    break;
                case 16:
                    signs[i, j] = signs[i, j + 1] = signs[i + 1, j + 1] = signs[i + 2, j + 1] = true;
                    grids_color[i, j] = grids_color[i, j + 1] = grids_color[i + 1, j + 1] = grids_color[i + 2, j + 1] = Color.LightBlue;
                    break;
                case 26:
                    signs[i, j] = signs[i - 1, j] = signs[i - 1, j + 1] = signs[i - 1, j + 2] = true;
                    grids_color[i, j] = grids_color[i - 1, j] = grids_color[i - 1, j + 1] = grids_color[i - 1, j + 2] = Color.LightBlue;
                    break;
                case 36:
                    signs[i, j] = signs[i, j - 1] = signs[i - 1, j - 1] = signs[i - 2, j - 1] = true;
                    grids_color[i, j] = grids_color[i, j - 1] = grids_color[i - 1, j - 1] = grids_color[i - 2, j - 1] = Color.LightBlue;
                    break;

                case 7:
                    signs[i, j] = signs[i, j - 1] = signs[i, j + 1] = signs[i + 1, j] = true;
                    grids_color[i, j] = grids_color[i, j - 1] = grids_color[i, j + 1] = grids_color[i + 1, j] = Color.Purple;
                    break;
                case 17:
                    signs[i, j] = signs[i, j + 1] = signs[i - 1, j] = signs[i + 1, j] = true;
                    grids_color[i, j] = grids_color[i, j + 1] = grids_color[i - 1, j] = grids_color[i + 1, j] = Color.Purple;
                    break;
                case 27:
                    signs[i, j] = signs[i, j - 1] = signs[i, j + 1] = signs[i - 1, j] = true;
                    grids_color[i, j] = grids_color[i, j - 1] = grids_color[i, j + 1] = grids_color[i - 1, j] = Color.Purple;
                    break;
                case 37:
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j] = signs[i - 1, j] = true;
                    grids_color[i, j] = grids_color[i, j - 1] = grids_color[i + 1, j] = grids_color[i - 1, j] = Color.Purple;
                    break;
            }
        }
        bool y_direction(uint type, uint i, uint j)//檢驗下落的地方是不是有方塊，對應上面那個函式看他落下時是那些地方接觸到東西
                                                            
        {
            switch (type)
            {
                case 1:
                    if (i != 0 && !signs[i - 1, j]) return true;
                    else return false;

                case 11:
                    if (i != 0 && !signs[i - 1, j] && !signs[i - 1, j + 1] && !signs[i - 1, j + 2] && !signs[i - 1, j + 3]) return true;
                    else return false;

                case 2:
                    if (i != 0 && !signs[i - 1, j] && !signs[i - 1, j + 1]) return true;
                    else return false;

                case 3:
                    if (i != 0 && !signs[i, j - 1] && !signs[i - 1, j] && !signs[i - 1, j + 1]) return true;
                    else return false;

                case 13:
                    if (i != 1 && !signs[i - 2, j] && !signs[i - 1, j + 1]) return true;
                    else return false;

                case 4:
                    if (i != 0 && !signs[i, j + 1] && !signs[i - 1, j] && !signs[i - 1, j - 1]) return true;
                    else return false;

                case 14:
                    if (i != 1 && !signs[i - 1, j] && !signs[i - 2, j + 1]) return true;
                    else return false;

                case 5:
                    if (i != 0 && !signs[i - 1, j] && !signs[i, j + 1] && !signs[i, j + 2]) return true;
                    else return false;

                case 15:
                    if (i != 0 && !signs[i - 1, j] && !signs[i - 1, j - 1]) return true;
                    else return false;

                case 25:
                    if (i != 1 && !signs[i - 2, j] && !signs[i - 2, j - 1] && !signs[i - 2, j - 2]) return true;
                    else return false;

                case 35:
                    if (i != 2 && !signs[i - 1, j] && !signs[i - 3, j + 1]) return true;
                    else return false;

                case 6:
                    if (i != 0 && !signs[i, j - 1] && !signs[i, j - 2] && !signs[i - 1, j]) return true;
                    else return false;

                case 16:
                    if (i != 0 && !signs[i - 1, j] && !signs[i - 1, j + 1]) return true;
                    else return false;

                case 26:
                    if (i != 1 && !signs[i - 2, j] && !signs[i - 2, j + 1] && !signs[i - 2, j + 2]) return true;
                    else return false;

                case 36:
                    if (i != 2 && !signs[i - 1, j] && !signs[i - 3, j - 1]) return true;
                    else return false;

                case 7:
                    if (i != 0 && !signs[i - 1, j - 1] && !signs[i - 1, j] && !signs[i - 1, j + 1]) return true;
                    else return false;

                case 17:
                    if (i != 1 && !signs[i - 2, j] && !signs[i - 1, j + 1]) return true;
                    else return false;

                case 27:
                    if (i != 1 && !signs[i - 1, j - 1] && !signs[i - 1, j + 1] && !signs[i - 2, j]) return true;
                    else return false;

                case 37:
                    if (i != 1 && !signs[i - 2, j] && !signs[i - 1, j - 1]) return true;
                    else return false;

                default:
                    return false;
            }
        }
        bool x_direction(uint type, uint i, uint j, int d)//偵測水平
        {
            switch (type)
            {
                case 1:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i + 1, j - 1] && !signs[i + 2, j - 1] && !signs[i + 3, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 9 && !signs[i, j + 1] && !signs[i + 1, j + 1] && !signs[i + 2, j + 1] && !signs[i + 3, j + 1]) return true;
                        else return false;
                    }

                case 11:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 6 && !signs[i, j + 4]) return true;
                        else return false;
                    }

                case 2:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i + 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i + 1, j + 2]) return true;
                        else return false;
                    }

                case 3:
                    if (d == -1)
                    {
                        if (j != 1 && !signs[i, j - 1] && !signs[i + 1, j - 2]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i + 1, j + 1]) return true;
                        else return false;
                    }

                case 13:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i + 1, j] && !signs[i + 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i + 1, j + 2] && !signs[i - 1, j + 1]) return true;
                        else return false;
                    }

                case 4:
                    if (d == -1)
                    {
                        if (j != 1 && !signs[i, j - 2] && !signs[i + 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 1] && !signs[i + 1, j + 2]) return true;
                        else return false;
                    }

                case 14:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i + 1, j - 1] && !signs[i - 1, j]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i + 1, j + 1] && !signs[i - 1, j + 2]) return true;
                        else return false;
                    }

                case 5:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i + 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 7 && !signs[i, j + 1] && !signs[i + 1, j + 3]) return true;
                        else return false;
                    }

                case 15:
                    if (d == -1)
                    {
                        if (j != 1 && !signs[i, j - 2] && !signs[i + 1, j - 2] && !signs[i + 2, j - 2]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 9 && !signs[i, j + 1] && !signs[i + 1, j] && !signs[i + 2, j]) return true;
                        else return false;
                    }

                case 25:
                    if (d == -1)
                    {
                        if (j != 2 && !signs[i, j - 1] && !signs[i - 1, j - 3]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 9 && !signs[i, j + 1] && !signs[i - 1, j + 1]) return true;
                        else return false;
                    }

                case 35:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i - 1, j] && !signs[i - 2, j]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i - 1, j + 2] && !signs[i - 2, j + 2]) return true;
                        else return false;
                    }

                case 6:
                    if (d == -1)
                    {
                        if (j != 2 && !signs[i, j - 1] && !signs[i + 1, j - 3]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 9 && !signs[i, j + 1] && !signs[i + 1, j + 1]) return true;
                        else return false;
                    }

                case 16:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i + 1, j] && !signs[i + 2, j]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i + 1, j + 2] && !signs[i + 2, j + 2]) return true;
                        else return false;
                    }

                case 26:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i - 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 7 && !signs[i, j + 1] && !signs[i - 1, j + 3]) return true;
                        else return false;
                    }

                case 36:
                    if (d == -1)
                    {
                        if (j != 1 && !signs[i, j - 2] && !signs[i - 1, j - 2] && !signs[i - 2, j - 2]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 9 && !signs[i, j + 1] && !signs[i - 1, j] && !signs[i - 2, j]) return true;
                        else return false;
                    }

                case 7:
                    if (d == -1)
                    {
                        if (j != 1 && !signs[i, j - 2] && !signs[i + 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i + 1, j + 1]) return true;
                        else return false;
                    }

                case 17:
                    if (d == -1)
                    {
                        if (j != 0 && !signs[i, j - 1] && !signs[i + 1, j - 1] && !signs[i - 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i + 1, j + 1] && !signs[i - 1, j + 1]) return true;
                        else return false;
                    }

                case 27:
                    if (d == -1)
                    {
                        if (j != 1 && !signs[i, j - 2] && !signs[i - 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 8 && !signs[i, j + 2] && !signs[i - 1, j + 1]) return true;
                        else return false;
                    }

                case 37:
                    if (d == -1)
                    {
                        if (j != 1 && !signs[i, j - 2] && !signs[i + 1, j - 1] && !signs[i - 1, j - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (j != 9 && !signs[i, j + 1] && !signs[i + 1, j + 1] && !signs[i - 1, j + 1]) return true;
                        else return false;
                    }

                default:
                    return false;
            }
        }
        void full_line_check()
        {
            uint row_sum;
            uint i, j;

            i = 0;
            while (i < 20)
            {
                row_sum = 0;
                for (j = 0; j < 10; j++)
                    if (signs[i, j]) row_sum++;

                if (row_sum == 10)
                {
                    //score += 20;
                    //label_score.Text = "Score:" + score.ToString();
                    for (j = 0; j < 10; j++)
                        signs[i, j] = false;

                    show_grids(); // show a black line 

                    for (uint y = i; y < 21; y++)
                        for (j = 0; j < 10; j++)
                        {
                            signs[y, j] = signs[y + 1, j];
                            grids_color[y, j] = grids_color[y + 1, j];
                        }
                    show_grids();
                }
                else i++;
            }
        }
        void show_grids()
        {
            int i, j;
            for (i = 0; i < 20; i++)
                for (j = 0; j < 10; j++)
                    if (signs[i, j])
                        grids[i, j].BackColor = grids_color[i, j];
                    else
                        grids[i, j].BackColor = Color.Black;
        }
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;//最大化窗體
            draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
