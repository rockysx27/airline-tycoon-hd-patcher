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
            label2 = new Label();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            linkLabel5 = new LinkLabel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
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
            btnBrowse.Location = new Point(447, 245);
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
            lblStatus.Size = new Size(284, 20);
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
            pictureBox1.Size = new Size(284, 240);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(447, 202);
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
            checkBox1.Location = new Point(452, 220);
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
            checkBox2.Location = new Point(446, 166);
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
            checkBox3.Location = new Point(446, 139);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(58, 19);
            checkBox3.TabIndex = 10;
            checkBox3.Text = "atd fix";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(500, 12);
            button1.Name = "button1";
            button1.Size = new Size(28, 32);
            button1.TabIndex = 12;
            button1.Text = "🕪";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(432, 12);
            button2.Name = "button2";
            button2.Size = new Size(28, 32);
            button2.TabIndex = 13;
            button2.Text = "🌙";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(466, 12);
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
            checkBox4.Location = new Point(446, 90);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(78, 19);
            checkBox4.TabIndex = 16;
            checkBox4.Text = "V6 Config";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "v1.2H3", "v1.6.2P", "v1.7.2-preview", "v1.8.0-preview" });
            comboBox1.Location = new Point(383, 137);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(61, 23);
            comboBox1.TabIndex = 17;
            comboBox1.Tag = "";
            comboBox1.SelectedItem = "v1.8.0-preview";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "v7.1.0.0", "experimental" });
            comboBox2.Location = new Point(383, 164);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(61, 23);
            comboBox2.TabIndex = 18;
            comboBox2.Tag = "";
            comboBox2.SelectedItem = "experimental";
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Checked = true;
            checkBox5.CheckState = CheckState.Checked;
            checkBox5.Location = new Point(446, 112);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(91, 19);
            checkBox5.TabIndex = 19;
            checkBox5.Text = "spolszczenie";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "airline tycoon", "evolution" });
            comboBox3.Location = new Point(383, 110);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(61, 23);
            comboBox3.TabIndex = 20;
            comboBox3.Tag = "";
            comboBox3.SelectedItem = "evolution";
            // 
            // label2
            // 
            label2.Location = new Point(303, 51);
            label2.Name = "label2";
            label2.Size = new Size(87, 48);
            label2.TabIndex = 22;
            label2.Text = "Please, thank the creators of the mods:";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(362, 113);
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
            linkLabel3.Location = new Point(303, 139);
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
            linkLabel4.Location = new Point(317, 167);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(67, 15);
            linkLabel4.TabIndex = 25;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "FunkyFr3sh";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(228, 9);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 26;
            label3.Text = "v1.2-1.8 HD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(11, 9);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 27;
            label4.Text = "Open-source";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(123, 9);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 28;
            label5.Text = "7.1.0.0 - EXP";
            // 
            // pictureBox2
            // 
            pictureBox2.ImageLocation = "https://avatars.githubusercontent.com/u/7768485?v=4";
            pictureBox2.Location = new Point(282, 134);
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
            pictureBox3.Location = new Point(341, 110);
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
            pictureBox4.Location = new Point(296, 163);
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
            pictureBox5.Location = new Point(396, 55);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(24, 24);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 32;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // linkLabel5
            // 
            linkLabel5.Location = new Point(421, 51);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(97, 32);
            linkLabel5.TabIndex = 33;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "Patcher Made by Leds7777";
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(361, 204);
            label1.Name = "label1";
            label1.Size = new Size(87, 32);
            label1.TabIndex = 34;
            label1.Text = "v1.1 12/05/2025";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 330);
            Controls.Add(label1);
            Controls.Add(linkLabel5);
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
            Controls.Add(label2);
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
        private Label label2;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private LinkLabel linkLabel5;
        private Label label1;
    }
}
