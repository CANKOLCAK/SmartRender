using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRender.MainClass
{
    class Audio
    {
       static mainForm mainFrm = (mainForm)Application.OpenForms["mainForm"];
        static public string SoundFiliter(GroupBox Tab)
        {
            string filter = string.Empty;
            foreach (RadioButton echo in Tab.Controls)
            {
                if (echo.Checked)
                {
                    switch (echo.Name)
                    {
                        case "r11": // Orjinal Sound
                            {
                                filter = "volume=0.5";
                                break;

                            }
                        case "r1": // Echo 1
                            {
                                filter = "aecho=0.8:0.88:60:0.4";
                                break;

                            }
                        case "r2": // Echo 2
                            {
                                filter = "aecho=0.2:0.88:60:0.4";
                                break;

                            }
                        case "r3": // Echo 3
                            {
                                filter = "aecho=0.8:0.88:6:0.4";
                                break;

                            }
                        case "r4": // Echo 4
                            {
                                filter = "aecho=0.8:0.88:6:0.4";
                                break;

                            }
                        case "r5": // Yankı 1
                            {
                                filter = "aecho=0.8:0.9:1000|1800:0.3|0.25";
                                break;

                            }
                        case "r6": // Yankı 2
                            {
                                filter = "aecho=0.8:0.9:1000|1800:0.3|0.25";
                                break;

                            }
                        case "r7": // Baştan Hızlandırma
                            {
                                filter = "atrim=10:60";
                                break;

                            }
                        case "r8": // Boğuk Ses 2
                            {
                                filter = "chorus=0.6:0.9:50|60:0.4|0.32:0.25|0.4:2|1.3";
                                break;

                            }
                        case "r9": // Gürültü
                            {
                                filter = "chorus=0.7:0.9:55:0.4:0.25:2";
                                break;

                            }
                        case "r10": // Yankı 2
                            {
                                filter = "volume=40";
                                break;

                            }
                        case "manuel":
                            {
                                filter = string.Format(@"aecho={0}:{1}:{2}:{3}",mainFrm.ec1.Text,mainFrm.ec2.Text,mainFrm.ec3.Text,mainFrm.ec4.Text);
                                break;
                            }
                    }
                }
            }
            return filter;
        }
    
    }
}
