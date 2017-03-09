using System.IO;
using NorthbridgeSubSystem.Properties;

namespace NorthbridgeSubSystem
{
    internal static class BackupEngine
    {
        public static void BackupModeSetup()
        {
            if (!Settings.Default.AutoBackupEnabled || Settings.Default.AutoBackupLocation == null) return;
            var svw = new FileSystemWatcher
            {
                Path = CommonVariables.SaveLocation,
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = CommonVariables.SaveFilename + CommonVariables.SaveFileExtension
            };
            svw.Changed += OnChanged;
            svw.Created += OnChanged;
            svw.Deleted += OnChanged;
            svw.EnableRaisingEvents = true;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)

        {
            if (Settings.Default.SingleBackupMode)
            {
                File.Copy(e.FullPath, Settings.Default.AutoBackupLocation + "\\" + e.Name, true);
            }
            else
            {
                CommonVariables.CountChanges = CommonVariables.CountChanges + 1;
            }
        }

        public static void AutoBackupCode()
        {
            var areSavesAvaliable = Directory.GetFiles(CommonVariables.SaveLocation, CommonVariables.SaveFilename + CommonVariables.SaveFileExtension).Length > 0;
            var i = 1;
            if (!areSavesAvaliable) return;
            if (!Directory.Exists(CommonVariables.BackupFolderSetup))
                StorageToolkit.DirectoryCopy(CommonVariables.SaveLocation, CommonVariables.BackupFolderSetup, true);
            else
            {
                //This variable sets a new location to create the backup, should a folder with the same name exists.
                //Adjust the format to your liking.
                var newBackupFolder = CommonVariables.BackupFolderSetup + "-" + i + "\\";
                while (Directory.Exists(CommonVariables.BackupFolderSetup + "-" + i + "\\"))
                {
                    i++;
                }
                StorageToolkit.DirectoryCopy(CommonVariables.SaveLocation, newBackupFolder, true);
            }
        }
    }
}
