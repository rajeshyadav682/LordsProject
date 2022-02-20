using System;
using Reports.DataAccessLayer;

public partial class ChangePassword : System.Web.UI.Page
{
    EmployeeBAL EmpBal = new EmployeeBAL();
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            lblMessage.Text = "";
            if (txtOldPassword.Text == "")
            {
                UtilityUI.ShowAlert(this, "w", "Enter Old Password");
            }

            else if (txtNewPassword.Text == "")
            {
                UtilityUI.ShowAlert(this, "w", "Enter New Password");
            }
            else if (txtConfirmPassword.Text == "")
            {
                UtilityUI.ShowAlert(this, "w", "Confirm Password");
            }
            else if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                UtilityUI.ShowAlert(this, "w", "New Password and Confirm Password does not match");
            }
            else
            {
                string rslt = EmpBal.chagePassword(Session["UserName"].ToString(), txtOldPassword.Text.Trim(), txtNewPassword.Text.Trim());
                if (rslt.ToUpper() == "OK")
                {
                    UtilityUI.ShowAlert(this, "s", "Password Changed Successfully");
                    ////Response.AppendHeader("Refresh", "5;url=Home.aspx");
                    //HtmlMeta meta = new HtmlMeta();
                    //meta.HttpEquiv = "Refresh";
                    //meta.Content = "5;url=Home.aspx";
                    //this.Page.Controls.Add(meta);
                    //lblMessage.Text = "Password Changed Successfully, You will now be log out in 5 seconds";
                }
                else
                {
                    UtilityUI.ShowAlert(this, "w", rslt);
                }
            }
        }
        catch (Exception ex )
        {
            lblMessage.Text = ex.Message;
        }
    }
}