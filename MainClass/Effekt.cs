using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRender.MainClass;
using System.IO;

namespace SmartRender.MainClass
{
    class Effekt
    {
        static mainForm mainForm = (mainForm)Application.OpenForms["mainForm"];
        static public string Background_Text()
        {
            string uygulanacak = string.Empty;
            if (mainForm.backCheck.Checked)
            {
                string font_size = mainForm.backSize.Text;
                string font_file = Variables.FONT + "/" + mainForm.backFont.Text;
                if (!File.Exists(font_file))
                { SendMessage.Success(Messages.MSG_21[Language.ViewingLanguage], "Warning!"); }
                string font_color = mainForm.backC2.BackColor.Name;
                string yazi = mainForm.backText.Text;
                string x = string.Empty, y = string.Empty;
                string background_color = mainForm.backC1.BackColor.Name;
                switch (mainForm.backLoc.SelectedIndex)
                {
                    case 0: // Tam Ortaya
                        {
                            x = "(w-tw)/2";
                            y = "(h-th)/2";
                            break;
                        }
                    case 2: // Sol Alt Köşe
                        {
                            x = "10";
                            y = "(h-th)-10";
                            break;
                        }
                    case 1: //Sol Üst Köşe
                        {
                            x = "10";
                            y = x;
                            break;
                        }
                    case 3: //Sağ Alt Köşe
                        {
                            x = "(w-tw)-10";
                            y = "(h-th)-10";
                            break;
                        }
                    case 4: //Sağ Üst Köşe
                        {
                            x = "(w-tw)-10";
                            y = "10";
                            break;
                        }
                    case 5: //Manuel
                        {
                            x = mainForm.backX.Text;
                            y = mainForm.backY.Text;
                            break;
                        }
                    case 6: // Orta Alt
                        {
                            x = "(main_w-tw)/2";
                            y = "main_h-th";
                            break;
                        }
                    case 7: // Orta Üst
                        {
                            x = "(main_w-tw)/2";
                            y = "0";
                            break;
                        }
                    case 8: // Sağ Orta
                        {
                            x = "(main_w-tw)";
                            y = "(main_h-th)/2";
                            break;
                        }
                    case 9: // Sol Orta
                        {
                            x = "0";
                            y = "(main_h-th)/2";
                            break;
                        }
                }
                    if (mainForm.backTrans.Checked) // TransParent Arka Plan
                    {
                        uygulanacak += string.Format(@",drawtext='fontsize={0}:fontfile={1}:fontcolor={2}:text='{3}':x={4}:y={5}'", font_size, font_file, font_color, yazi, x, y);
                    }
                    else
                    {
                        uygulanacak += string.Format(@",drawtext='fontsize={0}:fontfile={1}:fontcolor={2}:box=1: boxcolor={6}:text='{3}':x={4}:y={5}'", font_size, font_file, font_color, yazi, x, y, background_color);
                    }


                }
            return uygulanacak;
            
        }
       static public string Load_Effects(GroupBox Tab)
        {
            string uygulanacak = string.Empty;
            string box_y = "0";
            foreach(CheckBox efekt in Tab.Controls)
            {
                    if (efekt.Checked)
                    {
                        switch (efekt.Name)
                        {
                            case "Giris":
                                {
                                    uygulanacak += ",fade=in:0:100";
                                    break;
                                }
                            case "Camera":
                                {
                                    uygulanacak += ",crop=in_w/1.5:in_h/1.5:y:100+100*sin(n/10)";
                                    break;
                                }
                            case "Gray":
                                {
                                    uygulanacak += ",hue=s=0";
                                    break;
                                }
                            case "Ayna":
                                {
                                    uygulanacak += ",hflip";
                                    break;
                                }
                            case "Kusak":
                                {
                                    uygulanacak += ",geq=r='X/W*r(X,Y)':g='(1-X/W)*g(X,Y)':b='(H-Y)/H*b(X,Y)'";
                                    break;
                                }
                            case "Gümüş Efekt":
                                {
                                    uygulanacak += ",format=gray,geq=lum_expr='(p(X,Y)+(256-p(X-4,Y-4)))/2'";
                                    break;
                                }
                            case "BeyazPerde":
                                {
                                    uygulanacak += ",colorlevels=romin=0.5:gomin=0.5:bomin=0.5";
                                    break;
                                }
                            case "EdgeDetect":
                                {
                                    uygulanacak += ",edgedetect";
                                    break;
                                }
                            case "Line":
                                {
                                    uygulanacak += ",fftfilt=dc_Y=128:weight_Y='squish(1-(Y+X)/100)'";
                                    break;
                                }
                            case "Ters":
                                {
                                    uygulanacak += ",vflip";
                                    break;
                                }
                            case "Kenarlik":
                                {
                                    uygulanacak += ",drawbox= : x=0 : y=0 :color=white:t=5";
                                    break;
                                }
                            case "drawBox":
                                {
                                    string opacity = mainForm.serit_opacity.Value.ToString();
                                    string font_size = mainForm.boyut.Text;
                                    string box_color = mainForm.button3.BackColor.Name.ToString();
                                    switch (mainForm.yazikonum.SelectedIndex)
                                    {
                                        case 0: // Tam Ortaya
                                            {
                                                box_y = "(ih-h)/2";
                                                break;
                                            }
                                        case 1: // Sol Üst Köşe
                                            {
                                                box_y = "0";
                                                break;
                                            }
                                        case 2: //Sol Alt Köşe
                                            {
                                                box_y = string.Format("(ih-{0})",font_size);
                                                break;
                                            }
                                        case 3: //Sağ Alt Köşe
                                            {
                                                box_y = "0";
                                                break;
                                            }
                                        case 4: //Sağ Üst Köşe
                                            {                                                
                                                box_y = string.Format("ih-{0}", font_size);
                                                break;
                                            }
                                        case 5: //Manuel
                                            {
                                                box_y = mainForm.backY.Text;
                                                break;
                                            }
                                        case 6: // Orta Alt
                                            {
                                                box_y = string.Format("ih-{0}", font_size);
                                                break;
                                            }
                                        case 7: // Orta Üst
                                            {
                                                box_y = "0";
                                                break;
                                            }
                                        case 8: // Sağ Orta
                                            {
                                                box_y = "(ih-h)/2";
                                                break;
                                            }
                                        case 9: // Sol Orta
                                            {
                                                box_y = "(ih-h)/2";
                                                break;
                                            }
                                    }
                                    uygulanacak += string.Format(@",drawbox=y={0}:color={3}@0.{2}:width=iw:height={1}:t=max", box_y,font_size,opacity,box_color);
                                    break;
                                }
                            case "writer":
                                {
                                    break;
                                }
                        }
                    }
                
            }
           if(mainForm.writer.Checked)
           {
               string font_size = mainForm.boyut.Text;
               string font_file = Variables.FONT + "/" + mainForm.fontcombo.Text;
               if (!File.Exists(font_file))
               { SendMessage.Success(Messages.MSG_21[Language.ViewingLanguage], "Error!"); }
               string font_color = mainForm.yazi_renk.BackColor.Name;
               string yazi = mainForm.writerstr.Text;
               string giris = mainForm.y_giris.Text;
               string cikis = mainForm.y_cikis.Text;
               string background_color = mainForm.yazi_arka_renk.BackColor.Name;
               string x = string.Empty, y = string.Empty;
               switch (mainForm.yazikonum.SelectedIndex)
               {
                   case 0: // Tam Ortaya
                       {
                           x = "(w-tw)/2";
                           y = "(h-th)/2";
                           break;
                       }
                   case 2: // Sol Alt Köşe
                       {
                           x = "10";
                           y = "(h-th)-10";
                           break;
                       }
                   case 1: //Sol Üst Köşe
                       {
                           x = "10";
                           y = x;
                           break;
                       }
                   case 4: //Sağ Alt Köşe
                       {
                           x = "(w-tw)-10";
                           y = "(h-th)-10";
                           break;
                       }
                   case 3: //Sağ Üst Köşe
                       {
                           x = "(w-tw)-10";
                           y = "10";
                           break;
                       }
                   case 5: //Manuel
                       {
                           x = mainForm.backX.Text;
                           y = mainForm.backY.Text;
                           break;
                       }
                   case 6: // Orta Alt
                       {
                           x = "(main_w-tw)/2";
                           y = "main_h-th";
                           break;
                       }
                   case 7: // Orta Üst
                       {
                           x = "(main_w-tw)/2";
                           y = "5";
                           break;
                       }
                   case 8: // Sağ Orta
                       {
                           x = "(main_w-tw)";
                           y = "(main_h-th)/2";
                           break;
                       }
                   case 9: // Sol Orta
                       {
                           x = "5";
                           y = "(main_h-th)/2";
                           break;
                       }
               }
               if (mainForm.yazi_giris_durum.Checked)
               {
                   if (mainForm.yazi_arka_plan.Checked) // TransParent Arka Plan
                   {
                       uygulanacak += string.Format(@",drawtext='fontsize={0}:fontfile={1}:fontcolor={2}:text='{3}':x={4}:y={5}'", font_size, font_file, font_color, yazi, x, y);
                   }
                   else
                   {
                       uygulanacak += string.Format(@",drawtext='fontsize={0}:fontfile={1}:fontcolor={2}:box=1: boxcolor={6}:text='{3}':x={4}:y={5}'", font_size, font_file, font_color, yazi, x, y, background_color);
                   }
               }
               else
               {
                   if (mainForm.yazi_arka_plan.Checked) // TransParent Arka Plan
                   {
                       uygulanacak += string.Format(@",drawtext='fontsize={0}:fontfile={1}:fontcolor={2}:text='{3}':x={4}:y={5}:enable=between(t\,{6}\,{7})'", font_size, font_file, font_color, yazi, x, y, giris, cikis);
                   }
                   else
                   {
                       uygulanacak += string.Format(@",drawtext='fontsize={0}:fontfile={1}:fontcolor={2}:box=1: boxcolor={8}:text='{3}':x={4}:y={5}:enable=between(t\,{6}\,{7})'", font_size, font_file, font_color, yazi, x, y, giris, cikis, background_color);
                   }

               }
           }
            if (uygulanacak == string.Empty) return "";
            else return uygulanacak;
        }
    }
}
