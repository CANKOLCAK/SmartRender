using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SmartRender.MainClass;
namespace SmartRender.Control
{
    public partial class Viewer : UserControl
    {
        public Viewer()
        {
            InitializeComponent();
        }
        string FName;
        Color BC = Color.Transparent;
        public string FileName
        {
            get { return FName; }
            set
            {
                FName = value; label1.Text = Path.GetFileName(value);
                p.ImageLocation = value;
            }


        }

        private void p_Click(object sender, EventArgs e)
        {
            mainForm mainForm = (mainForm)Application.OpenForms["mainForm"];           
            switch(mainForm.selectView.SelectedIndex)
            {
                case 0://arka plan
                    {                       
                        if(mainForm.mode.SelectedIndex == 1)
                        {
                            Controllers.getFiles(mainForm.framescombo, Variables.BACKGROUND);
                            mainForm.framescombo.Text = Path.GetFileName(FileName);
                        }
                        else
                        {
                            SendMessage.Success(Messages.MSG_22[Language.ViewingLanguage], "Warning");
                        }
                        break;
                    }
                case 1://çerçeve
                    {
                        if (mainForm.mode.SelectedIndex == 0)
                        {
                            Controllers.getFiles(mainForm.framescombo, Variables.FRAMES);
                            mainForm.framescombo.Text = Path.GetFileName(FileName);
                        }
                        else
                        {
                            SendMessage.Success(Messages.MSG_23[Language.ViewingLanguage], "Warning");
                        }
                        break;
                    }
                case 2://filitre
                    {
                        Controllers.getFiles(mainForm.filtercombo, Variables.FILTER);
                        mainForm.filtercombo.Text = Path.GetFileName(FileName);
                        
                        break;
                    }
            }
        }

        private void p_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.DarkViolet;
        }

        private void p_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;
        }
    }
}
