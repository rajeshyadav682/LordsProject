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
using System.Data.SqlTypes;

/// <summary>
/// Summary description for SqlBAL
/// </summary>
/// 
namespace Reports.DataAccessLayer
{
    public class SqlBAL : SqlDataAccessLayer
    {
        public SqlBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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

        #region Login Page--------------------------

        

        public DataTable GetLeaveType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetLeaveTypeBranchWise", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            //cmdUser.Parameters.AddWithValue("@UserId", userName);
            //cmdUser.Parameters.AddWithValue("@password", userPassword);
            Sqladpter.Fill(dt);
            return dt;
        }


        #endregion
        //=========Pay element------------------
        #region Bind Employee Pay Element--------------------------

        public DataTable GetEmpPayElement(string empcode)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetEmployeePayElement", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@empcode", empcode);
            Sqladpter.Fill(dt);
            return dt;
        }


        #endregion
        #region Bind Employee Name--------------------------

        public DataTable GetEmployeeName()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetAllEmployeeName", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        public static DataTable GetBindLeaveType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_DisPlayLeaveType", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        #endregion
        #region Bind Pay Element--------------------------

        public DataTable GetPayElementType(bool SystemPayElementOnly = false)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetAllPayElement", conUser);
            cmdUser.Parameters.AddWithValue("@SystemPayElementOnly", SystemPayElementOnly);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }


        #endregion
        public string InsertPayElementEmployee(string EmpCode, string payStructureDate, string payelemnetCode, string PaidCategory, string Type, decimal Amount, string EffectiveDate)
        {
            SqlCommand comd = DBM.GetCommandSP("SP_InsertPayElementEmployee");
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@payStructureDate", payStructureDate);
            comd.Parameters.AddWithValue("@payelemnetCode", payelemnetCode);
            comd.Parameters.AddWithValue("@PaidCategory", PaidCategory);
            comd.Parameters.AddWithValue("@Type", Type);
            comd.Parameters.AddWithValue("@Amount", Amount);
            comd.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);
            return DBM.WriteToDbWithTransactionWithOutput(comd);
        }
        
        #region GetData-------------

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
        #endregion
        //===============================================================Riya==========================================================================
        #region Employee Band
        public string insert_EmployeeBand(string code, string Description, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("insert_EmployeeBand");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string UpdateEmployeeBand(string code, string Description, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Update_EmployeesBand");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public DataTable GetEmployeeBandGrid(string GradeCode, string GradeName, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetEmployeeBand");
            Comd.Parameters.AddWithValue("@GradeCode", GradeCode);
            Comd.Parameters.AddWithValue("@GradeName", GradeName);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        public DataTable GetEmployeeBand()
        {
            return GetEmployeeBandGrid("", "", "1");
        }
        public DataTable GetSubGrade(string GradeCode, string SubGradeCode, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("display_subgrade");
            Comd.Parameters.AddWithValue("@GradeCode", GradeCode);
            Comd.Parameters.AddWithValue("@SubGradeCode", SubGradeCode);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        #endregion
        #region Skills
        public DataTable GetSkillGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Skill_Bind", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Skill_insert(string code, string Name, string CreatedBy)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Insert_Skill", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@CreateBy", CreatedBy);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Update_Skills(string code, string Name, string ModifyBy)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_Skills", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion
        
        #region Employee Tranfer

        public DataTable EmployeeUpdate_Transfer(string EmployeeCode, string BranchCode, string EffectiveDate, string UserId)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("EmployeeUpdate_Transfer", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@EmpCode", EmployeeCode);
            cmdUser.Parameters.AddWithValue("@BranchCode", BranchCode);
            cmdUser.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);
            cmdUser.Parameters.AddWithValue("@UserId", UserId);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetEmployeeNameType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Employee_Name", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
       
        public DataTable GetTransferGrid(string Employee, string Branch, string effectDate)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Transfer_Bind", conUser);
            cmdUser.Parameters.AddWithValue("@Employee", Employee);
            cmdUser.Parameters.AddWithValue("@Branch", Branch);
            cmdUser.Parameters.AddWithValue("@effectDate", effectDate);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion
        
        #region Occupation

        public DataTable Occupation_insert(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Insert_Occupation", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Update_Occupation(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_Occupation", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetOccupationGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Occupation_Bind]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion
        
        #region Short Branch Leave

        public DataTable GetShortBranchGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("BranchLeave_Bind", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable BranchWiseLeave_Insert(string code, string Leavetype, string StartTime, string EndTime, string NoOfLeave, string IsActive, string CreatedBy)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Insert_ShortBranchLeave", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@LeaveType", Leavetype);
            cmdUser.Parameters.AddWithValue("@StartTime", StartTime);
            cmdUser.Parameters.AddWithValue("@EndTime", EndTime);
            cmdUser.Parameters.AddWithValue("@NoOfLeaveInMonth", NoOfLeave);
            cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@CreateBy", CreatedBy);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Update_BranchWiseLeave(string code, string Leavetype, string StartTime, string EndTime, string NoOfLeave, string IsActive, string ModifyBy)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_BranchWiseLeave", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@LeaveType", Leavetype);
            cmdUser.Parameters.AddWithValue("@StartTime", StartTime);
            cmdUser.Parameters.AddWithValue("@EndTime", EndTime);
            cmdUser.Parameters.AddWithValue("@NoOfLeaveInMonth", NoOfLeave);
            cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetBranchCodeLeave()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Branch_ShortLeaveCode", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion
        public string CreateDepartment(string Code, string Description, string EMail, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("CreateDepartment");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@EMail", EMail);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }


        public DataTable Employee_Search(string code)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Employee_Search]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetDepartment(string Code, string Description, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("GetDepartment");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        


        public DataTable Designation_Search(string code)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Designation_Search]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetDesignationGrid(string Code, string Description, string GradeCode, string SubGradeCode, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Designation_Bind");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@GradeCode", GradeCode);
            Comd.Parameters.AddWithValue("@SubGradeCode", SubGradeCode);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        public string Employee_Designation(string code, string Name, string Grade, string SubGrade, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Employee_designation");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Name", Name);
            Comd.Parameters.AddWithValue("@Grade", Grade);
            Comd.Parameters.AddWithValue("@SubGrade", SubGrade);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string Employee_UpdateDesignation(string code, string Name, string Grade, string SubGrade, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Employee_Updatedesignation");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Name", Name);
            Comd.Parameters.AddWithValue("@Grade", Grade);
            Comd.Parameters.AddWithValue("@SubGrade", SubGrade);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string UpdateDepartment(string Code, string Description, string EMail, bool IsActive)
        {

            SqlCommand Comd = DBM.GetCommandSP("UpdateDepartment");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@EMail", EMail);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }

        //#region Bind Dept code--------------------------
        //public DataTable BindDeptCode()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdUser = new SqlCommand("[Emp_Code]", conUser);
        //    cmdUser.Connection = conUser;
        //    cmdUser.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
        //    Sqladpter.Fill(dt);
        //    return dt;
        //}
        //#endregion
        //#region Bind Desg code---------------------------

        //public DataTable BindDesgCode()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdUser = new SqlCommand("[Designation_Code]", conUser);
        //    cmdUser.Connection = conUser;
        //    cmdUser.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
        //    Sqladpter.Fill(dt);
        //    return dt;
        //}
        //#endregion
        #region Bind Employee code--------------------------

        public DataTable BindEmpCode()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Employee_Code]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        #endregion
        public string EmployeeUpdate_Branch(string Bcode, string Name, string Head, string CCode, string StateId, string CntId, string Address, string Pincode, string Email, string contact, bool DeductPTDS, string TimeIn, string TimeOut, string TimeInRelaxation, string TimeOutRelaxation, string DocumentType, string LWFEmployer, string LWFEmployee, string HRCode, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("EmployeeUpdate_Branch");
            Comd.Parameters.AddWithValue("@BranchCode", Bcode);
            Comd.Parameters.AddWithValue("@BranchName", Name);
            Comd.Parameters.AddWithValue("@BHead", Head);
            Comd.Parameters.AddWithValue("@CCode", CCode);
            Comd.Parameters.AddWithValue("@StateId", StateId);
            Comd.Parameters.AddWithValue("@CntId", CntId);
            Comd.Parameters.AddWithValue("@Address", Address);
            Comd.Parameters.AddWithValue("@PinCode", Pincode);
            Comd.Parameters.AddWithValue("@Email", Email);
            Comd.Parameters.AddWithValue("@Contact", contact);
            Comd.Parameters.AddWithValue("@DeductPTDS", DeductPTDS);
            Comd.Parameters.AddWithValue("@TimeIn", TimeIn);
            Comd.Parameters.AddWithValue("@TimeOut", TimeOut);
            Comd.Parameters.AddWithValue("@TimeInRelaxation", TimeInRelaxation);
            Comd.Parameters.AddWithValue("@TimeOutRelaxation", TimeOutRelaxation);
            Comd.Parameters.AddWithValue("@DocumentType", DocumentType);
            Comd.Parameters.AddWithValue("@LWFEmployer", LWFEmployer);
            Comd.Parameters.AddWithValue("@LWFEmployee", LWFEmployee);
            Comd.Parameters.AddWithValue("@HRCode", HRCode);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string Employee_Branch(string Bcode, string Name, string Head, string CCode, string StateId, string cntId, string Address, string Pincode, string Email, string contact, bool DeductPTDS, string TimeIn, string TimeOut, string TimeInRelaxation, string TimeOutRelaxation, string DocumentType, string LWFEmployer, string LWFEmployee, string HRCode, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Employee_Branch");
            Comd.Parameters.AddWithValue("@BranchCode", Bcode);
            Comd.Parameters.AddWithValue("@BranchName", Name);
            Comd.Parameters.AddWithValue("@BranchHead", Head);
            Comd.Parameters.AddWithValue("@CityCode", CCode);
            Comd.Parameters.AddWithValue("@StateId", StateId);
            Comd.Parameters.AddWithValue("@CntId", cntId);
            Comd.Parameters.AddWithValue("@Address", Address);
            Comd.Parameters.AddWithValue("@Pincode", Pincode);
            Comd.Parameters.AddWithValue("@Email", Email);
            Comd.Parameters.AddWithValue("@contact", contact);
            Comd.Parameters.AddWithValue("@DeductPTDS", DeductPTDS);
            Comd.Parameters.AddWithValue("@TimeIn", TimeIn);
            Comd.Parameters.AddWithValue("@TimeOut", TimeOut);
            Comd.Parameters.AddWithValue("@TimeInRelaxation", TimeInRelaxation);
            Comd.Parameters.AddWithValue("@TimeOutRelaxation", TimeOutRelaxation);
            Comd.Parameters.AddWithValue("@DocumentType", DocumentType);
            Comd.Parameters.AddWithValue("@LWFEmployer", LWFEmployer);
            Comd.Parameters.AddWithValue("@LWFEmployee", LWFEmployee);
            Comd.Parameters.AddWithValue("@HRCode", HRCode);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public DataTable GetBranch(string BranchCode, string BranchName, string BranchHead, string City, string State, string Country, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Branch_Bind");
            Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            Comd.Parameters.AddWithValue("@BranchName", BranchName);
            Comd.Parameters.AddWithValue("@BranchHead", BranchHead);
            Comd.Parameters.AddWithValue("@City", City);
            Comd.Parameters.AddWithValue("@State", State);
            Comd.Parameters.AddWithValue("@Country", Country);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        public DataTable Branch_Search(string code)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Branch_Search]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            Sqladpter.Fill(dt);
            return dt;
        }
        
        public DataTable GetBranchHeadType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Branch_Head", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetCityCodeType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("City_Code", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetStateIdType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("State_Id", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetCountryIdType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Country_Id", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Qualification_Category(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Qualification_Category", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable UpdateQualification(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_Qualification", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetEmployeeBandCategoryGrid(string Code, string Description, bool IsEdit)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[EmployeeBandCategory_Bind]", conUser);
            cmdUser.Parameters.AddWithValue("@Code", Code);
            cmdUser.Parameters.AddWithValue("@Description", Description);
            cmdUser.Parameters.AddWithValue("@IsEdit", IsEdit);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable BindBandCode()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[EmployeeBandCategory_Code]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable EmployeeBand_Category(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[EmployeeBand_Category]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable UpdateEmployeeBandCategory(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_EmployeeBand", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            Sqladpter.Fill(dt);
            return dt;
        }

        #region Holi Day--------------------------------------------------------------------------

        public string Holiday_insert(string Occasion, string Date, string BranchCode, bool IsActive, bool CanEarnCompensatoryLeave, string CreatedBy)
        {
            SqlCommand Comd = DBM.GetCommandSP("InsertHoliday");
            Comd.Parameters.AddWithValue("@Occasion", Occasion);
            Comd.Parameters.AddWithValue("@Date", Date);
            Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@CanEarnCompensatoryLeave", CanEarnCompensatoryLeave);
            Comd.Parameters.AddWithValue("@CreateBy", CreatedBy);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string Update_Holiday(Int32 Sno, string Occasion, string Date, string BranchCode, bool IsActive, bool CanEarnCompensatoryLeave, string ModifyBy)
        {
            SqlCommand Comd = DBM.GetCommandSP("Update_Holiday");
            Comd.Parameters.AddWithValue("@Sno", Sno);
            Comd.Parameters.AddWithValue("@Occasion", Occasion);
            Comd.Parameters.AddWithValue("@Date", Date);
            Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@CanEarnCompensatoryLeave", CanEarnCompensatoryLeave);
            Comd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public DataTable GetHolidayGrid(string Month, string Year, string Occasion, string Date, string BranchCode, string Day)
        {
            SqlCommand Comd = DBM.GetCommandSP("Holiday_Bind");
            Comd.Parameters.AddWithValue("@Month", Month);
            Comd.Parameters.AddWithValue("@Year", Year);
            Comd.Parameters.AddWithValue("@Occasion", Occasion);
            Comd.Parameters.AddWithValue("@HoliDayDate", Date);
            Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            Comd.Parameters.AddWithValue("@Day", Day);
            return DBM.GetDataTable(Comd);
        }
        public DataTable GetHolidayGridByBranchCode(Int32 PKey, string BranchCode)
        {
            SqlCommand Comd = DBM.GetCommandSP("Holiday_Bind_Branch");
            Comd.Parameters.AddWithValue("@PKey", PKey);
            Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            return DBM.GetDataTable(Comd);
        }
        public DataTable GetOffDays(string BranchCode, string Type, string Day)
        {
            SqlCommand Comd = DBM.GetCommandSP("Display_OffDay");
            Comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            Comd.Parameters.AddWithValue("@Type", Type);
            Comd.Parameters.AddWithValue("@Day", Day);
            return DBM.GetDataTable(Comd);
        }
        #endregion

        #region Relation

        public DataTable Relation_insert(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Insert_Relation", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Update_Relation(string code, string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_Relation", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetRelationGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Relation_Bind", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion
        #region Assets
        public DataTable assets_insert(string code, string Name, string CreatedBy)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("InsertAssets", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@BranchName", BranchName);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            //cmdUser.Parameters.AddWithValue("@CreateBy", CreatedBy);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Update_Assets(string code, string Name,string ModifyBy)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_Assets", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@Code", code);
            cmdUser.Parameters.AddWithValue("@Name", Name);
            //cmdUser.Parameters.AddWithValue("@BranchName", BranchName);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetBranchAssetsCodeType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Branch_CodeAssets", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetAssestsGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Assets_Bind", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        #endregion

        public DataTable GetCurrencyGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Currency_Bind", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Currency_insert(string ISOCode, string CountryCode, string Currency, string FractionalUnit, string Price, string IsActive, string EffectiveDate, string createdby)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_InsertCurrency", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@ISOCode", ISOCode);
            cmdUser.Parameters.AddWithValue("@CountryCode", CountryCode);
            cmdUser.Parameters.AddWithValue("@Currency", Currency);
            cmdUser.Parameters.AddWithValue("@FranctionalUnit", FractionalUnit);
            cmdUser.Parameters.AddWithValue("@Price", Price);
            cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);
            cmdUser.Parameters.AddWithValue("@createdby", createdby);
            cmdUser.Parameters.Add("@Rs", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Update_Currency(string key, string CountryCode, string Currency, string FractionalUnit, string Price, string IsActive, string EffectiveDate)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Update_Currency]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@key", key);
            cmdUser.Parameters.AddWithValue("@CountryCode", CountryCode);
            cmdUser.Parameters.AddWithValue("@Currency", Currency);
            cmdUser.Parameters.AddWithValue("@FranctionalUnit", FractionalUnit);
            cmdUser.Parameters.AddWithValue("@Price", Price);
            cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);
            Sqladpter.Fill(dt);
            return dt;
        }

        //==========================================Advance Entery==========================================
        public DataTable GetEmployeeType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetEmployeeNameAndCode", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable AdvancedEntry_insert(string EmpCode, string AdvancedPayment, string Remarks, string IsActive, string userid)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_InsertAdvanceEntry", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@EmpCode", EmpCode);
            cmdUser.Parameters.AddWithValue("@AdvancedPayment", AdvancedPayment);
            cmdUser.Parameters.AddWithValue("@Remarks", Remarks);
            cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@userid", userid);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable AdvancePayment_insert(string EmpCode, string AdvancedPayment, string Remarks, string userid)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_InsertAdvancePayment", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@EmpCode", EmpCode);
            cmdUser.Parameters.AddWithValue("@AdvancedPayment", AdvancedPayment);
            cmdUser.Parameters.AddWithValue("@Remarks", Remarks);
            //cmdUser.Parameters.AddWithValue("@IsActive", IsActive);
            cmdUser.Parameters.AddWithValue("@userid", userid);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable getBranchcode()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("Bind_Branch", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            return dt;
        }
        public DataTable getEmployee(string Code)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("Bind_Employee", con);
            cmd.Parameters.AddWithValue("@branchCode", Code);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            return dt;
        }
        public DataTable BindShiftCode()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Shift_Code]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable ShiftMaster_insert(string BranchName, string ShiftCode, string ShiftName, string StartTime, string EndTime, string EffectiveDate, string userid)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("InsertShiftMaster", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@BranchCode", BranchName);
            cmdUser.Parameters.AddWithValue("@ShiftCode", ShiftCode);
            cmdUser.Parameters.AddWithValue("@ShiftName", ShiftName);
            cmdUser.Parameters.AddWithValue("@StartTime", StartTime);
            cmdUser.Parameters.AddWithValue("@EndTime", EndTime);
            cmdUser.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);
            cmdUser.Parameters.AddWithValue("@CreatedBy", userid);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Update_ShiftMaster(string BranchName, string ShiftCode, string ShiftName, DateTime StartTime, DateTime EndTime, string EffectiveDate, string ModifyBy)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Update_ShiftMaster", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@BranchCode", BranchName);
            cmdUser.Parameters.AddWithValue("@ShiftCode", ShiftCode);
            cmdUser.Parameters.AddWithValue("@ShiftName", ShiftName);
            cmdUser.Parameters.AddWithValue("@StartTime", StartTime);
            cmdUser.Parameters.AddWithValue("@EndTime", EndTime);
            cmdUser.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);
            cmdUser.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetShiftMasterGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Shift_Bind]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetShiftName()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Shift_Name", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable BindShifChange()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("ShiftChange_Managment", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetShif()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Get_shift", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable Shiftchange_insert(string Empcode, string BranchCode, string fromshif,string Toshift, string EffectiveDate, string userid)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Insert_ShiftChange", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@EmpCode", Empcode);
            cmdUser.Parameters.AddWithValue("@Branchcode", BranchCode);
            cmdUser.Parameters.AddWithValue("@FromShift", fromshif);
            cmdUser.Parameters.AddWithValue("@ToShiftCode", Toshift);
            cmdUser.Parameters.AddWithValue("@Effective", EffectiveDate);
            cmdUser.Parameters.AddWithValue("@CreatedBy", userid);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable change_MonthlyCO(string Empcode, string BranchCode, string from, string To, string EffectiveDate, string userid,int InActive)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("Insert_MonthlyCompOff", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@EmpCode", Empcode);
            cmdUser.Parameters.AddWithValue("@Branchcode", BranchCode);
            cmdUser.Parameters.AddWithValue("@From", from);
            cmdUser.Parameters.AddWithValue("@To", To);
            cmdUser.Parameters.AddWithValue("@Effective", EffectiveDate);
            cmdUser.Parameters.AddWithValue("@CreatedBy", userid);
            cmdUser.Parameters.AddWithValue("@Inactive", InActive);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable BindShiftgrid( string BranchCode, string EmpCode)
        {
            DataTable dt = new DataTable();
            SqlConnection concnt = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("SP_Display", concnt);
            cmd.Connection = concnt;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            //cmd.Parameters.AddWithValue("@DOJ", (DOJ != "") ? DOJ : Convert.DBNull);
            cmd.Parameters.AddWithValue("@BranchCode", BranchCode);
            cmd.Parameters.AddWithValue("@EmpCode", (EmpCode != "") ? EmpCode : Convert.DBNull);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable BindBranchCodeandName()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("getBranchCodeandName", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        //============================================================Loan=======================================================================

        #region Loan

        public DataTable GetLoanType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("sp_LoanType", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable BindLoanCode()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("[Loan_Code]", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public string insert_Loan(string EmpCode, string GuarantorCode, string LoanCode, string Loantype, string Amount, string LoanApplicationDate, string InstallmentAmount, string Purpose, string CreatedBy, bool AdjustBonus, bool AdjustProjectIncentive, bool AdjustLeaveEnCashment)
        {
            SqlCommand Comd = DBM.GetCommandSP("insert_Loan");
            Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            Comd.Parameters.AddWithValue("@GuarantorCode", GuarantorCode);
            Comd.Parameters.AddWithValue("@LoanCode", LoanCode);
            Comd.Parameters.AddWithValue("@Loantype", Loantype);
            Comd.Parameters.AddWithValue("@Amount", Amount);
            Comd.Parameters.AddWithValue("@LoanApplicationDate", LoanApplicationDate);
            Comd.Parameters.AddWithValue("@InstallmentAmount", InstallmentAmount);
            Comd.Parameters.AddWithValue("@Purpose", Purpose);
            Comd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            Comd.Parameters.AddWithValue("@AdjustBonus", AdjustBonus);
            Comd.Parameters.AddWithValue("@AdjustProjectIncentive", AdjustProjectIncentive);
            Comd.Parameters.AddWithValue("@AdjustLeaveEnCashment", AdjustLeaveEnCashment);
            return DBM.WriteToDbWithOutput(Comd);

            //DataTable dt = new DataTable();
            //SqlConnection conUser = new SqlConnection(_strconnectionString);
            //SqlCommand cmdUser = new SqlCommand("[insert_Loan]", conUser);
            //cmdUser.Connection = conUser;
            //cmdUser.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            //cmdUser.Parameters.AddWithValue("@Name", EmpCode);
            //cmdUser.Parameters.AddWithValue("@LoanCode", LoanCode);
            //cmdUser.Parameters.AddWithValue("@Loantype", Loantype);
            //cmdUser.Parameters.AddWithValue("@Amount", Amount);
            //cmdUser.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDate));
            ////cmdUser.Parameters.AddWithValue("@EndDate", DateTime.Parse(EndDate));
            ////cmdUser.Parameters.AddWithValue("@NoOfMonths", NoOfMonths);
            //cmdUser.Parameters.AddWithValue("@RateOfInterest", RateOfInterest);
            //cmdUser.Parameters.AddWithValue("@InstallmentAmount", InstallmentAmount);
            ////cmdUser.Parameters.AddWithValue("@NoOfInstallment", NoOfInstallment);
            ////cmdUser.Parameters.AddWithValue("@TotalPayable", TotalPayable);
            ////cmdUser.Parameters.AddWithValue("@TotalInterest", TotalInterest);
            //cmdUser.Parameters.AddWithValue("@Purpose", Purpose);
            //cmdUser.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            //Sqladpter.Fill(dt);
            //return dt;
        }
        public string Update_Loan(string LoanCode, string Loantype, string RequestedDisbursementDate, string Amount, string InstallmentAmount, string Remarks, bool AdjustBonus, bool AdjustProjectIncentive, bool AdjustLeaveEnCashment, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("Update_Loan");
            Comd.Parameters.AddWithValue("@LoanCode", LoanCode);
            Comd.Parameters.AddWithValue("@Loantype", Loantype);
            Comd.Parameters.AddWithValue("@Amount", Amount);
            Comd.Parameters.AddWithValue("@InstallmentAmount", InstallmentAmount);
            Comd.Parameters.AddWithValue("@RequestedDisbursementDate", RequestedDisbursementDate);
            Comd.Parameters.AddWithValue("@Remarks", Remarks);
            Comd.Parameters.AddWithValue("@AdjustBonus", AdjustBonus);
            Comd.Parameters.AddWithValue("@AdjustProjectIncentive", AdjustProjectIncentive);
            Comd.Parameters.AddWithValue("@AdjustLeaveEnCashment", AdjustLeaveEnCashment);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string Update_Loan_Account(string LoanCode, string DisbursementDate, string StartDate, string Remarks, string UserId)
        {
            SqlCommand Comd = DBM.GetCommandSP("Update_Loan_Account");
            Comd.Parameters.AddWithValue("@LoanCode", LoanCode);
            Comd.Parameters.AddWithValue("@DisbursementDate", DisbursementDate);
            Comd.Parameters.AddWithValue("@StartDate", StartDate);
            Comd.Parameters.AddWithValue("@Remarks", Remarks);
            Comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public DataTable GetLoanGrid(string EmpCode, string LoanCode, string LoanType, string Status = "PENDING", string FromDate = "", string ToDate = "", string BalanceAsOnDate = "", string UserBranchCode = "")
        {
            SqlCommand Comd = DBM.GetCommandSP("Loan_Bind");
            Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            Comd.Parameters.AddWithValue("@LoanCode", LoanCode);
            Comd.Parameters.AddWithValue("@LoanType", LoanType);
            Comd.Parameters.AddWithValue("@Stauts", Status);
            Comd.Parameters.AddWithValue("@FromDate", FromDate == "" ? SqlString.Null : FromDate);
            Comd.Parameters.AddWithValue("@ToDate", ToDate == "" ? SqlString.Null : ToDate);
            Comd.Parameters.AddWithValue("@BalanceAsOnDate", BalanceAsOnDate == "" ? SqlString.Null : BalanceAsOnDate);
            Comd.Parameters.AddWithValue("@UserBranchCode", UserBranchCode);
            return DBM.GetDataTable(Comd);
        }
        //public DataTable GetLoanGrid2()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdUser = new SqlCommand("Loan_Bind2", conUser);
        //    cmdUser.Connection = conUser;
        //    cmdUser.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
        //    Sqladpter.Fill(dt);
        //    return dt;
        //}
        //public DataTable UpdateLoanRemarkAccept(string LoanCode)
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdUser = new SqlCommand("[Update_LoanRemark]", conUser);
        //    cmdUser.Connection = conUser;
        //    cmdUser.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
        //    cmdUser.Parameters.AddWithValue("@LoanCode", LoanCode);
        //    Sqladpter.Fill(dt);
        //    return dt;
        //}
        //public DataTable UpdateLoanRemarkReject(string Remark, string LoanCode)
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdUser = new SqlCommand("[Update_LoanRemarkReject]", conUser);
        //    cmdUser.Connection = conUser;
        //    cmdUser.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
        //    cmdUser.Parameters.AddWithValue("@Remark", Remark);
        //    cmdUser.Parameters.AddWithValue("@LoanCode", LoanCode);
        //    Sqladpter.Fill(dt);
        //    return dt;
        //}
        #endregion


    //public DataTable getreportdailytime()
    //    {
    //        DataTable dt = new DataTable();
    //        SqlConnection con = new SqlConnection(_strconnectionString);
    //        SqlCommand cmd = new SqlCommand("sp_dailtimeOfficeReport", con);
    //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //        sda.Fill(dt);
    //        return dt;
    //    }
        public string EmpCode { get; set; }
        public string BranchCode { get; set; }
        public string DeptName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }

        public DataTable getreportdailytime()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("sp_dailtimeOfficeReportNew", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (!string.IsNullOrEmpty(EmpCode))
            {
                cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
            }
            if (!string.IsNullOrEmpty(BranchCode))
            {
                cmd.Parameters.AddWithValue("@BranchName", BranchCode);
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                cmd.Parameters.AddWithValue("@DeptName", DeptName);
            }
            if (Month != 0)
            {
                cmd.Parameters.AddWithValue("@Month", Month);
            }
            if (Year != 0)
            {
                cmd.Parameters.AddWithValue("@Year", Year);
            }
            cmd.Parameters.AddWithValue("@Type", Type); ;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
        public static DataTable Getbranch()
        {
            return DBM.GetDataTable("Get_Branch");
        }

        public string Insert_Payelement(string Code, string Description, string PaidCategory, string Type, string SortingOrder, bool LWP, bool Gratuity, bool Bonus,
                                     bool ProjectIncentive, bool LeaveEncashment, bool PF, bool ESI, bool PaySlip, bool SalaryRegister, bool NoticePeriod,
                                     bool PTDS, bool TDS, bool Irregular, bool IsOT, bool OT, bool Exgratia, bool SystemPayElement, string ReversePayElement, string UserId)
        {
            SqlCommand cmd = DBM.GetCommandSP("Insert_Payelement");
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@PaidCategory", PaidCategory);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@SortingOrder", SortingOrder);
            cmd.Parameters.AddWithValue("@LWP", LWP);
            cmd.Parameters.AddWithValue("@Gratuity", Gratuity);
            cmd.Parameters.AddWithValue("@Bonus", Bonus);
            cmd.Parameters.AddWithValue("@ProjectIncentive", ProjectIncentive);
            cmd.Parameters.AddWithValue("@LeaveEncashment", LeaveEncashment);
            cmd.Parameters.AddWithValue("@PF", PF);
            cmd.Parameters.AddWithValue("@ESI", ESI);
            cmd.Parameters.AddWithValue("@PaySlip", PaySlip);
            cmd.Parameters.AddWithValue("@SalaryRegister", SalaryRegister);
            cmd.Parameters.AddWithValue("@NoticePeriod", NoticePeriod);
            cmd.Parameters.AddWithValue("@PTDS", PTDS);
            cmd.Parameters.AddWithValue("@TDS", TDS);
            cmd.Parameters.AddWithValue("@Irregular", Irregular);
            cmd.Parameters.AddWithValue("@IsOT", IsOT);
            cmd.Parameters.AddWithValue("@OT", OT);
            cmd.Parameters.AddWithValue("@Exgratia", Exgratia);
            cmd.Parameters.AddWithValue("@SystemPayElement", SystemPayElement);
            cmd.Parameters.AddWithValue("@ReversePayElement", ReversePayElement);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(cmd);
        }

        public string Update_Payelement(string Code, string Description, string PaidCategory, string Type, string SortingOrder, bool LWP, bool Gratuity, bool Bonus,
                                     bool ProjectIncentive, bool LeaveEncashment, bool PF, bool ESI, bool PaySlip, bool SalaryRegister, bool NoticePeriod,
                                     bool PTDS, bool TDS, bool Irregular, bool IsOT, bool OT, bool Exgratia, bool SystemPayElement, string ReversePayElement, string UserId)
        {
            SqlCommand cmd = DBM.GetCommandSP("Update_Payelement");
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@PaidCategory", PaidCategory);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@SortingOrder", SortingOrder);
            cmd.Parameters.AddWithValue("@LWP", LWP);
            cmd.Parameters.AddWithValue("@Gratuity", Gratuity);
            cmd.Parameters.AddWithValue("@Bonus", Bonus);
            cmd.Parameters.AddWithValue("@ProjectIncentive", ProjectIncentive);
            cmd.Parameters.AddWithValue("@LeaveEncashment", LeaveEncashment);
            cmd.Parameters.AddWithValue("@PF", PF);
            cmd.Parameters.AddWithValue("@ESI", ESI);
            cmd.Parameters.AddWithValue("@PaySlip", PaySlip);
            cmd.Parameters.AddWithValue("@SalaryRegister", SalaryRegister);
            cmd.Parameters.AddWithValue("@NoticePeriod", NoticePeriod);
            cmd.Parameters.AddWithValue("@PTDS", PTDS);
            cmd.Parameters.AddWithValue("@TDS", TDS);
            cmd.Parameters.AddWithValue("@Irregular", Irregular);
            cmd.Parameters.AddWithValue("@IsOT", IsOT);
            cmd.Parameters.AddWithValue("@OT", OT);
            cmd.Parameters.AddWithValue("@Exgratia", Exgratia);
            cmd.Parameters.AddWithValue("@SystemPayElement", SystemPayElement);
            cmd.Parameters.AddWithValue("@ReversePayElement", ReversePayElement);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.WriteToDbWithOutput(cmd);
        }
        
        public DataTable Display_Payelement(string PayElementCode, string PaidCategory, string Type)
        {
            SqlCommand cmd = DBM.GetCommandSP("Display_PayElement");
            cmd.Parameters.AddWithValue("@PayElementCode", PayElementCode);
            cmd.Parameters.AddWithValue("@PaidCategory", PaidCategory);
            cmd.Parameters.AddWithValue("@Type", Type);
            return DBM.GetDataTable(cmd);
        }

        //public DataSet getemployeecode()
        //{
        //    DataSet dt = new DataSet();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdcity = new SqlCommand("sp_getEmpcode", conUser);
        //    cmdcity.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
        //    Sqladpter.Fill(dt);
        //    return dt;
        //}
        //public DataSet GetPayslip(string EmpCode, string monthname, string monthnumber)
        //{
        //    DataSet dt = new DataSet();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdcity = new SqlCommand("Display_payslip", conUser);
        //    cmdcity.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
        //    cmdcity.Parameters.AddWithValue("@ID", EmpCode);
        //    cmdcity.Parameters.AddWithValue("@month", monthnumber);
        //    cmdcity.Parameters.AddWithValue("@monthdesc", monthname);
        //    Sqladpter.Fill(dt);
        //    return dt;
        // }

        //public DataSet GetPaysliponline(string EmpCode, string monthname, string monthnumber, string year)
        //{
        //    DataSet dt = new DataSet();
        //    SqlConnection conUser = new SqlConnection(_strconnectionString);
        //    SqlCommand cmdcity = new SqlCommand("Display_payslip", conUser);
        //    cmdcity.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
        //    cmdcity.Parameters.AddWithValue("@ID", EmpCode);
        //    cmdcity.Parameters.AddWithValue("@month", monthnumber);
        //    cmdcity.Parameters.AddWithValue("@monthdesc", monthname);
        //    cmdcity.Parameters.AddWithValue("@year", year);
        //    Sqladpter.Fill(dt);
        //    return dt;
        //}

        //public string insertODEntry(int Sno, string EmpCode, string FromDate, string ToDate, string TimeIn, string TimeOut, bool Fullday, string UserId, string Remarks)
        //{
        //    SqlCommand comd = DBM.GetCommandSP("sp_insertODAttandance");
        //    comd.Parameters.AddWithValue("@Sno", Sno);
        //    comd.Parameters.AddWithValue("@EmpCode", EmpCode);
        //    comd.Parameters.AddWithValue("@FromDate", FromDate);
        //    comd.Parameters.AddWithValue("ToDate", ToDate);
        //    comd.Parameters.AddWithValue("@TimeIn", TimeIn);
        //    comd.Parameters.AddWithValue("@TimeOut", TimeOut);
        //    comd.Parameters.AddWithValue("@Fullday", Fullday);
        //    comd.Parameters.AddWithValue("@UserId", UserId);
        //    comd.Parameters.AddWithValue("@Remarks", Remarks);
        //    return DBM.WriteToDbWithOutput(comd);
        //}

        //--==============wfh
        public string insertODEntry(int Sno, string EmpCode, string Project, string FromDate, string ToDate, string TimeIn, string TimeOut, bool Fullday, string UserId, string Remarks, string RegularWork, string Progress)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_insertODAttandance_R");
            comd.Parameters.AddWithValue("@Sno", Sno);
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@FromDate", FromDate);
            comd.Parameters.AddWithValue("ToDate", ToDate);
            comd.Parameters.AddWithValue("@TimeIn", TimeIn);
            comd.Parameters.AddWithValue("@TimeOut", TimeOut);
            comd.Parameters.AddWithValue("@Fullday", Fullday);
            comd.Parameters.AddWithValue("@Projectcode", Project);
            comd.Parameters.AddWithValue("@Regularwork", RegularWork);
            comd.Parameters.AddWithValue("@Progress", Progress);
            comd.Parameters.AddWithValue("@UserId", UserId);
            comd.Parameters.AddWithValue("@Remarks", Remarks);
            return DBM.WriteToDbWithOutput(comd);
        }



        public DataTable GetodattanceDetails(string EmpCode, string UserBranchCode, string UserId, string ReportingPersonAccess, string BranchCode, string FromDate, string ToDate, string Status)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_getOdDetails");
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@UserBranchCode", UserBranchCode);
            comd.Parameters.AddWithValue("@UserId", UserId);
            comd.Parameters.AddWithValue("@ReportingPersonAccess", ReportingPersonAccess);
            comd.Parameters.AddWithValue("@BranchCode", BranchCode);
            comd.Parameters.AddWithValue("@FromDate", FromDate);
            comd.Parameters.AddWithValue("@ToDate", ToDate);
            comd.Parameters.AddWithValue("@Status", Status);
            return DBM.GetDataTable(comd);
        }
	
        public DataSet GetMonthLeaveDetails(string EmpCode, string monthnumber, string Year)
    {
        DataSet dt = new DataSet();
        SqlConnection conUser = new SqlConnection(_strconnectionString);
        SqlCommand cmdcity = new SqlCommand("sp_getleaveDetails", conUser);
        cmdcity.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdcity);
        cmdcity.Parameters.AddWithValue("@Empcode", EmpCode);
        cmdcity.Parameters.AddWithValue("@Month", monthnumber);
        cmdcity.Parameters.AddWithValue("@Year", Year);
        Sqladpter.Fill(dt);
        return dt;
    }
        public DataTable getCTC(string Empcode, string Branch, string Department)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("Sp_EmployeeCTC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpCode", Empcode);
            cmd.Parameters.AddWithValue("@Branch", Branch);
            cmd.Parameters.AddWithValue("@Department", Department);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            return dt;
        }
        public DataTable getAttandanceregister()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("Attendance_Report", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (!string.IsNullOrEmpty(EmpCode))
            {
                cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
            }
            if (!string.IsNullOrEmpty(BranchCode))
            {
                cmd.Parameters.AddWithValue("@BranchName", BranchCode);
            }
            //if (!string.IsNullOrEmpty(DeptName))
            //{
            //    cmd.Parameters.AddWithValue("@DeptName", DeptName);
            //}
            if (Month != 0 && Month != null)
            {
                cmd.Parameters.AddWithValue("@Month", Month);
            }
            if (Year != 0 && Year != null)
            {
                cmd.Parameters.AddWithValue("@Year", Year);
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
        public string BranchName { get; set; }
        public DataTable getAnualNetpayable()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("ProcAnualNetPayableReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (!string.IsNullOrEmpty(EmpCode))
            {
                cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
            }
            if (!string.IsNullOrEmpty(BranchCode))
            {
                cmd.Parameters.AddWithValue("@BranchName", BranchName);
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
        public DataTable getAnualNetpayableDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("ProcAnualNetPayabledetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
            if (Year != null && Year != 0)
            {
                cmd.Parameters.AddWithValue("@Year", Year);
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

        public string insert_subgrade(string GradeCode, string SubGradeCode, string Description, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Insert_SubGrade");
            Comd.Parameters.AddWithValue("@GradeCode", GradeCode);
            Comd.Parameters.AddWithValue("@SubGrade", SubGradeCode);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }

        #region Division
        public string DivisionInsert(string code, string Division, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Proc_DivisionInsert");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Division", Division);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }

        public string DivisionUpdate(string code, string Division, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Proc_DivisionUpdate");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Division", Division);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public DataTable GetDivisionDDL()
        {
            return DBM.GetDataTable("SP_GetDivisionDDL");
        }
        public DataTable GetDivision(string Code, string Division, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetDivision");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Division", Division);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        #endregion
        #region TechComm
        public int TechCommInsert(string code, string Type)
        {
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            conUser.Open();
            try
            {
                SqlCommand cmdUser = new SqlCommand("Proc_TechCommInsert", conUser);
                cmdUser.Connection = conUser;
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Parameters.AddWithValue("@Code", code);
                cmdUser.Parameters.AddWithValue("@Type", Type);
                return cmdUser.ExecuteNonQuery();
                conUser.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                conUser.Close();
            }
        }

        public int TechCommUpdate(string code, string Type)
        {

            SqlConnection conUser = new SqlConnection(_strconnectionString);
            conUser.Open();
            try
            {
                SqlCommand cmdUser = new SqlCommand("Proc_TechCommUpdate", conUser);
                cmdUser.Connection = conUser;
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Parameters.AddWithValue("@Code", code);
                cmdUser.Parameters.AddWithValue("@Type", Type);
                return cmdUser.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                conUser.Close();
            }
        }
        #endregion
        #region Project/ Location of Posting
        public string LocationPostingInsert(string Code, string Description, string Division, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Proc_LocationInsert");
            Comd.Parameters.AddWithValue("@Code",Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@Division",Division);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }

        public void LocationPostingUpdate(string Code, string Description, string Division, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Proc_locationPostingUpdate");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@Division", Division);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            DBM.WriteToDb(Comd);
        }
        #endregion
        #region OverTime
        public static DataTable GetOverTime(string EmpCode, string Month, string Year)
        {
            SqlCommand comd = DBM.GetCommandSP("rptOverTime");
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@Month", Month);
            comd.Parameters.AddWithValue("@Year", Year);
            return DBM.GetDataTable(comd);
        }
        #endregion
        #region LabourWelfareFund
        public static DataTable GetLabourWelfareFund(string EmpCode, string Month, string Year)
        {
            SqlCommand comd = DBM.GetCommandSP("rptLabourWelfareFund");
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@Month", Month);
            comd.Parameters.AddWithValue("@Year", Year);
            return DBM.GetDataTable(comd);
        }
        #endregion
        public DataTable GetLeave_Approval_Details(string EmpCode, string LeaveType, string LeaveCode, string FromDate, string ToDate, string Status, string UserBranchCode, string UserId, string ReportingPersonAccess)
        {
            try
            {
                SqlCommand comd = DBM.GetCommandSP("Leave_Approval_Details");
                comd.Parameters.AddWithValue("@EmpCode", EmpCode);
                comd.Parameters.AddWithValue("@LeaveType", LeaveType);
                comd.Parameters.AddWithValue("@LeaveCode", LeaveCode);
                comd.Parameters.AddWithValue("@FromDate", FromDate.Trim());
                comd.Parameters.AddWithValue("@ToDate", ToDate.Trim());
                comd.Parameters.AddWithValue("@Status", Status);
                comd.Parameters.AddWithValue("@UserBranchCode", UserBranchCode);
                comd.Parameters.AddWithValue("@UserId", UserId);
                comd.Parameters.AddWithValue("@ReportingPersonAccess", ReportingPersonAccess);
                return DBM.GetDataTable(comd);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable GetProjectWisePercentageApproval(string EmpCode, string Branch, string UserId)
        {
            SqlCommand comd = DBM.GetCommandSP("MonthlyAttendanceProjectWiseApproval");
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@BranchName", Branch);
            comd.Parameters.AddWithValue("@UserId", UserId);
            return DBM.GetDataTable(comd);
        }
        public DataTable GetEmpExtraPay(string EmpCode, string Month, string Year)
        {
            SqlCommand comd = DBM.GetCommandSP("rptEmpExtraPay");
            comd.Parameters.AddWithValue("@EmpCode", EmpCode);
            comd.Parameters.AddWithValue("@Month", Month);
            comd.Parameters.AddWithValue("@Year", Year);
            return DBM.GetDataTable(comd);
        }

        public DataTable GetAttritionChart(string FromDate, string Todate)
        {
            SqlCommand comd = DBM.GetCommandSP("AttritionChart");
            comd.Parameters.AddWithValue("@FromDate", FromDate);
            comd.Parameters.AddWithValue("@Todate", Todate);
            return DBM.GetDataTable(comd);
        }

        public static string ValidationsBeforeMonthClose()
        {
            return DBM.WriteToDbWithOutput(DBM.GetCommandSP("ValidationsBeforeMonthClose"));
        }

        public static DataTable GetMenuList()
        {
            return DBM.GetDataTable("GetMenuesByEmpCode");
        }

        #region Facility Master
        public static string FacilityCreate(string Code, string Description, bool IsActive)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_FacilityMasterCreate");
            comd.Parameters.AddWithValue("@Code", Code);
            comd.Parameters.AddWithValue("@Description", Description);
            comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(comd);
        }
        public static string FacilityUpdate(string Code, string Description, bool IsActive)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_FacilityMasterUpdate");
            comd.Parameters.AddWithValue("@Code", Code);
            comd.Parameters.AddWithValue("@Description", Description);
            comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(comd);
        }
        /// <summary>
        /// Get All Active Facility
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFacility()
        {
            return GetFacility("", "", "1"); // All Active Facility only
        }
        /// <summary>
        /// Get facility According To Applied Filter
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Description"></param>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public static DataTable GetFacility(string Code, string Description, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetFacilityMaster");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        #endregion
        #region Drawing Category Master
        public static string DrawingCategoryCreate(string Code, string Description, bool IsActive)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_DrawingCategoryMasterCreate");
            comd.Parameters.AddWithValue("@Code", Code);
            comd.Parameters.AddWithValue("@Description", Description);
            comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(comd);
        }
        public static string DrawingCategoryUpdate(string Code, string Description, bool IsActive)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_DrawingCategoryMasterUpdate");
            comd.Parameters.AddWithValue("@Code", Code);
            comd.Parameters.AddWithValue("@Description", Description);
            comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(comd);
        }
        /// <summary>
        /// Get All Active Drawing Category
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDrawingCategory()
        {
            return GetDrawingCategory("", "", "1"); // All Active Drawing Category only
        }
        /// <summary>
        /// Get Drawing Category According To Applied Filter
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Description"></param>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public static DataTable GetDrawingCategory(string Code, string Description, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetDrawingCategoryMaster");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        #endregion
        #region Drawing Type Master
        public static string DrawingTypeCreate(string Code, string Description, bool IsActive)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_DrawingTypeMasterCreate");
            comd.Parameters.AddWithValue("@Code", Code);
            comd.Parameters.AddWithValue("@Description", Description);
            comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(comd);
        }
        public static string DrawingTypeUpdate(string Code, string Description, bool IsActive)
        {
            SqlCommand comd = DBM.GetCommandSP("sp_DrawingTypeMasterUpdate");
            comd.Parameters.AddWithValue("@Code", Code);
            comd.Parameters.AddWithValue("@Description", Description);
            comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(comd);
        }
        /// <summary>
        /// Get All Active Drawing Type
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDrawingType()
        {
            return GetDrawingType("", "", "1"); // All Active Drawing Type only
        }
        /// <summary>
        /// Get Drawing Type According To Applied Filter
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Description"></param>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public static DataTable GetDrawingType(string Code, string Description, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetDrawingTypeMaster");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }
        #endregion

        //==========================Login===================ashu

        public DataTable checkUserDetail(string userName, string userPassword)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("LoginDetail", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            cmdUser.Parameters.AddWithValue("@UserId", userName);
            cmdUser.Parameters.AddWithValue("@password", userPassword);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable GetTaxRegimeType()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("TaxRegimeType", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        //===========================================================
        //==============================Task MGT====================06Aug2020===
        public DataTable GetMajorCategory(string Code, string CName, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("SP_GetCategoryMaster");
            Comd.Parameters.AddWithValue("@Code", Code);
            Comd.Parameters.AddWithValue("@Name", CName);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }

        public string insert_MajorCategory(string code, string Description, bool IsActive, string CreatedBy)
        {
            SqlCommand Comd = DBM.GetCommandSP("insert_MajorCategory");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@createdBy", CreatedBy);
            return DBM.WriteToDbWithOutput(Comd);
        }

        public string UpdateMajorCategory(string code, string Description, bool IsActive, string ModifyBy)
        {
            SqlCommand Comd = DBM.GetCommandSP("Update_MajorCategory");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Description", Description);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            Comd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetDepartmentmaster", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable GetMajorCategory()
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetMajorCategory", conUser);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable GetTaskDetail(string UId, string mode)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetTaskDetail", conUser);
            cmdUser.Parameters.AddWithValue("@createdBy", UId);
            cmdUser.Parameters.AddWithValue("@mode", mode);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        public DataTable GetTaskDetailArchive(string UId,string Empcode, string mode)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetTaskDetail_TaskArchive", conUser);
            cmdUser.Parameters.AddWithValue("@createdBy", UId);
            cmdUser.Parameters.AddWithValue("@Empcode", Empcode);
            cmdUser.Parameters.AddWithValue("@mode", mode);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable GetDepartmentWiseEmployee(string DeptId, string UId, string TaskType)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetAllEmployeeDeptWise", conUser);
            cmdUser.Parameters.AddWithValue("@DeptId", DeptId);
            cmdUser.Parameters.AddWithValue("@Uid", UId);
            cmdUser.Parameters.AddWithValue("@mode", TaskType);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }

        public DataTable GetTaskID(string UId)
        {
            DataTable dt = new DataTable();
            SqlConnection conUser = new SqlConnection(_strconnectionString);
            SqlCommand cmdUser = new SqlCommand("SP_GetTaskRefID", conUser);
            cmdUser.Parameters.AddWithValue("@Uid", UId);
            cmdUser.Connection = conUser;
            cmdUser.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmdUser);
            Sqladpter.Fill(dt);
            return dt;
        }
        //==============================Task MGT==================END===========

        //================================WFH=====================START===============

        public DataTable GetRegularworkGrid(string code, string Name, string dep, string div, string sec, string subdiv, string IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("regularworkbind");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Name", Name);
            Comd.Parameters.AddWithValue("@dept", dep);
            Comd.Parameters.AddWithValue("@sec", sec);
            Comd.Parameters.AddWithValue("@div", div);
            Comd.Parameters.AddWithValue("@subdiv", subdiv);
            Comd.Parameters.AddWithValue("@IsActive", IsActive == "-1" ? SqlString.Null : IsActive);
            return DBM.GetDataTable(Comd);
        }


        public string Regularwork(string code, string Name, string dep, string div, string sec, string subdiv, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("Sp_Regularwork");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Name", Name);
            Comd.Parameters.AddWithValue("@dept", dep);
            Comd.Parameters.AddWithValue("@sec", sec);
            Comd.Parameters.AddWithValue("@div", div);
            Comd.Parameters.AddWithValue("@Subdiv", subdiv);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        public string RegularworkUpdate(string code, string Name, string dep, string div, string sec, string subdiv, bool IsActive)
        {
            SqlCommand Comd = DBM.GetCommandSP("updateRegularwork");
            Comd.Parameters.AddWithValue("@Code", code);
            Comd.Parameters.AddWithValue("@Name", Name);
            Comd.Parameters.AddWithValue("@dept", dep);
            Comd.Parameters.AddWithValue("@sec", sec);
            Comd.Parameters.AddWithValue("@div", div);
            Comd.Parameters.AddWithValue("@Subdiv", subdiv);
            Comd.Parameters.AddWithValue("@IsActive", IsActive);
            return DBM.WriteToDbWithOutput(Comd);
        }
        //=========================end

        public DataTable BindonthlyCompof(string BranchCode, string EmpCode,string Week)
        {
            DataTable dt = new DataTable();
            SqlConnection concnt = new SqlConnection(_strconnectionString);
            SqlCommand cmd = new SqlCommand("[SP_EMPCOMPOFFNEW]", concnt);
            cmd.Connection = concnt;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Sqladpter = new SqlDataAdapter(cmd);
            //cmd.Parameters.AddWithValue("@DOJ", (DOJ != "") ? DOJ : Convert.DBNull);
            cmd.Parameters.AddWithValue("@BranchCode", BranchCode);
            cmd.Parameters.AddWithValue("@EmpCode", (EmpCode != "") ? EmpCode : Convert.DBNull);
            cmd.Parameters.AddWithValue("@Week", Week);
            Sqladpter.Fill(dt);
            return dt;
        }
    }
}