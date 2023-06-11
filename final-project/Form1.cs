using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.IO;
using System.Text.Json;

namespace final_project
{
    public partial class Form1 : Form

    {
        int x = 0;
        Color grayColor = Color.FromArgb(205, 0, 0, 0);
        bool end = false;//紀錄遊戲是否結束
        bool israndon = true;
        bool[,] signs = new bool[24, 10];//紀錄每個方塊哪裡有東西
        Label[,] temp = new Label[4, 4];//暫存方塊
        Label[,] next = new Label[4, 3];   //next area, total 12 grids
        Label[,] grids = new Label[24, 10];//game area, total 200 grids
        Color[,] grids_color = new Color[24, 10];//紀    錄每個方塊的顏色
        bool[,] shade = new bool[24, 10];//紀錄每個方塊的陰影
        bool exchange = false;//紀錄是否交換
        int exchange_count = 0;//紀錄交換次數
        uint block_row = 20;
        uint block_col = 4;
        uint block_type;
        uint block_row_pre = 20;
        uint block_col_pre = 4;
        uint block_type_pre;
        uint block_type_next;
        uint block_type_temp=0;
        bool block_changed = false;
        uint block_count = 0;//計算方塊數量
        uint score = 0;
        int timer_interval = 1010;
        int game_mode = 1;
        Random rander = new Random();
        PictureBox pictureBox1 = new PictureBox();

        public Form1()
        {

            InitializeComponent();


            timer1.Stop();
            timer3.Start();
            axWindowsMediaPlayer5.Visible = false;
            axWindowsMediaPlayer5.URL = "Ding.mp4";
            axWindowsMediaPlayer5.Ctlcontrols.play();
            Font ShowFont(string name, float size)
            {
                Font font = null;
                System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
                privateFonts.AddFontFile("./Minecraft.ttf");
                font = new Font(privateFonts.Families[0], size);
                return font;
            }
            void ChangecontrolFont(Font font)
            {
                label_block_count.Font = font;
                label1.Font = font;
                label2.Font = font;
                label_info.Font = font;
                label_level.Font = font;
                label_score.Font = font;
                textBox1.Font = font;

            }
            ChangecontrolFont(ShowFont("Minecraft", 18));
            groupBox1.Text = "";
            axWindowsMediaPlayer1.uiMode = "none";//隱藏播放器的控制項
            axWindowsMediaPlayer1.URL = "space.mp4";//播放音樂
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer3.Visible = false;
            axWindowsMediaPlayer3.settings.autoStart = false;
            axWindowsMediaPlayer3.URL = "drum.mp3";//播放音樂
            axWindowsMediaPlayer4.Visible = false;
            axWindowsMediaPlayer4.settings.autoStart = false;
            axWindowsMediaPlayer4.URL = "full_line.mp3";//播放音樂
            WindowState = FormWindowState.Maximized;//最大化窗體
            //設定音樂循環播放
            block_type = (uint)rander.Next(0, 7) + 1;
            block_type_pre = block_type;
            block_type_next = block_type;
                
            // generate 20x10 labels for "main" area, dynamically.
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++)
                {
                    grids[i, j] = new Label();
                    
                    grids[i, j].Width = 30;
                    grids[i, j].Height = 30;
                    grids[i, j].BorderStyle = BorderStyle.FixedSingle;


                    grids[i, j].Left = 630 + 30 * j;
                    grids[i, j].Top = 650 - i * 30;
                    grids[i, j].Visible = true;
                    this.Controls.Add(grids[i, j]);

                }
            // generate 4x3 labels for "next" area, dynamically.
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                {
                    next[i, j] = new Label();
                    next[i, j].BringToFront();
                    next[i, j].Width = 20;
                    next[i, j].Height = 20;
                    next[i, j].BorderStyle = BorderStyle.FixedSingle;
                    next[i, j].BackColor = Color.White;
                    next[i, j].Left = 995 + 20 * j;
                    next[i, j].Top = 150 - i * 20;
                    next[i, j].Visible = true;
                    this.Controls.Add(next[i, j]);
                    next[i, j].BringToFront();
                }
            pictureBox1.Location = new Point(720, 200);
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(pictureBox1);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                {
                    temp[i, j] = new Label();
                    temp[i, j].BringToFront();
                    temp[i, j].Width = 20;
                    temp[i, j].Height = 20;
                    temp[i, j].BorderStyle = BorderStyle.FixedSingle;
                    temp[i, j].BackColor = Color.White;
                    temp[i, j].Left = 495 + 20 * j;
                    temp[i, j].Top = 150 - i * 20;
                    temp[i, j].Visible = true;
                    this.Controls.Add(temp[i, j]);
                    temp[i, j].BringToFront();
                }
            // init variables of the game
            init_game();
            textBox1.Visible = false;
            textBox1.BackColor = Color.Black;

            

        }

        public async void timer1_Tick(object sender, EventArgs e)
        {
            if (y_direction(block_type, block_row, block_col))
            {
                if (israndon)
                {
                    block_type_next = (uint)rander.Next(0, 7) + 1;
                    israndon = false;
                }               
                block_row_pre = block_row; block_row_pre = block_row; block_type_pre = block_type;

                block_row--;

                if (block_row == 19 && !exchange)
                {
                    display_next_block(block_type_next);
                    block_count++;
                    score += 5;
                    label_block_count.Text = "Blocks:" + block_count.ToString();
                    label_score.Text = "Score:" + score.ToString();
                    if (game_mode == 1)
                    {
                        timer_interval = 1010 - (int)(score / 150) * 50;
                        if (timer_interval <= 0)
                            timer_interval = 10;

                        timer1.Interval = timer_interval;
                        label_level.Text = "Level:" + (1010 - timer_interval) / 50;
                    }
                }
                show_grids();
                exchange = false;
                erase_block(block_row_pre, block_col_pre, block_type_pre);
                update_block(block_row, block_col, block_type);
                block_row_pre = block_row;
                block_changed = false;
            }
            else
            {
                exchange_count = 0;
                show_grids();
                full_line_check();
                if (block_row == 20)
                {

                    end = true;
                    timer1.Enabled = false;
                    timer2.Enabled = false;

                    string filePath = "./scores.json";
                    string json;
                    List<int> scores = new List<int>();
                    if (File.Exists(filePath))
                    {
                        string[] rank = { "1th", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th" };
                        json = File.ReadAllText(filePath);
                        scores = JsonSerializer.Deserialize<List<int>>(json);
                        //讀取 JSON 檔案中的分數紀錄，並將它們反序列化為 List<int>
                        label_info.Visible = true;
                        textBox1.Visible = true;
                        for (int i = 0; i < 20; i++)
                            for (int j = 0; j < 10; j++)
                            {
                                grids[i, j].SendToBack();
                            }
                        textBox1.BringToFront();
                        label_info.BringToFront();
                        label_info.Text = "Game Over! You got " + score.ToString() + "\r\n\r\nPress ENTER to try again";
                        // 在遊戲結束時，將玩家的分數加入 scores 列表中
                        int newScore = Convert.ToInt32(score);
                        
                        if (scores.Count < 10)
                        {
                            scores.Add(newScore); 
                        }
                        else
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (newScore > scores[i])
                                {
                                    scores.Insert(i, newScore);
                                    scores.RemoveAt(10);
                                    textBox1.AppendText("You beat the " + rank[scores.LastIndexOf(newScore)] + "-ranked!!!!!!\r\n");
                                    break;
                                }
                            }
                            if(newScore<=scores.Last())
                                textBox1.AppendText("So Sad :<\r\n");
                        }
                        // 根據分數排序 scores 列表，以便前十名分數最高的玩家排在前面
                        scores = scores.OrderByDescending(s => s).Take(scores.Count).ToList();
                        if (scores.Count != 10)
                        {
                            textBox1.AppendText("you become the" + rank[scores.LastIndexOf(newScore)] + "!!!!!!\r\n");
                        }


                        // 將 scores 列表序列化為 JSON 字串，並將其寫入 scores.json 檔案中
                        json = JsonSerializer.Serialize(scores);
                        File.WriteAllText("scores.json", json);
                        for(int i=0; i<scores.Count;i++)
                        {
                            textBox1.AppendText(rank[i] +":  "+ scores[i]+"\r\n");
                        }
                    }
                    else
                    {
                        scores.Add(Convert.ToInt32(score));
                        json = JsonSerializer.Serialize(scores);
                        File.WriteAllText("scores.json", json);
                    }
                    return;
                };
                block_type = block_type_next;
                block_row = 20;
                block_col = 4;
                block_row_pre = 20;
                block_col_pre = 4;
                block_type_pre = block_type;
                block_changed = false;
                israndon = true;

                ;
            }
        }
        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(timer1.Enabled == true) {
                if (e.KeyCode == Keys.P)//暫停
                {
                    if (game_mode == 0) { game_mode = 1; timer1.Enabled = true; }
                    else { game_mode = 0; timer1.Enabled = false; }
                }

                if (e.KeyCode == Keys.Left)
                {
                    if (x_direction(block_type, block_row, block_col, -1))
                    {
                        block_col_pre = block_col; block_col--;
                        block_changed = true;
                    }
                }

                if (e.KeyCode == Keys.Right)
                {
                    if (x_direction(block_type, block_row, block_col, 1))
                    {
                        block_col_pre = block_col; block_col++;
                        block_changed = true;
                    }
                }

                if (e.KeyCode == Keys.Up)
                {
                    block_type_pre = block_type;
                    block_col_pre = block_col; block_row_pre = block_row;
                    block_type = next_block_type(block_type, block_row, block_col);
                    if (block_type != block_type_pre)
                        block_changed = true;

                }

                if (e.KeyCode == Keys.S)//增加level
                {
                    game_mode = 2;
                    timer_interval -= 50;

                    if (timer_interval <= 0)
                        timer_interval = 1;

                    timer1.Interval = timer_interval;
                    label_level.Text = "Level:" + (1010 - timer_interval) / 50;
                }

                if (e.KeyCode == Keys.A)//減少level
                {
                    game_mode = 2;
                    timer_interval += 50;

                    if (timer_interval >= 1010)
                        timer_interval = 1010;

                    timer1.Interval = timer_interval;
                    label_level.Text = "Level:" + (1010 - timer_interval) / 50;
                }

                if (e.KeyCode == Keys.Space)//方塊直接落到底部
                {
                    if (!end)
                        axWindowsMediaPlayer3.Ctlcontrols.play();
                    else
                    {
                        return;
                    }
                    if (block_row == 20)
                    {
                        timer1_Tick(sender, e);
                    }
                    while (block_row != 20)
                        timer1_Tick(sender, e);
                }
                

                if (e.KeyCode == Keys.Down)
                {
                    timer1.Interval = 40;
                }

                
                if (e.KeyCode == Keys.ShiftKey)
                {
                    store_block();
                }
            }
            if (e.KeyCode == Keys.Escape)//離開遊戲
            {
                if (MessageBox.Show("真的不玩了嗎==？", "離開遊戲", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("哭了 掰掰~ ");
                    Application.Exit();
                }

            }
            if (e.KeyCode == Keys.Enter)//重新開始
            {
                if (end)
                {
                    label_info.Visible = false;
                    textBox1.Visible = false;
                    textBox1.Clear();
                    init_game();
                    timer2.Enabled = true;
                    end = false;
                }

            }
            if (block_changed)
            {
                erase_block(block_row_pre, block_col_pre, block_type_pre);
                update_block(block_row, block_col, block_type);
                show_grids();
                block_row_pre = block_row; block_col_pre = block_col; block_type_pre = block_type;
                block_changed = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        
        void init_game()
        {
            axWindowsMediaPlayer2.Ctlcontrols.stop();
            axWindowsMediaPlayer5.Ctlcontrols.play();
            pictureBox1.Image = imageList2.Images[0];
            timer3.Interval = 1;
            pictureBox1.Visible = true;
            x = 0;
            timer1.Stop();
            timer2.Stop();
            timer3.Start();
            for (uint i = 0; i < 24; i++)
                for (uint j = 0; j < 10; j++)
                    signs[i, j] = false;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    temp[i, j].BackColor = Color.White;
            block_type = (uint)rander.Next(0, 7) + 1;
            block_row = 20;
            block_col = 4;
            block_row_pre = 20;
            block_col_pre = 4;

            block_changed = false;
            timer_interval = 1010;
            timer1.Interval = timer_interval;
            block_count = 0;
            score = 0;
            game_mode = 1;
            block_type_temp=0;
            show_grids();
            groupBox1.SendToBack();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                {
                    temp[i, j].BackColor = Color.White;
                    temp[i, j].Image = null;
                }


        }
        void store_block()
        {
            if(exchange_count == 0)
            {
                erase_block(block_row, block_col, block_type);
                if (block_type_temp == 0)
                {
                    block_type = block_type % 10;
                    exchange_count = 1;
                    block_type_temp = block_type;
                    display_temp_block(block_type_temp);
                    block_type = block_type_next;
                    block_type_next = (uint)rander.Next(0, 7) + 1;
                    display_next_block(block_type_next);
                    block_row = 20;
                    block_col = 4;
                    block_changed = true;
                }
                else
                {
                    exchange_count = 1;
                    exchange = true;
                    block_type = block_type % 10;
                    uint t = block_type_temp;
                    block_type_temp = block_type;
                    block_type = t;
                    display_temp_block(block_type_temp);
                    block_row = 20;
                    block_col = 4;
                    block_changed = true;
                }
            }
        }
        void update_block(uint i, uint j, uint type)//方塊有37種對應哪個case把位置轉成true並塗色
        {
            switch (type)
            {
                case 1:
                    signs[i, j] = signs[i + 1, j] = signs[i + 2, j] = signs[i + 3, j] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i + 2, j] = grids_color[i + 3, j] = Color.Blue;
                    break;
                case 11:
                    signs[i, j] = signs[i, j + 1] = signs[i, j + 2] = signs[i, j + 3] = true;
                    grids_color[i, j] = grids_color[i, j + 1] = grids_color[i, j + 2] = grids_color[i, j + 3] = Color.Blue;
                    break;
                case 2:
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i + 1, j + 1] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i, j + 1] = grids_color[i + 1, j + 1] = Color.Yellow;
                    break;
                case 3:
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i, j + 1] = true;
                    grids_color[i, j] = grids_color[i + 1, j] = grids_color[i + 1, j - 1] = grids_color[i, j + 1] = Color.Red;
                    break;
                case 13:
                    signs[i, j] = signs[i - 1, j] = signs[i, j + 1] = signs[i + 1, j + 1] = true;
                    grids_color[i, j] = grids_color[i - 1, j] = grids_color[i, j + 1] = grids_color[i + 1, j + 1] = Color.Red;
                    break;
                case 4:
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j] = signs[i + 1, j + 1] = true;
                    grids_color[i, j] = grids_color[i, j - 1] = grids_color[i + 1, j] = grids_color[i + 1, j + 1] = Color.Green;
                    break;
                case 14:
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
        void erase_block(uint i, uint j, uint type)
        {
            switch (type)
            {
                case 1:
                    signs[i, j] = signs[i + 1, j] = signs[i + 2, j] = signs[i + 3, j] = false;
                    break;
                case 11:
                    signs[i, j] = signs[i, j + 1] = signs[i, j + 2] = signs[i, j + 3] = false;
                    break;
                case 2:
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i + 1, j + 1] = false;
                    break;
                case 3:
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i, j + 1] = false;
                    break;
                case 13:
                    signs[i, j] = signs[i - 1, j] = signs[i, j + 1] = signs[i + 1, j + 1] = false;
                    break;
                case 4:
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j] = signs[i + 1, j + 1] = false;
                    break;
                case 14:
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i - 1, j + 1] = false;
                    break;
                case 5:
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j + 1] = signs[i + 1, j + 2] = false;
                    break;
                case 15:
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j - 1] = signs[i + 2, j - 1] = false;
                    break;
                case 25:
                    signs[i, j] = signs[i - 1, j] = signs[i - 1, j - 1] = signs[i - 1, j - 2] = false;
                    break;
                case 35:
                    signs[i, j] = signs[i, j + 1] = signs[i - 1, j + 1] = signs[i - 2, j + 1] = false;
                    break;
                case 6:
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i + 1, j - 2] = false;
                    break;
                case 16:
                    signs[i, j] = signs[i, j + 1] = signs[i + 1, j + 1] = signs[i + 2, j + 1] = false;
                    break;
                case 26:
                    signs[i, j] = signs[i - 1, j] = signs[i - 1, j + 1] = signs[i - 1, j + 2] = false;
                    break;
                case 36:
                    signs[i, j] = signs[i, j - 1] = signs[i - 1, j - 1] = signs[i - 2, j - 1] = false;
                    break;
                case 7:
                    signs[i, j] = signs[i, j - 1] = signs[i, j + 1] = signs[i + 1, j] = false;
                    break;
                case 17:
                    signs[i, j] = signs[i, j + 1] = signs[i - 1, j] = signs[i + 1, j] = false;
                    break;
                case 27:
                    signs[i, j] = signs[i, j - 1] = signs[i, j + 1] = signs[i - 1, j] = false;
                    break;
                case 37:
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j] = signs[i - 1, j] = false;
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
                    axWindowsMediaPlayer4.Ctlcontrols.play();
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
                    {
                        if (grids_color[i, j] == Color.Blue)
                        {
                            grids[i, j].Image = imageList1.Images[1];

                        }
                        else if (grids_color[i, j] == Color.Yellow)
                        {
                            grids[i, j].Image = imageList1.Images[5];

                        }
                        else if (grids_color[i, j] == Color.Red)
                        {
                            grids[i, j].Image = imageList1.Images[4];

                        }
                        else if (grids_color[i, j] == Color.LightBlue)
                        {
                            grids[i, j].Image = imageList1.Images[0];

                        }
                        else if (grids_color[i, j] == Color.Purple)
                        {
                            grids[i, j].Image = imageList1.Images[2];

                        }
                        else if (grids_color[i, j] == Color.Green)
                        {
                            grids[i, j].Image = imageList1.Images[6];

                        }
                        else if (grids_color[i, j] == Color.Orange)
                        {
                            grids[i, j].Image = imageList1.Images[3];

                        }
                    }
                    else
                    {
                        grids[i, j].Image = null;
                        grids[i, j].BackColor = Color.Black;
                    }
        }
        void display_next_block(uint type)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                {
                    next[i, j].BackColor = Color.White;
                    next[i, j].Image = null;
                }
            switch (type)
            {
                case 1:
                    next[0, 1].Image = next[1, 1].Image = next[2, 1].Image = next[3, 1].Image = imageList1.Images[1];
                    break;
                case 2:
                    next[1, 0].Image = next[1, 1].Image = next[2, 0].Image = next[2, 1].Image = imageList1.Images[5];
                    break;
                case 3:
                    next[2, 0].Image = next[2, 1].Image = next[1, 1].Image = next[1, 2].Image = imageList1.Images[4];
                    break;
                case 4:
                    next[1, 0].Image = next[1, 1].Image = next[2, 1].Image = next[2, 2].Image = imageList1.Images[6];
                    break;
                case 5:
                    next[1, 0].Image = next[2, 0].Image = next[2, 1].Image = next[2, 2].Image = imageList1.Images[3];
                    break;
                case 6:
                    next[2, 0].Image = next[2, 1].Image = next[2, 2].Image = next[1, 2].Image = imageList1.Images[0];
                    break;
                case 7:
                    next[1, 0].Image = next[1, 1].Image = next[1, 2].Image = next[2, 1].Image = imageList1.Images[2];
                    break;
            }
        }
        void display_temp_block(uint type)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                {
                    temp[i, j].BackColor = Color.White;
                    temp[i, j].Image = null;
                }
            switch (type)
            {
                case 1:
                    temp[0, 1].Image = temp[1, 1].Image = temp[2, 1].Image = temp[3, 1].Image = imageList1.Images[1];
                    break;
                case 2:
                    temp[1, 0].Image = temp[1, 1].Image = temp[2, 0].Image = temp[2, 1].Image = imageList1.Images[5];
                    break;
                case 3:
                    temp[2, 0].Image = temp[2, 1].Image = temp[1, 1].Image = temp[1, 2].Image = imageList1.Images[4];
                    break;
                case 4:
                    temp[1, 0].Image = temp[1, 1].Image = temp[2, 1].Image = temp[2, 2].Image = imageList1.Images[6];
                    break;
                case 5:
                    temp[1, 0].Image = temp[2, 0].Image = temp[2, 1].Image = temp[2, 2].Image = imageList1.Images[3];
                    break;
                case 6:
                    temp[2, 0].Image = temp[2, 1].Image = temp[2, 2].Image = temp[1, 2].Image = imageList1.Images[0];
                    break;
                case 7:
                    temp[1, 0].Image = temp[1, 1].Image = temp[1, 2].Image = temp[2, 1].Image = imageList1.Images[2];
                    break;
            }
        }
        uint next_block_type(uint type, uint i, uint j)//旋轉
        {
            switch (type)
            {
                case 1:
                    if (j <= 7 && j >= 1 && !signs[i + 2, j - 1] && !signs[i + 2, j + 1] && !signs[i + 2, j + 2])
                    {
                        block_row = i + 2; block_col = j - 1;
                        return 11;
                    }
                    else return 1;

                case 11:
                    if (i >= 2 && !signs[i - 1, j + 1] && !signs[i - 2, j + 1] && !signs[i + 1, j + 1])
                    {
                        block_row = i - 2; block_col = j + 1;
                        return 1;
                    }
                    else return 11;

                case 2: return 2;

                case 3:
                    if (i >= 1 && !signs[i + 1, j + 1] && !signs[i - 1, j])
                        return 13;
                    else return 3;

                case 13:
                    if (j >= 1 && !signs[i + 1, j] && !signs[i + 1, j - 1])
                        return 3;
                    else return 13;

                case 4:
                    if (i >= 1 && !signs[i, j + 1] && !signs[i - 1, j + 1])
                        return 14;
                    else return 4;

                case 14:
                    if (j >= 1 && !signs[i, j - 1] && !signs[i + 1, j + 1])
                        return 4;
                    else return 14;

                case 5:
                    if (!signs[i + 2, j] && !signs[i, j + 1])
                    {
                        block_col = j + 1;
                        return 15;
                    }
                    else return 5;

                case 15:
                    if (j >= 2 && !signs[i, j - 2] && !signs[i + 1, j])
                    {
                        block_row = i + 1;
                        return 25;
                    }
                    else return 15;

                case 25:
                    if (i >= 2 && !signs[i, j - 1] && !signs[i - 2, j])
                    {
                        block_col = j - 1;
                        return 35;
                    }
                    else return 25;

                case 35:
                    if (j <= 7 && !signs[i - 1, j] && !signs[i, j + 2])
                    {
                        block_row = i - 1;
                        return 5;
                    }
                    else return 35;

                case 6:
                    if (!signs[i, j - 1] && !signs[i + 2, j])
                    {
                        block_col = j - 1;
                        return 16;
                    }
                    else return 6;

                case 16:
                    if (j <= 7 && !signs[i - 1, j] && !signs[i, j + 2])
                    {
                        block_row = i + 1;
                        return 26;
                    }
                    else return 16;

                case 26:
                    if (i >= 2 && !signs[i, j + 1] && !signs[i - 2, j])
                    {
                        block_col = j + 1;
                        return 36;
                    }
                    else return 26;

                case 36:
                    if (j >= 2 && !signs[i, j - 2] && !signs[i - 1, j])
                    {
                        block_row = i - 1;
                        return 6;
                    }
                    else return 36;

                case 7:
                    if (i >= 1 && !signs[i - 1, j])
                        return 17;
                    else return 7;

                case 17:
                    if (j >= 1 && !signs[i, j - 1])
                        return 27;
                    else return 17;

                case 27:
                    if (!signs[i + 1, j])
                        return 37;
                    else return 27;

                case 37:
                    if (j <= 8 && !signs[i, j + 1])
                        return 7;
                    else return 37;

                default: return 0;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                timer1.Interval = timer_interval;
            }
        }
        void update_shade_block(uint i, uint j, uint type)
        {
            while(y_direction(type,i,j))
            {
                i--;
            }

            switch (type)
            {
                case 1:
                    shade[i,j] = shade[i + 1, j] = shade[i + 2, j] = shade[i + 3, j] = true;
                    break;
                case 11:
                    shade[i, j] = shade[i, j + 1] = shade[i, j + 2] = shade[i, j + 3] = true;
                    break;
                case 2:
                    shade[i, j] = shade[i + 1, j] = shade[i, j + 1] = shade[i + 1, j + 1] = true;
                    break;
                case 3:
                    shade[i, j] = shade[i + 1, j] = shade[i + 1, j - 1] = shade[i, j + 1] = true;
                    break;
                case 13:
                    shade[i, j] = shade[i - 1, j] = shade[i, j + 1] = shade[i + 1, j + 1] = true;
                    break;
                case 4:
                    shade[i, j] = shade[i, j - 1] = shade[i + 1, j] = shade[i + 1, j + 1] = true;
                    break;
                case 14:
                    shade[i, j] = shade[i + 1, j] = shade[i, j + 1] = shade[i - 1, j + 1] = true;
                    break;
                case 5:
                    shade[i, j] = shade[i + 1, j] = shade[i + 1, j + 1] = shade[i + 1, j + 2] = true;
                    break;
                case 15:
                    shade[i, j] = shade[i, j - 1] = shade[i + 1, j - 1] = shade[i + 2, j - 1] = true;
                    break;
                case 25:
                    shade[i, j] = shade[i - 1, j] = shade[i - 1, j - 1] = shade[i - 1, j - 2] = true;
                    break;
                case 35:
                    shade[i, j] = shade[i, j + 1] = shade[i - 1, j + 1] = shade[i - 2, j + 1] = true;
                    break;
                case 6:
                    shade[i, j] = shade[i + 1, j] = shade[i + 1, j - 1] = shade[i + 1, j - 2] = true;
                    break;
                case 16:
                    shade[i, j] = shade[i, j + 1] = shade[i + 1, j + 1] = shade[i + 2, j + 1] = true;
                    break;
                case 26:
                    shade[i, j] = shade[i - 1, j] = shade[i - 1, j + 1] = shade[i - 1, j + 2] = true;
                    break;
                case 36:
                    shade[i, j] = shade[i, j - 1] = shade[i - 1, j - 1] = shade[i - 2, j - 1] = true;
                    break;

                case 7:
                    shade[i, j] = shade[i, j - 1] = shade[i, j + 1] = shade[i + 1, j] = true;
                    break;
                case 17:
                    shade[i, j] = shade[i, j + 1] = shade[i - 1, j] = shade[i + 1, j] = true;
                    break;
                case 27:
                    shade[i, j] = shade[i, j - 1] = shade[i, j + 1] = shade[i - 1, j] = true;
                    break;
                case 37:
                    shade[i, j] = shade[i, j - 1] = shade[i + 1, j] = shade[i - 1, j] = true;
                    break;
            }
        }
        void show_shade_grids()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (shade[i, j]&&!signs[i,j])
                    {
                        grids[i, j].BackColor = grayColor;
                    }
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            update_shade_block(block_row, block_col, block_type);
            show_shade_grids();
            for (int i=0;i<20;i++)
            {
                for(int j=0;j<10;j++)
                {
                    shade[i, j] = false;
                }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 900;
            pictureBox1.BringToFront();
            pictureBox1.Visible = true;
            if (x<4)
            pictureBox1.Image = imageList2.Images[x];
            x++;
            if(x==5)
            {
                timer1.Start();
                timer2.Start();
                timer3.Stop();
                pictureBox1.Visible = false;
                axWindowsMediaPlayer2.Visible = false;
                axWindowsMediaPlayer2.URL = "QQ.mp3";
                axWindowsMediaPlayer2.settings.setMode("loop", true);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
