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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileBrowser = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DirectoriesLabel = new System.Windows.Forms.Label();
            this.FilesLabel = new System.Windows.Forms.Label();
            this.ActualDirectoriesName = new System.Windows.Forms.TextBox();
            this.ActualDirectory = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileBrowser
            // 
            this.FileBrowser.Location = new System.Drawing.Point(315, 38);
            this.FileBrowser.Name = "FileBrowser";
            this.FileBrowser.Size = new System.Drawing.Size(92, 27);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 132);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 255);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(370, 132);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(352, 255);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // DirectoriesLabel
            // 
            this.DirectoriesLabel.AutoSize = true;
            this.DirectoriesLabel.Location = new System.Drawing.Point(12, 113);
            this.DirectoriesLabel.Name = "DirectoriesLabel";
            this.DirectoriesLabel.Size = new System.Drawing.Size(57, 13);
            this.DirectoriesLabel.TabIndex = 3;
            this.DirectoriesLabel.Text = "Directories";
            // 
            // FilesLabel
            // 
            this.FilesLabel.AutoSize = true;
            this.FilesLabel.Location = new System.Drawing.Point(411, 113);
            this.FilesLabel.Name = "FilesLabel";
            this.FilesLabel.Size = new System.Drawing.Size(28, 13);
            this.FilesLabel.TabIndex = 4;
            this.FilesLabel.Text = "Files";
            // 
            // ActualDirectoriesName
            // 
            this.ActualDirectoriesName.Location = new System.Drawing.Point(112, 52);
            this.ActualDirectoriesName.Name = "ActualDirectoriesName";
            this.ActualDirectoriesName.Size = new System.Drawing.Size(184, 20);
            this.ActualDirectoriesName.TabIndex = 5;
            this.ActualDirectoriesName.TextChanged += new System.EventHandler(this.ActualDirectoriesName_TextChanged);
            // 
            // ActualDirectory
            // 
            this.ActualDirectory.AutoSize = true;
            this.ActualDirectory.Location = new System.Drawing.Point(12, 52);
            this.ActualDirectory.Name = "ActualDirectory";
            this.ActualDirectory.Size = new System.Drawing.Size(82, 13);
            this.ActualDirectory.TabIndex = 6;
            this.ActualDirectory.Text = "Actual Directory";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(243, 78);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(53, 20);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(523, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(186, 78);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(51, 20);
            this.back.TabIndex = 9;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(727, 396);
            this.Controls.Add(this.back);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ActualDirectory);
            this.Controls.Add(this.ActualDirectoriesName);
            this.Controls.Add(this.FilesLabel);
            this.Controls.Add(this.DirectoriesLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.FileBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button FileBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label DirectoriesLabel;
        private System.Windows.Forms.Label FilesLabel;
        private System.Windows.Forms.TextBox ActualDirectoriesName;
        private System.Windows.Forms.Label ActualDirectory;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button back;
    }
}

