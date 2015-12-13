using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SmartRender.Control
{
    public partial class SmartBallButton : Button
    {
        public SmartBallButton()
        {
            InitializeComponent();
        }

        public SmartBallButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
         private void SetProperties()
        {
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Arial", 10, FontStyle.Bold);
            Size = new Size(66, 64);
        }       
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetProperties();
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
        }       
    }
}
