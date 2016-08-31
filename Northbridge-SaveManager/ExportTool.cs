using System;
using System.IO;
using System.Windows.Forms;

namespace NorthbridgeSubSystem
{
    public partial class ExportTool : Form
    {
        //Location of the Save folder.
        private static readonly string SaveLocation = Application.StartupPath + "\\Saves\\";
        //Set the extension of the save file Add "*".
        private const string SaveFileExtension = "*.rvdata2";
        //The name of the save file. Usualy they are SaveXX.
        private const string SaveFilename = "Save";
        //Initalise a structure that contains necessary info (such as arguments).
        private const int Saveslots = 16;
        private int _n;
        public ExportTool()
        {
            InitializeComponent();
        }

        private void ExportTool_Load(object sender, EventArgs e)
        {
            

            for (_n = 1; _n <= Saveslots; _n++)
            {
                if (File.Exists(SaveLocation + SaveFilename + "0" + _n + SaveFileExtension))
                    checkedListBox1.Items.Add(SaveFilename + "0" + _n + SaveFileExtension);
                else if (File.Exists(SaveLocation + SaveFilename + _n + SaveFileExtension))
                {
                    checkedListBox1.Items.Add(SaveFilename + _n + SaveFileExtension);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var eli = ExportFolderDialog.ShowDialog();
                if (eli != DialogResult.OK) return;

                foreach (var str in checkedListBox1.CheckedItems)
                {
                    MessageBox.Show(str.ToString());
                    File.Copy(SaveLocation + "\\" + str, ExportFolderDialog.SelectedPath + "\\" + str, true); 
                }
                //for (_n = 0; _n <= checkedListBox1.CheckedIndices.Count; _n++)
                //{
                //    if (checkedListBox1.GetItemCheckState(_n) == CheckState.Checked)
                //    {
                //        MessageBox.Show((checkedListBox1.GetItemCheckState(_n) == CheckState.Checked).ToString());
                //        if (_n < 10)
                //            File.Copy(SaveLocation + "\\" + checkedListBox1.CheckedIndices[_n],
                //                ExportFolderDialog.SelectedPath + "\\" + checkedListBox1.GetItemText(_n), true);
                //    }
                //}
                MessageBox.Show(@"Export Complete!");
            }

            catch (Exception)
            {
                MessageBox.Show(@"Failed to export!");
            }
            Close();
        }
    }
}
