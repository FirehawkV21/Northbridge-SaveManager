using NorthbridgeCTLib;
using NorthbridgeLauncher.Properties;
using System;
using System.IO;
using System.Windows;

namespace NorthbridgeLauncher
{
    internal static class BackupEngine
    {
        public static readonly string BackupFolder = Settings.Default.AutoBackupLocation + "\\" + "Backup" +
                                                     DateTime.Now.ToString("yyyyMMddHHmm") + "\\";

        private static readonly string SingleBackupLocation = Path.Combine(Path.GetTempPath() + "\\SingleBackupTemp\\");
        private static bool _areSavesAvaliable;
        public static int CountChanges;
        private static readonly string SearchLocation = Settings.Default.CompatMode ? "C:\\Immortal Sins\\Saves\\" : CommonVariables.SaveLocation;

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (Settings.Default.SingleBackupMode)
            {
                if (Settings.Default.ArchiveBackups) File.Copy(e.FullPath, SingleBackupLocation + e.Name, true);
                else File.Copy(e.FullPath, Settings.Default.AutoBackupLocation + e.Name, true);
            }             
                CountChanges = CountChanges + 1;
        }

        public static void MonitorSetupCode()
        {
            IoController.DiskCheck(Settings.Default.AutoBackupLocation);
            if (CommonVariables.PermissionError)
                MessageBox.Show(Resources.BackupMonitorPermissionError, Resources.CommonWordWarning, MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else if (CommonVariables.SpaceError)
                MessageBox.Show(Resources.BackupMonitorSpaceError,
                    Resources.CommonWordWarning, MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else if (!CommonVariables.IsDriveReady)
                MessageBox.Show(Resources.BackupMonitorDNRError, Resources.CommonWordWarning, MessageBoxButton.OK, MessageBoxImage.Warning);
            if (CommonVariables.PermissionError || CommonVariables.SpaceError || !CommonVariables.IsDriveReady) return;
            if (Settings.Default.SingleBackupMode) UnpackSingleBackupPackage();
            var svw = new FileSystemWatcher
            {
                Path = SearchLocation,
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "GameSave*.isgsf"
            };
            svw.Changed += OnChanged;
            svw.Created += OnChanged;
            svw.Deleted += OnChanged;
            svw.EnableRaisingEvents = true;
        }

        public static void SnapshotBackupCode()
        {
            var i = 1;
            _areSavesAvaliable = Directory.GetFiles(CommonVariables.SaveLocation, "*.isgsf").Length > 0;

            if (!_areSavesAvaliable) return;
            if (Settings.Default.ArchiveBackups)
                IoController.ArchiveCodec(false, SearchLocation, Settings.Default.AutoBackupLocation + "\\ImmortalSins-BackupSnapshot-" + DateTime.Now.ToString("yyyyMMddHHmm") + ".isarc2");
            else
            {
                if (!Directory.Exists(BackupFolder))
                    IoController.DirectoryCopy(SearchLocation, BackupFolder, true);
                else
                {
                    var newBackupFolder = BackupFolder + "-" + i + "\\";
                    while (Directory.Exists(BackupFolder + "-" + i + "\\"))
                        i++;
                    IoController.DirectoryCopy(SearchLocation, newBackupFolder, true);
                }
            }
        }

        public static void SingleBackupArchive()
        {
            if (!Directory.Exists(SingleBackupLocation)) return;
            IoController.ArchiveCodec(false, SingleBackupLocation, Settings.Default.AutoBackupLocation + "\\ImmortalSins-SingleBackup.isarc2");
            Directory.Delete(SingleBackupLocation, true);
        }

        private static void UnpackSingleBackupPackage()
        {
            if (Directory.Exists(SingleBackupLocation)) Directory.Delete(SingleBackupLocation, true);
            if (File.Exists(Settings.Default.AutoBackupLocation + "\\ImmortalSins-SingleBackup.isarc2"))
                IoController.ArchiveCodec(true,
                    Settings.Default.AutoBackupLocation + "\\ImmortalSins-SingleBackup.isarc2", SingleBackupLocation);
            else Directory.CreateDirectory(SingleBackupLocation);
        }
    }
}