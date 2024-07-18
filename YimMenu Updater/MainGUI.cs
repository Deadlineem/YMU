using System.Data;
using System.Resources;
using System.Net;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO.Compression;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Text.Json;
using Newtonsoft.Json;
using Guna.UI2.WinForms;
using RestSharp;
using Microsoft.VisualBasic;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace YimUpdater
{

    public partial class MainGUI : Form
    {
        private const string GitHubApiUrl = "https://api.github.com/repos/Deadlineem/YMU/releases/latest";
        private const string ExeName = "YMU.exe";

        public bool drag;
        public MainGUI()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
            //LoadRepositories();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            //All events below
            pictureBox1.MouseDown += TitleBarMouseDown;
            pictureBox1.MouseMove += TitleBarDrag;
            pictureBox1.MouseUp += TitleBarMouseUp;
            CloseBtn.Click += CloseBtn_Click;
            CloseBtn.MouseLeave += CloseBtn_Leave;
            CloseBtn.MouseHover += CloseBtn_Hover;
            minBtn.Click += MinBtn_Click;
            minBtn.MouseLeave += MinBtn_Leave;
            minBtn.MouseHover += MinBtn_Hover;
            howToGuide.Click += howToGuide_Click;
            uninstallYimMenu.Click += uninstallYimMenu_Click;
            deleteCache.Click += deleteCache_Click;
            downloadYimMenu.Click += downloadYimMenu_Click;
            installOutfits.Click += installOutfits_Click;
            installJsonVehicles.Click += installJsonVehicles_Click;
            installYimASI.Click += installYimASI_Click;
            installXMLs.Click += installXMLs_Click;
            downloadAnimations.Click += downloadAnimations_Click;
            downloadHorseMenu.Click += downloadHorseMenu_Click;
            injectDLL.Click += injectDLL_Click;
            launchGame.Click += launchGame_Click;
            updateCheck.Click += new EventHandler(updateCheck_Click);
        }

        private async void updateCheck_Click(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }

        private async Task CheckForUpdates()
        {
            try
            {
                var client = new RestClient(GitHubApiUrl);
                var request = new RestRequest("", Method.Get);
                request.AddHeader("User-Agent", "YimMenu-Updater");
                var response = await client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var release = JObject.Parse(response.Content);
                    var asset = release["assets"].FirstOrDefault(a => a["name"].ToString() == ExeName);
                    if (asset == null)
                    {
                        MessageBox.Show("Could not find the latest version of YMU.exe.");
                        return;
                    }
                    var downloadUrl = asset["browser_download_url"].ToString();

                    await DownloadAndReplaceExecutable(downloadUrl, ExeName);
                }
                else
                {
                    MessageBox.Show("Failed to check for updates. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking for updates: {ex.Message}");
            }
        }

        private async Task DownloadAndReplaceExecutable(string downloadUrl, string executableName)
        {
            try
            {
                var tempFilePath = Path.GetTempFileName();
                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(new Uri(downloadUrl), tempFilePath);
                }

                var exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, executableName);
                if (File.Exists(exePath))
                {
                    var currentHash = ComputeSha256Hash(exePath);
                    var downloadedHash = ComputeSha256Hash(tempFilePath);

                    if (currentHash != downloadedHash)
                    {
                        File.Delete(exePath);
                        File.Move(tempFilePath, exePath);

                        MessageBox.Show("Update completed successfully. The application will now restart.");
                        RestartApplication();
                    }
                    else
                    {
                        MessageBox.Show("You already have the latest version.");
                        File.Delete(tempFilePath);
                    }
                }
                else
                {
                    File.Move(tempFilePath, exePath);
                    MessageBox.Show("No existing executable found. The latest version has been downloaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the application: {ex.Message}");
            }
        }

        private string ComputeSha256Hash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = File.OpenRead(filePath))
            {
                var hashBytes = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private void RestartApplication()
        {
            var exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ExeName);
            Process.Start(exePath);
            Application.Exit();
        }

        private void CloseBtn_Click(object? sender, EventArgs e)
        {
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn_a;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (object? sender, EventArgs e) =>
            {
                CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn_h;
                Environment.Exit(0);
            };
            timer.Start();
        }

        private void CloseBtn_Hover(object? sender, EventArgs e)
        {
            //CloseBtn.BackgroundImage = ResourceReader
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn_h;
        }

        private void CloseBtn_Leave(object? sender, EventArgs e)
        {
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn;
        }
        private void MinBtn_Click(object? sender, EventArgs e)
        {
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn_a;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (object? sender, EventArgs e) =>
            {
                minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn_h;
                this.WindowState = FormWindowState.Minimized;
                timer.Stop();
            };
            timer.Start();
        }

        private void MinBtn_Hover(object? sender, EventArgs e)
        {
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn_h;
        }

        private void MinBtn_Leave(object? sender, EventArgs e)
        {
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn;
        }

        public static int calcposy;
        public static int calcposx;
        private void TitleBarMouseDown(object? sender, MouseEventArgs e)
        {
            drag = true;
            var mousestartposx = Cursor.Position.X;
            var mousestartposy = Cursor.Position.Y;
            var windowstartposx = this.Location.X;
            var windowstartposy = this.Location.Y;
            calcposx = mousestartposx - windowstartposx;
            calcposy = mousestartposy - windowstartposy;
        }

        private void TitleBarDrag(object? sender, MouseEventArgs e)
        {
            if (drag == true)
            {
                var newmouseposx = Cursor.Position.X;
                var newmouseposy = Cursor.Position.Y;
                var newposx = newmouseposx - calcposx;
                var newposy = newmouseposy - calcposy;
                Point location = new Point(newposx, newposy);
                this.Location = location;
            }
        }

        private void TitleBarMouseUp(object? sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void downloadYimMenu_Click(object? sender, EventArgs e)
        {
            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string file = "YimMenu.dll";
            string dllUrl = "https://github.com/YimMenu/YimMenu/releases/download/nightly/" + file;
            string dllPath = Path.Combine(downloadsFolder, "YimMenu.dll");

            DownloadFile(file, dllUrl, null, "YimMenu.dll downloaded to ", true);
        }

        private void uninstallYimMenu_Click(object? sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu");

            DeleteDirectory(yimMenuFolder, "YimMenu has been uninstalled.");
        }

        private void deleteCache_Click(object? sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cacheFolder = Path.Combine(appDataFolder, "YimMenu", "cache");

            DeleteDirectory(cacheFolder, "YimMenu's Cache has been deleted.");
        }

        private void howToGuide_Click(object? sender, EventArgs e)
        {
            ShowHowToGuide();
        }

        private void DownloadFile(string file, string url, string path, string successMessage, bool ofd = false)
        {
            string downloadPath = path;

            // If path is not set, show the FolderBrowserDialog
            if (string.IsNullOrEmpty(path))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    downloadPath = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    MessageBox.Show("No folder selected. Download canceled.", "Canceled");
                    return;
                }
            }

            // Proceed with download if the path is set
            RestClient httpc = new RestClient();
            RestRequest request = new RestRequest(url);
            byte[] help = httpc.DownloadData(request);

            if (help == null)
            {
                MessageBox.Show("File failed to download. URL: " + url, "Error");
            }
            else
            {
                string fullPath = Path.Combine(downloadPath, file);
                File.WriteAllBytes(fullPath, help);
                MessageBox.Show(file + " has been downloaded successfully to " + downloadPath, "Success");
            }
        }

        private void DeleteDirectory(string path, string successMessage)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete \'" + path + "\'?\nThis can NOT be undone!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    MessageBox.Show(successMessage);
                }
                else
                {
                    MessageBox.Show("Directory not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShowHowToGuide()
        {
            string guide = "How to Download/Install YimMenu:\n\n" +
                           "1. To download YimMenu, click the 'Download YimMenu' button.\n" +
                           "2. Load into GTA5\n" +
                           "3. Go to the Tools tab, type GTA5 into the input box.\n" +
                           "4. Click Inject DLL and navigate to your Downloads folder, then select YimMenu.dll\n" +
                           "5. The program should automatically inject YimMenu into GTA\n\n" +
                           "Use the INSERT key to Open/Close the menu, IF you do not have an insert key and you are\n" +
                           "a first time YimMenu user, click VK_INSERT on the first popup screen and change it to J\n" +
                           "This will set the menu keybind to J for Opening/Closing the menu.";
            MessageBox.Show(guide, "How to Guide");
        }

        // Lua Scripts Tab Buttons

        private void downloadExtras_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu", "scripts");
            string file1 = "Extras-Addon.lua";
            string file2 = "Extras-data.lua";
            string file3 = "json.lua";

            // Download each file using the DownloadFile method
            DownloadFile(file1, "https://raw.githubusercontent.com/Deadlineem/Extras-Addon-for-YimMenu/main/" + file1, yimMenuFolder, file1 + " downloaded successfully to ", true);

            DownloadFile(file2, "https://raw.githubusercontent.com/Deadlineem/Extras-Addon-for-YimMenu/main/" + file2, yimMenuFolder, file2 + " downloaded successfully to ", true);

            DownloadFile(file3, "https://raw.githubusercontent.com/Deadlineem/Extras-Addon-for-YimMenu/main/" + file3, yimMenuFolder, file3 + " downloaded successfully to ", true);
        }

        private void downloadCSYONMenu_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu", "scripts");
            string file = "Csyon SubMenu V5.1 1.69.lua";
            DownloadFile(file, "https://raw.githubusercontent.com/CSY0N/CsyonSubMenu/main/Csyon%20Sub%20Menu%20YimMenu%20Script/" + file, yimMenuFolder, file + " downloaded successfully to ", true);
        }

        private void downloadAnimations_Click(object? sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu");
            string file = "animDictsCompact.json";

            DownloadFile(file, "https://raw.githubusercontent.com/DurtyFree/gta-v-data-dumps/master/" + file, yimMenuFolder, file + " downloaded successfully to ", true);
        }

        private void DownloadAndExtractZip(string url, string zipFilePath, string fileName, string extractDirectory)
        {
            WebClient client = new WebClient();

            // Subscribe to the DownloadProgressChanged event to update the progress bar
            client.DownloadProgressChanged += (sender, e) =>
            {
                progressBar1.Visible = true;
                // Assuming progressBar1 is your ProgressBar control on the form
                progressBar1.Value = e.ProgressPercentage;
            };

            try
            {
                // Download the zip file asynchronously
                client.DownloadFileAsync(new Uri(url), zipFilePath);

                // Handle completion of download
                client.DownloadFileCompleted += (sender, e) =>
                {
                    progressBar1.Visible = false;

                    // Extract the zip file to the specified directory
                    try
                    {
                        // Ensure the extractDirectory exists
                        Directory.CreateDirectory(extractDirectory);

                        // Extract the zip file, overwriting existing files if any
                        ZipFile.ExtractToDirectory(zipFilePath, extractDirectory, true);

                        MessageBox.Show($"{fileName} Download completed!\n\n Extracted {fileName} to {extractDirectory}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error extracting zip file: {ex.Message}");
                    }
                    finally
                    {
                        // Clean up: Delete the downloaded zip file
                        File.Delete(zipFilePath);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}");
                progressBar1.Visible = false;
            }
        }

        private void installXMLs_Click(object? sender, EventArgs e)
        {
            // For xml_maps.zip
            string urlMaps = "http://bedrock.root.sx/xml_maps.zip";
            string zipFileNameMaps = "xml_maps";
            string zipFileNameM = "XML Maps";
            string extractDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimMenu");

            DownloadAndExtractZip(urlMaps, zipFileNameMaps, zipFileNameM, extractDirectory);

            // For xml_vehicles.zip
            string urlVehicles = "http://bedrock.root.sx/xml_vehicles.zip";
            string zipFileNameVehicles = "xml_vehicles";
            string zipFileNameV = "XML Vehicles";

            DownloadAndExtractZip(urlVehicles, zipFileNameVehicles, zipFileNameV, extractDirectory);
        }

        private bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RestartAsAdmin()
        {
            try
            {
                string exeName = Assembly.GetEntryAssembly().Location;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas"; // Run as administrator
                Process.Start(startInfo);
                Application.Exit(); // Exit current instance
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restarting application as administrator: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void installOutfits_Click(object? sender, EventArgs e)
        {
            // For saved_outfits.zip
            string urlOutfits = "https://raw.githubusercontent.com/juniorkrz/Yim-Json-Vehicles-and-Outfits/master/downloads/saved_outfits.zip";
            string zipFileNameOutfits = "saved_outfits.zip";
            string zipFileNameO = "Outfits";
            string extractDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimMenu");

            DownloadAndExtractZip(urlOutfits, zipFileNameOutfits, zipFileNameO, extractDirectory);
        }

        private void installJsonVehicles_Click(object? sender, EventArgs e)
        {
            // For saved_json_vehicles.zip
            string urlJsonVehicles = "https://raw.githubusercontent.com/juniorkrz/Yim-Json-Vehicles-and-Outfits/master/downloads/saved_json_vehicles.zip";
            string zipFileNameJsonVehicles = "saved_json_vehicles.zip";
            string zipFileNameJV = "Json Vehicles";
            string extractDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimMenu");

            DownloadAndExtractZip(urlJsonVehicles, zipFileNameJsonVehicles, zipFileNameJV, extractDirectory);
        }

        private void installYimASI_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files|*.exe";
            openFileDialog.Title = "Find & Select GTA5.exe";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string gta5Path = openFileDialog.FileName;

                string yimASIUrl = "https://github.com/xesdoog/YimASI/releases/download/release/";
                string scriptHookUrl = "http://bedrock.root.sx/";

                string gtaFolder = Path.GetDirectoryName(gta5Path); // Get the directory where GTA5.exe is located
                string scriptHookFilePath = Path.Combine(gtaFolder, "ScriptHookV.dll");
                string yimASIFilePath = Path.Combine(gtaFolder, "WTSAPI32.dll");

                if (!IsAdministrator())
                {
                    // Prompt user to restart as admin
                    DialogResult result = MessageBox.Show("This operation requires administrative privileges to install to your game path, Restart your application as administrator and try again!",
                                                          "Admin Privileges Required", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                DownloadFile("WTSAPI32.dll", yimASIUrl, yimASIFilePath, "YimASI downloaded successfully to: ");
                DownloadFile("ScriptHookV.dll", scriptHookUrl, scriptHookFilePath, "ScriptHookV downloaded successfully to: ");
            }
        }

        public class Repository
        {
            public string Name { get; set; }
            public string Html_Url { get; set; }
        }

        public class GitHubRepositories
        {
            private static readonly HttpClient client = new HttpClient();

            public async Task<List<Repository>> FetchRepositoriesAsync()
            {
                string url = "https://api.github.com/orgs/YimMenu-Lua/repos?type=all";
                client.DefaultRequestHeaders.UserAgent.ParseAdd("request");

                var response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<Repository>>(response);
            }
        }

        private GitHubRepositories gitHubRepositories = new GitHubRepositories();
        private FlowLayoutPanel flowLayoutPanel;
        private List<Repository> customRepositories = new List<Repository>
        {
            new Repository { Name = "Extras Addon", Html_Url = "" },
            new Repository { Name = "CSYON Submenu", Html_Url = "" }
        };

        private async void InitializeFlowLayoutPanel()
        {
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true
            };

            LuaScripts_Tab.Controls.Add(flowLayoutPanel);

            await LoadRepositories();
        }

        private async Task LoadRepositories()
        {
            var fetchedRepositories = await gitHubRepositories.FetchRepositoriesAsync();

            // Exclude specific repositories from the fetched list
            var excludedRepositoryNames = new List<string> { "Example", "submission" };
            fetchedRepositories = fetchedRepositories.Where(repo => !excludedRepositoryNames.Contains(repo.Name)).ToList();

            // Combine custom repositories and fetched repositories, with custom ones first
            var allRepositories = customRepositories.Concat(fetchedRepositories).ToList();

            foreach (var repo in allRepositories)
            {
                Guna2Button repoButton = new Guna2Button
                {
                    Text = repo.Name,
                    Tag = new RepositoryTag { Repository = repo, Url = repo.Html_Url }, // Store repository info in Tag
                    Size = new Size(155, 45),
                    Margin = new Padding(6),
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(155, 0, 0),
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.White,
                    TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
                };

                repoButton.DisabledState.BorderColor = Color.DarkGray;
                repoButton.DisabledState.CustomBorderColor = Color.DarkGray;
                repoButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
                repoButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);

                flowLayoutPanel.Controls.Add(repoButton);

                if (repo.Name == "Extras Addon")
                {
                    repoButton.Click += downloadExtras_Click;
                }
                else if (repo.Name == "CSYON Submenu")
                {
                    repoButton.Click += downloadCSYONMenu_Click;
                }
                else
                {
                    repoButton.Click += RepoButton_Click;
                }
            }
        }

        public class RepositoryTag
        {
            public Repository Repository { get; set; }
            public string Url { get; set; }
        }

        private void RepoButton_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;

            // Retrieve repository information from Tag
            var repoTag = button.Tag as RepositoryTag;
            if (repoTag != null)
            {
                string url = repoTag.Url + "/archive/refs/heads/main.zip";
                string fileName = repoTag.Repository.Name; // Use repo.Name as fileName
                string tempPath = Path.GetTempPath();
                string zipFilePath = Path.Combine(tempPath, $"{fileName}_main.zip");
                string extractDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimMenu", "scripts");

                DownloadAndExtractZip(url, zipFilePath, fileName, extractDirectory);
            }
        }

        private void downloadHorseMenu_Click(object? sender, EventArgs e)
        {
            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string file = "HorseMenu.dll";
            string dllUrl = "https://github.com/YimMenu/HorseMenu/releases/download/nightly/" + file;
            string dllPath = Path.Combine(downloadsFolder, "HorseMenu.dll");

            DownloadFile(file, "https://github.com/YimMenu/HorseMenu/releases/download/nightly/" + file, null, file + " downloaded to ", true);
        }

        private Process GetProcessByName(string processName)
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                Console.WriteLine($"Checking process: " + processName);
                if (process.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase))
                {
                    return process;
                }
            }
            return null;
        }

        private void injectDLL_Click(object sender, EventArgs e)
        {
            string processNameText = processName.Text.Trim(); // Trim any extra spaces
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string injectorPath = Path.Combine(baseDirectory, "dllinject.exe"); // The injector executable
            bool procOpen = false;

            if (string.IsNullOrEmpty(processNameText))
            {
                MessageBox.Show("Please enter a process name.");
                return;
            }

            foreach (Process p in Process.GetProcesses())
            {
                //MessageBox.Show(p.ProcessName);
                if (p.ProcessName.ToLower() == processNameText.ToLower())
                {
                    procOpen = true;
                }
            }

            if (!procOpen)
            {
                MessageBox.Show(processNameText + " is not open", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open a file dialog to select the DLL
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads",
                Filter = "DLL files (*.dll)|*.dll",
                Title = "Select a DLL file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dllPath = openFileDialog.FileName;

                try
                {
                    // Start the injector process with elevated privileges
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = injectorPath,
                        Arguments = $"--process-name \"{processNameText}.exe\" --inject \"{dllPath}\"",
                        Verb = "runas", // Run as administrator
                        UseShellExecute = true // Required to run as admin
                    };

                    Process.Start(startInfo);

                    string outputPath = @"inject-log.txt";

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(outputPath))
                        {
                            writer.WriteLine($"Command to execute: {injectorPath} --process-name \"{processNameText}.exe\" --inject \"{dllPath}\"");
                        }

                        Console.WriteLine("Command written to file: " + outputPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("DLL selection was cancelled.");
            }
        }

        private void launchGame_Click(object sender, EventArgs e)
        {
            bool valid = false;
            string game = processName.Text.ToLower();
            string[] knownGames = new string[] { "gta5", "rdr2", "minecraft.windows"};

            foreach (string knownGame in knownGames)
            {
                if (game == knownGame)
                    valid = true;
            }

            if (!valid)
            {
                MessageBox.Show(game + " is not a known game.\nWe currently support:\ngta5\nrdr2\nminecraft.windows", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (game)
            {

                /*
                Process To Start and Find games, maybe if its finds more than one
                installation it will ask which one to start, i know for rdr2 and gta5 there is
                atleast 3 installation locations, epic games, steam and rockstar launcher.

                As far as im aware Minecraft Bedrock is only avaiable on the Microsoft Store.
                */
                case "gta5":
                    string[] found = new string[] { };
                    string[] locations = new string[] { "Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V", "SteamLibrary\\steamapps\\common\\Grand Theft Auto V\\", "Program Files\\Rockstar Games\\Grand Theft Auto V\\", "Rockstar Games\\Grand Theft Auto V\\", "Program Files\\Epic Games\\GTAV\\", "Epic Games\\GTAV\\" };
                    string exe = "GTAVLauncher.exe";
                    foreach (DriveInfo drive in DriveInfo.GetDrives())
                    {
                        foreach (string location in locations)
                        {
                            string loc = drive.Name + location + exe;
                            if (File.Exists(loc))
                            {
                                found.Append(loc);
                                if (MessageBox.Show("Found " + loc + " would you like to launch it?", "Found", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        ProcessStartInfo startInfo = new ProcessStartInfo
                                        {
                                            FileName = loc,
                                            WorkingDirectory = drive.Name + location,
                                            Verb = "runas",
                                            UseShellExecute = true
                                        };
                                        Process proc = Process.Start(startInfo);
                                    } catch (Exception ex)
                                    {
                                        MessageBox.Show("Couldnt start GTA 5 - " + ex.Message);
                                    }
                                    return;
                                }
                            }
                        }
                    }
                    return;

                case "rdr2":
                    string[] rdrfound = new string[] { };
                    string[] rdrlocations = new string[] { "Program Files (x86)\\Steam\\steamapps\\common\\Red Dead Redemption 2\\", "SteamLibrary\\steamapps\\common\\Red Dead Redemption 2\\", "Program Files\\Epic Games\\RDR2\\", "Program Files\\Epic Games\\RedDeadRedemption2\\", "Epic Games\\RDR2\\", "Program Files\\Rockstar Games\\Red Dead Redemption 2\\", "Rockstar Games\\Red Dead Redemption 2\\" };
                    string rdrexe = "RDR2.exe";
                    foreach (DriveInfo drive in DriveInfo.GetDrives())
                    {
                        foreach (string location in rdrlocations)
                        {
                            string loc = drive.Name + location + rdrexe;
                            if (File.Exists(loc))
                            {
                                rdrfound.Append(loc);
                                if (MessageBox.Show("Found " + loc + " would you like to launch it?", "Found", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        ProcessStartInfo startInfo = new ProcessStartInfo
                                        {
                                            FileName = loc,
                                            WorkingDirectory = drive.Name + location,
                                            Verb = "runas",
                                            UseShellExecute = true
                                        };
                                        Process proc = Process.Start(startInfo);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Couldnt start RDR2 - " + ex.Message);
                                    }
                                    return;
                                }
                            }
                        }
                    }
                    return;

                case "minecraft.windows":
                    if (Interaction.Shell("explorer.exe shell:appsFolder\\Microsoft.MinecraftUWP_8wekyb3d8bbwe!App", AppWinStyle.MinimizedFocus, false, -1) == 0)
                    {
                        MessageBox.Show("Failed To Launch Minecraft.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MessageBox.Show("Starting Minecraft", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
        }
    }
}
