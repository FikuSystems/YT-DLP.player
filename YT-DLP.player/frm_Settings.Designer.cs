using YT_DLP.player.controls;

namespace YT_DLP.player
{
    partial class frm_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Settings));
            FormTitleLabel = new Label();
            SaveButton = new DLPButtonHighlighted();
            DiscardButton = new DLPButton();
            groupBox2 = new GroupBox();
            DefualtVolumeNUD = new NumericUpDown();
            label8 = new Label();
            AudioFormatTB = new TextBox();
            label7 = new Label();
            VideoFormatTB = new TextBox();
            DefaultVolumeTB = new Label();
            NormalizeVolumeCB = new CheckBox();
            DownloadBehaviourPanel = new GroupBox();
            HideDownloadsCB = new CheckBox();
            LargeDownloadThresholdNUD = new NumericUpDown();
            WarningThresholdLabel = new Label();
            LargeDownloadWarningCB = new CheckBox();
            PreferredLanguageTB = new TextBox();
            PreferredLanguageLabel = new Label();
            DownloadSubtitlesCB = new CheckBox();
            AutoplayCB = new CheckBox();
            DownloadLocationLeaveBlankLabel = new Label();
            DownloadLocationLabel = new Label();
            DownloadLocationTB = new TextBox();
            DeleteOnCloseCB = new CheckBox();
            ResetButton = new DLPButton();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DefualtVolumeNUD).BeginInit();
            DownloadBehaviourPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LargeDownloadThresholdNUD).BeginInit();
            SuspendLayout();
            // 
            // FormTitleLabel
            // 
            FormTitleLabel.AutoSize = true;
            FormTitleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormTitleLabel.Location = new Point(12, 9);
            FormTitleLabel.Name = "FormTitleLabel";
            FormTitleLabel.Size = new Size(90, 30);
            FormTitleLabel.TabIndex = 1;
            FormTitleLabel.Text = "Settings";
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
            SaveButton.Click += SaveButton_Click;
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
            DiscardButton.Click += DiscardButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(DefualtVolumeNUD);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(AudioFormatTB);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(VideoFormatTB);
            groupBox2.Controls.Add(DefaultVolumeTB);
            groupBox2.Controls.Add(NormalizeVolumeCB);
            groupBox2.ForeColor = Color.FromArgb(255, 255, 254);
            groupBox2.Location = new Point(223, 42);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(205, 269);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Video and Audio";
            // 
            // DefualtVolumeNUD
            // 
            DefualtVolumeNUD.Location = new Point(153, 21);
            DefualtVolumeNUD.Name = "DefualtVolumeNUD";
            DefualtVolumeNUD.Size = new Size(46, 23);
            DefualtVolumeNUD.TabIndex = 20;
            DefualtVolumeNUD.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 104);
            label8.Name = "label8";
            label8.Size = new Size(78, 15);
            label8.TabIndex = 18;
            label8.Text = "Audio format";
            // 
            // AudioFormatTB
            // 
            AudioFormatTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            AudioFormatTB.BackColor = Color.FromArgb(26, 26, 26);
            AudioFormatTB.BorderStyle = BorderStyle.FixedSingle;
            AudioFormatTB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AudioFormatTB.ForeColor = Color.White;
            AudioFormatTB.Location = new Point(7, 122);
            AudioFormatTB.Name = "AudioFormatTB";
            AudioFormatTB.Size = new Size(193, 23);
            AudioFormatTB.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 60);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 16;
            label7.Text = "Video format";
            // 
            // VideoFormatTB
            // 
            VideoFormatTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            VideoFormatTB.BackColor = Color.FromArgb(26, 26, 26);
            VideoFormatTB.BorderStyle = BorderStyle.FixedSingle;
            VideoFormatTB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            VideoFormatTB.ForeColor = Color.White;
            VideoFormatTB.Location = new Point(6, 78);
            VideoFormatTB.Name = "VideoFormatTB";
            VideoFormatTB.Size = new Size(193, 23);
            VideoFormatTB.TabIndex = 15;
            // 
            // DefaultVolumeTB
            // 
            DefaultVolumeTB.AutoSize = true;
            DefaultVolumeTB.Location = new Point(6, 23);
            DefaultVolumeTB.Name = "DefaultVolumeTB";
            DefaultVolumeTB.Size = new Size(88, 15);
            DefaultVolumeTB.TabIndex = 7;
            DefaultVolumeTB.Text = "Default Volume";
            // 
            // NormalizeVolumeCB
            // 
            NormalizeVolumeCB.AutoSize = true;
            NormalizeVolumeCB.Location = new Point(7, 41);
            NormalizeVolumeCB.Margin = new Padding(3, 0, 3, 0);
            NormalizeVolumeCB.Name = "NormalizeVolumeCB";
            NormalizeVolumeCB.Size = new Size(115, 19);
            NormalizeVolumeCB.TabIndex = 11;
            NormalizeVolumeCB.Text = "Normalize Audio";
            NormalizeVolumeCB.UseVisualStyleBackColor = true;
            // 
            // DownloadBehaviourPanel
            // 
            DownloadBehaviourPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DownloadBehaviourPanel.Controls.Add(HideDownloadsCB);
            DownloadBehaviourPanel.Controls.Add(LargeDownloadThresholdNUD);
            DownloadBehaviourPanel.Controls.Add(WarningThresholdLabel);
            DownloadBehaviourPanel.Controls.Add(LargeDownloadWarningCB);
            DownloadBehaviourPanel.Controls.Add(PreferredLanguageTB);
            DownloadBehaviourPanel.Controls.Add(PreferredLanguageLabel);
            DownloadBehaviourPanel.Controls.Add(DownloadSubtitlesCB);
            DownloadBehaviourPanel.Controls.Add(AutoplayCB);
            DownloadBehaviourPanel.Controls.Add(DownloadLocationLeaveBlankLabel);
            DownloadBehaviourPanel.Controls.Add(DownloadLocationLabel);
            DownloadBehaviourPanel.Controls.Add(DownloadLocationTB);
            DownloadBehaviourPanel.Controls.Add(DeleteOnCloseCB);
            DownloadBehaviourPanel.ForeColor = Color.FromArgb(255, 255, 254);
            DownloadBehaviourPanel.Location = new Point(12, 42);
            DownloadBehaviourPanel.Name = "DownloadBehaviourPanel";
            DownloadBehaviourPanel.Size = new Size(205, 269);
            DownloadBehaviourPanel.TabIndex = 4;
            DownloadBehaviourPanel.TabStop = false;
            DownloadBehaviourPanel.Text = "Download Behaviour";
            // 
            // HideDownloadsCB
            // 
            HideDownloadsCB.AutoSize = true;
            HideDownloadsCB.Location = new Point(6, 60);
            HideDownloadsCB.Margin = new Padding(3, 0, 3, 0);
            HideDownloadsCB.Name = "HideDownloadsCB";
            HideDownloadsCB.Size = new Size(168, 19);
            HideDownloadsCB.TabIndex = 15;
            HideDownloadsCB.Text = "Hide downloads on launch";
            HideDownloadsCB.UseVisualStyleBackColor = true;
            // 
            // LargeDownloadThresholdNUD
            // 
            LargeDownloadThresholdNUD.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            LargeDownloadThresholdNUD.Location = new Point(140, 195);
            LargeDownloadThresholdNUD.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            LargeDownloadThresholdNUD.Name = "LargeDownloadThresholdNUD";
            LargeDownloadThresholdNUD.Size = new Size(59, 23);
            LargeDownloadThresholdNUD.TabIndex = 14;
            LargeDownloadThresholdNUD.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // WarningThresholdLabel
            // 
            WarningThresholdLabel.AutoSize = true;
            WarningThresholdLabel.Location = new Point(5, 197);
            WarningThresholdLabel.Name = "WarningThresholdLabel";
            WarningThresholdLabel.Size = new Size(105, 15);
            WarningThresholdLabel.TabIndex = 13;
            WarningThresholdLabel.Text = "Warning threshold";
            // 
            // LargeDownloadWarningCB
            // 
            LargeDownloadWarningCB.AutoSize = true;
            LargeDownloadWarningCB.Location = new Point(6, 175);
            LargeDownloadWarningCB.Margin = new Padding(3, 0, 3, 0);
            LargeDownloadWarningCB.Name = "LargeDownloadWarningCB";
            LargeDownloadWarningCB.Size = new Size(157, 19);
            LargeDownloadWarningCB.TabIndex = 12;
            LargeDownloadWarningCB.Text = "Large download warning";
            LargeDownloadWarningCB.UseVisualStyleBackColor = true;
            // 
            // PreferredLanguageTB
            // 
            PreferredLanguageTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PreferredLanguageTB.BackColor = Color.FromArgb(26, 26, 26);
            PreferredLanguageTB.BorderStyle = BorderStyle.FixedSingle;
            PreferredLanguageTB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PreferredLanguageTB.ForeColor = Color.White;
            PreferredLanguageTB.Location = new Point(140, 96);
            PreferredLanguageTB.MaxLength = 3;
            PreferredLanguageTB.Name = "PreferredLanguageTB";
            PreferredLanguageTB.Size = new Size(59, 23);
            PreferredLanguageTB.TabIndex = 10;
            // 
            // PreferredLanguageLabel
            // 
            PreferredLanguageLabel.AutoSize = true;
            PreferredLanguageLabel.Location = new Point(6, 98);
            PreferredLanguageLabel.Name = "PreferredLanguageLabel";
            PreferredLanguageLabel.Size = new Size(107, 15);
            PreferredLanguageLabel.TabIndex = 9;
            PreferredLanguageLabel.Text = "Preferred language";
            // 
            // DownloadSubtitlesCB
            // 
            DownloadSubtitlesCB.AutoSize = true;
            DownloadSubtitlesCB.Location = new Point(6, 79);
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
            // DownloadLocationLeaveBlankLabel
            // 
            DownloadLocationLeaveBlankLabel.AutoSize = true;
            DownloadLocationLeaveBlankLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            DownloadLocationLeaveBlankLabel.ForeColor = Color.FromArgb(224, 224, 224);
            DownloadLocationLeaveBlankLabel.Location = new Point(6, 157);
            DownloadLocationLeaveBlankLabel.Name = "DownloadLocationLeaveBlankLabel";
            DownloadLocationLeaveBlankLabel.Size = new Size(140, 15);
            DownloadLocationLeaveBlankLabel.TabIndex = 4;
            DownloadLocationLeaveBlankLabel.Text = "^ Leave blank for default";
            // 
            // DownloadLocationLabel
            // 
            DownloadLocationLabel.AutoSize = true;
            DownloadLocationLabel.Location = new Point(6, 116);
            DownloadLocationLabel.Name = "DownloadLocationLabel";
            DownloadLocationLabel.Size = new Size(110, 15);
            DownloadLocationLabel.TabIndex = 3;
            DownloadLocationLabel.Text = "Download Location";
            // 
            // DownloadLocationTB
            // 
            DownloadLocationTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DownloadLocationTB.BackColor = Color.FromArgb(26, 26, 26);
            DownloadLocationTB.BorderStyle = BorderStyle.FixedSingle;
            DownloadLocationTB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DownloadLocationTB.ForeColor = Color.White;
            DownloadLocationTB.Location = new Point(6, 134);
            DownloadLocationTB.Name = "DownloadLocationTB";
            DownloadLocationTB.Size = new Size(193, 23);
            DownloadLocationTB.TabIndex = 2;
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
            // ResetButton
            // 
            ResetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ResetButton.BackColor = Color.FromArgb(64, 64, 64);
            ResetButton.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            ResetButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            ResetButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            ResetButton.FlatStyle = FlatStyle.Flat;
            ResetButton.Font = new Font("Segoe UI", 9F);
            ResetButton.ForeColor = Color.White;
            ResetButton.Location = new Point(12, 324);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(62, 32);
            ResetButton.TabIndex = 5;
            ResetButton.Text = "&Reset";
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += dlpButton1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(169, 18);
            label1.Name = "label1";
            label1.Size = new Size(255, 15);
            label1.TabIndex = 6;
            label1.Text = "Most of the settings are still being implemented";
            label1.Click += label1_Click;
            // 
            // frm_Settings
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(26, 26, 26);
            CancelButton = DiscardButton;
            ClientSize = new Size(440, 368);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(ResetButton);
            Controls.Add(DownloadBehaviourPanel);
            Controls.Add(groupBox2);
            Controls.Add(DiscardButton);
            Controls.Add(SaveButton);
            Controls.Add(FormTitleLabel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frm_Settings";
            Text = "YT-DLP Player - Settings";
            Load += Settings_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DefualtVolumeNUD).EndInit();
            DownloadBehaviourPanel.ResumeLayout(false);
            DownloadBehaviourPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LargeDownloadThresholdNUD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label FormTitleLabel;
        private controls.DLPButtonHighlighted SaveButton;
        private controls.DLPButton DiscardButton;
        private GroupBox groupBox2;
        private GroupBox DownloadBehaviourPanel;
        private CheckBox DeleteOnCloseCB;
        private Label DownloadLocationLeaveBlankLabel;
        private Label DownloadLocationLabel;
        private TextBox DownloadLocationTB;
        private Label DefaultVolumeTB;
        private CheckBox DownloadSubtitlesCB;
        private TextBox PreferredLanguageTB;
        private Label PreferredLanguageLabel;
        private CheckBox NormalizeVolumeCB;
        private Label label8;
        private TextBox AudioFormatTB;
        private Label label7;
        private TextBox VideoFormatTB;
        private Label WarningThresholdLabel;
        private CheckBox LargeDownloadWarningCB;
        private controls.DLPButton ResetButton;
        private NumericUpDown DefualtVolumeNUD;
        private NumericUpDown LargeDownloadThresholdNUD;
        private Label label1;
        private CheckBox HideDownloadsCB;
        private CheckBox AutoplayCB;
    }
}