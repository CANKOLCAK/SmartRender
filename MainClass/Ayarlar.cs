using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRender.MainClass
{
    class Ayarlar
    {
        public string SavePath { get; set; }
        public string Sound { get; set; }
        #region TrackBars
        public string R { get; set; }
        public string G { get; set; }
        public string B { get; set; }
        public string BLUR { get; set; }
        public string HAZE { get; set; }
        public string SPEED { get; set; }
        public string ZOOM { get; set; }
        #endregion
        #region SoundFilter
        public string SoundFilter1 { get; set; }
        public string SoundFilter2 { get; set; }
        public string SoundFilter3 { get; set; }
        public string SoundFilter4 { get; set; }
        public string SoundFilter5 { get; set; }
        public string SoundFilter6 { get; set; }
        public string SoundFilter7 { get; set; }
        public string SoundFilter8 { get; set; }
        public string SoundFilter9 { get; set; }
        public string SoundFilter10 { get; set; }
        public string ORJINALSoundFilter { get; set; }
        #endregion
        #region VideoFilter
        public string VideoFilter1 { get; set; }
        public string VideoFilter2 { get; set; }
        public string VideoFilter3 { get; set; }
        public string VideoFilter4 { get; set; }
        public string VideoFilter5 { get; set; }
        public string VideoFilter6 { get; set; }
        public string VideoFilter7 { get; set; }
        public string VideoFilter8 { get; set; }
        public string VideoFilter9 { get; set; }
        public string VideoFilter10 { get; set; }
        #endregion
        #region Video On String
        public string VideoStringActive { get; set; }
        public string VideoStringFont { get; set; }
        public string VideoStringFontSize { get; set; }
        public string VideoString { get; set; }
        public string VideoStringCoordinates { get; set; }
        public string VideoStringTransparent { get; set; }
        public string VideoStringX { get; set; }
        public string VideoStringY { get; set; }
        public string y_info { get; set; }
        public string y_giris { get; set; }
        public string y_cikis { get; set; }
        #endregion
        #region Video Arka Plan & Çerçeve & Filitre Ayarları
        public string VideoMode { get; set; }
        public string VideoPixel { get; set; }
        public string BackgroundPixel { get; set; }
        public string Frame { get; set; }
        public string Filter { get; set; }
        public string VideoCoordinates { get; set; }
        public string CoordinatesX { get; set; }
        public string CoordinatesY { get; set; }        

        #endregion
        #region Yazılım Ayarları
        public string AutoUpdate { get; set; }
        public string FileNameControl { get; set; }
        public string RenderCompleteProccess { get; set; }
        public string RenderProccess { get; set; }
        #endregion
        #region Video Kesme Ayarları
        public string CutVideo { get; set; }
        public string CutFirst { get; set; }
        public string CutLast { get; set; }
        #endregion
        #region Logo Ayarları
        public string LogoName { get; set; }
        public string LogoAktif { get; set; }
        public string LogoKonum { get; set; }
        public string LogoX { get; set; }
        public string LogoY { get; set; }

        #endregion
        #region Canlılık Ayarları
        public string Gamma { get; set; }
        public string Kontrast { get; set; }
        public string Brightness { get; set; }
        public string White { get; set; }
        #endregion
        #region Arkan Plan Diğer Ayarları
        public int ArkaPlanBulaniklik { get; set; }
        #endregion
        #region Arka Plana Yazı
        public string BackText { get; set; }
        #endregion
        #region Simulator Ayarları
        public string sim_height { get; set; }
        public string sim_width { get; set; }
        public string sim_video_height { get; set; }
        public string sim_video_width { get; set; }
        public string sim_video_x { get; set; }
        public string sim_video_y { get; set; }
        #endregion
        #region Şerit Ayarları
        public string str_font { get; set; }
        public string serit_check { get; set; }
        public string serit_opacity { get; set; }
        #endregion




    }
}
