using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Northbridge_SaveManagerR2.Properties;
using MessageBox = System.Windows.MessageBox;

namespace Northbridge_SaveManagerR2
{
    class CommonProcedures
    {
        public static void CheckDrive()
        {
            IoController.DiskCheck(CommonVariables.SaveLocation);
            if (!CommonVariables.IsDriveReady)
                MessageBox.Show("The storage drive that stores the save files isn't ready.", "Drive not ready", MessageBoxButton.OK, MessageBoxImage.Warning);
            if (CommonVariables.PermissionError)
                MessageBox.Show(
                    "The game can't write on the save folder. Please check the folder permissions.", "Permission Error", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            if (CommonVariables.SpaceError)
                MessageBox.Show("The game needs at least 1MB of free space. Please free up some space from this machine, so you can save your progress and settings.",
                    "Not enough space", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ImportCode(IEnumerable<string> fileName, bool multiImport, int? slot)
        {
            if (multiImport)
            {
                var count = slot;
                var i = 0;
                var limit = 24 - (Convert.ToInt32(count) + i);
                foreach (var fileQueue in fileName)
                {
                    if (limit < 0)
                    {
                        MessageBox.Show(Resources.SlotOverflowErrorString, Resources.SlotOverflowErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new ApplicationException("Out of limit");
                        //break;
                    }
                    while (File.Exists(CommonVariables.SaveLocation + fileName))
                    {
                        var checker = MessageBox.Show(Resources.FileOverwriteCheckString1 + fileName + Resources.FileOverwriteCheckString2, Resources.FileOverwriteCheckTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (checker == (MessageBoxResult) DialogResult.No) ++i;
                        else break;
                    }
                    if (count >= 10 || count + i >= 10)
                        File.Copy(fileQueue,
                            CommonVariables.SaveLocation + @"\" + "GameSave" + (count + i) + ".isgsf", true);
                    else
                        File.Copy(fileQueue,
                            CommonVariables.SaveLocation + @"\" + "GameSave0" + (count + i) + ".isgsf", true);
                    i++;
                    --limit;
                }
            }
            else
            {
                if (File.Exists(CommonVariables.SaveLocation + fileName))
                    foreach (var fileQueue in fileName)

                        File.Copy(fileQueue, CommonVariables.SaveLocation + @"\" + Path.GetFileName(fileQueue), true);
            }
            CommonVariables.IsSaveAvailable = GetFolderSaves();
        }

        public static bool GetFolderSaves()
        {
            return Directory.GetFiles(CommonVariables.SaveLocation,
                       CommonVariables.SaveFilename + CommonVariables.SaveFileExtension).Length > 0;
        }
    }
}
