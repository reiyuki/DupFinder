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
    public partial class Form1 : Form
    {
        public Dupfinder dup;

        public Form1()
        {
            InitializeComponent();
            dup = new Dupfinder();
        }

        private void hotPathButton1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void hotPathButton1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            //C:\Img
            //dup.searchPaths.Add("C:\\Temp\\test");
            dup.searchPaths.Add("C:\\inc\\0814");

            dup.StartSearch();
        }
    }
}
