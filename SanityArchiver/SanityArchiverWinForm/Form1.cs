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
        static string directoryName = @"C:\Users\Judit";
        static string fileName;
        DirectoryInfo directory;
        DirectoryInfo[] directories;
        FileInfo[] files;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void FileBrowser_Click(object sender, EventArgs e)
        {
            directory = new DirectoryInfo(directoryName);
            directories = directory.GetDirectories();
            files = directory.GetFiles();

            tableLayoutPanel1.AutoSize = (directories.Length > 16) ? false : true;
            tableLayoutPanel1.AutoScroll = (directories.Length > 16) ? true: false;

            tableLayoutPanel2.AutoSize = (files.Length > 16) ? false : true;
            tableLayoutPanel2.AutoScroll = (files.Length > 16) ? true : false;
            CreateMapButtons(directories.Length, directories, files.Length, files);

            ActualDirectoriesName.Text = directoryName;
        }

        public void CreateMapButtons(int DirectoryNumber, DirectoryInfo[] directories, int FileNumber, FileInfo[] files)
        {
            int rowCount;
            int rowCountForFiles;
            int columnCount = 4;
            

            rowCount = (DirectoryNumber % columnCount == 0) ? DirectoryNumber % columnCount : (DirectoryNumber % columnCount) + 1;
            rowCountForFiles = (FileNumber % columnCount == 0) ? FileNumber % columnCount : (FileNumber % columnCount) + 1;

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

            directoryName = (sender as Button).Text;
            directory = new DirectoryInfo(directoryName);
            directories = directory.GetDirectories();
            files = directory.GetFiles();

            tableLayoutPanel1.AutoSize = (directories.Length > 16) ? false : true;
            tableLayoutPanel1.AutoScroll = (directories.Length > 16) ? true : false;

            tableLayoutPanel2.AutoSize = (files.Length > 16) ? false : true;
            tableLayoutPanel2.AutoScroll = (files.Length > 16) ? true : false;
            CreateMapButtons(directories.Length, directories, files.Length, files);

            ActualDirectoriesName.Text = directoryName;
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

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void ActualDirectoriesName_TextChanged(object sender, EventArgs e)
        {
            directoryName = (sender as TextBox).Text;
            directory = new DirectoryInfo(directoryName);
            directories = directory.GetDirectories();
            files = directory.GetFiles();

            tableLayoutPanel1.AutoSize = (directories.Length > 16) ? false : true;
            tableLayoutPanel1.AutoScroll = (directories.Length > 16) ? true : false;

            tableLayoutPanel2.AutoSize = (files.Length > 16) ? false : true;
            tableLayoutPanel2.AutoScroll = (files.Length > 16) ? true : false;
            CreateMapButtons(directories.Length, directories, files.Length, files);
        }
    }
}
