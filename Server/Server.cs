using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRender.Server
{
    class Server
    {
        static mainForm F1 = (mainForm)Application.OpenForms["MainForm"];
        static public void Open()
        {
        QPEN:
            try
            {
                TcpListener Dinle = new TcpListener(3322);
                Dinle.Start();
                dWrite("Sunucu Aktif Edildi");
                Socket Socket = Dinle.AcceptSocket();
                if (!Socket.Connected)
                {
                    dWrite("HATA : SUNUCU AKTIF EDILEMEDI!");
                }
                else
                {
                    while (true)
                    {
                        //dWrite("[SUNUCU] Ready!");
                        NetworkStream NS = new NetworkStream(Socket);
                        StreamReader SR = new StreamReader(NS);
                        StreamWriter SW = new StreamWriter(NS);

                        try
                        {
                            String gelen = SR.ReadLine();
                            dWrite(string.Format("[ANDROID] : {0}", gelen));
                            SW.WriteLine("SERVER OK");
                            SW.Flush();
                        }
                        catch
                        {
                            dWrite("HATA SUNUCU KAPATILDI!");
                        }
                    }
                }
                Dinle.Stop();
                Socket.Close();
                goto QPEN;
            }
            catch (Exception ex)
            {
                dWrite("HATA");
                goto QPEN;
            }
        }
        static public void dWrite(string str)
        {
            F1.dConsole.Text += Environment.NewLine + string.Format("{0} => {1}",str,DateTime.Now.ToString("H:mm:s"));
        }
    }
}
