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
    public partial class DLPButton: Button
    {
        public DLPButton()
        {
            // switch(Application.ColorMode)
            // {
            //     case SystemColorMode.Classic:
            //         InitializeLightTheme();
            //         break;
            //     case SystemColorMode.Dark:
            //         InitializeDarkTheme();
            //         break;
            // }
            //
            //void InitializeLightTheme()
            // {
            //     this.FlatStyle = FlatStyle.System;
            // }
            InitializeDarkTheme();
            void InitializeDarkTheme()
            {
                this.FlatStyle = FlatStyle.Flat;
                this.BackColor = Color.FromArgb(64, 64, 64);
                this.FlatAppearance.BorderColor = SystemColors.WindowFrame;
                this.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
                this.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 42, 42);
                this.ForeColor = Color.White;
                this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                this.Size = new Size(90, 32);
            }

        }
    }
}
