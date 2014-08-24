namespace JJ_ImageSorter
{
    partial class Popup_DeleteFiles
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
            this.lstItemsToDelete = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDeleteStatus = new System.Windows.Forms.Label();
            this.progressBarDeleteStatus = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lstItemsToDelete
            // 
            this.lstItemsToDelete.FormattingEnabled = true;
            this.lstItemsToDelete.Location = new System.Drawing.Point(12, 12);
            this.lstItemsToDelete.Name = "lstItemsToDelete";
            this.lstItemsToDelete.Size = new System.Drawing.Size(144, 69);
            this.lstItemsToDelete.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(54, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblDeleteStatus
            // 
            this.lblDeleteStatus.AutoSize = true;
            this.lblDeleteStatus.Location = new System.Drawing.Point(31, 87);
            this.lblDeleteStatus.Name = "lblDeleteStatus";
            this.lblDeleteStatus.Size = new System.Drawing.Size(105, 13);
            this.lblDeleteStatus.TabIndex = 5;
            this.lblDeleteStatus.Text = "Deleted (x) of (y) files";
            // 
            // progressBarDeleteStatus
            // 
            this.progressBarDeleteStatus.Location = new System.Drawing.Point(12, 103);
            this.progressBarDeleteStatus.Name = "progressBarDeleteStatus";
            this.progressBarDeleteStatus.Size = new System.Drawing.Size(144, 21);
            this.progressBarDeleteStatus.TabIndex = 4;
            // 
            // Popup_DeleteFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(163, 161);
            this.ControlBox = false;
            this.Controls.Add(this.lstItemsToDelete);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDeleteStatus);
            this.Controls.Add(this.progressBarDeleteStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Popup_DeleteFiles";
            this.ShowInTaskbar = false;
            this.Text = "Delete Complete";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Popup_DeleteFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstItemsToDelete;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblDeleteStatus;
        private System.Windows.Forms.ProgressBar progressBarDeleteStatus;
    }
}