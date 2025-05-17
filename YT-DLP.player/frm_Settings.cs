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
    public partial class frm_Settings : Form
    {
        public frm_Settings()
        {
            EnableDarkTitleBar(this.Handle);
            InitializeComponent();
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
        private void GetSettings()
        {
            // Reload Changes
            Properties.Settings.Default.Reload();

            // Check Boxes
            DeleteOnCloseCB.Checked = Properties.Settings.Default.DeleteOnClose;
            AutoplayCB.Checked = Properties.Settings.Default.AutoPlayAfterDownload;
            DownloadSubtitlesCB.Checked = Properties.Settings.Default.DownloadSubtitles;
            LargeDownloadWarningCB.Checked = Properties.Settings.Default.WarnLargeDownloads;
            NormalizeVolumeCB.Checked = Properties.Settings.Default.NormalizeAudio;

            // Text Boxes
            DownloadLocationTB.Text = Properties.Settings.Default.DownloadLocation;
            PreferredLanguageTB.Text = Properties.Settings.Default.PreferredLanguage;
            VideoFormatTB.Text = Properties.Settings.Default.DownloadVideoFormat;
            AudioFormatTB.Text = Properties.Settings.Default.DownloadAudioFormat;

            // Domain/ Numberic Up-Downs
            LargeDownloadThresholdNUD.Value = Properties.Settings.Default.LargeDownloadsThreshold;
            DefualtVolumeNUD.Value = Properties.Settings.Default.DefaultVolume;
        }
        // Fix for CS0266: Explicitly cast 'decimal' to 'int'  
        private void SaveSettings()
        {
            // Check Boxes  
            Properties.Settings.Default.DeleteOnClose = DeleteOnCloseCB.Checked;
            Properties.Settings.Default.AutoPlayAfterDownload = AutoplayCB.Checked;
            Properties.Settings.Default.DownloadSubtitles = DownloadSubtitlesCB.Checked;
            Properties.Settings.Default.NormalizeAudio = NormalizeVolumeCB.Checked;
            Properties.Settings.Default.WarnLargeDownloads = LargeDownloadWarningCB.Checked;

            // Text Boxes  
            Properties.Settings.Default.DownloadLocation = DownloadLocationTB.Text;
            Properties.Settings.Default.PreferredLanguage = PreferredLanguageTB.Text;
            Properties.Settings.Default.DownloadVideoFormat = VideoFormatTB.Text;
            Properties.Settings.Default.DownloadAudioFormat = AudioFormatTB.Text;

            // Domain/ Numeric Up-Downs  
            Properties.Settings.Default.LargeDownloadsThreshold = (int)LargeDownloadThresholdNUD.Value;
            Properties.Settings.Default.DefaultVolume = (int)DefualtVolumeNUD.Value;

            // Save Settings
            Properties.Settings.Default.Save();
        }
        private void DefaultSettings()
        {
            Properties.Settings.Default.DeleteOnClose = true;
            Properties.Settings.Default.AutoPlayAfterDownload = true;
            Properties.Settings.Default.DownloadSubtitles = false;
            Properties.Settings.Default.NormalizeAudio = false;
            Properties.Settings.Default.ResumeLastPosition = false;
            Properties.Settings.Default.WarnLargeDownloads = true;

            // Text Boxes  
            Properties.Settings.Default.DownloadLocation = "";
            Properties.Settings.Default.PreferredLanguage = "en";
            Properties.Settings.Default.DownloadVideoFormat = "bestvideo";
            Properties.Settings.Default.DownloadAudioFormat = "bestaudio";

            // Domain/ Numeric Up-Downs  
            Properties.Settings.Default.LargeDownloadsThreshold = 1000;
            Properties.Settings.Default.DefaultVolume = 80;

            // Save Settings
            Properties.Settings.Default.Save();

            // Reload Changes
            GetSettings();
        }

        // LOAD SETTINGS

        private void Settings_Load(object sender, EventArgs e)
        {
            GetSettings();
        }

        // BUTTONS

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void dlpButton1_Click(object sender, EventArgs e)
        {
            DefaultSettings();
        }

        private void DiscardButton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What did i just tell you?");
        }
    }
}
