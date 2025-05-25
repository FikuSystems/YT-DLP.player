using LibVLCSharp.Shared;
using System.Runtime.InteropServices;
using LibVLCSharp.WinForms;
using System.Reflection;
using System.Threading.Tasks;
using System.Resources;
using YT_DLP.player.Properties;
using System.IO.Compression;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.IO;
using System.Net.Http;

namespace YT_DLP.player
{
    public partial class Form1 : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        private static readonly string YTDLPMirrorLink = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
        private static readonly string FFMPEGZipUrl = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";

        private Cursor _emptyCursor;

        public Form1()
        {
            Properties.Settings.Default.Reload();
            InitializeComponent();



            // Initialize non-nullable fields to avoid CS8618 warnings
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            _emptyCursor = new Cursor("EmptyCursor.cur");
        }
        #region Settings
        private bool DeleteOnClose;
        private bool AutoPlayAfterDownload;
        private bool DownloadSubtitles;
        private bool WarnLargeDownloads;
        private bool NormalizeAudio;

        private string? DownloadLocation;
        private string? PreferredLanguage;
        private string? DownloadVideoFormat;
        private string? DownloadAudioFormat;

        private int LargeDownloadsThreshold;
        private int DefaultVolume;


        private void GetSettings()
        {
            // Check Boxes
            DeleteOnClose = Properties.Settings.Default.DeleteOnClose;
            AutoPlayAfterDownload = Properties.Settings.Default.AutoPlayAfterDownload;
            DownloadSubtitles = Properties.Settings.Default.DownloadSubtitles;
            WarnLargeDownloads = Properties.Settings.Default.WarnLargeDownloads;
            NormalizeAudio = Properties.Settings.Default.NormalizeAudio;
            // Text Boxes
            DownloadLocation = Properties.Settings.Default.DownloadLocation;
            PreferredLanguage = Properties.Settings.Default.PreferredLanguage;
            DownloadVideoFormat = Properties.Settings.Default.DownloadVideoFormat;
            DownloadAudioFormat = Properties.Settings.Default.DownloadAudioFormat;
            // Domain/ Numberic Up-Downs
            LargeDownloadsThreshold = Properties.Settings.Default.LargeDownloadsThreshold;
            DefaultVolume = Properties.Settings.Default.DefaultVolume;

            ApplyBasicSettings();
        }

        private void ApplyBasicSettings()
        {
            // Delete on close done
            // Autoplay after download done
            // Default Volume done

            // >> Download Subtitles <<
            // >> Warn Large Downloads <<
            // >> Normalize Audio <<
            // >> Download Location <<
            // >> Preferred Language <<
            // >> Download Video Format <<
            // >> Download Audio Format <<
            // >> Large Downloads Threshold <<

            // Volume
            VolumeTrackBar.Value = DefaultVolume;
            VolumeLabel.Text = $"Volume {VolumeTrackBar.Value}%";
            _mediaPlayer.Volume = DefaultVolume;

            // Autoplay button text
            FindVideoButton.Text = AutoPlayAfterDownload ? "Play" : "Get";
        }
        #endregion
        private void ShowNotificationPanel(string message, bool autohide)
        {
            NotificationPanel.Visible = true;
            NotificationLabel.Text = message;
            // Hide after 5 seconds
            if (!autohide) return;
            NotificationButton.Hide();
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                Invoke(new Action(() => NotificationPanel.Visible = false));
            });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //bool isMetered = NetworkHelper.IsConnectedToMeteredNetwork();
            //if (isMetered)
            //{
            //    ShowNotificationPanel("You are connected to a metered network. Downloads may incur additional charges.", false);
            //}
            KeyPreview = true;

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mediaPlayer;
            _mediaPlayer.LengthChanged += MediaPlayer_LengthChanged;
            _mediaPlayer.Volume = VolumeTrackBar.Value;
            _mediaPlayer.EndReached += MediaPlayer_EndReached;
            _mediaPlayer.TitleChanged += MediaPlayer_TitleChanged;
            _emptyCursor = new Cursor("EmptyCursor.cur");

            await EnsureYTDLPAsync();

            GetVideos();
            GetSettings();
        }

        private void GetVideos()
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.Combine(exeDir, "Downloads");
            if (!Directory.Exists(folderPath)) return;

            RecentVideosFlow.Controls.Clear();
            var videoExtensions = new[] { ".mp4", ".mkv", ".webm", ".avi" };

            foreach (var file in Directory.GetFiles(folderPath))
            {
                if (!videoExtensions.Contains(Path.GetExtension(file).ToLower()))
                    continue;

                // Split the filename to extract URL and VideoTitle
                string fileName = Path.GetFileNameWithoutExtension(file);
                int dashIndex = fileName.IndexOf(" - ");

                if (dashIndex < 0)
                    continue; // Skip if no dash is found

                string url = fileName.Substring(0, dashIndex); // Extract URL part before dash
                string videoTitle = fileName.Substring(dashIndex + 3); // Extract video title part after dash

                // Clean URL: replace any NTFS incompatibilities
                url = CleanUrl(url);

                // Create the control
                var videoControl = new DownloadedVideos
                {
                    VideoTitleLabel = { Text = videoTitle },
                    VideoURLLabel = { Text = url }
                };

                try
                {
                    using var libVLC = new LibVLC();
                    using var media = new Media(libVLC, file, FromType.FromPath);
                    media.Parse(MediaParseOptions.ParseLocal);
                    while (!media.ParsedStatus.HasFlag(MediaParsedStatus.Done))
                        Thread.Sleep(50);

                    var duration = TimeSpan.FromMilliseconds(media.Duration);
                    videoControl.TimeLabel.Text = duration.ToString(@"hh\:mm\:ss");
                }
                catch
                {
                    videoControl.TimeLabel.Text = "Unknown";
                }

                try
                {
                    string videoId = ExtractVideoIdFromUrl(url);
                    if (!string.IsNullOrEmpty(videoId))
                    {
                        // Construct the YouTube thumbnail URL
                        string thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";

                        // Download and set the thumbnail
                        Task.Run(async () =>
                        {
                            try
                            {
                                using var client = new HttpClient();
                                var thumbnailBytes = await client.GetByteArrayAsync(thumbnailUrl);
                                using var ms = new MemoryStream(thumbnailBytes);
                                Image thumbnailImage = Image.FromStream(ms);
                                Invoke(() => videoControl.pictureBox1.Image = thumbnailImage);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error downloading thumbnail: {ex.Message}");
                            }
                        });
                    }
                }
                catch { }

                string path = file;
                videoControl.WatchNowButton.Click += (s, e) =>
                {
                    var media = new Media(_libVLC, path, FromType.FromPath);
                    _mediaPlayer.Play(media);

                    PlayPauseButton.Text = "Pause";
                    PlayerControlsPanel.Enabled = true;

                    Invoke(() =>
                    {
                        string fileName = Path.GetFileNameWithoutExtension(path);
                        int dashIndex = fileName.IndexOf(" - ");
                        if (dashIndex >= 0)
                            fileName = fileName[(dashIndex + 3)..];

                        Text = $"YT-DLP Player - {fileName}";
                        VideoTitleLabel.Text = fileName;
                    });
                };

                videoControl.Margin = new Padding(0, 0, 3, 0);

                RecentVideosFlow.Controls.Add(videoControl);
            }
        }

        private static string CleanUrl(string url)
        {
            // Replace or remove problematic characters for NTFS compatibility
            string cleanedUrl = url;
            cleanedUrl = cleanedUrl.Replace("httpswww.youtube.comwatchv", "https://www.youtube.com/watch?v=");

            return cleanedUrl;
        }


        #region Player Controls
        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            if (_mediaPlayer.IsPlaying)
            {
                _mediaPlayer.Pause();
                PlayPauseButton.Text = "Play";
            }
            else
            {
                _mediaPlayer.Play();
                PlayPauseButton.Text = "Pause";
            }
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            _mediaPlayer.Volume = VolumeTrackBar.Value;
            VolumeLabel.Text = $"Volume {VolumeTrackBar.Value}%";
        }

        private void StopPlayBackButton_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Stop();
            PlayPauseButton.Text = "Play";
            SeekTrackBar.Value = 0;
            CurrentTimeLabel.Text = "--:--:--";
            TotalTimeLabel.Text = "--:--:--";
            PlayerControlsPanel.Enabled = false;
            Text = "YT-DLP Player - Stopped";
            VideoTitleLabel.Text = "Stopped - Enter a video URL in the URL bar.";

            if (IsFullscreen)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                Size = PreviousSize;
                IsFullscreen = false;
                TopPanel.Show();
                ControlPanelChangeMode(0); // Standard Mode
            }
        }

        private void TimeTrackTimer_Tick(object sender, EventArgs e)
        {
            if (_mediaPlayer == null || !_mediaPlayer.IsPlaying || _mediaPlayer.Length <= 0) return;

            int currentTimeSec = (int)(_mediaPlayer.Time / 1000);
            SeekTrackBar.Value = Math.Min(currentTimeSec, SeekTrackBar.Maximum);

            CurrentTimeLabel.Text = TimeSpan.FromMilliseconds(_mediaPlayer.Time).ToString(@"hh\:mm\:ss");
        }


        private void MediaPlayer_LengthChanged(object? sender, MediaPlayerLengthChangedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                var totalSeconds = (int)(e.Length / 1000);
                SeekTrackBar.Maximum = totalSeconds;
                TotalTimeLabel.Text = TimeSpan.FromMilliseconds(e.Length).ToString(@"hh\:mm\:ss");
            }));
        }

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            if (_mediaPlayer == null || _mediaPlayer.Length <= 0) return;

            long newTimeMs = SeekTrackBar.Value * 1000;
            _mediaPlayer.Time = newTimeMs;
        }

        private void SeekTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            TimeTrackTimer.Stop();
        }

        private void SeekTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            TimeTrackTimer.Start();
        }

        private void MediaPlayer_EndReached(object? sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                PlayPauseButton.Text = "Play";
                SeekTrackBar.Value = SeekTrackBar.Maximum;
                CurrentTimeLabel.Text = "--:--:--";
                TotalTimeLabel.Text = "--:--:--";
                PlayerControlsPanel.Enabled = false;
                Text = "YT-DLP Player - End Reached";

                if (IsFullscreen)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    Size = PreviousSize;
                    IsFullscreen = false;
                    TopPanel.Show();
                    ControlPanelChangeMode(0); // Standard Mode

                }
            }));
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show optional closing dialog
            frm_Closing closing = new();
            closing.Show();
            closing.BringToFront();
            closing.Focus();
            closing.TopMost = true;

            try
            {
                // Safely stop and dispose of VLC
                if (_mediaPlayer != null)
                {
                    _mediaPlayer.Stop();
                    _mediaPlayer.Dispose();
                }

                _libVLC?.Dispose();

                if (DeleteOnClose)
                {
                    // Delete all media files in the Downloads folder asynchronously
                    string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
                    string downloadsDir = Path.Combine(exeDir, "Downloads");

                    if (Directory.Exists(downloadsDir))
                    {
                        await Task.Run(() =>
                        {
                            foreach (string file in Directory.GetFiles(downloadsDir))
                            {
                                try
                                {
                                    System.IO.File.Delete(file);
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine($"Could not delete file {file}: {ex.Message}");
                                }
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during cleanup:\n{ex.Message}", "Cleanup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                closing.Close();
                closing.Dispose();
            }
        }

        private void MediaPlayer_TitleChanged(object? sender, MediaPlayerTitleChangedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (_mediaPlayer.Media?.Mrl != null)
                {
                    // Convert MRL (media resource locator) to a file path
                    var uri = new Uri(_mediaPlayer.Media.Mrl);
                    string fileName = Path.GetFileNameWithoutExtension(uri.LocalPath);

                    Text = $"YT-DLP Player - {fileName}";
                    VideoTitleLabel.Text = fileName;
                }
                else
                {
                    Text = "YT-DLP Player";
                    VideoTitleLabel.Text = "Unknown Title";
                }
            }));
        }
        #endregion

        #region FileDownloader

        private static async Task<bool> DownloadAndExtractFFmpegAsync(string destinationPath, PictureBox statusIcon)
        {
            string tempZipPath = Path.Combine(Path.GetTempPath(), "ffmpeg.zip");
            string tempExtractPath = Path.Combine(Path.GetTempPath(), "ffmpeg_extracted");

            int maxRetries = 5;
            int retryDelay = 1000; // 1 second
            int attempt = 0;

            while (attempt < maxRetries)
            {
                try
                {
                    ChangeArrow(statusIcon, "RightArrowShort_Blue");

                    // Use HttpClient with custom timeout
                    using (HttpClient client = new())
                    {
                        client.Timeout = TimeSpan.FromMinutes(5); // Set timeout to 5 minutes (or adjust as needed)

                        using HttpResponseMessage response = await client.GetAsync(FFMPEGZipUrl);
                        response.EnsureSuccessStatusCode();

                        await using FileStream fs = new(tempZipPath, FileMode.Create, FileAccess.Write, FileShare.None);
                        await response.Content.CopyToAsync(fs);
                    }

                    // If the extraction folder already exists, clean it up
                    if (Directory.Exists(tempExtractPath))
                        Directory.Delete(tempExtractPath, true);

                    // Extract the zip file
                    ZipFile.ExtractToDirectory(tempZipPath, tempExtractPath);

                    // Find ffmpeg.exe
                    string? foundExe = Directory
                        .GetFiles(tempExtractPath, "ffmpeg.exe", SearchOption.AllDirectories)
                        .FirstOrDefault();

                    if (foundExe != null)
                    {
                        System.IO.File.Copy(foundExe, destinationPath, overwrite: true);
                        ChangeArrow(statusIcon, "RightArrowShort_Green");
                        return true;
                    }
                    else
                    {
                        throw new FileNotFoundException("ffmpeg.exe not found in the extracted archive.");
                    }
                }
                catch (IOException ioEx)
                {
                    if (attempt >= maxRetries)
                    {
                        MessageBox.Show($"FFmpeg download error:\n{ioEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeArrow(statusIcon, "RightArrowShort_Orange");
                        return false;
                    }
                    // Retry if the file is in use
                    attempt++;
                    await Task.Delay(retryDelay);
                }
                catch (TimeoutException timeoutEx)
                {
                    if (attempt >= maxRetries)
                    {
                        MessageBox.Show($"FFmpeg download timeout:\n{timeoutEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeArrow(statusIcon, "RightArrowShort_Orange");
                        return false;
                    }
                    // Retry if the download timed out
                    attempt++;
                    await Task.Delay(retryDelay);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"FFmpeg download error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ChangeArrow(statusIcon, "RightArrowShort_Orange");
                    return false;
                }
                finally
                {
                    // Cleanup temporary files if any exist
                    try { if (System.IO.File.Exists(tempZipPath)) System.IO.File.Delete(tempZipPath); } catch { }
                    try { if (Directory.Exists(tempExtractPath)) Directory.Delete(tempExtractPath, true); } catch { }
                }
            }

            return false;
        }

        private async Task EnsureYTDLPAsync()
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            string ytDlpPath = Path.Combine(exeDir, "yt-dlp.exe");
            string ffmpegPath = Path.Combine(exeDir, "ffmpeg.exe");

            frm_DownloadingDialog downloadingdialog = new();
            ChangeArrow(downloadingdialog.pictureBox1, "RightArrowShort_Grey");
            ChangeArrow(downloadingdialog.pictureBox2, "RightArrowShort_Grey");

            downloadingdialog.Show();
            Application.DoEvents();
            Enabled = false;

            using HttpClient client = new();

            try
            {
                // yt-dlp
                if (!System.IO.File.Exists(ytDlpPath))
                {
                    ChangeArrow(downloadingdialog.pictureBox1, "RightArrowShort_Blue");

                    using HttpResponseMessage response = await client.GetAsync(YTDLPMirrorLink);
                    response.EnsureSuccessStatusCode();

                    using FileStream fs = new(ytDlpPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    await response.Content.CopyToAsync(fs);

                    ChangeArrow(downloadingdialog.pictureBox1, "RightArrowShort_Green");
                }

                // ffmpeg
                // ffmpeg
                if (!System.IO.File.Exists(ffmpegPath))
                {
                    await DownloadAndExtractFFmpegAsync(ffmpegPath, downloadingdialog.pictureBox2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Download error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (!System.IO.File.Exists(ytDlpPath))
                    ChangeArrow(downloadingdialog.pictureBox1, "RightArrowShort_Orange");

                if (!System.IO.File.Exists(ffmpegPath))
                    ChangeArrow(downloadingdialog.pictureBox2, "RightArrowShort_Orange");
            }
            finally
            {
                downloadingdialog.Close();
                downloadingdialog.Dispose();
                Enabled = true;
            }
        }


        private static void ChangeArrow(PictureBox pictureBox, string resourceName)
        {
            object? resource = Properties.Resources.ResourceManager.GetObject(resourceName);
            if (resource is byte[] imageBytes)
            {
                using MemoryStream ms = new(imageBytes);
                pictureBox.Image = Image.FromStream(ms);
            }
            else if (resource is Image img)
            {
                pictureBox.Image = img;
            }
            else
            {
                throw new ArgumentException("Resource not found or not a valid image type.", nameof(resourceName));
            }
        }

        #endregion

        private async void FindVideoButton_Click(object sender, EventArgs e)
        {
            string videoUrl = URLTextBox.Text.Trim();
            if (string.IsNullOrEmpty(videoUrl))
                return;

            string? filePath = await DownloadVideoAsync(videoUrl);
            if (filePath == null)
                return;

            if (AutoPlayAfterDownload)
            {
                var media = new Media(_libVLC, filePath, FromType.FromPath);
                _mediaPlayer.Play(media);

                PlayPauseButton.Text = "Pause";
                PlayerControlsPanel.Enabled = true;

                Invoke(new Action(() =>
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    // Remove the (VIDEOURL) - part
                    int dashIndex = fileName.IndexOf(" - ");
                    if (dashIndex >= 0)
                        fileName = fileName[(dashIndex + 3)..];

                    Text = $"YT-DLP Player - {fileName}";
                    VideoTitleLabel.Text = fileName;
                }));
            }
            GetVideos();
        }
        private async Task<string?> DownloadVideoAsync(string videoUrl)
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            string downloadsDir = Path.Combine(exeDir, "Downloads");
            Directory.CreateDirectory(downloadsDir);

            // Sanitize URL for filenames
            string sanitizedUrl = videoUrl.Replace(":", "").Replace("/", "").Replace("?", "").Replace("&", "").Replace("=", "");
            string outputTemplate = Path.Combine(downloadsDir, $"{sanitizedUrl} - %(title)s.%(ext)s");

            string ytDlpPath = Path.Combine(exeDir, "yt-dlp.exe");

            frm_DownloadingVideo downloadingDialog = new();
            downloadingDialog.Text = "YT-DLP Player - Downloading...";
            downloadingDialog.Show(this);

            // Reset and show the progress bar
            Invoke(() =>
            {
                DownloadProgress_PB.Value = 0;
            });

            // Download the video using yt-dlp
            ProcessStartInfo psi = new()
            {
                FileName = ytDlpPath,
                Arguments = $"-f \"bestvideo[height<=1080][fps<=60]+bestaudio/best[height<=1080]\" --merge-output-format mp4 -o \"{outputTemplate}\" \"{videoUrl}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using Process process = new() { StartInfo = psi };
            process.OutputDataReceived += (s, e) => ParseProgress(e.Data, downloadingDialog);
            process.ErrorDataReceived += (s, e) => ParseProgress(e.Data, downloadingDialog);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();

            // Reset progress bar after completion
            Invoke(() => DownloadProgress_PB.Value = 0);

            downloadingDialog.Close();
            downloadingDialog.Dispose();

            if (process.ExitCode != 0)
            {
                MessageBox.Show("yt-dlp failed to download the video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Get the downloaded video file
            string? downloadedFile = Directory.GetFiles(downloadsDir, $"{sanitizedUrl} - *.mp4")
                                             .OrderByDescending(f => System.IO.File.GetLastWriteTime(f))
                                             .FirstOrDefault();

            // Get the video ID for the thumbnail (for YouTube, assuming the URL contains "v=" parameter)
            string videoId = ExtractVideoIdFromUrl(videoUrl);
            if (string.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("Unable to extract video ID from URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return downloadedFile;
            }

            // Download the thumbnail image
            string thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
            string thumbnailPath = Path.Combine(downloadsDir, $"{sanitizedUrl} - thumbnail.jpg");

            using (var client = new HttpClient())
            {
                try
                {
                    var thumbnailBytes = await client.GetByteArrayAsync(thumbnailUrl);
                    await File.WriteAllBytesAsync(thumbnailPath, thumbnailBytes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to download thumbnail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //if (!AutoPlayAfterDownload)
            //    Check_ShowDownloads.BackColor = Color.FromArgb(240, 0, 54);
            //Check_ShowDownloads.Refresh();
            //await Task.Delay(500).ContinueWith(_ =>
            //{
            //    Invoke(() => Check_ShowDownloads.BackColor = Color.FromArgb(64, 64, 64));
            //});

            return downloadedFile;
        }

        private static string ExtractVideoIdFromUrl(string url)
        {
            // Check for YouTube URL with v= parameter (e.g., https://www.youtube.com/watch?v=dQw4w9WgXcQ)
            var match = Regex.Match(url, @"(?:https?://(?:www\.)?youtube\.com/watch\?v=|youtu\.be/)([a-zA-Z0-9_-]+)");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private void ParseProgress(string? line, frm_DownloadingVideo dialog)
        {
            if (string.IsNullOrWhiteSpace(line)) return;

            if (line.Contains("[download]") && line.Contains('%'))
            {
                var match = Regex.Match(line, @"\[download\]\s+(\d{1,3}\.\d)%");

                if (match.Success && double.TryParse(match.Groups[1].Value, out double progress))
                {
                    // Ensure thread-safe update of UI elements
                    dialog.Invoke(() =>
                    {
                        if (dialog.progressBar1.Style != ProgressBarStyle.Continuous)
                        {
                            dialog.progressBar1.Style = ProgressBarStyle.Continuous;
                        }
                        // Set the progress bar value, ensuring it's capped at 100
                        dialog.progressBar1.Value = Math.Min((int)progress, 100);
                        DownloadProgress_PB.Value = Math.Min((int)progress, 100);

                        // Update the label with the current progress percentage
                        dialog.label1.Text = $"Downloading Video ({progress:0.0}%)";
                    });
                }
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            frm_Settings settingsdialog = new();
            settingsdialog.ShowDialog();
            GetSettings();
            settingsdialog.Dispose();
        }

        private void ControlPanelSize(int SizeType)
        {
            switch (SizeType)
            {
                case 0:
                    ControlPanel.Height = 215; //Standard
                    break;
                case 1:
                    ControlPanel.Height = 111; //HiddenDownloads
                    break;
                case 2:
                    ControlPanel.Height = 68; //Fullscreen
                    break;
                case 3:
                    ControlPanel.Height = 1; //Hidden
                    break;
            }
        }

        private void ControlPanelChangeMode(int Mode)
        {
            switch (Mode)
            {
                case 0: //Standard Mode
                    if (!Check_ShowDownloads.Checked)
                    {
                        ControlPanelSize(0);
                    }
                    else
                    {
                        ControlPanelSize(1);
                    }
                    break;
                case 2: //Fullscreen Mode
                    ControlPanelSize(2);
                    break;
            }
        }

        private bool IsFullscreen = false;
        private Size PreviousSize;
        private bool _cursorHidden = false;
        private Point _lastMousePosition;

        private void btn_FullScreen_Click(object sender, EventArgs e)
        {
            ChangeToFullScreen();
        }

        private void ChangeToFullScreen()
        {
            if (IsFullscreen)
            {
                IsFullscreen = false;
                FullScreenControlHide.Stop();

                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                Size = PreviousSize;

                TopPanel.Show();
                ShowPanel();
                ControlPanelChangeMode(0); // Standard Mode


                videoView1.Cursor = Cursors.Default;
                _cursorHidden = false;

            }
            else
            {
                PreviousSize = Size;

                if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;

                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;

                TopPanel.Hide();
                ControlPanelChangeMode(2); // Fullscreen Mode
                ShowPanel();

                RestartFullScreenTimer();
                IsFullscreen = true;
            }
        }

        private void RestartFullScreenTimer()
        {
            FullScreenControlHide.Stop();
            FullScreenControlHide.Interval = 3000;
            FullScreenControlHide.Start();
        }

        private void videoView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsFullscreen)
            {

                if (e.Location != _lastMousePosition)
                {
                    _lastMousePosition = e.Location;

                    RestartFullScreenTimer();

                    ShowPanel();

                    if (_cursorHidden)
                    {
                        videoView1.Cursor = Cursors.Default;
                        _cursorHidden = false;
                    }
                }
            }
        }

        private void FullScreenControlHide_Tick(object sender, EventArgs e)
        {
            if (!IsFullscreen)
                return;

            HidePanel();
            videoView1.Cursor = _emptyCursor;
            _cursorHidden = true;

            FullScreenControlHide.Stop();
        }

        private void PlayerControlsPanel_MouseEnter(object sender, EventArgs e)
        {
            FullScreenControlHide.Stop();
            ShowPanel();

            if (_cursorHidden)
            {
                videoView1.Cursor = Cursors.Default;
                _cursorHidden = false;
            }
        }

        private void PlayerControlsPanel_MouseLeave(object sender, EventArgs e)
        {
            RestartFullScreenTimer();

            ShowPanel();

            if (_cursorHidden)
            {
                videoView1.Cursor = Cursors.Default;
                _cursorHidden = false;
            }
        }

        private void videoView1_MouseLeave(object sender, EventArgs e)
        {
            FullScreenControlHide.Stop();
            ShowPanel();

            if (_cursorHidden)
            {
                videoView1.Cursor = Cursors.Default;
                _cursorHidden = false;
            }
        }

        private bool showtip = true;
        private void ShowPanel()
        {
            if (IsFullscreen)
            {
                ControlPanelChangeMode(2); // Fullscreen Mode
                SeekTrackBar.Show();
                ControlPanel.BackColor = Color.FromArgb(26, 26, 26);
            }
        }
        private void HidePanel()
        {
            if (IsFullscreen)
            {
                if (showtip)
                {
                    toolTip1.Show("Move mouse to bottom to reveal controls, or press ESC to exit fullscreen.", ControlPanel, 5000);
                    showtip = false;
                }
                ControlPanelSize(3); // Hidden
                SeekTrackBar.Hide();
                ControlPanel.BackColor = Color.Black;
            }
        }

        private void DownloadQueue_Click(object sender, EventArgs e)
        {
            frm_DownloadQueue downloadQueue = new();
            downloadQueue.Show();
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowDownloads_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (!Check_ShowDownloads.Checked)
            {
                ControlPanelSize(0);
                Check_ShowDownloads.Text = "Hide Downloads";
            }
            else
            {
                ControlPanelSize(1);
                Check_ShowDownloads.Text = "Show Downloads";
            }
        }
        #region Hotkeys
        // Open the hotkeys dialog form
        private void button1_Click(object sender, EventArgs e)
        {
            Hotkeys.frm_Hotkeys hotkeysForm = new();
            hotkeysForm.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (IsFullscreen && keyData == Keys.Escape)
            {
                ShowPanel();
                ControlPanel.BackColor = Color.FromArgb(26, 26, 26);
                ChangeToFullScreen();
                return true;

            }
            if (URLTextBox.Focused || RecentVideosFlow.Focused || PlayerControlsPanel.Focused)
            {
                // If any of these controls are focused, do not process hotkeys
                return base.ProcessCmdKey(ref msg, keyData);
            }
            // Call hotkey handler
            if (HandlePlayerHotkey(keyData))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsFullscreen && e.KeyCode == Keys.Escape)
            {
                ShowPanel();
                ChangeToFullScreen();
                e.Handled = true;
            }

        }

        private bool HandlePlayerHotkey(Keys keyData)
        {
            // Map Keys to HotKeys.settings property names
            string? hotkeyName = keyData switch
            {
                Keys.D1 or Keys.NumPad1 => "K1",
                Keys.D2 or Keys.NumPad2 => "K2",
                Keys.D3 or Keys.NumPad3 => "K3",
                Keys.D4 or Keys.NumPad4 => "K4",
                Keys.D5 or Keys.NumPad5 => "K5",
                Keys.D6 or Keys.NumPad6 => "K6",
                Keys.D7 or Keys.NumPad7 => "K7",
                Keys.D8 or Keys.NumPad8 => "K8",
                Keys.D9 or Keys.NumPad9 => "K9",
                Keys.D0 or Keys.NumPad0 => "K0",
                Keys.Q => "Q",
                Keys.W => "W",
                Keys.E => "E",
                Keys.R => "R",
                Keys.T => "T",
                Keys.Y => "Y",
                Keys.U => "U",
                Keys.I => "I",
                Keys.O => "O",
                Keys.P => "P",
                Keys.A => "A",
                Keys.S => "S",
                Keys.D => "D",
                Keys.F => "F",
                Keys.G => "G",
                Keys.H => "H",
                Keys.J => "J",
                Keys.K => "K",
                Keys.L => "L",
                Keys.Z => "Z",
                Keys.X => "X",
                Keys.C => "C",
                Keys.V => "V",
                Keys.B => "B",
                Keys.N => "N",
                Keys.M => "M",
                Keys.Oemcomma => "Comma",
                Keys.OemPeriod => "Period",
                Keys.OemQuestion => "ForwardSlash",
                Keys.Insert => "Insert",
                Keys.Delete => "Delete",
                Keys.Home => "Home",
                Keys.End => "End",
                Keys.PageUp => "PageUp",
                Keys.PageDown => "PageDown",
                Keys.Space => "Space",
                Keys.Left => "ArrowLeft",
                Keys.Right => "ArrowRight",
                Keys.Up => "ArrowUp",
                Keys.Down => "ArrowDown",
                _ => null
            };

            if (hotkeyName == null)
                return false;

            // Get the action string from settings
            string action = YT_DLP.player.Hotkeys.HotKeys.Default[hotkeyName]?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(action))
                return false;

            // Perform the action
            return PerformHotkeyAction(action);
        }
        private bool PerformHotkeyAction(string action)
        {
            // You can use a switch or if-else to match action strings
            switch (action)
            {
                case "Play/pause player":
                    PlayPauseButton.PerformClick();
                    return true;
                case "Seek back 10 seconds":
                    SeekRelative(-10);
                    return true;
                case "Seek forward 10 seconds":
                    SeekRelative(10);
                    return true;
                case "Seek back 5 seconds":
                    SeekRelative(-5);
                    return true;
                case "Seek forward 5 seconds":
                    SeekRelative(5);
                    return true;
                case "Increase volume 5%":
                    ChangeVolume(5);
                    return true;
                case "Decrease volume 5%":
                    ChangeVolume(-5);
                    return true;
                case "Mute/unmute player":
                    MuteButton.PerformClick();
                    return true;
                case "Activate/exit fullscreen":
                    if (IsFullscreen)
                    {
                        ShowPanel();
                        ControlPanel.BackColor = Color.FromArgb(26, 26, 26);
                        ChangeToFullScreen();
                    }
                    else
                    {
                        btn_FullScreen.PerformClick();
                    }
                    return true;
                case "Seek to begining":
                    _mediaPlayer.Time = 0;
                    return true;
                case "Seek to end":
                    _mediaPlayer.Time = _mediaPlayer.Length;
                    return true;
                case "Skip player to 10%":
                    SeekToPercentage(0.1);
                    return true;
                case "Skip player to 20%":
                    SeekToPercentage(0.2);
                    return true;
                case "Skip player to 30%":
                    SeekToPercentage(0.3);
                    return true;
                case "Skip player to 40%":
                    SeekToPercentage(0.4);
                    return true;
                case "Skip player to 50%":
                    SeekToPercentage(0.5);
                    return true;
                case "Skip player to 60%":
                    SeekToPercentage(0.6);
                    return true;
                case "Skip player to 70%":
                    SeekToPercentage(0.7);
                    return true;
                case "Skip player to 80%":
                    SeekToPercentage(0.8);
                    return true;
                case "Skip player to 90%":
                    SeekToPercentage(0.9);
                    return true;
                case "Go to URL box":
                    URLTextBox.Focus();
                    URLTextBox.SelectAll();
                    return true;
                case "Go back previous frame":
                    GoToPreviousFrame();
                    return true;
                case "Skip to next frame":
                    GoToNextFrame();
                    return true;
                default:
                    return false;
            }
        }

        // Helper methods
        private void GoToNextFrame()
        {
            if (_mediaPlayer == null) return;
            if (_mediaPlayer.IsPlaying)
                _mediaPlayer.Pause();

            _mediaPlayer.NextFrame();
        }
        private void GoToPreviousFrame()
        {
            MessageBox.Show("This feature is not implemented yet, but will be in a future update.", "Unimplemented Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void SeekToPercentage(double percentage)
        {
            if (_mediaPlayer == null || _mediaPlayer.Length <= 0) return;
            long newTime = (long)(_mediaPlayer.Length * percentage);
            _mediaPlayer.Time = newTime;
        }
        private void SeekRelative(int seconds)
        {
            if (_mediaPlayer == null || _mediaPlayer.Length <= 0) return;
            long newTime = Math.Max(0, Math.Min(_mediaPlayer.Time + seconds * 1000, _mediaPlayer.Length));
            _mediaPlayer.Time = newTime;
        }

        private void ChangeVolume(int delta)
        {
            if (_mediaPlayer.Mute)
            {
                MuteButton.PerformClick();
            }
            int newVolume = Math.Max(0, Math.Min(100, _mediaPlayer.Volume + delta));
            _mediaPlayer.Volume = newVolume;
            VolumeTrackBar.Value = newVolume;
            VolumeLabel.Text = $"Volume {newVolume}%";
        }

        #endregion

        private void MuteButton_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Mute = !_mediaPlayer.Mute;
            if (!_mediaPlayer.Mute)
            {
                MuteButton.Text = "Unmute";
                VolumeTrackBar.Enabled = false;
                VolumeLabel.Text = "Volume Muted";
            }
            else
            {
                MuteButton.Text = "Mute";
                VolumeTrackBar.Enabled = true;
                VolumeLabel.Text = $"Volume {VolumeTrackBar.Value}%";
            }
        }

        private void URLTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    e.SuppressKeyPress = true;
                    videoView1.Focus();
                    FindVideoButton.PerformClick();
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    videoView1.Focus();
                    break;
            }

        }

        private void dlpButton1_Click(object sender, EventArgs e)
        {
            NotificationPanel.Hide();
        }
    }
}
