using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Reports.DataAccessLayer;

public partial class COVID19DelayReport : System.Web.UI.Page
{
    string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SProll"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            if (!IsPostBack)
            {
                lblmsg.Text = "";
                TxtDate.Text = System.DateTime.Now.ToString("dd/MMM/yyyy");

            }

        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
        
            BindGrid();
        }
      
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
  
    public void BindGrid()
    {
        try
        {
            string UserCode = UtilityUI.GetEmpCode(txtEmployee.Text.Trim());
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("PRC_GET_FillForm_Data", con);
            cmd.CommandType = CommandType.StoredProcedure;         
            cmd.Parameters.AddWithValue("@UserCode", UserCode);
            cmd.Parameters.AddWithValue("@Date", TxtDate.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            sda.Fill(ds);        
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                GrCovid.DataSource = ds;
                GrCovid.DataBind();
                lblmsg.Text = "";
            }
            else
            {
                lblmsg.Text = "No Data found.";
                lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                GrCovid.DataSource = "";
              
                
            }
            con.Close();
            // FGds = null;
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
    protected void GrCovid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrCovid.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
}