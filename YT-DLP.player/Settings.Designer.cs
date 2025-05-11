namespace YT_DLP.player
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            SaveButton = new YT_DLP.player.controls.DLPButtonHighlighted();
            DiscardButton = new YT_DLP.player.controls.DLPButton();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
            label4 = new Label();
            DownloadSubtitlesCB = new CheckBox();
            AutoplayCB = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            URLTextBox = new TextBox();
            DeleteOnCloseCB = new CheckBox();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 30);
            label1.TabIndex = 1;
            label1.Text = "Settings";
            label1.Click += label1_Click;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.BackColor = Color.FromArgb(240, 0, 54);
            SaveButton.FlatAppearance.BorderColor = Color.FromArgb(250, 0, 60);
            SaveButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(115, 0, 26);
            SaveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 0, 40);
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.Font = new Font("Segoe UI", 9F);
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(338, 324);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(90, 32);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "&Save";
            SaveButton.UseVisualStyleBackColor = false;
            // 
            // DiscardButton
            // 
            DiscardButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DiscardButton.BackColor = Color.FromArgb(64, 64, 64);
            DiscardButton.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            DiscardButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            DiscardButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            DiscardButton.FlatStyle = FlatStyle.Flat;
            DiscardButton.Font = new Font("Segoe UI", 9F);
            DiscardButton.ForeColor = Color.White;
            DiscardButton.Location = new Point(216, 324);
            DiscardButton.Name = "DiscardButton";
            DiscardButton.Size = new Size(116, 32);
            DiscardButton.TabIndex = 4;
            DiscardButton.Text = "&Discard changes";
            DiscardButton.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.ForeColor = Color.FromArgb(255, 255, 254);
            groupBox2.Location = new Point(223, 42);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(205, 269);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Video and Audio";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(DownloadSubtitlesCB);
            groupBox3.Controls.Add(AutoplayCB);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(URLTextBox);
            groupBox3.Controls.Add(DeleteOnCloseCB);
            groupBox3.ForeColor = Color.FromArgb(255, 255, 254);
            groupBox3.Location = new Point(12, 42);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(205, 269);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Download Behaviour";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(26, 26, 26);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(100, 138);
            textBox1.MaxLength = 3;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(38, 23);
            textBox1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 140);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 7;
            label4.Text = "Default Volume";
            // 
            // DownloadSubtitlesCB
            // 
            DownloadSubtitlesCB.AutoSize = true;
            DownloadSubtitlesCB.Location = new Point(6, 60);
            DownloadSubtitlesCB.Margin = new Padding(3, 0, 3, 0);
            DownloadSubtitlesCB.Name = "DownloadSubtitlesCB";
            DownloadSubtitlesCB.Size = new Size(128, 19);
            DownloadSubtitlesCB.TabIndex = 6;
            DownloadSubtitlesCB.Text = "Download Subtitles";
            DownloadSubtitlesCB.UseVisualStyleBackColor = true;
            // 
            // AutoplayCB
            // 
            AutoplayCB.AutoSize = true;
            AutoplayCB.Location = new Point(6, 41);
            AutoplayCB.Margin = new Padding(3, 0, 3, 0);
            AutoplayCB.Name = "AutoplayCB";
            AutoplayCB.Size = new Size(157, 19);
            AutoplayCB.TabIndex = 5;
            AutoplayCB.Text = "Autoplay after download";
            AutoplayCB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(224, 224, 224);
            label3.Location = new Point(6, 120);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 4;
            label3.Text = "Leave blank for default";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 79);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 3;
            label2.Text = "Download Location";
            // 
            // URLTextBox
            // 
            URLTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            URLTextBox.BackColor = Color.FromArgb(26, 26, 26);
            URLTextBox.BorderStyle = BorderStyle.FixedSingle;
            URLTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            URLTextBox.ForeColor = Color.White;
            URLTextBox.Location = new Point(6, 97);
            URLTextBox.Name = "URLTextBox";
            URLTextBox.Size = new Size(193, 23);
            URLTextBox.TabIndex = 2;
            // 
            // DeleteOnCloseCB
            // 
            DeleteOnCloseCB.AutoSize = true;
            DeleteOnCloseCB.Location = new Point(6, 22);
            DeleteOnCloseCB.Margin = new Padding(3, 0, 3, 0);
            DeleteOnCloseCB.Name = "DeleteOnCloseCB";
            DeleteOnCloseCB.Size = new Size(106, 19);
            DeleteOnCloseCB.TabIndex = 0;
            DeleteOnCloseCB.Text = "Delete on close";
            DeleteOnCloseCB.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            CancelButton = DiscardButton;
            ClientSize = new Size(440, 368);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(DiscardButton);
            Controls.Add(SaveButton);
            Controls.Add(label1);
            ForeColor = Color.White;
            Name = "Settings";
            Text = "YT-DLP Player - Settings";
            Load += Settings_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        private controls.DLPButtonHighlighted SaveButton;
        private controls.DLPButton DiscardButton;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private CheckBox DeleteOnCloseCB;
        private Label label3;
        private Label label2;
        private TextBox URLTextBox;
        private TextBox textBox1;
        private Label label4;
        private CheckBox DownloadSubtitlesCB;
        private CheckBox AutoplayCB;
    }
}