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
using System.IO;
namespace SmartRender
{
    public partial class LoadSet : Form
    {
        public LoadSet()
        {
            InitializeComponent();
            ok.Click(new EventHandler(ok_click));
            if (Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                label1.Text = "Ayar dosyası seçin (JSON)";
                ok.BText = "TAMAM";
            }
            else
            {
                label1.Text = "Please Select JSON Settings File";
                ok.BText = "DONE";
            }
        }
        private void ok_click(object sender,EventArgs e)
        {
            string json_file = string.Format("{0}/{1}",Variables.AYARLAR,set_combo.Text);
            if(File.Exists(json_file))
            {
                Controllers.AyarlariYukle(json_file,true);
            }
            else
            {
                SendMessage.Success("Ayarlar yüklenemedi! Dosya silinmiş, yada taşınmış","Hata");
            }
            Close();

        }

        private void set_combo_Click(object sender, EventArgs e)
        {
            set_combo.Items.Clear();
            foreach(string json in Directory.GetFiles(Variables.AYARLAR,"*.json"))
            {
                set_combo.Items.Add(Path.GetFileName(json));
            }
        }
    }
}
