namespace SmartRender
{
    partial class Simulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulator));
            this.bg = new System.Windows.Forms.PictureBox();
            this.cm1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rclick = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.p2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).BeginInit();
            this.cm1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.BackColor = System.Drawing.Color.Black;
            this.bg.ContextMenuStrip = this.cm1;
            this.bg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Margin = new System.Windows.Forms.Padding(4);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(835, 379);
            this.bg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg.TabIndex = 13;
            this.bg.TabStop = false;
            this.bg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.bg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.bg.Resize += new System.EventHandler(this.p1_Resize);
            // 
            // cm1
            // 
            this.cm1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cm1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rclick});
            this.cm1.Name = "cm1";
            this.cm1.Size = new System.Drawing.Size(131, 30);
            // 
            // rclick
            // 
            this.rclick.Name = "rclick";
            this.rclick.Size = new System.Drawing.Size(130, 26);
            this.rclick.Text = "Uygula";
            this.rclick.Click += new System.EventHandler(this.uygulaToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 350);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "●Rec";
            // 
            // p1
            // 
            this.p1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1.ContextMenuStrip = this.cm1;
            this.p1.Image = ((System.Drawing.Image)(resources.GetObject("p1.Image")));
            this.p1.Location = new System.Drawing.Point(201, 54);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(425, 239);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1.TabIndex = 18;
            this.p1.TabStop = false;
            this.p1.Resize += new System.EventHandler(this.p1_Resize);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.Transparent;
            this.p2.ContextMenuStrip = this.cm1;
            this.p2.Location = new System.Drawing.Point(0, 0);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(95, 85);
            this.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2.TabIndex = 19;
            this.p2.TabStop = false;
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 379);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.bg);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Simulator";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Simulator_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Simulator_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.p1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bg)).EndInit();
            this.cm1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.ContextMenuStrip cm1;
        private System.Windows.Forms.ToolStripMenuItem rclick;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox p2;
        public System.Windows.Forms.PictureBox p1;
    }
}