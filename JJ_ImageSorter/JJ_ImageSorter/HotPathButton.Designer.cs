namespace JJ_ImageSorter
{
    partial class HotPathButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHotPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHotPath
            // 
            this.lblHotPath.AutoEllipsis = true;
            this.lblHotPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblHotPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHotPath.Location = new System.Drawing.Point(0, 0);
            this.lblHotPath.Name = "lblHotPath";
            this.lblHotPath.Size = new System.Drawing.Size(100, 49);
            this.lblHotPath.TabIndex = 0;
            this.lblHotPath.Text = "label1";
            this.lblHotPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHotPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblHotPath_DragDrop);
            this.lblHotPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblHotPath_DragEnter);
            this.lblHotPath.DoubleClick += new System.EventHandler(this.lblHotPath_DoubleClick);
            // 
            // HotPathButton
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblHotPath);
            this.Name = "HotPathButton";
            this.Size = new System.Drawing.Size(100, 49);
            this.Load += new System.EventHandler(this.HotPathButton_Load);
            this.SizeChanged += new System.EventHandler(this.HotPathButton_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.HotPathButton_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.HotPathButton_DragEnter);
            this.DoubleClick += new System.EventHandler(this.HotPathButton_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHotPath;

    }
}
