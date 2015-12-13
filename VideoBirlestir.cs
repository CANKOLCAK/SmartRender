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
using System.Diagnostics;
using SmartRender.MainClass;
using System.IO;
using System.Threading;
namespace SmartRender
{
    public partial class VideoBirlestir : Form
    {
        int _index = 0;
        string INTRO = string.Empty;
        public VideoBirlestir()
        {
            InitializeComponent();
            WorkList.Columns[0].Width = WorkList.Width - 105;
            if(Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                tDuration.Text = "Toplam Süre";
                label1.Text = "Videonun Kayıt Edileceği Yer";
                label2.Text = "Çıktı Dosyasının Adı";
                ok.Text = "TAMAM";
                change.Text = "Değiştir";
                Text = "Video Birleştir";
                comb.Text = "Video Birleştir";
            }
            else
            {
                tDuration.Text = "Total Duration";
                label1.Text = "Output Folder";
                label2.Text = "Output File Name";
                ok.Text = "DONE";
                change.Text = "Change";
                Text = "Video Combine";
                comb.Text = "Video Combine";
            }
        }

        private void WorkList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void WorkList_DragDrop(object sender, DragEventArgs e)
        {
            String[] videos = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach(string video in videos)
            {
                Video._addF(video, WorkList);
            }
        }
        public void Intro()
        {
            #region Create Initialize
            using(StreamWriter sw= new StreamWriter("1.txt"))
            {
                string pros = WorkList.Items[_index].Text;

                sw.WriteLine(string.Format("file '{0}'",INTRO) + Environment.NewLine);
                sw.WriteLine(string.Format("file '{0}'",pros));
                sw.Close();
            }


            #endregion
        }
        public void Intro_Completing(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => pBar.Value = pBar.Maximum));
            SendMessage.Success(Messages.MSG_14[Language.ViewingLanguage], "Success");
        }
        public void Birlestir()
        {

            using (StreamWriter sw = new StreamWriter("1.txt"))
            {
                foreach(ListViewItem file in WorkList.Items)
                {               
                    sw.WriteLine(string.Format("file '{0}'", file.Text));                               
                }
                sw.Close();
            }

            ProcessStartInfo s = new ProcessStartInfo
            {
                RedirectStandardError = true,
                UseShellExecute = false,
                LoadUserProfile = true,
                CreateNoWindow = true,
                FileName = Variables.FFMPEG,
                Arguments = string.Format(@"-f concat -i ""{0}"" -preset ultrafast -b 2500k ""{1}/{2}""", "1.txt", t1.Text, t2.Text)
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

                            int t_index = testReader.ReadLine().IndexOf("time=");
                            string saniye = testReader.ReadLine().Substring(t_index + 5, 8);
                            double seconds = TimeSpan.Parse(saniye).TotalSeconds;
                            double toplam = TimeSpan.Parse(total.Text).TotalSeconds;

                            double process = (seconds / toplam) * 100;
                            string normal = process.ToString().Substring(0, process.ToString().IndexOf(","));
                            Console.WriteLine("%{0}", normal);
                                if (int.Parse(normal) < pBar.Maximum)
                                {
                                    BeginInvoke(new Action(() => pBar.Value = int.Parse(normal)));
                                }
                            Application.DoEvents();
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

        private void purpleButton2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(t1.Text)) { thr = new Thread(Birlestir); thr.Start(); } else { SendMessage.Success(Messages.MSG_7[Language.ViewingLanguage], "Error"); }            
        }
        public void Apply_Completing(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => pBar.Value = pBar.Maximum));
            SendMessage.Success(Messages.MSG_14[Language.ViewingLanguage],"Success");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (WorkList.Items.Count > 0)
                {
                    int TotalDuration = 0;
                    foreach (ListViewItem Duration in WorkList.Items)
                    {
                        TotalDuration += (int)TimeSpan.Parse(Duration.SubItems[1].Text).TotalSeconds;
                    }
                    pBar.Maximum = TotalDuration;
                    total.Text = TimeSpan.FromSeconds(double.Parse(TotalDuration.ToString())).ToString();
                }
            }
            catch { }
        }

        private void purpleButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                t1.Text = fd.SelectedPath;
            }
        }

    }
}
