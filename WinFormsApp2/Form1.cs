using Microsoft.Win32;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public static class DarkModeHelper
        {
            [DllImport("dwmapi.dll")]
            private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

            private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20; // Windows 10 1809+

            public static void UseImmersiveDarkMode(Form form, bool enabled)
            {
                if (Environment.OSVersion.Version.Major >= 10)
                {
                    int useDark = enabled ? 1 : 0;
                    DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));
                }
            }
        }
        // SoundPlayer to handle music playback
        private SoundPlayer soundPlayer;
        private bool isMuted = false;
        private bool isPlaying = false;

        private readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            // Load the sound from the embedded resource
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "WinFormsApp2.sound.wav"; // Ensure this matches the namespace and file name

            // Get the stream without using "using", so it doesn't dispose immediately
            Stream resourceStream = assembly.GetManifestResourceStream(resourceName);

            // Initialize the SoundPlayer with the stream
            soundPlayer = new SoundPlayer(resourceStream);

            // Autoplay sound as soon as the form is loaded
            soundPlayer.PlayLooping(); // Use Play() for single play, PlayLooping() for continuous play
            isPlaying = true;
        }


        private void ApplyTheme(Control parent, bool dark)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.BackColor = dark ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
                ctrl.ForeColor = dark ? Color.White : Color.Black;

                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = dark ? Color.Gray : SystemColors.ControlDark;
                    btn.FlatAppearance.BorderSize = dark ? 1 : 0;
                }
                else if (ctrl is TextBox tb)
                {
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.BackColor = dark ? Color.FromArgb(50, 50, 50) : Color.White;
                    tb.ForeColor = dark ? Color.White : Color.Black;
                }
                else if (ctrl is ProgressBar pb)
                {
                    pb.Style = ProgressBarStyle.Continuous;
                    pb.BackColor = dark ? Color.Gray : SystemColors.Control;
                }
                else if (ctrl is CheckBox cb)
                {
                    cb.BackColor = dark ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
                    cb.ForeColor = dark ? Color.White : Color.Black;
                    cb.UseVisualStyleBackColor = dark;
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = dark ? Color.FromArgb(50, 50, 50) : Color.White;
                    cmb.ForeColor = dark ? Color.White : Color.Black;
                    cmb.FlatStyle = FlatStyle.Flat;

                }

                if (ctrl.HasChildren)
                    ApplyTheme(ctrl, dark);
            }
        }


        // Add this at the class level
        private bool isDarkMode = false;


        private bool IsSystemInDarkMode()
        {
            const string userRoot = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string keyName = "AppsUseLightTheme";

            object registryValue = Registry.GetValue(userRoot, keyName, null);
            if (registryValue is int useLightTheme)
            {
                return useLightTheme == 0; // 0 = Dark, 1 = Light
            }

            // Default to light mode if value not found
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnInstall.Enabled = false;
            isDarkMode = IsSystemInDarkMode();

            // Apply the dark mode to the form and title bar
            DarkModeHelper.UseImmersiveDarkMode(this, isDarkMode);

            // Set the form's background color and apply theme
            this.BackColor = isDarkMode ? Color.Black : Color.White;
            ApplyTheme(this, isDarkMode);

            // Set button text based on the current mode
            button2.Text = isDarkMode ? "☀️" : "🌙";

            comboBox1.SelectedItem = "v1.9.0";
            comboBox2.SelectedItem = "experimental";
            comboBox3.SelectedItem = "evolution";
            comboBox4.SelectedItem = "normal";
            comboBox5.SelectedItem = "🇵🇱";
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtGameDir.Text = dialog.SelectedPath;
                string atPdbPath = Path.Combine(dialog.SelectedPath, "at.pdb");
                if (File.Exists(atPdbPath))
                {
                    btnInstall.Text = "Uninstall";
                }
                else
                {
                    btnInstall.Text = "Install";
                }
                btnInstall.Enabled = true;
            }
        }
        private record FileDownload(string FileName, string Url);

        private FileDownload[] GetVersionFiles(string version)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return version switch
            {
                "v1.2H3" => new[]
                {
            new FileDownload("AT.exe", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.2H3/AT.exe"),
            new FileDownload("AT.pdb", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.2H3/AT.pdb"),
            new FileDownload("Dependencies.zip", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.2H3/Dependencies.zip")
        },

                "v1.6.2P" => new[]
                {
            new FileDownload("AT.exe", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.6.2P/AT.exe"),
            new FileDownload("AT.pdb", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.6.2P/AT.pdb"),
            new FileDownload("Dependencies.zip", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.6.2P/Dependencies.zip")
        },

                "v1.7.2-preview" => new[]
                {
            new FileDownload("AT-1.7.2-preview-windows.zip", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.7.2-preview/AT-1.7.2-preview-windows.zip")
        },

                "v1.8.0-preview" => new[]
                {
            new FileDownload("AT-1.8.0-preview-windows.zip", "https://github.com/WizzardMaker/AirlineTycoon/releases/download/v1.8.0-preview/AT-1.8.0-preview-windows.zip")
        },
                "v1.8.4" => new[]
        {
            new FileDownload("AT-1.8.4-windows.zip", "https://github.com/mertenpopp/AirlineTycoon/releases/download/v1.8.4/AT-1.8.4-windows.zip")
        },
                "v1.9.0" => new[]
        {
            new FileDownload("AT-1.9.0-windows.zip", "https://github.com/mertenpopp/AirlineTycoon/releases/download/v1.9.0/AT-1.9.0-windows.zip")
        },

                _ => null
            };
#pragma warning restore CS8603 // Possible null reference return.
        }

        private async Task InstallAirlineTycoon(string tempDir, string gameDir, string selectedVersion)
        {
            var versionFiles = GetVersionFiles(selectedVersion);
            if (versionFiles == null)
            {
                lblStatus.Text = "Unknown version selected.";
                return;
            }

            int totalSteps = versionFiles.Length * 2; // Download + install
            int currentStep = 0;

            foreach (var file in versionFiles)
            {
                lblStatus.Text = $"Downloading {file.FileName}...";
                string localPath = Path.Combine(tempDir, file.FileName);
                byte[] data = await httpClient.GetByteArrayAsync(file.Url);
                await File.WriteAllBytesAsync(localPath, data);

                currentStep++;
                progressBar1.Value = 5 + (int)((float)currentStep / totalSteps * 90);

                if (file.FileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    lblStatus.Text = $"Extracting {file.FileName}...";
                    string extractPath = Path.Combine(tempDir, Path.GetFileNameWithoutExtension(file.FileName));
                    if (Directory.Exists(extractPath))
                        Directory.Delete(extractPath, true);

                    ZipFile.ExtractToDirectory(localPath, extractPath);

                    // Optional: Use CopyAll for full overwrite control
                    CopyAll(new DirectoryInfo(extractPath), new DirectoryInfo(gameDir));

                    File.Delete(localPath); // clean up zip
                }
                else
                {
                    string destPath = Path.Combine(gameDir, file.FileName);
                    if (File.Exists(destPath))
                        File.Delete(destPath);

                    File.Copy(localPath, destPath);
                }

                currentStep++;
                progressBar1.Value = 5 + (int)((float)currentStep / totalSteps * 90);
            }

            lblStatus.Text = "Installation complete.";
            progressBar1.Value = 100;
        }



        private async Task UninstallMods(string gameDir)
        {
            string[] filesToDelete = {
        "AT.exe", "AT.pdb", "cnc-ddraw config.exe", "crashpad_handler.exe",
        "crashpad_wer.dll", "ddraw.dll", "ddraw.ini", "libFLAC-8.dll",
        "libfreetype-6.dll", "libjpeg-9.dll", "libmodplug-1.dll", "libmpg123-0.dll",
        "libogg-0.dll", "libopus-0.dll", "libopusfile-0.dll", "libpng16-16.dll",
        "libtiff-5.dll", "libvorbis-0.dll", "libvorbisfile-3.dll", "libwebp-7.dll",
        "SDL2.dll", "SDL2_image.dll", "SDL2_mixer.dll", "SDL2_ttf.dll",
        "sentry.dll", "zlib1.dll", "cnc-ddraw config.exe"
    };

            string[] dirsToDelete = { "patch", "Shaders" };

            lblStatus.Text = "Uninstalling mods...";
            progressBar1.Value = 0;

            foreach (string file in filesToDelete)
            {
                string filePath = Path.Combine(gameDir, file);
                if (File.Exists(filePath))
                {
                    try { File.Delete(filePath); } catch { /* Log or ignore */ }
                }
                progressBar1.Value += 1;
            }

            foreach (string dir in dirsToDelete)
            {
                string dirPath = Path.Combine(gameDir, dir);
                if (Directory.Exists(dirPath))
                {
                    try { Directory.Delete(dirPath, true); } catch { /* Log or ignore */ }
                }
                progressBar1.Value += 5;
            }

            string backupDir = Path.Combine(gameDir, "BACKUP");
            string backupExe = Path.Combine(backupDir, "at.exe");
            string restorePath = Path.Combine(gameDir, "at.exe");

            if (File.Exists(backupExe))
            {
                try { File.Move(backupExe, restorePath); } catch { MessageBox.Show("Failed to restore backup at.exe."); }
            }

            if (Directory.Exists(backupDir))
            {
                try { Directory.Delete(backupDir, true); } catch { /* Log or ignore */ }
            }

            lblStatus.Text = "Uninstallation complete.";
            progressBar1.Value = 100;
        }


        private async void btnInstall_Click(object sender, EventArgs e)
        {
            string gameDir = txtGameDir.Text;
            if (!Directory.Exists(gameDir))
            {
                MessageBox.Show("Invalid directory.");
                return;
            }

            if (btnInstall.Text == "Uninstall")
            {
                await UninstallMods(gameDir);
                MessageBox.Show("Uninstall completed.");
                this.Close();
                return;
            }

            // Check if checkbox1 is ticked, if not, do not proceed with the installation
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Please agree to the terms before proceeding with the installation.");
                return;
            }

            // Backup at.exe if it exists
            string atExePath = Path.Combine(gameDir, "at.exe");
            if (File.Exists(atExePath))
            {
                string backupDir = Path.Combine(gameDir, "BACKUP");
                // Create the backup directory if it doesn't exist
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }

                // Move the at.exe to the backup folder
                string backupAtExePath = Path.Combine(backupDir, "at.exe");
                try
                {
                    File.Move(atExePath, backupAtExePath);
                    //MessageBox.Show("at.exe has been backed up.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to move at.exe: {ex.Message}");
                    return; // Exit if backup fails
                }

            }
            else
            {
                MessageBox.Show("Invalid directory, select the folder with at.exe.");
                return;
            }

            progressBar1.Value = 0;
            lblStatus.Text = "Starting installation...";

            string tempPath = Path.Combine(Path.GetTempPath(), "ModInstallerTemp");
            Directory.CreateDirectory(tempPath);

            // Check if checkbox2 (cnc-ddraw mod) is ticked and install if so
            if (checkBox2.Checked)
            {
                // Get selected version from comboBox1
                string selectedVersion = comboBox2.SelectedItem.ToString();
                //
                if (selectedVersion == "experimental")
                {
                    await InstallMod(
                    "https://github.com/FunkyFr3sh/cnc-ddraw/releases/download/experimental/cnc-ddraw-experimental-release.zip",
                    tempPath,
                    gameDir,
                    "cnc-ddraw-experimental-release.zip",
                    10);
                }
                else
                {
                    await InstallMod(
                    "https://github.com/FunkyFr3sh/cnc-ddraw/releases/download/v7.1.0.0/cnc-ddraw.zip",
                    tempPath,
                    gameDir,
                    "cnc-ddraw.zip",
                    10);
                }
            }


            // Check if checkbox3 (AirlineTycoon) is ticked and install if so
            if (checkBox3.Checked)
            {
                // Get selected version from comboBox1
                string selectedVersion = comboBox1.SelectedItem.ToString();
                await InstallAirlineTycoon(tempPath, gameDir, selectedVersion);
            }


            if (checkBox4.Checked)
            {
                // Install the ddraw.ini mod
                await InstallMod(
                    "https://raw.githubusercontent.com/rockysx27/v6config/main/ddraw.ini", // Correct raw URL
                    tempPath,
                    gameDir,
                    "ddraw.ini",  // Name the file "ddraw.ini" when saving
                    10);  // Progress start value

                // Get the selected language
                string selectedLanguage = comboBox5.SelectedItem.ToString();
                int languageCode = selectedLanguage switch
                {
                    "🇩🇪" => 0,
                    "🇬🇧" => 1,
                    "🇺🇸" => 1,
                    "🇫🇷" => 2,
                    "🇪🇸" => 7,
                    "🇵🇱" => 8,
                    "🇧🇷" => 9,
                    "🇷🇺" => 10,
                    _ => 1 // Default to 'en' if the language is not found
                };

                // Get the selected difficulty
                string selectedVersion = comboBox4.SelectedItem.ToString();
                int maxDifficulty1 = 142;
                int maxDifficulty2 = 111;
                int maxDifficulty3 = 298;

                if (selectedVersion == "hard")
                {
                    maxDifficulty1 = 200;  // between 111 and 298
                    maxDifficulty2 = 180;  // between 111 and 298
                    maxDifficulty3 = 280;  // between 111 and 298
                }
                else if (selectedVersion == "hardcore")
                {
                    maxDifficulty1 = 260;  // between 111 and 298
                    maxDifficulty2 = 240;  // between 111 and 298
                    maxDifficulty3 = 298;  // max allowed
                }

                // Construct the at.json file content
                string atJsonContent = $@"
{{
    ""OptionLanguage"": {languageCode},
    ""bConfigNoVgaRam"": 0,
    ""bConfigNoSpeedyMouse"": 0,
    ""bConfigWinMouse"": 0,
    ""bConfigNoDigiSound"": 0,
    ""OptionFullscreen"": 2,
    ""OptionKeepAspectRatio"": false,
    ""OptionTicketPriceIncrement"": 10,
    ""OptionRentOfficeTriggerPercent"": 20,
    ""OptionRentOfficeMinAvailable"": 0,
    ""OptionRentOfficeMaxAvailable"": 3,
    ""OptionScreenWindowedWidth"": 1920,
    ""OptionScreenWindowedHeight"": 1080,
    ""OptionPlanes"": true,
    ""OptionPassengers"": true,
    ""OptionMusicType"": 2,
    ""OptionEnableDigi"": true,
    ""OptionMusik"": 3,
    ""OptionLoopMusik"": 0,
    ""OptionAmbiente"": 3,
    ""OptionRealKuerzel"": true,
    ""OptionDurchsagen"": 3,
    ""OptionPlaneVolume"": 3,
    ""OptionEffekte"": 3,
    ""OptionGirl"": true,
    ""OptionBerater"": true,
    ""OptionBriefBriefing"": true,
    ""OptionBlenden"": true,
    ""OptionTransparenz"": true,
    ""OptionSchatten"": true,
    ""OptionAirport"": 16777330,
    ""OptionThinkBubbles"": true,
    ""OptionFlipping"": false,
    ""Sim.MaxDifficulty"": {maxDifficulty1},
    ""Sim.MaxDifficulty2"": {maxDifficulty2},
    ""Sim.MaxDifficulty3"": {maxDifficulty3},
    ""OptionAutosave"": true,
    ""OptionFax"": true,
    ""OptionRoundNumber"": true,
    ""Sim.GameSpeed"": 30,
    ""OptionViewedIntro"": true,
    ""OptionTalking"": 7,
    ""OptionSpeechBubble"": true,
    ""OptionRandomStartday"": true,
    ""OptionRoomDescription"": 1026,
    ""&AppPath"": ""C:\\GOG Games\\Airline Tycoon Deluxe\\"",
    ""OptionLastPlayer"": 1,
    ""KeyHints1"": 0,
    ""KeyHints2"": 0,
    ""OptionLastMission"": 0,
    ""OptionLastMission3"": 41,
    ""OptionLastMission2"": 11,
    ""OptionLastProvider"": 0,
    ""OptionMasterServer"": ""master.open-airlinetycoon.com"",
    ""Player0"": ""TINA CORTEZ          "",
    ""Player1"": ""SIGGI SORGLOS        "",
    ""Player2"": ""IGOR TUPPOLEVSKY     "",
    ""Player3"": ""MARIO ZUCCHERO       "",
    ""OptionMasterVolume"": 7
}}";

                // Save the constructed at.json content to the game directory
                await File.WriteAllTextAsync(Path.Combine(gameDir, "at.json"), atJsonContent);
            }

            // THEN install spolszczenie
            if (checkBox5.Checked)
            {

                // Run the game once to initialize on the new engine
                string atPath = Path.Combine(gameDir, "AT.exe");
                if (File.Exists(atPath))
                {
                    lblStatus.Text = "Launching game to complete initialization...";
                    var process = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = atPath,
                        WorkingDirectory = gameDir,
                        UseShellExecute = true
                    });

                    lblStatus.Text = "Waiting up to 20s for OpenGL initialization...";

                    int maxWaitMs = 20000;
                    int pollIntervalMs = 500;
                    int waitedMs = 0;

                    while (!process.HasExited && waitedMs < maxWaitMs)
                    {
                        await Task.Delay(pollIntervalMs);
                        waitedMs += pollIntervalMs;
                    }

                    try
                    {
                        if (!process.HasExited)
                        {
                            process.Kill();
                            lblStatus.Text = "Game closed forcibly after 20s.";
                        }
                        else
                        {
                            lblStatus.Text = "Game closed early.";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't close AT.exe: " + ex.Message);
                    }
                }


                string selectedVersion = comboBox3.SelectedItem.ToString();

                string selectedLanguage = comboBox5.SelectedItem.ToString();

                if (selectedLanguage == "🇵🇱")
                {
                    if (selectedVersion == "evolution")
                    {
                        await InstallMod(
                        "https://github.com/rockysx27/v6config/releases/download/release/evo.zip",
                        tempPath,
                        gameDir,
                        "evo.zip",
                        10);
                    }
                    else
                    {
                        await InstallMod(
                            "https://github.com/rockysx27/v6config/releases/download/publish/spolszczenie.zip",
                            tempPath,
                            gameDir,
                            "spolszczenie.zip",
                            10);
                    }
                }
                else if (selectedLanguage == "🇪🇸")
                {
                    await InstallMod(
                           "https://github.com/rockysx27/v6config/releases/download/dub-es/espanol.zip",
                           tempPath,
                           gameDir,
                           "espanol.zip",
                           10);
                }
                else if (selectedLanguage == "🇷🇺")
                {
                    await InstallMod(
                           "https://github.com/rockysx27/v6config/releases/download/dub-rus/russian.zip",
                           tempPath,
                           gameDir,
                           "russian.zip",
                           10);
                }
                else
                {
                    await InstallMod(
                           "https://github.com/rockysx27/v6config/releases/download/dub-br/portugese.zip",
                           tempPath,
                           gameDir,
                           "portugese.zip",
                           10);
                }
            }


            //"🇺🇸", "🇬🇧", "🇵🇱", "🇩🇪", "🇪🇸", "🇷🇺", "🇫🇷"
            if (checkBox6.Checked)
            {
                string selectedVersion = comboBox5.SelectedItem.ToString();
                if (selectedVersion == "🇵🇱")
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-pl/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }
                else if (selectedVersion == "🇩🇪")
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-de/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }
                else if (selectedVersion == "🇬🇧")
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-uk/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }
                else if (selectedVersion == "🇺🇸")
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-us/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }
                else if (selectedVersion == "🇪🇸")
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-es/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }
                else if (selectedVersion == "🇷🇺")
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-rus/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }
                else if (selectedVersion == "🇫🇷")
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-fre/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }
                else
                {
                    await InstallMod(
                    "https://github.com/rockysx27/v6config/releases/download/csv-br/data.zip", // Correct raw URL
                    tempPath,
                    gameDir,
                    "data.zip",
                    10);
                }

            }

            lblStatus.Text = "Done!";
            progressBar1.Value = 100;
            MessageBox.Show("Mods installed successfully.");

            // Close the form after the installation is complete
            this.Close(); // This will close the current form
                          // Alternatively, you can use Application.Exit() to close the whole application, if needed.
                          // Application.Exit(); 
        }

        private async Task InstallMod(string url, string tempDir, string gameDir, string fileName, int progressStart)
        {
            // Determine a file name if none was provided
            if (string.IsNullOrEmpty(fileName))
                fileName = Path.GetFileName(new Uri(url).LocalPath);

            lblStatus.Text = $"Downloading {fileName}...";
            string downloadPath = Path.Combine(tempDir, fileName);

            // Download
            byte[] data = await httpClient.GetByteArrayAsync(url);
            await File.WriteAllBytesAsync(downloadPath, data);
            progressBar1.Value = progressStart + 20;

            // If it's a zip, extract & copy
            if (Path.GetExtension(fileName).Equals(".zip", StringComparison.OrdinalIgnoreCase))
            {
                lblStatus.Text = $"Extracting {fileName}...";
                string extractDir = Path.Combine(tempDir, Path.GetFileNameWithoutExtension(fileName));
                if (Directory.Exists(extractDir)) Directory.Delete(extractDir, true);
                ZipFile.ExtractToDirectory(downloadPath, extractDir);
                progressBar1.Value = progressStart + 40;

                lblStatus.Text = $"Copying files from {fileName}...";
                // Log files for debugging
                // Copy all files from the extracted directory to the game directory
                foreach (var file in Directory.GetFiles(extractDir, "*", SearchOption.AllDirectories))
                {
                    // Get the path of the file relative to the extraction root
                    string relativePath = Path.GetRelativePath(extractDir, file);

                    // Build the full path to where the file should go in the game directory
                    string targetFile = Path.Combine(gameDir, relativePath);

                    // Ensure the target directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(targetFile));

                    // Copy the file, overwriting if it already exists
                    File.Copy(file, targetFile, overwrite: true);
                }


                progressBar1.Value = progressStart + 50;
            }
            else
            {
                // Non-zip files get copied directly
                lblStatus.Text = $"Installing {fileName}...";
                File.Copy(downloadPath, Path.Combine(gameDir, fileName), overwrite: true);
                progressBar1.Value = progressStart + 50;
            }
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (!target.Exists)
                target.Create();

            // Copy files
            foreach (FileInfo file in source.GetFiles())
            {
                string targetFilePath = Path.Combine(target.FullName, file.Name);

                // Delete existing file before copying
                if (File.Exists(targetFilePath))
                {
                    File.Delete(targetFilePath);
                }

                file.CopyTo(targetFilePath);
            }

            // Recursively copy subdirectories
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyAll(subDir, nextTargetSubDir);
            }
        }



        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Toggle dark mode
            isDarkMode = !isDarkMode;

            // Update the title bar to reflect the new theme
            DarkModeHelper.UseImmersiveDarkMode(this, isDarkMode);

            // Update form background and theme for all controls
            this.BackColor = isDarkMode ? Color.Black : Color.White;
            ApplyTheme(this, isDarkMode);

            // Change button icon/text
            button2.Text = isDarkMode ? "☀️" : "🌙";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                // Stop playing music if it's already playing
                soundPlayer.Stop();
                isPlaying = false;
            }
            else
            {
                // Start playing music if it's not already playing
                soundPlayer.PlayLooping(); // Or Play() if you want it to play once
                isPlaying = true;
            }

            // Toggle mute/unmute functionality
            if (isMuted)
            {
                // Unmute the music
                soundPlayer.PlayLooping(); // Restart music if previously muted
                button1.Text = "🔊"; // Speaker with volume symbol
            }
            else
            {
                // Mute the music
                soundPlayer.Stop();
                button1.Text = "🔇"; // Muted speaker symbol
            }

            // Toggle mute state
            isMuted = !isMuted;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var url = "https://store.steampowered.com/app/331920/Airline_Tycoon_Deluxe/";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Generate your Terms of Use content
            string termsContent = @"
   <!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Terms of Use</title>
    <style>
        body { font-family: Arial, sans-serif; line-height: 1.6; margin: 2rem; color: #333; }
        h1 { color: #00539C; font-size: 2rem; }
        h2 { color: #0077D1; margin-top: 1.5rem; }
        p, li { margin-bottom: 1rem; }
        ul { margin-left: 1.5rem; }
        .note { background: #f9f9f9; border-left: 4px solid #0077D1; padding: 1rem; }
        a { color: #0077D1; text-decoration: none; }
        a:hover { text-decoration: underline; }
    </style>
</head>
<body>
    <h1>Terms of Use</h1>

    <p><strong>Airlines Tycoon Evolution HD Patcher</strong> is an open-source, non-commercial utility designed to improve the playability of the game <strong>Airline Tycoon Deluxe</strong>. By downloading, installing, or using this software, you agree to the terms outlined below.</p>

    <h2>1. Non-Commercial Use</h2>
    <ul>
        <li>This program is provided entirely free of charge and without any commercial interest.</li>
        <li>No monetary gain is derived from its development, distribution, or usage.</li>
        <li>All rights to the original game and its assets belong to the original developers and publishers.</li>
    </ul>

    <h2>2. Third-Party Content and Credits</h2>
    <ul>
        <li>This software may utilize or install files from the following third-party projects:</li>
<ul>
  <li><strong>cnc-ddraw</strong> by FunkyFr3sh – <a href=""https://github.com/FunkyFr3sh/cnc-ddraw/releases"" target=""_blank"">GitHub Repository</a></li>
  <li><strong>Pełne spolszczenie do Airline Tycoon Deluxe</strong> by Lili – <a href=""https://steamcommunity.com/sharedfiles/filedetails/?id=1325551452"" target=""_blank"">Steam Guide</a></li>
  <li><strong>Airline Tycoon Patch 1.2-1.8</strong> by WizzardMaker – <a href=""https://github.com/WizzardMaker"" target=""_blank"">GitHub Repository</a></li>
 <li><strong>Airline Tycoon Patch 1.8.4-1.9.0</strong> by WizzardMaker – <a href=""https://github.com/mertenpopp"" target=""_blank"">GitHub Repository</a></li>
<li><strong>Credits and Contributors</strong></li>
  <li>WizzardMaker - Main contributor and maintainer</li>
  <li>CrossVR - Original contributor</li>
  <li>mertenpopp - Contributor</li>
  <li>wackfx - Contributor</li>
  <li>CrazyOrange - Contributor</li>
  <li>Heftie - Contributor</li>
  <li>Fisico9798 - Planes</li>
  <li>Hephaestus6059 - Planes</li>
  <li>Flat_Eric1983 - Cities, Routes and Builds</li>
</ul>

<ul>
  <li><strong>Obsada (Polski Dubbing)</strong></li>
  <li><strong>Krzysztof Kowalewski</strong> – Dyrektor Godziński</li>
  <li><strong>Artur Barciś</strong> – Andrzej Balicki</li>
  <li><strong>Pijak w kawiarni</strong></li>
  <li><strong>Jan Piechociński</strong>
    <ul>
      <li>Pracownik Inter Adu</li>
      <li>Pracownik sklepu NASA</li>
      <li>Sabotażysta</li>
      <li>Mechanik</li>
      <li>Sprzedawca samolotów Maczek i Synowie</li>
    </ul>
  </li>
  <li><strong>W pozostałych rolach</strong>
    <ul>
      <li><strong>Elżbieta Bieda</strong>
        <ul>
          <li>Joasia Skalska</li>
          <li>Ekspedientka w sklepie bezcłowym</li>
          <li>Urzędniczka w banku</li>
          <li>Urzędniczka oddziału zagranicznego</li>
        </ul>
      </li>
      <li><strong>Michał Burbo</strong>
        <ul>
          <li>Stańczyk</li>
          <li>Jan Nowak</li>
          <li>Darek</li>
        </ul>
      </li>
      <li><strong>Henryka Korzycka</strong> – Dorota Lotna</li>
      <li>Komunikaty z megafonu</li>
      <li><strong>Jan Plewako</strong>
        <ul>
          <li>Marian Migalski</li>
          <li>Pracownik ArabAir</li>
          <li>Kioskarz</li>
        </ul>
      </li>
      <li><strong>Robert Płuszka</strong>
        <ul>
          <li>Igor Tupolewski</li>
          <li>Pracownik muzeum lotniczego</li>
        </ul>
      </li>
    </ul>
  </li>
</ul>
        <li><strong>Credits for Spanish, Brazilian, and Russian dubbing go to their respective voice actors and directors.</strong></li>
        <li>All credit for these tools and patches goes to their respective authors.</li>
        <li>You must comply with the specific licenses and terms provided by each third-party project before use.</li>
    </ul>

    <h2>3. Functionality Overview</h2>
    <ul>
        <li>The program may perform the following actions:</li>
        <ul>
            <li>Download and apply community-made patches and files.</li>
            <li>Modify, move, or delete specific folders/files within the game directory.</li>
            <li>Generate ZIP backups of affected game files.</li>
            <li>Edit configuration files, such as <code>cnc-ddraw.ini</code>, if custom settings are selected by the user.</li>
        </ul>
        <li>The software itself does not create or own any mods or patches.</li>
    </ul>

    <h2>4. Legal Compliance</h2>
    <p>You are solely responsible for ensuring your use of this program complies with local, national, and international laws, as well as the original game’s End User License Agreement (EULA).</p>

    <h2>5. Disclaimer of Warranties</h2>
    <div class=""note"">
        <p>This software is provided “as-is” without warranty of any kind, express or implied. There is no guarantee it will function without error, nor that it will meet your expectations or requirements.</p>
    </div>

    <h2>6. Limitation of Liability</h2>
    <p>To the maximum extent permitted by law, in no event shall the author or contributors be liable for any direct, indirect, incidental, special, exemplary, or consequential damages (including but not limited to data loss, corruption, game malfunction, hardware failure, or legal claims) arising in any way from the use or misuse of this software.</p>

    <h2>7. Indemnification</h2>
    <p>You agree to indemnify and hold harmless the author, contributors, and distributors of this software from any and all claims, damages, liabilities, losses, costs, or expenses (including attorneys’ fees) arising from your use of the program or violation of these terms.</p>

    <h2>8. Governing Law</h2>
    <p>These Terms shall be governed and construed in accordance with the laws applicable in your jurisdiction, without regard to conflict of law principles. If any provision is deemed invalid, the rest shall remain in effect.</p>

    <h2>9. No Warranty or Support</h2>
    <p>This program is offered without any obligation of support, maintenance, or update. Use is entirely at your own risk, and there is no guarantee of continued availability or compatibility.</p>

    <h2>10. Acceptance of Terms</h2>
    <p>By using, installing, or downloading this program, you affirm that you have read, understood, and agreed to be bound by these Terms of Use. If you do not agree, you must not use this software.</p>

    <p style=""margin-top:2rem;""><strong>Last updated:</strong> May 12, 2025</p>
</body>
</html>

";

            // Define the path where we will save the HTML file temporarily
            string tempFilePath = Path.Combine(Path.GetTempPath(), "terms_of_use.html");

            // Write the HTML content to the temporary file
            File.WriteAllText(tempFilePath, termsContent);

            // Now open this HTML file in the default browser
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening the Terms of Use file: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var url = "https://store.steampowered.com/app/331920/Airline_Tycoon_Deluxe/";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = "https://lili.lgbt/en/";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = "";
            if (linkLabel3.Text == "WizzardMaker")
            {
                url = "https://wizzardmaker.github.io/portfolio/";
            } else
            {
                url = "https://github.com/mertenpopp";
            }
                

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = "https://github.com/FunkyFr3sh";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var url = "https://wizzardmaker.github.io/portfolio/";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = "https://github.com/rockysx27";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var url = "https://github.com/rockysx27";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var url = "https://lili.lgbt/en/";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var url = "https://github.com/FunkyFr3sh";

            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Required in .NET Core and .NET 5+
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedVersion = comboBox5.SelectedItem.ToString();
            if (selectedVersion == "🇵🇱" || selectedVersion == "🇪🇸" || selectedVersion == "🇷🇺" || selectedVersion == "🇧🇷")
            {
                if (selectedVersion == "🇵🇱")
                {
                    comboBox3.Enabled = true;
                }
                else
                {
                    comboBox3.Enabled = false;
                }
                checkBox5.Checked = true;
                checkBox5.Enabled = true;
            }
            else
            {
                comboBox3.Enabled = false;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedVersion = comboBox1.SelectedItem.ToString();
            if (selectedVersion == "v1.8.4" || selectedVersion == "v1.9.0")
            {
                comboBox4.Enabled = false;
                comboBox4.SelectedItem = "normal";

                linkLabel3.Text = "Mertenpopp";
                pictureBox2.ImageLocation = "https://avatars.githubusercontent.com/u/28233977?v=4";
            } else
            {
                comboBox4.Enabled = true;
                comboBox4.SelectedItem = "normal";

                linkLabel3.Text = "WizzardMaker";
                pictureBox2.ImageLocation = "https://avatars.githubusercontent.com/u/7768485?v=4";
            }
        }
    }
}
