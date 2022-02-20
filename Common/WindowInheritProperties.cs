using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG_Desktop
{
    public class LGTextBox : System.Windows.Forms.TextBox 
    {

    }

    public class LGLabel : System.Windows.Forms.Label
    {
        public LGLabel()
        {
            this.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }
    }

    public class LGButton : System.Windows.Forms.Button
    {
    }

    public class LGDateTimePicker : System.Windows.Forms.DateTimePicker
    {

    }

    public class LGNumericTextBox : System.Windows.Forms.TextBox
    {
        private byte m_decimalPlaces = 2;

        internal LGNumericTextBox()
        {
            this.MaxLength = 10;
            //this.DecimalPlaces = 2;
            this.TextAlign = HorizontalAlignment.Right;
        }

        internal Decimal Number 
        {
            get {
                if (string.IsNullOrEmpty(this.Text))
                    return 0;
                else
                    return Decimal.Parse(this.Text);
            }
            set{
                this.Text = string.Format(value.ToString(), "n" + m_decimalPlaces);
            } 
        }
    }
}
