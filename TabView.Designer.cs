namespace SmartRender
{
    partial class TabView
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
            this.FW1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FW1
            // 
            this.FW1.AutoScroll = true;
            this.FW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FW1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FW1.Location = new System.Drawing.Point(0, 0);
            this.FW1.Name = "FW1";
            this.FW1.Size = new System.Drawing.Size(829, 305);
            this.FW1.TabIndex = 0;
            // 
            // TabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkViolet;
            this.ClientSize = new System.Drawing.Size(829, 305);
            this.Controls.Add(this.FW1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TabView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TabView";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabView_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel FW1;

    }
}