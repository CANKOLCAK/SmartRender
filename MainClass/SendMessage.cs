using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRender.MainClass
{
    class SendMessage
    {
        static public void Error(string message,string ErrorCode)
        {
            MessageBox.Show(message,ErrorCode,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        static public void Success(string message, string Title)
        {
            MessageBox.Show(message,Title,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
