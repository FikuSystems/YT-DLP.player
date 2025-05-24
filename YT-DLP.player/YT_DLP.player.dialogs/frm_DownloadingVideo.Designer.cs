namespace YT_DLP.player
{
    partial class frm_DownloadingVideo
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
            progressBar1 = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.ForeColor = Color.FromArgb(240, 0, 54);
            progressBar1.Location = new Point(12, 42);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(403, 10);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 30);
            label1.TabIndex = 4;
            label1.Text = "Downloading Video";
            // 
            // frm_DownloadingVideo
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(427, 69);
            ControlBox = false;
            Controls.Add(progressBar1);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "frm_DownloadingVideo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "YT-DLP Player - Downloading %video%";
            TopMost = true;
            Load += DownloadingVideo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label label1;
        public ProgressBar progressBar1;
    }
}