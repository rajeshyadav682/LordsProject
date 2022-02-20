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
    public static string PostSalaryToEpicor(DataSet ds)
    {
        try
        {
            string PathForGroup = ConfigurationManager.AppSettings["PostGLGroup"].ToString();
            string PathForLines = ConfigurationManager.AppSettings["PostGLLine"].ToString();
            if (PathForGroup.Length > 0 && PathForLines.Length > 0)
            {
                String FileName;
                int isGroup = 1;
                foreach (DataTable dt in ds.Tables)
                {
                    if (isGroup == 1)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            FileName = @"" + PathForGroup + dr["GroupId"].ToString() + ".xml";
                            using (XmlTextWriter writer = new XmlTextWriter(FileName, System.Text.Encoding.UTF8))
                            {
                                writer.WriteStartDocument(true);
                                writer.WriteStartElement("Table");
                                writer.WriteStartElement("Row");
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    writer.WriteStartElement(dc.ColumnName);
                                    writer.WriteString(dr[dc].ToString());
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                            }
                            Thread.Sleep(1000); // 1 Seconds
                        }
                        isGroup = 0;
                        Thread.Sleep(60000); // 60 Seconds
                    }
                    FileName = @"" + PathForLines + dt.Rows[0]["GroupId"].ToString() + ".xml";
                    using (XmlTextWriter writer = new XmlTextWriter(FileName, System.Text.Encoding.UTF8))
                    {
                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("Table");
                        foreach (DataRow dr in dt.Rows)
                        {
                            writer.WriteStartElement("Row");
                            foreach (DataColumn dc in dt.Columns)
                            {
                                writer.WriteStartElement(dc.ColumnName);
                                writer.WriteString(dr[dc].ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }
            }
            return "OK";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public static string CreateEmployeeInEpicor(DataTable dtEmployee)
    {
        try
        {
            if (dtEmployee.Rows.Count == 0) { return ""; }
            DataRow dr = dtEmployee.Rows[0];
            string PathForEmployee = ConfigurationManager.AppSettings["PostEmployee"].ToString();
            if (PathForEmployee.Length > 0)
            {
                String FileName = @"" + PathForEmployee + dr["EmpCode"].ToString() + ".xml";
                using (XmlTextWriter writer = new XmlTextWriter(FileName, System.Text.Encoding.UTF8))
                {
                    writer.WriteStartDocument(true);
                    writer.WriteStartElement("Table");
                    writer.WriteStartElement("Row");
                    foreach (DataColumn dc in dtEmployee.Columns)
                    {
                        writer.WriteStartElement(dc.ColumnName);
                        writer.WriteString(dr[dc].ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            return "OK";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static string CreateDepartmentInEpicor(DataTable dtDept)
    {
        try
        {
            if (dtDept.Rows.Count == 0) { return ""; }
            DataRow dr = dtDept.Rows[0];
            string PathForEmployee = ConfigurationManager.AppSettings["PostDepartment"].ToString();
            if (PathForEmployee.Length > 0)
            {
                String FileName = @"" + PathForEmployee + dr["DeptId"].ToString() + ".xml";
                using (XmlTextWriter writer = new XmlTextWriter(FileName, System.Text.Encoding.UTF8))
                {
                    writer.WriteStartDocument(true);
                    writer.WriteStartElement("Table");
                    writer.WriteStartElement("Row");
                    foreach (DataColumn dc in dtDept.Columns)
                    {
                        writer.WriteStartElement(dc.ColumnName);
                        writer.WriteString(dr[dc].ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            return "OK";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    static string GetDirectoryPath(string RootPath, List<string> SubDirectorys)
    {
        string DirectoryPath = RootPath;
        foreach (string s in SubDirectorys)
        {
            DirectoryPath += (s.Length == 0 ? "UnKnown" : s) + "/";
        }
        return DirectoryPath;
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