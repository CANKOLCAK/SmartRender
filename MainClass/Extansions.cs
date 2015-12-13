using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRender.MainClass
{
    class Extansions
    {
        #region Uzantılar
        static public int count = 0;
        static public string[] desteklenen = new string[] { ".mp4", ".webm", ".mpeg4", ".avi", ".wmv", ".mpegps", ".flv", ".3gpp", ".wma", ".mov", ".movie", ".mkv",".mpg",".mp3",".ts",".m4v",".m2t",};
        static public Dictionary<string, int> extension = new Dictionary<string, int>();
        #endregion
    }
}
