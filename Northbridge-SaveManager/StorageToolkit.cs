using System;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace NorthbridgeSubSystem
{
    internal static class StorageToolkit
    {

        public static void DiskCheck(string folderLocation, bool isTarget)
        {
            var permissionSet = new PermissionSet(PermissionState.None);
            var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, folderLocation);
            var readPermission = new FileIOPermission(FileIOPermissionAccess.Read, folderLocation);
            permissionSet.AddPermission(writePermission);
            permissionSet.AddPermission(readPermission);
            var drive = new DriveInfo(folderLocation);
            if (!drive.IsReady) return;
            if (isTarget)
            CommonVariables.TgtIsDriveReady = true;
            else
            CommonVariables.IsDriveReady = true;
            var a = new DriveInfo(drive.Name);
            if (a.AvailableFreeSpace > 70)
            {
                if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet)) return;
                if (isTarget)
                CommonVariables.TgtPermissionError = true;
                else
                    CommonVariables.PermissionError = true;
            }
            else
            {
                if (isTarget)
                CommonVariables.TgtSpaceError = true;
                else
                CommonVariables.SpaceError = true;
            }
        }

        public static void DirectoryCopy(
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
    }
}
