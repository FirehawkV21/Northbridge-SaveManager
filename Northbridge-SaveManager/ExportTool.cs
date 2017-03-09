using System;
using System.IO;
using System.Windows.Forms;

namespace NorthbridgeSubSystem
{
    public partial class ExportTool : Form
    {
        private int _n;
        public ExportTool()
        {
            InitializeComponent();
        }

        private void ExportTool_Load(object sender, EventArgs e)
        {
            

            for (_n = 1; _n <= CommonVariables.Saveslots; _n++)
            {
                if (File.Exists(CommonVariables.SaveLocation + CommonVariables.SaveFilename + "0" + _n + CommonVariables.SaveFileExtension))
                    checkedListBox1.Items.Add(CommonVariables.SaveFilename + "0" + _n + CommonVariables.SaveFileExtension);
                else if (File.Exists(CommonVariables.SaveLocation + CommonVariables.SaveFilename + _n + CommonVariables.SaveFileExtension))
                {
                    checkedListBox1.Items.Add(CommonVariables.SaveFilename + _n + CommonVariables.SaveFileExtension);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var eli = ExportFolderDialog.ShowDialog();
                if (eli != DialogResult.OK) return;
                StorageToolkit.DiskCheck(ExportFolderDialog.SelectedPath);
                if (CommonVariables.PermissionError) MessageBox.Show(@"Cannot access the target folder.", @"Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (CommonVariables.SpaceError) MessageBox.Show(@"Not enough space on the storage drive.", @"Out of space", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!CommonVariables.IsDriveReady) MessageBox.Show(@"The drive that stores the target folder isn't ready.", @"Drive not ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (CommonVariables.PermissionError || CommonVariables.SpaceError || !CommonVariables.IsDriveReady) return;
                foreach (var str in checkedListBox1.CheckedItems)
                {
                    MessageBox.Show(str.ToString());
                    File.Copy(CommonVariables.SaveLocation + "\\" + str, ExportFolderDialog.SelectedPath + "\\" + str, true); 
                }

                MessageBox.Show(@"Export Complete!", @"Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception)
            {
                MessageBox.Show(@"Failed to export!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}
