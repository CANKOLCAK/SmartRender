using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRender.Control;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace SmartRender.MainClass
{
    class Controllers
    {
        static public mainForm MainForm = (mainForm)Application.OpenForms["mainForm"]; 
        static public String[] PictureFormats = new String[] {".png",".bmp",".jpg",".jpeg","ico","icon" };
        static public string sim_background = "800:600";
        static public string sim_video = "600:480";
        static public void getFiles(ComboBox Combo,string FPath)
        {
            Combo.Items.Clear();
            foreach (string Files in Directory.GetFiles(FPath))
            {
                if (PictureFormats.Contains(Path.GetExtension(Files).ToLower()))
                {
                    Combo.Items.Add(Path.GetFileName(Files));
                }
            }
            Combo.Items.Add("");
        }
        static public void DirectoryControllers(string[] Directories)
        {
            foreach (string directory in Directories)
            {
                if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            }
        }
        static public void AutoSizeWorkList(ListView WorkList)
        {
            int total = WorkList.Width;
            int bir = WorkList.Columns[1].Width;
            int iki = WorkList.Columns[2].Width;
            int uc = WorkList.Columns[3].Width;
            int dort = WorkList.Columns[4].Width;
            int bes = WorkList.Columns[5].Width;
            int sonuc = total - (bir + iki + uc + dort + bes);
            WorkList.Columns[0].Width = sonuc - 5;
        }      
        static public void showFilesFolder(string folder_path)
        {
            if (File.Exists(folder_path))
            {
                Process.Start("explorer.exe", @"/select, " + folder_path);
            }
            else
            {
                SendMessage.Error(Messages.MSG_18[Language.ViewingLanguage], "Warning");
            }
        }
        static public void ViewPhotoFiles(string FPath,FlowLayoutPanel Panel)
        {
            Panel.Controls.Clear();
            foreach(string Files in Directory.GetFiles(FPath))
            {
                if(PictureFormats.Contains(Path.GetExtension(Files).ToLower()))
                {
                    Viewer v = new Viewer();
                    v.FileName = Files;
                    Panel.Controls.Add(v);
                    Application.DoEvents();
                }
            }
        }
        static public void AyarlariKaydet(string SettingsFileName)
        {
            try
            {
                mainForm main = (mainForm)Application.OpenForms["MainForm"];
                List<MainClass.Ayarlar> _data = new List<MainClass.Ayarlar>();
                _data.Add(new MainClass.Ayarlar()
                {
                    SavePath = main.save_folder.Text,
                    Sound = main.sessiz.Checked.ToString(),
                    R = main.rBar.Value.ToString(),
                    G = main.gBar.Value.ToString(),
                    B = main.gBar.Value.ToString(),
                    BLUR = main.blur.Value.ToString(),
                    HAZE = main.trackBar1.Value.ToString(),
                    SPEED = main.speedbar.Value.ToString(),
                    ZOOM = main.zoombar.Value.ToString(),
                    SoundFilter1 = main.r1.Checked.ToString(),
                    SoundFilter2 = main.r2.Checked.ToString(),
                    SoundFilter3 = main.r3.Checked.ToString(),
                    SoundFilter4 = main.r4.Checked.ToString(),
                    SoundFilter5 = main.r5.Checked.ToString(),
                    SoundFilter6 = main.r6.Checked.ToString(),
                    SoundFilter7 = main.r7.Checked.ToString(),
                    SoundFilter8 = main.r8.Checked.ToString(),
                    SoundFilter9 = main.r9.Checked.ToString(),
                    SoundFilter10 = main.r10.Checked.ToString(),
                    ORJINALSoundFilter = main.r11.Checked.ToString(),
                    VideoFilter1 = main.Giris.Checked.ToString(),
                    VideoFilter2 = main.Camera.Checked.ToString(),
                    VideoFilter3 = main.Gray.Checked.ToString(),
                    VideoFilter4 = main.Ayna.Checked.ToString(),
                    VideoFilter5 = main.BeyazPerde.Checked.ToString(),
                    VideoFilter6 = main.Line.Checked.ToString(),
                    VideoFilter7 = main.EdgeDetect.Checked.ToString(),
                    VideoFilter8 = main.Kusak.Checked.ToString(),
                    VideoFilter9 = main.Ters.Checked.ToString(),
                    VideoFilter10 = main.Kenarlik.Checked.ToString(),
                    VideoStringActive = main.yazi.Checked.ToString(),
                    VideoStringFont = main.fontcombo.Text,
                    VideoStringFontSize = main.boyut.Text,
                    VideoString = main.writerstr.Text,
                    VideoStringCoordinates = main.yazikonum.Text,
                    VideoStringTransparent = main.yazi_arka_plan.Checked.ToString(),
                    VideoStringX = main.yazi_x.Text,
                    VideoStringY = main.yazi_y.Text,
                    VideoMode = main.mode.SelectedIndex.ToString(),
                    VideoPixel = main.c3.Text,
                    BackgroundPixel = main.bgcombo.Text,
                    Frame = main.framescombo.Text,
                    Filter = main.filtercombo.Text,
                    VideoCoordinates = main.bgalign.Text,
                    CoordinatesX = main.txt_bg_x.Text,
                    CoordinatesY = main.txt_bg_y.Text,
                    AutoUpdate = main.otoupdate.Checked.ToString(),
                    FileNameControl = main.vfilename.Checked.ToString(),
                    RenderCompleteProccess = main.rendercomplete.Checked.ToString(),
                    RenderProccess = main.islemler.Text,
                    CutVideo = main.Cut.Checked.ToString(),
                    CutFirst = main.tbas.Text,
                    CutLast = main.tson.Text,
                    y_info = main.yazi_giris_durum.Checked.ToString(),
                    y_giris = main.y_giris.Text,
                    y_cikis = main.y_cikis.Text,
                    LogoName = main.logo_name,
                    LogoAktif = main.logo_stat.Checked.ToString(),
                    LogoKonum = main.LogoKonum.Text,
                    LogoX = main.logo_x.Text,
                    LogoY = main.logo_y.Text,
                    Brightness = main.brig.Value.ToString(),
                    Gamma = main.gamma.Value.ToString(),
                    Kontrast = main.contrast.Value.ToString(),
                    White = main.canlilik.Value.ToString(),
                    ArkaPlanBulaniklik = main.bgblur.Value,
                    BackText = main.backText.Text,
                    sim_height = main.simulator_height,
                    sim_width = main.simulator_width,
                    sim_video_width = main.background_video_width,
                    sim_video_height = main.background_video_height,
                    sim_video_x = main.background_video_x,
                    sim_video_y = main.background_video_y,
                    serit_check = main.serit.Checked.ToString(),
                    serit_opacity = main.serit_opacity.Value.ToString(),
                    str_font = main.fontcombo.Text
                });
                string json = JsonConvert.SerializeObject(_data.ToArray());
                System.IO.File.WriteAllText(SettingsFileName, json);
                SendMessage.Success(Messages.MSG_19[Language.ViewingLanguage], "Successs!");
            }
            catch (Exception Exception)
            {
                SendMessage.Success(Exception.Message, "Error!");
            }
        }
        static public void AyarlariYukle(string SettingsFile,bool msg)
        {
            try
            {
                mainForm main = (mainForm)Application.OpenForms["MainForm"];
                StreamReader sr = new StreamReader(SettingsFile, Encoding.UTF8);
                string line = string.Empty;
                string json = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    json += line.ToString();
                }
                sr.Close();

                JObject j = JObject.Parse(json.Replace("[", "").Replace("]", ""));
                main.save_folder.Text = j["SavePath"].ToString();
                main.mode.SelectedIndex = int.Parse(j["VideoMode"].ToString());
                if (j["Sound"].ToString() == "True") { main.sessiz.Checked = true; } else { main.sessiz.Checked = false; }
                main.rBar.Value = int.Parse(j["R"].ToString());
                main.gBar.Value = int.Parse(j["G"].ToString());
                main.bBar.Value = int.Parse(j["B"].ToString());
                main.blur.Value = int.Parse(j["BLUR"].ToString());
                main.trackBar1.Value = int.Parse(j["HAZE"].ToString());
                main.speedbar.Value = int.Parse(j["SPEED"].ToString());
                main.zoombar.Value = int.Parse(j["ZOOM"].ToString());
                if (j["SoundFilter1"].ToString() == "True") { main.r1.Checked = true; } else { main.r1.Checked = false; }
                if (j["SoundFilter2"].ToString() == "True") { main.r2.Checked = true; } else { main.r2.Checked = false; }
                if (j["SoundFilter3"].ToString() == "True") { main.r3.Checked = true; } else { main.r3.Checked = false; }
                if (j["SoundFilter4"].ToString() == "True") { main.r4.Checked = true; } else { main.r4.Checked = false; }
                if (j["SoundFilter5"].ToString() == "True") { main.r5.Checked = true; } else { main.r5.Checked = false; }
                if (j["SoundFilter6"].ToString() == "True") { main.r6.Checked = true; } else { main.r6.Checked = false; }
                if (j["SoundFilter7"].ToString() == "True") { main.r7.Checked = true; } else { main.r7.Checked = false; }
                if (j["SoundFilter8"].ToString() == "True") { main.r8.Checked = true; } else { main.r8.Checked = false; }
                if (j["SoundFilter9"].ToString() == "True") { main.r9.Checked = true; } else { main.r9.Checked = false; }
                if (j["SoundFilter10"].ToString() == "True") { main.r10.Checked = true; } else { main.r10.Checked = false; }
                if (j["ORJINALSoundFilter"].ToString() == "True") { main.r11.Checked = true; } else { main.r11.Checked = false; }

                if (j["VideoFilter1"].ToString() == "True") { main.Giris.Checked = true; } else { main.Giris.Checked = false; }
                if (j["VideoFilter2"].ToString() == "True") { main.Camera.Checked = true; } else { main.Camera.Checked = false; }
                if (j["VideoFilter3"].ToString() == "True") { main.Gray.Checked = true; } else { main.Gray.Checked = false; }
                if (j["VideoFilter4"].ToString() == "True") { main.Ayna.Checked = true; } else { main.Ayna.Checked = false; }
                if (j["VideoFilter5"].ToString() == "True") { main.BeyazPerde.Checked = true; } else { main.BeyazPerde.Checked = false; }
                if (j["VideoFilter6"].ToString() == "True") { main.Line.Checked = true; } else { main.Line.Checked = false; }
                if (j["VideoFilter7"].ToString() == "True") { main.EdgeDetect.Checked = true; } else { main.EdgeDetect.Checked = false; }
                if (j["VideoFilter8"].ToString() == "True") { main.Kusak.Checked = true; } else { main.Kusak.Checked = false; }
                if (j["VideoFilter9"].ToString() == "True") { main.Ters.Checked = true; } else { main.Ters.Checked = false; }
                if (j["VideoFilter10"].ToString() == "True") { main.Kenarlik.Checked = true; } else { main.Kenarlik.Checked = false; }

                if (j["VideoStringActive"].ToString() == "True") { main.yazi.Checked = true; } else { main.yazi.Checked = false; }
                main.fontcombo.Text = j["VideoStringFont"].ToString();
                main.boyut.Text = j["VideoStringFontSize"].ToString();
                main.writerstr.Text = j["VideoString"].ToString();
                main.yazikonum.Text = j["VideoStringCoordinates"].ToString();
                if (j["VideoStringTransparent"].ToString() == "True") { main.yazi_arka_plan.Checked = true; } else { main.yazi_arka_plan.Checked = false; }
                main.yazi_x.Text = j["VideoStringX"].ToString();
                main.yazi_y.Text = j["VideoStringY"].ToString();
                main.c3.Text = j["VideoPixel"].ToString();
                if (main.mode.SelectedIndex == 0)
                {
                    Controllers.getFiles(main.framescombo, Variables.FRAMES);
                }
                else
                {
                    Controllers.getFiles(main.framescombo, Variables.BACKGROUND);
                }
                Controllers.getFiles(main.filtercombo, Variables.FILTER);
                main.bgcombo.Text = j["BackgroundPixel"].ToString();
                main.framescombo.Text = j["Frame"].ToString();
                main.filtercombo.Text = j["Filter"].ToString();
                main.bgalign.Text = j["VideoCoordinates"].ToString();
                main.txt_bg_x.Text = j["CoordinatesX"].ToString();
                main.txt_bg_y.Text = j["CoordinatesX"].ToString();
                if (j["AutoUpdate"].ToString() == "True") { main.otoupdate.Checked = true; } else { main.otoupdate.Checked = false; }
                if (j["FileNameControl"].ToString() == "True") { main.vfilename.Checked = true; } else { main.vfilename.Checked = false; }
                if (j["RenderCompleteProccess"].ToString() == "True") { main.rendercomplete.Checked = true; } else { main.rendercomplete.Checked = false; }
                main.islemler.Text = j["RenderProccess"].ToString();
                if (j["CutVideo"].ToString() == "True") { main.Cut.Checked = true; } else { main.Cut.Checked = false; }
                main.tbas.Text = j["CutFirst"].ToString();
                main.tson.Text = j["CutLast"].ToString();
                if (j["y_info"].ToString() == "True") { main.yazi_giris_durum.Checked = true; } else { main.yazi_giris_durum.Checked = false; }
                main.y_giris.Text = j["y_giris"].ToString();
                main.y_cikis.Text = j["y_cikis"].ToString();
                main.logo_name = j["LogoName"].ToString();
                if (File.Exists(main.logo_name)) { main.WaterMarks.ImageLocation = main.logo_name; }
                if (j["LogoAktif"].ToString() == "True") { main.logo_stat.Checked = true; } else { main.logo_stat.Checked = false; }
                main.LogoKonum.Text = j["LogoKonum"].ToString();
                main.logo_x.Text = j["LogoX"].ToString();
                main.logo_y.Text = j["LogoY"].ToString();
                main.canlilik.Value = int.Parse(j["White"].ToString());
                main.contrast.Value = int.Parse(j["Kontrast"].ToString());
                main.brig.Value = int.Parse(j["Brightness"].ToString());
                main.gamma.Value = int.Parse(j["Gamma"].ToString());
                main.bgblur.Value = int.Parse(j["ArkaPlanBulaniklik"].ToString());
                if (msg) { SendMessage.Success(Messages.MSG_20[Language.ViewingLanguage], "Success!"); }
                main.backText.Text = j["BackText"].ToString();
                main.simulator_width = j["sim_width"].ToString();
                main.simulator_height = j["sim_height"].ToString();
                main.background_video_width = j["sim_video_width"].ToString();
                main.background_video_height = j["sim_video_height"].ToString();
                main.background_video_x = j["sim_video_x"].ToString();
                main.background_video_y = j["sim_video_y"].ToString();

                sim_video = string.Format("{0}:{1}", main.simulator_width, main.simulator_height);
                sim_background = string.Format("{0}:{1}", main.background_video_width, main.background_video_height);
                main.txt_bg_x.Text = main.background_video_x;
                main.txt_bg_y.Text = main.background_video_y;

                if (j["serit_check"].ToString() == "True") { main.serit.Checked = true; } else { main.serit.Checked = false; }
                main.serit_opacity.Value = int.Parse(j["serit_opacity"].ToString());
                main.fontcombo.Items.Clear();
                string font_extansion = "*.otf,*.ttf";
                foreach (string font_file in Directory.GetFiles(Variables.FONT, "*.*", SearchOption.AllDirectories).Where(emre => font_extansion.Contains(Path.GetExtension(font_extansion))))
                {
                    main.fontcombo.Items.Add(Path.GetFileName(font_file));
                }
                main.fontcombo.Text = j["str_font"].ToString();
                
            }
            catch (Exception Exception)
            {
                if (!msg) { SendMessage.Success(Exception.Message, "Error!"); }
                
            }





        }
        static public string BackgroundPixel(string Quality)
        {
            string returnPixel = string.Empty;
            switch(Quality)
            {
                case  "1920p HD":
                    {
                        returnPixel = "1920:1280";
                        break;
                    }
                case "1080p HD":
                    {
                        returnPixel = "1920:1080";
                        break;
                    }
                case "720p HD":
                    {
                        returnPixel = "1280:720";
                        break;
                    }
                case "480p":
                    {
                        returnPixel = "640:480";
                        break;
                    }
                case "360p":
                    {
                        returnPixel = "640:360";
                        break;
                    }
                case "144p":
                    {
                        returnPixel = "256:144";
                        break;
                    }

                case "Simulator":
                    {
                        returnPixel = sim_background;
                        break;
                    }
            }
            return returnPixel;
        }
        static public string VideoPixel(string Quality)
        {
            string returnPixel = string.Empty;
            switch (Quality)
            {
                case "1920p HD":
                    {
                        returnPixel = "1920:1280";
                        break;
                    }
                case "1080p HD":
                    {
                        returnPixel = "1920:1080";
                        break;
                    }
                case "720p HD":
                    {
                        returnPixel = "1280:720";
                        break;
                    }
                case "480p":
                    {
                        returnPixel = "640:480";
                        break;
                    }
                case "360p":
                    {
                        returnPixel = "640:360";
                        break;
                    }
                case "144p":
                    {
                        returnPixel = "256:144";
                        break;
                    }

                case "Simulator":
                    {
                        returnPixel = sim_video;
                        break;
                    }
            }
            return returnPixel;
        }
    }
}
