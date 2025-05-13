namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtGameDir = new TextBox();
            btnBrowse = new Button();
            btnInstall = new Button();
            lblStatus = new Label();
            progressBar1 = new ProgressBar();
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            checkBox4 = new CheckBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            checkBox5 = new CheckBox();
            comboBox3 = new ComboBox();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            linkLabel5 = new LinkLabel();
            label1 = new Label();
            checkBox6 = new CheckBox();
            comboBox4 = new ComboBox();
            label6 = new Label();
            comboBox5 = new ComboBox();
            pictureBox6 = new PictureBox();
            label8 = new Label();
            pictureBox7 = new PictureBox();
            label9 = new Label();
            pictureBox8 = new PictureBox();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // txtGameDir
            // 
            txtGameDir.Location = new Point(12, 258);
            txtGameDir.Name = "txtGameDir";
            txtGameDir.Size = new Size(430, 23);
            txtGameDir.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(448, 245);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 47);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Select AT Folder";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnInstall
            // 
            btnInstall.Location = new Point(448, 295);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(75, 23);
            btnInstall.TabIndex = 2;
            btnInstall.Text = "Install";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Click += btnInstall_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = SystemColors.ActiveBorder;
            lblStatus.ForeColor = SystemColors.ActiveCaptionText;
            lblStatus.Location = new Point(12, 232);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(270, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Idle";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(11, 295);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(430, 23);
            progressBar1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.ImageLocation = "https://shared.cloudflare.steamstatic.com/store_item_assets/steam/apps/331920/ss_c0aa0007b659ef061fde00bad97502ede46e80a3.600x338.jpg?t=1732706159";
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(270, 240);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(449, 208);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(75, 15);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Terms of Use";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(454, 226);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(63, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "I Agree";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(452, 160);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(76, 19);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "cnc-draw";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(452, 133);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(58, 19);
            checkBox3.TabIndex = 10;
            checkBox3.Text = "atd fix";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(500, 5);
            button1.Name = "button1";
            button1.Size = new Size(28, 32);
            button1.TabIndex = 12;
            button1.Text = "🕪";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(432, 5);
            button2.Name = "button2";
            button2.Size = new Size(28, 32);
            button2.TabIndex = 13;
            button2.Text = "🌙";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(466, 5);
            button3.Name = "button3";
            button3.Size = new Size(28, 32);
            button3.TabIndex = 14;
            button3.Text = "🎮";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Location = new Point(452, 66);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(78, 19);
            checkBox4.TabIndex = 16;
            checkBox4.Text = "Config V6";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "v1.2H3", "v1.6.2P", "v1.7.2-preview", "v1.8.0-preview" });
            comboBox1.Location = new Point(389, 131);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(61, 23);
            comboBox1.TabIndex = 17;
            comboBox1.Tag = "";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "v7.1.0.0", "experimental" });
            comboBox2.Location = new Point(389, 158);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(61, 23);
            comboBox2.TabIndex = 18;
            comboBox2.Tag = "";
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Checked = true;
            checkBox5.CheckState = CheckState.Checked;
            checkBox5.Location = new Point(452, 106);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(65, 19);
            checkBox5.TabIndex = 19;
            checkBox5.Text = "PL DUB";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "airline tycoon", "evolution" });
            comboBox3.Location = new Point(389, 104);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(61, 23);
            comboBox3.TabIndex = 20;
            comboBox3.Tag = "";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(366, 106);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(22, 15);
            linkLabel2.TabIndex = 23;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Lili";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(307, 134);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(81, 15);
            linkLabel3.TabIndex = 24;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "WizzardMaker";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new Point(316, 160);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(67, 15);
            linkLabel4.TabIndex = 25;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "FunkyFr3sh";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.ImageLocation = "https://avatars.githubusercontent.com/u/7768485?v=4";
            pictureBox2.Location = new Point(286, 129);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 29;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources._06539c5370d3fedac1cc7d969f8836c3;
            pictureBox3.ImageLocation = "";
            pictureBox3.Location = new Point(345, 103);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 30;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.ImageLocation = "https://avatars.githubusercontent.com/u/8355237?v=4";
            pictureBox4.Location = new Point(295, 157);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(24, 24);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 31;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.ImageLocation = "https://avatars.githubusercontent.com/u/128807992?v=4";
            pictureBox5.Location = new Point(321, 40);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(24, 24);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 32;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new Point(342, 45);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(147, 15);
            linkLabel5.TabIndex = 33;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "Patcher Made by Leds7777";
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(363, 210);
            label1.Name = "label1";
            label1.Size = new Size(87, 32);
            label1.TabIndex = 34;
            label1.Text = "v1.1 12/05/2025";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Checked = true;
            checkBox6.CheckState = CheckState.Checked;
            checkBox6.Location = new Point(452, 85);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(66, 19);
            checkBox6.TabIndex = 35;
            checkBox6.Text = "Data V6";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "normal", "hard", "hardcore" });
            comboBox4.Location = new Point(389, 185);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(61, 23);
            comboBox4.TabIndex = 36;
            comboBox4.Tag = "";
            // 
            // label6
            // 
            label6.Location = new Point(333, 188);
            label6.Name = "label6";
            label6.Size = new Size(74, 24);
            label6.TabIndex = 37;
            label6.Text = "Difficulty:";
            // 
            // comboBox5
            // 
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.Font = new Font("Segoe UI Emoji", 10F);
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "🇺🇸", "🇬🇧", "🇵🇱", "🇩🇪" });
            comboBox5.Location = new Point(389, 73);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(61, 25);
            comboBox5.TabIndex = 38;
            comboBox5.Tag = "";
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.ImageLocation = "";
            pictureBox6.Location = new Point(12, 179);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(24, 24);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 41;
            pictureBox6.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 182);
            label8.Name = "label8";
            label8.Size = new Size(138, 15);
            label8.TabIndex = 42;
            label8.Text = "Hephaestus6059 - Planes";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.ImageLocation = "";
            pictureBox7.Location = new Point(12, 205);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(24, 24);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 43;
            pictureBox7.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(33, 208);
            label9.Name = "label9";
            label9.Size = new Size(214, 15);
            label9.TabIndex = 44;
            label9.Text = "Flat_Eric1983 - Cities, Routes and Builds";
            // 
            // pictureBox8
            // 
            pictureBox8.ImageLocation = "https://airline-tycoon.com/images/avatars/gallery/airline%20tycoon/avax26.jpg";
            pictureBox8.Location = new Point(12, 153);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(24, 24);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 45;
            pictureBox8.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 156);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 46;
            label2.Text = "Fisico9798 - Planes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(11, 12);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 27;
            label4.Text = "Open-source";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(116, 12);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 28;
            label5.Text = "7.1.0.0 - EXP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(214, 12);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 26;
            label3.Text = "v1.2-1.8 HD";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(329, 78);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 47;
            label7.Text = "Language:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 330);
            Controls.Add(linkLabel5);
            Controls.Add(pictureBox6);
            Controls.Add(label8);
            Controls.Add(pictureBox8);
            Controls.Add(label2);
            Controls.Add(pictureBox7);
            Controls.Add(label9);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(checkBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(linkLabel4);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel2);
            Controls.Add(comboBox3);
            Controls.Add(checkBox5);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(checkBox4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(linkLabel1);
            Controls.Add(lblStatus);
            Controls.Add(pictureBox1);
            Controls.Add(progressBar1);
            Controls.Add(btnInstall);
            Controls.Add(btnBrowse);
            Controls.Add(txtGameDir);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label7);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(548, 369);
            MinimumSize = new Size(548, 369);
            Name = "Form1";
            Text = "Airlines Tycoon Evolution HD Patcher";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGameDir;
        private Button btnBrowse;
        private Button btnInstall;
        private Label lblStatus;
        private ProgressBar progressBar1;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private CheckBox checkBox4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private CheckBox checkBox5;
        private ComboBox comboBox3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private LinkLabel linkLabel5;
        private Label label1;
        private CheckBox checkBox6;
        private ComboBox comboBox4;
        private Label label6;
        private ComboBox comboBox5;
        private PictureBox pictureBox6;
        private Label label8;
        private PictureBox pictureBox7;
        private Label label9;
        private PictureBox pictureBox8;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label label7;
    }
}
