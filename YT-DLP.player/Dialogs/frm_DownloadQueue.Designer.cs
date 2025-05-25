namespace YT_DLP.player
{
    partial class frm_DownloadQueue
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
            dataGridView1 = new DataGridView();
            Priority = new DataGridViewTextBoxColumn();
            URL = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            dlpButton1 = new controls.DLPButton();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Priority, URL, Column1, Column2 });
            dataGridView1.Location = new Point(12, 155);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.Size = new Size(444, 213);
            dataGridView1.TabIndex = 0;
            // 
            // Priority
            // 
            Priority.HeaderText = "Priority";
            Priority.Name = "Priority";
            // 
            // URL
            // 
            URL.HeaderText = "URL";
            URL.Name = "URL";
            // 
            // Column1
            // 
            Column1.HeaderText = "Title";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Progress";
            Column2.Name = "Column2";
            // 
            // dlpButton1
            // 
            dlpButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dlpButton1.BackColor = Color.FromArgb(64, 64, 64);
            dlpButton1.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            dlpButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            dlpButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
            dlpButton1.FlatStyle = FlatStyle.Flat;
            dlpButton1.Font = new Font("Segoe UI", 9F);
            dlpButton1.ForeColor = Color.White;
            dlpButton1.Location = new Point(366, 374);
            dlpButton1.Name = "dlpButton1";
            dlpButton1.Size = new Size(90, 32);
            dlpButton1.TabIndex = 1;
            dlpButton1.Text = "dlpButton1";
            dlpButton1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 137);
            panel1.TabIndex = 2;
            // 
            // frm_DownloadQueue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 418);
            Controls.Add(panel1);
            Controls.Add(dlpButton1);
            Controls.Add(dataGridView1);
            Name = "frm_DownloadQueue";
            Text = "YT-DLP Player - Download Queue";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private controls.DLPButton dlpButton1;
        private DataGridViewTextBoxColumn Priority;
        private DataGridViewTextBoxColumn URL;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Panel panel1;
    }
}