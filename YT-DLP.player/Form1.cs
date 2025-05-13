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

namespace YT_DLP.player
{
    public partial class Form1 : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        private string YTDLPMirrorLink = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
        private string FFMPEGZipUrl = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";

        private Cursor _emptyCursor;

        public Form1()
        {
            Properties.Settings.Default.Reload();
            InitializeComponent();
            EnableDarkTitleBar(Handle);

            // Initialize non-nullable fields to avoid CS8618 warnings
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            _emptyCursor = new Cursor("EmptyCursor.cur");
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

            VolumeTrackBar.Value = DefaultVolume;
            VolumeLabel.Text = $"Volume {VolumeTrackBar.Value}%";
        }
        #endregion

        private async void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            //Form2 form2 = new();
            //form2.Show();
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
            ApplyBasicSettings();
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
                var videoControl = new YT_DLP.player.DownloadedVideos
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
                                using (var client = new HttpClient())
                                {
                                    var thumbnailBytes = await client.GetByteArrayAsync(thumbnailUrl);
                                    using (var ms = new MemoryStream(thumbnailBytes))
                                    {
                                        var thumbnailImage = Image.FromStream(ms);
                                        Invoke(() => videoControl.pictureBox1.Image = thumbnailImage);
                                    }
                                }
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

        private string CleanUrl(string url)
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

        private void trackBar2_Scroll(object sender, EventArgs e)
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
                ControlPanel.Height = 215;
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
                    ControlPanel.Height = 215;
                }
            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show optional closing dialog
            Closing closing = new Closing();
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

                // Wait a moment to ensure file handles are released
                System.Threading.Thread.Sleep(300);

                if (DeleteOnClose)
                {
                    // Delete all media files in the Downloads folder
                    string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
                    string downloadsDir = Path.Combine(exeDir, "Downloads");

                    if (Directory.Exists(downloadsDir))
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

        private async Task<bool> DownloadAndExtractFFmpegAsync(string destinationPath, PictureBox statusIcon)
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
                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromMinutes(5); // Set timeout to 5 minutes (or adjust as needed)

                        using (HttpResponseMessage response = await client.GetAsync(FFMPEGZipUrl))
                        {
                            response.EnsureSuccessStatusCode();

                            await using (FileStream fs = new FileStream(tempZipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                await response.Content.CopyToAsync(fs);
                            }
                        }
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

            DownloadingDialog downloadingdialog = new();
            ChangeArrow(downloadingdialog.pictureBox1, "RightArrowShort_Grey");
            ChangeArrow(downloadingdialog.pictureBox2, "RightArrowShort_Grey");

            downloadingdialog.Show();
            Application.DoEvents();
            Enabled = false;

            using HttpClient client = new HttpClient();

            try
            {
                // yt-dlp
                if (!System.IO.File.Exists(ytDlpPath))
                {
                    ChangeArrow(downloadingdialog.pictureBox1, "RightArrowShort_Blue");

                    using HttpResponseMessage response = await client.GetAsync(YTDLPMirrorLink);
                    response.EnsureSuccessStatusCode();

                    using FileStream fs = new FileStream(ytDlpPath, FileMode.Create, FileAccess.Write, FileShare.None);
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


        private void ChangeArrow(PictureBox pictureBox, string resourceName)
        {
            object? resource = Properties.Resources.ResourceManager.GetObject(resourceName);
            if (resource is byte[] imageBytes)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
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

        //private void FindVideoButton_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(URLTextBox.Text))
        //    {
        //        using var media = new Media(_libVLC, "d:\\Videos\\Animepahe Jujutsu Kaisen - 29 1080P Subsplease.mp4");
        //        _mediaPlayer.Play(media);
        //    }
        //    PlayPauseButton.Text = "Pause";
        //    PlayerControlsPanel.Enabled = true;
        //
        //    Invoke(new Action(() =>
        //    {
        //        if (_mediaPlayer.Media?.Mrl != null)
        //        {
        //            // Convert MRL (media resource locator) to a file path
        //            var uri = new Uri(_mediaPlayer.Media.Mrl);
        //            string fileName = Path.GetFileNameWithoutExtension(uri.LocalPath);
        //
        //            Text = $"YT-DLP Player - {fileName}";
        //            VideoTitleLabel.Text = fileName;
        //        }
        //        else
        //        {
        //            Text = "YT-DLP Player";
        //            VideoTitleLabel.Text = "Unknown Title";
        //        }
        //    }));
        //}

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

            DownloadingVideo downloadingDialog = new DownloadingVideo();
            downloadingDialog.Text = "YT-DLP Player - Downloading...";
            downloadingDialog.Show(this);

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

            return downloadedFile;
        }

        private string ExtractVideoIdFromUrl(string url)
        {
            // Check for YouTube URL with v= parameter (e.g., https://www.youtube.com/watch?v=dQw4w9WgXcQ)
            var match = Regex.Match(url, @"(?:https?://(?:www\.)?youtube\.com/watch\?v=|youtu\.be/)([a-zA-Z0-9_-]+)");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private void ParseProgress(string? line, DownloadingVideo dialog)
        {
            if (string.IsNullOrWhiteSpace(line)) return;

            if (line.Contains("[download]") && line.Contains("%"))
            {
                var match = Regex.Match(line, @"\[download\]\s+(\d{1,3}\.\d)%");

                if (match.Success && double.TryParse(match.Groups[1].Value, out double progress))
                {
                    // Ensure thread-safe update of UI elements
                    dialog.Invoke(() =>
                    {
                        // Change style to Continuous to reflect accurate progress
                        if (dialog.progressBar1.Style != ProgressBarStyle.Continuous)
                        {
                            dialog.progressBar1.Style = ProgressBarStyle.Continuous;
                        }

                        // Set the progress bar value, ensuring it's capped at 100
                        dialog.progressBar1.Value = Math.Min((int)progress, 100);

                        // Update the label with the current progress percentage
                        dialog.label1.Text = $"Downloading Video ({progress:0.0}%)";
                    });
                }
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settingsdialog = new();
            settingsdialog.ShowDialog();
            GetSettings();
            settingsdialog.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool IsFullscreen = false;
        private Size PreviousSize;
        private bool _cursorHidden = false;
        private Point _lastMousePosition;

        private void dlpButton2_Click(object sender, EventArgs e)
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
                ControlPanel.Height = 215;


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
                ControlPanel.Height = 68;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (IsFullscreen && keyData == Keys.Escape)
            {
                ShowPanel();
                ControlPanel.BackColor = Color.FromArgb(26, 26, 26);
                ChangeToFullScreen();
                return true;

            }

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
                ControlPanel.Height = 68;
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
                    toolTip1.Show("Move mouse to bottom to reveal controls, or press ESC to exit fullscreen.", ControlPanel);
                    showtip = false;
                }
                ControlPanel.Height = 1;
                SeekTrackBar.Hide();
                ControlPanel.BackColor = Color.Black;
            }
        }

        private void DownloadQueue_Click(object sender, EventArgs e)
        {
            DownloadQueue downloadQueue = new();
            downloadQueue.Show();
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
