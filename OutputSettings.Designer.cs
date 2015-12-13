namespace SmartRender
{
    partial class OutputSettings
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
            this.p1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.r1 = new System.Windows.Forms.Label();
            this.r2 = new System.Windows.Forms.Label();
            this.r3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(12, 12);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(471, 318);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1.TabIndex = 0;
            this.p1.TabStop = false;
            this.p1.DragDrop += new System.Windows.Forms.DragEventHandler(this.p1_DragDrop);
            this.p1.DragEnter += new System.Windows.Forms.DragEventHandler(this.p1_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dosya Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Süre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Format";
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Location = new System.Drawing.Point(105, 333);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(67, 17);
            this.r1.TabIndex = 3;
            this.r1.Text = "%name%";
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(105, 359);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(58, 17);
            this.r2.TabIndex = 3;
            this.r2.Text = "%time%";
            // 
            // r3
            // 
            this.r3.AutoSize = true;
            this.r3.Location = new System.Drawing.Point(105, 383);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(72, 17);
            this.r3.TabIndex = 3;
            this.r3.Text = "%format%";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(489, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(548, 140);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // OutputSettings
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 434);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.r3);
            this.Controls.Add(this.r2);
            this.Controls.Add(this.r1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p1);
            this.Name = "OutputSettings";
            this.Text = "OutputSettings";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.p1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.p1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label r1;
        private System.Windows.Forms.Label r2;
        private System.Windows.Forms.Label r3;
        public System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.ListView listView1;
    }
}