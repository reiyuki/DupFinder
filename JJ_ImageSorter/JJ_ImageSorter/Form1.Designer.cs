namespace JJ_ImageSorter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.btnAddPath = new System.Windows.Forms.Button();
            this.lstSearchPaths = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtStatusBar = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnDeletePath = new System.Windows.Forms.Button();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.context_ExpandItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripExpandMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExpandAllItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnExpandAllItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTagFileWildcard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddFolderTagWildcard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCutAllInFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPasteItems = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDeleteCheckedFiles = new System.Windows.Forms.Button();
            this.dlgAddFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSearchState = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnAutoCheck = new System.Windows.Forms.Button();
            this.context_ExpandItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPath
            // 
            this.btnAddPath.Location = new System.Drawing.Point(12, 4);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(70, 25);
            this.btnAddPath.TabIndex = 1;
            this.btnAddPath.Text = "Add Path";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // lstSearchPaths
            // 
            this.lstSearchPaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSearchPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstSearchPaths.FullRowSelect = true;
            this.lstSearchPaths.GridLines = true;
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.lstSearchPaths.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.lstSearchPaths.Location = new System.Drawing.Point(12, 35);
            this.lstSearchPaths.MultiSelect = false;
            this.lstSearchPaths.Name = "lstSearchPaths";
            this.lstSearchPaths.Size = new System.Drawing.Size(446, 57);
            this.lstSearchPaths.TabIndex = 2;
            this.lstSearchPaths.UseCompatibleStateImageBehavior = false;
            this.lstSearchPaths.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 6000;
            // 
            // txtStatusBar
            // 
            this.txtStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusBar.Location = new System.Drawing.Point(12, 308);
            this.txtStatusBar.Name = "txtStatusBar";
            this.txtStatusBar.ReadOnly = true;
            this.txtStatusBar.Size = new System.Drawing.Size(446, 20);
            this.txtStatusBar.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 128);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(446, 174);
            this.treeView1.TabIndex = 4;
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // btnDeletePath
            // 
            this.btnDeletePath.Location = new System.Drawing.Point(88, 4);
            this.btnDeletePath.Name = "btnDeletePath";
            this.btnDeletePath.Size = new System.Drawing.Size(77, 25);
            this.btnDeletePath.TabIndex = 5;
            this.btnDeletePath.Text = "Delete Path";
            this.btnDeletePath.UseVisualStyleBackColor = true;
            this.btnDeletePath.Click += new System.EventHandler(this.btnDeletePath_Click);
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(182, 4);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(95, 25);
            this.btnStartSearch.TabIndex = 6;
            this.btnStartSearch.Text = "Start Search";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // context_ExpandItems
            // 
            this.context_ExpandItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExpandMenu,
            this.toolStripSeparator1,
            this.toolStripTagFileWildcard,
            this.toolStripAddFolderTagWildcard,
            this.toolStripSeparator2,
            this.toolStripCutAllInFolder,
            this.toolStripPasteItems});
            this.context_ExpandItems.Name = "context_ExpandItems";
            this.context_ExpandItems.Size = new System.Drawing.Size(206, 126);
            this.context_ExpandItems.Opening += new System.ComponentModel.CancelEventHandler(this.context_ExpandItems_Opening);
            this.context_ExpandItems.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.context_ExpandItems_ItemClicked);
            // 
            // toolStripExpandMenu
            // 
            this.toolStripExpandMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExpandAllItems,
            this.toolStripUnExpandAllItems});
            this.toolStripExpandMenu.Name = "toolStripExpandMenu";
            this.toolStripExpandMenu.Size = new System.Drawing.Size(205, 22);
            this.toolStripExpandMenu.Text = "(Un)Expand Items";
            // 
            // toolStripExpandAllItems
            // 
            this.toolStripExpandAllItems.Name = "toolStripExpandAllItems";
            this.toolStripExpandAllItems.Size = new System.Drawing.Size(176, 22);
            this.toolStripExpandAllItems.Text = "Expand All Items";
            this.toolStripExpandAllItems.Click += new System.EventHandler(this.toolStripExpandAllItems_Click);
            // 
            // toolStripUnExpandAllItems
            // 
            this.toolStripUnExpandAllItems.Name = "toolStripUnExpandAllItems";
            this.toolStripUnExpandAllItems.Size = new System.Drawing.Size(176, 22);
            this.toolStripUnExpandAllItems.Text = "UnExpand All Items";
            this.toolStripUnExpandAllItems.Click += new System.EventHandler(this.toolStripUnExpandAllItems_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripTagFileWildcard
            // 
            this.toolStripTagFileWildcard.Name = "toolStripTagFileWildcard";
            this.toolStripTagFileWildcard.Size = new System.Drawing.Size(205, 22);
            this.toolStripTagFileWildcard.Text = "Add File Tag Wildcard";
            // 
            // toolStripAddFolderTagWildcard
            // 
            this.toolStripAddFolderTagWildcard.Name = "toolStripAddFolderTagWildcard";
            this.toolStripAddFolderTagWildcard.Size = new System.Drawing.Size(205, 22);
            this.toolStripAddFolderTagWildcard.Text = "Add Folder Tag Wildcard";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripCutAllInFolder
            // 
            this.toolStripCutAllInFolder.Name = "toolStripCutAllInFolder";
            this.toolStripCutAllInFolder.Size = new System.Drawing.Size(205, 22);
            this.toolStripCutAllInFolder.Text = "Cut all items in folder";
            this.toolStripCutAllInFolder.Click += new System.EventHandler(this.toolStripCutAllInFolder_Click);
            // 
            // toolStripPasteItems
            // 
            this.toolStripPasteItems.Name = "toolStripPasteItems";
            this.toolStripPasteItems.Size = new System.Drawing.Size(205, 22);
            this.toolStripPasteItems.Text = "Paste to folder";
            this.toolStripPasteItems.Click += new System.EventHandler(this.toolStripPasteItems_Click);
            // 
            // cmdDeleteCheckedFiles
            // 
            this.cmdDeleteCheckedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeleteCheckedFiles.Location = new System.Drawing.Point(332, 98);
            this.cmdDeleteCheckedFiles.Name = "cmdDeleteCheckedFiles";
            this.cmdDeleteCheckedFiles.Size = new System.Drawing.Size(126, 24);
            this.cmdDeleteCheckedFiles.TabIndex = 7;
            this.cmdDeleteCheckedFiles.Text = "Delete Checked Files";
            this.cmdDeleteCheckedFiles.UseVisualStyleBackColor = true;
            this.cmdDeleteCheckedFiles.Click += new System.EventHandler(this.cmdDeleteCheckedFiles_Click);
            // 
            // lblSearchState
            // 
            this.lblSearchState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchState.AutoSize = true;
            this.lblSearchState.Location = new System.Drawing.Point(195, 292);
            this.lblSearchState.Name = "lblSearchState";
            this.lblSearchState.Size = new System.Drawing.Size(62, 13);
            this.lblSearchState.TabIndex = 8;
            this.lblSearchState.Text = "searchstate";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 334);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(446, 24);
            this.progressBar1.TabIndex = 9;
            // 
            // btnAutoCheck
            // 
            this.btnAutoCheck.Location = new System.Drawing.Point(213, 98);
            this.btnAutoCheck.Name = "btnAutoCheck";
            this.btnAutoCheck.Size = new System.Drawing.Size(95, 24);
            this.btnAutoCheck.TabIndex = 10;
            this.btnAutoCheck.Text = "AutoCheck Files";
            this.btnAutoCheck.UseVisualStyleBackColor = true;
            this.btnAutoCheck.Click += new System.EventHandler(this.btnAutoCheck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 375);
            this.Controls.Add(this.btnAutoCheck);
            this.Controls.Add(this.lblSearchState);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdDeleteCheckedFiles);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.btnDeletePath);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.txtStatusBar);
            this.Controls.Add(this.lstSearchPaths);
            this.Controls.Add(this.btnAddPath);
            this.MinimumSize = new System.Drawing.Size(440, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.context_ExpandItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.ListView lstSearchPaths;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtStatusBar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnDeletePath;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.ContextMenuStrip context_ExpandItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripExpandMenu;
        private System.Windows.Forms.Button cmdDeleteCheckedFiles;
        private System.Windows.Forms.FolderBrowserDialog dlgAddFolder;
        private System.Windows.Forms.Label lblSearchState;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripExpandAllItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripUnExpandAllItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripTagFileWildcard;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddFolderTagWildcard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripCutAllInFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripPasteItems;
        private System.Windows.Forms.Button btnAutoCheck;

    }
}

