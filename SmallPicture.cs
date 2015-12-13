using SmartRender.MainClass;
using SmartRender.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRender
{
    public partial class SmallPicture : Form
    {
        public SmallPicture()
        {
            InitializeComponent();
            save.Click(new EventHandler(button1_Click));
        }
        int maxi;
        public int max
        {
            get { return maxi; }
            set { maxi = value; tbar.Maximum = value; }
        }
        string video;
        public string file
        {
            get { return video; }
            set { video = value; }
        }
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Variables.S_PICTURE + @"\LastPicture.jpg", fbd.SelectedPath + @"\" + t1.Text + ".jpg");
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            double second = double.Parse(tbar.Value.ToString());
            string saniye = TimeSpan.FromSeconds(second).ToString();
            Video.Kucuk_Resim(file, saniye, tbar.Maximum);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = tbar.Value.ToString();
        }
    }
}
