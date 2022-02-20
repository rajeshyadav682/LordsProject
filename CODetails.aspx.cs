using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Reports.DataAccessLayer;
using Utility;

public partial class CODetails : System.Web.UI.Page
{
    #region
    DataTable GetData()
    {
        string UserBranchCode = ((bool)ViewState["AllBranchAccess"]) ? "" : Session["BranchCode"].ToString();
        SqlCommand comd = DBM.GetCommandSP("sp_GetCODetails");
        comd.Parameters.AddWithValue("@EmpCode", UtilityUI.GetEmpCode(txtSEmployee.Text.Trim()));
        comd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.Trim());
        comd.Parameters.AddWithValue("@ToDate", txtToDate.Text.Trim());
        comd.Parameters.AddWithValue("@Status", ddlSStatus.SelectedValue);
        comd.Parameters.AddWithValue("@UserBranchCode",UserBranchCode);
        comd.Parameters.AddWithValue("@UserId", Session["UserId"]);
        comd.Parameters.AddWithValue("@ReportingPersonAccess", ViewState["ReportingPersonAccess"]);
        return DBM.GetDataTable(comd);
        //ViewState["CODetails"] = DBM.GetDataTable(comd);
        //UtilityUI.FillGrid(gvCODetails, (DataTable)ViewState["CODetails"]);
    }
    void fillgrid()
    {
        gvCODetails.Fill(GetData());
    }
    void clearpage()
    {
        txtSEmployee.Text = txtSEmployee.Enabled ? "" : txtSEmployee.Text;
        ddlSStatus.SelectedIndex = 0;
        txtFromDate.Text = txtToDate.Text = "";
    }
    void CheckPermission()
    {
        ViewState["AllEmployeeAccess"] = ViewState["AllEmployeeAccess"] == null ? Session["AllEmployeeAccess"] : ViewState["AllEmployeeAccess"];
        ViewState["AllBranchAccess"] = ViewState["AllBranchAccess"] == null ? Session["AllBranchAccess"] : ViewState["AllBranchAccess"];
        ViewState["ReportingPersonAccess"] = ViewState["ReportingPersonAccess"] == null ? Session["ReportingPersonAccess"] : ViewState["ReportingPersonAccess"];
        if (ViewState["AllEmployeeAccess"] == null || Convert.ToInt32(ViewState["AllEmployeeAccess"]) == 0)
        {
            txtSEmployee.Text = Session["EmployeeNameCode"].ToString();
            txtSEmployee.Enabled = false;
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckPermission();
        }
        catch (Exception)
        {
            
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        clearpage();
        fillgrid();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GetData().ExportToExcel("Co Details", Response, true);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        UtilityUI.ShowAlert(this, "i", "Access Denied");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        UtilityUI.RedirectToCurrentPage(this);
    }
    //protected void lnkEdit_Click(object sender, EventArgs e)
    //{
    //    GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
    //    ViewState["SNo"] = Convert.ToInt32(grdattendence.DataKeys[gvr.RowIndex].Values["SNo"]);
    //    txtEmployee.Text = grdattendence.DataKeys[gvr.RowIndex].Values["Name"].ToString() + "("+grdattendence.DataKeys[gvr.RowIndex].Values["EmpCode"].ToString()+")";
    //    txtdate.Text = grdattendence.DataKeys[gvr.RowIndex].Values["Date"].ToString();
    //    txtTimeIn.Text = grdattendence.DataKeys[gvr.RowIndex].Values["TimeIn"].ToString();
    //    txtTimeOut.Text = grdattendence.DataKeys[gvr.RowIndex].Values["timeout"].ToString();
    //    txtremark.Text = grdattendence.DataKeys[gvr.RowIndex].Values["Remarks"].ToString();
    //    grdattendence.DataKeys[gvr.RowIndex].Values["status"].ToString();
    //    txtEmployee.Enabled = false;
    //    divSave.Visible = true;
    //    divView.Visible = false;
    //    btnSave.Text = "Update";
    //}
    //protected void grdattendence_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            ((LinkButton)e.Row.FindControl("lnkEdit")).Visible = grdattendence.DataKeys[e.Row.RowIndex].Values["status"].ToString().ToUpper() == "PENDING" ? true : false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
            
    //    }
    //}
}