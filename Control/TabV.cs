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
    public partial class TabV : UserControl
    {
        public TabV()
        {
            InitializeComponent();
        }
        public Image Image
        {
            get { return P.Image; }
            set { P.Image = value; }
        }
        public string Header
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
    }
}
