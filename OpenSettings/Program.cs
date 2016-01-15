using System;
using System.Diagnostics;

namespace OpenSettings
{
    static class Program
    {
        static void Main()
        {
            Process.Start("NorthbridgeSubsystem.exe","-NBSettings");
            Environment.Exit(0);
        }
    }
}
