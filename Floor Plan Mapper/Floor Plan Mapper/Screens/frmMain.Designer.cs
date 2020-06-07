namespace Floor_Plan_Mapper
{
    partial class frmMain
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.grpbSelectFile = new System.Windows.Forms.GroupBox();
            this.grpbxPreview = new System.Windows.Forms.GroupBox();
            this.btnStudio = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.tbBuildingName = new System.Windows.Forms.TextBox();
            this.tbFloor = new System.Windows.Forms.TextBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.lblBuildingName = new System.Windows.Forms.Label();
            this.grpbSelectFile.SuspendLayout();
            this.grpbxPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(9, 29);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(439, 26);
            this.txtFile.TabIndex = 0;
            this.txtFile.Text = "Select File";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(456, 25);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(103, 35);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "Browse";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // grpbSelectFile
            // 
            this.grpbSelectFile.Controls.Add(this.txtFile);
            this.grpbSelectFile.Controls.Add(this.btnFile);
            this.grpbSelectFile.Location = new System.Drawing.Point(18, 19);
            this.grpbSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbSelectFile.Name = "grpbSelectFile";
            this.grpbSelectFile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbSelectFile.Size = new System.Drawing.Size(592, 80);
            this.grpbSelectFile.TabIndex = 2;
            this.grpbSelectFile.TabStop = false;
            this.grpbSelectFile.Text = "Select File";
            // 
            // grpbxPreview
            // 
            this.grpbxPreview.Controls.Add(this.tbBuildingName);
            this.grpbxPreview.Controls.Add(this.lblBuildingName);
            this.grpbxPreview.Controls.Add(this.lblFloor);
            this.grpbxPreview.Controls.Add(this.tbFloor);
            this.grpbxPreview.Controls.Add(this.btnStudio);
            this.grpbxPreview.Controls.Add(this.picPreview);
            this.grpbxPreview.Location = new System.Drawing.Point(18, 108);
            this.grpbxPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxPreview.Name = "grpbxPreview";
            this.grpbxPreview.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxPreview.Size = new System.Drawing.Size(592, 374);
            this.grpbxPreview.TabIndex = 3;
            this.grpbxPreview.TabStop = false;
            this.grpbxPreview.Text = "Preview";
            // 
            // btnStudio
            // 
            this.btnStudio.Location = new System.Drawing.Point(402, 328);
            this.btnStudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStudio.Name = "btnStudio";
            this.btnStudio.Size = new System.Drawing.Size(177, 35);
            this.btnStudio.TabIndex = 8;
            this.btnStudio.Text = "Open Studio";
            this.btnStudio.UseVisualStyleBackColor = true;
            this.btnStudio.Click += new System.EventHandler(this.btnStudio_Click);
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(10, 31);
            this.picPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(569, 287);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // tbBuildingName
            // 
            this.tbBuildingName.Location = new System.Drawing.Point(241, 332);
            this.tbBuildingName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBuildingName.Name = "tbBuildingName";
            this.tbBuildingName.Size = new System.Drawing.Size(153, 26);
            this.tbBuildingName.TabIndex = 2;
            this.tbBuildingName.Text = "Gilman";
            this.tbBuildingName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbFloor
            // 
            this.tbFloor.Location = new System.Drawing.Point(80, 332);
            this.tbFloor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFloor.Name = "tbFloor";
            this.tbFloor.Size = new System.Drawing.Size(82, 26);
            this.tbFloor.TabIndex = 9;
            this.tbFloor.Text = "1";
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.Location = new System.Drawing.Point(25, 335);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(52, 20);
            this.lblFloor.TabIndex = 10;
            this.lblFloor.Text = "Floor:";
            // 
            // lblBuildingName
            // 
            this.lblBuildingName.AutoSize = true;
            this.lblBuildingName.Location = new System.Drawing.Point(169, 334);
            this.lblBuildingName.Name = "lblBuildingName";
            this.lblBuildingName.Size = new System.Drawing.Size(74, 20);
            this.lblBuildingName.TabIndex = 11;
            this.lblBuildingName.Text = "Building:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 489);
            this.Controls.Add(this.grpbxPreview);
            this.Controls.Add(this.grpbSelectFile);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Floor Plan Mapper";
            this.grpbSelectFile.ResumeLayout(false);
            this.grpbSelectFile.PerformLayout();
            this.grpbxPreview.ResumeLayout(false);
            this.grpbxPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.GroupBox grpbSelectFile;
        private System.Windows.Forms.GroupBox grpbxPreview;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnStudio;
        private System.Windows.Forms.TextBox tbBuildingName;
        private System.Windows.Forms.Label lblBuildingName;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox tbFloor;
    }
}

