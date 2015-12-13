using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRender.MainClass
{

    class Language
    {
        static public string ViewLanguage = "Turkish";
        static public int ViewingLanguage = 0;
        public enum Languages
        {
            Turkish,
            English
        }
       static public void Turkish()
        {
           mainForm F1 = (mainForm)Application.OpenForms["mainForm"];
           #region Sol Menu
           F1.btn_add.Text = "Ekle";
           F1.button2.Text = "Kaldır";
           F1.btn_display.Text = "Önizleme";
           F1.btn_start.Text = "BAŞLAT";
           F1.button1.Text = "Ekran Kaydet(F5)";
           F1.btn_thumbnail.Text = "Küçük Resim";
           F1.btnCollectivePicture.Text = "Toplu Resim";
           F1.button7.Text = "Hesap Oluştur";
           F1.btn_login.Text = "Oturum Aç";
           F1.buy.Text = "Satın Al";
           F1.savesettings.Text = "Ayarları Kaydet";
           F1.loadsettings.Text = "Ayarları Yükle";
           F1.Combine.Text = "Video Birleştir";
           #endregion
           #region WorkList
           F1.WorkList.Columns[0].Text = "Video";
           F1.WorkList.Columns[1].Text = "Süre";
           F1.WorkList.Columns[2].Text = "Boyut";
           F1.WorkList.Columns[3].Text = "Tür";
           F1.WorkList.Columns[4].Text = "İşlem";
           F1.WorkList.Columns[5].Text = "Geçen Süre";
            #endregion
           #region WorkTab
           F1.WorkTab.TabPages[0].Text = "Videolar";
           F1.WorkTab.TabPages[1].Text = "Genel Video Ayarları";
           F1.WorkTab.TabPages[2].Text = "Arka Plan ve Çerçeve";
           F1.WorkTab.TabPages[3].Text = "Efektler ve Ses";
           F1.WorkTab.TabPages[4].Text = "Konsol";
           F1.WorkTab.TabPages[5].Text = "Yazılım Ayarları ve Ekstra";
            #endregion
           #region Tab#Genel Video Ayarları
           F1.KonumBox.Text = "Videoların Kayıt Edileceği Konum";
           F1.label4.Text = "Çerçeve";
           F1.label5.Text = "Filire";
           F1.LogoBox.Text = "Logo Ayarları";
           F1.label19.Text = "Arka Plan Rengi";
           F1.Cut.Text = "Aktif";
           F1.label16.Text = "Yazı Rengi";
           F1.KonumDegistir.BText = "Konum Değiştir";
           F1.ColorBox.Text = "RGB Renk Ayarları";
           F1.Rlabel.Text = "(R) Kırmızı";
           F1.Glabel.Text = "(G) Yeşil";
           F1.Blabel.Text = "(B) Mavi";
           F1.digerBox.Text = "Diğer";
           F1.BulanikLabel.Text = "Bulanıklık";
           F1.PusLabel.Text = "Puslama";
           F1.HızLabel.Text = "Hız";
           F1.ZoomLabel.Text = "Zoom";
           F1.CanliBox.Text = "Diğer";
           F1.gammaLabel.Text = "Gamma";
           F1.parlakLabel.Text = "Parlaklık";
           F1.kontrastLabel.Text = "Kontrast";
           F1.beyazLabel.Text = "Beyazlık";
           F1.FontBox.Text = "Yazı ve Font";
           F1.boyutLabel.Text = "Boyut";
           F1.konumLabel.Text = "Konum";
           F1.yGirisLabel.Text = "Yazı Giriş Saniyesi";
           F1.yCikisLabel.Text = "Yazı Çıkış Saniyesi";
           F1.yazi_giris_durum.Text = "Yazı Sürekli Görünsün";
           F1.yazi_arka_plan.Text = "Transparent Arka Plan";
           F1.yazi.Text = "Aktif";
           F1.cutBox.Text = "Süre Kes";
           F1.bastanLabel.Text = "Baştan";
           F1.sondanLabel.Text = "Sondan";
           F1.saniyeLabel1.Text = "Saniye";
           F1.saniyeLabel2.Text = "Saniye";
           F1.btnReset.BText = "AYARLARI SIFIRLA";
           F1.LogoKonumLabel.Text = "Logo Konumu";
           F1.logo_stat.Text = "Aktif";
           F1.LogonSimulator.BText = "Simulator ile Ayarla";
           F1.logoLabel.Text = "LOGO EKLEMEK İÇİN, LOGONUZU BU PENCEREYE SÜRÜKLEYİP BIRAKIN";

            #endregion
           #region Tab#Arka Plan ve Çerçeveler
           F1.sessiz.Text = "Sessiz";
           F1.frameBox.Text = "Arka Plan ve Çerçeve";
           F1.modeLabel.Text = "Video Modu";
           F1.VideoPixelLabel.Text = "Video Çözünürlüğü";
           F1.arkaPlanPixelLabel.Text = "Arka Plan Çözünürlüğü";
           F1.VideoKonumLabel.Text = "Video Konumu";
           F1.ArkaPlanBulanikLabel.Text = "Arka Plan Bulanıklığı";
           F1.showFilter.BText = "Filitreler";
           F1.showFrame.BText = "Çerçeveler";
           F1.showBackground.BText = "Arka Planlar";
           F1.showSimulator.BText = "Simulator ile Ayarla";
           F1.backRenk1.Text = "Arka Plan";
           F1.backRenk2.Text = "Yazı Rengi";
           F1.backTrans.Text = "Transparent Arka Plan";
           F1.label7.Text = "Boyut";
           F1.label6.Text = "Konum";
           F1.backCheck.Text = "Aktif";
           F1.BackTextBox.Text = "Arka Plana Yazı Yaz";
            #endregion
           #region Tab#Efektler ve Ses
           F1.Camera.Text = "Kamera Efekti";
           F1.Giris.Text = "Giriş Efekti";
           F1.Gray.Text = "Gri Ton";
           F1.Ayna.Text = "Ayna";
           F1.BeyazPerde.Text = "Beyaz Pederde";
           F1.Line.Text = "Beyaz Perde 2";
           F1.Kusak.Text = "Gök Kuşağı";
           F1.Ters.Text = "Ters Çevir";
           F1.Kenarlik.Text = "Kenarlık";
           F1.EF.Text = "Video Efektleri";
           F1.manuel.Text = "Ayarlanabilir Echo ( Alt Sekmede Ayarları yapabilirsiniz)";
           F1.Komut.Text = "Kod Yazmak için Tıklayın..";
            #endregion
           #region Tab#Ayarlar
           F1.setBox.Text = "Yazılım Ayarları";
           F1.otoupdate.Text = "Otomatik Güncelleme";
           F1.vfilename.Text = "Video isim kontrol (Geçersiz Karakterleri Siler ve Yeniden Adlandırır)";
           F1.rendercomplete.Text = "Render İşlemleri Tamamlandığında";
           F1.mailchange.Text = "tıklayın";
           F1.label24.Text = "Üyeliğinizi oluşturduğunuz e-mail adresine mailler gönderilir, mailinizi değiştirmek için";
           F1.label31.Text = "Render Modu :";
           F1.label36.Text = "Video Çıkış Formatı :";
           F1.label32.Text = "Varsayılan Ayar Dosyası (Yazılım ilk açıldığında yüklenecek ayar dosyası)";
           F1.exportBox.Text = "Dosya Aktar";
           F1.addfreym.Text = "ÇERÇEVE";
           F1.addbckgrnd.Text = "ARKA PLAN";
           F1.addfltr.Text = "FILITRE";
           F1.addfnt.Text = "FONT";

           #endregion
           #region WorkListMenu
           F1.önizleToolStripMenuItem.Text = "Önizle";
           F1.GroupDrag.Text = "Şu Gruba Taşı";
           F1.ViewFolder.Text = "Klasörde Göster";
           F1.deleteAll.Text = "Tümünü Sil";
           F1.gruplaToolStripMenuItem.Text = "Yeni Grup Oluştur";
           #endregion
           #region Combobox
           String[] item = new String[] { "Ortaya", "Sol Üst Köşe", "Sol Alt Köşe", "Sağ Üst Köşe", "Sağ Alt Köşe", "Manuel", "Orta Alt Bölüm", "Orta Üst Bölüm", "Sağ Orta Bölüm", "Sol Orta Bölüm" };
           String[] item2 = new String[] { "Çerçeveli Video", "Arka Plan Üzeri Video" };
           String[] item4 = new String[] { "Orjinal Render", "Yavaş Hızda Render", "Orta Hızda Render", "Hızlı Render", "Yüksek Hızda Render" };
           String[] item5 = new String[] { "Close Computer", "Send a Mail", "Play the Alarm" };
           F1.bgalign.Items.Clear();
           F1.mode.Items.Clear();
           F1.yazikonum.Items.Clear();
           F1.LogoKonum.Items.Clear();
           F1.RenderMode.Items.Clear();
           F1.islemler.Items.Clear();
           F1.backLoc.Items.Clear();
           foreach (string str in item) { F1.bgalign.Items.Add(str); }
           foreach (string str in item2) { F1.mode.Items.Add(str); }
           foreach (string str in item) { F1.yazikonum.Items.Add(str); }
           foreach (string str in item) { F1.LogoKonum.Items.Add(str); }
           foreach (string str in item4) { F1.RenderMode.Items.Add(str); }
           foreach (string str in item5) { F1.islemler.Items.Add(str); }
           foreach (string str in item) { F1.backLoc.Items.Add(str); }
           F1.RenderMode.SelectedIndex = F1.RenderMode.Items.Count - 1;
           F1.mode.SelectedIndex = 0;
           F1.islemler.SelectedIndex = 0;
           F1.bgalign.SelectedIndex = 0;
           #endregion
           ViewLanguage = Languages.Turkish.ToString();
           ViewingLanguage = 0;
        }
       static public void English()
       {
           mainForm F1 = (mainForm)Application.OpenForms["mainForm"];
           #region Sol Menu
           F1.btn_add.Text = "Add";
           F1.button2.Text = "Remove";
           F1.btn_display.Text = "Display";
           F1.btn_start.Text = "START";
           F1.button1.Text = "Screen Capture(F5)";
           F1.btn_thumbnail.Text = "Thumbnails";
           F1.btnCollectivePicture.Text = "Collective Thumbnails";
           F1.button7.Text = "Create Account";
           F1.btn_login.Text = "Log In";
           F1.buy.Text = "Buy";
           F1.savesettings.Text = "Save Settings";
           F1.loadsettings.Text = "Load Settings";
           F1.Combine.Text = "Combine";
           #endregion
           #region WorkList
           F1.WorkList.Columns[0].Text = "Video";
           F1.WorkList.Columns[1].Text = "Duration";
           F1.WorkList.Columns[2].Text = "Size";
           F1.WorkList.Columns[3].Text = "Extansion";
           F1.WorkList.Columns[4].Text = "Process";
           F1.WorkList.Columns[5].Text = "Time";
           #endregion
           #region WorkTab
           F1.WorkTab.TabPages[0].Text = "Videos";
           F1.WorkTab.TabPages[1].Text = "General Video Settings";
           F1.WorkTab.TabPages[2].Text = "Background and Frames";
           F1.WorkTab.TabPages[3].Text = "Effects and Sound";
           F1.WorkTab.TabPages[4].Text = "Console";
           F1.WorkTab.TabPages[5].Text = "Software Settings and Extra";
           #endregion
           #region Tab#Genel Video Ayarları
           F1.KonumBox.Text = "Output Folder Location";
           F1.label4.Text = "Frame";
           F1.Cut.Text = "Active";
           F1.label5.Text = "Filter";
           F1.LogoBox.Text = "Watermark Settings";
           F1.label19.Text = "Background Color";
           F1.label16.Text = "Fore Color";
           F1.KonumDegistir.BText = "Change Location";
           F1.ColorBox.Text = "RGB Color Settings";
           F1.Rlabel.Text = "(R)ed";
           F1.Glabel.Text = "(G)reen";
           F1.Blabel.Text = "(B)lue";
           F1.digerBox.Text = "Other";
           F1.BulanikLabel.Text = "Blur";
           F1.PusLabel.Text = "Shadow";
           F1.HızLabel.Text = "Speed";
           F1.CanliBox.Text = "Dynamics Settings";
           F1.gammaLabel.Text = "Gamma";
           F1.parlakLabel.Text = "Brightness";
           F1.kontrastLabel.Text = "Contrast";
           F1.beyazLabel.Text = "Whiteness";
           F1.FontBox.Text = "Text And Fonts";
           F1.boyutLabel.Text = "Size";
           F1.konumLabel.Text = "Location";
           F1.yGirisLabel.Text = "Text Input Seconds";
           F1.yCikisLabel.Text = "Text Input Seconds";
           F1.yazi_giris_durum.Text = "Continuous";
           F1.yazi_arka_plan.Text = "Transparent Background";
           F1.yazi.Text = "Active";
           F1.cutBox.Text = "Cutting";
           F1.bastanLabel.Text = "Begining";
           F1.sondanLabel.Text = "End";
           F1.saniyeLabel1.Text = "Seconds";
           F1.saniyeLabel2.Text = "Seconds";
           F1.btnReset.BText = "RESET SETTINGS";
           F1.LogoKonumLabel.Text = "Logo Location";
           F1.logo_stat.Text = "Active";
           F1.LogonSimulator.BText = "Set To Simulator";
           F1.logoLabel.Text = "Drag and Drop to add logo";

           #endregion
           #region Tab#Arka Plan ve Çerçeveler
           F1.sessiz.Text = "Mute";
           F1.frameBox.Text = "Background && Çerçeve";
           F1.modeLabel.Text = "Video Mode";
           F1.VideoPixelLabel.Text = "Video Resolution";
           F1.arkaPlanPixelLabel.Text = "Background Resolution";
           F1.VideoKonumLabel.Text = "Video Location";
           F1.ArkaPlanBulanikLabel.Text = "Background Blur";
           F1.showFilter.BText = "Filiters";
           F1.showFrame.BText = "Frames";
           F1.showBackground.BText = "Backgrounds";
           F1.showSimulator.BText = "Set to Simulator";
           F1.backRenk1.Text = "Background Color";
           F1.backRenk2.Text = "Fore Color";
           F1.backTrans.Text = "Transparent Background";
           F1.label7.Text = "Size";
           F1.label6.Text = "Location";
           F1.backCheck.Text = "Active";
           F1.BackTextBox.Text = "Write Text From Background";

           #endregion
           #region Tab#Efektler ve Ses
           F1.Camera.Text = "Camera Effect";
           F1.Giris.Text = "Login Efekti";
           F1.Gray.Text = "Gray Tone";
           F1.Ayna.Text = "Mirror";
           F1.BeyazPerde.Text = "White 1";
           F1.Line.Text = "White 2";
           F1.Kusak.Text = "Colorful";
           F1.Ters.Text = "Reverse";
           F1.Kenarlik.Text = "Border";
           F1.EF.Text = "Video Efektleri";
           F1.manuel.Text = "Manuel Echo";
           F1.Komut.Text = "Click For Write Code";
           #endregion
           #region Tab#Ayarlar
           F1.setBox.Text = "Software Settings";
           F1.otoupdate.Text = "Auto Update";
           F1.vfilename.Text = "File Name Control";
           F1.rendercomplete.Text = "Process Complete";
           F1.mailchange.Text = "click";
           F1.label24.Text = "sent to your default e-mail address, change your e-mail";
           F1.label31.Text = "Render Mode :";
           F1.label36.Text = "Video Output Formats :";
           F1.label32.Text = "Default settings file";
           F1.exportBox.Text = "Export File";
           F1.addfreym.Text = "FRAME";
           F1.addbckgrnd.Text = "BACKGROUND";
           F1.addfltr.Text = "FILITERS";
           F1.addfnt.Text = "FONT";

           #endregion
           #region WorkListMenu
           F1.önizleToolStripMenuItem.Text = "Display";
           F1.GroupDrag.Text = "Move To";
           F1.ViewFolder.Text = "Open Containing Folder";
           F1.deleteAll.Text = "Remove All";
           F1.gruplaToolStripMenuItem.Text = "Create new Group";
           #endregion
           #region Combobox
           String[] item = new String[] { "Center", "Top Left Corner", "Bottom Left Corner", "Top Right Corner", "Bottom Right Corner", "Manuel", "Center Bottom", "Center Top", "Right Center", "Left Center" };
           String[] item2 = new String[] { "Framed Video", "Background Over Video" };
           String[] item4 = new String[] { "Orjinal Render", "Slow Render", "Normal Render", "Speed Render", "Ultra Speed Hızda Render" };
           String[] item5 = new String[] { "Close Computer", "Send a Mail", "Play the Alarm" };
           F1.bgalign.Items.Clear();
           F1.mode.Items.Clear();
           F1.yazikonum.Items.Clear();
           F1.LogoKonum.Items.Clear();
           F1.RenderMode.Items.Clear();
           F1.islemler.Items.Clear();
           F1.backLoc.Items.Clear();
           foreach (string str in item) { F1.bgalign.Items.Add(str); }
           foreach (string str in item2) { F1.mode.Items.Add(str); }
           foreach (string str in item) { F1.yazikonum.Items.Add(str); }
           foreach (string str in item) { F1.LogoKonum.Items.Add(str); }
           foreach (string str in item4) { F1.RenderMode.Items.Add(str); }
           foreach (string str in item5) { F1.islemler.Items.Add(str); }
           foreach (string str in item) { F1.backLoc.Items.Add(str); }
           F1.RenderMode.SelectedIndex = F1.RenderMode.Items.Count - 1;
           F1.mode.SelectedIndex = 0;
           F1.islemler.SelectedIndex = 0;
           F1.bgalign.SelectedIndex = 0;
           #endregion
           ViewLanguage = Languages.English.ToString();
           ViewingLanguage = 1;
       }
    }
}
