﻿using System;
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
             dup.StatusChanged += dupStatusChanged;
             dup.DuplicateFileFound += DuplicateFileFound;
            //textBox1.DataBindings.Add("Text", dup, "CurrentStatus", false, DataSourceUpdateMode.OnPropertyChanged);

             //objListView.SetObjects(

        }

        private void dupStatusChanged(object sender, EventArgs e)
        {
            txtStatusBar.Text = dup.Status;
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            //C:\Img
            //dup.searchPaths.Add("C:\\Temp\\test");

            DialogResult d = dlgAddFolder.ShowDialog();
            if (d == DialogResult.OK)
            {
                dup.searchPaths.Add(dlgAddFolder.SelectedPath);
            }


            PopulatePaths();
        }

        public void PopulatePaths()
        {
            lstSearchPaths.Clear();
            foreach (string pathName in dup.searchPaths)
            {
                lstSearchPaths.Items.Add(pathName);
            }
        }




        private void PopulateDupList()
        {

            //Clear treeview
            treeView1.Nodes.Clear();

            //Each set of duplicates
            for (int curPos = 0; curPos <= dup.duplicates.Count - 1; curPos++)
            {
                //get curDupe  (0)
                List<SmartFile> curDupe = dup.duplicates.ElementAt(curPos).Value;

                TreeNode newNode = new TreeNode(curDupe[0].fullFileName + "      (" + curDupe[0].tagRank  + ")");
                newNode.Tag = curDupe[0];
                treeView1.Nodes.Add(newNode);

                //add children  (1 to x)
                for (int childNodeIndex = 1; childNodeIndex <= curDupe.Count - 1; childNodeIndex++)
                {

                    TreeNode newChildNode = new TreeNode(curDupe[childNodeIndex].fullFileName + "      (" + curDupe[childNodeIndex].tagRank  + ")");
                    newChildNode.Tag = curDupe[childNodeIndex];

                    newNode.Nodes.Add(newChildNode);

                }

            }

            //Test do stuff
            TreeNode n = new TreeNode();
            n.Tag = dup.duplicates.ElementAt(0).Value[0]; // no way!!


        }

        private void DuplicateFileFound(DupFileEvent d)
        {
            //Check to see if hash exists
            System.Diagnostics.Debug.WriteLine(d.smartFile.fullFileName);
        }




        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            dup.StartSearch();
            this.Text = dup.Status;
            PopulateDupList();
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
            dup.searchPaths.Remove(lstSearchPaths.SelectedItems[0].Text);
            PopulatePaths();
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
    }
}
