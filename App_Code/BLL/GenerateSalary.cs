using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Reports.DataAccessLayer;

/// <summary>
/// Summary description for EmployeeBAL
/// </summary>
/// 
namespace Reports.DataAccessLayer
{
    public static class GenerateSalary
    {
        #region Monthly Attendance
        public static string GenerateMonthAttendance(string BranchCode,string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("GetEmployeeMonthlyAttendance");
            Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public static DataTable GetMonthlyAttendance()
        {
            return DBM.GetDataTable("SP_GetAttendance");
        }
        #endregion

        #region Monthly Salary
        public static void GenerateSalaryProcess(string BranchCode, string UserId)
        {
          
                SqlCommand Comd = DBM.GetCommandSP("Sp_SalaryCalculation_TaxRegimeType");//Sp_SalaryCalculation by ashu on 30 apr 2020               
                Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
                Comd.Parameters.AddWithValue("@UserId", UserId);
                DBM.WriteToDb(Comd);
            
            
               
           

        }
        public static DataTable GetSalary(string BranchCode)
        {
            return DBM.GetDataTable("SP_GetSalary '" + BranchCode + "'");
        }
        #endregion
    }
}