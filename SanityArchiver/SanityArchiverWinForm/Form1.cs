using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiverWinForm
{
    public partial class Form1 : Form
    {
        static List<FileInfo> FoundFiles;
        static string defaultDirectoryPath = @"C:\Users\Judit";
        static string directoryPath = @"C:\Users\Judit";
        static string fileName;
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

        private void FileBrowser_Click(object sender, EventArgs e)
        {
            directory = new DirectoryInfo(directoryPath);

            UpdateDirectoryInfos();

            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Visible = true;
            DirectoriesLabel.Visible = true;
            FilesLabel.Visible = true;
            pictureBox1.Visible = true;
        }

        public void CreateMapButtons(int DirectoryNumber, DirectoryInfo[] directories, int FileNumber, FileInfo[] files)
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

            foreach (DirectoryInfo directory in directories)
            {
                var dir = new Button();
                dir.Text = (directory.Name).ToString();
                dir.Name = string.Format("dir_{0}", (directory.Name).ToString());
                dir.Click += dir_Click;
                dir.Dock = DockStyle.Fill;
                this.tableLayoutPanel1.Controls.Add(dir);
            }

            foreach (FileInfo file in files)
            {
                var fil = new Button();
                fil.Text = (file.Name).ToString();
                fil.Name = string.Format("fil_{0}", (file.Name).ToString());
                fil.Click += fil_Click;
                fil.Dock = DockStyle.Fill;
                this.tableLayoutPanel2.Controls.Add(fil);
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
        }



        void fil_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
                MessageBox.Show(string.Format("{0} Clicked", b.Text));
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

        private void ActualDirectoriesName_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.Controls.Count > 0 || tableLayoutPanel2.Controls.Count > 0)
            {
                directoryPath = ActualDirectoriesName.Text;
                directory = new DirectoryInfo(directoryPath);

                UpdateDirectoryInfos();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.Controls.Count > 0 || tableLayoutPanel2.Controls.Count > 0)
            {
                directory = directory.Parent;
                UpdateDirectoryInfos();
            }
        }

        public void UpdateDirectoryInfos()
        {
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
            CreateMapButtons(directories.Length, directories, files.Length, files);

            directoryPath = directory.FullName;
            ActualDirectoriesName.Text = directoryPath;
        }
    }
}
