using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT_DLP.player.controls
{
    public partial class DLPButtonHotkey: Button
    {
        public DLPButtonHotkey()
        {
            InitializeDarkTheme();
            void InitializeDarkTheme()
            {
                this.FlatStyle = FlatStyle.Flat;
                this.BackColor = Color.FromArgb(64, 64, 64);
                this.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
                this.TextAlign = ContentAlignment.BottomLeft;
                this.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
                this.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
                this.ForeColor = Color.White;
                this.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                this.Size = new Size(60, 60);
            }

        }
    }
}
