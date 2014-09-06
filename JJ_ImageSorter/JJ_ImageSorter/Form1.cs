using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JJ_ImageSorter;


namespace JJ_ImageSorter
{
    public partial class Form1 : Form
    {
        public DupFinder dup;


        public Form1()
        {
            InitializeComponent();
            dup = new DupFinder();
             //dup.StatusChanged += dupStatusChanged;
             //dup.DuplicateFileFound += DuplicateFileFound;
            //textBox1.DataBindings.Add("Text", dup, "CurrentStatus", false, DataSourceUpdateMode.OnPropertyChanged);

            
            //Events, yay.
            dup.StateChanged += dupStateChanged;
            dup.ProgressChanged += ProgressChanged;
            dup.ScanFinished += dupScanFinished;
            dup.FileDeleted += DupFileDeleted;
        }

        private void dupScanFinished(object sender, EventArgs e)
        {
            //this.Invoke(PopulateDupList);
            if(InvokeRequired)
            {
                EventHandler newE = new EventHandler(dupScanFinished);
                this.Invoke(newE, sender, e);
            }
            else
            {
                PopulateDupList();
            }
            
            
        }

        private void DupFileDeleted(SmartFile sf)
        {
            //find file in list
            
        }

        private void dupStateChanged(DupFinder.SearchState newState)
        {
            if (InvokeRequired)  //Invoke in case thread workers working
            {
                DupFinder.StateHandler st = new DupFinder.StateHandler(dupStateChanged);
                this.Invoke(st, newState);
            }
            else
            {
                lblSearchState.Text = ((DupFinder.SearchState)newState).ToString();
            }
        }

        private void ProgressChanged(double progressPercent, string progressDescription, DupFinder.SearchState state)
        {
            if (InvokeRequired)
            {
                DupFinder.ProgressEventHandler pe = new DupFinder.ProgressEventHandler(ProgressChanged);
                this.Invoke(pe,progressPercent,progressDescription,state);
            }
            else
            {
                txtStatusBar.Text = progressDescription;
                progressBar1.Value = (int)progressPercent;
            }

        }


        private void btnAddPath_Click(object sender, EventArgs e)
        {
            //dup.AddSearchPath("C:\\Temp\\test");
            //PopulatePaths();
            //return;


            DialogResult d = dlgAddFolder.ShowDialog();
            if (d == DialogResult.OK)
            {
                dup.AddSearchPath(dlgAddFolder.SelectedPath);
            }


            PopulatePaths();
        }

        public void PopulatePaths()
        {
            lstSearchPaths.Clear();
            foreach (string pathName in dup.GetSearchPaths())
            {
                lstSearchPaths.Items.Add(pathName);
            }
        }




        private void PopulateDupList()
        {
            Dictionary<ulong, List<SmartFile>> duplicateFiles = dup.DuplicateFiles;  //grab ref

            //Clear treeview
            treeView1.Nodes.Clear();

            //Each set of duplicates
            for (int curPos = 0; curPos <= duplicateFiles.Count - 1; curPos++)
            {
                //get curDupe  (0)
                List<SmartFile> curDupe = duplicateFiles.ElementAt(curPos).Value;

                TreeNode newNode = new TreeNode(curDupe[0].fullFileName + "      (" + curDupe[0].TagRank  + ")");
                newNode.Tag = curDupe[0];
                treeView1.Nodes.Add(newNode);

                //add children  (1 to x)
                for (int childNodeIndex = 1; childNodeIndex <= curDupe.Count - 1; childNodeIndex++)
                {

                    TreeNode newChildNode = new TreeNode(curDupe[childNodeIndex].fullFileName + "      (" + curDupe[childNodeIndex].TagRank  + ")");
                    newChildNode.Tag = curDupe[childNodeIndex];

                    newNode.Nodes.Add(newChildNode);

                }

            }

            //Test do stuff
            TreeNode n = new TreeNode();
            n.Tag = duplicateFiles.ElementAt(0).Value[0]; // no way!!  This actually works.


        }

        private void DuplicateFileFound(DupFileEvent d)
        {
            //Check to see if hash exists
            System.Diagnostics.Debug.WriteLine(d.smartFile.fullFileName);
        }




        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            //dup.StartSearch();
            dup.StartSearch_Async();
            //PopulateDupList();
        }



        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Button.ToString());
            if (e.Button == MouseButtons.Right)
            {
                context_ExpandItems.Show(treeView1,e.Location);
            }
        }
        private void context_ExpandItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //
            if (e.ClickedItem.Text == "Expand All Items")
            {
                foreach (TreeNode n in treeView1.Nodes)
                {
                    n.Expand();
                }
            }
            if (e.ClickedItem.Text == "UnExpand All Items")
            {
                foreach (TreeNode n in treeView1.Nodes)
                {
                    n.Collapse();
                }
            }


        }

        private void btnDeletePath_Click(object sender, EventArgs e)
        {
            if (lstSearchPaths.SelectedItems.Count > 0)
            {
                dup.DelSearchPath(lstSearchPaths.SelectedItems[0].Text);
                PopulatePaths();
            }
        }

        private void cmdDeleteCheckedFiles_Click(object sender, EventArgs e)
        {
            //
            //Get a list of all checked files
            List<SmartFile> sf = new List<SmartFile>();
            for (int x = 0; x < treeView1.Nodes.Count; x++)
            {
                if (treeView1.Nodes[x].Checked == true)
                {
                    SmartFile tmpFile = (SmartFile)treeView1.Nodes[x].Tag;
                    sf.Add(tmpFile);
                    //sf.Add(dup.duplicates.ElementAt(x)

                    //sf.Add((SmartFile)treeView1.Nodes[x].Nodes[0]);
                }
                //Check children
                foreach (TreeNode n in treeView1.Nodes[x].Nodes)
                {
                    if (n.Checked)
                    {
                        SmartFile tmpSubFile = (SmartFile)n.Tag;
                        sf.Add(tmpSubFile);
                    }
                }
            }

            Popup_DeleteFiles p = new Popup_DeleteFiles(sf);

            //I can haz centerpointed?
            p.Owner = this;
            p.StartPosition = FormStartPosition.CenterParent;


            p.ShowDialog();
            //p.ShowDialogPrompt();


        }

        private void context_ExpandItems_Opening(object sender, CancelEventArgs e)
        {

        }


        //  Cut+Paste
        private void toolStripCutAllInFolder_Click(object sender, EventArgs e)
        {
            //
            DataObject data = new DataObject();
            SmartFile selectedFile = (SmartFile) treeView1.SelectedNode.Tag;

            string[] files = System.IO.Directory.GetFiles(selectedFile.FullFolderName);

            data.SetData("FileDrop", files);
            data.SetData("Preferred DropEffect", DragDropEffects.Move);

            Clipboard.Clear();
            Clipboard.SetDataObject(data,true);


        }

        private void toolStripPasteItems_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetData("FileDrop") == null) { return;}
            //
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                SmartFile file = (SmartFile) selectedNode.Tag;
                string fullPath = file.FullFolderName;
                
                string[] files = (string[]) Clipboard.GetData("FileDrop");
                
                foreach (string curFile in files)
                {
                    SmartFile s = new SmartFile(curFile);
                    if (s.isValidFile)
                    {
                        s.Move(fullPath);
                    }
                    //System.IO.Directory.Move(curFile,fullPath
                }

                PopulateDupList();
            }

        }


        //Autocheck based on ranking
        private void btnAutoCheck_Click(object sender, EventArgs e)
        {
            //only check files with different rankings
            foreach (TreeNode curNode in treeView1.Nodes)
            {
                TreeNode keeperNode = curNode;

                
                //get children nodes as well


                //Check all that aren't keepers

            }
        }


        private void toolStripExpandAllItems_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void toolStripUnExpandAllItems_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        



    }



    public static class ControlExtentions
    {
        public delegate void InvokeHandler();

        public static void SafeInvoke(this Control control, InvokeHandler handler)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(handler);
            }
            else
            {
                handler();
            }

        }


    }



}
