using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRender.Render;
using System.IO;
using System.Collections.Specialized;
namespace SmartRender
{
    public partial class OutputSettings : Form
    {
        public OutputSettings()
        {
            InitializeComponent();
        }

        private void p1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void p1_DragDrop(object sender, DragEventArgs e)
        {
            String[] dosyalar = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach(string video in dosyalar)
            {
                r1.Text = Path.GetFileName(video);
                r2.Text = Video._time(video);
                r3.Text = Path.GetExtension(video);
                Video.Intro_Image(video, "3");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
