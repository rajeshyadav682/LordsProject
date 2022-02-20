using LG_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Desktop.Common
{
    public class Global
    {
        public static List<FormDetails> OpenFormList = new List<FormDetails>();
        public static bool IsAdmin { get; set; }
    }
}
