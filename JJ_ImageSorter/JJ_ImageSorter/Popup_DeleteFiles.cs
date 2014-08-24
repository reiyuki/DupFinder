using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJ_ImageSorter
{
    public partial class Popup_DeleteFiles : Form
    {
        SmartFile[] filesToDelete;


        private bool _isDeleting;
        public bool isDeleting
        {
            get
            {
                return _isDeleting;
            }
            private set
            {
                _isDeleting = value;
                if (value == true)
                {
                    this.Text = "DELETING...";
                    btnOK.Text = "Cancel";
                }
                else
                {
                    this.Text = "FINISHED";
                    btnOK.Text = "OK";
                }
            }
        }


        public Popup_DeleteFiles(SmartFile[] files)
        {
            InitializeComponent();
        }

        public Popup_DeleteFiles(string[] files)
        {
            InitializeComponent();
        }
        //public Popup_DeleteFiles()
        //{
        //    InitializeComponent();
        //}


        private void ShowDialogPrompt()
        {
            
            
            
            DialogResult dr = MessageBox.Show("Please confirm that you DAMN SURE you want to delete all this", "Confirm Delete", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                DeleteFiles();
            }
            if (dr == DialogResult.Cancel)
            {
                this.Dispose();
            }

        }

        private void DeleteFiles()
        {
            isDeleting = true;
            int filesDeleted = 0;
            int totalFilesToDelete = filesToDelete.Length;

            for (int x = 0; x < filesToDelete.Length; x++)
            {
                System.Diagnostics.Debug.WriteLine("DELETEING:" + filesToDelete[x].fullFileName);
                //Application.DoEvents();
                UpdateDeleteProgress(filesDeleted, totalFilesToDelete);
                //System.Threading.Thread.Sleep(1000);
            }

            isDeleting = false;
            this.Text = "Delete Complete";
            //Deleted x of y files
        }

        private void UpdateDeleteProgress(int curFile, int totalFiles)
        {
            lblDeleteStatus.Text = "Deleted " + curFile.ToString() + " of " + totalFiles.ToString() + " files.";
            progressBarDeleteStatus.Maximum = totalFiles;
            progressBarDeleteStatus.Value = curFile;              
        }

        private void Popup_DeleteFiles_Load(object sender, EventArgs e)
        {
            //display dialog
            ShowDialogPrompt();
        }
    }
}
