namespace NorthbridgeSubSystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RestoreFailedLabel = new System.Windows.Forms.Label();
            this.RestoreCompleteLabel = new System.Windows.Forms.Label();
            this.RestoreBackupButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.DeleteBackupsFailed = new System.Windows.Forms.Label();
            this.BackupDeleteCompleteLabel = new System.Windows.Forms.Label();
            this.DeleteBackupCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DeleteBackupButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EnableSnapshotCheckbox = new System.Windows.Forms.CheckBox();
            this.BackupFailedLabel = new System.Windows.Forms.Label();
            this.BackupCompleteLabel = new System.Windows.Forms.Label();
            this.TestBackupButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.LocationBackup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AutoBackupCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeleteFailedLabel = new System.Windows.Forms.Label();
            this.DeleteCompleteLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DeleteAllSavesCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectiveExportButton = new System.Windows.Forms.Button();
            this.ExportFailedLabel = new System.Windows.Forms.Label();
            this.ExportCompleteLabel = new System.Windows.Forms.Label();
            this.ExportButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.SlotSelectCheckBox = new System.Windows.Forms.CheckBox();
            this.ImportFailedLabel = new System.Windows.Forms.Label();
            this.ImportCompleteLabel = new System.Windows.Forms.Label();
            this.ImportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.ImportFilePicker = new System.Windows.Forms.OpenFileDialog();
            this.ExportFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.BackupFolderPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.RestoreFolderPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.ExportFilePicker = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.closeButton);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox6);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RestoreFailedLabel);
            this.groupBox5.Controls.Add(this.RestoreCompleteLabel);
            this.groupBox5.Controls.Add(this.RestoreBackupButton);
            this.groupBox5.Controls.Add(this.label8);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // RestoreFailedLabel
            // 
            resources.ApplyResources(this.RestoreFailedLabel, "RestoreFailedLabel");
            this.RestoreFailedLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.RestoreFailedLabel.Name = "RestoreFailedLabel";
            // 
            // RestoreCompleteLabel
            // 
            resources.ApplyResources(this.RestoreCompleteLabel, "RestoreCompleteLabel");
            this.RestoreCompleteLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.RestoreCompleteLabel.Name = "RestoreCompleteLabel";
            // 
            // RestoreBackupButton
            // 
            resources.ApplyResources(this.RestoreBackupButton, "RestoreBackupButton");
            this.RestoreBackupButton.Name = "RestoreBackupButton";
            this.RestoreBackupButton.UseVisualStyleBackColor = true;
            this.RestoreBackupButton.Click += new System.EventHandler(this.RestoreBackupButton_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.DeleteBackupsFailed);
            this.groupBox6.Controls.Add(this.BackupDeleteCompleteLabel);
            this.groupBox6.Controls.Add(this.DeleteBackupCheckBox);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.DeleteBackupButton);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // DeleteBackupsFailed
            // 
            resources.ApplyResources(this.DeleteBackupsFailed, "DeleteBackupsFailed");
            this.DeleteBackupsFailed.ForeColor = System.Drawing.Color.DarkRed;
            this.DeleteBackupsFailed.Name = "DeleteBackupsFailed";
            // 
            // BackupDeleteCompleteLabel
            // 
            resources.ApplyResources(this.BackupDeleteCompleteLabel, "BackupDeleteCompleteLabel");
            this.BackupDeleteCompleteLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.BackupDeleteCompleteLabel.Name = "BackupDeleteCompleteLabel";
            // 
            // DeleteBackupCheckBox
            // 
            resources.ApplyResources(this.DeleteBackupCheckBox, "DeleteBackupCheckBox");
            this.DeleteBackupCheckBox.Name = "DeleteBackupCheckBox";
            this.DeleteBackupCheckBox.UseVisualStyleBackColor = true;
            this.DeleteBackupCheckBox.Click += new System.EventHandler(this.DeleteBackupCheckBox_CheckedChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // DeleteBackupButton
            // 
            resources.ApplyResources(this.DeleteBackupButton, "DeleteBackupButton");
            this.DeleteBackupButton.Name = "DeleteBackupButton";
            this.DeleteBackupButton.UseVisualStyleBackColor = true;
            this.DeleteBackupButton.Click += new System.EventHandler(this.DeleteBackupButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EnableSnapshotCheckbox);
            this.groupBox4.Controls.Add(this.BackupFailedLabel);
            this.groupBox4.Controls.Add(this.BackupCompleteLabel);
            this.groupBox4.Controls.Add(this.TestBackupButton);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.BrowseButton);
            this.groupBox4.Controls.Add(this.LocationBackup);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.AutoBackupCheckbox);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // EnableSnapshotCheckbox
            // 
            resources.ApplyResources(this.EnableSnapshotCheckbox, "EnableSnapshotCheckbox");
            this.EnableSnapshotCheckbox.Name = "EnableSnapshotCheckbox";
            this.EnableSnapshotCheckbox.UseVisualStyleBackColor = true;
            // 
            // BackupFailedLabel
            // 
            resources.ApplyResources(this.BackupFailedLabel, "BackupFailedLabel");
            this.BackupFailedLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.BackupFailedLabel.Name = "BackupFailedLabel";
            // 
            // BackupCompleteLabel
            // 
            resources.ApplyResources(this.BackupCompleteLabel, "BackupCompleteLabel");
            this.BackupCompleteLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.BackupCompleteLabel.Name = "BackupCompleteLabel";
            // 
            // TestBackupButton
            // 
            resources.ApplyResources(this.TestBackupButton, "TestBackupButton");
            this.TestBackupButton.Name = "TestBackupButton";
            this.TestBackupButton.UseVisualStyleBackColor = true;
            this.TestBackupButton.Click += new System.EventHandler(this.TestBackupButton_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // BrowseButton
            // 
            resources.ApplyResources(this.BrowseButton, "BrowseButton");
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // LocationBackup
            // 
            resources.ApplyResources(this.LocationBackup, "LocationBackup");
            this.LocationBackup.Name = "LocationBackup";
            this.LocationBackup.TextChanged += new System.EventHandler(this.LocationBackup_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // AutoBackupCheckbox
            // 
            resources.ApplyResources(this.AutoBackupCheckbox, "AutoBackupCheckbox");
            this.AutoBackupCheckbox.Name = "AutoBackupCheckbox";
            this.AutoBackupCheckbox.UseVisualStyleBackColor = true;
            this.AutoBackupCheckbox.CheckedChanged += new System.EventHandler(this.AutoBackupCheckbox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DeleteFailedLabel);
            this.groupBox3.Controls.Add(this.DeleteCompleteLabel);
            this.groupBox3.Controls.Add(this.DeleteButton);
            this.groupBox3.Controls.Add(this.DeleteAllSavesCheckBox);
            this.groupBox3.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // DeleteFailedLabel
            // 
            resources.ApplyResources(this.DeleteFailedLabel, "DeleteFailedLabel");
            this.DeleteFailedLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.DeleteFailedLabel.Name = "DeleteFailedLabel";
            // 
            // DeleteCompleteLabel
            // 
            resources.ApplyResources(this.DeleteCompleteLabel, "DeleteCompleteLabel");
            this.DeleteCompleteLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.DeleteCompleteLabel.Name = "DeleteCompleteLabel";
            // 
            // DeleteButton
            // 
            resources.ApplyResources(this.DeleteButton, "DeleteButton");
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DeleteAllSavesCheckBox
            // 
            resources.ApplyResources(this.DeleteAllSavesCheckBox, "DeleteAllSavesCheckBox");
            this.DeleteAllSavesCheckBox.Name = "DeleteAllSavesCheckBox";
            this.DeleteAllSavesCheckBox.UseVisualStyleBackColor = true;
            this.DeleteAllSavesCheckBox.CheckedChanged += new System.EventHandler(this.DeleteAllSavesCheckBox_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectiveExportButton);
            this.groupBox2.Controls.Add(this.ExportFailedLabel);
            this.groupBox2.Controls.Add(this.ExportCompleteLabel);
            this.groupBox2.Controls.Add(this.ExportButton);
            this.groupBox2.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // SelectiveExportButton
            // 
            resources.ApplyResources(this.SelectiveExportButton, "SelectiveExportButton");
            this.SelectiveExportButton.Name = "SelectiveExportButton";
            this.SelectiveExportButton.UseVisualStyleBackColor = true;
            this.SelectiveExportButton.Click += new System.EventHandler(this.SelectiveExportButton_Click);
            // 
            // ExportFailedLabel
            // 
            resources.ApplyResources(this.ExportFailedLabel, "ExportFailedLabel");
            this.ExportFailedLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ExportFailedLabel.Name = "ExportFailedLabel";
            // 
            // ExportCompleteLabel
            // 
            resources.ApplyResources(this.ExportCompleteLabel, "ExportCompleteLabel");
            this.ExportCompleteLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.ExportCompleteLabel.Name = "ExportCompleteLabel";
            // 
            // ExportButton
            // 
            resources.ApplyResources(this.ExportButton, "ExportButton");
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.SlotSelectCheckBox);
            this.groupBox1.Controls.Add(this.ImportFailedLabel);
            this.groupBox1.Controls.Add(this.ImportCompleteLabel);
            this.groupBox1.Controls.Add(this.ImportButton);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SlotSelectCheckBox
            // 
            resources.ApplyResources(this.SlotSelectCheckBox, "SlotSelectCheckBox");
            this.SlotSelectCheckBox.Name = "SlotSelectCheckBox";
            this.SlotSelectCheckBox.UseVisualStyleBackColor = true;
            this.SlotSelectCheckBox.CheckedChanged += new System.EventHandler(this.SlotSelectCheckBox_CheckedChanged);
            // 
            // ImportFailedLabel
            // 
            resources.ApplyResources(this.ImportFailedLabel, "ImportFailedLabel");
            this.ImportFailedLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ImportFailedLabel.Name = "ImportFailedLabel";
            // 
            // ImportCompleteLabel
            // 
            resources.ApplyResources(this.ImportCompleteLabel, "ImportCompleteLabel");
            this.ImportCompleteLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.ImportCompleteLabel.Name = "ImportCompleteLabel";
            // 
            // ImportButton
            // 
            resources.ApplyResources(this.ImportButton, "ImportButton");
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ImportFilePicker
            // 
            this.ImportFilePicker.FileName = "openFileDialog1";
            resources.ApplyResources(this.ImportFilePicker, "ImportFilePicker");
            // 
            // BackupFolderPicker
            // 
            resources.ApplyResources(this.BackupFolderPicker, "BackupFolderPicker");
            // 
            // RestoreFolderPicker
            // 
            resources.ApplyResources(this.RestoreFolderPicker, "RestoreFolderPicker");
            // 
            // ExportFilePicker
            // 
            resources.ApplyResources(this.ExportFilePicker, "ExportFilePicker");
            this.ExportFilePicker.Multiselect = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label RestoreFailedLabel;
        private System.Windows.Forms.Label RestoreCompleteLabel;
        private System.Windows.Forms.Button RestoreBackupButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label DeleteBackupsFailed;
        private System.Windows.Forms.Label BackupDeleteCompleteLabel;
        private System.Windows.Forms.CheckBox DeleteBackupCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button DeleteBackupButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label BackupFailedLabel;
        private System.Windows.Forms.Label BackupCompleteLabel;
        private System.Windows.Forms.Button TestBackupButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox LocationBackup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox AutoBackupCheckbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label DeleteFailedLabel;
        private System.Windows.Forms.Label DeleteCompleteLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.CheckBox DeleteAllSavesCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ExportFailedLabel;
        private System.Windows.Forms.Label ExportCompleteLabel;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox SlotSelectCheckBox;
        private System.Windows.Forms.Label ImportFailedLabel;
        private System.Windows.Forms.Label ImportCompleteLabel;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.OpenFileDialog ImportFilePicker;
        private System.Windows.Forms.FolderBrowserDialog ExportFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog BackupFolderPicker;
        private System.Windows.Forms.FolderBrowserDialog RestoreFolderPicker;
        private System.Windows.Forms.Button SelectiveExportButton;
        private System.Windows.Forms.OpenFileDialog ExportFilePicker;
        private System.Windows.Forms.CheckBox EnableSnapshotCheckbox;
    }
}

