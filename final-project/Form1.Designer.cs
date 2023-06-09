namespace final_project
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_block_count = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.label_level = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.axWindowsMediaPlayer4 = new AxWMPLib.AxWindowsMediaPlayer();
            this.axWindowsMediaPlayer3 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1010;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_block_count
            // 
            this.label_block_count.AutoSize = true;
            this.label_block_count.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_block_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_block_count.Location = new System.Drawing.Point(670, 246);
            this.label_block_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_block_count.Name = "label_block_count";
            this.label_block_count.Size = new System.Drawing.Size(46, 15);
            this.label_block_count.TabIndex = 0;
            this.label_block_count.Text = "Blocks:";
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_score.Location = new System.Drawing.Point(670, 297);
            this.label_score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(42, 15);
            this.label_score.TabIndex = 1;
            this.label_score.Text = "Score:";
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_level.Location = new System.Drawing.Point(670, 346);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(39, 15);
            this.label_level.TabIndex = 218;
            this.label_level.Text = "Level:";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.SystemColors.WindowText;
            this.label_info.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_info.ForeColor = System.Drawing.Color.Red;
            this.label_info.Location = new System.Drawing.Point(626, 168);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(0, 27);
            this.label_info.TabIndex = 219;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(664, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 221;
            this.label1.Text = "NEXT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(164, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 222;
            this.label2.Text = "HOLD";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label_block_count);
            this.groupBox1.Controls.Add(this.label_score);
            this.groupBox1.Controls.Add(this.label_level);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.axWindowsMediaPlayer2);
            this.groupBox1.Controls.Add(this.axWindowsMediaPlayer1);
            this.groupBox1.Enabled = false;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(320, -48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(924, 765);
            this.groupBox1.TabIndex = 223;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(695, 445);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 200);
            this.pictureBox1.TabIndex = 227;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(298, 297);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 405);
            this.textBox1.TabIndex = 226;
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(3, 21);
            this.axWindowsMediaPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer2.TabIndex = 1;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(-530, -500);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(2000, 2000);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blue.png");
            this.imageList1.Images.SetKeyName(1, "light_blue.png");
            this.imageList1.Images.SetKeyName(2, "purple.png");
            this.imageList1.Images.SetKeyName(3, "orange.png");
            this.imageList1.Images.SetKeyName(4, "red.png");
            this.imageList1.Images.SetKeyName(5, "yellow.png");
            this.imageList1.Images.SetKeyName(6, "green.png");
            // 
            // axWindowsMediaPlayer4
            // 
            this.axWindowsMediaPlayer4.Enabled = true;
            this.axWindowsMediaPlayer4.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer4.Margin = new System.Windows.Forms.Padding(2);
            this.axWindowsMediaPlayer4.Name = "axWindowsMediaPlayer4";
            this.axWindowsMediaPlayer4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer4.OcxState")));
            this.axWindowsMediaPlayer4.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer4.TabIndex = 225;
            // 
            // axWindowsMediaPlayer3
            // 
            this.axWindowsMediaPlayer3.Enabled = true;
            this.axWindowsMediaPlayer3.Location = new System.Drawing.Point(143, 332);
            this.axWindowsMediaPlayer3.Margin = new System.Windows.Forms.Padding(2);
            this.axWindowsMediaPlayer3.Name = "axWindowsMediaPlayer3";
            this.axWindowsMediaPlayer3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer3.OcxState")));
            this.axWindowsMediaPlayer3.Size = new System.Drawing.Size(118, 46);
            this.axWindowsMediaPlayer3.TabIndex = 224;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 500;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "螢幕擷取畫面 2023-06-09 223514.png");
            this.imageList2.Images.SetKeyName(1, "螢幕擷取畫面 2023-06-09 223700 - 複製 (2).png");
            this.imageList2.Images.SetKeyName(2, "螢幕擷取畫面 2023-06-09 223610.png");
            this.imageList2.Images.SetKeyName(3, "螢幕擷取畫面 2023-06-09 223700.png");
            this.imageList2.Images.SetKeyName(4, "螢幕擷取畫面 2023-06-09 223631.png");
            this.imageList2.Images.SetKeyName(5, "螢幕擷取畫面 2023-06-09 223700 - 複製.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1377, 808);
            this.Controls.Add(this.axWindowsMediaPlayer4);
            this.Controls.Add(this.axWindowsMediaPlayer3);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "好玩遊戲";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_block_count;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private System.Windows.Forms.ImageList imageList1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer3;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

