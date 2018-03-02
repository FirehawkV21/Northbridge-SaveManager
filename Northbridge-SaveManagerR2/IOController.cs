using System;
using System.IO;
using System.IO.Compression;
using System.Security;
using System.Security.Permissions;
using System.Windows;
using Northbridge_SaveManagerR2.Properties;


namespace Northbridge_SaveManagerR2
{
    public static class IoController
    {
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }


        public static void ArchiveCodec(bool readarchive, string sourceLocation, string dropLocation)
        {

                if (readarchive == false)
                    try
                    {
                        ZipFile.CreateFromDirectory(sourceLocation, dropLocation, CompressionLevel.Optimal, false);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(Resources.CompressionFailedString, Resources.CommonWordsError, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
            else
                {
                    if(Directory.Exists(Path.Combine(Path.GetTempPath(), "MicroUnpack"))) Directory.Delete(Path.Combine(Path.GetTempPath(), "MicroUnpack"), true);
                    ZipFile.ExtractToDirectory(sourceLocation, Path.Combine(Path.GetTempPath(), "MicroUnpack"));
                    DirectoryCopy(Path.Combine(Path.GetTempPath(), "MicroUnpack"), dropLocation, true);
                    Directory.Delete(Path.Combine(Path.GetTempPath(), "MicroUnpack"), true);

                }


            //var archivepack = readarchive == false ? new ZipFile() : new ZipFile(zipLocation);
            //if (readarchive == false)
            //{

            //    //archivepack.Encryption = EncryptionAlgorithm.WinZipAes256;
            //    //archivepack.CompressionMethod = CompressionMethod.BZip2;
            //    //archivepack.Password = CommonVariables.Passkey;
            //    //archivepack.AddDirectory(CommonVariables.SaveLocation);
            //    //archivepack.Save($"{zipLocation}\\ImmortalSinsArchive" + DateTime.Now.ToString("yyyyMMddHHmm") +
            //    //                 ".isarc2");
            //}
            //else
            //{
            //    Directory.CreateDirectory(Path.GetTempPath() + "\\ImportFilePack\\");
            //    archivepack.Password = CommonVariables.Passkey;
            //    archivepack.ExtractAll(Path.GetTempPath() + "\\ImportFilePack\\");
            //    for (var x = 1; x < 25; x++)
            //        if (x < 10)
            //            File.Copy(Path.GetTempPath() + @"\ImportFilePack\GameSave0" + x + ".isgsf",
            //                CommonVariables.SaveLocation + @"\GameSave0" + x + @".isgsf", true);
            //        else
            //            File.Copy(Path.GetTempPath() + @"\ImportFilePack\GameSave" + x + ".isgsf",
            //                CommonVariables.SaveLocation + @"\GameSave" + x + ".isgsf", true);
            //    // DirectoryCopy(Path.GetTempPath() + "\\ImportFilePack\\", CommonVariables.SaveLocation, true);
            //    Directory.Delete(Path.GetTempPath() + "\\ImportFilePack\\", true);
            //}
        }

        public static void ArchivePackaging(string source, string zipLocation)
        {
            //var archivepack = new ZipFile
            //{
            //    Encryption = EncryptionAlgorithm.WinZipAes256,
            //    Password = CommonVariables.Passkey
            //};
            //archivepack.AddDirectory(source);
            //    archivepack.Save($"{zipLocation}\\ImmortalSinsArchive" + DateTime.Now.ToString("yyyyMMddHHmm") + ".isarc");
        }

        public static void DiskCheck(string folderLocation)
        {
            var permissionSet = new PermissionSet(PermissionState.None);
            var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, folderLocation);
            var readPermission = new FileIOPermission(FileIOPermissionAccess.Read, folderLocation);
            permissionSet.AddPermission(writePermission);
            permissionSet.AddPermission(readPermission);
            var drive = new DriveInfo(folderLocation);
            if (!drive.IsReady) return;
            CommonVariables.IsDriveReady = true;
            var a = new DriveInfo(drive.Name);
            if (a.AvailableFreeSpace > 70)
            {
                if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet)) return;
                CommonVariables.PermissionError = true;
            }
            else
            {
                CommonVariables.SpaceError = true;
            }
        }
    }
}