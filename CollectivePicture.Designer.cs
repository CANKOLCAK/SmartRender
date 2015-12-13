namespace SmartRender
{
    partial class CollectivePicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectivePicture));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.yazikonum = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boyut = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fnt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.clr = new System.Windows.Forms.Button();
            this.smalltext = new System.Windows.Forms.TextBox();
            this.c1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.smallsecond = new System.Windows.Forms.TextBox();
            this.purpleButton1 = new SmartRender.Control.PurpleButton(this.components);
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.yazikonum);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.boyut);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.fnt);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.linkLabel1);
            this.groupBox6.Controls.Add(this.clr);
            this.groupBox6.Controls.Add(this.smalltext);
            this.groupBox6.Controls.Add(this.c1);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.smallsecond);
            this.groupBox6.Location = new System.Drawing.Point(10, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(316, 238);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Küçük Resim Ayarları";
            // 
            // yazikonum
            // 
            this.yazikonum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yazikonum.FormattingEnabled = true;
            this.yazikonum.Items.AddRange(new object[] {
            "Ortaya",
            "Sol Alt Köşe",
            "Sol Üst Köşe",
            "Sağ Alt Köşe",
            "Sağ Üst Köşe"});
            this.yazikonum.Location = new System.Drawing.Point(109, 177);
            this.yazikonum.Name = "yazikonum";
            this.yazikonum.Size = new System.Drawing.Size(194, 24);
            this.yazikonum.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Konum";
            // 
            // boyut
            // 
            this.boyut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boyut.FormattingEnabled = true;
            this.boyut.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.boyut.Location = new System.Drawing.Point(109, 207);
            this.boyut.Name = "boyut";
            this.boyut.Size = new System.Drawing.Size(194, 24);
            this.boyut.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Boyut";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Font";
            // 
            // fnt
            // 
            this.fnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fnt.FormattingEnabled = true;
            this.fnt.Location = new System.Drawing.Point(109, 146);
            this.fnt.Name = "fnt";
            this.fnt.Size = new System.Drawing.Size(194, 24);
            this.fnt.TabIndex = 7;
            this.fnt.Click += new System.EventHandler(this.fnt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Yazı Rengi";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(130, 122);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(151, 17);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "(Değiştirmek için Tıkla)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // clr
            // 
            this.clr.BackColor = System.Drawing.Color.Black;
            this.clr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clr.Location = new System.Drawing.Point(15, 120);
            this.clr.Name = "clr";
            this.clr.Size = new System.Drawing.Size(23, 23);
            this.clr.TabIndex = 4;
            this.clr.UseVisualStyleBackColor = false;
            // 
            // smalltext
            // 
            this.smalltext.Location = new System.Drawing.Point(15, 92);
            this.smalltext.Name = "smalltext";
            this.smalltext.Size = new System.Drawing.Size(288, 22);
            this.smalltext.TabIndex = 3;
            this.smalltext.Text = "Smart Render";
            // 
            // c1
            // 
            this.c1.AutoSize = true;
            this.c1.Location = new System.Drawing.Point(15, 65);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(296, 21);
            this.c1.TabIndex = 2;
            this.c1.Text = "Küçük Resme Yazı Bastır (Aşağıya Giriniz)";
            this.c1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Küçük Resmin Alınacağı Saniye";
            // 
            // smallsecond
            // 
            this.smallsecond.Location = new System.Drawing.Point(228, 37);
            this.smallsecond.Name = "smallsecond";
            this.smallsecond.Size = new System.Drawing.Size(75, 22);
            this.smallsecond.TabIndex = 0;
            this.smallsecond.Text = "1";
            this.smallsecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // purpleButton1
            // 
            this.purpleButton1.BackColor = System.Drawing.Color.DarkViolet;
            this.purpleButton1.FlatAppearance.BorderSize = 0;
            this.purpleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purpleButton1.ForeColor = System.Drawing.Color.White;
            this.purpleButton1.Location = new System.Drawing.Point(10, 251);
            this.purpleButton1.Name = "purpleButton1";
            this.purpleButton1.Size = new System.Drawing.Size(316, 30);
            this.purpleButton1.TabIndex = 7;
            this.purpleButton1.Text = "TAMAM";
            this.purpleButton1.UseVisualStyleBackColor = false;
            this.purpleButton1.Click += new System.EventHandler(this.purpleButton1_Click);
            // 
            // CollectivePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 289);
            this.Controls.Add(this.purpleButton1);
            this.Controls.Add(this.groupBox6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(350, 336);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 336);
            this.Name = "CollectivePicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "#Smart Render | Toplu Küçük Resim Ayarlama";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox yazikonum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox boyut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox fnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button clr;
        private System.Windows.Forms.TextBox smalltext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox smallsecond;
        private Control.PurpleButton purpleButton1;
        public System.Windows.Forms.CheckBox c1;
    }
}