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


        public Popup_DeleteFiles(SmartFile[] files)
        {
            InitializeComponent();
        }

        public Popup_DeleteFiles(string[] files)
        {
            InitializeComponent();
        }
        public Popup_DeleteFiles()
        {
            InitializeComponent();
        }


        private void ShowDialogPrompt()
        {
            
            
            
            DialogResult dr = MessageBox.Show("Please confirm that you DAMN SURE you want to delete all this", "Confirm Delete", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
            }
            if (dr == DialogResult.Cancel)
            {
                this.Dispose();
            }

        }

        private void Popup_DeleteFiles_Load(object sender, EventArgs e)
        {
            //display dialog
            ShowDialogPrompt();
        }
    }
}
