using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJ_ImageSorter
{
    public partial class oldPopup_DeleteFiles : UserControl
    {
        SmartFile[] filesToDelete;

        //Dialogbox to confirm:

        public oldPopup_DeleteFiles(SmartFile[] files)
        {
            InitializeComponent();
        }

        public oldPopup_DeleteFiles(string[] files)
        {
            InitializeComponent();
        }
        public oldPopup_DeleteFiles()
        {
            InitializeComponent();
        }



        private void Popup_DeleteFiles_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialogPrompt()
        {

            DialogResult dr = MessageBox.Show("Please confirm that you DAMN SURE you want to delete all this", "Confirm Delete", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.BringToFront();
            }
            if (dr == DialogResult.Cancel)
            {
                this.Dispose();
            }

        }

    }
}
