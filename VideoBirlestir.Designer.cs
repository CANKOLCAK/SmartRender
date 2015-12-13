namespace SmartRender
{
    partial class VideoBirlestir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoBirlestir));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ok = new SmartRender.Control.PurpleButton(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.TextBox();
            this.change = new SmartRender.Control.PurpleButton(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.TextBox();
            this.WorkList = new System.Windows.Forms.ListView();
            this.vFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.total = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.intro = new System.Windows.Forms.RadioButton();
            this.outro = new System.Windows.Forms.RadioButton();
            this.comb = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comb);
            this.groupBox1.Controls.Add(this.outro);
            this.groupBox1.Controls.Add(this.intro);
            this.groupBox1.Controls.Add(this.ok);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.t2);
            this.groupBox1.Controls.Add(this.change);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.t1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(537, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 482);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayarlar";
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.DarkViolet;
            this.ok.FlatAppearance.BorderSize = 0;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ok.ForeColor = System.Drawing.Color.White;
            this.ok.Location = new System.Drawing.Point(9, 229);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(283, 53);
            this.ok.TabIndex = 5;
            this.ok.Text = "BAŞLAT";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.purpleButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Çıktı Dosyasının Adı";
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(6, 144);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(286, 22);
            this.t2.TabIndex = 3;
            this.t2.Text = "SMART.mp4";
            // 
            // change
            // 
            this.change.BackColor = System.Drawing.Color.DarkViolet;
            this.change.FlatAppearance.BorderSize = 0;
            this.change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.change.ForeColor = System.Drawing.Color.White;
            this.change.Location = new System.Drawing.Point(198, 87);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(94, 30);
            this.change.TabIndex = 2;
            this.change.Text = "Değiştir";
            this.change.UseVisualStyleBackColor = false;
            this.change.Click += new System.EventHandler(this.purpleButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Videonun Kayıt Edileceği Yer";
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(6, 59);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(286, 22);
            this.t1.TabIndex = 0;
            // 
            // WorkList
            // 
            this.WorkList.AllowDrop = true;
            this.WorkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.vFile,
            this.tms});
            this.WorkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkList.FullRowSelect = true;
            this.WorkList.GridLines = true;
            this.WorkList.Location = new System.Drawing.Point(0, 0);
            this.WorkList.Name = "WorkList";
            this.WorkList.Size = new System.Drawing.Size(537, 482);
            this.WorkList.TabIndex = 1;
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
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.pBar,
            this.tDuration,
            this.total});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(537, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 20);
            this.toolStripStatusLabel1.Text = "Process";
            // 
            // pBar
            // 
            this.pBar.Name = "pBar";
            this.pBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.pBar.Size = new System.Drawing.Size(280, 19);
            // 
            // tDuration
            // 
            this.tDuration.Name = "tDuration";
            this.tDuration.Size = new System.Drawing.Size(92, 20);
            this.tDuration.Text = "Toplam Süre";
            // 
            // total
            // 
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(63, 20);
            this.total.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // intro
            // 
            this.intro.AutoSize = true;
            this.intro.Location = new System.Drawing.Point(150, 316);
            this.intro.Name = "intro";
            this.intro.Size = new System.Drawing.Size(57, 21);
            this.intro.TabIndex = 6;
            this.intro.Text = "Intro";
            this.intro.UseVisualStyleBackColor = true;
            // 
            // outro
            // 
            this.outro.AutoSize = true;
            this.outro.Location = new System.Drawing.Point(213, 316);
            this.outro.Name = "outro";
            this.outro.Size = new System.Drawing.Size(65, 21);
            this.outro.TabIndex = 7;
            this.outro.Text = "Outro";
            this.outro.UseVisualStyleBackColor = true;
            // 
            // comb
            // 
            this.comb.AutoSize = true;
            this.comb.Checked = true;
            this.comb.Location = new System.Drawing.Point(9, 316);
            this.comb.Name = "comb";
            this.comb.Size = new System.Drawing.Size(135, 21);
            this.comb.TabIndex = 8;
            this.comb.TabStop = true;
            this.comb.Text = "Video Birleştirme";
            this.comb.UseVisualStyleBackColor = true;
            // 
            // VideoBirlestir
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 482);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.WorkList);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(859, 529);
            this.MinimumSize = new System.Drawing.Size(859, 529);
            this.Name = "VideoBirlestir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoBirlestir";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView WorkList;
        private System.Windows.Forms.ColumnHeader vFile;
        private Control.PurpleButton ok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t2;
        private Control.PurpleButton change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripProgressBar pBar;
        private System.Windows.Forms.ColumnHeader tms;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel total;
        private System.Windows.Forms.ToolStripStatusLabel tDuration;
        private System.Windows.Forms.RadioButton comb;
        private System.Windows.Forms.RadioButton outro;
        private System.Windows.Forms.RadioButton intro;
    }
}