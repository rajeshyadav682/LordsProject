using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
//using System.Configuration;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for GetEmployeeDetails
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class GetEmployeeDetails : System.Web.Services.WebService {

    //public GetEmployeeDetails () {

    //    //Uncomment the following line if using designed components 
    //    //InitializeComponent(); 
    //}

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}
    #region Employee
    [WebMethod(EnableSession = true)]
    public List<string> GetEmployeeNameAndEmpCode(string prefixText, int count)
    {
        try
        {
            return GetEmployees(prefixText, "ACTIVE");
            //DataTable Employees = DBM.GetDataTable("Sp_GetEmpNameAndEmpCode @KeyWord = '" + prefixText + "', @UserId = '"+Session["UserId"]+"'");
            //List<string> EmployeeList = new List<string>();
            //foreach (DataRow dr in Employees.Rows)
            //{
            //    EmployeeList.Add(dr["Employee"].ToString());
            //}
            //return EmployeeList;
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    [WebMethod(EnableSession = true)]
    public List<string> GetEmployeeNameAndEmpCodeForFullnFinal(string prefixText, int count)
    {
        try
        {
            return GetEmployees(prefixText, "FNF");
            //DataTable Employees = DBM.GetDataTable("GetEmployeeNameAndEmpCodeForFullnFinal @KeyWord = '" + prefixText + "', @UserId = '" + Session["UserId"] + "'");
            //List<string> EmployeeList = new List<string>();
            //foreach (DataRow dr in Employees.Rows)
            //{
            //    EmployeeList.Add(dr["Employee"].ToString());
            //}
            //return EmployeeList;
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    [WebMethod(EnableSession = true)]
    public List<string> GetALLEmployee(string prefixText, int count)
    {
        try
        {
            return GetEmployees(prefixText, "ALL");
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetALLInActiveEmployee(string prefixText, int count)
    {
        try
        {
            return GetEmployees(prefixText, "INACTIVE");
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetEmployeeFNFActive(string prefixText, int count)
    {
        try
        {
            return GetEmployees(prefixText, "FNFActive");
        }
        catch (Exception)
        {
            throw;
        }
    }


    [WebMethod(EnableSession = true)]
    public List<string> GetEmployeeFNFCompleted(string prefixText, int count)
    {
        try
        {
            return GetEmployees(prefixText, "FNFDONE");
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetUserNameAndCode(string prefixText, int count)
    {
        try
        {
            return GetEmployees(prefixText, "USER");
        }
        catch (Exception)
        {
            throw;
        }
    }
    List<string> GetEmployees(string KeyWord, string ReportType)
    {
        try
        {
            DataTable Employees = DBM.GetDataTable("Sp_GetEmpNameAndEmpCode @KeyWord = '" + KeyWord + "', @UserId = '" + Session["UserId"] + "', @ReportType = '" + ReportType + "'");
            List<string> EmployeeList = new List<string>();
            foreach (DataRow dr in Employees.Rows)
            {
                EmployeeList.Add(dr["Employee"].ToString());
            }
            return EmployeeList;
            //    string connString = ConfigurationManager.ConnectionStrings["SProll"].ConnectionString;
            //    SqlConnection con = new SqlConnection(connString);
            //    DataSet dtst = new DataSet();
            //    //string CompanyCode = HttpContext.Current.Session["CompanyCode"].ToString();
            //    SqlCommand sqlComd = new SqlCommand("[Sp_GetEmpNameAndEmpCode]", con);
            //    sqlComd.CommandType = CommandType.StoredProcedure;

            //    sqlComd.Parameters.AddWithValue("@KeyWord", prefixText);
            //    //sqlComd.Parameters.AddWithValue("@CompanyCode", CompanyCode);
            //    con.Open();
            //    SqlDataAdapter sqlAdpt = new SqlDataAdapter();
            //    sqlAdpt.SelectCommand = sqlComd;
            //    sqlAdpt.Fill(dtst);
            //    string[] cntName = new string[dtst.Tables[0].Rows.Count];
            //    int i = 0;
            //    try
            //    {
            //        foreach (DataRow rdr in dtst.Tables[0].Rows)
            //        {
            //            string EmpCode = rdr["EmpCode"].ToString().Replace("|", string.Empty);
            //            string EmployeeName = rdr["EmployeeName"].ToString().Replace("|", string.Empty);
            //            EmpCode = EmpCode.Replace("'", string.Empty);
            //            EmployeeName = EmployeeName.Replace("'", string.Empty);

            //            cntName.SetValue(EmployeeName + "(" + EmpCode + ")", i);

            //            i++;
            //        }
            //    }
            //    catch { }
            //    finally
            //    {
            //        con.Close();
            //    }
            //    return cntName;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    #endregion

    #region Project
    [WebMethod(EnableSession = true)]
    public List<string> GetProjectByEmpCode(string prefixText, int count)
    {
        try
        {
            return GetProjects(prefixText, count, Session["AttenProjectEmpCode"].ToString(), 1);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public List<string> GetProjectAllActive(string prefixText, int count)
    {
        try
        {
            return GetProjects(prefixText, count, "", 1);
        }
        catch (Exception)
        {
            throw;
        }
    }
    [WebMethod(EnableSession = true)]
    public List<string> GetProjectAll(string prefixText, int count)
    {
        try
        {
            return GetProjects(prefixText, count, "", -1);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public List<string> GetProjects(string prefixText, int count, string EmpCode, int Active)
    {
        try
        {
            SqlCommand Comd = DBM.GetCommandSP("getProjectCodeAndDescription");
            Comd.Parameters.AddWithValue("@KeyWord", prefixText);
            Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            Comd.Parameters.AddWithValue("@Active", Active);
            DataTable ProjectList = DBM.GetDataTable(Comd);
            return ProjectList.AsEnumerable().Select(x => x.Field<string>("Project")).ToList();

        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region Projectwfh
    [WebMethod(EnableSession = true)]
    public List<string> GetProjectByEmpCodeWFM(string prefixText, int count)
    {
        try
        {
            return GetProjectsWFM(prefixText, count, Session["AttenProjectEmpCode"].ToString(), 1);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
//-----------------------------------------
public List<string> GetProjectsWFM(string prefixText, int count, string EmpCode, int Active)
    {
        try
        {
            SqlCommand Comd = DBM.GetCommandSP("getProjectCodeAndDescriptionWFM");
            Comd.Parameters.AddWithValue("@KeyWord", prefixText);
            Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            Comd.Parameters.AddWithValue("@Active", Active);
            DataTable ProjectList = DBM.GetDataTable(Comd);
            int i = ProjectList.Rows.Count;
            return ProjectList.AsEnumerable().Select(x => x.Field<string>("Project")).ToList();

        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}
