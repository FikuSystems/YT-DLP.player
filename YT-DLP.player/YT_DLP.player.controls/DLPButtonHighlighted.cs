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
    public partial class DLPButtonHighlighted: Button
    {
        public DLPButtonHighlighted()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.FromArgb(240,0,54);
            this.FlatAppearance.BorderColor = Color.FromArgb(250, 0, 60);
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(115, 0, 26);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 0, 40);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.Size = new Size(90, 32);
        }
    }
}
