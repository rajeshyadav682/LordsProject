using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG_Desktop.Model
{
    public class FormDetails
    {
        public FormDetails(Form f)
        {
            this.FromObj = f;
            this.FormID = int.Parse(string.IsNullOrEmpty(f.AccessibleName)?"1":f.AccessibleName);
            this.FormName = f.Text;
        }
        public Form FromObj { get; set; }
        public string FormName { get; set;}
        public int FormID { get; set; }

    }
}
