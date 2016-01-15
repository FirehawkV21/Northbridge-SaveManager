using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OpenSettings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = Application.StartupPath + "NorthbridgeSubsystem.exe",
                Arguments = "-NBSetup"
            };
            Process.Start(startInfo);
            Close();
        }
    }
}
