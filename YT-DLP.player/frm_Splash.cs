using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT_DLP.player
{
    public partial class frm_Splash : Form
    {
        public frm_Splash()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetBackgroundToScreen();
        }

        private void SetBackgroundToScreen()
        {
            // Get the form's location and size on the screen
            Rectangle bounds = this.Bounds;

            // Capture the screen area behind the form
            using (Bitmap bmp = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
                }
                // Set as background image
                this.BackgroundImage = (Bitmap)bmp.Clone();
            }
            this.BackgroundImageLayout = ImageLayout.Stretch; // Or None/Tile/Center as desired
        }

        private void frm_Splash_Load(object sender, EventArgs e)
        {
            label1.Text = $"YT_DLP.Player loading...\r\nVersion: {Application.ProductVersion}";
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
