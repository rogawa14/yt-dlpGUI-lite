using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        string configFile = "config.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(DataFormats.Text) as string;
            if (text != null && text.StartsWith("http"))
                UrlBox.Text = text;
        }

        private async void UrlBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string url = UrlBox.Text;

            if (!url.StartsWith("http"))
                return;

            TitleText.Text = "取得中...";

            await Task.Run(() =>
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "yt-dlp.exe",
                        Arguments = $"--dump-json {url}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process p = Process.Start(psi);
                    string json = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();

                    var doc = JsonDocument.Parse(json);

                    string title = doc.RootElement.GetProperty("title").GetString();
                    string thumbnail = doc.RootElement.GetProperty("thumbnail").GetString();
                    string uploader = doc.RootElement.GetProperty("uploader").GetString();
                    long views = doc.RootElement.GetProperty("view_count").GetInt64();

                    double sizeMB = 0;
                    if (doc.RootElement.TryGetProperty("filesize", out var size))
                        sizeMB = size.GetDouble() / 1024 / 1024;

                    int duration = 0;
                    if (doc.RootElement.TryGetProperty("duration", out var dur))
                        duration = dur.GetInt32();

                    string time = TimeSpan.FromSeconds(duration).ToString();

                    Dispatcher.Invoke(() =>
                    {
                        TitleText.Text = title;
                        ChannelText.Text = "チャンネル: " + uploader;
                        ViewsText.Text = "再生回数: " + views.ToString("N0");
                        SizeText.Text = "サイズ: " + sizeMB.ToString("0.0") + " MB";
                        DurationText.Text = "動画時間: " + time;
                        ThumbnailImage.Source = new BitmapImage(new Uri(thumbnail));
                    });
                }
                catch
                {
                    Dispatcher.Invoke(() =>
                    {
                        TitleText.Text = "取得失敗";
                    });
                }
            });
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.CheckFileExists = false;
            dialog.FileName = "folder";

            if (dialog.ShowDialog() == true)
            {
                FolderBox.Text = Path.GetDirectoryName(dialog.FileName);
                SaveConfig();
            }
        }

        private async void Download_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlBox.Text;
            string folder = FolderBox.Text;
            string quality = ((ComboBoxItem)QualityBox.SelectedItem).Content.ToString();

            string args;

            if (Mp3Radio.IsChecked == true)
            {
                args = $"-x --audio-format mp3 -o \"%(title)s.%(ext)s\" -P \"{folder}\" {url}";
            }
            else
            {
                if (quality == "1080p")
                    args = $"-f \"bv*[ext=mp4][height<=1080]+ba[ext=m4a]/b[ext=mp4][height<=1080]\" --merge-output-format mp4 -o \"%(title)s.%(ext)s\" -P \"{folder}\" {url}";
                else
                    args = $"-f \"bv*[ext=mp4][height<=720]+ba[ext=m4a]/b[ext=mp4][height<=720]\" --merge-output-format mp4 -o \"%(title)s.%(ext)s\" -P \"{folder}\" {url}";
            }

            await Task.Run(() => RunYtDlp(args));

            Dispatcher.Invoke(() =>
            {
                StatusText.Text = "完了";
                ProgressBar.Value = 100;
                MessageBox.Show("ダウンロード完了");
            });
        }

        private void RunYtDlp(string args)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "yt-dlp.exe",
                Arguments = args,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process();
            process.StartInfo = psi;

            process.OutputDataReceived += (s, e) =>
            {
                if (e.Data == null) return;

                Match progress = Regex.Match(e.Data, @"(\d{1,3}\.\d)%");
                Match speed = Regex.Match(e.Data, @"(\d+\.\d+\w+/s)");

                Dispatcher.Invoke(() =>
                {
                    if (progress.Success)
                    {
                        double percent = double.Parse(progress.Groups[1].Value);
                        ProgressBar.Value = percent;
                        StatusText.Text = percent + "%";
                    }

                    if (speed.Success)
                        SpeedText.Text = "速度: " + speed.Groups[1].Value;
                });
            };

            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("yt-dlp.exe", "-U");
        }

        private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            if (DarkModeToggle.IsChecked == true)
            {
                Background = Brushes.Black;
                Foreground = Brushes.White;
            }
            else
            {
                Background = Brushes.White;
                Foreground = Brushes.Black;
            }
        }

        private void SaveConfig()
        {
            File.WriteAllText(configFile, FolderBox.Text);
        }

        private void LoadConfig()
        {
            if (File.Exists(configFile))
                FolderBox.Text = File.ReadAllText(configFile);
        }
    }
}