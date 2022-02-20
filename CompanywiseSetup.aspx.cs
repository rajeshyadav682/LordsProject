using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CompanywiseSetup : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            if (!IsPostBack)
            {
                divBonusDisplay.Style.Add("display", "None");
                divgeneraldisplay.Style.Add("display", "Block");
                //divgeneraldisplay.Style.Add("display", "None");
                divattendancedisplay.Style.Add("display", "None");
                divindustrialdisplay.Style.Add("display", "None");
                divpolicydisplay.Style.Add("display", "None");
                divgratutitydisplay.Style.Add("display", "None");
                divleavesdisplay.Style.Add("display", "None");
                //divView.Visible = true;
                divSave.Visible = true;

                
                display();
                GetDEtail();

                DateTime dt = DateTime.Parse("12:35 PM");
                //DateTime dt = System.DateTime.Now;
                MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                if (dt.ToString("tt") == "AM")
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                }
                else 
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                }
                txtcoretimingstart.SetTime(dt.Hour, dt.Minute, am_pm);
                txtcoretimimgend.SetTime(dt.Hour, dt.Minute, am_pm);
                txtstarttime.SetTime(dt.Hour, dt.Minute, am_pm);
                txtendtime.SetTime(dt.Hour, dt.Minute, am_pm);
                txtstarttimegrace.SetTime(dt.Hour, dt.Minute, am_pm);

                
           }
            }
        //}
        catch { }
            }

    void display()
    {
        ViewState["CompanyWise"] = DBM.GetDataTable("Display_Companywise_Setup");
        //GridLeave.DataSource = (DataTable)ViewState["CompanyWise"];
        //GridLeave.DataBind();
    }
    void clear()
    {
        chkemployee.Checked = false;
        txtemployerpfcon.Text = txtPF.Text = txtVPF.Text = txtVPFamount.Text = txtVPFpercentage.Text = txtVPFamountlimit.Text = "";
        txtbonusdeclarationdate.Text = txtbonus.Text = txtbonussalarymaximum.Text = txtexexgratiasalaryexceedlimit.Text = "";
        txtexgratiasalarymaxilimit.Text = txtminworkingdays.Text = txtdurationofshortleave.Text = txtnoofhoursinhalfday.Text = "";
        txtnoOfshortleavesinamonth.Text = txtcompensatoryleaves.Text = "";
        chkcontinuleave.Checked = false;
        ddlpayrollsystem.SelectedIndex = ddlattendancesystm.SelectedIndex = 0;
        chkpendingleaveappli.Checked = false;
        txtnoofhrperday.Text = txtotmultiplier.Text = "";
        checklatecomingapplicable.Checked = false;
        ddldefultattendncestatus.SelectedIndex = 0;
        chkOTapllicable.Checked = chkmonthlyattendance.Checked = false;
        chkconsidercoreforflexihalfdays.Checked = false; txtnoOFlatecomingmonth.Text = "";
        chkOtapproval.Checked = chktimesheetinfo.Checked = false;
        txtminnoOFyear.Text = txtNoOfdayssalary.Text = txtnoOfdaysinmonth.Text = txtnoOfdaysformentcompensation.Text = txtnoOfdaysformentmonthcompensation.Text = txtminageforemployment.Text = "";
        chkrevisedamteditableinpay.Checked = chklearbasedonleavingdate.Checked = chkfullandfinalsalary.Checked = chkallowTDSmanually.Checked = chkleavebalavailble.Checked = chkPTDSonlyonmonthlyelement.Checked = chkcalculatevariable.Checked = chkcalculateprevmnt.Checked = chkroundeachpayelement.Checked = chkemployeeselection.Checked = false;
        txtLEpercentdeponbasic.Text = "";
    }
    void GetDEtail()
    {
        DataTable dt = (DataTable)ViewState["CompanyWise"];
        if (dt.Rows.Count > 0)
        {
            //CheckBox chk = (CheckBox)e.Row.FindControl("chkemployer");
            //chkemployer=Convert.ToBoolean(dt.Rows[0]["EmployeeDeductionOnActualSalary"].ToString());
            //chkemployee.Checked = Convert.ToBoolean(dt.Rows[0]["EmployeeDeductionOnActualSalary"]);
            if (chkemployee.Checked.ToString() == "YES")
            {
                chkemployee.Checked = true;
            }
            else
            {
                chkemployee.Checked = false;
            }
            if (chkemployer.Checked.ToString() == "YES")
            {
                chkemployer.Checked = true;
            }
            else
            {
                chkemployer.Checked = false;
            }
            //chkemployer.Checked = Convert.ToBoolean(dt.Rows[0]["EmployeeDeductionOnActualSalary"].ToString());
            txtemployerpfcon.Text = dt.Rows[0]["EmployerPFContributionSalaryLimit"].ToString();
            txtPF.Text = dt.Rows[0]["PF"].ToString();
            txtVPF.Text = dt.Rows[0]["VPF"].ToString();
            txtVPFamount.Text = dt.Rows[0]["VPFAmount"].ToString();
            txtVPFpercentage.Text = dt.Rows[0]["VPFPercentagelimit"].ToString();
            txtVPFamountlimit.Text = dt.Rows[0]["VPFAmountlimit"].ToString();
            txtbonusdeclarationdate.Text = dt.Rows[0]["Bonus Declaration Date"].ToString();
            txtbonus.Text = dt.Rows[0]["Bonus"].ToString();
            txtbonussalarymaximum.Text = dt.Rows[0]["Bonus Salary Maximum Limit"].ToString();
            txtexexgratiasalaryexceedlimit.Text = dt.Rows[0]["[Exgratia Salary Maximum LimitExExgratia Salary Exceed Limit]"].ToString();
            txtexgratiasalarymaxilimit.Text = dt.Rows[0]["Exgratia Salary Maximum Limit"].ToString();
            txtminworkingdays.Text = dt.Rows[0]["Min. Working Days"].ToString();
            txtdurationofshortleave.Text = dt.Rows[0]["Duration of Short Leave (In hrs)"].ToString();
            txtnoofhoursinhalfday.Text = dt.Rows[0]["No of hours in Half-Day"].ToString();
            txtnoOfshortleavesinamonth.Text = dt.Rows[0]["No. of Short Leaves in a month"].ToString();
            txtcompensatoryleaves.Text = dt.Rows[0]["Compensatory Leaves to be credited against"].ToString();
            chkcontinuleave.Checked = Convert.ToBoolean(dt.Rows[0]["Continuous Leaves to include Holidays/Off-Days"].ToString());
            ddlpayrollsystem.SelectedValue = dt.Rows[0]["Payroll System (Based on)"].ToString();
            ddlattendancesystm.SelectedValue = dt.Rows[0]["Attendance System (Based On)"].ToString();
            chkpendingleaveappli.Checked = Convert.ToBoolean(dt.Rows[0]["Pending Leave Application Check"].ToString());
            txtnoofhrperday.Text = dt.Rows[0]["Number Of Hours Per Day"].ToString();
            checklatecomingapplicable.Checked = Convert.ToBoolean(dt.Rows[0]["Late Coming Applicable"].ToString());
            txtotmultiplier.Text = dt.Rows[0]["OT Multiplier"].ToString();
            ddldefultattendncestatus.SelectedValue = dt.Rows[0]["Default Attendance Status"].ToString();
            chkOTapllicable.Checked = Convert.ToBoolean(dt.Rows[0]["OT Applicable"].ToString());
            chkmonthlyattendance.Checked = Convert.ToBoolean(dt.Rows[0]["Monthly Attendance Processed"].ToString());
            // txtcoretimingstart.= dt.Rows[0]["Core Timing Start"].ToString();
            //txtcoretimimgend.Text = dt.Rows[0]["Core Timing End"].ToString();
            chkconsidercoreforflexihalfdays.Checked = Convert.ToBoolean(dt.Rows[0]["Consider Core for Flexi Half-Days"].ToString());
            //txtstarttime.Text = dt.Rows[0]["Start Time"].ToString();
            //txtendtime.Text = dt.Rows[0]["End Time"].ToString();
            //txtstarttimegrace.Text = dt.Rows[0]["Start Time (Including Grace)"].ToString();
            txtnoOFlatecomingmonth.Text = dt.Rows[0]["No. of Late Comings in a month"].ToString();
            chkOtapproval.Checked = Convert.ToBoolean(dt.Rows[0]["OT Approval Check"].ToString());
            chktimesheetinfo.Checked = Convert.ToBoolean(dt.Rows[0]["Timesheet Information Check"].ToString());
            txtminnoOFyear.Text = dt.Rows[0]["MinNoOfYears"].ToString();
            txtNoOfdayssalary.Text = dt.Rows[0]["NoOfDaysSalary"].ToString();
            txtnoOfdaysinmonth.Text = dt.Rows[0]["NoOfDaysInMonth"].ToString();
            txtnoOfdaysformentcompensation.Text = dt.Rows[0]["NoofDaysForRetenchment Compensation"].ToString();
            txtnoOfdaysformentmonthcompensation.Text = dt.Rows[0]["NoofDaysInMonthForRetenchment Compensation"].ToString();
            txtminageforemployment.Text = dt.Rows[0]["Min.Age for Employment"].ToString();
            chkrevisedamteditableinpay.Checked = Convert.ToBoolean(dt.Rows[0]["Revised Amt Editable in Pay Revision"].ToString());
            chklearbasedonleavingdate.Checked = Convert.ToBoolean(dt.Rows[0]["LEAR Based on Leaving Date"].ToString());
            chkfullandfinalsalary.Checked = Convert.ToBoolean(dt.Rows[0]["Full &Final Salary calculation to be based on Leaving Date"].ToString());
            chkallowTDSmanually.Checked = Convert.ToBoolean(dt.Rows[0]["Allow TDS manually in F&F"].ToString());
            chkleavebalavailble.Checked = Convert.ToBoolean(dt.Rows[0]["Check Leave Bal. available upto Year End"].ToString());
            chkPTDSonlyonmonthlyelement.Checked = Convert.ToBoolean(dt.Rows[0]["PTDS only on Monthly elements"].ToString());
            chkcalculatevariable.Checked = Convert.ToBoolean(dt.Rows[0]["Calculate Variable Pay Element"].ToString());
            chkcalculateprevmnt.Checked = Convert.ToBoolean(dt.Rows[0]["Calculate Prev Mnt LeaveArrear"].ToString());
            chkroundeachpayelement.Checked = Convert.ToBoolean(dt.Rows[0]["Round each pay element"].ToString());
            chkemployeeselection.Checked = Convert.ToBoolean(dt.Rows[0]["Employee selection allowed during Monthly Salary Posting"].ToString());
            txtLEpercentdeponbasic.Text = dt.Rows[0]["LE Percent dep on Basic"].ToString();

        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        try
        {
            DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", txtcoretimingstart.Hour, txtcoretimingstart.Minute, txtcoretimingstart.Second, txtcoretimingstart.AmPm));
            ClientScript.RegisterStartupScript(this.GetType(), "time", "alert('Selected Time: " + time.ToString("hh:mm:ss tt") + "');", true);
            DateTime time1 = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", txtcoretimimgend.Hour, txtcoretimimgend.Minute, txtcoretimimgend.Second, txtcoretimimgend.AmPm));
            ClientScript.RegisterStartupScript(this.GetType(), "time1", "alert('Selected time1: " + time.ToString("hh:mm:ss tt") + "');", true);
            DateTime starttime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", txtstarttime.Hour, txtstarttime.Minute, txtstarttime.Second, txtstarttime.AmPm));
            ClientScript.RegisterStartupScript(this.GetType(), "time", "alert('Selected starttime: " + time.ToString("hh:mm:ss tt") + "');", true);
            DateTime endtime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", txtendtime.Hour, txtendtime.Minute, txtendtime.Second, txtendtime.AmPm));
            ClientScript.RegisterStartupScript(this.GetType(), "endtime", "alert('Selected time1: " + time.ToString("hh:mm:ss tt") + "');", true);
            DateTime timegrace = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", txtstarttimegrace.Hour, txtstarttimegrace.Minute, txtstarttimegrace.Second, txtstarttimegrace.AmPm));
            ClientScript.RegisterStartupScript(this.GetType(), "timegrace", "alert('Selected Time: " + time.ToString("hh:mm:ss tt") + "');", true);
            SqlCommand cmd = DBM.GetCommandSP("SP_CompanyWiseSetup");
            //decimal value =  Convert.ToDecimal(txtPF.Text);
            //decimal value1 = Convert.ToDecimal(txtVPF.Text);
            //decimal value =
            //cmd.Parameters.AddWithValue("@Price",value);
            cmd.Parameters.AddWithValue("@EmployerDeductionOnActualSalary", chkemployer.Checked.ToString());
            cmd.Parameters.AddWithValue("@EmployeeDeductionOnActualSalary", chkemployee.Checked.ToString());
            cmd.Parameters.AddWithValue("@EmployerPFContributionSalaryLimit", txtemployerpfcon.Text.ToString());
            if (txtPF.Text != "" && txtPF.Text != null)
            {
                cmd.Parameters.AddWithValue("@PF", txtPF.Text);
               
            }
            else
            {
                cmd.Parameters.AddWithValue("@PF","0.00");
             }
             if (txtVPF.Text != "" && txtPF.Text != null)
            {
                cmd.Parameters.AddWithValue("@VPF", txtVPF.Text);
             }
            else
            {
                cmd.Parameters.AddWithValue("@VPF", "0.00");
            }

             if (txtVPFamount.Text != "" && txtVPFamount.Text != null)
            {
                cmd.Parameters.AddWithValue("@VPFAmount", txtVPFamount.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@VPFAmount", "0.00");
            }

             if (txtVPFpercentage.Text != "" && txtVPFpercentage.Text != null)
            {
                cmd.Parameters.AddWithValue("@VPFPercentagelimit", txtVPFpercentage.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@VPFPercentagelimit", "0.00");
            }

            if (txtVPFamountlimit.Text != "" && txtVPFamountlimit.Text != null)
            {
                cmd.Parameters.AddWithValue("@VPFAmountlimit", txtVPFamountlimit.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@VPFAmountlimit", "0.00");
            }

            if (txtbonusdeclarationdate.Text != "" && txtbonusdeclarationdate.Text != null)
            {
                cmd.Parameters.AddWithValue("@BonusDeclarationDate", txtbonusdeclarationdate.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BonusDeclarationDate", txtbonusdeclarationdate.Text);
            }

            if (txtbonus.Text != "" && txtbonus.Text != null)
            {
                cmd.Parameters.AddWithValue("@Bonus", txtbonus.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Bonus", "0.00");
            }

            if (txtbonussalarymaximum.Text != "" && txtbonussalarymaximum.Text != null)
            {
                cmd.Parameters.AddWithValue("@BonusSalaryMaximumLimit", txtbonussalarymaximum.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BonusSalaryMaximumLimit", "0.00");
            }

            if (txtexexgratiasalaryexceedlimit.Text != "" && txtexexgratiasalaryexceedlimit.Text != null)
            {
                cmd.Parameters.AddWithValue("@ExgratiaSalaryMaximumLimitExExgratiaSalaryExceedLimit", txtexexgratiasalaryexceedlimit.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ExgratiaSalaryMaximumLimitExExgratiaSalaryExceedLimit", "0.00");
            }

            if (txtexgratiasalarymaxilimit.Text != "" && txtexgratiasalarymaxilimit.Text != null)
            {
                cmd.Parameters.AddWithValue("@ExgratiaSalaryMaximumLimit", txtexgratiasalarymaxilimit.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ExgratiaSalaryMaximumLimit", "0.00");
            }

            if (txtminworkingdays.Text != "" && txtminworkingdays.Text != null)
            {
                cmd.Parameters.AddWithValue("@MinWorkingDays", txtminworkingdays.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MinWorkingDays", "0.00");
            }

            if (txtdurationofshortleave.Text != "" && txtdurationofshortleave.Text != null)
            {
                cmd.Parameters.AddWithValue("@DurationofShortLeave", txtdurationofshortleave.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DurationofShortLeave", "0.00");
            }

            if (txtnoofhoursinhalfday.Text != "" && txtnoofhoursinhalfday.Text != null)
            {
                cmd.Parameters.AddWithValue("@NoofhoursinHalfDay", txtnoofhoursinhalfday.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NoofhoursinHalfDay", "0.00");
            }

            if (txtnoOfshortleavesinamonth.Text != "" && txtnoOfshortleavesinamonth.Text != null)
            {
                cmd.Parameters.AddWithValue("@NoOfShortLeavesinamonth", txtnoOfshortleavesinamonth.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NoOfShortLeavesinamonth", "0.00");
            }
            cmd.Parameters.AddWithValue("@CompensatoryLeavestobecreditedagainst", txtcompensatoryleaves.Text.ToString());
            //if (txtVPFamount.Text != "" && txtVPFamount.Text != null)
            //{
            //    cmd.Parameters.AddWithValue("@VPFAmount", txtVPFamount.Text);
            //}
            //else
            //{
            //    txtVPFamount.Text = "0.00";
            //}
            cmd.Parameters.AddWithValue("@ContinuousLeavestoincludeHolidays", chkcontinuleave.Checked.ToString());
            cmd.Parameters.AddWithValue("@PayrollSystem", ddlpayrollsystem.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@AttendanceSystem", ddlattendancesystm.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@PendingLeaveApplicationCheck", chkpendingleaveappli.Checked.ToString());

            if (txtnoofhrperday.Text != "" && txtnoofhrperday.Text != null)
            {
                cmd.Parameters.AddWithValue("@NumberOfHoursPerDay", txtnoofhrperday.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NumberOfHoursPerDay", "0.00");
            }
            cmd.Parameters.AddWithValue("@LateComingApplicable", checklatecomingapplicable.Checked.ToString());

            if (txtotmultiplier.Text != "" && txtotmultiplier.Text != null)
            {
                cmd.Parameters.AddWithValue("@OTMultiplier", txtotmultiplier.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@OTMultiplier", "0.00");
            }
            cmd.Parameters.AddWithValue("@DefaultAttendanceStatus", ddldefultattendncestatus.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@OTApplicable", chkOTapllicable.Checked.ToString());
            cmd.Parameters.AddWithValue("@MonthlyAttendanceProcessed", chkmonthlyattendance.Checked.ToString());
            cmd.Parameters.AddWithValue("@CoreTimingStart", time.ToString());
            cmd.Parameters.AddWithValue("@CoreTimingEnd", time1.ToString());
            cmd.Parameters.AddWithValue("@ConsiderCoreforFlexiHalfDays", chkconsidercoreforflexihalfdays.Checked.ToString());
            cmd.Parameters.AddWithValue("@StartTime", starttime.ToString());
            cmd.Parameters.AddWithValue("@EndTime", endtime.ToString());
            cmd.Parameters.AddWithValue("@StartTimeIncludingGrace", timegrace.ToString());
            cmd.Parameters.AddWithValue("@NoofLateComingsinamonth", txtnoOFlatecomingmonth.Text.ToString());
            cmd.Parameters.AddWithValue("@OTApprovalCheck", chkOtapproval.Checked.ToString());
            cmd.Parameters.AddWithValue("@TimesheetInformationCheck", chktimesheetinfo.Checked.ToString());

            if (txtminnoOFyear.Text != "" && txtminnoOFyear.Text != null)
            {
                cmd.Parameters.AddWithValue("@MinNoOfYears", txtminnoOFyear.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MinNoOfYears", "0.00");
            }

            if (txtNoOfdayssalary.Text != "" && txtNoOfdayssalary.Text != null)
            {
                cmd.Parameters.AddWithValue("@NoOfDaysSalary", txtNoOfdayssalary.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NoOfDaysSalary","0.00");
            }

            if (txtnoOfdaysinmonth.Text != "" && txtnoOfdaysinmonth.Text != null)
            {
                cmd.Parameters.AddWithValue("@NoOfDaysInMonth", txtnoOfdaysinmonth.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NoOfDaysInMonth", "0.00");
            }

            if (txtnoOfdaysformentcompensation.Text != "" && txtnoOfdaysformentcompensation.Text != null)
            {
                cmd.Parameters.AddWithValue("@NoofDaysForRetenchmentCompensation", txtnoOfdaysformentcompensation.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NoofDaysForRetenchmentCompensation", "0.00");
            }

            if (txtnoOfdaysformentmonthcompensation.Text != "" && txtnoOfdaysformentmonthcompensation.Text != null)
            {
                cmd.Parameters.AddWithValue("@NoofDaysInMonthForRetenchmentCompensation", txtnoOfdaysformentmonthcompensation.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NoofDaysInMonthForRetenchmentCompensation", "0.00");
            }

            if (txtminageforemployment.Text != "" && txtminageforemployment.Text != null)
            {
                cmd.Parameters.AddWithValue("@MinAgeforEmployment", txtminageforemployment.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MinAgeforEmployment", "0.00");
            }
            cmd.Parameters.AddWithValue("@RevisedAmtEditableinPayRevision", chkrevisedamteditableinpay.Checked.ToString());
            cmd.Parameters.AddWithValue("@LEARBasedonLeavingDate", chklearbasedonleavingdate.Checked.ToString());
            cmd.Parameters.AddWithValue("@FullFinalSalarycalculationtobebasedonLeavingDate", chkfullandfinalsalary.Checked.ToString());
            cmd.Parameters.AddWithValue("@AllowTDSmanuallyinFF", chkallowTDSmanually.Checked.ToString());
            cmd.Parameters.AddWithValue("@CheckLeaveBalavailableuptoYearEnd", chkleavebalavailble.Checked.ToString());
            cmd.Parameters.AddWithValue("@PTDSonlyonMonthlyelements", chkPTDSonlyonmonthlyelement.Checked.ToString());
            cmd.Parameters.AddWithValue("@CalculateVariablePayElement", chkcalculatevariable.Checked.ToString());
            cmd.Parameters.AddWithValue("@CalculatePrevMntLeaveArrear", chkcalculateprevmnt.Checked.ToString());
            cmd.Parameters.AddWithValue("@Roundeachpayelement", chkroundeachpayelement.Checked.ToString());
            cmd.Parameters.AddWithValue("@EmployeeselectionallowedduringMonthlySalaryPosting", chkemployeeselection.Checked.ToString());
            cmd.Parameters.AddWithValue("@LEPercentdeponBasic", txtLEpercentdeponbasic.Text.ToString());
            cmd.Parameters.Add("@rslt", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            DBM.WriteToDb(cmd);
            string rslt = cmd.Parameters["@rslt"].Value.ToString();
            if (rslt.ToUpper() == "OK")
            {
                UtilityUI.ShowAlert(this, "s", "Saved Successfully ");
                divSave.Visible = true;
                //divView.Visible = true;
                clear();
                GetDEtail();
            }
            else
            {
                UtilityUI.ShowAlert(this, "s", "Update Successfully ");
                clear();
                GetDEtail();
            }
            
        }
        catch { }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanywiseSetup.aspx");
    }
}