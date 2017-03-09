using System.IO;
using NorthbridgeSubSystem.Properties;

namespace NorthbridgeSubSystem
{
    static class BackupEngine
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
    }
}
