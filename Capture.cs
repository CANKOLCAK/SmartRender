using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRender.MainClass;
namespace SmartRender
{
    public partial class Capture : Form
    {
        public Capture()
        {
            InitializeComponent();
            if(Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                F1.Text = "Dosya";
                F1.Text = "Farklı Kaydet";
            }
            else
            {
                F1.Text = "File";
                F1.Text = "Save As";
            }
        }
        string now_Capture_Time()
        {
            return string.Format("{0}_{1}_{2}_{3}_{4}_{5}",DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second,DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Year);
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                Captured.Image.Save(string.Format("{0}/Smart_Render{1}.png",fd.SelectedPath,now_Capture_Time()));
            }
        }

        private void Capture_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                try
                {
                    mainForm mainFrm = (mainForm)Application.OpenForms["mainForm"];
                    mainFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Bitmap bmp = new Bitmap(((int)mainFrm.Width) + 2, ((int)mainFrm.Height) + 2);
                    mainFrm.DrawToBitmap(bmp, new Rectangle(0, 0, ((int)mainFrm.Width) + 2, ((int)mainFrm.Height) + 2));
                    Captured.Image = bmp;
                    mainFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                }
                catch { SendMessage.Error("Smart Render Error","Warning"); }
            }
        }
    }
}
