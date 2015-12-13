using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRender.MainClass;
using System.Threading;
namespace SmartRender.Render
{
    class Video
    {
        static public string desteklenen = @"0123456789.:\/_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        static public void Onizle(string parameters)
        {
            ProcessStartInfo s = new ProcessStartInfo { Arguments = parameters, FileName = @"References\ffplay.exe", CreateNoWindow = true, UseShellExecute=false,LoadUserProfile =false};
            Process p = new Process { StartInfo = s };
            if (!File.Exists(s.FileName))
            { MessageBox.Show(string.Format("{0} Bulunamıyor!", s.FileName)); }
            else
            {
                p.Start();
            }
        }
        static public string _time(string videp_path)
        {
            string VideoSuresi = string.Empty;
            ProcessStartInfo s = new ProcessStartInfo
            {
                RedirectStandardError = true,
                UseShellExecute = false,
                LoadUserProfile = true,
                CreateNoWindow = false,
                FileName = Variables.FFMPEG
            };
            Process p = new Process { StartInfo = s };
            s.CreateNoWindow = true;
            s.Arguments = string.Format(@"-y -i ""{0}""", videp_path);
            if (p.Start())
            {
                StreamReader Reader = p.StandardError;
                while (!Reader.EndOfStream)
                {
                    string reading = Reader.ReadLine();

                    if (reading.Contains("Duration: "))
                    {
                        int baslangic = reading.IndexOf(":");
                        int bitis = reading.IndexOf(",");
                        VideoSuresi = reading.Substring(baslangic + 1, bitis - 11).ToString();

                    }
                }
            }
            return VideoSuresi;
        }
        static public string _boyut(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
        static public void _addF(string file, ListView WorkList)
        {

            if (Extansions.extension.ContainsKey(Path.GetExtension(file).ToLower()))
            {
                string[] charmap = new string[] {"?","!","#",".",",","*","+","{","}","(",")","€","£","[","]","+","'","^" };
                mainForm main = (mainForm)Application.OpenForms["mainForm"];
                bool errorchr = false;
                
                    for(int i =0;i<= charmap.Length-1;i++)
                    {
                        if (Path.GetFileNameWithoutExtension(file).Contains(charmap[i].ToString()))
                        {
                            errorchr = true;                            
                        }
                    }                   
                    

                if (!errorchr)
                {
                    FileInfo f = new FileInfo(file);
                    ListViewItem item = new ListViewItem { Text = file };
                    item.SubItems.Add(Video._time(file));
                    item.SubItems.Add(Video._boyut(f.Length));
                    item.SubItems.Add(Path.GetExtension(file));
                    item.SubItems.Add("Bekliyor..");
                    item.SubItems.Add("00:00:00");
                    WorkList.Items.AddRange(new ListViewItem[] { item });
                }
                else //geçersiz karakter varsa
                {
                    string v_path = file.Replace(Path.GetFileName(file), "");
                    string v_name = Path.GetFileNameWithoutExtension(file);                    
                    for(int i =0;i<=charmap.Length-1;i++)
                    {
                        v_name = v_name.Replace(charmap[i],"");
                    }
                    string replacingvideo = v_path + v_name + Path.GetExtension(file);
                    if (main.vfilename.Checked)
                    {
                        File.Move(file, replacingvideo);

                        FileInfo f = new FileInfo(replacingvideo);
                        ListViewItem item = new ListViewItem { Text = replacingvideo };
                        item.SubItems.Add(Video._time(replacingvideo));
                        item.SubItems.Add(Video._boyut(f.Length));
                        item.SubItems.Add(Path.GetExtension(file));
                        item.SubItems.Add("Bekliyor..");
                        item.SubItems.Add("00:00:00");
                        WorkList.Items.AddRange(new ListViewItem[] { item });
                    }
                    else
                    {
                      DialogResult dr =  MessageBox.Show(string.Format("Videonuzun İsminde Geçersiz Karakterler Var! Videonuzun ismini aşağıdaki gibi değiştirmemizi ister misiniz? \n\n\n {0} \n\n\n NOT: Bu işlemi otomatik yaptırıp, bu mesajı almak istemiyorsanız, YAZILIM AYARLARI SEKMESINDEKI Video isim kontrol kutucuğunu işaretleyin", v_name + Path.GetExtension(file)),"Hatalı Video İsmi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                      if (dr == DialogResult.Yes)
                      {
                          File.Move(file,replacingvideo);
    
                          FileInfo f = new FileInfo(replacingvideo);
                          ListViewItem item = new ListViewItem { Text = replacingvideo };
                          item.SubItems.Add(Video._time(replacingvideo));
                          item.SubItems.Add(Video._boyut(f.Length));
                          item.SubItems.Add(Path.GetExtension(file));
                          item.SubItems.Add("Bekliyor..");
                          item.SubItems.Add("00:00:00");
                          WorkList.Items.AddRange(new ListViewItem[] { item });
                      }
                        
                    
                    }

                }
            }
            else
            {
                SendMessage.Error(string.Format("{1} {0}", Path.GetExtension(file).Replace(".", "").ToUpper(), Messages.MSG_17[Language.ViewingLanguage]), "Warning");
            }
        }
        /*static public void _addFEX(string file,ListView WorkList)
        {
            try
            {
                FileInfo f = new FileInfo(file);
                ListViewItem item = new ListViewItem { Text = file };
                item.SubItems.Add(Video._time(file));
                item.SubItems.Add(Video._boyut(f.Length));
                item.SubItems.Add(Path.GetExtension(file));
                item.SubItems.Add("Bekliyor..");
                item.SubItems.Add("00:00:00");
                WorkList.Items.AddRange(new ListViewItem[] { item });
            }
            catch (Exception ex)
            { SendMessage.Success(ex.Message,"Hata"); }

        }*/
        /*static public string ReplaceFile(string file)
        {
            mainForm mainForm = (mainForm)Application.OpenForms["mainForm"];
            string v_Name = Path.GetFileName(file);//dosyanın sadece adını alıyorum
            string v_oldName = v_Name;
            string input = file.Replace(Path.GetFileName(file), ""); //Dosyanın Sadece Yolunu aldım
            string oldFileName = input; //Replace işlemine girmeden önceki dosyamız
            bool error = false;//hatalı karakter olup olmadığını kontrol edicem
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (!desteklenen.Contains(input[i].ToString())) //kontrol edilen karakter desteklenmiyorsa
                {
                    input = input.Replace(input[i].ToString(), "_");
                    error = true;
                }
            }
            if (error) //desteklenmeyen karakter bulunduysa adını değiştir
            {
               
                    if (Directory.Exists(oldFileName))
                    {
                        Directory.Move(oldFileName, input);
                        oldFileName = input;
                    }
              
                
            }
            //Dosya yolu kontrolü tamam! şimdi dosya ismini kontrol edelim
            bool f_error = false;
            for (int i = 0; i <= v_Name.Length - 1;i++ )
            {
                if(!desteklenen.Contains(v_Name[i].ToString())) //kontrol edilen karakter desteklenmiyorsa
                {
                    v_Name = v_Name.Replace(v_Name[i].ToString(), "_");
                    f_error = true;
                }
            }
            if(f_error)
            {
                string eski = string.Format("{0}{1}",input,v_oldName);
                string yeni = string.Format("{0}{1}", input, v_Name);
                File.Move(eski, yeni);
            }
            input += v_Name;


                return input;
        } */  
        /* static public void _ekle(string file, ListView WorkList)
        {
            if (Extansions.extension.ContainsKey(Path.GetExtension(file).ToLower()))
            {
                mainForm mainForm = (mainForm)Application.OpenForms["mainForm"];
                if (mainForm.vfilename.Checked)
                {
                    _addF(file, WorkList);
                }
                else
                {
                    bool err = false;
                    for(int i =0;i<=file.Length-1;i++)
                    {
                        if(!desteklenen.Contains(file[i].ToString()))
                        {
                            err = true;
                        }
                    }
                    if(err)
                    {
                       DialogResult dr = MessageBox.Show(string.Format("{0} \n\n Belirtilen dizinde Render işleminde hatalara sebep olabilecek karakterler var, Geçersiz karakterlerin silinmesini ister misiniz? \n\n\n Bu işlemi mesaj görmeden otomatik yaptırmak için YAZILIM AYARLARI sekmesinden VIDEO ISIM KONTROL kutucuğunu işaretlemeniz yeterli.",file),"Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(dr == DialogResult.Yes)
                        {
                            _addF(file, WorkList);
                        }
                        else
                        {
                            _addF(file, mainForm.WorkList);
                        }
                    }
                    else
                    {
                        _addF(file, mainForm.WorkList);
                    }
                }
            }
            else
            {
                SendMessage.Error(string.Format("Desteklenmeyen Uzantı : {0}", Path.GetExtension(file).Replace(".", "").ToUpper()), "Dosya Eklenmedi");
            }
        }*/ 
        static public void Thumblr_Complete(object sender, EventArgs e)
        {            
            try
            {
                SmallPicture Small = (SmallPicture)Application.OpenForms["SmallPicture"];
                Small.pic1.ImageLocation = Variables.S_PICTURE + @"\LastPicture.jpg";
                Small.pic1.Refresh();
            }
            catch
            { }
        }
        static public void Kucuk_Resim(string file,string time,int total=0)
        {
            //if (File.Exists(Variables.S_PICTURE + @"\LastPicture.jpg")) { File.Delete(Variables.S_PICTURE + @"\LastPicture.jpg"); }
            bool is_open = false;
            SmallPicture Small = (SmallPicture)Application.OpenForms["SmallPicture"];
            foreach(Form title in Application.OpenForms)
            {
                if (title.Text == "Küçük Resim Al")
             {
                 is_open = true;
             }
            }
            if(!is_open)
            {
                Small = new SmallPicture();
                Small.max = total;
                Small.file = file;
                Small.Show();
            }
            else { Small.Focus(); }

            Process p = new Process();
            ProcessStartInfo s = new ProcessStartInfo();
            s.UseShellExecute = false;
            s.FileName = Variables.FFMPEG;
            string argx = string.Format(@"-y -ss {3} -i ""{0}"" -vframes 1 {1}\{2}""", file, Variables.S_PICTURE, "LastPicture.jpg", time);
            s.Arguments = argx;
            p.StartInfo = s;
            s.CreateNoWindow = true;
            s.RedirectStandardError = true;
            s.UseShellExecute = false;
            s.LoadUserProfile = true;
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(Thumblr_Complete);
            p.Start();
        }
        static public void Intro_Image_Complete(object sender, EventArgs e)
        {
            try
            {
                OutputSettings yeni = (OutputSettings)Application.OpenForms["OutputSettings"];
                yeni.p1.ImageLocation = Variables.S_PICTURE + "//INTRO.jpg";
                yeni.p1.Refresh();
            }
            catch
            { }
        }
        static public void Intro_Image(string file,string time)
        {
            Process p = new Process();
            ProcessStartInfo s = new ProcessStartInfo();
            s.UseShellExecute = false;
            s.FileName = Variables.FFMPEG;
            string argx = string.Format(@"-y -ss {3} -i ""{0}"" -vframes 1 {1}\{2}""", file, Variables.S_PICTURE, "INTRO.jpg", time);
            s.Arguments = argx;
            p.StartInfo = s;
            s.CreateNoWindow = true;
            s.RedirectStandardError = true;
            s.UseShellExecute = false;
            s.LoadUserProfile = true;
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(Intro_Image_Complete);
            p.Start();
        }
        static public void Toplu_Kucuk_Resim(string file, string time, string yazi, int konum, string yazifont, int boyut, string renk)
        {
            string x = string.Empty;
            string y = string.Empty;
            switch (konum)
            {
                case 0: // Tam Ortaya
                    {
                        x = "(w-tw)/2";
                        y = "(h-th)/2";
                        break;
                    }
                case 1: // Sol Alt Köşe
                    {
                        x = "10";
                        y = "(h-th)-10";
                        break;
                    }
                case 2: //Sol Üst Köşe
                    {
                        x = "10";
                        y = x;
                        break;
                    }
                case 3: //Sağ Alt Köşe
                    {
                        x = "(w-tw)-10";
                        y = "(h-th)-10";
                        break;
                    }
                case 4: //Sağ Üst Köşe
                    {
                        x = "(w-tw)-10";
                        y = "10";
                        break;
                    }
            }



            Process p = new Process();
            ProcessStartInfo s = new ProcessStartInfo();
            s.UseShellExecute = false;
            s.FileName = Variables.FFMPEG;
            string argx = string.Empty;
            CollectivePicture Coll = (CollectivePicture)Application.OpenForms["CollectivePicture"];
            if (!Coll.c1.Checked)
            {
                argx = string.Format(@"-y -ss {0} -i ""{1}"" -vframes 1 ""{2}\{3}.jpg""", time, file, Variables.S_PICTURE, Path.GetFileNameWithoutExtension(file));
            }
            else
            {
                argx = string.Format(@"-y -ss {0} -i ""{1}"" -vf ""drawtext='fontsize={2}:fontfile={3}:fontcolor={4}:text={5}:x={6}:y={7}"" ""{8}/{9}.jpg""", time, file, boyut, yazifont, renk, yazi, x, y, Variables.S_PICTURE, Path.GetFileNameWithoutExtension(file));
            }
            s.Arguments = argx;
            p.StartInfo = s;
            s.CreateNoWindow = true;
            s.RedirectStandardError = true;
            s.UseShellExecute = false;
            s.LoadUserProfile = true;
            p.Start();
        }
        }
    }

