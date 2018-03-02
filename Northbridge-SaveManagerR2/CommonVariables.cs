using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Northbridge_SaveManagerR2.Properties;

namespace Northbridge_SaveManagerR2
{
    class CommonVariables
    {
        //Initialising a few static variables here. Add anything you want the executable to access frequently here as variables.

        //Location of the Save folder.
        public static readonly string SaveLocation = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + "\\Saves\\";
        //Location of the RGSS Library (RMXP/RMVX/RMVXA).
        public static readonly string RgssLib = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + "\\System\\RGSS301.dll";
        //Location of the Game file (RMXP/RMVX/RMVXA).
        public static readonly string GameFile = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + "\\Game.rgss3a";
        //Location of the game executable.
        public static readonly string PlayerFile = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + "\\Game.exe";
        //Set the extension of the save file Add "*".
        public const string SaveFileExtension = "*.rvdata2";
        //The name of the save file. Usualy they are SaveXX.
        public const string SaveFilename = "Save";
        //Initalise a structure that contains necessary info (such as arguments).
        public static readonly ProcessStartInfo GameInfo = new ProcessStartInfo(PlayerFile);
        //This is the format of the folder when the backup is executed.
        public static readonly string BackupFolderSetup = Settings.Default.AutoBackupLocation + "\\" + "Backup" + DateTime.Now.ToString("yyyyMMddHHmm");
        //How many slots the game has.
        public const int Saveslots = 16;
        //Interger used as a check for the backup system (Normal Mode only).
        //If this interger is higher than 0, issue a backup.
        public static int CountChanges;
        //Reserved variable to run the game. Especially when arguments are added.
        public static readonly Process GameProcess = new Process();
        //Reserved variables for the DiskCheck.
        public static bool IsDriveReady;
        public static bool SpaceError;
        public static bool PermissionError;
        public static bool TgtIsDriveReady;
        public static bool TgtSpaceError;
        public static bool TgtPermissionError;
        public static bool IsSaveAvailable;
    }
}
