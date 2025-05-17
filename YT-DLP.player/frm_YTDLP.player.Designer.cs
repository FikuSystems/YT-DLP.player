using YT_DLP.player.controls;

namespace YT_DLP.player
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
            components = new System.ComponentModel.Container();
            TopPanel = new Panel();
            DownloadQueue = new DLPButton();
            FindVideoButton = new DLPButtonHighlighted();
            SettingsButton = new Button();
            panel2 = new Panel();
            URLTextBox = new TextBox();
            label1 = new Label();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            BodyPanel = new Panel();
            PlayerPanel = new Panel();
            RecentVideosFlow = new FlowLayoutPanel();
            PlayerControlsPanel = new Panel();
            VolumeLabel = new Label();
            VolumeTrackBar = new TrackBar();
            TotalTimeLabel = new Label();
            CurrentTimeLabel = new Label();
            SeekTrackBar = new TrackBar();
            StopPlayBackButton = new DLPButton();
            PlayPauseButton = new DLPButtonHighlighted();
            dlpButton2 = new DLPButton();
            VideoTitleLabel = new Label();
            TimeTrackTimer = new System.Windows.Forms.Timer(components);
            ControlPanel = new Panel();
            dlpButton1 = new DLPButton();
            FullScreenControlHide = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            button1 = new Button();
            TopPanel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            BodyPanel.SuspendLayout();
            PlayerPanel.SuspendLayout();
            PlayerControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SeekTrackBar).BeginInit();
            ControlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(DownloadQueue);
            TopPanel.Controls.Add(FindVideoButton);
            TopPanel.Controls.Add(SettingsButton);
            TopPanel.Controls.Add(panel2);
            TopPanel.Controls.Add(label1);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1068, 63);
            TopPanel.TabIndex = 1;
            TopPanel.Paint += TopPanel_Paint;
            // 
            // DownloadQueue
            // 
            DownloadQueue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DownloadQueue.BackColor = Color.FromArgb(64, 64, 64);
            DownloadQueue.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            DownloadQueue.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            DownloadQueue.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            DownloadQueue.FlatStyle = FlatStyle.Flat;
            DownloadQueue.Font = new Font("Segoe UI", 9F);
            DownloadQueue.ForeColor = Color.White;
            DownloadQueue.Location = new Point(741, 15);
            DownloadQueue.Name = "DownloadQueue";
            DownloadQueue.Size = new Size(53, 32);
            DownloadQueue.TabIndex = 5;
            DownloadQueue.Text = "Queue";
            DownloadQueue.UseVisualStyleBackColor = false;
            DownloadQueue.Click += DownloadQueue_Click;
            // 
            // FindVideoButton
            // 
            FindVideoButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FindVideoButton.BackColor = Color.FromArgb(240, 0, 54);
            FindVideoButton.FlatAppearance.BorderColor = Color.FromArgb(250, 0, 60);
            FindVideoButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(115, 0, 26);
            FindVideoButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 0, 40);
            FindVideoButton.FlatStyle = FlatStyle.Flat;
            FindVideoButton.Font = new Font("Segoe UI", 9F);
            FindVideoButton.ForeColor = Color.White;
            FindVideoButton.Location = new Point(699, 15);
            FindVideoButton.Name = "FindVideoButton";
            FindVideoButton.Size = new Size(41, 32);
            FindVideoButton.TabIndex = 3;
            FindVideoButton.Text = "Play";
            FindVideoButton.UseVisualStyleBackColor = false;
            FindVideoButton.Click += FindVideoButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SettingsButton.BackColor = Color.FromArgb(64, 64, 64);
            SettingsButton.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            SettingsButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            SettingsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            SettingsButton.FlatStyle = FlatStyle.Flat;
            SettingsButton.Location = new Point(984, 15);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(70, 32);
            SettingsButton.TabIndex = 4;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = false;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(URLTextBox);
            panel2.Location = new Point(329, 15);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(1);
            panel2.Size = new Size(369, 32);
            panel2.TabIndex = 2;
            // 
            // URLTextBox
            // 
            URLTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            URLTextBox.BackColor = Color.FromArgb(26, 26, 26);
            URLTextBox.BorderStyle = BorderStyle.None;
            URLTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            URLTextBox.ForeColor = Color.White;
            URLTextBox.Location = new Point(2, 5);
            URLTextBox.Name = "URLTextBox";
            URLTextBox.Size = new Size(318, 20);
            URLTextBox.TabIndex = 1;
            URLTextBox.Text = "https://www.youtube.com/watch?v=Zgq3yZDhuxM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(168, 32);
            label1.TabIndex = 0;
            label1.Text = "YT-DLP Player";
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Dock = DockStyle.Fill;
            videoView1.Location = new Point(0, 0);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(1068, 332);
            videoView1.TabIndex = 2;
            videoView1.Text = "videoView1";
            videoView1.MouseLeave += videoView1_MouseLeave;
            videoView1.MouseMove += videoView1_MouseMove;
            // 
            // BodyPanel
            // 
            BodyPanel.AutoScroll = true;
            BodyPanel.Controls.Add(PlayerPanel);
            BodyPanel.Dock = DockStyle.Fill;
            BodyPanel.Location = new Point(0, 63);
            BodyPanel.Name = "BodyPanel";
            BodyPanel.Size = new Size(1068, 332);
            BodyPanel.TabIndex = 3;
            // 
            // PlayerPanel
            // 
            PlayerPanel.Controls.Add(videoView1);
            PlayerPanel.Dock = DockStyle.Fill;
            PlayerPanel.Location = new Point(0, 0);
            PlayerPanel.Name = "PlayerPanel";
            PlayerPanel.Size = new Size(1068, 332);
            PlayerPanel.TabIndex = 3;
            // 
            // RecentVideosFlow
            // 
            RecentVideosFlow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RecentVideosFlow.AutoScroll = true;
            RecentVideosFlow.Location = new Point(0, 111);
            RecentVideosFlow.Margin = new Padding(0);
            RecentVideosFlow.Name = "RecentVideosFlow";
            RecentVideosFlow.Size = new Size(1068, 104);
            RecentVideosFlow.TabIndex = 6;
            RecentVideosFlow.WrapContents = false;
            // 
            // PlayerControlsPanel
            // 
            PlayerControlsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PlayerControlsPanel.Controls.Add(VolumeLabel);
            PlayerControlsPanel.Controls.Add(VolumeTrackBar);
            PlayerControlsPanel.Controls.Add(TotalTimeLabel);
            PlayerControlsPanel.Controls.Add(CurrentTimeLabel);
            PlayerControlsPanel.Controls.Add(SeekTrackBar);
            PlayerControlsPanel.Controls.Add(StopPlayBackButton);
            PlayerControlsPanel.Controls.Add(PlayPauseButton);
            PlayerControlsPanel.Enabled = false;
            PlayerControlsPanel.Location = new Point(12, 0);
            PlayerControlsPanel.Name = "PlayerControlsPanel";
            PlayerControlsPanel.Size = new Size(1044, 68);
            PlayerControlsPanel.TabIndex = 4;
            PlayerControlsPanel.MouseEnter += PlayerControlsPanel_MouseEnter;
            PlayerControlsPanel.MouseLeave += PlayerControlsPanel_MouseLeave;
            // 
            // VolumeLabel
            // 
            VolumeLabel.AutoSize = true;
            VolumeLabel.Location = new Point(342, 42);
            VolumeLabel.Name = "VolumeLabel";
            VolumeLabel.Size = new Size(72, 15);
            VolumeLabel.TabIndex = 13;
            VolumeLabel.Text = "Volume 80%";
            // 
            // VolumeTrackBar
            // 
            VolumeTrackBar.AutoSize = false;
            VolumeTrackBar.Location = new Point(179, 37);
            VolumeTrackBar.Maximum = 100;
            VolumeTrackBar.Name = "VolumeTrackBar";
            VolumeTrackBar.Size = new Size(157, 24);
            VolumeTrackBar.TabIndex = 12;
            VolumeTrackBar.TickStyle = TickStyle.None;
            VolumeTrackBar.Value = 80;
            VolumeTrackBar.Scroll += trackBar2_Scroll;
            // 
            // TotalTimeLabel
            // 
            TotalTimeLabel.Anchor = AnchorStyles.Right;
            TotalTimeLabel.AutoSize = true;
            TotalTimeLabel.Font = new Font("Consolas", 9F);
            TotalTimeLabel.Location = new Point(978, 5);
            TotalTimeLabel.Name = "TotalTimeLabel";
            TotalTimeLabel.Size = new Size(63, 14);
            TotalTimeLabel.TabIndex = 11;
            TotalTimeLabel.Text = "--:--:--";
            // 
            // CurrentTimeLabel
            // 
            CurrentTimeLabel.Anchor = AnchorStyles.Left;
            CurrentTimeLabel.AutoSize = true;
            CurrentTimeLabel.Font = new Font("Consolas", 9F);
            CurrentTimeLabel.Location = new Point(3, 5);
            CurrentTimeLabel.Name = "CurrentTimeLabel";
            CurrentTimeLabel.Size = new Size(63, 14);
            CurrentTimeLabel.TabIndex = 10;
            CurrentTimeLabel.Text = "--:--:--";
            // 
            // SeekTrackBar
            // 
            SeekTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SeekTrackBar.AutoSize = false;
            SeekTrackBar.Location = new Point(72, -6);
            SeekTrackBar.Name = "SeekTrackBar";
            SeekTrackBar.Size = new Size(900, 25);
            SeekTrackBar.TabIndex = 9;
            SeekTrackBar.TickStyle = TickStyle.TopLeft;
            SeekTrackBar.Scroll += SeekTrackBar_Scroll;
            SeekTrackBar.MouseDown += SeekTrackBar_MouseDown;
            SeekTrackBar.MouseUp += SeekTrackBar_MouseUp;
            // 
            // StopPlayBackButton
            // 
            StopPlayBackButton.BackColor = Color.FromArgb(64, 64, 64);
            StopPlayBackButton.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            StopPlayBackButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            StopPlayBackButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            StopPlayBackButton.FlatStyle = FlatStyle.Flat;
            StopPlayBackButton.Font = new Font("Segoe UI", 9F);
            StopPlayBackButton.ForeColor = Color.White;
            StopPlayBackButton.Location = new Point(91, 33);
            StopPlayBackButton.Name = "StopPlayBackButton";
            StopPlayBackButton.Size = new Size(82, 32);
            StopPlayBackButton.TabIndex = 7;
            StopPlayBackButton.Text = "Stop";
            StopPlayBackButton.UseVisualStyleBackColor = false;
            StopPlayBackButton.Click += StopPlayBackButton_Click;
            // 
            // PlayPauseButton
            // 
            PlayPauseButton.BackColor = Color.FromArgb(240, 0, 54);
            PlayPauseButton.FlatAppearance.BorderColor = Color.FromArgb(250, 0, 60);
            PlayPauseButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(115, 0, 26);
            PlayPauseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 0, 40);
            PlayPauseButton.FlatStyle = FlatStyle.Flat;
            PlayPauseButton.Font = new Font("Segoe UI", 9F);
            PlayPauseButton.ForeColor = Color.White;
            PlayPauseButton.Location = new Point(3, 33);
            PlayPauseButton.Name = "PlayPauseButton";
            PlayPauseButton.Size = new Size(82, 32);
            PlayPauseButton.TabIndex = 6;
            PlayPauseButton.Text = "Play";
            PlayPauseButton.UseVisualStyleBackColor = false;
            PlayPauseButton.Click += PlayPauseButton_Click;
            // 
            // dlpButton2
            // 
            dlpButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dlpButton2.BackColor = Color.FromArgb(64, 64, 64);
            dlpButton2.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            dlpButton2.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            dlpButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            dlpButton2.FlatStyle = FlatStyle.Flat;
            dlpButton2.Font = new Font("Segoe UI", 9F);
            dlpButton2.ForeColor = Color.White;
            dlpButton2.Location = new Point(971, 33);
            dlpButton2.Name = "dlpButton2";
            dlpButton2.Size = new Size(82, 32);
            dlpButton2.TabIndex = 8;
            dlpButton2.Text = "Full Screen";
            dlpButton2.UseVisualStyleBackColor = false;
            dlpButton2.Click += dlpButton2_Click;
            // 
            // VideoTitleLabel
            // 
            VideoTitleLabel.AutoSize = true;
            VideoTitleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VideoTitleLabel.Location = new Point(12, 73);
            VideoTitleLabel.Name = "VideoTitleLabel";
            VideoTitleLabel.Size = new Size(302, 30);
            VideoTitleLabel.TabIndex = 5;
            VideoTitleLabel.Text = "Choose a video in the URL bar";
            // 
            // TimeTrackTimer
            // 
            TimeTrackTimer.Enabled = true;
            TimeTrackTimer.Interval = 10;
            TimeTrackTimer.Tick += TimeTrackTimer_Tick;
            // 
            // ControlPanel
            // 
            ControlPanel.Controls.Add(button1);
            ControlPanel.Controls.Add(dlpButton1);
            ControlPanel.Controls.Add(dlpButton2);
            ControlPanel.Controls.Add(PlayerControlsPanel);
            ControlPanel.Controls.Add(RecentVideosFlow);
            ControlPanel.Controls.Add(VideoTitleLabel);
            ControlPanel.Dock = DockStyle.Bottom;
            ControlPanel.Location = new Point(0, 395);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(1068, 215);
            ControlPanel.TabIndex = 7;
            ControlPanel.Paint += panel1_Paint;
            // 
            // dlpButton1
            // 
            dlpButton1.BackColor = Color.FromArgb(64, 64, 64);
            dlpButton1.FlatStyle = FlatStyle.System;
            dlpButton1.Font = new Font("Segoe UI", 9F);
            dlpButton1.ForeColor = Color.White;
            dlpButton1.Location = new Point(522, 75);
            dlpButton1.Name = "dlpButton1";
            dlpButton1.Size = new Size(75, 23);
            dlpButton1.TabIndex = 9;
            dlpButton1.Text = "dlpButton1";
            dlpButton1.UseVisualStyleBackColor = true;
            // 
            // FullScreenControlHide
            // 
            FullScreenControlHide.Interval = 3000;
            FullScreenControlHide.Tick += FullScreenControlHide_Tick;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Guide";
            // 
            // button1
            // 
            button1.ForeColor = Color.White;
            button1.Location = new Point(622, 75);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1068, 610);
            Controls.Add(BodyPanel);
            Controls.Add(ControlPanel);
            Controls.Add(TopPanel);
            ForeColor = Color.White;
            MinimumSize = new Size(541, 600);
            Name = "Form1";
            Text = "YT-DLP Player";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += MainForm_KeyDown;
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            BodyPanel.ResumeLayout(false);
            PlayerPanel.ResumeLayout(false);
            PlayerControlsPanel.ResumeLayout(false);
            PlayerControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SeekTrackBar).EndInit();
            ControlPanel.ResumeLayout(false);
            ControlPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel TopPanel;
        private Panel panel2;
        private TextBox URLTextBox;
        private Label label1;
        private Button SettingsButton;
        private controls.DLPButtonHighlighted FindVideoButton;
        private LibVLCSharp.WinForms.VideoView videoView1;
        private Panel BodyPanel;
        private Label VideoTitleLabel;
        private Panel PlayerControlsPanel;
        private Panel PlayerPanel;
        private TrackBar SeekTrackBar;
        private controls.DLPButton dlpButton2;
        private controls.DLPButton StopPlayBackButton;
        private controls.DLPButtonHighlighted PlayPauseButton;
        private Label CurrentTimeLabel;
        private Label TotalTimeLabel;
        private TrackBar VolumeTrackBar;
        private System.Windows.Forms.Timer TimeTrackTimer;
        private Label VolumeLabel;
        private FlowLayoutPanel RecentVideosFlow;
        private Panel ControlPanel;
        private System.Windows.Forms.Timer FullScreenControlHide;
        private ToolTip toolTip1;
        private controls.DLPButton DownloadQueue;
        private controls.DLPButton dlpButton1;
        private Button button1;
    }
}
