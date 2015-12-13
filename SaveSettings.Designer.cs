namespace SmartRender
{
    partial class SaveSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.json = new System.Windows.Forms.TextBox();
            this.c1 = new System.Windows.Forms.CheckBox();
            this.b1 = new SmartRender.Control.PurpleButton(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(108, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ayar İsmi";
            // 
            // json
            // 
            this.json.Location = new System.Drawing.Point(34, 77);
            this.json.Name = "json";
            this.json.Size = new System.Drawing.Size(260, 22);
            this.json.TabIndex = 0;
            // 
            // c1
            // 
            this.c1.AutoSize = true;
            this.c1.Location = new System.Drawing.Point(34, 105);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(186, 21);
            this.c1.TabIndex = 1;
            this.c1.Text = "Varsayılan Olarak Ayarla";
            this.c1.UseVisualStyleBackColor = true;
            // 
            // b1
            // 
            this.b1.BackColor = System.Drawing.Color.DarkViolet;
            this.b1.FlatAppearance.BorderSize = 0;
            this.b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b1.ForeColor = System.Drawing.Color.White;
            this.b1.Location = new System.Drawing.Point(106, 160);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(187, 45);
            this.b1.TabIndex = 8;
            this.b1.Text = "KAYDET";
            this.b1.UseVisualStyleBackColor = false;
            this.b1.Click += new System.EventHandler(this.smartButton1_Click);
            // 
            // SaveSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 322);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.c1);
            this.Controls.Add(this.json);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(346, 369);
            this.MinimumSize = new System.Drawing.Size(346, 369);
            this.Name = "SaveSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarları Kaydet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox json;
        private System.Windows.Forms.CheckBox c1;
        private Control.PurpleButton b1;
    }
}