using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class COLeaveApproval : System.Web.UI.Page
{
    //DataTable GetCoLeaves()
    //{
    //    return DBM.GetDataTable("getCoLeaveforApproval");
    //}
    //void search()
    //{
    //    ViewState["COLeaves"] = ViewState["COLeaves"] == null ? GetCoLeaves() : ViewState["COLeaves"];

    //    DataTable dt = (DataTable)ViewState["COLeaves"];

    //    DataRow[] drArray = dt.Select("EmpCode like '%" + txtEmployeeCode.Text.Trim() + "%' and Name like '%" + txtEmployee.Text.Trim() + "%' " + (ddlBranch.SelectedIndex == 0 ? "" : " and  BranchCode = '" + ddlBranch.SelectedValue.ToString() + "'") + (ddlStatus.SelectedIndex == 0 ? "" : " and  ApprovedRejected = '" + ddlStatus.SelectedValue.ToString() + "'"));

    //    if (drArray.Length > 0)
    //    {
    //        gvCoLeave.DataSource = drArray.CopyToDataTable();
    //    }
    //    gvCoLeave.DataBind();
    //}
    //void Export()
    //{
    //    ViewState["COLeaves"] = ViewState["COLeaves"] == null ? GetCoLeaves() : ViewState["COLeaves"];

    //    DataTable dt = (DataTable)ViewState["COLeaves"];
        
    //    DataRow[] drArray = dt.Select("EmpCode like '%" + txtEmployeeCode.Text.Trim() + "%' and Name like '%" + txtEmployee.Text.Trim() + "%' " + (ddlBranch.SelectedIndex == 0 ? "" : " and  BranchCode = '" + ddlBranch.SelectedValue.ToString() + "'") + (ddlStatus.SelectedIndex == 0 ? "" : " and  ApprovedRejected = '" + ddlStatus.SelectedValue.ToString() + "'"));

    //    if (drArray.Length > 0)
    //    {
    //        UtilityUI.ExportToExcel(drArray.CopyToDataTable(), "COLeaves", Response);
    //    }
        
    //}
    //void ViewAll()
    //{
    //    ddlBranch.SelectedIndex = ddlStatus.SelectedIndex = 0;
    //    txtEmployee.Text = txtEmployeeCode.Text = "";
    //    ViewState["COLeaves"] = null;
    //    search();
    //}
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (!IsPostBack)
    //        {
    //            UtilityUI.FillddlWithAll(ddlBranch, DBM.getReader("Bind_Branch"), "BranchName", "Branchcode");
    //            ViewAll();
    //        }
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
        
    //}
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (gvCoLeave.Rows.Count == 0)
    //        {
    //            UtilityUI.ShowAlert(this,"w","There Should be At Least One Row To Save.!");
    //            return;
    //        }
    //        string Querry = "";
    //        foreach (GridViewRow gvr in gvCoLeave.Rows)
    //        {
    //            if (((RadioButtonList)gvr.FindControl("rdlist")).Enabled)
    //            {
    //                string ApprovedReject = ((RadioButtonList)gvr.FindControl("rdlist")).SelectedValue.ToString();
    //                if (ApprovedReject.Length > 0)
    //                {
    //                    string Remarks = ((TextBox)gvr.FindControl("txtRemarks")).Text.Trim();
    //                    string sno = gvCoLeave.DataKeys[gvr.RowIndex]["SNo"].ToString();

    //                    Querry += Environment.NewLine +" exec ApproveCoLeave @Sno = '" + sno + "', @Approved = '" + ApprovedReject + "', @Remarks = '" + Remarks + "', @UserId = '" + Session["UserId"] + "'";
    //                    //Querry += " update EmployeeCOLeave set Approved = '" + ApprovedReject + "', Remarks = '" + Remarks + "'," +
    //                    //          " UpdatedBy = '" + Session["UserId"] + "', UpdatedOn = getdate() where SNo = '" + sno + "' and Approved is null ";
    //                }
    //            }
    //        }
    //        if (Querry.Length == 0)
    //        {
    //            UtilityUI.ShowAlert(this, "w", "Approve Or Reject At Least One Leave To Save.!");
    //            return;
    //        }
    //        if (DBM.WriteToDbWithTransaction(Querry))
    //        {
    //            UtilityUI.ShowAlert(this,"s","Changes Saved Successfully.");
    //            ViewAll();
                
    //        }
    //        else
    //        {
    //            UtilityUI.ShowAlert(this, "w", "Unable To Save Changes.!");
    //        }
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
        
    //}
    //protected void gvCoLeave_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string ApprovedRejected = gvCoLeave.DataKeys[e.Row.RowIndex]["ApprovedRejected"].ToString();
    //        if (ApprovedRejected.Length > 0)
    //        {
    //            ((RadioButtonList)e.Row.FindControl("rdlist")).Enabled = false;
    //            ((TextBox)e.Row.FindControl("txtRemarks")).Enabled = false;
    //            ((RadioButtonList)e.Row.FindControl("rdlist")).SelectedValue = ApprovedRejected;
    //        }
    //    }
    //}
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    search();
    //}
    //protected void btnViewAll_Click(object sender, EventArgs e)
    //{
    //    ViewAll();
    //}
    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    Export();
    //}
    void FillGrid()
    {
        UtilityUI.FillGrid(gvCoLeave, DBM.GetDataTable("getCoLeaveforApproval @EmpCode = '" + Session["UserId"] + "', @AllBranchAccess = " + ViewState["AllBranchAccess"]));
        btnSave.Visible = gvCoLeave.Rows.Count > 0 ? true : false;
    }
    void CheckPermission()
    {
        ViewState["AllEmployeeAccess"] = ViewState["AllEmployeeAccess"] == null ? Session["AllEmployeeAccess"] : ViewState["AllEmployeeAccess"];
        ViewState["AllBranchAccess"] = ViewState["AllBranchAccess"] == null ? Session["AllBranchAccess"] : ViewState["AllBranchAccess"];
        //if (ViewState["AllEmployeeAccess"] == null || Convert.ToInt32(ViewState["AllEmployeeAccess"]) == 0)
        //{
        //    txtemployee.Text = Session["UserId"].ToString();
        //    txtemployee.Enabled = false;
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckPermission();
            if (!IsPostBack)
            {
                FillGrid();
            }
        }
        catch { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int reject = 0;
            int accept = 0;
            if (gvCoLeave.Rows.Count == 0)
            {
                UtilityUI.ShowAlert(this, "w", "There Should be At Least One Row To Save.!");
                return;
            }
            string Querry = "";
            foreach (GridViewRow gvr in gvCoLeave.Rows)
            {
                if (((RadioButtonList)gvr.FindControl("rdlist")).Enabled)
                {
                    string ApprovedReject = ((RadioButtonList)gvr.FindControl("rdlist")).SelectedValue.ToString();
                    if (ApprovedReject.Length > 0)
                    {
                        string Remarks = ((TextBox)gvr.FindControl("txtRemarks")).Text.Trim();
                        string sno = gvCoLeave.DataKeys[gvr.RowIndex]["SNo"].ToString();

                        if (ApprovedReject == "0" && Remarks.Length == 0)
                        {
                            UtilityUI.ShowAlert(this, "w", "Enter Remark. For Rejected Comp Off.!");
                            return;
                        }

                        Querry += Environment.NewLine + " exec ApproveCoLeave @Sno = '" + sno + "', @Approved = '" + ApprovedReject + "', @Remarks = '" + Remarks + "', @UserId = '" + Session["UserId"] + "'";
                        accept += ApprovedReject == "1" ? 1 : 0;
                        reject += ApprovedReject == "0" ? 1 : 0;
                    }
                }
            }
            if (Querry.Length == 0)
            {
                UtilityUI.ShowAlert(this, "w", "Approve Or Reject At Least One Leave To Save.!");
                return;
            }
            if (DBM.WriteToDbWithTransaction(Querry))
            {
                UtilityUI.ShowAlert(this, "s", "You have Approved " + accept + " CO and Rejected " + reject + " CO ");
                FillGrid();
            }
            else
            {
                UtilityUI.ShowAlert(this, "w", "Unable To Save Changes.!");
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
}