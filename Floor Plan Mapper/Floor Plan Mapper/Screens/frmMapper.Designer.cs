namespace Floor_Plan_Mapper.Screens
{
    partial class frmMapper
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
            this.studio = new Studio();
            this.stdMain = new Studio();
            this.SuspendLayout();
            // 
            // studio
            // 
            this.studio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studio.Location = new System.Drawing.Point(0, 0);
            this.studio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.studio.Name = "studio";
            this.studio.Quality = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.studio.Size = new System.Drawing.Size(2880, 1319);
            this.studio.TabIndex = 0;
            this.studio.Text = "sarrow_Tabselector1";
            // 
            // stdMain
            // 
            this.stdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stdMain.Location = new System.Drawing.Point(0, 0);
            this.stdMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stdMain.Name = "stdMain";
            this.stdMain.Quality = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.stdMain.Size = new System.Drawing.Size(2880, 1319);
            this.stdMain.TabIndex = 0;
            this.stdMain.Text = "sarrow_Tabselector1";
            // 
            // frmMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2304, 1055);
            this.Controls.Add(this.studio);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMapper";
            this.Text = "Mapper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMapper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Studio studio;
        private Studio stdMain;
    }
}