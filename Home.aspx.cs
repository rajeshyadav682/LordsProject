using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Reports.DataAccessLayer;
using System.Globalization;
using Utility;
using System.Net;

public partial class Home : System.Web.UI.Page
{
    SqlBAL sBal = new SqlBAL();
    Utility.DBM db = new Utility.DBM(ConfigurationManager.ConnectionStrings["con"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
           // sendmail();
            if (Session.Count > 0)
            {
                txtUserName.Text = txtPassword.Text = "";
                Session.Clear();
               // sendmail();
            }
        }
        catch (Exception ex)
        {
            this.ShowAlert(ex.Message);
            //throw;
        }
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;
            string rslt;
            if (UserName.Length == 0)
            {
                this.ShowAlert("Please Enter UserName");
                return;
            }
            if (Password.Length == 0)
            {
                this.ShowAlert("Please Enter Correct Password");
                return;
            }
            SqlCommand Comd = DBM.GetCommandSP("Sp_UserLogin");
            Comd.Parameters.AddWithValue("@Username", UserName);
            Comd.Parameters.AddWithValue("@Password", Password);
            DataTable dt = DBM.GetDataTable(Comd, out rslt);
            if (rslt != "OK")
            {
                this.ShowAlert(rslt);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowAlert("Invalid Id or Password");
                return;
            }
            Session["UserName"] = dt.Rows[0]["UserName"];
            Session["RoleId"] = dt.Rows[0]["RoleId"];
            Session["Name"] = dt.Rows[0]["Name"];
            Session["UserNameCode"] = dt.Rows[0]["UserNameCode"];
            Session["RoleId"] = dt.Rows[0]["RoleId"];
            //Session["Image"] = dt.Rows[0]["ImagesPath"];
            Session["DateOfJoining"] = dt.Rows[0]["DateOfJoining"];
            Session["DefaultPage"] = dt.Rows[0]["DefaultPage"];
            //Application["OrganizationAddress"] = dt.Rows[0]["OrganizationAddress"];
            Response.Redirect(Session["DefaultPage"].ToString());
        }
        catch (Exception ex)
        {
            this.ShowAlert(ex.Message);
            //throw;
        }
    }

    public void sendmail()
    {
        System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage();
        mm.To.Add(new System.Net.Mail.MailAddress("rajesh.yadav@corporateserve.com", "Name"));
        mm.From = new System.Net.Mail.MailAddress("payroll@taikishaindia.com");
        mm.Sender = new System.Net.Mail.MailAddress("payroll@taikishaindia.com", "Name");
        mm.Subject = "This is Test Email";
        mm.Body = "<h3>This is Testing SMTP Mail Send By Me</h3>";
        mm.IsBodyHtml = true;
        mm.Priority = System.Net.Mail.MailPriority.High; // Set Priority to sending mail
        System.Net.Mail.SmtpClient smtCliend = new System.Net.Mail.SmtpClient();
        smtCliend.Host = "secure.emailsrvr.com";
        smtCliend.Port = 587;    // SMTP port no            
        smtCliend.Credentials = new NetworkCredential("payroll@taikishaindia.com", "Teipl@1986");
        smtCliend.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        try
        {
            smtCliend.Send(mm);
        }
        catch (System.Net.Mail.SmtpException ex)
        {
           // lblMsg.Text = ex.ToString();
        }
        catch (Exception exe)
        {
          //  lblMsg.Text = "\n\n\n" + exe.ToString();
        }
    }
}