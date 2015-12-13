using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRender.Control
{
    public partial class SmartButton : Button
    {       
        public SmartButton()
        {
            InitializeComponent();
        }
        Font fnt;
        string txt = "SmartButton";
        Color FColor = Color.White;
        Color MouseMov = Color.DarkOrchid;
        Color MouseDow = Color.MediumOrchid;        
        public void Click(EventHandler handler)
        {
            this.label1.Click += handler;
        }
        public Color MDown
        {
            get { return MouseDow; }
            set { MouseDow = value; }
        }
        public Color MMove
        {
            get { return MouseMov; }
            set { MouseMov = value; }
        }
        public Font BFont
        {
            get { return fnt; }
            set { fnt = value; label1.Font = value; }
        }
        public string BText
        {
            get { return txt; }
            set { txt = value; label1.Text = value; }
        }
        public Color BForeColor
        {
            get { return FColor; }
            set { FColor = value; label1.ForeColor = value; }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.BackColor = MouseMov;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkViolet;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label1.BackColor = MouseDow;
            }
        }

        
        
    }
}
