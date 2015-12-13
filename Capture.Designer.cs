namespace SmartRender
{
    partial class Capture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Capture));
            this.Captured = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.F = new System.Windows.Forms.ToolStripMenuItem();
            this.F1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Captured)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Captured
            // 
            this.Captured.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Captured.Location = new System.Drawing.Point(0, 28);
            this.Captured.Name = "Captured";
            this.Captured.Size = new System.Drawing.Size(761, 419);
            this.Captured.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Captured.TabIndex = 0;
            this.Captured.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.F});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // F
            // 
            this.F.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.F1});
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(44, 24);
            this.F.Text = "&File";
            // 
            // F1
            // 
            this.F1.Name = "F1";
            this.F1.Size = new System.Drawing.Size(168, 26);
            this.F1.Text = "Farklı Kaydet";
            this.F1.Click += new System.EventHandler(this.farklıKaydetToolStripMenuItem_Click);
            // 
            // Capture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 447);
            this.Controls.Add(this.Captured);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Capture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekran Görüntüsü Yakala";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Capture_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Captured)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem F;
        private System.Windows.Forms.ToolStripMenuItem F1;
        public System.Windows.Forms.PictureBox Captured;
    }
}