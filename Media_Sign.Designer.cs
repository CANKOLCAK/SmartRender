namespace SmartRender
{
    partial class Media_Sign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Media_Sign));
            this.WorkList = new System.Windows.Forms.ListView();
            this.vFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.t1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.selectfolder = new System.Windows.Forms.Button();
            this.purpleButton1 = new SmartRender.Control.PurpleButton(this.components);
            this.SuspendLayout();
            // 
            // WorkList
            // 
            this.WorkList.AllowDrop = true;
            this.WorkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.vFile,
            this.tms});
            this.WorkList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.WorkList.FullRowSelect = true;
            this.WorkList.GridLines = true;
            this.WorkList.Location = new System.Drawing.Point(8, 41);
            this.WorkList.Name = "WorkList";
            this.WorkList.Size = new System.Drawing.Size(643, 377);
            this.WorkList.TabIndex = 2;
            this.WorkList.UseCompatibleStateImageBehavior = false;
            this.WorkList.View = System.Windows.Forms.View.Details;
            this.WorkList.DragDrop += new System.Windows.Forms.DragEventHandler(this.WorkList_DragDrop);
            this.WorkList.DragEnter += new System.Windows.Forms.DragEventHandler(this.WorkList_DragEnter);
            // 
            // vFile
            // 
            this.vFile.Text = "Video";
            // 
            // tms
            // 
            this.tms.Text = "Süre";
            this.tms.Width = 100;
            // 
            // t1
            // 
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.t1.Location = new System.Drawing.Point(165, 9);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(378, 28);
            this.t1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Çıktı Klasörü";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.info.Location = new System.Drawing.Point(12, 442);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 24);
            this.info.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // selectfolder
            // 
            this.selectfolder.FlatAppearance.BorderSize = 0;
            this.selectfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectfolder.Image = ((System.Drawing.Image)(resources.GetObject("selectfolder.Image")));
            this.selectfolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectfolder.Location = new System.Drawing.Point(549, 9);
            this.selectfolder.Name = "selectfolder";
            this.selectfolder.Size = new System.Drawing.Size(100, 23);
            this.selectfolder.TabIndex = 6;
            this.selectfolder.Text = "Seç";
            this.selectfolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectfolder.UseVisualStyleBackColor = true;
            this.selectfolder.Click += new System.EventHandler(this.selectfolder_Click);
            // 
            // purpleButton1
            // 
            this.purpleButton1.BackColor = System.Drawing.Color.DarkViolet;
            this.purpleButton1.FlatAppearance.BorderSize = 0;
            this.purpleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purpleButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.purpleButton1.ForeColor = System.Drawing.Color.White;
            this.purpleButton1.Location = new System.Drawing.Point(440, 424);
            this.purpleButton1.Name = "purpleButton1";
            this.purpleButton1.Size = new System.Drawing.Size(211, 59);
            this.purpleButton1.TabIndex = 3;
            this.purpleButton1.Text = "Tamam";
            this.purpleButton1.UseVisualStyleBackColor = false;
            this.purpleButton1.Click += new System.EventHandler(this.purpleButton1_Click);
            // 
            // Media_Sign
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 487);
            this.Controls.Add(this.selectfolder);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.purpleButton1);
            this.Controls.Add(this.WorkList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(681, 534);
            this.MinimumSize = new System.Drawing.Size(681, 534);
            this.Name = "Media_Sign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Media_Sign";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView WorkList;
        private System.Windows.Forms.ColumnHeader vFile;
        private System.Windows.Forms.ColumnHeader tms;
        private Control.PurpleButton purpleButton1;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button selectfolder;
    }
}