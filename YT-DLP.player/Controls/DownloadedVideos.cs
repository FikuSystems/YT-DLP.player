using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT_DLP.player
{
    public partial class DownloadedVideos : UserControl
    {
        public DownloadedVideos()
        {
            InitializeComponent();
        }

        private void VideoURLLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(VideoURLLabel.Text);
            toolTip1.Show($"Copied URL to clipboard: {VideoURLLabel.Text}", VideoURLLabel, 5000);
        }
    }
}
