using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SmartRender.MainClass;
using System.Diagnostics;
using SmartRender.Render;
namespace SmartRender
{
    public partial class CollectivePicture : Form
    {
        public CollectivePicture()
        {
            InitializeComponent();
            yazikonum.SelectedIndex = 0;
            boyut.SelectedIndex = 10;
            if(Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                label3.Text = "Küçük Resmin Alınacağı Saniye";
                c1.Text = "Küçük Resme Yazı Bastır (Aşağıya Giriniz)";
                label4.Text = "Yazı Rengi";
                linkLabel1.Text = "(Değiştirmek için Tıkla)";
                label7.Text = "Konum";
                label6.Text = "Boyut";
                purpleButton1.Text = "TAMAM";
                groupBox6.Text = "Küçük Resim Ayarları";
                yazikonum.Items.Clear();
                yazikonum.Items.Add("Ortaya");
                yazikonum.Items.Add("Sol Alt Köşe");
                yazikonum.Items.Add("Sol Üst Köşe");
                yazikonum.Items.Add("Sağ Alt Köşe");
                yazikonum.Items.Add("Sağ Üst Köşe");
            }
            else
            {
                groupBox6.Text = "Thumbnail Settings";
                label3.Text = "Captured Seconds";
                c1.Text = "Add to Text";
                label4.Text = "Fore Color";
                linkLabel1.Text = "(Click and Change)";
                label7.Text = "Location";
                label6.Text = "Size";
                purpleButton1.Text = "DONE";
                yazikonum.Items.Clear();
                yazikonum.Items.Add("Center");
                yazikonum.Items.Add("Bottom Left Corner");
                yazikonum.Items.Add("Top Left Corner");
                yazikonum.Items.Add("Bottom Right Corner");
                yazikonum.Items.Add("Right Top Corner");
            }
        }

        private void fnt_Click(object sender, EventArgs e)
        {
            fnt.Items.Clear();
            foreach(string files in Directory.GetFiles(Variables.FONT))
            {
                fnt.Items.Add(Path.GetFileName(files));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                
               if(cd.Color.IsNamedColor)
               {
                   clr.BackColor = cd.Color;
               }
               else
               {
                   SendMessage.Success("Lütfen Başka Bir Renk Seçin, Bu Renk FFMPEG ile uyumlu değil","Başka Bir Renk Seçmelisiniz!");
               }
            }
        }

        private void purpleButton1_Click(object sender, EventArgs e)
        {
            mainForm mainFrm = (mainForm)Application.OpenForms["mainForm"];
            foreach(ListViewItem video in mainFrm.WorkList.Items)
            {
                Video.Toplu_Kucuk_Resim(video.Text, smallsecond.Text, smalltext.Text, yazikonum.SelectedIndex, Variables.FONT + "/" + fnt.Text, int.Parse(boyut.Text), clr.BackColor.Name);
            }
            DialogResult dr = MessageBox.Show("Küçük Resimlerin Oluşturulduğu Klasörü Görüntülemek İster misiniz?", "İşlem Başarıyla Tamamlandı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Process.Start("explorer.exe", Variables.S_PICTURE);
            }
        }
    }
}
