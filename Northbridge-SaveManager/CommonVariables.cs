using System;
using System.Diagnostics;
using System.Windows.Forms;
using NorthbridgeSubSystem.Properties;

namespace NorthbridgeSubSystem
{
    internal static class CommonVariables
    {
        //Initialising a few static variables here. Add anything you want the executable to access frequently here as variables.

        //Location of the Save folder.
        public static readonly string SaveLocation = Application.StartupPath + "\\Saves\\";
        //Location of the RGSS Library (RMXP/RMVX/RMVXA).
        public static readonly string RgssLib = Application.StartupPath + "\\System\\RGSS301.dll";
        //Location of the Game file (RMXP/RMVX/RMVXA).
        public static readonly string GameFile = Application.StartupPath + "\\Game.rgss3a";
        //Location of the game executable.
        public static readonly string PlayerFile = Application.StartupPath + "\\Game.exe";
        //Set the extension of the save file Add "*".
        public const string SaveFileExtension = "*.rvdata2";
        //The name of the save file. Usualy they are SaveXX.
        public const string SaveFilename = "Save";
        //Initalise a structure that contains necessary info (such as arguments).
        public static readonly ProcessStartInfo GameInfo = new ProcessStartInfo(PlayerFile);
        //This is the format of the folder when the backup is executed.
        public static readonly string BackupFolderSetup = Settings.Default.AutoBackupLocation + "\\" + "Backup" + DateTime.Now.ToString("yyyyMMddHHmm");
        //Interger used as a check for the backup system (Normal Mode only).
        //If this interger is higher than 0, issue a backup.
        public static int CountChanges;
        //Reserved variable to run the game. Especially when arguments are added.
        public static readonly Process GameProcess = new Process();
    }
}
