using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
namespace SmartRender.Control
{
    public partial class PurpleButton : Button
    {
        Color MouseMov = Color.DarkOrchid;
        Color MouseDow = Color.MediumOrchid;
        Color MousePrew = Color.DarkViolet;
        public PurpleButton()
        {
            InitializeComponent();
            Propertiess();
        }

        public PurpleButton(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void Propertiess()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.DarkViolet;
            ForeColor = Color.White;
        }
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            BackColor = MouseMov;
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            BackColor = MouseDow;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = MousePrew;
        }
    }
}
