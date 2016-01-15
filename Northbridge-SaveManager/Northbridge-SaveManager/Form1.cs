using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NorthbridgeSubSystem.Properties;

namespace NorthbridgeSubSystem
{
    public partial class Form1 : Form
    {
        private static readonly string SaveLocation = Application.StartupPath;
        private static readonly string RgssLib = Application.StartupPath + "\\System\\RGSS301.dll";
        private static readonly string GameFile = Application.StartupPath + "\\Game.rgss3a";
        private static readonly string PlayerFile = Application.StartupPath + "\\Game.exe";
        private readonly ProcessStartInfo _gameInfo = new ProcessStartInfo("Game.exe");
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
                DeleteCompleteLabel.Visible = true;
            }
            catch (Exception)
            {
                DeleteFailedLabel.Visible = true;
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
                    File.Copy(ImportFilePicker.FileName, SaveLocation + "GameSave" + numericUpDown1.Value + ".isgsf");
                else
                    File.Copy(ImportFilePicker.FileName, SaveLocation + ImportFilePicker.SafeFileName, true);
                ExportButton.Enabled = Directory.GetFiles(SaveLocation, "*.isgsf").Length > 0;
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
            if (copySubDirs)
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
            var areSavesAvaliable = Directory.GetFiles(SaveLocation, "Save*.rvdata2").Length > 0;
            if (areSavesAvaliable)
                DirectoryCopy(SaveLocation,
                    Settings.Default.AutoBackupLocation + "\\" + "Backup" + DateTime.Now.ToString("yyyyMMddHHmm") + "\\",
                    true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            foreach (var arg in args)
            {
                if (arg != "-NBSettings")
                {
                    if (!File.Exists(PlayerFile) || !File.Exists(RgssLib) || !File.Exists(GameFile))
                    {
                        MessageBox.Show(@"Missing file(s). Aborting.");
                        Close();
                    }
                    else
                    {
                        Hide();
                        _gameProcess.StartInfo = _gameInfo;
                        _gameProcess.Start();
                        _gameProcess.WaitForExit();
                        if (Settings.Default.AutoBackupEnabled) AutoBackupCode();
                        Close();
                    }
                }
            }
        }
    }
}
