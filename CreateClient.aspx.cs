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
using System.Globalization;
using Utility;
public partial class CreateEmployee : System.Web.UI.Page
{
    EmployeeBAL EmpBal = new EmployeeBAL();
    string Userid = string.Empty;
    DataTable dt;
    DataTable dtclientCode;

    string ClientCode = string.Empty;
    
    SqlBAL sqlBAL = new SqlBAL();
    
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Userid = Session["UserName"].ToString();
            lbldiscount.Text = "200";
            lblexpiredate.Text = "200";
            if (!Page.IsPostBack)
            {
                SetInitialRow();
                Session["insertTime"] = Server.UrlEncode(System.DateTime.Now.ToString());
                BindRole();
                BindPlan();
           //     BindSequncecode();
                ViewState["ClientCode"] = Convert.ToString(Request.QueryString["ClientCode"]);
                if (Request.QueryString["ClientCode"] != null)
                {
                    ClientCode = Request.QueryString["ClientCode"].ToString();
                    GetAllClientDetailForEdit(ViewState["ClientCode"].ToString());
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    
   
    protected void ShowAndHide(string ClientCode)
    {
       
        //CodePrefix.Visible = false;
        btnGeneral.Text = "Update";
        lblclientcode.Text = ClientCode;
        lblClientName.Text = txtfullName.Text;
        ShowEmpCode.Style.Add("display", "Block");        
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["insertTime"] = Session["insertTime"];
    }
    protected void btnPayelement_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open('Pay_Elements.aspx?EmpCode=" + lblclientcode.Text + "');", true);
    }
    protected void GetAllClientDetailForEdit(string EmployeeCode)
    {
        try
        {
            DataTable dtclientDetail = EmpBal.GetAllClientDetail(ClientCode);
            txtfullName.Text= dtclientDetail.Rows[0]["Name"].ToString();
            lblClientName.Text = dtclientDetail.Rows[0]["Name"].ToString();
            txtage.Text= dtclientDetail.Rows[0]["Age"].ToString();
            txtDOJ.Text = dtclientDetail.Rows[0]["DateOfJoining"].ToString();
            txtMobileNo.Text = dtclientDetail.Rows[0]["ContactNo"].ToString();
            txtcomment.Text = dtclientDetail.Rows[0]["description"].ToString();
            txtCurrentAddress.Text = dtclientDetail.Rows[0]["full_address"].ToString();
            ddlplan.SelectedValue = dtclientDetail.Rows[0]["plan_id"].ToString();
            ddlRole.SelectedValue = dtclientDetail.Rows[0]["Roleid"].ToString();
            chkisactive.Checked =Convert.ToBoolean(dtclientDetail.Rows[0]["IsActive"].ToString());

            //ViewState["ImagesPath"] = dtEmpDetail.Rows[0]["ImagesPath"].ToString();

            DateTime DateOfJoining = Convert.ToDateTime(dtclientDetail.Rows[0]["DateOfJoining"]);
            ShowAndHide(ClientCode);
           
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    //protected void BindSequncecode()
    //{
    //    dt = new DataTable();
    //    dt = EmpBal.GetCodeFromMaster();
    //    if (dt.Rows.Count > 0)
    //    {
    //        rdbtnlistcode.DataSource = dt;
    //        rdbtnlistcode.DataTextField = "Name";
    //        rdbtnlistcode.DataValueField = "Code";
    //        rdbtnlistcode.DataBind();
    //        rdbtnlistcode.Items[0].Selected = true;
    //    }
    //}

    protected void BindRole()
    {
        DataTable dtRole = new DataTable();
        dtRole = EmpBal.GetRole();
        ddlRole.DataSource = dtRole;
        ddlRole.DataTextField = "Description";
        ddlRole.DataValueField = "RoleCode";
        ddlRole.DataBind();
        ddlRole.Items.Insert(0, "---Select---");
    }
    protected void BindPlan()
    {
        DataTable dtBranch = new DataTable();
        dtBranch = EmpBal.GetPlan();
        ddlplan.DataSource = dtBranch;
        ddlplan.DataTextField = "Name";
        ddlplan.DataValueField = "Code";
        ddlplan.DataBind();
        ddlplan.Items.Insert(0, "---Select---");
    }

    protected void GetDiscountDetails(string planid)
    {
        DataTable dtdis = new DataTable();
        dtdis = EmpBal.GetDiscountdetails(planid);
        if (dtdis.Rows.Count > 0)
        {
            lblexpiredate.Text= dtdis.Rows[0]["expire_date"].ToString();
            lbldiscount.Text = dtdis.Rows[0]["amt"].ToString();
            pnldiscount.Visible = true;
        }
        else
        {
            pnldiscount.Visible = true;
            lbldiscount.Text = "0";
        }

    }


    void callJs(string TabName)
    {
        string FuncationName = TabName == "General" ? "jsGeneralDetail()" :
                               TabName == "Personal" ? "jsPersonal()" :
                               TabName == "Tax" ? "jsfnTax()" : "";
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", FuncationName, true);
    }

    protected void btnImgSubmit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile != false)
        {
            //string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //lblimageName.Text = filename;
            //string FilePath = Server.MapPath(BaseProperties.UploadImagePath + lblempcode.Text);
            //if (!Directory.Exists(FilePath))
            //{
            //    Directory.CreateDirectory(FilePath);
            //}
            //FilePath = BaseProperties.UploadImagePath + lblempcode.Text + "/" + System.DateTime.Now.ToString("ddMMyyhhmmss_") + filename;
            //FileUpload1.SaveAs(Server.MapPath(FilePath));
            //EmpImg.ImageUrl = FilePath;
            //ViewState["ImagesPath"] = FilePath;

            lblimageName.Text = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string FilePath, rslt;
            //if (UtilityUI.UploadEmployeeProfile(this, FileUpload1, lblempcode.Text, out FilePath, out rslt))
            //{
            //    EmpImg.ImageUrl = FilePath;
            //    ViewState["ImagesPath"] = FilePath;
            //}
            //else
            //{
            //    UtilityUI.ShowAlert(this, rslt);
            //}
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "key", "<script>alert('Please Select Images !');</script>", false);
            return;
        }

    }
  
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string RecordType = "";
        try
        {
            RecordType = "Insert";
            if (Session["insertTime"].ToString() == ViewState["insertTime"].ToString())
            {
                InsertData();
            }
            Session["insertTime"] = Server.UrlEncode(System.DateTime.Now.ToString());
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
    protected void InsertData()
    {
        string Tab = "", GeneralTab = "General", PersonalTab = "Personal";
        try
        {
            string ClientCode = string.Empty;
            string Prefix = string.Empty;
            string FullName = string.Empty;
            DateTime DOJ;
            string ContactNo = string.Empty;
            string Age = string.Empty;
            string Address = string.Empty;
            string Role = string.Empty;
            string Plan = string.Empty;
            string Desc = string.Empty;
            bool IsActive = false;
            Tab = GeneralTab;
           
            FullName = txtfullName.Text;
            if (FullName == "")
            {
                UtilityUI.ShowAlert(this, "W", "Please Enter Full Name !");
                txtfullName.Focus();
                //callJs(GeneralTab);
                return;
            }
           
          
            if (!UtilityUI.IsValidDate(txtDOJ.Text.Trim()))
            {
                UtilityUI.ShowAlert(this, "W", "Please Enter Date Of Joining !");
                txtDOJ.Focus();
                //callJs(GeneralTab);
                return;
            }
            DOJ = Convert.ToDateTime(txtDOJ.Text);
           
            if (txtMobileNo.Text.Trim().Length == 10)
            {
                ContactNo = txtMobileNo.Text;
            }
            else
            {
                UtilityUI.ShowAlert(this, "W", "Please Enter Valid Contact Number !");
                txtMobileNo.Focus();
                //callJs(GeneralTab);
                return;
            }

         
            //role
            if (ddlRole.SelectedIndex != 0)
            {
                Role = ddlRole.SelectedValue;
            }
            else
            {
                UtilityUI.ShowAlert(this, "W", "Please Select Role !");
                ddlRole.Focus();
                //callJs(GeneralTab);
                return;
            }
            if (ddlplan.SelectedIndex != 0)
            {
                Plan = ddlplan.SelectedValue;
            }
            else
            {
                UtilityUI.ShowAlert(this, "W", "Please Plan!");
                ddlplan.Focus();
                //callJs(GeneralTab);
                return;
            }
            Age = txtage.Text;
            Address = txtCurrentAddress.Text;
            IsActive = chkisactive.Checked;
            Desc = txtcomment.Text;


            // Imagepath = ViewState["ImagesPath"] != null ? ViewState["ImagesPath"].ToString() : "";

            string rslt = "";
            if (ViewState["ClientCode"] == null)
            {

                rslt = EmpBal.CreateClient(FullName.ToUpper(), Age, DOJ, ContactNo,Plan,Address,IsActive,Desc,Role, out ClientCode) ;
                if (rslt != "")
                {
                    ShowAndHide(ClientCode);
                    UtilityUI.ShowAlert(this, "s", "Client Create Successfully ! " + ClientCode);     
                    ViewState["ClientCode"] = ClientCode;
                }
                else
                {
                    UtilityUI.ShowAlert(this, "w", rslt);
                }
            }
            else
            {
                lblclientcode.Text = ViewState["ClientCode"].ToString();
                ClientCode = lblclientcode.Text;
                rslt = EmpBal.UpdateClient(lblclientcode.Text, FullName.ToUpper(), Age, DOJ, ContactNo, Plan,Address,IsActive,  Desc,  Role);
              //
                if (rslt.ToUpper() == "OK")
                {
                    ShowAndHide(ClientCode);
                    UtilityUI.ShowAlert(this, "s", "Client Update Successfully ! " + ClientCode);
                    
                }
                else
                {
                    UtilityUI.ShowAlert(this, "w", "Client Not Update Successfully ! " + ClientCode);
                }
            }
      
            Tab = "";
        }
        finally
        {
            if(Tab.Length > 0)
            callJs(Tab);
        }
    }


    protected void BtnpaymentrowAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void Btnpaymentrowdelete_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex;
        if (ViewState["CurrentTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data and reset row number  
                    dt.Rows.Remove(dt.Rows[rowID]);
                    ResetRowID(dt);
                }
            }

            //Store the current data in ViewState for future reference  
            ViewState["CurrentTable"] = dt;

            //Re bind the GridView for the updated data  
            gridviewpayment.DataSource = dt;
            gridviewpayment.DataBind();
        }

        //Set Previous Data on Postbacks  
        SetPreviousData();
    }

    private void ResetRowID(DataTable dt)
    {
        int rowNumber = 1;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                row[0] = rowNumber;
                rowNumber++;
            }
        }
    }
    protected void gridviewpayment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    private ArrayList GetDummyData()
    {

        ArrayList arr = new ArrayList();

        arr.Add(new ListItem("Item1", "1"));
        arr.Add(new ListItem("Item2", "2"));
        arr.Add(new ListItem("Item3", "3"));
        arr.Add(new ListItem("Item4", "4"));
        arr.Add(new ListItem("Item5", "5"));

        return arr;
    }

    private void FillDropDownList(DropDownList ddl)
    {
        ArrayList arr = GetDummyData();

        foreach (ListItem item in arr)
        {
            //ddl.Items.Add(item);
        }
    }
    private void SetInitialRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("Sno", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for DropDownList selected item   
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   

        dr = dt.NewRow();
        dr["Sno"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dt.Rows.Add(dr);

        //Store the DataTable in ViewState for future reference   
        ViewState["CurrentTable"] = dt;

        //Bind the Gridview   
        gridviewpayment.DataSource = dt;
        gridviewpayment.DataBind();

        //After binding the gridview, we can then extract and fill the DropDownList with Data   
       // DropDownList ddl1 = (DropDownList)gridviewpayment.Rows[0].Cells[3].FindControl("DropDownList1");
        DropDownList ddl2 = (DropDownList)gridviewpayment.Rows[0].Cells[4].FindControl("DropDownList2");
        //FillDropDownList(ddl1);
        FillDropDownList(ddl2);
    }
    private void AddNewRowToGrid()
    {

        if (ViewState["CurrentTable"] != null)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["Sno"] = dtCurrentTable.Rows.Count + 1;

                //add new row to DataTable   
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Store the current data to ViewState for future reference   

                ViewState["CurrentTable"] = dtCurrentTable;


                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {

                    //extract the TextBox values   

                    TextBox box1 = (TextBox)gridviewpayment.Rows[i].Cells[1].FindControl("txtamount");
                    TextBox box2 = (TextBox)gridviewpayment.Rows[i].Cells[2].FindControl("txtpaymentMode");
                    TextBox box3 = (TextBox)gridviewpayment.Rows[i].Cells[3].FindControl("txtpaymentdate");

                    dtCurrentTable.Rows[i]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i]["Column3"] = box3.Text;

                    //extract the DropDownList Selected Items   

                    //DropDownList ddl1 = (DropDownList)gridviewpayment.Rows[i].Cells[3].FindControl("DropDownList1");
                    DropDownList ddl2 = (DropDownList)gridviewpayment.Rows[i].Cells[4].FindControl("DropDownList2");

                    // Update the DataRow with the DDL Selected Items   

                    //dtCurrentTable.Rows[i]["Column3"] = ddl1.SelectedItem.Text;
                    dtCurrentTable.Rows[i]["Column4"] = ddl2.SelectedItem.Text;

                }

                //Rebind the Grid with the current data to reflect changes   
                gridviewpayment.DataSource = dtCurrentTable;
                gridviewpayment.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");

        }
        //Set Previous Data on Postbacks   
        SetPreviousData();
    }
    private void SetPreviousData()
    {

        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)gridviewpayment.Rows[i].Cells[1].FindControl("txtamount");
                    TextBox box2 = (TextBox)gridviewpayment.Rows[i].Cells[2].FindControl("txtpaymentMode");
                    TextBox box3 = (TextBox)gridviewpayment.Rows[i].Cells[3].FindControl("txtpaymentdate");

                    //DropDownList ddl1 = (DropDownList)gridviewpayment.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                    DropDownList ddl2 = (DropDownList)gridviewpayment.Rows[rowIndex].Cells[4].FindControl("DropDownList2");

                    //Fill the DropDownList with Data   
                    //FillDropDownList(ddl1);
                    FillDropDownList(ddl2);

                    if (i < dt.Rows.Count - 1)
                    {

                        //Assign the value from DataTable to the TextBox   
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();

                        //Set the Previous Selected Items on Each DropDownList  on Postbacks   
                        //ddl1.ClearSelection();
                        //ddl1.Items.FindByText(dt.Rows[i]["Column3"].ToString()).Selected = true;

                        ddl2.ClearSelection();
                        ddl2.Items.FindByText(dt.Rows[i]["Column4"].ToString()).Selected = true;

                    }

                    rowIndex++;
                }
            }
        }
    }


    protected void ddlplan_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDiscountDetails(ddlplan.SelectedValue);
    }
}