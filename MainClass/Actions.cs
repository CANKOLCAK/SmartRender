using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SmartRender.MainClass
{
    class Actions
    {
        static public mainForm MainForm = (mainForm)Application.OpenForms["mainForm"];       
        static public class GroupActions
        {
            static public void KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Grupla(MainForm.txtGroupName.Text);
                    MainForm.txtGroupName.Text = "Grup Adı Gir";
                }
            }
            static public void Grupla(string GroupName)
            {
                foreach (ListViewGroup g in MainForm.WorkList.Groups)
                {
                    if (g.Items.Count < 0 && g.Items.Count == 0)
                    {
                        MainForm.WorkList.Groups.Remove(g);
                    }
                }
                int iFirstGroup = 0;
                iFirstGroup = MainForm.WorkList.Groups.Add(new ListViewGroup(GroupName));
                foreach (ListViewItem item in MainForm.WorkList.SelectedItems)
                {
                    item.Group = MainForm.WorkList.Groups[MainForm.WorkList.Groups.Count - 1];
                }

            }
            static public void MouseDown(object sender, MouseEventArgs e)
            {
                int x = 0;
                MainForm.GroupDrag.DropDownItems.Clear();
                if (e.Button == MouseButtons.Right)
                {
                  

                            foreach(string RenderProfile in Directory.GetFiles(Variables.AYARLAR,"*.json"))
                            {
                                ToolStripMenuItem tool = new ToolStripMenuItem { Text = Path.GetFileNameWithoutExtension(RenderProfile) };
                                MainForm.GroupDrag.DropDownItems.AddRange(new ToolStripItem[] { tool });
                                tool.ToolTipText = x.ToString();
                                tool.Click += delegate(object o, EventArgs evnt)
                                {
                                    Grupla(tool.Text);
                                    int GIndex = int.Parse(tool.ToolTipText);
                                    foreach (ListViewItem item in MainForm.WorkList.SelectedItems)
                                    {
                                        item.Group = MainForm.WorkList.Groups[MainForm.WorkList.Groups.Count-1];
                                    }
                                };
                                x++;
                            }
                    
                }
            }
            static public void txtClear(object sender, EventArgs e)
            {
                MainForm.txtGroupName.Clear();
            }
        }
        static public class FormActions
        {
            static public void Resize(object sender, EventArgs e)
            {
               Controllers.AutoSizeWorkList(MainForm.WorkList);
            }
            static public void Font_Click(object sender, EventArgs e)
            {
                MainForm.fontcombo.Items.Clear();
                string font_extansion = "*.otf,*.ttf";
                foreach (string font_file in Directory.GetFiles(Variables.FONT, "*.*", SearchOption.AllDirectories).Where(emre => font_extansion.Contains(Path.GetExtension(font_extansion))))
                {
                    MainForm.fontcombo.Items.Add(Path.GetFileName(font_file));
                }
            }
            static public void FramesCombo_Click(object sender, EventArgs e)
            {
                if (MainForm.mode.SelectedIndex == 0)
                {
                    string onceki = MainForm.framescombo.Text;
                    Controllers.getFiles(MainForm.framescombo, Variables.FRAMES);
                    MainForm.framescombo.Text = onceki;
                }
                else
                {
                    string onceki = MainForm.framescombo.Text;
                    Controllers.getFiles(MainForm.framescombo, Variables.BACKGROUND);
                    MainForm.framescombo.Text = onceki;
                }
            }
            static public void FilterCombo_Click(object sender, EventArgs e)
            {
                string onceki = MainForm.filtercombo.Text;
                Controllers.getFiles(MainForm.filtercombo, Variables.FILTER);
                MainForm.filtercombo.Text = onceki;
            }
            static public void Konum_Click(object sender, EventArgs e)
            {
                FolderBrowserDialog obd = new FolderBrowserDialog();
                if (obd.ShowDialog() == DialogResult.OK) { MainForm.save_folder.Text = obd.SelectedPath; }
            }
            static public void ZBAR(object sender,EventArgs e)
            {
                if (MainForm.zoombar.Value < 10)
                {
                    MainForm.txtzoom.Text = string.Format("0.{0}", MainForm.zoombar.Value);
                }
                else
                {
                    MainForm.txtzoom.Text = string.Format("{0}.{1}", MainForm.zoombar.Value.ToString()[0], MainForm.zoombar.Value.ToString()[1]);
                }
            }
            static public void SPEEDBAR(object sender, EventArgs e)
            {
                if (MainForm.speedbar.Value < 100)
                {
                    MainForm.txtspeed.Text = string.Format("0.{0}", MainForm.speedbar.Value);
                }
                else
                {
                    MainForm.txtspeed.Text = string.Format("{0}.{1}{2}", MainForm.speedbar.Value.ToString()[0], MainForm.speedbar.Value.ToString()[1], MainForm.speedbar.Value.ToString()[2]);
                }
            }
            static public void RBAR(object sender, EventArgs e)
            {
                MainForm.rText.Text = MainForm.rBar.Value.ToString();
            }
            static public void GBAR(object sender, EventArgs e)
            {
                MainForm.gText.Text = MainForm.gBar.Value.ToString();
            }
            static public void BBAR(object sender, EventArgs e)
            {
                MainForm.bText.Text = MainForm.bBar.Value.ToString();
            }
            static public void BLUR(object sender, EventArgs e)
            {
                MainForm.bulanik = MainForm.blur.Value;
                MainForm.bq.Text = MainForm.blur.Value.ToString();
            }
            static public void trackBar1_Scroll(object sender, EventArgs e)
            {
                MainForm.pus = MainForm.trackBar1.Value;
                MainForm.puss.Text = MainForm.pus.ToString();
            }
            static public void Mode_SelectedIndexChanged(object sender, EventArgs e)
            {
                if(MainForm.mode.SelectedIndex == 0)
                {
                    MainForm.label4.Text = "Çerçeve";
                }
                else
                {
                    MainForm.label4.Text = "Arka Plan";
                }

            }
            static public void Capture()
            {
                mainForm mainFrm = (mainForm)Application.OpenForms["mainForm"];
                mainFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Bitmap bmp = new Bitmap(((int)mainFrm.Width) + 2, ((int)mainFrm.Height) + 2);
                mainFrm.DrawToBitmap(bmp, new Rectangle(0, 0, ((int)mainFrm.Width) + 2, ((int)mainFrm.Height) + 2));
                try
                {
                    Capture Cap = (Capture)Application.OpenForms["Capture"];
                    Cap.Captured.Image = bmp;
                    Cap.Focus();
                    mainFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                }
                catch
                {
                    Capture Cap = new Capture();
                    Cap.Captured.Image = bmp;
                    Cap.Show();
                    mainFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                }
            }
            static public Bitmap CaptureObject(Form Obj)
            {
                Bitmap bmp = new Bitmap(((int)Obj.Width) + 2, ((int)Obj.Height) + 2);
                Obj.DrawToBitmap(bmp, new Rectangle(0, 0, ((int)Obj.Width) + 2, ((int)Obj.Height) + 2));
                return bmp;
            }
        }
    }
}
