using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Reports.DataAccessLayer;

public partial class Clients : System.Web.UI.Page
{
    EmployeeBAL EmpBal = new EmployeeBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                BindEmployeeDetail();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateClient.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindEmployeeDetail();
    }
    public void BindEmployeeDetail()
    {
        string UserName = EmpBal.GetEmployeeCode(txtSearchEmpName.Text.ToString());
        string DOJ = UtilityUI.IsValidDate(txtSearchDOJ.Text) ? txtSearchDOJ.Text.Trim() : "";
        ViewState["Export"] = EmpBal.BindClientsDetails(DOJ, UserName);
        UtilityUI.FillGrid(gvFindEmployee, (DataTable)ViewState["Export"]);
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        txtSearchEmpName.Text = txtSearchDOJ.Text = "";
        BindEmployeeDetail();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataTable dt = ((DataTable)ViewState["Export"]).Copy();
        dt.Columns.Remove("navEditEmployee");
        dt.Columns.Remove("navPayElement");
        dt.Columns.Remove("IsActive");
        Export(dt);
    }
    public void Export(DataTable dt)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<TABLE border='1'><Center><thead style='font-size:16; font-family:Verdana; color:blue'><font color='blue' size='5'><b>Client List</font></thead></Center>");
        for (int count = 1; count < dt.Columns.Count - 1; count++)
        {
            sb.Append("<TH  style='background-color:#f3f9f5; position:fixed; color:#507CD1; font-family:Verdana; white-space: pre-wrap; font-size:14'><b>" + dt.Columns[count].ToString() + "</b></TH>");
        }

        for (int row = 0; row < dt.Rows.Count; row++)
        {
            sb.Append("<TR>");
            for (int col = 1; col < dt.Columns.Count - 1; col++)
            {
                sb.Append("<TD align='Center'><font color='black'>" + dt.Rows[row][col].ToString() + "</font></TD>");
            }
            sb.Append("</TR>");
        }
        sb.Append("</TABLE>");
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=EmployeeList.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        stringWrite.WriteLine(sb.ToString());
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        Response.Write(stringWrite.ToString());
        Response.Flush();
        Response.End();
    }
    protected void gvFindEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFindEmployee.PageIndex = e.NewPageIndex;
        BindEmployeeDetail();
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        string URL = gvFindEmployee.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["navEditEmployee"].ToString();
        UtilityUI.RedirectToURL(this, URL);
    }
    protected void lnkpay_Click(object sender, EventArgs e)
    {
        if (!isActiveEmployee((GridViewRow)((LinkButton)sender).NamingContainer))
        {
            UtilityUI.ShowAlert(this, "i", "InActive Employee");
            return;
        }
        //string Code = gvFindEmployee.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["EmpCode"].ToString();
        //string Name = gvFindEmployee.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["EmpName"].ToString();
        //string  doj= gvFindEmployee.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["DateOfJoining"].ToString();

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open('Pay_Elements.aspx?EmpCode=" + Code + "');", true);
        string URL = gvFindEmployee.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["navPayElement"].ToString();
        UtilityUI.RedirectToURL(this, URL);
    }
    bool isActiveEmployee(GridViewRow gvr)
    {
        try
        {
            return Convert.ToBoolean(gvFindEmployee.DataKeys[gvr.RowIndex]["IsActive"]);
        }
        catch (Exception)
        {

            return false;
        }
    }
    protected void GridEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


        }
    }
}