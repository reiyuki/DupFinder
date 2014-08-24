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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test2");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAddPath = new System.Windows.Forms.Button();
            this.lvSelectedPaths = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hotPathButton1 = new JJ_ImageSorter.HotPathButton();
            this.SuspendLayout();
            // 
            // btnAddPath
            // 
            this.btnAddPath.Location = new System.Drawing.Point(304, 79);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(79, 29);
            this.btnAddPath.TabIndex = 1;
            this.btnAddPath.Text = "Add Path";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // lvSelectedPaths
            // 
            this.lvSelectedPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSelectedPaths.FullRowSelect = true;
            this.lvSelectedPaths.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.lvSelectedPaths.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.lvSelectedPaths.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvSelectedPaths.Location = new System.Drawing.Point(304, 114);
            this.lvSelectedPaths.MultiSelect = false;
            this.lvSelectedPaths.Name = "lvSelectedPaths";
            this.lvSelectedPaths.Size = new System.Drawing.Size(232, 97);
            this.lvSelectedPaths.TabIndex = 2;
            this.lvSelectedPaths.UseCompatibleStateImageBehavior = false;
            this.lvSelectedPaths.View = System.Windows.Forms.View.List;
            // 
            // hotPathButton1
            // 
            this.hotPathButton1.AllowDrop = true;
            this.hotPathButton1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hotPathButton1.hotPath = ((System.IO.DirectoryInfo)(resources.GetObject("hotPathButton1.hotPath")));
            this.hotPathButton1.hotPathString = "c:\\temp";
            this.hotPathButton1.Location = new System.Drawing.Point(21, 12);
            this.hotPathButton1.Name = "hotPathButton1";
            this.hotPathButton1.Size = new System.Drawing.Size(100, 49);
            this.hotPathButton1.TabIndex = 0;
            this.hotPathButton1.DragEnter += new System.Windows.Forms.DragEventHandler(this.hotPathButton1_DragEnter);
            this.hotPathButton1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.hotPathButton1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 363);
            this.Controls.Add(this.lvSelectedPaths);
            this.Controls.Add(this.btnAddPath);
            this.Controls.Add(this.hotPathButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private HotPathButton hotPathButton1;
        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.ListView lvSelectedPaths;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

    }
}

