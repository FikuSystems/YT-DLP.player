using YT_DLP.player.controls;

namespace YT_DLP.player.dialogs
{
    partial class Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
            panel1 = new Panel();
            label1 = new Label();
            dlpButtonHighlighted1 = new DLPButtonHighlighted();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dlpButtonHighlighted1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(850, 33);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // dlpButtonHighlighted1
            // 
            dlpButtonHighlighted1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dlpButtonHighlighted1.BackColor = Color.FromArgb(240, 0, 54);
            dlpButtonHighlighted1.FlatAppearance.BorderColor = Color.FromArgb(250, 0, 60);
            dlpButtonHighlighted1.FlatAppearance.MouseDownBackColor = Color.FromArgb(115, 0, 26);
            dlpButtonHighlighted1.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 0, 40);
            dlpButtonHighlighted1.FlatStyle = FlatStyle.Flat;
            dlpButtonHighlighted1.Font = new Font("Segoe UI", 9F);
            dlpButtonHighlighted1.ForeColor = Color.White;
            dlpButtonHighlighted1.Image = (Image)resources.GetObject("dlpButtonHighlighted1.Image");
            dlpButtonHighlighted1.Location = new Point(821, 3);
            dlpButtonHighlighted1.Name = "dlpButtonHighlighted1";
            dlpButtonHighlighted1.Size = new Size(26, 26);
            dlpButtonHighlighted1.TabIndex = 1;
            dlpButtonHighlighted1.UseVisualStyleBackColor = false;
            dlpButtonHighlighted1.Click += dlpButtonHighlighted1_Click;
            // 
            // Dialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(850, 269);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Dialog";
            Text = "Dialog";
            Load += Dialog_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private controls.DLPButtonHighlighted dlpButtonHighlighted1;
        private Label label1;
    }
}