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

/// <summary>
/// Summary description for EmployeeBAL
/// </summary>
/// 
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

        #region Bind EmpCode from Master--------------------------

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
        #endregion

        #region GetEmployee Code ====================
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
        #endregion

        

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


        #region Bind City--------------------------

        public DataTable GetCityName()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("SP_GetCityName", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion

        #region Bind Department--------------------------

        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("[SP_GetDepartment]", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion

        #region Bind Employee band--------------------------

        //public DataTable GetEmployeeBand()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection concity = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdcity = new SqlCommand("SP_GetEmployeeBand", concity);
        //    //cmdcity.Connection = concity;
        //    concity.Open();
        //    cmdcity.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
        //    Sqladpter.Fill(dt);
        //    concity.Close();
        //    return dt;
        //}
        public DataTable GetEmployeeSubGrade(string GradeCode)
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("GetSubGradeByGradeCode", concity);
            concity.Open();
            cmdcity.CommandType = CommandType.StoredProcedure;
            cmdcity.Parameters.AddWithValue("@GradeCode", GradeCode);
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            concity.Close();
            return dt;
        }
        #endregion

        #region Bind State--------------------------

        public DataTable GetStateName()
        {
            DataTable dt = new DataTable();
            SqlConnection conState = new SqlConnection(_strconnectionString);
            SqlCommand cmdState = new SqlCommand("SP_GetStateName", conState);
            //cmdState.Connection = conState;
            conState.Open();
            cmdState.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdState);
            Sqladpter.Fill(dt);
            conState.Close();
            return dt;
        }
        #endregion

        #region Bind Country--------------------------

        public DataTable GetCountryName()
        {
            DataTable dt = new DataTable();
            SqlConnection concnt = new SqlConnection(_strconnectionString);
            SqlCommand cmdcnt = new SqlCommand("SP_GetCountryName", concnt);
            cmdcnt.Connection = concnt;
            cmdcnt.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcnt);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion

        #region Insert/ Update Employee--------------------------
        //rslt = EmpBal.CreateEmployee("LG001", FullName.ToUpper(), Age, DOJ, ContactNo,Plan, out ClientCode) ;
        public string CreateClient(string FullName,string Age,DateTime DOJ,String Contact,String Plan,string Address,bool Isactive,string Desc,string Role, out string ClientCode)
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


        #region Bind EmpCode from Master--------------------------

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
        #endregion

        public string EditEmployee_Self(string EmpCode, string Imagepath, string Address, string City, string State, string Country, string pincode,
                string PAddress, string PCity, string PState, string PCountry, string PPincode, string PContactNo,
                string RName, string RMobileNo, string REmail, string RAddess, string RCity, string RState, string RCountry, string RPincode, string UserId)
        {
            SqlCommand cmd = DBM.GetCommandSP("SP_EditEmployee_Self");
            cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
            cmd.Parameters.AddWithValue("@Imagepath", Imagepath);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@pincode", pincode);
            cmd.Parameters.AddWithValue("@PAddress", PAddress);
            cmd.Parameters.AddWithValue("@PCity", PCity);
            cmd.Parameters.AddWithValue("@PState", PState);
            cmd.Parameters.AddWithValue("@PCountry", PCountry);
            cmd.Parameters.AddWithValue("@PPincode", PPincode);
            cmd.Parameters.AddWithValue("@PContactNo", PContactNo);
            cmd.Parameters.AddWithValue("@RName", RName);
            cmd.Parameters.AddWithValue("@RMobileNo", RMobileNo);
            cmd.Parameters.AddWithValue("@REmail", REmail);
            cmd.Parameters.AddWithValue("@RAddess", RAddess);
            cmd.Parameters.AddWithValue("@RCity", RCity);
            cmd.Parameters.AddWithValue("@RState", RState);
            cmd.Parameters.AddWithValue("@RCountry", RCountry);
            cmd.Parameters.AddWithValue("@RPincode", RPincode);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(cmd);
        }
        #endregion

        //#region Update Emp Personal Detail--------------------------

        //public string UpdateEmpPersonalDetailss(string CommEmpCode,string  BloodGroup, string BirthDate, string MaritalStatus, string MarriageDate, string ESINo,string  ESIDespensary,
        //    string  PFNo,string  DLNumber,string  SocialSecurityNo,
        //    string RecordedBy, string Password, string LatestPayEffectiveDate,string degree,string ClassName, string BoardName, string YearOfPassing, string percent, string Remark)
        //{
        //    string EmployeeCode = string.Empty;
        //    DataTable dt = new DataTable();
        //    SqlConnection con = new SqlConnection(_strconnectionString);
        //    SqlCommand cmd = new SqlCommand("[SP_InsertPersonalDetail]", con);
        //    //cmdcnt.Connection = concnt;
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
        //    cmd.Parameters.Add("@CommEmpCode", CommEmpCode);
        //    cmd.Parameters.Add("@BloodGroup", BloodGroup);
        //    cmd.Parameters.Add("@BirthDate", BirthDate);
        //    cmd.Parameters.Add("@MaritalStatus", MaritalStatus);
        //    cmd.Parameters.Add("@MarriageDate", MarriageDate);
        //    cmd.Parameters.Add("@ESINo", ESINo);
        //    cmd.Parameters.Add("@ESIDespensary", ESIDespensary);
        //    cmd.Parameters.Add("@PFNo", PFNo);
        //    cmd.Parameters.Add("@DLNumber", DLNumber);
        //    cmd.Parameters.Add("@SocialSecurityNo", SocialSecurityNo);
        //    cmd.Parameters.Add("@RecordedBy", RecordedBy);
        //    cmd.Parameters.Add("@Password", Password);
        //    cmd.Parameters.Add("@LatestPayEffectiveDate", LatestPayEffectiveDate);
        //    cmd.Parameters.Add("@degree", degree);
        //    cmd.Parameters.Add("@ClassName", ClassName);
        //    cmd.Parameters.Add("@BoardName", BoardName);
        //    cmd.Parameters.Add("@YearOfPassing", YearOfPassing);
        //    cmd.Parameters.Add("@percent", percent);
        //    cmd.Parameters.Add("@Remark", Remark);

        //    cmd.Parameters.Add("@return", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
        //    cmd.ExecuteNonQuery();
        //    EmployeeCode = cmd.Parameters["@return"].Value.ToString();
        //    con.Close();
        //    return EmployeeCode;
        //}
        //#endregion

        //#region Employee Communication Update--------------------------

        //public string CreateEmployeeCommunications(string CommEmpCode, string fatherName, string husbandName, string motherName, string permanentAddress, string perPincode, 
        //    string perCity, string perState, string perCountry, string altEmail, string companyEmail, string percontactNo)
        //{
        //    try
        //    {
        //        SqlConnection concnt = new SqlConnection(_strconnectionString);
        //        SqlCommand cmd = new SqlCommand("SP_UpdateCommunication", concnt);
        //        concnt.Open();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);

        //        cmd.Parameters.AddWithValue("@CommEmpCode", CommEmpCode);
        //        cmd.Parameters.AddWithValue("@fatherName", fatherName);
        //        cmd.Parameters.AddWithValue("@husbandName", husbandName);
        //        cmd.Parameters.AddWithValue("@motherName", motherName);
        //        cmd.Parameters.AddWithValue("@permanentAddress", permanentAddress);
        //        cmd.Parameters.AddWithValue("@perPincode", perPincode);
        //        cmd.Parameters.AddWithValue("@perCity", perCity);
        //        cmd.Parameters.AddWithValue("@perState", perState);
        //        cmd.Parameters.AddWithValue("@perCountry", perCountry);
        //        cmd.Parameters.AddWithValue("@altEmail", altEmail);
        //        cmd.Parameters.AddWithValue("@companyEmail", companyEmail);
        //        cmd.Parameters.AddWithValue("@percontactNo", percontactNo);
        //        cmd.ExecuteNonQuery();
        //        return "1";
        //        concnt.Close();
        //    }
        //    catch(Exception ex)
        //    {
        //        return "0";
        //    }
        //}
        //#endregion

        #region Find Employee--------------------------

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
        #endregion


        #region All Detail Of Employee for Edit--------------------------

        public DataTable GetAllClientDetail(string ClientCode)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetClientDetail");
            Comd.Parameters.AddWithValue("@ClientCode", ClientCode);
            return DBM.GetDataTable(Comd);
        }
        public DataTable GetEmployeeData(string EmpCode)
        {
            SqlCommand Comd = DBM.GetCommandSP("GetEmployeeData");
            Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            return DBM.GetDataTable(Comd);
        }
        #endregion

        #region Insert family Detail--------------------------

        //public string InsertFamilyDetail(string EmpCode, string Relation, string Name, string DOB, string Age, string Occupation, string RecordType)
        //{
        //    string EmployeeCode = string.Empty;
        //    DataTable dt = new DataTable();
        //    SqlConnection con = new SqlConnection(_strconnectionString);
        //    SqlCommand cmd = new SqlCommand("[SP_InsertUpdateFamilyDetail]", con);
        //    //cmdcnt.Connection = concnt;
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
        //    cmd.Parameters.Add("@EmpCode", EmpCode);
        //    cmd.Parameters.Add("@Relation", Relation);
        //    cmd.Parameters.Add("@Name", Name);
        //    cmd.Parameters.Add("@DOB", DOB);
        //    cmd.Parameters.Add("@Age", Age);
        //    cmd.Parameters.Add("@Occupation", Occupation);
        //    cmd.Parameters.Add("@RecordType", RecordType);
        //    cmd.Parameters.Add("@return", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
        //    cmd.ExecuteNonQuery();
        //    EmployeeCode = cmd.Parameters["@return"].Value.ToString();
        //    con.Close();
        //    return EmployeeCode;
        //}
        #endregion

        #region vikrant updation-------------

        public DataTable GetData(string query)
        {
            SqlConnection con = new SqlConnection(_strconnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Sqladpter.Fill(dt);
            con.Close();
            return dt;
        }
        public int ExecuteNonQuery(string qry)
        {
            SqlConnection con = new SqlConnection(_strconnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            int r = cmd.ExecuteNonQuery();
            con.Close();
            return r;
        }

        public void CreateDesignation(string DesgId, string DesgName)
        {
            // string DesignationId = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("SP_InsertDesignation", con);
            //cmdcnt.Connection = concnt;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@DesgId", DesgId);
            cmd.Parameters.Add("@DesgName", DesgName);
            // cmd.Parameters.Add("@return", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //DesignationId = cmd.Parameters["@return"].Value.ToString();
            con.Close();

        }

        public DataTable UpdateDesignation(string DesgId, string DesgName)
        {
            DataTable dt = new DataTable();
            SqlConnection concnt = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("[SP_InsertDesignation]", concnt);
            cmd.Connection = concnt;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@DesgId", DesgId);
            cmd.Parameters.AddWithValue("@DesgName", DesgName);
            Sqladpter.Fill(dt);
            return dt;
        }

        public void CreateBranch(string BranchCode, string BranchName, string BranchHead, string StateId, string CityName, string CtrName)
        {
            // string DesignationId = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("SP_InsertUpdateBranch", con);
            //cmdcnt.Connection = concnt;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@BranchCode", BranchCode);
            cmd.Parameters.Add("@BranchName", BranchName);
            cmd.Parameters.Add("@BranchHead", BranchHead);
            cmd.Parameters.Add("@StateId", StateId);
            cmd.Parameters.Add("@CityCode", CityName);
            cmd.Parameters.Add("@CntId", CtrName);
            // cmd.Parameters.Add("@return", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //DesignationId = cmd.Parameters["@return"].Value.ToString();
            con.Close();
        }

        public DataTable UpdateBranch(string BranchCode, string BranchName, string BranchHead, string StateId, string Citycode, string CntId)
        {
            DataTable dt = new DataTable();
            SqlConnection concnt = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("[SP_InsertUpdateBranch]", concnt);
            cmd.Connection = concnt;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@BranchCode", BranchCode);
            cmd.Parameters.AddWithValue("@BranchName", BranchName);
            cmd.Parameters.AddWithValue("@BranchHead", BranchHead);
            cmd.Parameters.AddWithValue("@StateId", StateId);
            cmd.Parameters.AddWithValue("@Citycode", Citycode);
            cmd.Parameters.AddWithValue("@CntId", CntId);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable GetBranch()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("SP_GetBranch", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }

        #endregion

        #region Bind Employee Qualification=============
        public DataTable BindQualification(string EmpCode)
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("SP_BindEmpQualification", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            cmdcity.Parameters.AddWithValue("@EmpCode", EmpCode);
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }
        #endregion

        #region Bind Relation--------------------------

        public DataTable GetRelation()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("SP_GetRelation", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }
        #endregion

        #region Bind Occupation--------------------------
        public DataTable GetOccupation()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("SP_GetOccupation", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }
        #endregion
        #region Bind FamilyDetail--------------------------
        public DataTable GetFamilyDetail(string EmpCode)
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("SP_GetFamilyDetail", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            cmdcity.Parameters.AddWithValue("@EmpCode", EmpCode);
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }
        #endregion

        #region Bind Work Experiance--------------------------
        public DataTable GetWorkExperiance(string EmpCode)
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("SP_GetWorkExperiance", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            cmdcity.Parameters.AddWithValue("@EmpCode", EmpCode);
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }
        #endregion


        public string UpdateFamilyDetail(string EmpCodeFD, string Name, string relation, string Qualification, string Occupation, string MobileNo, string DateOfBirth, string Remarks, string Dependent, string Userid)
        {
            string EmployeeCode = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("[SP_InsertFamilyDetail]", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpCodeFD", EmpCodeFD);
            cmd.Parameters.Add("@relation", relation);
            cmd.Parameters.Add("@Name", Name);
            cmd.Parameters.Add("@Qualification", Qualification);
            cmd.Parameters.Add("@DateOfBirth", DateOfBirth);
            cmd.Parameters.Add("@MobileNo", MobileNo);
            cmd.Parameters.Add("@Occupation", Occupation);
            cmd.Parameters.Add("@Remarks", Remarks);
            cmd.Parameters.Add("@Dependent", Dependent);
            cmd.Parameters.Add("@Userid", Userid);
            cmd.Parameters.Add("@return", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            EmployeeCode = cmd.Parameters["@return"].Value.ToString();
            con.Close();
            return EmployeeCode;
        }

        public void InsertQualification(string EmpCode, string QualiCode, string University, string FromDate, string ToDate, string Type, string Grade, string Percent, string Remarks, string Userid)
        {
            SqlCommand cmd = DBM.GetCommandSP("[SP_InsertEmpQualification]");
            cmd.Parameters.Add("@EmpCode", EmpCode);
            cmd.Parameters.Add("@QualiCode", QualiCode);
            cmd.Parameters.Add("@University", University);
            cmd.Parameters.Add("@FromDate", FromDate);
            cmd.Parameters.Add("@ToDate", ToDate);
            cmd.Parameters.Add("@Type", Type);
            cmd.Parameters.Add("@Grade", Grade);
            cmd.Parameters.Add("@Percent", Percent);
            cmd.Parameters.Add("@Remarks", Remarks);
            cmd.Parameters.Add("@Userid", Userid);
            DBM.WriteToDb(cmd);
        }
        public void UpdateQualification(string Sno, string EmpCode, string QualiCode, string University, string FromDate, string ToDate, string Type, string Grade, string Percent, string Remarks, string Userid)
        {
            SqlCommand cmd = DBM.GetCommandSP("[SP_UpdateEmpQualification]");
            cmd.Parameters.Add("@Sno", Sno);
            cmd.Parameters.Add("@EmpCode", EmpCode);
            cmd.Parameters.Add("@QualiCode", QualiCode);
            cmd.Parameters.Add("@University", University);
            cmd.Parameters.Add("@FromDate", FromDate);
            cmd.Parameters.Add("@ToDate", ToDate);
            cmd.Parameters.Add("@Type", Type);
            cmd.Parameters.Add("@Grade", Grade);
            cmd.Parameters.Add("@Percent", Percent);
            cmd.Parameters.Add("@Remarks", Remarks);
            cmd.Parameters.Add("@Userid", Userid);
            DBM.WriteToDb(cmd);
        }
        public void DeleteQualification(string Sno)
        {
            SqlCommand cmd = DBM.GetCommandSP("[SP_deleteEmpQualification]");
            cmd.Parameters.Add("@Sno", Sno);
            DBM.WriteToDb(cmd);
        }
        //==============================================================End============================================================================
        public string WorkExpInsert(string EmpCode, string CompanyName, string LastDepartment, string LastDesignation, string LastSalaryDrawn, string FromDate, string ToDate, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_UpdateEmployeeWorkExp");
            Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            Comd.Parameters.AddWithValue("@CompanyName", CompanyName);
            Comd.Parameters.AddWithValue("@LastDepartment", LastDepartment);
            Comd.Parameters.AddWithValue("@LastDesignation", LastDesignation);
            Comd.Parameters.AddWithValue("@LastSalaryDrawn", LastSalaryDrawn);
            Comd.Parameters.AddWithValue("@FromDate", FromDate);
            Comd.Parameters.AddWithValue("@ToDate", ToDate);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string WorkExpUpdate(string Sno, string EmpCode, string CompanyName, string LastDepartment, string LastDesignation, string LastSalaryDrawn, string FromDate, string ToDate, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_UpdateEmployeeWorkExp");
            Comd.Parameters.AddWithValue("@Sno", Sno);
            Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            Comd.Parameters.AddWithValue("@CompanyName", CompanyName);
            Comd.Parameters.AddWithValue("@LastDepartment", LastDepartment);
            Comd.Parameters.AddWithValue("@LastDesignation", LastDesignation);
            Comd.Parameters.AddWithValue("@LastSalaryDrawn", LastSalaryDrawn);
            Comd.Parameters.AddWithValue("@FromDate", FromDate);
            Comd.Parameters.AddWithValue("@ToDate", ToDate);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }

        //====================================BAL===============================================
        public string UpdateTaxDetail(string EmpCodeTax, string PanNo, string AccountType, string BankAccountNo, string BankName, string DigitCode, string LedgerNo, string BulkReturn, string EligibleDed, string ConsentforECS, string BankBranch)
        {
            string EmployeeCode = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("[SP_UpdateTaxDetail]", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpCodeTax", EmpCodeTax);
            cmd.Parameters.Add("@PanNo", PanNo);
            cmd.Parameters.Add("@AccountType", AccountType);
            cmd.Parameters.Add("@BankAccountNo", BankAccountNo);
            cmd.Parameters.Add("@BankName", BankName);
            cmd.Parameters.Add("@DigitCode", DigitCode);
            cmd.Parameters.Add("@LedgerNo", LedgerNo);
            cmd.Parameters.Add("@BulkReturn", BulkReturn);
            cmd.Parameters.Add("@EligibleDed", EligibleDed);
            cmd.Parameters.Add("@ConsentForECS", ConsentforECS);
            cmd.Parameters.Add("@BankBranch", BankBranch);
            cmd.Parameters.Add("@return", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            EmployeeCode = cmd.Parameters["@return"].Value.ToString();
            con.Close();
            return EmployeeCode;
        }

        public DataTable GetAssetsNameBranchWise()
        {
            return DBM.GetDataTable("SP_GetAssetsNameBranchWise");
        }

        public string InsertAssetsDetail(string EmpCode, string assetsCode, string issueDate, string Model, string SerialNo, string PurchaseDate, string RecoveryDate, string remarks, string UserId)
        {
            string EmployeeCode = string.Empty;
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("SP_InsertAssetsDetail", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
            cmd.Parameters.AddWithValue("@assetsCode", assetsCode);
            cmd.Parameters.AddWithValue("@issueDate", (issueDate != "") ? issueDate : Convert.DBNull);
            cmd.Parameters.AddWithValue("@Model", Model);
            cmd.Parameters.AddWithValue("@SerialNo", SerialNo);
            cmd.Parameters.AddWithValue("@PurchaseDate", (PurchaseDate != "") ? PurchaseDate : Convert.DBNull);
            cmd.Parameters.AddWithValue("@RecoveryDate", (RecoveryDate != "") ? RecoveryDate : Convert.DBNull);
            cmd.Parameters.AddWithValue("@remarks", remarks);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.Add("@return", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            EmployeeCode = cmd.Parameters["@return"].Value.ToString();
            con.Close();
            return EmployeeCode;
        }

        public DataTable BindAssetsDetail(string empCode)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("SP_GetAssetsDetail", con);
            //cmdcnt.Connection = concnt;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empCode", empCode);
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            Sqladpter.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckAssetsDetail(string empCode, string assetsCode)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("[SP_CheckAssetsDetail]", con);
            //cmdcnt.Connection = concnt;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empCode", empCode);
            //cmd.Parameters.AddWithValue("@branchCode", branchCode);
            cmd.Parameters.AddWithValue("@assetsCode", assetsCode);
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            Sqladpter.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllLeaveApplication()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("sp_GetAllLeaveApplication", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;

        }

        public string chagePassword(string UserId, string OldPassword, string NewPassword)
        {
            SqlCommand Comd = DBM.GetCommandSP("sp_ChangePassword");
            Comd.Parameters.AddWithValue("@UserId", UserId);
            Comd.Parameters.AddWithValue("@OldPassword", OldPassword);
            Comd.Parameters.AddWithValue("@NewPassword", NewPassword);
            return DBM.WriteToDbWithOutput(Comd);
        }


     
    
        public DataTable GetLeaveHistory()
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("[sp_getLeaveHistory]", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetLeaveDetailsbyEmpidAndLeaveType(string empCode, String LeaveType, int month, int year)
        {
            DataTable dt = new DataTable();
            SqlConnection concity = new SqlConnection(_strconnectionString);
            SqlCommand cmdcity = new SqlCommand("[sp_GetLeaveByEmpCodeAndLeaveType]", concity);
            cmdcity.Connection = concity;
            cmdcity.CommandType = CommandType.StoredProcedure;
            cmdcity.Parameters.AddWithValue("@EmpCode", empCode);
            cmdcity.Parameters.AddWithValue("@Leavecode", LeaveType);
            cmdcity.Parameters.AddWithValue("@month", month);
            cmdcity.Parameters.AddWithValue("@year", year);
            concity.Open();
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
            Sqladpter.Fill(dt);
            concity.Dispose();
            concity.Close();
            return dt;
        }

        public DataTable GetLocationPosting()
        {
            return DBM.GetDataTable("SP_GetLocationPosting");
        }
        //public DataTable GetDivision()
        //{
        //    return DBM.GetDataTable("SP_GetDivision");
        //}
        public DataTable GetTechComm()
        {
            return DBM.GetDataTable("SP_GetTechComm");
        }

        #region Employee Investment
        /// <summary>
        /// To get Investment of Current Financial Year Investment of Employee
        /// </summary>
        /// <param name="EmpCode"></param>
        /// <param name="rslt"></param>
        /// <returns></returns>
      
        //By Ashutosh on 14 apr 2020 for new Tax Regime
        public static DataSet GetEmployeeRegime(string EmpCode, string RegimeType, out string rslt)
        {
            SqlCommand comd = DBM.GetCommandSP("GetEmployeeRegime");
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);            
            comd.Parameters.AddWithValue("@RegimeType", RegimeType);
            return DBM.GetDataSet(comd, out rslt);
        }
        //--=========================================For Slack User=============================
        public static DataSet GetEmployeeSlack(string EmpCode, string SlackUser, out string rslt)
        {
            SqlCommand comd = DBM.GetCommandSP("GetEmployeeSlack");
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@SlackUser", SlackUser);
            return DBM.GetDataSet(comd, out rslt);
        }
        //public static void ReGenerateEmployeeInvesments(string EmpCode)
        //{
        //    SqlCommand comd = DBM.GetCommandSP("sp_SaveInvestment_ReGenerate");
        //    comd.Parameters.AddWithValue("@EmpCode", EmpCode);
        //    comd.Parameters.AddWithValue("@FinancialYear", BaseProperties.CurrentSession);
        //    DBM.WriteToDb(comd);
        //}
        #endregion

    }

    public static class Section
    {
        public static DataTable GetSection(string Code, string Description, string  IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Section_Get");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        public static DataTable GetSectionforddl()
        {
            return GetSection("", "", "1");
        }
        public static string CreateSection(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("Section_Create");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public static string UpdateSection(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("Section_Update");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
    }
    public static class SubSection
    {
        public static DataTable GetSubSection(string Code, string Description, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SubSection_Get");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        public static DataTable GetSubSectionforddl()
        {
            return GetSubSection("", "", "1");
        }
        public static string CreateSubSection(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("SubSection_Create");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public static string UpdateSubSection(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("SubSection_Update");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
    }
    public static class Estimation
    {
        public static DataTable GetEstimation(string Code, string Description, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Estimation_Get");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        public static DataTable GetEstimationforddl()
        {
            return GetEstimation("", "", "1");
        }
        public static string CreateEstimation(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("Estimation_Create");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public static string UpdateEstimation(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("Estimation_Update");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
    }
    public static class SubDivision
    {
        public static DataTable GetSubDivision(string Code, string Description, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SubDivision_Get");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        public static DataTable GetSubDivisionforddl()
        {
            return GetSubDivision("", "", "1");
        }
        public static string CreateSubDivision(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("SubDivision_Create");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public static string UpdateSubDivision(string Code, string Description, bool IsActive, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("SubDivision_Update");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
    }
}
