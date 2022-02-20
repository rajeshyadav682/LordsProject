using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG_Desktop.Common
{
    public class LgCommon
    {

        public static void Log(string msg)
        {
            var path = StaticFields.EXECUTION_PATH + "\\Log.txt";
            DateTime dt = DateTime.Now;
            File.AppendAllText(path, dt.ToString("dd-MM-yyyy HH:mm:ss") + ": " + msg + "\n");
        }

        public static void Log(Exception ex,bool needToPopError = true)
        {
            if (needToPopError) ErrorBox("Error:"+ex.Message+"\n\nContact Admin..!");
            Log("Error:"+ex.Message+Environment.NewLine+ex.StackTrace);
        }

        public static void LockFormFields(object form,bool lockCtrl)
        {
            try
            {
                //find object type
                ControlCollection cc = null;
                if (form != null)
                {
                    if (form is Form)
                        cc = ((Form)form).Controls;
                    else if (form is TabPage)
                        cc = ((TabPage)form).Controls;
                    else if (form is Panel)
                        cc = ((Panel)form).Controls;

                }

                if (cc != null && cc.Count > 0)
                {
                    foreach(Control ctrl in cc)
                    {
                        if(string.IsNullOrEmpty(ctrl.AccessibleDefaultActionDescription) || !ctrl.AccessibleDefaultActionDescription.Equals("IgnoreLock"))
                        {
                            Type ofCtrl = ctrl.GetType();
                            if ((typeof(LGTextBox) == ofCtrl) || (typeof(LGNumericTextBox) == ofCtrl) || (typeof(LGDateTimePicker) == ofCtrl) || (typeof(ComboBox) == ofCtrl) || (typeof(CheckBox) == ofCtrl) || (typeof(NumericUpDown) == ofCtrl))
                            {
                                ctrl.Enabled = ! lockCtrl;
                            }
                            else if (ctrl is TabControl)
                                foreach (var page in ((TabControl)ctrl).TabPages)
                                    LockFormFields(page, lockCtrl);
                            else if (ctrl is Panel)
                                    LockFormFields(((Panel)ctrl), lockCtrl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        public static List<string> PlanTypeList()
        {
            var planTypeList = new List<string>();
            try
            {
                planTypeList.Add("");
                planTypeList.Add("Monthly");
                planTypeList.Add("Quaterly");
                planTypeList.Add("Semi Annualy");
                planTypeList.Add("Annualy");
            }
            catch (Exception ex)
            {
                LgCommon.Log(ex);
            }
            return planTypeList;
        }

        public static string DateString(DateTime date) => date.ToShortDateString();

        public static bool CheckSecurity(FormActions formActions)
        {
            return true;
        }

        public static bool ConfirmBox(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                DialogResult result = MessageBox.Show(msg, StaticFields.APP_NAME, MessageBoxButtons.YesNo);
                return result == DialogResult.Yes;
            }
            else
                return false;
        }

        public static void ErrorBox(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show(msg, StaticFields.APP_NAME, MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public static void InformationBox(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show(msg, StaticFields.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
