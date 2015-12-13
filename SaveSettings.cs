using SmartRender.MainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRender
{
    public partial class SaveSettings : Form
    {
        public SaveSettings()
        {
            InitializeComponent();
            if(Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                Text = "Ayarları Kaydet";
                label1.Text = "Ayar İsmi";
                c1.Text = "Varsayılan Ayar Olarak Kaydet";
                b1.Text = "KAYDET";
            }
            else
            {
                Text = "Save Settings";
                label1.Text = "Settings Name";
                c1.Text = "Save by Current Settings";
                b1.Text = "SAVE";
            }
        }
        private void smartButton1_Click(object sender, EventArgs e)
        {
            if (json.Text != string.Empty)
            {
                Controllers.AyarlariKaydet(string.Format("{0}/{1}.json", Variables.AYARLAR, json.Text));
                
                    mainForm mainForm = (mainForm)Application.OpenForms["mainForm"];
                    mainForm.defaultjson.Text = string.Format("{0}/{1}.json", Variables.AYARLAR, json.Text);
                if (c1.Checked)
                {
                    Properties.Settings.Default.defaultJson = string.Format("{0}/{1}.json", Variables.AYARLAR, json.Text);
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                SendMessage.Success("Lütfen Bir Ayar Adı Girin!","Hata");
            }
            
            Close();
        }
    }
}
