using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Reports.DataAccessLayer;
using System.Configuration;
using System.Data;

public partial class CostCenter : System.Web.UI.Page
{
    SqlBAL sqlBAL = new SqlBAL();
    //DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        catch (Exception)
        {
        }
    }
    public void BindGrid()
    {
        ViewState["EmployeeBand_Category"] = sqlBAL.GetEmployeeBandCategoryGrid(txtSearchCatId.Text,txtSearchCatName.Text,false);
        UtilityUI.FillGrid(gvCategory, (DataTable)ViewState["EmployeeBand_Category"]);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        divSave.Visible = true;
        divView.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
        //string strqury = string.Empty;
        //string str = string.Empty;
        //if (txtSearchCatId.Text == "" && txtSearchCatName.Text == "" )
        //{
        //    UtilityUI.ShowAlert(this, "w", "Please Enter Something to Search !");
        //}
        //else
        //{
        //    if (txtSearchCatId.Text != "")
        //    {
        //        if (str.Trim() != "") str += " and ";
        //        str += "PostingGroupCode like '%" + txtSearchCatId.Text.Trim() + "%' ";
        //    }
        //    if (txtSearchCatName.Text != "")
        //    {
        //        if (str.Trim() != "") str += " and ";
        //        str += "PostingGroupName like '%" + txtSearchCatName.Text.Trim() + "%' ";
        //    }
        //}

        //strqury = "select Sno as s,PostingGroupCode,PostingGroupName from PostingGroup where "+ str;

        //DataTable dt = sqlBAL.GetData1(strqury);
        //gvCategory.DataSource = dt;
        //gvCategory.DataBind();
        //ViewState["EmployeeBand_Category"] = dt;
        
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        txtSearchCatId.Text = txtSearchCatName.Text = "";
        BindGrid();
        //gvCategory.DataSource = (DataTable)ViewState["EmployeeBand_Category"];
        //gvCategory.DataBind();
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        //int s = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        string Key = gvCategory.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex].Value.ToString();
        DataTable dt = sqlBAL.GetEmployeeBandCategoryGrid(Key, "", true);
        //string Query = "Select PostingGroupCode,PostingGroupName from PostingGroup where PostingGroupCode='" + Key + "' ";
        //DataTable dtquery = sqlBAL.GetData1(Query);
        if (dt.Rows.Count > 0)
        {
            txtCatCode.Enabled = false;
            txtCatCode.Text = dt.Rows[0]["Code"].ToString();
            txtCatName.Text = dt.Rows[0]["Description"].ToString();
        }
        divView.Visible = false;
        divSave.Visible = true;
        btnSave.Text = "Update";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Code = txtCatCode.Text.Trim();
        string Name = txtCatName.Text.Trim();
        if (Code == "")
        {
            UtilityUI.ShowAlert(this, "w", "Please Enter Code");
            txtCatCode.Focus();
            return;
        }
        if (Name == "")
        {
            UtilityUI.ShowAlert(this, "w", "Please Enter Description");
            txtCatName.Focus();
            return;
        }
        if (btnSave.Text != "Update")
        {
            if (sqlBAL.GetData("Select * from PostingGroup where PostingGroupName='" + Name + "'").Rows.Count > 0)
            {
                UtilityUI.ShowAlert(this, "w", "Record Already Exists !");
            }
            else
            {
                sqlBAL.EmployeeBand_Category(Code, Name);
                UtilityUI.ShowAlert(this, "s", "Record Saved Successfully !");
            }
        }
        else if (btnSave.Text == "Update")
        {
            sqlBAL.UpdateEmployeeBandCategory(Code, Name);
            UtilityUI.ShowAlert(this, "s", "Record Updated Successfully !");
        }
        BindGrid();
        txtCatCode.Enabled = true;
        divSave.Visible = false;
        divView.Visible = true;
        btnSave.Text = "Save";
        txtCatCode.Text = txtCatName.Text = "";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CostCenter.aspx");
    }
    public void Export(DataTable dt)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<TABLE border='1'><Center><thead style='font-size:16; font-family:Verdana; color:blue'><font color='blue' size='5'><b>Posting Group</font></thead></Center>");
        for (int count = 1; count < dt.Columns.Count; count++)
        {
            sb.Append("<TH  style='background-color:#f3f9f5; position:fixed; color:#507CD1; font-family:Verdana; white-space: pre-wrap; font-size:14'><b>" + dt.Columns[count].ToString() + "</b></TH>");
        }

        for (int row = 0; row < dt.Rows.Count; row++)
        {
            sb.Append("<TR>");
            for (int col = 1; col < dt.Columns.Count; col++)
            {
                sb.Append("<TD align='Center'><font color='black'>" + dt.Rows[row][col].ToString() + "</font></TD>");
            }
            sb.Append("</TR>");
        }
        sb.Append("</TABLE>");
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=PostingGroup.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        stringWrite.WriteLine(sb.ToString());
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        Response.Write(stringWrite.ToString());
        Response.Flush();
        Response.End();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        UtilityUI.ExportToExcel((DataTable)ViewState["EmployeeBand_Category"], "CostCenter", Response, true);
        //DataTable dt = (DataTable)ViewState["EmployeeBand_Category"];
        //Export(dt);
    }
    protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategory.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}