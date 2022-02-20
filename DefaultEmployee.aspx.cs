using Reports.DataAccessLayer;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
public partial class DefaultEmployee : System.Web.UI.Page
{
    EmployeeBAL EmpBal = new EmployeeBAL();
    #region
    protected void GetEmployeeDetail(string EmployeeCode)
    {
        try
        {
            DataTable dtEmpDetail = EmpBal.GetEmployeeData(EmployeeCode);
            DataRow dr = dtEmpDetail.Rows[0];
            if (dtEmpDetail.Rows.Count <= 0)
            {
                UtilityUI.ShowAlert(this, "Employee Code is Blank !");
                return;
            }
            imgProffile2.ImageUrl = dr["ImagesPath"].ToString();
            lblempcode.Text = EmployeeCode;
            lblEmpName.Text = dr["EmployeeName"].ToString();
            txtTitle.Text = dr["Title"].ToString();
            txtFirstName.Text = dr["FName"].ToString();
            txtMiddleName.Text = dr["MName"].ToString();
            txtLastName.Text = dr["LName"].ToString();
            txtDOB.Text = dr["DateOfBirth"].ToString();
            txtDOJ.Text = dr["DateOfJoining"].ToString();
            txtMobileNo.Text = dr["ContactNo"].ToString();
            txtGender.Text = dr["Sex"].ToString();
            txtGrade.Text = dr["Grade"].ToString();
            txtSubGrade.Text = dr["SubGrade"].ToString();
            txtDesignation.Text = dr["Designation"].ToString();
            txtDevision.Text = dr["Division"].ToString();
            txtSection.Text = dr["Section"].ToString();
            txtSubSection.Text = dr["SubSection"].ToString();
            txtDepartment.Text = dr["Department"].ToString();
            txtBranch.Text = dr["Branch"].ToString();
            //txtRole.Text = dr["Role"].ToString();
            txtRegion.Text = dr["Region"].ToString();
            txtTechcomm.Text = dr["TechComm"].ToString();
            //txtEmpType.Text = dr["EmpType"].ToString();
            //txtCostCenter.Text = dr["CostCenter"].ToString();
            //txtCurrency.Text = dr["Currency"].ToString();
            //txtCardNo.Text = dr["CardNo"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtEmpHead.Text = dr["ReportingPerson"].ToString();
            txtOfficeEmail.Text = dr["OfficeEmail"].ToString();
            txtOfficeMobileNo.Text = dr["OfficeMobile"].ToString();

            txtCurrentAddress.Text = dr["Address"].ToString();
            txtCityName.Text = dr["City"].ToString();
            txtStateName.Text = dr["State"].ToString();
            txtCountry.Text = dr["Country"].ToString();
            txtpinCode.Text = dr["PinCode"].ToString();

            txtPermanentAddress.Text = dr["PermanentAddress"].ToString();
            txtPermanentContactNo.Text = dr["PermanentContactNo"].ToString();
            txtPermanentCity.Text = dr["PermanentCity"].ToString();
            txtPermanentState.Text = dr["PermanentState"].ToString();
            txtPermantCountry.Text = dr["PermanentCountry"].ToString();
            txtAddressPinCode.Text = dr["PermanentPinCode"].ToString();

            txtpersonName.Text = dr["RName"].ToString();
            txtpersonAddress.Text = dr["RAddess"].ToString();
            txtpersonCity.Text = dr["RCity"].ToString();
            txtpersonState.Text = dr["RState"].ToString();
            txtPersonCountry.Text = dr["RCountry"].ToString();
            txtPersonPincode.Text = dr["RPinCode"].ToString();
            txtPersonEmail.Text = dr["REmailID"].ToString();              
            txtpersonMobileno.Text = dr["RMobileNo"].ToString();

            //Payroll Detail
            ckEntitlementToESI.Checked = Convert.ToBoolean(dr["EntitlementToESI"].ToString());
            ckEntitlementToPF.Checked = Convert.ToBoolean(dr["EntitlementToPF"].ToString());
            ckPFOnActualSalary.Checked = Convert.ToBoolean(dr["PFDeductionOnActualSalary"].ToString());
            ckEmployerPFOnActualSalary.Checked = Convert.ToBoolean(dr["EmployerPFDeductionOnActualSalary"].ToString());
            chkGratuity.Checked = Convert.ToBoolean(dr["EntitlementToGratuity"].ToString());
            
            txtNoOfMonthForConfirmation.Text = dr["ConfirmationMonths"].ToString();
            txtConfirmationDate.Text = dr["ConfirmationDate"].ToString();
            chkConfirmed.Checked = Convert.ToBoolean(dr["Confirmed"].ToString());
            txtResignationDate.Text = dr["ResignationDate"].ToString();
            txtStatusStatusAdmin.Text = dr["Status"].ToString();
            txtOldEmployeeCode.Text = dr["OLDEmployeeCode"].ToString();
            ckSalaryStopped.Checked = Convert.ToBoolean(dr["SalaryStopped"].ToString());
            txtLeaveDate.Text = dr["RelievingDate"].ToString();
            txtRemarksAdmin.Text = dr["RelievingRemarks"].ToString();
            txtHoldSalaryRemark.Text = dtEmpDetail.Rows[0]["HoldSalaryRemarks"].ToString();
            txtLastRevisionDate.Text = dtEmpDetail.Rows[0]["LastRevisionDate"].ToString();
            string str = dr["LeaveType"].ToString();
            string[] strLeaveType = str.Split(',');
            foreach (ListItem item in chklistLeaveType.Items)
            {
                foreach (string s in strLeaveType)
                {
                    if (s == item.Value)
                    {
                        item.Selected = true;
                        continue;
                    }
                }
            }
            txtPaymentMethod.Text = dr["PaymentMethod"].ToString();
            txtBankCode.Text = dr["Bank"].ToString();
            txtBankBranch.Text = dtEmpDetail.Rows[0]["BankAddress"].ToString();
            txtifsc.Text = dr["IFSC"].ToString();
            txtAccountNo.Text = dr["AccountNo"].ToString();

            //Personal Detail
            txtperfather.Text = dr["FatherName"].ToString();
            txtmotherName.Text = dr["MotherName"].ToString();
            txtBloodGroup.Text = dr["BloodGroup"].ToString();
            txtperSpouseName.Text = dr["SpouseName"].ToString();
            txtMaritalStatus.Text = dr["MaritalStatus"].ToString();
            txtperMarriageDate.Text = dr["MarriageDate"].ToString();
            txtperESINo.Text = dr["ESINO"].ToString();
            txtperESIDis.Text = dr["ESIDespensary"].ToString();
            txtperPFNo.Text = dr["PFNo"].ToString();
            txtUANNo.Text = dr["UANNo"].ToString();
            txtpassportNo.Text = dr["passportNo"].ToString();
            txtAdharcard.Text = dr["AdharCardNo"].ToString();
            txtperDL.Text = dr["DLNumber"].ToString();
            txtperSSN.Text = dr["SocialSecurityNo"].ToString();
            txtperTotalExp.Text = dr["PreviousExperience"].ToString();
            txtperRelExp.Text = dr["CurrentExperience"].ToString();
            chkOverSeasEligibility.Checked = Convert.ToBoolean(dtEmpDetail.Rows[0]["OverSeasEligibility"].ToString());

            //TAX
            txtPanNo.Text = dr["PANNo"].ToString();
            txtPreviosCompanyIncome.Text = Convert.ToString(dr["PreviousCompanyIncome"]); //IncomeInPreviousCompany
            txtPreviosCompanyTDS.Text = Convert.ToString(dr["PreviousCompanyTDS"]); //TDSDeductionInPreviousCompany

            BindWorkExp(EmployeeCode);
            BindFD(EmployeeCode);
            BindQualification(EmployeeCode);
            BindAssetsdetail(EmployeeCode);
            BindPayElement(EmployeeCode);
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    protected void BindWorkExp(string EmpCode)
    {
        UtilityUI.FillGrid(gvWorkExp, EmpBal.GetWorkExperiance(EmpCode));
    }
    protected void BindFD(string EmpCode)
    {
        UtilityUI.FillGrid(gvFD, EmpBal.GetFamilyDetail(EmpCode));
    }
    protected void BindQualification(string EmpCode)
    {
        UtilityUI.FillGrid(GvQualification, EmpBal.BindQualification(EmpCode));
    }
    protected void BindAssetsdetail(string EmpCode)
    {
        UtilityUI.FillGrid(gvAssets,EmpBal.BindAssetsDetail(EmpCode));
    }
    private void BindPayElement(string EmployeeCode)
    {
        DataSet ds = DBM.GetDataSet("GetEmployeePayStructure '" + EmployeeCode + "'");
        if (ds.Tables.Count > 0)
        {
            decimal MonthlyPayelement = 0, YearlyPayelement = 0, MonthlyREIMBURSEMENT = 0, YearlyREIMBURSEMENT = 0;
            UtilityUI.FillGrid(gvPayElement, ds.Tables[0]);
            MonthlyPayelement = UtilityUI.IsValidDecimal(gvPayElement.FooterRow.Cells[1].Text) ? Convert.ToDecimal(gvPayElement.FooterRow.Cells[1].Text) : 0;
            YearlyPayelement = UtilityUI.IsValidDecimal(gvPayElement.FooterRow.Cells[2].Text) ? Convert.ToDecimal(gvPayElement.FooterRow.Cells[2].Text) : 0;

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                UtilityUI.FillGrid(gvPayElementReimbursement, ds.Tables[1]);
                MonthlyREIMBURSEMENT = UtilityUI.IsValidDecimal(gvPayElementReimbursement.FooterRow.Cells[1].Text) ? Convert.ToDecimal(gvPayElementReimbursement.FooterRow.Cells[1].Text) : 0;
                YearlyREIMBURSEMENT = UtilityUI.IsValidDecimal(gvPayElementReimbursement.FooterRow.Cells[2].Text) ? Convert.ToDecimal(gvPayElementReimbursement.FooterRow.Cells[2].Text) : 0;
            }
            lblMonthCTC.InnerText = (MonthlyPayelement + MonthlyREIMBURSEMENT).ToString();
            lblYearlyCTC.InnerText = (YearlyPayelement + YearlyREIMBURSEMENT).ToString();
        }
    }
    protected void BindLeaveType()
    {
        DataTable dt = SqlBAL.GetBindLeaveType();
        chklistLeaveType.DataSource = dt;
        chklistLeaveType.DataTextField = "LeaveName";
        chklistLeaveType.DataValueField = "LeaveCode";
        chklistLeaveType.DataBind();
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindLeaveType();
                string EmpCode = Request.QueryString["EmpCode"] != null ? Request.QueryString["EmpCode"].ToString() : Session["Userid"].ToString();
                GetEmployeeDetail(EmpCode);
            }
        }
        catch (Exception ex)
        {
            
        }
    }
    protected void gvPayElement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                decimal Amount = 0, YearlyAmount = 0;
                foreach (GridViewRow gvr in gvPayElement.Rows)
                {
                    Amount += Convert.ToDecimal(gvr.Cells[1].Text);
                    YearlyAmount += Convert.ToDecimal(gvr.Cells[2].Text);
                }
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = Amount.ToString();
                e.Row.Cells[2].Text = YearlyAmount.ToString();
            }
        }
        catch (Exception)
        {
        }
    }
    protected void gvPayElementReimbursement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                decimal Amount = 0, YearlyAmount = 0;
                foreach (GridViewRow gvr in gvPayElementReimbursement.Rows)
                {
                    Amount += Convert.ToDecimal(gvr.Cells[1].Text);
                    YearlyAmount += Convert.ToDecimal(gvr.Cells[2].Text);
                }
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = Amount.ToString();
                e.Row.Cells[2].Text = YearlyAmount.ToString();
            }
        }
        catch (Exception)
        {
        }
    }
}