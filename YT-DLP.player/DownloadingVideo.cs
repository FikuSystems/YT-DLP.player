using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT_DLP.player
{
    public partial class DownloadingVideo : Form
    {
        public DownloadingVideo()
        {
            InitializeComponent();
            EnableDarkTitleBar(this.Handle);
        }
        #region DarkTitleBar
        private static void EnableDarkTitleBar(IntPtr handle)
        {
            if (Environment.OSVersion.Version.Build >= 17763) // Windows 10 1809+
            {
                int useImmersiveDarkMode = 1;
                DwmSetWindowAttribute(handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useImmersiveDarkMode, sizeof(int));
            }
        }

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        #endregion
        private void DownloadingVideo_Load(object sender, EventArgs e)
        {

        }
    }
}
