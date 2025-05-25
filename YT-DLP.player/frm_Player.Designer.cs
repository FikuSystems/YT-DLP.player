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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TopPanel = new Panel();
            pictureBox1 = new PictureBox();
            DownloadProgress_PB = new ProgressBar();
            button1 = new Button();
            DownloadQueue = new DLPButton();
            FindVideoButton = new DLPButtonHighlighted();
            SettingsButton = new Button();
            panel2 = new Panel();
            URLTextBox = new TextBox();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            BodyPanel = new Panel();
            PlayerPanel = new Panel();
            RecentVideosFlow = new FlowLayoutPanel();
            PlayerControlsPanel = new Panel();
            MuteButton = new DLPButton();
            VolumeLabel = new Label();
            VolumeTrackBar = new TrackBar();
            TotalTimeLabel = new Label();
            CurrentTimeLabel = new Label();
            SeekTrackBar = new TrackBar();
            StopPlayBackButton = new DLPButton();
            PlayPauseButton = new DLPButtonHighlighted();
            btn_FullScreen = new DLPButton();
            VideoTitleLabel = new Label();
            TimeTrackTimer = new System.Windows.Forms.Timer(components);
            ControlPanel = new Panel();
            Check_ShowDownloads = new CheckBox();
            FullScreenControlHide = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            NotificationPanel = new Panel();
            NotificationButton = new DLPButton();
            pictureBox2 = new PictureBox();
            NotificationLabel = new Label();
            TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            BodyPanel.SuspendLayout();
            PlayerPanel.SuspendLayout();
            PlayerControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VolumeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SeekTrackBar).BeginInit();
            ControlPanel.SuspendLayout();
            NotificationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(pictureBox1);
            TopPanel.Controls.Add(DownloadProgress_PB);
            TopPanel.Controls.Add(button1);
            TopPanel.Controls.Add(DownloadQueue);
            TopPanel.Controls.Add(FindVideoButton);
            TopPanel.Controls.Add(SettingsButton);
            TopPanel.Controls.Add(panel2);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1068, 63);
            TopPanel.TabIndex = 1;
            TopPanel.Paint += TopPanel_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // DownloadProgress_PB
            // 
            DownloadProgress_PB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DownloadProgress_PB.ForeColor = Color.FromArgb(240, 0, 54);
            DownloadProgress_PB.Location = new Point(302, 48);
            DownloadProgress_PB.Name = "DownloadProgress_PB";
            DownloadProgress_PB.Size = new Size(369, 5);
            DownloadProgress_PB.Style = ProgressBarStyle.Continuous;
            DownloadProgress_PB.TabIndex = 5;
            DownloadProgress_PB.Visible = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(908, 15);
            button1.Name = "button1";
            button1.Size = new Size(70, 32);
            button1.TabIndex = 3;
            button1.Text = "Hot Keys";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // DownloadQueue
            // 
            DownloadQueue.Anchor = AnchorStyles.Right;
            DownloadQueue.BackColor = Color.FromArgb(64, 64, 64);
            DownloadQueue.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            DownloadQueue.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            DownloadQueue.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            DownloadQueue.FlatStyle = FlatStyle.Flat;
            DownloadQueue.Font = new Font("Segoe UI", 9F);
            DownloadQueue.ForeColor = Color.White;
            DownloadQueue.Location = new Point(714, 15);
            DownloadQueue.Name = "DownloadQueue";
            DownloadQueue.Size = new Size(53, 32);
            DownloadQueue.TabIndex = 2;
            DownloadQueue.Text = "Queue";
            DownloadQueue.UseVisualStyleBackColor = false;
            DownloadQueue.Click += DownloadQueue_Click;
            // 
            // FindVideoButton
            // 
            FindVideoButton.Anchor = AnchorStyles.Right;
            FindVideoButton.BackColor = Color.FromArgb(240, 0, 54);
            FindVideoButton.FlatAppearance.BorderColor = Color.FromArgb(250, 0, 60);
            FindVideoButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(115, 0, 26);
            FindVideoButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 0, 40);
            FindVideoButton.FlatStyle = FlatStyle.Flat;
            FindVideoButton.Font = new Font("Segoe UI", 9F);
            FindVideoButton.ForeColor = Color.White;
            FindVideoButton.Location = new Point(672, 15);
            FindVideoButton.Name = "FindVideoButton";
            FindVideoButton.Size = new Size(41, 32);
            FindVideoButton.TabIndex = 1;
            FindVideoButton.Text = "Play";
            FindVideoButton.UseVisualStyleBackColor = false;
            FindVideoButton.Click += FindVideoButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SettingsButton.BackColor = Color.FromArgb(64, 64, 64);
            SettingsButton.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
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
            panel2.Location = new Point(302, 15);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(1);
            panel2.Size = new Size(369, 32);
            panel2.TabIndex = 0;
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
            URLTextBox.Size = new Size(366, 20);
            URLTextBox.TabIndex = 0;
            URLTextBox.Text = "https://www.youtube.com/watch?v=6PjxUD_T9WI";
            URLTextBox.KeyDown += URLTextBox_KeyDown;
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Dock = DockStyle.Fill;
            videoView1.Location = new Point(0, 0);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(1068, 332);
            videoView1.TabIndex = 0;
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
            RecentVideosFlow.Padding = new Padding(3, 0, 3, 0);
            RecentVideosFlow.Size = new Size(1068, 104);
            RecentVideosFlow.TabIndex = 0;
            RecentVideosFlow.WrapContents = false;
            // 
            // PlayerControlsPanel
            // 
            PlayerControlsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PlayerControlsPanel.Controls.Add(MuteButton);
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
            PlayerControlsPanel.TabIndex = 1;
            PlayerControlsPanel.MouseEnter += PlayerControlsPanel_MouseEnter;
            PlayerControlsPanel.MouseLeave += PlayerControlsPanel_MouseLeave;
            // 
            // MuteButton
            // 
            MuteButton.BackColor = Color.FromArgb(64, 64, 64);
            MuteButton.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            MuteButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            MuteButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            MuteButton.FlatStyle = FlatStyle.Flat;
            MuteButton.Font = new Font("Segoe UI", 9F);
            MuteButton.ForeColor = Color.White;
            MuteButton.Location = new Point(179, 33);
            MuteButton.Name = "MuteButton";
            MuteButton.Size = new Size(82, 32);
            MuteButton.TabIndex = 5;
            MuteButton.Text = "Mute";
            MuteButton.UseVisualStyleBackColor = false;
            MuteButton.Click += MuteButton_Click;
            // 
            // VolumeLabel
            // 
            VolumeLabel.AutoSize = true;
            VolumeLabel.Location = new Point(430, 42);
            VolumeLabel.Name = "VolumeLabel";
            VolumeLabel.Size = new Size(72, 15);
            VolumeLabel.TabIndex = 7;
            VolumeLabel.Text = "Volume 80%";
            // 
            // VolumeTrackBar
            // 
            VolumeTrackBar.AutoSize = false;
            VolumeTrackBar.Location = new Point(267, 39);
            VolumeTrackBar.Maximum = 100;
            VolumeTrackBar.Name = "VolumeTrackBar";
            VolumeTrackBar.Size = new Size(157, 24);
            VolumeTrackBar.TabIndex = 6;
            VolumeTrackBar.TickStyle = TickStyle.None;
            VolumeTrackBar.Value = 80;
            VolumeTrackBar.Scroll += VolumeTrackBar_Scroll;
            // 
            // TotalTimeLabel
            // 
            TotalTimeLabel.Anchor = AnchorStyles.Right;
            TotalTimeLabel.AutoSize = true;
            TotalTimeLabel.Font = new Font("Consolas", 9F);
            TotalTimeLabel.Location = new Point(978, 5);
            TotalTimeLabel.Name = "TotalTimeLabel";
            TotalTimeLabel.Size = new Size(63, 14);
            TotalTimeLabel.TabIndex = 2;
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
            CurrentTimeLabel.TabIndex = 0;
            CurrentTimeLabel.Text = "--:--:--";
            // 
            // SeekTrackBar
            // 
            SeekTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SeekTrackBar.AutoSize = false;
            SeekTrackBar.Location = new Point(72, -6);
            SeekTrackBar.Name = "SeekTrackBar";
            SeekTrackBar.Size = new Size(900, 25);
            SeekTrackBar.TabIndex = 1;
            SeekTrackBar.TickStyle = TickStyle.TopLeft;
            SeekTrackBar.Scroll += SeekTrackBar_Scroll;
            SeekTrackBar.MouseDown += SeekTrackBar_MouseDown;
            SeekTrackBar.MouseUp += SeekTrackBar_MouseUp;
            // 
            // StopPlayBackButton
            // 
            StopPlayBackButton.BackColor = Color.FromArgb(64, 64, 64);
            StopPlayBackButton.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            StopPlayBackButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            StopPlayBackButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            StopPlayBackButton.FlatStyle = FlatStyle.Flat;
            StopPlayBackButton.Font = new Font("Segoe UI", 9F);
            StopPlayBackButton.ForeColor = Color.White;
            StopPlayBackButton.Location = new Point(91, 33);
            StopPlayBackButton.Name = "StopPlayBackButton";
            StopPlayBackButton.Size = new Size(82, 32);
            StopPlayBackButton.TabIndex = 4;
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
            PlayPauseButton.TabIndex = 3;
            PlayPauseButton.Text = "Play";
            PlayPauseButton.UseVisualStyleBackColor = false;
            PlayPauseButton.Click += PlayPauseButton_Click;
            // 
            // btn_FullScreen
            // 
            btn_FullScreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_FullScreen.BackColor = Color.FromArgb(64, 64, 64);
            btn_FullScreen.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            btn_FullScreen.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            btn_FullScreen.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            btn_FullScreen.FlatStyle = FlatStyle.Flat;
            btn_FullScreen.Font = new Font("Segoe UI", 9F);
            btn_FullScreen.ForeColor = Color.White;
            btn_FullScreen.Location = new Point(971, 33);
            btn_FullScreen.Name = "btn_FullScreen";
            btn_FullScreen.Size = new Size(82, 32);
            btn_FullScreen.TabIndex = 2;
            btn_FullScreen.Text = "Full Screen";
            btn_FullScreen.UseVisualStyleBackColor = false;
            btn_FullScreen.Click += btn_FullScreen_Click;
            // 
            // VideoTitleLabel
            // 
            VideoTitleLabel.AutoSize = true;
            VideoTitleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VideoTitleLabel.Location = new Point(12, 73);
            VideoTitleLabel.Name = "VideoTitleLabel";
            VideoTitleLabel.Size = new Size(302, 30);
            VideoTitleLabel.TabIndex = 3;
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
            ControlPanel.Controls.Add(Check_ShowDownloads);
            ControlPanel.Controls.Add(btn_FullScreen);
            ControlPanel.Controls.Add(PlayerControlsPanel);
            ControlPanel.Controls.Add(RecentVideosFlow);
            ControlPanel.Controls.Add(VideoTitleLabel);
            ControlPanel.Dock = DockStyle.Bottom;
            ControlPanel.Location = new Point(0, 395);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(1068, 215);
            ControlPanel.TabIndex = 2;
            // 
            // Check_ShowDownloads
            // 
            Check_ShowDownloads.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Check_ShowDownloads.Appearance = Appearance.Button;
            Check_ShowDownloads.BackColor = Color.FromArgb(64, 64, 64);
            Check_ShowDownloads.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            Check_ShowDownloads.FlatAppearance.CheckedBackColor = Color.FromArgb(64, 64, 64);
            Check_ShowDownloads.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            Check_ShowDownloads.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            Check_ShowDownloads.FlatStyle = FlatStyle.Flat;
            Check_ShowDownloads.Location = new Point(938, 73);
            Check_ShowDownloads.Name = "Check_ShowDownloads";
            Check_ShowDownloads.Size = new Size(116, 32);
            Check_ShowDownloads.TabIndex = 4;
            Check_ShowDownloads.Text = "Hide Downloads";
            Check_ShowDownloads.TextAlign = ContentAlignment.MiddleCenter;
            Check_ShowDownloads.UseVisualStyleBackColor = false;
            Check_ShowDownloads.CheckedChanged += ShowDownloads_Check_CheckedChanged;
            // 
            // FullScreenControlHide
            // 
            FullScreenControlHide.Interval = 3000;
            FullScreenControlHide.Tick += FullScreenControlHide_Tick;
            // 
            // toolTip1
            // 
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Guide";
            // 
            // NotificationPanel
            // 
            NotificationPanel.BackColor = Color.FromArgb(254, 252, 200);
            NotificationPanel.Controls.Add(NotificationButton);
            NotificationPanel.Controls.Add(pictureBox2);
            NotificationPanel.Controls.Add(NotificationLabel);
            NotificationPanel.Dock = DockStyle.Top;
            NotificationPanel.Location = new Point(0, 63);
            NotificationPanel.Name = "NotificationPanel";
            NotificationPanel.Size = new Size(1068, 24);
            NotificationPanel.TabIndex = 1;
            NotificationPanel.Visible = false;
            // 
            // NotificationButton
            // 
            NotificationButton.BackColor = Color.FromArgb(254, 252, 200);
            NotificationButton.FlatAppearance.BorderColor = Color.FromArgb(254, 252, 200);
            NotificationButton.FlatAppearance.BorderSize = 0;
            NotificationButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(165, 166, 126);
            NotificationButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 198, 151);
            NotificationButton.FlatStyle = FlatStyle.Flat;
            NotificationButton.Font = new Font("Segoe UI", 9F);
            NotificationButton.ForeColor = Color.Black;
            NotificationButton.Location = new Point(1032, 0);
            NotificationButton.Name = "NotificationButton";
            NotificationButton.Size = new Size(36, 24);
            NotificationButton.TabIndex = 2;
            NotificationButton.Text = "OK";
            NotificationButton.UseVisualStyleBackColor = false;
            NotificationButton.Click += dlpButton1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(5, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(16, 16);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // NotificationLabel
            // 
            NotificationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NotificationLabel.ForeColor = Color.Black;
            NotificationLabel.Location = new Point(28, 4);
            NotificationLabel.Name = "NotificationLabel";
            NotificationLabel.Size = new Size(998, 15);
            NotificationLabel.TabIndex = 0;
            NotificationLabel.Text = "You are on a metered network. Dowloads can be in excess of over a gigabyte.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1068, 610);
            Controls.Add(NotificationPanel);
            Controls.Add(BodyPanel);
            Controls.Add(ControlPanel);
            Controls.Add(TopPanel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(541, 600);
            Name = "Form1";
            Text = "YT-DLP Player";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += MainForm_KeyDown;
            TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
            NotificationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel TopPanel;
        private Panel panel2;
        private TextBox URLTextBox;
        private Button SettingsButton;
        private controls.DLPButtonHighlighted FindVideoButton;
        private LibVLCSharp.WinForms.VideoView videoView1;
        private Panel BodyPanel;
        private Label VideoTitleLabel;
        private Panel PlayerControlsPanel;
        private Panel PlayerPanel;
        private TrackBar SeekTrackBar;
        private controls.DLPButton btn_FullScreen;
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
        private CheckBox Check_ShowDownloads;
        private Button button1;
        private ProgressBar DownloadProgress_PB;
        private PictureBox pictureBox1;
        private DLPButton MuteButton;
        private Panel NotificationPanel;
        private PictureBox pictureBox2;
        private Label NotificationLabel;
        private DLPButton NotificationButton;
    }
}
