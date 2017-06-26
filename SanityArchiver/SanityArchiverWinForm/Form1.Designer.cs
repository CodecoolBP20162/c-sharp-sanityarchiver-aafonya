namespace SanityArchiverWinForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Browse = new System.Windows.Forms.Button();
            this.FileBrowser = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Directories = new System.Windows.Forms.Label();
            this.Files = new System.Windows.Forms.Label();
            this.ActualDirectoriesName = new System.Windows.Forms.TextBox();
            this.ActualDirectory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(323, 1);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "Browse Files";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileBrowser
            // 
            this.FileBrowser.Location = new System.Drawing.Point(275, 39);
            this.FileBrowser.Name = "FileBrowser";
            this.FileBrowser.Size = new System.Drawing.Size(171, 46);
            this.FileBrowser.TabIndex = 1;
            this.FileBrowser.Text = "FileBrowser";
            this.FileBrowser.UseVisualStyleBackColor = true;
            this.FileBrowser.Click += new System.EventHandler(this.FileBrowser_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 163);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 155);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(447, 163);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 155);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Directories
            // 
            this.Directories.AutoSize = true;
            this.Directories.Location = new System.Drawing.Point(146, 106);
            this.Directories.Name = "Directories";
            this.Directories.Size = new System.Drawing.Size(57, 13);
            this.Directories.TabIndex = 3;
            this.Directories.Text = "Directories";
            // 
            // Files
            // 
            this.Files.AutoSize = true;
            this.Files.Location = new System.Drawing.Point(548, 106);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(28, 13);
            this.Files.TabIndex = 4;
            this.Files.Text = "Files";
            // 
            // ActualDirectoriesName
            // 
            this.ActualDirectoriesName.Location = new System.Drawing.Point(133, 137);
            this.ActualDirectoriesName.Name = "ActualDirectoriesName";
            this.ActualDirectoriesName.Size = new System.Drawing.Size(140, 20);
            this.ActualDirectoriesName.TabIndex = 5;
            this.ActualDirectoriesName.TextChanged += new System.EventHandler(this.ActualDirectoriesName_TextChanged);
            // 
            // ActualDirectory
            // 
            this.ActualDirectory.AutoSize = true;
            this.ActualDirectory.Location = new System.Drawing.Point(45, 137);
            this.ActualDirectory.Name = "ActualDirectory";
            this.ActualDirectory.Size = new System.Drawing.Size(82, 13);
            this.ActualDirectory.TabIndex = 6;
            this.ActualDirectory.Text = "Actual Directory";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 396);
            this.Controls.Add(this.ActualDirectory);
            this.Controls.Add(this.ActualDirectoriesName);
            this.Controls.Add(this.Files);
            this.Controls.Add(this.Directories);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.FileBrowser);
            this.Controls.Add(this.Browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button FileBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Directories;
        private System.Windows.Forms.Label Files;
        private System.Windows.Forms.TextBox ActualDirectoriesName;
        private System.Windows.Forms.Label ActualDirectory;
    }
}

