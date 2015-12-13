using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartRender.MainClass;
using SmartRender.Render;
using System.IO;
using System.Threading;
using System.Diagnostics;
using SmartRender.Control;
using SmartRender.Server;
namespace SmartRender
{
    public partial class mainForm : Form
    {
        #region Variables
        double process_times = 0;
        public double r = 1.0;
        public double g = 1.0;
        public double b = 1.0;
        public double speed = 1.0;
        public int bulanik = 0;
        public int pus = 0;
        public bool loginxyz = true;
        bool render = false;
        string bg_x = string.Empty, bg_y = string.Empty;
        OpenFileDialog ofd = new OpenFileDialog { Multiselect = true };
        public string logo_name = string.Empty;
        string mark_x = "0";
        string mark_y = "0";
        int _index = 0;
        public int[] logo_size = new int[] {100,100 };
        public string simulator_width;
        public string simulator_height;
        public string background_video_width;
        public string background_video_height;
        public string background_video_x;
        public string background_video_y;
        #endregion
        #region Function
        bool selected()
        {
            try
            {
                string s = WorkList.FocusedItem.Text;
                return true;
            }
            catch
            {
                SendMessage.Success(Messages.MSG_4[Language.ViewingLanguage], "Warning");
                return false;
            }
        }
        #endregion
        public mainForm()
        {
            InitializeComponent();
            #region Events
            txtGroupName.KeyDown += new KeyEventHandler(Actions.GroupActions.KeyDown);
            WorkList.MouseDown += new MouseEventHandler(Actions.GroupActions.MouseDown);
            txtGroupName.Click += new EventHandler(Actions.GroupActions.txtClear);
            Resize += new EventHandler(Actions.FormActions.Resize);
            fontcombo.Click += new EventHandler(Actions.FormActions.Font_Click);
            framescombo.Click += new EventHandler(Actions.FormActions.FramesCombo_Click);
            filtercombo.Click += new EventHandler(Actions.FormActions.FilterCombo_Click);
            rBar.ValueChanged += new EventHandler(Actions.FormActions.RBAR);
            gBar.ValueChanged += new EventHandler(Actions.FormActions.GBAR);
            bBar.ValueChanged += new EventHandler(Actions.FormActions.BBAR);
            blur.ValueChanged += new EventHandler(Actions.FormActions.BLUR);
            zoombar.ValueChanged += new EventHandler(Actions.FormActions.ZBAR);
            speedbar.ValueChanged += new EventHandler(Actions.FormActions.SPEEDBAR);
            trackBar1.ValueChanged += new EventHandler(Actions.FormActions.trackBar1_Scroll);
            mode.SelectedIndexChanged += new EventHandler(Actions.FormActions.Mode_SelectedIndexChanged);
            #endregion
            CheckForIllegalCrossThreadCalls = false;
            Controllers.DirectoryControllers(new string[] { "References", "Filter", "Frame", "Background", "SmallPicture", "Font","Ayarlar","Watermark" });
            output_ext.Items.Add("Orjinal");
            foreach (string format in Extansions.desteklenen)
            {
                Extansions.extension.Add(format, Extansions.count++);
                output_ext.Items.Add(format);
            }
            output_ext.SelectedIndex = 0;
            showFilter.Click(new EventHandler(showFilter_Click));
            showFrame.Click(new EventHandler(showFrame_Click));
            showBackground.Click(new EventHandler(showBackground_Click));
            KonumDegistir.Click(new EventHandler(Actions.FormActions.Konum_Click));
            showSimulator.Click(new EventHandler(Simulator_Click));
            LogonSimulator.Click(new EventHandler(LogonSim));
            btnReset.Click(new EventHandler(BtnRes));
            bRate.SelectedIndex = 0;
            backLoc.SelectedIndex = 6;
            backSize.SelectedIndex = 15;
        }
        #region Filter,Frame,Background,Simulator Button
        private void Simulator_Click(object sender, EventArgs e)
        {
            if (File.Exists(string.Format("{0}/{1}", Variables.BACKGROUND, framescombo.Text)))
            {
                Simulator simula = new Simulator();
                switch (bgcombo.SelectedIndex)
                {
                    case 0: //1920
                        {
                            simula.Size = new Size(1920, 1280);
                            break;
                        }
                    case 1: //1080
                        {
                            simula.Size = new Size(1280, 720);
                            break;
                        }
                    case 2: //720
                        {
                            simula.Size = new Size(1080, 720);
                            break;
                        }
                    case 3: //480
                        {
                            simula.Size = new Size(640, 480);
                            break;
                        }
                    case 4:
                        {
                            simula.p1.Width = int.Parse(simulator_width);
                            simula.p1.Height = int.Parse(simulator_height);
                            simula.Width = int.Parse(background_video_width);
                            simula.Height = int.Parse(background_video_height);
                            simula.p1.Location = new Point(int.Parse(txt_bg_x.Text), int.Parse(txt_bg_y.Text));
                            break;
                        }
                }
                simula.Background = true;
                simula.IMG = string.Format("{0}/{1}", Variables.BACKGROUND, framescombo.Text);
                simula.Show();
            }
            else
            {
                SendMessage.Success(Messages.MSG_1[Language.ViewingLanguage], "Warning");
            }
        }
        private void showFilter_Click(object sender, EventArgs e)
        {
            selectView.SelectedIndex = 2;
            Controllers.ViewPhotoFiles(Variables.FILTER, ViewPanel);            
        }
        private void showFrame_Click(object sender, EventArgs e)
        {
            selectView.SelectedIndex = 1;
            Controllers.ViewPhotoFiles(Variables.FRAMES, ViewPanel);            
        }
        private void showBackground_Click(object sender, EventArgs e)
        {
            selectView.SelectedIndex = 0;
            Controllers.ViewPhotoFiles(Variables.BACKGROUND, ViewPanel);            
        }
        #endregion
        #region DragDrop
        private void WorkList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void WorkList_DragDrop(object sender, DragEventArgs e)
        {
            String[] Files = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in Files)
            {
                Video._addF(file, WorkList);
            }
        }
        #endregion
        #region  Arka Plan Üzeri Video ve WaterMark Konumu
        void WaterMark_Konum()
        {
            switch (LogoKonum.SelectedIndex)
            {
                case 0: // Tam Ortaya
                    {
                        mark_x = "(main_w-overlay_w)/2";
                        mark_y = "(main_h-overlay_h)/2";
                        break;
                    }
                case 1: // Sol Üst Köşe
                    {
                        mark_x = "10";
                        mark_y = mark_x;
                        break;
                    }
                case 2: //Sol Üst Köşe
                    {
                        mark_x = "10";
                        mark_y = "(main_h-overlay_h)-10";
                        break;
                    }
                case 3: //Sağ Alt Köşe
                    {
                        mark_x = "(main_w-overlay_w)-10";
                        mark_y = "10";
                        break;
                    }
                case 4: //Sağ Üst Köşe
                    {
                        mark_x = "(main_w-overlay_w)-10";
                        mark_y = "(main_h-overlay_h)-10";
                        break;
                    }
                case 5: //Manuel
                    {
                        mark_x = logo_x.Text;
                        mark_y = logo_y.Text;
                        break;
                    }
                case 6: // Orta Alt
                    {
                        mark_x = "(main_w-overlay_w)/2";
                        mark_y = "main_h-overlay_h";
                        break;
                    }
                case 7: // Orta Üst
                    {
                        mark_x = "(main_w-overlay_w)/2";
                        mark_y = "0";
                        break;
                    }
                case 8: // Sağ Orta
                    {
                        mark_x = "(main_w-overlay_w)";
                        mark_y = "(main_h-overlay_h)/2";
                        break;
                    }
                case 9: // Sol Orta
                    {
                        mark_x = "0";
                        mark_y = "(main_h-overlay_h)/2";
                        break;
                    }
            }
        }
        void bg_video_koordinat()
        {
            switch (bgalign.SelectedIndex)
            {
                case 0: // Tam Ortaya
                    {
                        bg_x = "(main_w-overlay_w)/2";
                        bg_y = "(main_h-overlay_h)/2";        
                        break;
                    }
                case 1: // Sol Üst Köşe
                    {
                        bg_x = "10";
                        bg_y = bg_x;
                        break;
                    }
                case 2: //Sol Üst Köşe
                    {
                        bg_x = "10";
                        bg_y = "(main_h-overlay_h)-10";
                        break;
                    }
                case 3: //Sağ Alt Köşe
                    {
                        bg_x = "(main_w-overlay_w)-10";
                        bg_y = "10";
                        break;
                    }
                case 4: //Sağ Üst Köşe
                    {
                        bg_x = "(main_w-overlay_w)-10";
                        bg_y = "(main_h-overlay_h)-10";
                        break;
                    }
                case 5: //Manuel
                    {
                        bg_x = txt_bg_x.Text;
                        bg_y = txt_bg_y.Text;
                        break;
                    }
                case 6: // Orta Alt
                    {
                        bg_x = "(main_w-overlay_w)/2";
                        bg_y = "main_h-overlay_h";
                        break;
                    }
                case 7: // Orta Üst
                    {
                        bg_x = "(main_w-overlay_w)/2";
                        bg_y = "0";
                        break;
                    }
                case 8: // Sağ Orta
                    {
                        bg_x = "(main_w-overlay_w)";
                        bg_y = "(main_h-overlay_h)/2";
                        break;
                    }
                case 9: // Sol Orta
                    {
                        bg_x = "0";
                        bg_y = "(main_h-overlay_h)/2";
                        break;
                    }
            }
        }
        #endregion        
        #region Efektler
        public string FFMPEG_CODE()
        {
            string CODE = string.Empty;
            if (trackBar1.Value == 0)
            {
                CODE = string.Format("setpts=PTS/{0},crop=iw/{1}:ih/{1},scale={2},boxblur={3},eq={4}:0.{5}:{6}:{7}:{8}:{9}:{10}{11}",
                    txtspeed.Text, txtzoom.Text, Controllers.VideoPixel(c3.Text), bulanik, gamma.Value, contrast.Value, brig.Value, canlilik.Value, rBar.Value, gBar.Value, bBar.Value, Effekt.Load_Effects(EF));
            }
            else
            {
                CODE = string.Format("setpts=PTS/{0},crop=iw/{1}:ih/{1},scale={2},boxblur={3},eq={4}:0.{5}:{6}:{7}:{8}:{9}:{10}{11},vignette={12}",
                    txtspeed.Text, txtzoom.Text, Controllers.VideoPixel(c3.Text), bulanik, gamma.Value, contrast.Value, brig.Value, canlilik.Value, rBar.Value, gBar.Value, bBar.Value, Effekt.Load_Effects(EF),pus);
            }
            return CODE;
            
        }
        #endregion
        #region Önizleme, Video Ekleme - Silme
        public string RenderCommand(string video)
        {
            string p2 = string.Empty;
            #region MOD 1
            if (mode.SelectedIndex == 0)
            {
                string filter = string.Format("{0}/{1}", Variables.FILTER, filtercombo.Text);
                string frame = string.Format("{0}/{1}", Variables.FRAMES, framescombo.Text);
                #region Çerçeve & Filitre
                if (File.Exists(filter) && File.Exists(frame))
                {
                    p2 = string.Format("movie={0}/{1},scale={2} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [in]; movie={4}/{5},scale={2} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,{3}",
                        Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), FFMPEG_CODE(), Variables.FRAMES, framescombo.Text
                        );
                }
                #endregion
                #region Filitre
                else if (File.Exists(filter))
                {
                    p2 = string.Format("{3} [in]; movie={0}/{1},scale={2} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2",
                            Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), FFMPEG_CODE()
                            );
                }
                #endregion
                #region Çerçeve
                else if (File.Exists(frame))
                {
                    p2 = string.Format("movie={0}/{1},scale={2} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,{3}",
                            Variables.FRAMES, framescombo.Text, Controllers.VideoPixel(c3.Text), FFMPEG_CODE()
                            );
                }
                #endregion
                #region Normal
                else if (!File.Exists(filter) && !File.Exists(frame))
                {
                    p2 = FFMPEG_CODE();
                }
                #endregion
            }
            #endregion
            else
            #region MOD 2
            {
                string movie_input = video.Substring(2, video.Length - 2).Replace(@"\", "/");
                movie_input = video[0] + @"\\:" + movie_input;
                bg_video_koordinat();

                string filter = string.Format("{0}/{1}", Variables.FILTER, filtercombo.Text);
                #region Filitreli
                if (File.Exists(filter))
                {
                    if (logo_stat.Checked)
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},boxblur={12}{13},scale={0}[a]; movie={2}, {3} [in]; movie={9}/{10},scale={11} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [in]; movie={4},scale={14}:{15} [logo]; [in][logo]overlay={5}:{6} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                   Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), bgblur.Value, Effekt.Background_Text(), logo_size[0], logo_size[1]);

                    }
                    else
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},scale={0},boxblur={12}{13}[a]; movie={2}, {3} [in]; movie={9}/{10},scale={11} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                    Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text),bgblur.Value,Effekt.Background_Text());
                    }
                }
                #endregion
                else
                #region Filitresiz
                {
                    if (logo_stat.Checked)
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},scale={0},boxblur={12}{13}[a]; movie={2}, {3} [in]; movie={4},scale={14}:{15} [logo]; [in][logo]overlay={5}:{6} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                   Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), bgblur.Value, Effekt.Background_Text(), logo_size[0], logo_size[1]);
                    }
                    else
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},scale={0},boxblur={12}{13}[a]; movie={2}, {3} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                    Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text),bgblur.Value,Effekt.Background_Text());
                    }
                }
                #endregion

            }
            #endregion

            
            #region Dspl
            string str = string.Empty;
            if (mode.SelectedIndex == 0)
            {
                #region Sesli
                if (!sessiz.Checked) //Sesli
                {
                    if (logo_stat.Checked)
                    {
                        if (r11.Checked) //Orjinal Ses & Logo Var //TESTQ
                        {
                            str = string.Format(@"-window_title ""Smart Render"" -af ""atempo={2}"" -i ""{0}"" -vf ""{1} [in]; movie={3},scale={6}:{7} [logo]; [in][logo]overlay={4}:{5}""",
                            video, p2, txtspeed.Text, logo_name, mark_x, mark_y,logo_size[0],logo_size[1]);
                        }
                        else //Ses Filitresi & Logo Var
                        {
                            str = string.Format(@"-window_title ""Smart Render"" -af ""{6},atempo={2}"" -i ""{0}"" -vf ""{1} [in]; movie={3},scale={7}:{8} [logo]; [in][logo]overlay={4}:{5}""",
                            video, p2, txtspeed.Text, logo_name, mark_x, mark_y, Audio.SoundFiliter(soundsF),logo_size[0],logo_size[1]);
                        }
                    }
                    else
                    {
                        if (r11.Checked) //Orjinal Ses - Logo Yok
                        {
                            str = string.Format(@"-window_title ""Smart Render"" -af ""atempo={2}"" -i ""{0}"" -vf ""{1}""",
                            video, p2, txtspeed.Text);
                        }
                        else // Ses Filitresi Var - Logo Yok
                        {
                            str = string.Format(@"-window_title ""Smart Render"" -af ""{3},atempo={2}"" -i ""{0}"" -vf ""{1}""",
                            video, p2, txtspeed.Text, Audio.SoundFiliter(soundsF));
                        }
                    }
                }
                #endregion
                else
                #region Sessiz
                {
                    if (logo_stat.Checked)
                    {
                        str = string.Format(@"-window_title SmartRender -an -i ""{0}"" -vf ""{1} [in]; movie={3} [logo]; [in][logo]overlay={4}:{5}""",
                        video, p2, txtspeed.Text, logo_name, mark_x, mark_y);
                    }
                    else
                    {
                        str = string.Format(@"-window_title SmartRender -an -i ""{0}"" -vf ""{1}""",
                        video, p2, txtspeed.Text);
                    }
                }
                #endregion
            }
            else
            {
                if (!sessiz.Checked)
                {
                    if (r11.Checked)
                    {
                        str = string.Format(@"-window_title SmartRender -af ""atempo={2}"" -i ""{0}"" -vf ""{1}""",
                            video, p2, txtspeed.Text);
                    }
                    else
                    {
                        str = string.Format(@"-window_title SmartRender -af ""{2},atempo={3}"" -i ""{0}"" -vf ""{1}""",
                            video, p2, Audio.SoundFiliter(soundsF), txtspeed.Text);
                    }
                }
                else
                {
                    str = string.Format(@"-window_title SmartRender -an -i ""{0}"" -vf ""{1}""",
                        video, p2);
                }
            }
            #endregion
            return str;

        }

        public string StrRender(string video)
        {
            string p2 = string.Empty;
            #region MOD 1
            if (mode.SelectedIndex == 0)
            {
                string filter = string.Format("{0}/{1}", Variables.FILTER, filtercombo.Text);
                string frame = string.Format("{0}/{1}", Variables.FRAMES, framescombo.Text);
                #region Çerçeve & Filitre
                if (File.Exists(filter) && File.Exists(frame))
                {

                   
                    /*p2 = string.Format(@"movie=Filter/{4},scale=iw:ih[a]; movie=Frame/{5},scale={2} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,{13}[c]; [c][b] overlay=0:0",
                                c2.Text, c2.Text, Controllers.VideoPixel(c3.Text), video, filtercombo.Text, framescombo.Text, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, FFMPEG_CODE());
                  */
                    p2 = string.Format(@"movie=Filter/{4},scale={2}[a]; movie=Frame/{5},scale={2} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [c]; [c][b] overlay=0:0,{13}",
                              c2.Text, c2.Text, Controllers.VideoPixel(c3.Text), video, filtercombo.Text, framescombo.Text, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, FFMPEG_CODE());
                }
                #endregion
                #region Filitre
                else if (File.Exists(filter))
                {
                    p2 = string.Format(@"{14} [in]; movie={1}/{2},scale={3} [watermark]; [in][watermark] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2",
                               video, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, logo_name, mark_x, mark_y, FFMPEG_CODE());
                }
                #endregion
                #region Çerçeve
                else if (File.Exists(frame))
                {
                    p2 = string.Format(@"movie={1}/{2},scale={3} [watermark]; [in][watermark] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,{14}",
                              video, Variables.FRAMES, framescombo.Text, Controllers.VideoPixel(c3.Text), Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, logo_name, mark_x, mark_y, FFMPEG_CODE());

                }
                #endregion
                #region Normal
                else if (!File.Exists(filter) && !File.Exists(frame))
                {
                    p2 = FFMPEG_CODE();
                }
                #endregion
            }
            #endregion
            else
            #region MOD 2
            {
                string movie_input = video.Substring(2, video.Length - 2).Replace(@"\", "/");
                movie_input = video[0] + @"\\:" + movie_input;
                bg_video_koordinat();

                string filter = string.Format("{0}/{1}", Variables.FILTER, filtercombo.Text);
                #region Filitreli
                if (File.Exists(filter))
                {
                    if (logo_stat.Checked)
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},scale={0},boxblur={12}{13}[a]; movie={2}, {3} [in]; movie={9}/{10},scale={11} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [in]; movie={4},scale={14}:{15} [logo]; [in][logo]overlay={5}:{6} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                   Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), bgblur.Value, Effekt.Background_Text(), logo_size[0], logo_size[1]);

                    }
                    else
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},scale={0},boxblur={12}{13}[a]; movie={2}, {3} [in]; movie={9}/{10},scale={11} [over]; [in][over]overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                    Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), bgblur.Value, Effekt.Background_Text());
                    }
                }
                #endregion
                else
                #region Filitresiz
                {
                    if (logo_stat.Checked)
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},scale={0},boxblur={12}{13}[a]; movie={2}, {3} [in]; movie={4},scale={14}:{15} [logo]; [in][logo]overlay={5}:{6} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                   Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), bgblur.Value, Effekt.Background_Text(), logo_size[0], logo_size[1]);
                    }
                    else
                    {
                        p2 = string.Format(@"scale={0}[in];movie=Background/{1},scale={0},boxblur={12}{13}[a]; movie={2}, {3} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={7}:{8}",
                                    Controllers.BackgroundPixel(bgcombo.Text), framescombo.Text, movie_input, FFMPEG_CODE(), logo_name, mark_x, mark_y, bg_x, bg_y, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), bgblur.Value, Effekt.Background_Text());
                    }
                }
                #endregion

            }
            #endregion

            string str = string.Empty;
            if (mode.SelectedIndex == 0)
            {
                #region Sesli
                if (!sessiz.Checked) //Sesli
                {
                    if (logo_stat.Checked)
                    {
                        if (r11.Checked) //Orjinal Ses & Logo Var
                        {
                            str = string.Format(@"-i ""{0}"" -af ""atempo={2}"" -vf ""{1} [in]; movie={3},scale={6}:{7} [logo]; [in][logo]overlay={4}:{5} """,
                            video, p2, txtspeed.Text, logo_name, mark_x, mark_y, logo_size[0], logo_size[1]);
                        }
                        else //Ses Filitresi & Logo Var
                        {
                            str = string.Format(@"-i ""{0}"" -af ""{6},atempo={2}"" -vf ""{1} [in]; movie={3},scale={7}:{8} [logo]; [in][logo]overlay={4}:{5}""",
                            video, p2, txtspeed.Text, logo_name, mark_x, mark_y, Audio.SoundFiliter(soundsF), logo_size[0], logo_size[1]);
                        }
                    }
                    else
                    {
                        if (r11.Checked) //Orjinal Ses - Logo Yok
                        {
                            str = string.Format(@"-i ""{0}"" -af ""atempo={2}"" -vf ""{1}""",
                            video, p2, txtspeed.Text);
                        }
                        else // Ses Filitresi Var - Logo Yok
                        {
                            str = string.Format(@"-i ""{0}"" -af ""{3},atempo={2}"" -vf ""{1}""",
                            video, p2, txtspeed.Text, Audio.SoundFiliter(soundsF));
                        }
                    }
                }
                #endregion
                else
                #region Sessiz
                {
                    if (logo_stat.Checked)
                    {
                        str = string.Format(@"-i ""{0}"" -an -vf ""{1} [in]; movie={3} [logo]; [in][logo]overlay={4}:{5}""",
                        video, p2, txtspeed.Text, logo_name, mark_x, mark_y);
                    }
                    else
                    {
                        str = string.Format(@"-i -an ""{0}"" -vf ""{1}""",
                        video, p2, txtspeed.Text);
                    }
                }
                #endregion
            }
            else
            {
                if (!sessiz.Checked)
                {
                    if (r11.Checked)
                    {
                        str = string.Format(@"-i ""{0}"" -af ""atempo={2}"" -vf ""{1}""",
                            video, p2, txtspeed.Text);
                    }
                    else
                    {
                        str = string.Format(@"-i ""{0}"" -af ""{2},atempo={3}"" -vf ""{1}""",
                            video, p2, Audio.SoundFiliter(soundsF), txtspeed.Text);
                    }
                }
                else
                {
                    str = string.Format(@"-i ""{0}"" -an -vf ""{1}""",
                        video, p2);
                }
            }

            return str;

        }

        public void Display()
        {

            if (File.Exists(Variables.FFPLAY))
            {
                FileInfo f = new FileInfo(Variables.FFPLAY);
                if (f.Length.ToString() == "30970368")
                {
                    if (loginxyz)
                    {
                        if (selected())
                        {                          
                            Video.Onizle(RenderCommand(WorkList.FocusedItem.Text));
                        }
                    }
                    else
                    {
                        SendMessage.Success(Messages.MSG_5[Language.ViewingLanguage], "Warning");
                    }
                }
                else
                {
                    SendMessage.Success(Messages.MSG_6[Language.ViewingLanguage], "Warning");
                }
            }
            else
            {
                SendMessage.Success(Messages.MSG_6[Language.ViewingLanguage], "Warning");
            }
        }
        public void VideoEkle()
        {
            if (File.Exists(Variables.FFMPEG))
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        Video._addF(file, WorkList);
                    }
                }
            }
            else
            {
                SendMessage.Success(Messages.MSG_6[Language.ViewingLanguage], "Warning");
            }
        }
        public void VideoSil()
        {
            foreach (ListViewItem silinecek in WorkList.SelectedItems)
            {
                WorkList.Items.Remove(silinecek);
            }
        }
        
        #endregion
        #region Render Yap
        Thread th;
        public void StartRender()
        {
            if (Directory.Exists(save_folder.Text))
            {
                    if (File.Exists(Variables.FFMPEG))
                    {
                        FileInfo f = new FileInfo(Variables.FFMPEG);
                        if (f.Length.ToString() == "31064064")
                        {
                            if (loginxyz)
                            {
                                if (WorkList.Items.Count > 0)
                                {
                                    if (!render)
                                    {
                                        SendMessage.Success(Messages.MSG_2[Language.ViewingLanguage], "Information");
                                        _index = 0;
                                        th = new Thread(_basla);
                                        th.Start();
                                        timer1.Start();
                                        render = true;
                                    }
                                    else
                                    {
                                        SendMessage.Success(Messages.MSG_3[Language.ViewingLanguage], "Warning");
                                    }
                                }
                                else
                                {
                                    SendMessage.Success(Messages.MSG_4[Language.ViewingLanguage], "Warning");
                                }
                            }
                            else
                            {
                                SendMessage.Success(Messages.MSG_5[Language.ViewingLanguage], "Warning");
                            }
                        }
                        else
                        {
                            SendMessage.Success(Messages.MSG_6[Language.ViewingLanguage], "Error");
                        }
                    }
                    else
                    {
                        SendMessage.Success(Messages.MSG_6[Language.ViewingLanguage], "Error");
                    }              
            }
            else
            {
                SendMessage.Success(Messages.MSG_7[Language.ViewingLanguage], "Folder Was Not Found");
            }
        }

        public void Apply_Completing(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                if (_index != WorkList.Items.Count - 1)
                {
                    WorkList.Items[_index].SubItems[4].Text = Messages.MSG_12[Language.ViewingLanguage];
                    _index++;
                    process_times = 0;
                    th = new Thread(_basla);
                    th.Start();
                }
                else
                {
                    btn_start.Text = "BAŞLAT";
                    btn_start.ImageIndex = 12;
                    WorkList.Items[_index].SubItems[4].Text = Messages.MSG_12[Language.ViewingLanguage];
                    WorkList.Items[_index].SubItems[5].Text = TimeSpan.FromSeconds(process_times).ToString();
                    render = false;
                    timer1.Stop();
                    process_times = 0;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.alarm);
                    if (rendercomplete.Checked)
                    {
                        switch (islemler.SelectedIndex)
                        {
                            case 0: // Bilgisayarı Kapat
                                {
                                    System.Diagnostics.Process.Start("shutdown", "-f -s");
                                    break;
                                }
                            case 1: // Mail Gönder
                                {
                                    break;
                                }
                            case 2: // Alarm Çal
                                {
                                    player.PlayLooping();
                                    SendMessage.Success(Messages.MSG_14[Language.ViewingLanguage], "Successfully");
                                    player.Stop();
                                    break;
                                }
                        }

                    }
                    else
                    {
                        SendMessage.Success(Messages.MSG_14[Language.ViewingLanguage], "Successfully");
                    }
                }
            });

        }

        public void _basla()
        {
            try
            {
                string RenderProfili = string.Format("{0}/{1}.json",Variables.AYARLAR,WorkList.Items[_index].Group.ToString());
                if (File.Exists(RenderProfili))
                {
                    Controllers.AyarlariYukle(RenderProfili, false);
                }
            }
            catch { }
            string input = WorkList.Items[_index].Text;
            string movie_input = input.Substring(2, input.Length - 2).Replace(@"\", "/");
            movie_input = input[0] + @"\\:" + movie_input;
            string output = save_folder.Text;
            bg_video_koordinat();

            #region ESKI
            /*
            if (mode.SelectedIndex == 0)
            {               
                    #region Çerçeve & Filitre & Puslu
                    #region Logolu
                    if (logo_stat.Checked)
                    {
                        uygulanacak = string.Format(@"""crop=iw/{12}:ih/{12} [in]; movie=Filter/{4},scale={0}[a]; movie=Frame/{5},scale={2} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,{16}[c]; [c][b] overlay=0:0 [in]; movie={13} [logo]; [in][logo]overlay={14}:{15}""",
                            c2.Text, c2.Text, Controllers.VideoPixel(c3.Text), input, filtercombo.Text, framescombo.Text, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, logo_name, mark_x, mark_y,FFMPEG_CODE());
                    }
                    #endregion
                    else
                    #region Logosuz
                    {
                        uygulanacak = string.Format(@"""crop=iw/{12}:ih/{12} [in]; movie=Filter/{4},scale={0}[a]; movie=Frame/{5},scale={2} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,{13}[c]; [c][b] overlay=0:0""",
                            c2.Text, c2.Text, Controllers.VideoPixel(c3.Text), input, filtercombo.Text, framescombo.Text, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text,FFMPEG_CODE());
                    }
                    #endregion
                    #endregion
                    #region Çerçeveli
                    if (!File.Exists(Variables.FILTER + @"\" + filtercombo.Text))
                    {
                        #region Logolu
                        if (logo_stat.Checked)
                       {
                           uygulanacak = string.Format(@"""{14} [in]; movie={1}/{2},scale={3} [watermark]; [in][watermark] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [in]; movie={11} [logo]; [in][logo]overlay={12}:{13}""",
                               input, Variables.FRAMES, framescombo.Text, Controllers.VideoPixel(c3.Text), Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, logo_name, mark_x, mark_y,FFMPEG_CODE());
                       }
                        #endregion
                        else
                        #region Logosuz
                        {
                           uygulanacak = string.Format(@"""{11} [in]; movie={1}/{2},scale={3} [watermark]; [in][watermark] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2""",
                               input, Variables.FRAMES, framescombo.Text, Controllers.VideoPixel(c3.Text), Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text,FFMPEG_CODE());
                        }
                        #endregion

                    }
                    #endregion
                    #region Filter
                    if (!File.Exists(Variables.FRAMES + @"\" + framescombo.Text))
                    {
                        #region Logolu
                        if (logo_stat.Checked)
                        {
                            uygulanacak = string.Format(@"""{14} [in]; movie={1}/{2},scale={3} [watermark]; [in][watermark] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2 [in]; movie={11} [logo]; [in][logo]overlay={12}:{13}""",
                                input, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, logo_name, mark_x, mark_y,FFMPEG_CODE());
                        }
                        #endregion
                        else
                        #region Logosuz
                        {
                            uygulanacak = string.Format(@"""{11} [in]; movie={1}/{2},scale={3} [watermark]; [in][watermark] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2""",
                                input, Variables.FILTER, filtercombo.Text, Controllers.VideoPixel(c3.Text), Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text,FFMPEG_CODE());
                        }
                        #endregion
                    }
                    #endregion
                    #region Düz Video
                    if (!File.Exists(Variables.FRAMES + @"\" + framescombo.Text) && !File.Exists(Variables.FILTER + @"\" + filtercombo.Text))
                    {
                        #region Logolu
                        if (logo_stat.Checked)
                        {
                            uygulanacak = string.Format(@"""{17} [in]; movie={14} [logo]; [in][logo]overlay={15}:{16}""",
                                input, framescombo.Text, c2.Text, Controllers.VideoPixel(c3.Text), filtercombo.Text, Variables.FILTER, Variables.FRAMES, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text, logo_name, mark_x, mark_y,FFMPEG_CODE());
                        }
                        #endregion
                        else
                        #region Logosuz
                        {
                            uygulanacak = string.Format(@"""{14}""",
                                input, framescombo.Text, c2.Text, Controllers.VideoPixel(c3.Text), filtercombo.Text, Variables.FILTER, Variables.FRAMES, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, txtzoom.Text,FFMPEG_CODE());
                        }
                        #endregion

                    }
                    #endregion                               
            }
            else if (mode.SelectedIndex == 1)
            {
                bg_video_koordinat();//Arka Plan Üzerinde Videonun Konumunu Oluşturan fonksiyon
                
                #region Arka Plan
                
                    #region Logo
                    if (logo_stat.Checked)
                    {
                        uygulanacak = string.Format(@"""scale={0}[in];movie=Background/{5},scale={0}[a]; movie={12},{19} [in]; movie={16} [logo]; [in][logo]overlay={17}:{18} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={14}:{15}""",
                            Controllers.BackgroundPixel(bgcombo.Text), c2.Text, Controllers.VideoPixel(c3.Text), input, filtercombo.Text, framescombo.Text, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, movie_input, txtzoom.Text, bg_x, bg_y, logo_name, mark_x, mark_y,FFMPEG_CODE());
                    }
                    #endregion
                    else
                    #region Logosuz
                    {
                        uygulanacak = string.Format(@"""scale={0}[in];movie=Background/{5},scale={0}[a]; movie={12},{16} [b]; [in][a] overlay=main_w/2-overlay_w/2:main_h/2-overlay_h/2,scale={0}[c]; [c][b] overlay={14}:{15}""",
                            Controllers.BackgroundPixel(bgcombo.Text), c2.Text, Controllers.VideoPixel(c3.Text), input, filtercombo.Text, framescombo.Text, Effekt.Load_Effects(EF), r, g, b, pus, bulanik, movie_input, txtzoom.Text, bg_x, bg_y,FFMPEG_CODE());
                    }
                    
                
                #endregion
                #endregion
            } */
            #endregion

            string suresi = WorkList.Items[_index].SubItems[1].Text;
            ProcessStartInfo s = new ProcessStartInfo
            {
                RedirectStandardError = true,
                UseShellExecute = false,
                LoadUserProfile = true,
                CreateNoWindow = false,
                FileName = Variables.FFMPEG
            };
            s.CreateNoWindow = true;
            Process p = new Process { StartInfo = s };
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(Apply_Completing);
            if (!File.Exists(Variables.FFMPEG))
            { SendMessage.Error(Messages.MSG_15[Language.ViewingLanguage], "Error"); }
            else
            {

               
                string Render_Type = string.Empty;
                switch (RenderMode.SelectedIndex)
                {
                    case 0: { break; } //Orjinal Render
                    case 1: { Render_Type = "-preset slow"; break; }
                    case 2: { Render_Type = "-movflags -faststart"; break; }
                    case 3: { Render_Type = "-preset superfast"; break; }
                    case 4: { Render_Type = "-preset ultrafast"; break; }
                }
                string komut = string.Empty;
                string output_extansion = Path.GetExtension(input);
                if (output_ext.SelectedIndex == 0)
                {
                    output_extansion = Path.GetExtension(input);
                }
                else
                {
                    output_extansion = output_ext.Text;
                }
                
                if(Cut.Checked)
                {
                    //Video Kesme
                    double video_suresi = TimeSpan.Parse(WorkList.Items[_index].SubItems[1].Text).TotalSeconds;
                    double bas = double.Parse(tbas.Text);
                    double son = double.Parse(tson.Text);
                    double dyeni = video_suresi - (bas + son);
                    int yeni = (int)dyeni;


                    if (bRate.SelectedIndex == 0) // Orjinal Bitrate
                    {
                        komut = string.Format(@"-y -ss {4} -t {5} {0} {1} ""{2}/{3}{6}""", StrRender(input), Render_Type, save_folder.Text, Path.GetFileNameWithoutExtension(input), tbas.Text, yeni, output_extansion);
                    }
                    else
                    {
                        komut = string.Format(@"-y -ss {4} -t {5} {0} {1} -b {7} ""{2}/{3}{6}""", StrRender(input), Render_Type, save_folder.Text, Path.GetFileNameWithoutExtension(input), tbas.Text, yeni, output_extansion, bRate.Text);
                    }

                } 
                else
                {
                    if (bRate.SelectedIndex == 0) // Orjinal Bitrate
                    {
                        komut = string.Format(@"-y {0} {1} ""{2}/{3}{4}""", StrRender(input), Render_Type, save_folder.Text, Path.GetFileNameWithoutExtension(input), output_extansion);
                    }
                    else
                    {
                        komut = string.Format(@"-y {0} {1} -b {5} ""{2}/{3}{4}""", StrRender(input), Render_Type, save_folder.Text, Path.GetFileNameWithoutExtension(input), output_extansion, bRate.Text);
                    }
                }                
                //BeginInvoke(new Action(() => Clipboard.SetText(komut)));
                s.Arguments = komut;
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

                                //Console.WriteLine(testReader.ReadLine());
                                int t_index = testReader.ReadLine().IndexOf("time=");
                                string saniye = testReader.ReadLine().Substring(t_index + 5, 8);
                                double seconds = TimeSpan.Parse(saniye).TotalSeconds;
                                double total = TimeSpan.Parse(suresi).TotalSeconds;
                                
                                if (Cut.Checked)
                                {
                                    int bas = int.Parse(tbas.Text);
                                    int son = int.Parse(tson.Text);
                                    int toplam_kesme = bas + son;
                                    if(toplam_kesme > total)
                                    {
                                        Process[] localByName = Process.GetProcessesByName("ffmpeg");
                                        foreach (Process pp in localByName)
                                        {
                                            pp.Kill();
                                        }
                                        SendMessage.Error(Messages.MSG_16[Language.ViewingLanguage], "Error");
                                    }

                                }                                
                                double process = (seconds / total) * 100;
                                Console.WriteLine("%{0}", Math.Round(process, 2));
                                BeginInvoke(new Action(() => WorkList.Items[_index].SubItems[4].Text = string.Format("%{0}", Math.Round(process, 2) * double.Parse(txtspeed.Text.Replace(".", ",")))));
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

        }
        #endregion
        #region Küçük Resim Al
        public void SmallPic()
        {
            if (File.Exists(Variables.FFMPEG))
            {
                FileInfo f = new FileInfo(Variables.FFMPEG);
                if (f.Length.ToString() == "31064064")
                {
                    if (loginxyz)
                    {
                        if (selected())
                        {
                            string video_time = WorkList.FocusedItem.SubItems[1].Text;
                            int total = (int)(TimeSpan.Parse(video_time).TotalSeconds);
                            Video.Kucuk_Resim(WorkList.FocusedItem.Text, "1", total);
                        }
                    }
                    else
                    {
                        SendMessage.Success(Messages.MSG_5[Language.ViewingLanguage], "Error");
                    }
                }
                else
                {
                    SendMessage.Success(Messages.MSG_6[Language.ViewingLanguage], "Error");
                }
            }
            else
            {
                SendMessage.Success(Messages.MSG_6[Language.ViewingLanguage], "Error");
            }
        }
        #endregion
        #region Ayarları Sıfırla
        public void ResetSettings()
        {
            rText.Text = "1";
            gText.Text = "1";
            bText.Text = "1";
            rBar.Value = 1;
            gBar.Value = 1;
            bBar.Value = 1;
            blur.Value = 0;
            trackBar1.Value = 0;
            bulanik = 0;
            pus = 0;
            puss.Text = "0";
            speedbar.Value = 100;
            txtspeed.Text = "1.00";
            txtzoom.Text = "1.0";
            zoombar.Value = 10;
            gamma.Value = 1;
            contrast.Value = 1;
            brig.Value = 1;
            canlilik.Value = 1;
        }
        #endregion
        #region Dosyadan Yükle
        private void addfreym_Click(object sender, EventArgs e)
        {
            OpenFileDialog addFiles = new OpenFileDialog { Multiselect = true };

            if (sender.ToString().Contains("ÇERÇEVE") || sender.ToString().Contains("FRAME"))
            {
                addFiles.Filter = "Çerçeve Dosyaları (*.png)|*.png";
                if (addFiles.ShowDialog() == DialogResult.OK)
                {
                    foreach (string files in addFiles.FileNames)
                    {
                        if (filecut.Checked)
                        {
                            File.Move(files, string.Format("{0}/{1}", Variables.FRAMES, Path.GetFileName(files)));
                        }
                        else
                        {
                            File.Copy(files, string.Format("{0}/{1}", Variables.FRAMES, Path.GetFileName(files)));
                        }
                    }
                    SendMessage.Success(Messages.MSG_8[Language.ViewingLanguage], "Successfully");
                }
            }
            else if (sender.ToString().Contains("ARKA PLAN") || sender.ToString().Contains("BACK"))
            {
                addFiles.Filter = "Arka Plan (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPG Files (*.jpeg)|*.jpeg";
                if (addFiles.ShowDialog() == DialogResult.OK)
                {
                    foreach (string files in addFiles.FileNames)
                    {
                        if (filecut.Checked)
                        {
                            File.Move(files, string.Format("{0}/{1}", Variables.BACKGROUND, Path.GetFileName(files)));
                        }
                        else
                        {
                            File.Copy(files, string.Format("{0}/{1}", Variables.BACKGROUND, Path.GetFileName(files)));
                        }
                    }
                    SendMessage.Success(Messages.MSG_8[Language.ViewingLanguage], "Successfully");
                }
            }
            else if (sender.ToString().Contains("FILITRE") || sender.ToString().Contains("FILITERS"))
            {
                addFiles.Filter = "Filitre (*.png)|*.png";
                if (addFiles.ShowDialog() == DialogResult.OK)
                {
                    foreach (string files in addFiles.FileNames)
                    {
                        if (filecut.Checked)
                        {
                            File.Move(files, string.Format("{0}/{1}", Variables.FILTER, Path.GetFileName(files)));
                        }
                        else
                        {
                            File.Copy(files, string.Format("{0}/{1}", Variables.FILTER, Path.GetFileName(files)));
                        }
                    }
                    SendMessage.Success(Messages.MSG_8[Language.ViewingLanguage], "Successfully");
                }
            }
            else if (sender.ToString().Contains("FONT"))
            {
                addFiles.Filter = "Font Files (*.otf)|*.otf|Font Files Files (*.ttf)|*.ttf";
                if (addFiles.ShowDialog() == DialogResult.OK)
                {
                    foreach (string files in addFiles.FileNames)
                    {
                        if (filecut.Checked)
                        {
                            File.Move(files, string.Format("{0}/{1}", Variables.FONT, Path.GetFileName(files)));
                        }
                        else
                        {
                            File.Copy(files, string.Format("{0}/{1}", Variables.FONT, Path.GetFileName(files)));
                        }
                    }
                    SendMessage.Success(Messages.MSG_8[Language.ViewingLanguage], "Successfully");
                }
            }
        }
        #endregion
        private void BtnRes(object sender, EventArgs e)
        {
            ResetSettings();
        }
        private void btn_display_Click(object sender, EventArgs e)
        {
            Display();
        }
        private void LogonSim(object sender, EventArgs e)
        {
            if (File.Exists(logo_name))
            {
                Simulator simula = new Simulator();
                simula.Background = false;
                simula.IMG = logo_name;

                switch (c3.SelectedIndex)
                {
                    case 0:
                        {
                            simula.Size = new Size(1920, 1280);
                            break;
                        }
                    case 1:
                        {
                            simula.Size = new Size(1920, 1280);
                            break;
                        }
                    case 2:
                        {
                            simula.Size = new Size(1280, 720);
                            break;
                        }
                    case 3:
                        {
                            simula.Size = new Size(640, 480);
                            break;
                        }
                    case 4:
                        {
                            simula.Size = new Size(640, 360);
                            break;
                        }
                    case 5:
                        {
                            simula.Size = new Size(256, 144);
                            break;
                        }
                    case 6:
                        {
                            int index_of = Controllers.sim_video.IndexOf(":");
                            int wi = int.Parse(Controllers.sim_video.Substring(0, index_of));
                            int he = int.Parse(Controllers.sim_video.Substring(index_of + 1, Controllers.sim_video.Length - index_of - 1));
                            simula.Size = new Size(wi, he);
                            break;
                        }
                }
                simula.MaximumSize = simula.Size;
                simula.MinimumSize = simula.Size;
                simula.MaximizeBox = false;
                simula.Show();
            }
            else
            {
                SendMessage.Success(Messages.MSG_9[Language.ViewingLanguage], "Warning");
            }
        }
        private void mainForm_Shown(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.username != string.Empty)
            {                Language.Turkish();
            }
            Controllers.AutoSizeWorkList(WorkList);
            LogoKonum.SelectedIndex = 2;
            bgcombo.SelectedIndex = 1;
            c3.SelectedIndex = 2;
            boyut.SelectedIndex = 9;
            yazikonum.SelectedIndex = 1;
            bgalign.SelectedIndex = 0;
            islemler.SelectedIndex = 2;
            RenderMode.SelectedIndex = 4;
            if(Properties.Settings.Default.Language == Language.Languages.Turkish.ToString())
            {
                Language.Turkish();
                StripLang.Image = LangTR.Image;
                StripLang.Text = Language.ViewLanguage;
            }
            else
            {
                Language.English();
                StripLang.Image = LangENG.Image;
                StripLang.Text = Language.ViewLanguage;
            }
            defaultjson.Text = Properties.Settings.Default.defaultJson.ToString();
            if (File.Exists(defaultjson.Text))
            { Controllers.AyarlariYukle(defaultjson.Text, true); }
        }
        Thread sunucu;
        private void Komut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Komut.Text.ToLower() == "server::start") { sunucu = new Thread(Server.Server.Open); sunucu.Start(); }
                else
                {
                    if (!Komut.Text.Contains(":"))
                    {
                        dConsole.Text += string.Format("\n{0} : {1}", Messages.MSG_10[Language.ViewingLanguage], Komut.Text);
                    }
                    else
                    {
                        int ayir = Komut.Text.IndexOf(":");
                        string type_ = Komut.Text.Substring(0, ayir);
                        switch (type_.ToLower())
                        {
                            #region Store Download Console
                            case "download":
                                {
                                    if (!Komut.Text.Replace("download:", "").Contains("."))
                                    {
                                        dConsole.Text += string.Format("\n{0} : {1}", Messages.MSG_10[Language.ViewingLanguage], Komut.Text);
                                    }
                                    else if (Komut.Text.Replace("download:", "").Length < 3)
                                    {
                                        dConsole.Text += string.Format("\n{0} : {1}", Messages.MSG_10[Language.ViewingLanguage], Komut.Text);
                                    }
                                    else
                                    {
                                        //if (CheckFiles.CheckIfFileExistsOnServer(string.Format("{0}", Komut.Text.Replace("download:", ""))))
                                        string str = CheckFiles.Check(Komut.Text.Replace("download:", ""));
                                        if (str != "error")
                                        {
                                            string downloads = Komut.Text.Replace("download:", "");
                                            CheckFiles.xDownloadFiles(downloads, str);
                                        }
                                        else
                                        {
                                            dConsole.Text += string.Format("\n{0} : {1}", Messages.MSG_10[Language.ViewingLanguage], Komut.Text);
                                        }
                                    }
                                    break;
                                }
                            #endregion
                            default:
                                {
                                    dConsole.Text += string.Format("\n{0} : {1}", Messages.MSG_10[Language.ViewingLanguage], Komut.Text);
                                    break;
                                }
                        }
                    }
                }
                if (Komut.Text.ToLower() == "clear") { dConsole.Clear(); }
                Komut.Clear();
            }
        }
        private void dConsole_TextChanged(object sender, EventArgs e)
        {
            dConsole.SelectionStart = dConsole.Text.Length;
            dConsole.ScrollToCaret();
        }
        private void Komut_Click(object sender, EventArgs e)
        {
            Komut.Clear();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            VideoEkle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VideoSil();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            StartRender();
        }

        private void btn_thumbnail_Click(object sender, EventArgs e)
        {
            SmallPic();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer Mode");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void ViewFolder_Click(object sender, EventArgs e)
        {
            if (selected())
            {
                Controllers.showFilesFolder(WorkList.FocusedItem.Text);
            }
        }

        private void buy_Click(object sender, EventArgs e)
        {
            Process.Start("http://smart-render.com/orderbuy.php");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            process_times++;
            WorkList.Items[_index].SubItems[5].Text = TimeSpan.FromSeconds(process_times).ToString();
        }

        private void savesettings_Click(object sender, EventArgs e)
        {
            SaveSettings saveset = new SaveSettings();
            saveset.Show();
        }

        private void tbas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void filter_delete_Click(object sender, EventArgs e)
        {
            filtercombo.Text = "";
        }

        private void frame_delete_Click(object sender, EventArgs e)
        {
            framescombo.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int okey = 0;
            for (int i = 0; i <= WorkList.Items.Count - 1; i++)
            {
                if (WorkList.Items[i].SubItems[4].Text == "Tamam")
                {
                    okey++;
                }
            }
            string total = WorkList.Items.Count.ToString();           
            string bekleyen  = work_info.Text = (WorkList.Items.Count - okey).ToString();
            if (Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                work_info.Text = string.Format("Toplam {0} Video Eklendi, {1} Tamamlandı, {2} Tanesi Beklemede ", total, okey, bekleyen);
            }
            else
            {
                work_info.Text = string.Format("Total {0} Videos Added, {1} Completed, {2} Waiting ", total, okey, bekleyen);
            }
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Messages.MSG_11[Language.ViewingLanguage], "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                WorkList.Items.Clear();
            }
        }

        private void yazi_CheckedChanged(object sender, EventArgs e)
        {
            writer.Checked = yazi.Checked;
        }

        private void tabPage2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void tabPage2_DragDrop(object sender, DragEventArgs e)
        {
            String[] Logo = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string str in Logo)
            {
                if (Controllers.PictureFormats.Contains(Path.GetExtension(str).ToLower()))
                {                    
                    string yeni =string.Format("{0}/{1}", Variables.LOGO, Path.GetFileName(str));
                    if (str != Path.GetFullPath(yeni))
                    {
                        if (File.Exists(yeni))
                        { File.Delete(yeni); }
                        File.Copy(str, yeni);
                        WaterMarks.ImageLocation = yeni;
                        logo_name = yeni;
                    }
                    else
                    {
                        WaterMarks.ImageLocation = yeni;
                        logo_name = yeni;
                    }
                }
            }
        }

        private void logo_x_TextChanged(object sender, EventArgs e)
        {
            mark_x = logo_x.Text;
        }

        private void logo_y_TextChanged(object sender, EventArgs e)
        {
            mark_y = logo_y.Text;
        }

        private void LogoKonum_SelectedIndexChanged(object sender, EventArgs e)
        {
            WaterMark_Konum();
        }

        private void loadsettings_Click(object sender, EventArgs e)
        {
            LoadSet opens = new LoadSet();
            opens.Show();
        }

        private void gamma_ValueChanged(object sender, EventArgs e)
        {
            gam.Text = gamma.Value.ToString();
        }

        private void contrast_ValueChanged(object sender, EventArgs e)
        {
            bri.Text = contrast.Value.ToString();
        }

        private void brig_ValueChanged(object sender, EventArgs e)
        {
            kont.Text = brig.Value.ToString();
        }

        private void canlilik_ValueChanged(object sender, EventArgs e)
        {
            wht.Text = canlilik.Value.ToString();
        }

        private void guncellemeler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://smart-render.com/guncelleme.php");
        }

        private void yazi_arka_renk_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                yazi_arka_renk.BackColor = cd.Color;

            }
        }

        private void yazi_renk_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                yazi_renk.BackColor = cd.Color;
            }
        }

        private void Komut_Click_1(object sender, EventArgs e)
        {
            Komut.Clear();
        }

        private void e1_ValueChanged(object sender, EventArgs e)
        {
            ec1.Text = string.Format("0.{0}",e1.Value);
        }

        private void ee1_Scroll(object sender, EventArgs e)
        {
            ec2.Text = string.Format("0.{0}",ee1.Value);
        }

        private void e2_Scroll(object sender, EventArgs e)
        {
            ec3.Text = string.Format("{0}",e2.Value);
        }

        private void ee2_Scroll(object sender, EventArgs e)
        {
            ec4.Text = string.Format("0.{0}", ee2.Value);
        }

        private void btnCollectivePicture_Click(object sender, EventArgs e)
        {
            try
            {
                CollectivePicture Collec = (CollectivePicture)Application.OpenForms["CollectivePicture"];
                Collec.Focus();
            }
            catch
            {
                CollectivePicture Collec = new CollectivePicture();
                Collec.Show();
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                Actions.FormActions.Capture();
            }
            if (e.KeyCode == Keys.Tab && (e.KeyData & Keys.Control) != Keys.None)
            {
                bool forward = (e.KeyData & Keys.Shift) == Keys.None;
                th_read = new Thread(_get);
                th_read.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actions.FormActions.Capture();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            language_item.ShowDropDown();
        }

        private void LangTR_Click(object sender, EventArgs e)
        {
            StripLang.Image = LangTR.Image;
            StripLang.Text = Language.Languages.Turkish.ToString();
            Properties.Settings.Default.Language = Language.Languages.Turkish.ToString();
            Properties.Settings.Default.Save();
            Language.Turkish();
        }

        private void LandENG_Click(object sender, EventArgs e)
        {
            StripLang.Image = LangENG.Image;
            StripLang.Text = Language.Languages.English.ToString();
            Properties.Settings.Default.Language = Language.Languages.English.ToString();
            Properties.Settings.Default.Save();
            Language.English();
        }

        private void backFont_Click(object sender, EventArgs e)
        {
            backFont.Items.Clear();
            string font_extansion = "*.otf,*.ttf";
            foreach (string font_file in Directory.GetFiles(Variables.FONT, "*.*", SearchOption.AllDirectories).Where(emre => font_extansion.Contains(Path.GetExtension(font_extansion))))
            {
                backFont.Items.Add(Path.GetFileName(font_file));
            }
        }

        private void backC1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                backC1.BackColor = cd.Color;
            }
        }

        private void backC2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                backC2.BackColor = cd.Color;
            }
        }

        private void Combine_Click(object sender, EventArgs e)
        {
            VideoBirlestir yeniBirlestir = new VideoBirlestir();
            yeniBirlestir.Show();
        }

        private void serit_CheckedChanged(object sender, EventArgs e)
        {
            drawBox.Checked = serit.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = cd.Color;
            }
        }

        private void btn_media_sign_Click(object sender, EventArgs e)
        {
            Media_Sign MS = new Media_Sign();
            MS.Show();
        }
        Thread th_read;
        void _get()
        {
            Invoke((MethodInvoker)delegate
            {
                Opacity = 0;
                TabView TB = new TabView();
                TB.Width = Screen.PrimaryScreen.WorkingArea.Width;
                foreach(TabPage T in WorkTab.TabPages)
                {
                    WorkTab.SelectedTab = T;
                    TabV Tabs = new TabV { Image = Actions.FormActions.CaptureObject(this),Header = T.Text };
                    TB.FW1.Controls.Add(Tabs);
                    Invalidate();
                }
                TB.Show();
            });

        }
    }
}
