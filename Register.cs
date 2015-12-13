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
using SmartRender.MainClass;
namespace SmartRender
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            if(Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                q1.Text = "Kullanıcı Adı";
                q2.Text = "Parola";
                q3.Text = "Tekrar Parola";
                q5.Text = "Phone";
                ok.Text = "Done";
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (t2.Text != t22.Text)
            {
                SendMessage.Success("Şifreler Aynı Değil!", "Şifreleri Kontrol Edin");
            }
            else if (t1.Text == string.Empty || t2.Text == string.Empty || t3.Text == string.Empty || t4.Text == string.Empty)
            {
                SendMessage.Success("Tüm Boşlukları Doldurun", "Hata");
            }
            else
            {
               
            }
        }

    }
}
