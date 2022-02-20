using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Utility;

/// <summary>
/// Summary description for UtilityUI
/// </summary>
public partial class UtilityUI : Utility.UtilityUI
{
    //static string ExcelFile { get { return "Excel"; } }
    //static string DocFile { get { return "Doc"; } }
    public static void RedirectToPrint(Page p)
    {
        ScriptManager.RegisterStartupScript(p, p.GetType(), "Key", "window.open('Print.aspx');", true);
    }
    public static void RedirectToPrintSSRS(Page p)
    {
        ScriptManager.RegisterStartupScript(p, p.GetType(), "Key", "window.open('PrintReport.aspx');", true);
    }
    public static void RedirectToURL(Page p, string URL)
    {
        ScriptManager.RegisterStartupScript(p, p.GetType(), "Key", "window.open('"+URL+"');", true);
    }
  
    static bool UploadFile(Page p, FileUpload fileUpload, string DirectoryPath, out string FilePhysicalPath, out string rslt)
    {
        try
        {
            string ServerPath = p.Server.MapPath(DirectoryPath);
            if (!Directory.Exists(ServerPath))
            {
                Directory.CreateDirectory(ServerPath);
            }
            string FileName = System.DateTime.Now.ToString("yyMMddhhmmss_") + Path.GetFileName(fileUpload.PostedFile.FileName);
            FilePhysicalPath = DirectoryPath + FileName;
            fileUpload.SaveAs(p.Server.MapPath(FilePhysicalPath));
            rslt = "OK";
            return true;
        }
        catch (Exception ex)
        {
            FilePhysicalPath = "";
            rslt = ex.Message;
            return false;
        }
    }
    
 
}