using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reports.DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

public partial class COApplication : System.Web.UI.Page
{
    #region
    void CheckPermission()
    {
        ViewState["AllEmployeeAccess"] = ViewState["AllEmployeeAccess"] == null ? Session["AllEmployeeAccess"] : ViewState["AllEmployeeAccess"];
        //ViewState["AllBranchAccess"] = ViewState["AllBranchAccess"] == null ? Session["AllBranchAccess"] : ViewState["AllBranchAccess"];
        if (ViewState["AllEmployeeAccess"] == null || Convert.ToInt32(ViewState["AllEmployeeAccess"]) == 0)
        {
            txtEmployee.Text = Session["EmployeeNameCode"].ToString();
            txtEmployee.Enabled = false;
        }
    }
    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckPermission();
            if (!IsPostBack)
            { 
                
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string EmpCode = UtilityUI.GetEmpCode(txtEmployee.Text.Trim());
        if (EmpCode.Length <= 0)
        {
            UtilityUI.ShowAlert(this, "w", "Select Employee.");
            txtEmployee.Focus();
            return;
        }
        if(!UtilityUI.IsValidDate(txtCoDate.Text.Trim()))
        {
            UtilityUI.ShowAlert(this, "w", "Select valid Date.");
            txtCoDate.Focus();
            return;
        }
        if (txtRemarks.Text.Trim().Length <= 20)
        {
            UtilityUI.ShowAlert(this, "w", "Remarks Require, Minimum 20 Characters.");
            txtEmployee.Focus();
            return;
        }
        SqlCommand Comd = DBM.GetCommandSP("InsertCO_MonthlyCO");
        Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
        Comd.Parameters.AddWithValue("@CODate", txtCoDate.Text.Trim());
        Comd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
        Comd.Parameters.AddWithValue("@UserId", Session["UserId"]);
        string rslt = DBM.WriteToDbWithOutput(Comd);
        if (rslt.ToUpper() == "OK")
        {
            UtilityUI.ShowAlert(this, "s", "Saved Successfully !");
            txtCoDate.Text = txtRemarks.Text = "";
        }
        else
        {
            UtilityUI.ShowAlert(this, "w", rslt);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("COApplication.aspx");
    }
}