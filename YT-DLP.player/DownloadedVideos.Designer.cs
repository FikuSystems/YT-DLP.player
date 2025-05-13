namespace YT_DLP.player
{
    partial class DownloadedVideos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            VideoTitleLabel = new Label();
            VideoURLLabel = new Label();
            TimeLabel = new Label();
            WatchNowButton = new YT_DLP.player.controls.DLPButtonHighlighted();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // VideoTitleLabel
            // 
            VideoTitleLabel.AutoEllipsis = true;
            VideoTitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VideoTitleLabel.Location = new Point(114, 3);
            VideoTitleLabel.Name = "VideoTitleLabel";
            VideoTitleLabel.Size = new Size(327, 23);
            VideoTitleLabel.TabIndex = 2;
            VideoTitleLabel.Text = "%Video Title%";
            // 
            // VideoURLLabel
            // 
            VideoURLLabel.AutoEllipsis = true;
            VideoURLLabel.Location = new Point(114, 26);
            VideoURLLabel.Name = "VideoURLLabel";
            VideoURLLabel.Size = new Size(327, 22);
            VideoURLLabel.TabIndex = 3;
            VideoURLLabel.Text = "%video url%";
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.BackColor = Color.Black;
            TimeLabel.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimeLabel.Location = new Point(6, 66);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(63, 14);
            TimeLabel.TabIndex = 4;
            TimeLabel.Text = "00:00:00";
            // 
            // WatchNowButton
            // 
            WatchNowButton.BackColor = Color.FromArgb(240, 0, 54);
            WatchNowButton.FlatAppearance.BorderColor = Color.FromArgb(250, 0, 60);
            WatchNowButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(115, 0, 26);
            WatchNowButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 0, 40);
            WatchNowButton.FlatStyle = FlatStyle.Flat;
            WatchNowButton.Font = new Font("Segoe UI", 9F);
            WatchNowButton.ForeColor = Color.White;
            WatchNowButton.Location = new Point(351, 51);
            WatchNowButton.Name = "WatchNowButton";
            WatchNowButton.Size = new Size(90, 32);
            WatchNowButton.TabIndex = 6;
            WatchNowButton.Text = "Watch Now";
            WatchNowButton.UseVisualStyleBackColor = false;
            // 
            // DownloadedVideos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(WatchNowButton);
            Controls.Add(TimeLabel);
            Controls.Add(VideoURLLabel);
            Controls.Add(VideoTitleLabel);
            Controls.Add(pictureBox1);
            ForeColor = Color.White;
            Name = "DownloadedVideos";
            Size = new Size(444, 86);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public PictureBox pictureBox1;
        public Label VideoTitleLabel;
        public Label VideoURLLabel;
        public Label TimeLabel;
        public controls.DLPButtonHighlighted WatchNowButton;
    }
}
