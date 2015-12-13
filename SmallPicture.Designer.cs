namespace SmartRender
{
    partial class SmallPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallPicture));
            this.tbar = new System.Windows.Forms.TrackBar();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.save = new SmartRender.Control.SmartButton();
            this.t1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbar
            // 
            this.tbar.Location = new System.Drawing.Point(8, 404);
            this.tbar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbar.Name = "tbar";
            this.tbar.Size = new System.Drawing.Size(840, 56);
            this.tbar.TabIndex = 8;
            this.tbar.Value = 1;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(17, 11);
            this.pic1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(821, 386);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 6;
            this.pic1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.DarkViolet;
            this.save.BFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.save.BForeColor = System.Drawing.Color.White;
            this.save.BText = "Farklı Kaydet";
            this.save.Location = new System.Drawing.Point(658, 453);
            this.save.MDown = System.Drawing.Color.MediumOrchid;
            this.save.MMove = System.Drawing.Color.DarkOrchid;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(180, 49);
            this.save.TabIndex = 10;
            this.save.Text = "smartButton1";
            this.save.UseVisualStyleBackColor = false;
            // 
            // t1
            // 
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.t1.ForeColor = System.Drawing.Color.Gray;
            this.t1.Location = new System.Drawing.Point(17, 459);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(635, 38);
            this.t1.TabIndex = 11;
            this.t1.Text = "Thumbnail";
            // 
            // SmallPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 514);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.tbar);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmallPicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Küçük Resim Al";
            ((System.ComponentModel.ISupportInitialize)(this.tbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TrackBar tbar;
        public System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private Control.SmartButton save;
        private System.Windows.Forms.TextBox t1;
    }
}