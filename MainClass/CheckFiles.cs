using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
namespace SmartRender.MainClass
{
    class CheckFiles
    {
        static string home = "http://smart-render.com/store/";
        static public bool CheckIfFileExistsOnServer(string fileName)
        {
           /* var request = (FtpWebRequest)WebRequest.Create("ftp://smart-render.com/httpdocs/store/" + fileName);
            request.Credentials = new NetworkCredential("id", "pw");
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }*/

            return false;
        }
        static public string Check(string File)
        {
            WebClient web = new WebClient();
            string str = web.DownloadString(string.Format("http://api.smart-render.com/type.php?file={0}",File));
            switch(str)
            {
                case "BACKGROUND":
                    {
                        str = "Background/";
                        break;
                    }
                case "FILTER":
                    {
                        str = "Filter/";
                        break;
                    }
                case "FRAME":
                    {
                        str = "Frame/";
                        break;
                    }
                default :
                    {
                        str = "error";
                        break;
                    }
            }
            return str;
        }
        static public void xDownloadFiles(string file, string savePath)
        {
            mainForm mainForm = (mainForm)Application.OpenForms["mainForm"];
            WebClient Client = new WebClient();
            Client.DownloadFileAsync(new Uri(string.Format("{0}{1}",home,file)),savePath +Path.GetFileName(file));
            Client.DownloadProgressChanged += delegate(object pChanged, DownloadProgressChangedEventArgs val)
            {
                mainForm.dConsole.Text += string.Format("\n {1} İndiriliyor.. %{0}",val.ProgressPercentage,file);
            };
            Client.DownloadFileCompleted += delegate(object sender, AsyncCompletedEventArgs e)
            {
                mainForm.dConsole.Text += string.Format("\n{0} başarıyla indirildi!",file);
            };
        }
    }
}
