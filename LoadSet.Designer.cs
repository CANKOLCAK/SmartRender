namespace SmartRender
{
    partial class LoadSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadSet));
            this.set_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ok = new SmartRender.Control.SmartButton();
            this.SuspendLayout();
            // 
            // set_combo
            // 
            this.set_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.set_combo.FormattingEnabled = true;
            this.set_combo.Location = new System.Drawing.Point(32, 86);
            this.set_combo.Name = "set_combo";
            this.set_combo.Size = new System.Drawing.Size(341, 24);
            this.set_combo.TabIndex = 0;
            this.set_combo.Click += new System.EventHandler(this.set_combo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ayar dosyası seçin (JSON)";
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.DarkViolet;
            this.ok.BFont = null;
            this.ok.BForeColor = System.Drawing.Color.White;
            this.ok.BText = "Tamam";
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ok.Location = new System.Drawing.Point(193, 126);
            this.ok.MDown = System.Drawing.Color.MediumOrchid;
            this.ok.MMove = System.Drawing.Color.DarkOrchid;
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(180, 49);
            this.ok.TabIndex = 2;
            this.ok.Text = "smartButton1";
            this.ok.UseVisualStyleBackColor = false;
            // 
            // LoadSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 225);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.set_combo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(431, 272);
            this.MinimumSize = new System.Drawing.Size(431, 272);
            this.Name = "LoadSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarları Yükle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox set_combo;
        private System.Windows.Forms.Label label1;
        private Control.SmartButton ok;
    }
}