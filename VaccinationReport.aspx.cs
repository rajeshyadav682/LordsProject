using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VaccinationReport : System.Web.UI.Page
{
    static string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SProll"].ConnectionString;
    #region UDF
    public void Bindgrid()
    {
        gvrpt.DataBind();
        string EmpCode = UtilityUI.GetEmpCode(txtemployeename.Text.Trim());
        string UserBranchCode = ((bool)ViewState["AllBranchAccess"]) ? "" : Session["BranchCode"].ToString();
        SqlCommand Comd = DBM.GetCommandSP("VaccinationReport_new");
        Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
        //Comd.Parameters.AddWithValue("@UserBranchCode", UserBranchCode);
        DataTable dt = DBM.GetDataTable(Comd);
 
        ViewState["VaccinationReport"] = dt;
        //ViewState["TimeSheet"] = DBM.GetDataTable("GetEmployeeTimeSheet @Year = " + dllYear.SelectedValue + ", @Month = " + ddlMonth.SelectedValue + 
        //    ", @CardNo = '" + txtCardNo.Text.Trim() + "', @EmpCode = '" + EmpCode + "'");
        UtilityUI.FillGrid(gvrpt, (DataTable)ViewState["VaccinationReport"]);
    }
    public void clear()
    {
        txtemployeename.Text = txtemployeename.Enabled ? "" : txtemployeename.Text;
       
    }
    void CheckPermission()
    {
        ViewState["AllEmployeeAccess"] = ViewState["AllEmployeeAccess"] == null ? Session["AllEmployeeAccess"] : ViewState["AllEmployeeAccess"];
        ViewState["AllBranchAccess"] = ViewState["AllBranchAccess"] == null ? Session["AllBranchAccess"] : ViewState["AllBranchAccess"];
        if (ViewState["AllEmployeeAccess"] == null || Convert.ToInt32(ViewState["AllEmployeeAccess"]) == 0)
        {
            txtemployeename.Text = Session["EmployeeNameCode"].ToString();
            txtemployeename.Enabled = false;
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
                Bindgrid();
                if (txtemployeename.Enabled == true)
                {
                    btnSearch.Visible = true;
                }
                else
                {
                    btnSearch.Visible = false;
                }
            }
        }
        catch(Exception ex) { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Bindgrid();
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        clear();
        Bindgrid();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string EmpCode = UtilityUI.GetEmpCode(txtemployeename.Text.Trim());
        GetDataByEmpCode(EmpCode);
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["VaccinationReportForExport"];
        dt.Columns.Remove("file");
        dt.Columns.Remove("FileType");
        dt.Columns.Remove("id");
        UtilityUI.ExportToExcel(dt, "Vaccination Report", Response, true);
    }
    protected void gvTimeSheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvrpt.PageIndex = e.NewPageIndex;
        Bindgrid();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        UtilityUI.ShowAlert(this, "i", "Access Denied");
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        
        string id = gvrpt.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["id"].ToString();
        string EmpCode = gvrpt.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["EmpCode"].ToString();
        gridchild.DataSource = GetDataByEmpCode(EmpCode);
        gridchild.DataBind();
        ModalPopupExtender1.Show();
    }
    DataTable GetDataByEmpCode(string EmpCode)
    {
        SqlCommand Comd = DBM.GetCommandSP("VaccinationReportByEmpcode");
        Comd.Parameters.AddWithValue("@EmpCode", EmpCode);
        ViewState["VaccinationReportForExport"] = DBM.GetDataTable(Comd);
        return DBM.GetDataTable(Comd);
    }

    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        string id = gridchild.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["id"].ToString();
        //string EmpCode = gridchild.DataKeys[((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex]["EmpCode"].ToString();
        DownLoad(Convert.ToInt32(id));
    }
    private void DownLoad(int id)
    {
        using (SqlConnection con = new SqlConnection(connetionString))
        {
            con.Open();
            // int id = Convert.ToInt32(e.CommandArgument.ToString());
            SqlCommand cmd = new SqlCommand("select [file],Filetype,fileName from TblVaccineRegistration where id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = dr["Filetype"].ToString();
                // to open file prompt Box open or Save file    
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["FileName"].ToString());
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["file"]);
                Response.End();
            }
        }
    }

    protected void gridchild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label filename = (Label)e.Row.FindControl("ldlfilename"); // FindControl fails
            LinkButton btn = (LinkButton)e.Row.FindControl("lnkdownload"); // FindControl fails
            if (filename.Text == "")
            {
                btn.Visible = false;
            }
            else
            {
                btn.Visible = true;
            }
        }
    }
}