using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmartRender.MainClass;
namespace SmartRender
{
    public partial class Simulator : Form
    {
        public Simulator()
        {
            InitializeComponent();
            p1.MouseEnter += new EventHandler(control_MouseEnter);
            p1.MouseLeave += new EventHandler(control_MouseLeave);
            p1.MouseDown += new MouseEventHandler(control_MouseDown);
            p1.MouseMove += new MouseEventHandler(control_MouseMove);
            p1.MouseUp += new MouseEventHandler(control_MouseUp);
            p2.Parent = bg;
            p2.MouseEnter += new EventHandler(control_MouseEnter);
            p2.MouseLeave += new EventHandler(control_MouseLeave);
            p2.MouseDown += new MouseEventHandler(control_MouseDown);
            p2.MouseMove += new MouseEventHandler(control_MouseMove);
            p2.MouseUp += new MouseEventHandler(control_MouseUp);
            if(Language.ViewLanguage == Language.Languages.Turkish.ToString())
            {
                rclick.Text = "Uygula";
            }
            else
            {
                rclick.Text = "Apply";
            }
        }
        public PictureBox pics;
        #region Variables
        const int DRAG_HANDLE_SIZE = 7;
        int mouseX, mouseY;
        System.Windows.Forms.Control SelectedControl;
        Direction direction;
        Point newLocation;
        Size newSize;
        enum Direction
        {
            NW,
            N,
            NE,
            W,
            E,
            SW,
            S,
            SE,
            None
        }
        #endregion

                bool backg = false;
                public bool Background
                {
                    get { return backg; }
                    set { backg = value;}
                }

        string imj;
        public string IMG
        {
            get { return imj; }
            set { imj = value; if (backg) { p2.Visible = false; bg.ImageLocation = value; } else { p1.Visible = false; p2.ImageLocation = value; } }
        }
        private void control_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            Cursor = Cursors.SizeAll;
        }
        private void control_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Start();
        }
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bg.Invalidate();
                SelectedControl = (System.Windows.Forms.Control)sender;
                System.Windows.Forms.Control control = (System.Windows.Forms.Control)sender;
                mouseX = -e.X;
                mouseY = -e.Y;
                control.Invalidate();
                DrawControlBorder(sender);

            }
        }
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Windows.Forms.Control control = (System.Windows.Forms.Control)sender;
                Point nextPosition = new Point();
                nextPosition = bg.PointToClient(MousePosition);
                nextPosition.Offset(mouseX, mouseY);
                control.Location = nextPosition;
                Invalidate();
            }
        }
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Windows.Forms.Control control = (System.Windows.Forms.Control)sender;
                Cursor.Clip = System.Drawing.Rectangle.Empty;
                control.Invalidate();
                DrawControlBorder(control);
            }
        }

        private void DrawControlBorder(object sender)
        {
            System.Windows.Forms.Control control = (System.Windows.Forms.Control)sender;
            Rectangle Border = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE / 2),
                new Size(control.Size.Width + DRAG_HANDLE_SIZE,
                    control.Size.Height + DRAG_HANDLE_SIZE));
            Rectangle NW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle N = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle NE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle W = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle E = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle S = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

            Graphics g = bg.CreateGraphics();
            ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
            ControlPaint.DrawGrabHandle(g, NW, true, true);
            ControlPaint.DrawGrabHandle(g, N, true, true);
            ControlPaint.DrawGrabHandle(g, NE, true, true);
            ControlPaint.DrawGrabHandle(g, W, true, true);
            ControlPaint.DrawGrabHandle(g, E, true, true);
            ControlPaint.DrawGrabHandle(g, SW, true, true);
            ControlPaint.DrawGrabHandle(g, S, true, true);
            ControlPaint.DrawGrabHandle(g, SE, true, true);
            g.Dispose();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null && e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                Invalidate();

                if (SelectedControl.Height < 20)
                {
                    SelectedControl.Height = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }
                else if (SelectedControl.Width < 20)
                {
                    SelectedControl.Width = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }

                Point pos = bg.PointToClient(MousePosition);

                #region resize the control in 8 directions
                if (direction == Direction.NW)
                {

                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width - (newLocation.X - SelectedControl.Location.X),
                        SelectedControl.Size.Height - (newLocation.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SE)
                {

                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width + (newLocation.X - SelectedControl.Size.Width - SelectedControl.Location.X),
                        SelectedControl.Height + (newLocation.Y - SelectedControl.Height - SelectedControl.Location.Y));
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.N)
                {

                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.S)
                {

                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.W)
                {

                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        SelectedControl.Height);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.E)
                {

                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SW)
                {

                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.NE)
                {
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                #endregion
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null)
                DrawControlBorder(SelectedControl);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Get the direction and display correct cursor
            if (SelectedControl != null)
            {
                Point pos = bg.PointToClient(MousePosition); 
                if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X) &&
                    (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NW;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SE;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                    pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y)
                {
                    direction = Direction.N;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE)
                {
                    direction = Direction.S;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.W;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.E;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE) &&
                    (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NE;
                    Cursor = Cursors.SizeNESW;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X + DRAG_HANDLE_SIZE) &&
                    (pos.Y >= SelectedControl.Location.Y + SelectedControl.Height - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SW;
                    Cursor = Cursors.SizeNESW;
                }
                else
                {
                    Cursor = Cursors.Default;
                    direction = Direction.None;
                }
            }
            else
            {
                direction = Direction.None;
                Cursor = Cursors.Default;
            }
            #endregion
        }

        private void Simulator_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void uygulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm main = (mainForm)Application.OpenForms["mainForm"];
            if (backg)
            {
                string arkaplan = string.Format("Arka Plan Çözünürlüğü : {0}x{1}", Width, Height);
                string video = string.Format("Video Çözünürlüğü : {0}x{1}", p1.Width, p1.Height);                
                MainClass.Controllers.sim_video = string.Format("{0}0:{1}0", (p1.Width).ToString().Substring(0, (p1.Width).ToString().Length - 1), (p1.Height).ToString().Substring(0, (p1.Height).ToString().Length - 1));
                MainClass.Controllers.sim_background = string.Format("{0}0:{1}0", Width.ToString().Substring(0, Width.ToString().Length - 1), Height.ToString().Substring(0, Height.ToString().Length - 1));
                main.txt_bg_x.Text = string.Format("{0}0", (p1.Location.X).ToString().Substring(0, (p1.Location.X).ToString().Length - 1));
                main.txt_bg_y.Text = string.Format("{0}0", (p1.Location.Y).ToString().Substring(0, (p1.Location.Y).ToString().Length - 1));
                main.c3.Text = "Simulator";
                main.bgcombo.Text = "Simulator";
                main.bgalign.Text = "Manuel";

                main.simulator_width = string.Format("{0}0", (p1.Width).ToString().Substring(0, (p1.Width).ToString().Length - 1), (p1.Height).ToString().Substring(0, (p1.Height).ToString().Length - 1));
                main.simulator_height = string.Format("{1}0", (p1.Width).ToString().Substring(0, (p1.Width).ToString().Length - 1), (p1.Height).ToString().Substring(0, (p1.Height).ToString().Length - 1));
                main.background_video_width = string.Format("{0}0", Width.ToString().Substring(0, Width.ToString().Length - 1), Height.ToString().Substring(0, Height.ToString().Length - 1));
                main.background_video_height = string.Format("{1}0", Width.ToString().Substring(0, Width.ToString().Length - 1), Height.ToString().Substring(0, Height.ToString().Length - 1));
                main.background_video_x = string.Format("{0}0", (p1.Location.X).ToString().Substring(0, (p1.Location.X).ToString().Length - 1));
                main.background_video_y =  string.Format("{0}0", (p1.Location.Y).ToString().Substring(0, (p1.Location.Y).ToString().Length - 1));


            }
            else
            {
                main.LogoKonum.Text = "Manuel";
                main.logo_x.Text = p2.Location.X.ToString();
                main.logo_y.Text = p2.Location.Y.ToString();
                main.logo_size[0] = p2.Width;
                main.logo_size[1] = p2.Height;
            }
        }

        private void p1_Resize(object sender, EventArgs e)
        {
            p1.Refresh();
            Text = string.Format("Arka Plan Çözünürlüğü : {2}x{3} - Video Çözünürlüğü : {0}x{1}", p1.Width, p1.Height, Width, Height);
        }

        private void Simulator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        p1.Location = new Point(p1.Location.X - 10, p1.Location.Y);
                        break;
                    }
                case Keys.Right:
                    {
                        p1.Location = new Point(p1.Location.X + 10, p1.Location.Y);
                        break;
                    }
                case Keys.Up:
                    {
                        p1.Location = new Point(p1.Location.X, p1.Location.Y - 10);
                        break;
                    }
                case Keys.Down:
                    {
                        p1.Location = new Point(p1.Location.X, p1.Location.Y + 10);
                        break;
                    }
                case Keys.Add:
                    {
                        p1.Size = new Size(p1.Width + 10, p1.Height + 10);
                        break;
                    }
                case Keys.Subtract:
                    {
                        if (p1.Width != 10 || p1.Height != 10)
                        {
                            p1.Size = new Size(p1.Width - 10, p1.Height - 10);
                        }
                        break;
                    }
            }
        }
    }
}
