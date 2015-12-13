using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRender.Render;
using System.Diagnostics;
using SmartRender.MainClass;
using System.IO;
using System.Threading;
using System;

namespace SmartRender
{
    public partial class Media_Sign : Form
    {
        int _index = 0;
        public Media_Sign()
        {
            InitializeComponent();
            WorkList.Columns[0].Width = WorkList.Width - 105;
        }
        private void WorkList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void WorkList_DragDrop(object sender, DragEventArgs e)
        {
            String[] videos = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string video in videos)
            {
                Video._addF(video, WorkList);
            }
        }
        public void Apply_Completing(object sender, EventArgs e)
        {
            if(_index != WorkList.Items.Count -1)
            {
                _index++;
                thr = new Thread(Imzala);
                thr.Start();
            }
            else
            {
                timer1.Stop();
                BeginInvoke(new Action(() => info.Text = string.Format("Devam Ediyor.. {1}/{1}", _index, WorkList.Items.Count)));
                SendMessage.Success(Messages.MSG_14[Language.ViewingLanguage], "Success");
            }
        }
        public void Imzala()
        {
            string dosya = WorkList.Items[_index].Text;
            string dosya_adi = Path.GetFileName(WorkList.Items[_index].Text);
            string klasor = t1.Text;
            ProcessStartInfo s = new ProcessStartInfo
            {
                RedirectStandardError = true,
                UseShellExecute = false,
                LoadUserProfile = true,
                CreateNoWindow = true,
                FileName = Variables.FFMPEG,
                Arguments = string.Format(@"-y -i ""{0}"" -codec:v libx264 ""{1}/_{2}""",dosya,klasor,dosya_adi)
            };
            Process p = new Process { StartInfo = s };
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(Apply_Completing);
            if (p.Start())
            {

                p.Refresh();
                StreamReader testReader = p.StandardError;

                while (testReader.ReadLine() != null)
                {
                    try
                    {
                        string satir = testReader.ReadLine().Substring(0, 6);
                        if (satir == "frame=")
                        {

                            /*int t_index = testReader.ReadLine().IndexOf("time=");
                            string saniye = testReader.ReadLine().Substring(t_index + 5, 8);
                            double seconds = TimeSpan.Parse(saniye).TotalSeconds;
                            double toplam = TimeSpan.Parse(total.Text).TotalSeconds;

                            double process = (seconds / toplam) * 100;
                            string normal = process.ToString().Substring(0, process.ToString().IndexOf(","));
                            Console.WriteLine("%{0}", normal);
                            Application.DoEvents();*/
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            else
            { Console.WriteLine("Error"); }
        }
        Thread thr;

        private void purpleButton1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(t1.Text))
            {
                thr = new Thread(Imzala);
                thr.Start();
                timer1.Start();
            }
            else
            {
                SendMessage.Success("Çıktı Klasörünün Var Olduğundan Emin Olun","Warning");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            info.Text = string.Format("Devam Ediyor.. {0}/{1}",_index,WorkList.Items.Count);
        }

        private void selectfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            { t1.Text = fd.SelectedPath; }
        }
    }
}
