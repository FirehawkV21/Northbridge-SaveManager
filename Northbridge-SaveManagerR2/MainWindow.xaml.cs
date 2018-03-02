using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using Path = System.Windows.Shapes.Path;

namespace Northbridge_SaveManagerR2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int Slotlimit { get; } = CommonVariables.Saveslots;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var importdlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = "GameSave*.isgsf",
                Filter = "Immortal Sins GameSave File|GameSave*.isgsf|Immortal Sins Save Archive v2|*.isarc2",
                Title = "Select the files/archive to import.",
                Multiselect = true
            };

            var importresult = importdlg.ShowDialog();
            if (importresult != true) return;
            try
            {
                if (Path.GetExtension(importdlg.SafeFileName) == ".isarc2")
                {
                    if (!Directory.Exists(CommonVariables.SaveLocation))
                        Directory.CreateDirectory(CommonVariables.SaveLocation);
                    IoController.ArchiveCodec(true, importdlg.FileName, CommonVariables.SaveLocation);
                }
                else

                {
                    CommonProcedures.ImportCode(importdlg.FileNames, ChangeSaveSlotCheckbox.IsEnabled,
                        SlotSelector.Value);
                }
                CommonVariables.IsSaveAvailable = CommonProcedures.GetFolderSaves();
                MessageBox.Show(Resources.ImportSavesComplete, Resources.CommonWordsFinish, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ImportSavesFailedString, Resources.CommonWordsError, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportSavesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportAllButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseLocationButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TestBackupsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBackupsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
