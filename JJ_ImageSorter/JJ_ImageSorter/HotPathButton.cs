using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace JJ_ImageSorter
{
    public partial class HotPathButton : UserControl
    {
        private DirectoryInfo _hotPath;
        private string _hotPathString;


        public HotPathButton()
        {
            InitializeComponent();
            HotPathButton_SizeChanged(this,null);
            //USERCONTROL.StatusUpdated += MyEventHandlerFunction_StatusUpdated
        }

        private void HotPathButton_Load(object sender, EventArgs e)
        {
            hotPathString = "c:\\temp";
        }

        private void PathChanged()
        {
            lblHotPath.Text = _hotPathString;
        }



        public DirectoryInfo hotPath
        {
            get
            {
                return _hotPath;
            }
            set
            {
                _hotPath = value;
                _hotPathString = value.ToString();
                PathChanged();
            }
        }

        public string hotPathString
        {
            get
            {
                return _hotPath.ToString();
            }
            set
            {
                _hotPathString = value;
                _hotPath = new DirectoryInfo(value);
                PathChanged();
            }
        }



        private void HotPathButton_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            
        }

        private void HotPathButton_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                FileInfo curFile = new FileInfo(file);
                curFile.CopyTo(hotPathString);
                Debug.WriteLine(hotPathString);
            }

            //more
            
        }

        private void HotPathButton_DoubleClick(object sender, EventArgs e)
        {
            // open menu to change hotpath
            FolderBrowserDialog f = new FolderBrowserDialog();
            DialogResult result = f.ShowDialog();
            Debug.WriteLine(result.ToString());
            if (result != DialogResult.OK)
            {
                return;
            }

            DirectoryInfo di = new DirectoryInfo(f.SelectedPath);
            hotPath = di;

            Debug.WriteLine(f.SelectedPath);
            //hotPathString = f.SelectedPath;

            f.Dispose();

        }


        //EventHandler for Label  (bubble-up events)
        private void HotPathButton_SizeChanged(object sender, EventArgs e)
        {
            lblHotPath.Size = this.Size;
        }
        private void lblHotPath_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);            
        }
        private void lblHotPath_DragDrop(object sender, DragEventArgs e)
        {
            this.OnDragDrop(e);
        }
        private void lblHotPath_DragEnter(object sender, DragEventArgs e)
        {
            this.OnDragEnter(e);
        }


    }
}
