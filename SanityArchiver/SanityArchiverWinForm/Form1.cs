using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;


namespace SanityArchiverWinForm
{
    public partial class Form1 : Form
    {
        static string defaultDirectoryPath = @"C:\Users\Judit";
        static string directoryPath = @"C:\Users\Judit";
        DirectoryInfo directory;
        DirectoryInfo[] directories;
        FileInfo[] files;

        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = false;
            DirectoriesLabel.Visible = false;
            FilesLabel.Visible = false;
            pictureBox1.Visible = false;
        }

        private void FileBrowserButton_Click(object sender, EventArgs e)
        {
            directory = new DirectoryInfo(directoryPath);

            UpdateDirectoryInfos();

            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Visible = true;
            DirectoriesLabel.Visible = true;
            FilesLabel.Visible = true;

            pictureBox1.Visible = (directories.Length > 0 && files.Length > 0) ? true : false;
        }

        public void CreateTable(int DirectoryNumber, DirectoryInfo[] directories, int FileNumber, FileInfo[] files)
        {
            int rowCount;
            int rowCountForFiles;
            int columnCount = 3;

            rowCount = (DirectoryNumber % columnCount == 0) ? DirectoryNumber / columnCount : (DirectoryNumber / columnCount) + 1;
            rowCountForFiles = (FileNumber % columnCount == 0) ? FileNumber / columnCount : (FileNumber / columnCount) + 1;

            if (rowCount == 0)
            {
                rowCount++;
            }
            else if (rowCountForFiles == 0)
            {
                rowCountForFiles++;
            }

            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;

            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
                this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
            }
            for (int i = 0; i < rowCount; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }
            for (int i = 0; i < rowCountForFiles; i++)
            {
                this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }

            CreateDirectoryButtons();

            CreateFileButtons();

        }

        public void CreateDirectoryButtons()
        {
            foreach (DirectoryInfo directory in directories)
            {
                var dir = new Button();
                dir.Text = (directory.Name).ToString();
                dir.Name = string.Format("dir_{0}", (directory.Name).ToString());
                dir.Click += dir_Click;
                dir.ContextMenuStrip = new ContextMenuStrip();

                CreateContextMenuStripForButtonDir(dir, directory);

                dir.Dock = DockStyle.Fill;
                this.tableLayoutPanel1.Controls.Add(dir);
            }
        }

        void dir_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
                MessageBox.Show(string.Format("{0} Clicked", b.Text));

            string directoryName = (sender as Button).Text;

            //directoryPath = Array.Find(directories, s => s.Name.Equals(directoryName));
            foreach (DirectoryInfo dir in directories)
            {
                if (dir.Name.Equals(directoryName))
                {
                    directory = dir;
                }
            }
            UpdateDirectoryInfos();

            CheckZeroDirectoriesAndFiles();

            pictureBox1.Visible = (directories.Length > 0 && files.Length > 0) ? true : false;
        }

        public void CreateFileButtons()
        {
            foreach (FileInfo file in files)
            {
                var fil = new Button();
                fil.Text = (file.Name).ToString();
                fil.Name = string.Format("fil_{0}", (file.FullName).ToString());

                CreateContextMenuStripForButton(fil, file);

                fil.Click += fil_Click;
                fil.Dock = DockStyle.Fill;
                this.tableLayoutPanel2.Controls.Add(fil);
            }
        }

        void fil_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
                MessageBox.Show(string.Format("{0} Clicked", b.Text));

            b.ContextMenuStrip.Visible = true;
        }

        public void CreateContextMenuStripForButton(Button button, FileInfo fileinfo)
        {
            button.ContextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem attributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem encryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            renameToolStripMenuItem.Text = "Rename";
            attributesToolStripMenuItem.Text = "Attributes";
            encryptToolStripMenuItem.Text = "Encrypt";
            compressToolStripMenuItem.Text = "Compress";
            moveToolStripMenuItem.Text = "Move";
            renameToolStripMenuItem.Name = string.Format("tool_{0}", (fileinfo.FullName).ToString());
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            attributesToolStripMenuItem.Name = string.Format("attr_{0}", (fileinfo.FullName).ToString());
            attributesToolStripMenuItem.Click += attributesToolStripMenuItem_Click;
            encryptToolStripMenuItem.Name = string.Format("encr_{0}", (fileinfo.FullName).ToString());
            encryptToolStripMenuItem.Click += encryptToolStripMenuItem_Click;
            compressToolStripMenuItem.Name = string.Format("comp_{0}", (fileinfo.FullName).ToString());
            compressToolStripMenuItem.Click += compressToolStripMenuItem_Click;
            moveToolStripMenuItem.Name = string.Format("move_{0}", (fileinfo.FullName).ToString());
            moveToolStripMenuItem.Click += moveToolStripMenuItem_Click;

            button.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                    {
                                                        renameToolStripMenuItem,
                                                        attributesToolStripMenuItem,
                                                        encryptToolStripMenuItem,
                                                        compressToolStripMenuItem,
                                                        moveToolStripMenuItem
                    });
            button.ContextMenuStrip.Name = string.Format("contextMenuStrip_{0}", (fileinfo.Name).ToString());
            button.ContextMenuStrip.Size = new System.Drawing.Size(153, 136);
            
        }

        public void CreateContextMenuStripForButtonDir(Button button, DirectoryInfo directoryinfo)
        {
            button.ContextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem attributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem encryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            renameToolStripMenuItem.Text = "Rename";
            attributesToolStripMenuItem.Text = "Attributes";
            encryptToolStripMenuItem.Text = "Encrypt";
            compressToolStripMenuItem.Text = "Compress";
            moveToolStripMenuItem.Text = "Move";
            renameToolStripMenuItem.Name = string.Format("tool_{0}", (directoryinfo.FullName).ToString());
            renameToolStripMenuItem.Click += renameToolStripMenuItem_ClickDir;
            attributesToolStripMenuItem.Name = string.Format("attr_{0}", (directoryinfo.FullName).ToString());
            attributesToolStripMenuItem.Click += attributesToolStripMenuItem_ClickDir;
            encryptToolStripMenuItem.Name = string.Format("encr_{0}", (directoryinfo.FullName).ToString());
            encryptToolStripMenuItem.Click += encryptToolStripMenuItem_ClickDir;
            compressToolStripMenuItem.Name = string.Format("comp_{0}", (directoryinfo.FullName).ToString());
            compressToolStripMenuItem.Click += compressToolStripMenuItem_ClickDir;
            moveToolStripMenuItem.Name = string.Format("move_{0}", (directoryinfo.FullName).ToString());
            moveToolStripMenuItem.Click += moveToolStripMenuItem_ClickDir;

            button.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                    {
                                                        renameToolStripMenuItem,
                                                        attributesToolStripMenuItem,
                                                        encryptToolStripMenuItem,
                                                        compressToolStripMenuItem,
                                                        moveToolStripMenuItem
                    });
            button.ContextMenuStrip.Name = string.Format("contextMenuStrip_{0}", (directoryinfo.Name).ToString());
            button.ContextMenuStrip.Size = new System.Drawing.Size(153, 136);

        }

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo fil in currentDirectory.GetFiles())
            {
                if (fil.Name == fileName)
                    foundFiles.Add(fil);
            }
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, dir);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ActualDirectoriesName.Text.Length > 0)
            {
                directoryPath = ActualDirectoriesName.Text;
                directory = new DirectoryInfo(directoryPath);

                UpdateDirectoryInfos();
            }
            CheckZeroDirectoriesAndFiles();

            pictureBox1.Visible = (directories.Length > 0 && files.Length > 0) ? true : false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if ( ActualDirectoriesName.Text.Length > 0)
            {
                directory = directory.Parent;
                UpdateDirectoryInfos();
            }

            pictureBox1.Visible = (directories.Length > 0 && files.Length > 0) ? true : false;
        }

        public void UpdateDirectoryInfos()
        {
            tableLayoutPanel1.BackgroundImage = null;
            tableLayoutPanel2.BackgroundImage = null;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel2.Controls.Clear();

            try
            {
                directories = directory.GetDirectories();
            }
            catch
            {
                MessageBox.Show(string.Format("Can't access this folder"));

                directory = new DirectoryInfo(defaultDirectoryPath);
            }

            files = directory.GetFiles();

            tableLayoutPanel1.AutoSize = (directories.Length > 9) ? false : true;
            tableLayoutPanel1.AutoScroll = (directories.Length > 9) ? true : false;

            tableLayoutPanel2.AutoSize = (files.Length > 9) ? false : true;
            tableLayoutPanel2.AutoScroll = (files.Length > 9) ? true : false;
            CreateTable(directories.Length, directories, files.Length, files);

            directoryPath = directory.FullName;
            ActualDirectoriesName.Text = directoryPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void CheckZeroDirectoriesAndFiles()
        {
            if (tableLayoutPanel1.Controls.Count == 0 && tableLayoutPanel2.Controls.Count == 0)
            {
                Image myimage = new Bitmap(@"C:\Users\Judit\Pictures\cat_PNG104.png");
                Image myimage3 = new Bitmap(@"C:\Users\Judit\Pictures\surprised_cat.png");
                tableLayoutPanel1.BackgroundImage = myimage;
                tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
                tableLayoutPanel2.BackgroundImage = myimage3;
                tableLayoutPanel2.BackgroundImageLayout = ImageLayout.Stretch;
                MessageBox.Show("There are no directories and files here.");
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = sender as ToolStripMenuItem;
            string name = toolStripMenuItem.Name.Substring(5);
            FileInfo fileinfo = new FileInfo(name);
            CreateDialogForm(fileinfo);
        }

        private void renameToolStripMenuItem_ClickDir(object sender, EventArgs e)
        {
            var toolStripMenuItem = sender as ToolStripMenuItem;
            string name = toolStripMenuItem.Name.Substring(5);
            DirectoryInfo directoryinfo = new DirectoryInfo(name);
            CreateDialogFormDir(directoryinfo);
        }

        private void attributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = sender as ToolStripMenuItem;
            string name = toolStripMenuItem.Name.Substring(5);
            FileInfo actualFile = new FileInfo(name);

            MessageBox.Show("Creation Time: " + Environment.NewLine
                + actualFile.CreationTime.ToString() + Environment.NewLine
                + "Last Access Time: " + Environment.NewLine
                + actualFile.LastAccessTime + Environment.NewLine
                + "isReadOnly: " + Environment.NewLine
                + actualFile.IsReadOnly);
        }

        private void attributesToolStripMenuItem_ClickDir(object sender, EventArgs e)
        {
            var toolStripMenuItem = sender as ToolStripMenuItem;
            string name = toolStripMenuItem.Name.Substring(5);
            DirectoryInfo directory = new DirectoryInfo(name);

            MessageBox.Show("Creation Time: " + Environment.NewLine
                + directory.CreationTime.ToString() + Environment.NewLine
                + "Last Acces Time: " + Environment.NewLine
                + directory.LastAccessTime + Environment.NewLine);
        }

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void encryptToolStripMenuItem_ClickDir(object sender, EventArgs e)
        {

        }

        private void compressToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compressToolStripMenuItem_ClickDir(object sender, EventArgs e)
        {

        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moveToolStripMenuItem_ClickDir(object sender, EventArgs e)
        {

        }

        public void CreateDialogForm(FileInfo file)
        {
            // Create a new instance of the form.
            Form DialogForm = new Form();
            // Create two buttons to use as the accept and cancel buttons.
            Button RenameButton = new Button();
            Button CancelButton = new Button();

            Label OldFileNameLabel = new Label();
            OldFileNameLabel.Text = "Old File Name";
            OldFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            OldFileNameLabel.Location = new Point(10, 10);
            Label OldFileNameText = new Label();
            OldFileNameText.Text = file.Name;
            OldFileNameText.Location = new Point(10, 40);
            Label NewFileNameLabel = new Label();
            NewFileNameLabel.Text = "New File Name";
            NewFileNameLabel.Location = new Point(10, 70);
            NewFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            TextBox NewFileNameTextBox = new TextBox();
            NewFileNameTextBox.Location = new Point(10, 100);

            // Set the text of RenameButton.
            RenameButton.Text = "Rename";
            // Set the position of the button on the form.
            RenameButton.Location = new Point(10, 140);
            // Set the text of CancelButton to "Cancel".
            CancelButton.Text = "Cancel";
            // Set the position of the button based on the location of button1.
            CancelButton.Location
               = new Point(RenameButton.Left, RenameButton.Height + RenameButton.Top + 10);
            // Make RenameButton's dialog result OK.
            RenameButton.DialogResult = DialogResult.OK;
            // Make button2's dialog result Cancel.
            CancelButton.DialogResult = DialogResult.Cancel;
            // Set the caption bar text of the form.   
            DialogForm.Text = "Rename Dialog Box";

            // Define the border style of the form to a dialog box.
            DialogForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the accept button of the form to RenameButton.
            DialogForm.AcceptButton = RenameButton;
            // Set the cancel button of the form to CancelButton.
            DialogForm.CancelButton = CancelButton;
            // Set the start position of the form to the center of the screen.
            DialogForm.StartPosition = FormStartPosition.CenterScreen;

            // Add RenameButton to the form.
            DialogForm.Controls.Add(RenameButton);
            // Add CancelButton to the form.
            DialogForm.Controls.Add(CancelButton);
            DialogForm.Controls.Add(OldFileNameLabel);
            DialogForm.Controls.Add(OldFileNameText);
            DialogForm.Controls.Add(NewFileNameLabel);
            DialogForm.Controls.Add(NewFileNameTextBox);

            // Display the form as a modal dialog box.
            DialogForm.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.
            if (DialogForm.DialogResult == DialogResult.OK)
            {
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(file.FullName, NewFileNameTextBox.Text);
                UpdateDirectoryInfos();
                // Display a message box indicating that the OK button was clicked.
                MessageBox.Show("The OK button on the form was clicked.");
                // Optional: Call the Dispose method when you are finished with the dialog box.
                DialogForm.Dispose();
            }
            else
            {
                // Display a message box indicating that the Cancel button was clicked.
                MessageBox.Show("The Cancel button on the form was clicked.");
                // Optional: Call the Dispose method when you are finished with the dialog box.
                DialogForm.Dispose();
            }
        }

        public void CreateDialogFormDir(DirectoryInfo directoryinfo)
        {
            // Create a new instance of the form.
            Form DialogForm = new Form();
            // Create two buttons to use as the accept and cancel buttons.
            Button RenameButton = new Button();
            Button CancelButton = new Button();

            Label OldFileNameLabel = new Label();
            OldFileNameLabel.Text = "Old Directory Name";
            OldFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            OldFileNameLabel.Location = new Point(10, 10);
            Label OldFileNameText = new Label();
            OldFileNameText.Text = directoryinfo.Name;
            OldFileNameText.Location = new Point(10, 40);
            Label NewFileNameLabel = new Label();
            NewFileNameLabel.Text = "New Directory Name";
            NewFileNameLabel.Location = new Point(10, 70);
            NewFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            TextBox NewFileNameTextBox = new TextBox();
            NewFileNameTextBox.Location = new Point(10, 100);

            // Set the text of RenameButton.
            RenameButton.Text = "Rename";
            // Set the position of the button on the form.
            RenameButton.Location = new Point(10, 140);
            // Set the text of CancelButton to "Cancel".
            CancelButton.Text = "Cancel";
            // Set the position of the button based on the location of button1.
            CancelButton.Location
               = new Point(RenameButton.Left, RenameButton.Height + RenameButton.Top + 10);
            // Make RenameButton's dialog result OK.
            RenameButton.DialogResult = DialogResult.OK;
            // Make button2's dialog result Cancel.
            CancelButton.DialogResult = DialogResult.Cancel;
            // Set the caption bar text of the form.   
            DialogForm.Text = "Rename Dialog Box";

            // Define the border style of the form to a dialog box.
            DialogForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the accept button of the form to RenameButton.
            DialogForm.AcceptButton = RenameButton;
            // Set the cancel button of the form to CancelButton.
            DialogForm.CancelButton = CancelButton;
            // Set the start position of the form to the center of the screen.
            DialogForm.StartPosition = FormStartPosition.CenterScreen;

            // Add RenameButton to the form.
            DialogForm.Controls.Add(RenameButton);
            // Add CancelButton to the form.
            DialogForm.Controls.Add(CancelButton);
            DialogForm.Controls.Add(OldFileNameLabel);
            DialogForm.Controls.Add(OldFileNameText);
            DialogForm.Controls.Add(NewFileNameLabel);
            DialogForm.Controls.Add(NewFileNameTextBox);

            // Display the form as a modal dialog box.
            DialogForm.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.
            if (DialogForm.DialogResult == DialogResult.OK)
            {
                Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(directoryinfo.FullName, NewFileNameTextBox.Text);
                UpdateDirectoryInfos();
                // Display a message box indicating that the OK button was clicked.
                MessageBox.Show("The OK button on the form was clicked.");
                // Optional: Call the Dispose method when you are finished with the dialog box.
                DialogForm.Dispose();
            }
            else
            {
                // Display a message box indicating that the Cancel button was clicked.
                MessageBox.Show("The Cancel button on the form was clicked.");
                // Optional: Call the Dispose method when you are finished with the dialog box.
                DialogForm.Dispose();
            }
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
