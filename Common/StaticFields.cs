using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LG_Desktop.Common
{
    internal class StaticFields
    {
        internal static string APP_NAME = "LOARD'S GYM";

        internal static string EXECUTION_PATH = Environment.CurrentDirectory;

        internal static string FILE_NAME = "LordClients";

        internal static string FILE_EXTENSION = ".xlsx";

        internal static string GET_DIRECTORY = Directory.GetCurrentDirectory();

        internal static string IMAGE_FOLDER = GET_DIRECTORY + "\\Assest\\ClientImages\\";

        internal static string GET_SET_IMAGE(string fileName)=>  IMAGE_FOLDER+fileName+".jpg";

        internal static System.Drawing.Size ChileFormSize()
        {
            var a = new System.Drawing.Size();
            a.Width = 1400;
            a.Height = 710;
            return a;
        }
    }
}
