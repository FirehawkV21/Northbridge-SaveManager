using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NorthbridgeSubSystem.Properties;

namespace NorthbridgeSubSystem
{
    public partial class Form1 : Form
    {
        //Initialising a few static variables here. Add anything you want the executable to access frequently here as variables.
        
        //Location of the Save folder.
        private static readonly string SaveLocation = Application.StartupPath + "\\Saves\\";
        //Location of the RGSS Library (RMXP/RMVX/RMVXA).
        private static readonly string RgssLib = Application.StartupPath + "\\System\\RGSS301.dll";
        //Location of the Game file (RMXP/RMVX/RMVXA).
        private static readonly string GameFile = Application.StartupPath + "\\Game.rgss3a";
        //Location of the game executable.
        private static readonly string PlayerFile = Application.StartupPath + "\\Game.exe";
        //Set the extension of the save file.
        private const string SaveFileExtension = "*.rvdata2";
        //The name of the save file. Usualy they are SaveXX.
        private static readonly string SaveFilename = "Save";
        //Initalise a structure that contains necessary info (such as arguments).
        private readonly ProcessStartInfo _gameInfo = new ProcessStartInfo(PlayerFile);
        //This is the format of the folder when the backup is executed.
        private static readonly string BackupFolderSetup = Settings.Default.AutoBackupLocation + "\\" + "Backup" + DateTime.Now.ToString("yyyyMMddHHmm");
        //How many seconds it will wait until a backup is issued (Snapshot Mode only).
        private const int WaitTime = 60000;
        //Interger used as a check for the backup system (Normal Mode only).
        //If this interger is higher than 0, issue a backup.
        private static int _countChanges;
        private readonly Process _gameProcess = new Process();

        public Form1()
        {
            InitializeComponent();
        }

        private void RestoreBackupButton_Click(object sender, EventArgs e)
        {
            RestoreCompleteLabel.Visible = false;
            RestoreFailedLabel.Visible = false;
            var rli = RestoreFolderPicker.ShowDialog();
            if (rli != DialogResult.OK) return;
            try
            {
                Directory.Delete(SaveLocation, true);
                Directory.CreateDirectory(SaveLocation);
                DirectoryCopy(RestoreFolderPicker.SelectedPath, SaveLocation, true);
                RestoreCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                RestoreFailedLabel.Visible = true;
            }
        }

        private void DeleteBackupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DeleteBackupButton.Enabled = DeleteBackupCheckBox.Checked;
        }

        private void DeleteBackupButton_Click(object sender, EventArgs e)
        {
            DeleteBackupsFailed.Visible = false;
            BackupDeleteCompleteLabel.Visible = false;
            try
            {
                var backupFolder = Settings.Default.AutoBackupLocation;
                Directory.Delete(backupFolder, true);
                Directory.CreateDirectory(backupFolder);
                BackupDeleteCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                DeleteBackupsFailed.Visible = true;
            }
        }

        private void TestBackupButton_Click(object sender, EventArgs e)
        {
            BackupCompleteLabel.Visible = false;
            BackupFailedLabel.Visible = false;
            try
            {
                var backupFolder = Settings.Default.AutoBackupLocation + "\\" + "Backup" +
                                   DateTime.Now.ToString("yyyyMMddHHmm") + "\\";
                DirectoryCopy(SaveLocation, backupFolder, true);
                BackupCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                BackupFailedLabel.Visible = true;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var dl = BackupFolderPicker.ShowDialog();
            if (dl != DialogResult.OK) return;
            Settings.Default.AutoBackupLocation = BackupFolderPicker.SelectedPath;
            LocationBackup.Text = Settings.Default.AutoBackupLocation;
            Settings.Default.Save();
        }

        private void LocationBackup_TextChanged(object sender, EventArgs e)
        {
            RestoreFolderPicker.SelectedPath = Settings.Default.AutoBackupLocation;
            Settings.Default.AutoBackupLocation = LocationBackup.Text;
            Settings.Default.Save();
        }

        private void AutoBackupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoBackupEnabled = AutoBackupCheckbox.Enabled;
            BrowseButton.Enabled = AutoBackupCheckbox.Enabled;
            LocationBackup.Enabled = AutoBackupCheckbox.Enabled;
            RestoreBackupButton.Enabled = AutoBackupCheckbox.Enabled;
            DeleteBackupCheckBox.Enabled = AutoBackupCheckbox.Checked;
            TestBackupButton.Enabled = AutoBackupCheckbox.Checked;
            LocationBackup.Text = Settings.Default.AutoBackupLocation;
            RestoreBackupButton.Enabled = AutoBackupCheckbox.Checked;
            Settings.Default.Save();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteFailedLabel.Visible = false;
            DeleteCompleteLabel.Visible = false;
            try
            {
                Directory.Delete(SaveLocation, true);
                Directory.CreateDirectory(SaveLocation);
                ExportButton.Enabled = false;
                DeleteCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                DeleteFailedLabel.Visible = true;
            }
        }

        private void DeleteAllSavesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DeleteButton.Enabled = DeleteAllSavesCheckBox.Checked;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExportCompleteLabel.Visible = false;
            ExportFailedLabel.Visible = false;
            var eli = ExportFolderDialog.ShowDialog();
            if (eli != DialogResult.OK) return;
            try
            {
                DirectoryCopy(SaveLocation, ExportFolderDialog.SelectedPath, true);
                ExportCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                ExportFailedLabel.Visible = true;
            }
        }

        private void SlotSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = SlotSelectCheckBox.Checked;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            ImportCompleteLabel.Visible = false;
            ImportFailedLabel.Visible = false;
            var il = ImportFilePicker.ShowDialog();
            if (il != DialogResult.OK) return;
            try
            {
                if (SlotSelectCheckBox.Checked)
                {
                    var i = 0;
                    foreach (var fileName in ImportFilePicker.FileNames)
                    {
                        File.Copy(fileName, SaveLocation + @"\" + SaveFilename + (numericUpDown1.Value + i) + SaveFileExtension, true);
                        i++;
                    }
                }
                else
                    foreach (var fileName in ImportFilePicker.FileNames)
                    {
                        File.Copy(fileName, SaveLocation + @"\" + Path.GetFileName(fileName), true);
                    }
                if (Directory.GetFiles(SaveLocation, SaveFilename + SaveFileExtension).Length > 0)
                {
                    ExportButton.Enabled = true;
                    SelectiveExportButton.Enabled = true;
                    AutoBackupCheckbox.Enabled = true;
                    LocationBackup.Enabled = AutoBackupCheckbox.Checked;
                    DeleteAllSavesCheckBox.Enabled = true;
                    DeleteButton.Enabled = DeleteAllSavesCheckBox.Checked;
                    TestBackupButton.Enabled = AutoBackupCheckbox.Checked;
                    RestoreBackupButton.Enabled = AutoBackupCheckbox.Checked;
                    DeleteBackupCheckBox.Enabled = AutoBackupCheckbox.Checked;
                    DeleteBackupButton.Enabled = DeleteBackupCheckBox.Checked;
                }
                else
                {
                    ExportButton.Enabled = false;
                    SelectiveExportButton.Enabled = false;
                    AutoBackupCheckbox.Enabled = false;
                    LocationBackup.Enabled = false;
                    DeleteAllSavesCheckBox.Enabled = false;
                    DeleteButton.Enabled = false;
                    TestBackupButton.Enabled = false;
                    RestoreBackupButton.Enabled = false;
                    DeleteBackupCheckBox.Enabled = false;
                    DeleteBackupButton.Enabled = false;
                }
                ImportCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                ImportFailedLabel.Visible = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static void DirectoryCopy(
            string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);
            var dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            var files = dir.GetFiles();

            foreach (var file in files)
            {
                // Create the path to the new copy of the file.
                var temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (!copySubDirs) return;
            {
                foreach (var subdir in dirs)
                {
                    // Create the subdirectory.
                    var temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, true);
                }
            }
        }

        private static void AutoBackupCode()
        {
            var areSavesAvaliable = Directory.GetFiles(SaveLocation, SaveFilename + SaveFileExtension).Length > 0;
            var i = 1;
            if (!areSavesAvaliable) return;
            if (!Directory.Exists(BackupFolderSetup))
                DirectoryCopy(SaveLocation, BackupFolderSetup, true);
            else
            {
                //This variable sets a new location to create the backup, should a folder with the same name exists.
                //Adjust the format to your liking.
                var newBackupFolder = BackupFolderSetup + "-" + i + "\\";
                while (Directory.Exists(BackupFolderSetup +"-"+ i + "\\"))
                {
                    i++;
                }
                DirectoryCopy(SaveLocation, newBackupFolder, true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialises an array were all arguments passed to this executable are saved.
            string[] args = Environment.GetCommandLineArgs();
            //Checks if the argument to call the UI is present. If not, launch the game.
            if (args.Contains("-NBSetup")) return;
            //Checks if the files set in lines 12 - 19 are present. Adjust this accordingly.
            if (!File.Exists(PlayerFile) || !File.Exists(RgssLib) || !File.Exists(GameFile))
            {
                MessageBox.Show(@"Missing file(s). Aborting.");
                Close();
            }
            else
            {
                Hide();
                //Set up a watcher to monitor the save folder. The "*" is used for wild card.
                if (Settings.Default.AutoBackupEnabled && Settings.Default.AutoBackupLocation != null)
                {
                    var svw = new FileSystemWatcher
                    {
                        Path = SaveLocation,
                        NotifyFilter = NotifyFilters.LastWrite,
                        Filter = SaveFilename + @"*" + SaveFileExtension
                    };
                    svw.Changed += OnChanged;
                    svw.EnableRaisingEvents = true;
                }
                //Any arguments for the game executable (set in this executable's code) are loaded.
                //So, for example you pass the arguments --LoadFile <file> via code, this will happen:
                // Run "<Game Folder>\Game.exe" --LoadFile <file>
                // Set these with _gameInfo.Arguments = "argument1 argument2";
                _gameProcess.StartInfo = _gameInfo;
                //Start the game.
                _gameProcess.Start();
                //Wait for the game to close before closing Northbridge.
                _gameProcess.WaitForExit();
                //Calls the Auto-Backup code.
                if (Settings.Default.AutoBackupEnabled && Settings.Default.AutoBackupLocation != null && _countChanges > 0 && !Settings.Default.EnableSnapshotMode) AutoBackupCode();
                Close();
            }
            AutoBackupCheckbox.Checked = Settings.Default.AutoBackupEnabled;
            LocationBackup.Text = Settings.Default.AutoBackupLocation;
            if (!Directory.Exists(SaveLocation))
            {
                Directory.CreateDirectory(SaveLocation);
                ExportButton.Enabled = false;
                SelectiveExportButton.Enabled = false;
                AutoBackupCheckbox.Enabled = false;
                LocationBackup.Enabled = false;
                DeleteAllSavesCheckBox.Enabled = false;
                DeleteButton.Enabled = false;
                TestBackupButton.Enabled = false;
                RestoreBackupButton.Enabled = false;
                DeleteBackupCheckBox.Enabled = false;
                DeleteBackupButton.Enabled = false;
            }
            else
            if (Directory.GetFiles(SaveLocation, SaveFilename + SaveFileExtension).Length > 0)
            {
                ExportButton.Enabled = true;
                SelectiveExportButton.Enabled = true;
                AutoBackupCheckbox.Enabled = true;
                LocationBackup.Enabled = AutoBackupCheckbox.Checked;
                DeleteAllSavesCheckBox.Enabled = true;
                DeleteButton.Enabled = DeleteAllSavesCheckBox.Checked;
                TestBackupButton.Enabled = AutoBackupCheckbox.Checked;
                RestoreBackupButton.Enabled = AutoBackupCheckbox.Checked;
                DeleteBackupCheckBox.Enabled = AutoBackupCheckbox.Checked;
                DeleteBackupButton.Enabled = DeleteBackupCheckBox.Checked;
                EnableSnapshotCheckbox.Enabled = AutoBackupCheckbox.Checked;
            }
            else
            {
                ExportButton.Enabled = false;
                SelectiveExportButton.Enabled = false;
                AutoBackupCheckbox.Enabled = false;
                LocationBackup.Enabled = false;
                DeleteAllSavesCheckBox.Enabled = false;
                DeleteButton.Enabled = false;
                TestBackupButton.Enabled = false;
                RestoreBackupButton.Enabled = false;
                DeleteBackupCheckBox.Enabled = false;
                DeleteBackupButton.Enabled = false;
                EnableSnapshotCheckbox.Enabled = false;
            }
        }

        private void SelectiveExportButton_Click(object sender, EventArgs e)
        {
            ExportFilePicker.InitialDirectory = SaveLocation;
            ExportCompleteLabel.Visible = false;
            ExportFailedLabel.Visible = false;
            var seli = ExportFilePicker.ShowDialog();
            if (seli != DialogResult.OK) return;
            var eli = ExportFolderDialog.ShowDialog();
            if (eli != DialogResult.OK) return;
            try
            {
                foreach (var fileName in ExportFilePicker.SafeFileNames)
                {
                    File.Copy(SaveLocation + "\\" + Path.GetFileName(fileName), ExportFolderDialog.SelectedPath + "\\" + Path.GetFileName(fileName), true);
                }
                ExportCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                ExportFailedLabel.Visible = true;
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (Settings.Default.EnableSnapshotMode)
            {
                Thread.Sleep(WaitTime);
                AutoBackupCode();
            }
            else
            {
                _countChanges = _countChanges + 1;
            }
        }
    }
    }
