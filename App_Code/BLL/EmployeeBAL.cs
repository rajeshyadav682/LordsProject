using Reports.DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlTypes;


namespace Reports.DataAccessLayer
{

    public class EmployeeBAL : SqlDataAccessLayer
    {

        public EmployeeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetEmpCodeFromMaster()
        {
            DataTable dt = new DataTable();
            SqlConnection conState = new SqlConnection(_strconnectionString);
            SqlCommand cmdState = new SqlCommand("[SP_GetEmpCodeFromMaster]", conState);
            //cmdState.Connection = conState;
            conState.Open();
            cmdState.CommandTimeout = 10000;
            cmdState.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdState);
            Sqladpter.Fill(dt);
            conState.Close();
            return dt;
        }
        

        
        public string GetEmployeeCode(string EmpCodeWithName)
        {
            string EmpCode = string.Empty;
            if (EmpCodeWithName.Trim().IndexOf('(') > 0 && EmpCodeWithName.Trim().IndexOf(')') > 0)
            {

                string[] strMaterial = EmpCodeWithName.Trim().Split('(');
                EmpCode = (strMaterial[1].ToString());
                EmpCode = EmpCode.Replace(')', ' ');
                EmpCode = EmpCode.Trim();
            }
            else
            {
                EmpCode = "";
            }
            return EmpCode;
        }
        



        #region Bind Role--------------------------
        public DataTable GetRole()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("[SP_GetRole]", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }
        #endregion


        public DataTable GetPlan()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("sp_getPlan", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }
        public DataTable GetDiscountdetails(string planid)
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("getdiscountdetails", concity);
            cmd.Parameters.AddWithValue("@plan", planid);
            cmd.Connection = concity;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            Sqladpter.Fill(dt);
            return dt;

        }


        public string CreateClient(string FullName, string Age, DateTime DOJ, String Contact, String Plan, string Address, bool Isactive, string Desc, string Role, out string ClientCode)
        {
            SqlCommand cmd = DBM.GetCommandSP("SP_InsertClient");
            cmd.Parameters.AddWithValue("@FullName", FullName);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@DOJ", DOJ);
            cmd.Parameters.AddWithValue("@ContactNo", Contact);
            cmd.Parameters.AddWithValue("@Plan", Plan);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Isactive", Isactive);
            cmd.Parameters.AddWithValue("@desc", Desc);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.Add("@ClientCode", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            string rslt = DBM.WriteToDbWithOutput(cmd);
            ClientCode = cmd.Parameters["@ClientCode"].Value.ToString();
            return rslt;
        }



        public string UpdateClient(string ClientCode, string FullName, string Age, DateTime DOJ, String Contact, String Plan, string Address, bool Isactive, string Desc, string Role)
        {
            SqlCommand cmd = DBM.GetCommandSP("SP_Updateclient");
            cmd.Parameters.AddWithValue("@ClientCode", ClientCode);
            cmd.Parameters.AddWithValue("@FullName", FullName);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@DOJ", DOJ);
            cmd.Parameters.AddWithValue("@ContactNo", Contact);
            cmd.Parameters.AddWithValue("@Plan", Plan);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Isactive", Isactive);
            cmd.Parameters.AddWithValue("@desc", Desc);
            cmd.Parameters.AddWithValue("@Role", Role);
            return DBM.WriteToDbWithOutput(cmd);
        }


        public DataTable GetCodeFromMaster()
        {
            DataTable dt = new DataTable();
            SqlConnection conState = new SqlConnection(_strconnectionString);
            SqlCommand cmdState = new SqlCommand("[SP_GetCodeFromMaster]", conState);
            //cmdState.Connection = conState;
            conState.Open();
            cmdState.CommandTimeout = 10000;
            cmdState.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdState);
            Sqladpter.Fill(dt);
            conState.Close();
            return dt;
        }



        public DataTable BindClientsDetails(string DOJ, string EmpCode)
        {
            DataTable dt = new DataTable();
            SqlConnection concnt = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("SP_FindClients", concnt);
            cmd.Connection = concnt;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@DOJ", (DOJ != "") ? DOJ : Convert.DBNull);
            cmd.Parameters.AddWithValue("@UserName", (EmpCode != "") ? EmpCode : Convert.DBNull);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable GetAllClientDetail(string ClientCode)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetClientDetail");
            Comd.Parameters.AddWithValue("@ClientCode", ClientCode);
            return DBM.GetDataTable(Comd);
        }


        //public DataTable GetDivision()
        //{
        //    return DBM.GetDataTable("SP_GetDivision");
        //}
    }
}
