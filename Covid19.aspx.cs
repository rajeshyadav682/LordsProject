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


public partial class Covid19 : System.Web.UI.Page
{
    string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SProll"].ConnectionString;
    DataSet FGds = new DataSet();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CheckPermission();
            if (!IsPostBack)
            {
                string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
                ViewState["CovidUserId"] = EmpCode;
                GetEmpHeader(EmpCode); //GetEmpHeader(Session["UserId"].ToString());
                lblmsg.Text = "";
                //BindGrid();
                LoadComplete += TDSProjectionForm12BB_LoadComplete;
                btnSave.Enabled = true;
                EnableRadiobuttonTrue();
            }

        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
    private void TDSProjectionForm12BB_LoadComplete(object sender, EventArgs e)
    {
        FillFormonLink();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
            if (EmpCode.Length == 0)
            {
                UtilityUI.ShowAlert(this, "i", "Select Valid Employee.");
                return;
            }
            if (RdApp.SelectedValue == "1")
            {
                //if (!(RFa1.SelectedValue == "" && RFa2.SelectedValue == "" && RFa3.SelectedValue == "" && RFa4.SelectedValue == "" && RFa5.SelectedValue == "" && RFa6.SelectedValue == "" && RFa7.SelectedValue == "" && RFa8.SelectedValue == "" && RFa9.SelectedValue == "" && RFa10.SelectedValue == "" && RFa11.SelectedValue == "" && RFa12.SelectedValue == "" && RFa13.SelectedValue == "" && RFa14.SelectedValue == "" && RFa15.SelectedValue == "") || (RFa1.SelectedValue != "" && RFa2.SelectedValue != "" && RFa3.SelectedValue != "" && RFa4.SelectedValue != "" && RFa5.SelectedValue != "" && RFa6.SelectedValue != "" && RFa7.SelectedValue != "" && RFa8.SelectedValue != "" && RFa9.SelectedValue != "" && RFa10.SelectedValue != "" && RFa11.SelectedValue != "" && RFa12.SelectedValue != "" && RFa13.SelectedValue != "" && RFa14.SelectedValue != "" && RFa15.SelectedValue != ""))
                //{
                    if (RFa1.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.1 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa2.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.2 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    if (RFa3.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.3 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa4.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.4 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa5.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.5 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa6.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.6 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa7.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.7 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa8.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.8 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa9.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.9 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa10.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.10 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa11.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.11 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa12.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.12 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa13.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.13 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa14.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.14 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa15.SelectedValue == "" && RdApp.SelectedValue == "1")
                    {
                        lblmsg.Text = "Questions No.15 in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (RFa2.SelectedValue == "1" && RdApp.SelectedValue == "1")
                    {
                        if (TFa2.Text == "" || TFa2.Text == null)
                        {
                            lblmsg.Text = "Questions No.2 Remarks in Father tab is mandatory.";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                    if (RFa9.SelectedValue == "1" && RdApp.SelectedValue == "1")
                    {
                        if (TFa9.Text == "" || TFa9.Text == null)
                        {
                            lblmsg.Text = "Questions No.9 Remarks in Father tab is mandatory.";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }

                    if (RFa10.SelectedValue == "1" && RdApp.SelectedValue == "1")
                    {
                        if (TFa10.Text == "" || TFa10.Text == null)
                        {
                            lblmsg.Text = "Questions No.10 Remarks in Father tab is mandatory.";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                //}
            }
            if (RdAppM.SelectedValue == "1")
            {
                //if (!(RMr1.SelectedValue == "" && RMr2.SelectedValue == "" && RMr3.SelectedValue == "" && RMr4.SelectedValue == "" && RMr5.SelectedValue == "" && RMr6.SelectedValue == "" && RMr7.SelectedValue == "" && RMr8.SelectedValue == "" && RMr9.SelectedValue == "" && RMr10.SelectedValue == "" && RMr11.SelectedValue == "" && RMr12.SelectedValue == "" && RMr13.SelectedValue == "" && RMr14.SelectedValue == "" && RMr15.SelectedValue == "") || (RMr1.SelectedValue != "" && RMr2.SelectedValue != "" && RMr3.SelectedValue != "" && RMr4.SelectedValue != "" && RMr5.SelectedValue != "" && RMr6.SelectedValue != "" && RMr7.SelectedValue != "" && RMr8.SelectedValue != "" && RMr9.SelectedValue != "" && RMr10.SelectedValue != "" && RMr11.SelectedValue != "" && RMr12.SelectedValue != "" && RMr13.SelectedValue != "" && RMr14.SelectedValue != "" && RMr15.SelectedValue != ""))
                //{
                if (RMr1.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.1 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr2.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.2 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (RMr3.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.3 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr4.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.4 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr5.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.5 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr6.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.6 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr7.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.7 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr8.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.8 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr9.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.9 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr10.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.10 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr11.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.11 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr12.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.12 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr13.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.13 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr14.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.14 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr15.SelectedValue == "" && RdAppM.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.15 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr2.SelectedValue == "1" && RdAppM.SelectedValue == "1")
                {
                    if (TMr2.Text == "" || TMr2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Mother tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (RMr9.SelectedValue == "1" && RdAppM.SelectedValue == "1")
                {
                    if (TMr9.Text == "" || TMr9.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Mother tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (RMr10.SelectedValue == "1" && RdAppM.SelectedValue == "1")
                {
                    if (TMr10.Text == "" || TMr10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in Mother tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            if (RdAppW.SelectedValue == "1")
            {
                //if (!(RWf1.SelectedValue == "" && RWf2.SelectedValue == "" && RWf3.SelectedValue == "" && RWf4.SelectedValue == "" && RWf5.SelectedValue == "" && RWf6.SelectedValue == "" && RWf7.SelectedValue == "" && RWf8.SelectedValue == "" && RWf9.SelectedValue == "" && RWf10.SelectedValue == "" && RWf11.SelectedValue == "" && RWf12.SelectedValue == "" && RWf13.SelectedValue == "" && RWf14.SelectedValue == "" && RWf15.SelectedValue == "") || (RWf1.SelectedValue != "" && RWf2.SelectedValue != "" && RWf3.SelectedValue != "" && RWf4.SelectedValue != "" && RWf5.SelectedValue != "" && RWf6.SelectedValue != "" && RWf7.SelectedValue != "" && RWf8.SelectedValue != "" && RWf9.SelectedValue != "" && RWf10.SelectedValue != "" && RWf11.SelectedValue != "" && RWf12.SelectedValue != "" && RWf13.SelectedValue != "" && RWf14.SelectedValue != "" && RWf15.SelectedValue != ""))
                //{
                if (RWf1.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.1 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf2.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.2 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (RWf3.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.3 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf4.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.4 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf5.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.5 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf6.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.6 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf7.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.7 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf8.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.8 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf9.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.9 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf10.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.10 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf11.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.11 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf12.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.12 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf13.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.13 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf14.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.14 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf15.SelectedValue == "" && RdAppW.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.15 in Spouse tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf2.SelectedValue == "1" && RdAppW.SelectedValue == "1")
                {
                    if (TWf2.Text == "" || TWf2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Spouse tab is mandatory."; ;
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (RWf9.SelectedValue == "1" && RdAppW.SelectedValue == "1")
                {
                    if (TWf9.Text == "" || TWf9.Text == null)
                    {
                        lblmsg.Text = "Questions No.9 Remarks in Spouse tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (RWf10.SelectedValue == "1" && RdAppW.SelectedValue == "1")
                {
                    if (TWf10.Text == "" || TWf10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in Spouse tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            if (RdAppC.SelectedValue == "1")
            {
                // if (!(Rch1.SelectedValue == "" && Rch2.SelectedValue == "" && Rch3.SelectedValue == "" && Rch4.SelectedValue == "" && Rch5.SelectedValue == "" && Rch6.SelectedValue == "" && Rch7.SelectedValue == "" && Rch8.SelectedValue == "" && Rch9.SelectedValue == "" && Rch10.SelectedValue == "" && Rch11.SelectedValue == "" && Rch12.SelectedValue == "" && Rch13.SelectedValue == "" && Rch14.SelectedValue == "" && Rch15.SelectedValue == "") || (Rch1.SelectedValue != "" && Rch2.SelectedValue != "" && Rch3.SelectedValue != "" && Rch4.SelectedValue != "" && Rch5.SelectedValue != "" && Rch6.SelectedValue != "" && Rch7.SelectedValue != "" && Rch8.SelectedValue != "" && Rch9.SelectedValue != "" && Rch10.SelectedValue != "" && Rch11.SelectedValue != "" && Rch12.SelectedValue != "" && Rch13.SelectedValue != "" && Rch14.SelectedValue != "" && Rch15.SelectedValue != ""))
                //{
                if (Rch1.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.1 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch2.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.2 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Rch3.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.3 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch4.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.4 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch5.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.5 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch6.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.6 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch7.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.7 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch8.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.8 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch9.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.9 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch10.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.10 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch11.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.11 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch12.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.12 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch13.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.13 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch14.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.14 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch15.SelectedValue == "" && RdAppC.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.15 in Brother/Sister/Child - 1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Rch2.SelectedValue == "1" && RdAppC.SelectedValue == "1")
                {
                    if (Tch2.Text == "" || Tch2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Brother/Sister/Child - 1 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (Rch9.SelectedValue == "1" && RdAppC.SelectedValue == "1")
                {
                    if (Tch9.Text == "" || Tch9.Text == null)
                    {
                        lblmsg.Text = "Questions No.9 Remarks in Brother/Sister/Child - 1 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (Rch10.SelectedValue == "1" && RdAppC.SelectedValue == "1")
                {
                    if (Tch10.Text == "" || Tch10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in Brother/Sister/Child - 1 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            if (RdAppC2.SelectedValue == "1")
            {
                //if (!(Rchi1.SelectedValue == "" && Rchi2.SelectedValue == "" && Rchi3.SelectedValue == "" && Rchi4.SelectedValue == "" && Rchi5.SelectedValue == "" && Rchi6.SelectedValue == "" && Rchi7.SelectedValue == "" && Rchi8.SelectedValue == "" && Rchi9.SelectedValue == "" && Rchi10.SelectedValue == "" && Rchi11.SelectedValue == "" && Rchi12.SelectedValue == "" && Rchi13.SelectedValue == "" && Rchi14.SelectedValue == "" && Rchi15.SelectedValue == "") || (Rchi1.SelectedValue != "" && Rchi2.SelectedValue != "" && Rchi3.SelectedValue != "" && Rchi4.SelectedValue != "" && Rchi5.SelectedValue != "" && Rchi6.SelectedValue != "" && Rchi7.SelectedValue != "" && Rchi8.SelectedValue != "" && Rchi9.SelectedValue != "" && Rchi10.SelectedValue != "" && Rchi11.SelectedValue != "" && Rchi12.SelectedValue != "" && Rchi13.SelectedValue != "" && Rchi14.SelectedValue != "" && Rchi15.SelectedValue != ""))
                //{
                if (Rchi1.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.1 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi2.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.2 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Rchi3.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.3 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi4.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.4 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi5.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.5 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi6.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.6 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi7.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.7 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi8.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.8 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi9.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.9 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi10.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.10 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi11.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.11 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi12.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.12 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi13.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.13 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi14.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.14 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi15.SelectedValue == "" && RdAppC2.SelectedValue == "1")
                {
                    lblmsg.Text = "Questions No.15 in Brother/Sister/Child - 2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi2.SelectedValue == "1" && RdAppC2.SelectedValue == "1")
                {
                    if (Tchi2.Text == "" || Tchi2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Brother/Sister/Child - 2 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (Rchi9.SelectedValue == "1" && RdAppC2.SelectedValue == "1")
                {
                    if (Tchi9.Text == "" || Tchi9.Text == null)
                    {
                        lblmsg.Text = "Questions No.9 Remarks in Brother/Sister/Child - 2 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (Rchi10.SelectedValue == "1" && RdAppC2.SelectedValue == "1")
                {
                    if (Tchi10.Text == "" || Tchi10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in Brother/Sister/Child - 2 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }


            if (RPS1.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.1 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS2.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.2 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (RPS3.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.3 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS4.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.4 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS5.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.5 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS6.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.6 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS7.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.7 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS8.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.8 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS9.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.8 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS9.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.9 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS10.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.10 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS11.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.11 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS12.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.12 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS13.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.13 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS14.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.14 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (RPS15.SelectedValue == "")
            {
                lblmsg.Text = "Questions No.15 is mandatory.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (RPS2.SelectedValue == "1")
            {
                if (TPS2.Text == "" || TPS2.Text == null)
                {
                    lblmsg.Text = "Questions No.2 Remarks in Personal tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            if (RPS9.SelectedValue == "1")
            {
                if (TPS9.Text == "" || TPS9.Text == null)
                {
                    lblmsg.Text = "Questions No.9 Remarks in Personal tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            if (RPS10.SelectedValue == "1")
            {
                if (TPS10.Text == "" || TPS10.Text == null)
                {
                    lblmsg.Text = "Questions No.10 Remarks in Personal tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }



            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("UserCode");
            dt.Columns.Add("Type");
            dt.Columns.Add("Question");
            dt.Columns.Add("Answer");
            dt.Columns.Add("Remarks");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("UpdatedBy");


            DataRow dr1 = dt.NewRow();
            dr1["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr1["Type"] = "P";
            dr1["Question"] = lblcough.Text;
            dr1["Answer"] = RPS1.SelectedValue;
            dr1["Remarks"] = TPS1.Text;
            dr1["CreatedBy"] = Session["UserId"].ToString();
            dr1["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr2["Type"] = "P";
            dr2["Question"] = Label1.Text;
            dr2["Answer"] = RPS2.SelectedValue;
            dr2["Remarks"] = TPS2.Text;
            dr2["CreatedBy"] = Session["UserId"].ToString();
            dr2["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr3["Type"] = "P";
            dr3["Question"] = Label2.Text;
            dr3["Answer"] = RPS3.SelectedValue;
            dr3["Remarks"] = TPS3.Text;
            dr3["CreatedBy"] = Session["UserId"].ToString();
            dr3["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr3);
            DataRow dr4 = dt.NewRow();
            dr4["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr4["Type"] = "P";
            dr4["Question"] = Label3.Text;
            dr4["Answer"] = RPS4.SelectedValue;
            dr4["Remarks"] = TPS4.Text;
            dr4["CreatedBy"] = Session["UserId"].ToString();
            dr4["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr4);
            DataRow dr5 = dt.NewRow();
            dr5["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr5["Type"] = "P";
            dr5["Question"] = Label4.Text;
            dr5["Answer"] = RPS5.SelectedValue;
            dr5["Remarks"] = TPS5.Text;
            dr5["CreatedBy"] = Session["UserId"].ToString();
            dr5["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr5);
            DataRow dr6 = dt.NewRow();
            dr6["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr6["Type"] = "P";
            dr6["Question"] = Label5.Text;
            dr6["Answer"] = RPS6.SelectedValue;
            dr6["Remarks"] = TPS6.Text;
            dr6["CreatedBy"] = Session["UserId"].ToString();
            dr6["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr6);
            DataRow dr7 = dt.NewRow();
            dr7["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr7["Type"] = "P";
            dr7["Question"] = Label6.Text;
            dr7["Answer"] = RPS7.SelectedValue;
            dr7["Remarks"] = TPS7.Text;
            dr7["CreatedBy"] = Session["UserId"].ToString();
            dr7["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr7);
            DataRow dr8 = dt.NewRow();
            dr8["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr8["Type"] = "P";
            dr8["Question"] = Label7.Text;
            dr8["Answer"] = RPS8.SelectedValue;
            dr8["Remarks"] = TPS8.Text;
            dr8["CreatedBy"] = Session["UserId"].ToString();
            dr8["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr8);
            DataRow dr9 = dt.NewRow();
            dr9["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr9["Type"] = "P";
            dr9["Question"] = Label8.Text;
            dr9["Answer"] = RPS9.SelectedValue;
            dr9["Remarks"] = TPS9.Text;
            dr9["CreatedBy"] = Session["UserId"].ToString();
            dr9["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr9);
            DataRow dr10 = dt.NewRow();
            dr10["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr10["Type"] = "P";
            dr10["Question"] = Label9.Text;
            dr10["Answer"] = RPS10.SelectedValue;
            dr10["Remarks"] = TPS10.Text;
            dr10["CreatedBy"] = Session["UserId"].ToString();
            dr10["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr10);
            DataRow dr11 = dt.NewRow();
            dr11["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr11["Type"] = "P";
            dr11["Question"] = Label10.Text;
            dr11["Answer"] = RPS11.SelectedValue;
            dr11["Remarks"] = TPS11.Text;
            dr11["CreatedBy"] = Session["UserId"].ToString();
            dr11["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr11);
            DataRow dr12 = dt.NewRow();
            dr12["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr12["Type"] = "P";
            dr12["Question"] = Label11.Text;
            dr12["Answer"] = RPS12.SelectedValue;
            dr12["Remarks"] = TPS12.Text;
            dr12["CreatedBy"] = Session["UserId"].ToString();
            dr12["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr12);
            DataRow dr13 = dt.NewRow();
            dr13["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr13["Type"] = "P";
            dr13["Question"] = Label12.Text;
            dr13["Answer"] = RPS13.SelectedValue;
            dr13["Remarks"] = TPS13.Text;
            dr13["CreatedBy"] = Session["UserId"].ToString();
            dr13["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr13);
            DataRow dr14 = dt.NewRow();
            dr14["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr14["Type"] = "P";
            dr14["Question"] = Label13.Text;
            dr14["Answer"] = RPS14.SelectedValue;
            dr14["Remarks"] = TPS14.Text;
            dr14["CreatedBy"] = Session["UserId"].ToString();
            dr14["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr14);
            DataRow dr15 = dt.NewRow();
            dr15["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr15["Type"] = "P";
            dr15["Question"] = Label14.Text;
            dr15["Answer"] = RPS15.SelectedValue;
            dr15["Remarks"] = TPS15.Text;
            dr15["CreatedBy"] = Session["UserId"].ToString();
            dr15["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr15);

            DataRow dr16 = dt.NewRow();
            dr16["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr16["Type"] = "F";
            dr16["Question"] = Label15.Text;
            dr16["Answer"] = RFa1.SelectedValue;
            dr16["Remarks"] = TFa1.Text;
            dr16["CreatedBy"] = Session["UserId"].ToString();
            dr16["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr16);
            DataRow dr17 = dt.NewRow();
            dr17["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr17["Type"] = "F";
            dr17["Question"] = Label16.Text;
            dr17["Answer"] = RFa2.SelectedValue;
            dr17["Remarks"] = TFa2.Text;
            dr17["CreatedBy"] = Session["UserId"].ToString();
            dr17["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr17);
            DataRow dr18 = dt.NewRow();
            dr18["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr18["Type"] = "F";
            dr18["Question"] = Label17.Text;
            dr18["Answer"] = RFa3.SelectedValue;
            dr18["Remarks"] = TFa3.Text;
            dr18["CreatedBy"] = Session["UserId"].ToString();
            dr18["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr18);
            DataRow dr19 = dt.NewRow();
            dr19["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr19["Type"] = "F";
            dr19["Question"] = Label18.Text;
            dr19["Answer"] = RFa4.SelectedValue;
            dr19["Remarks"] = TFa4.Text;
            dr19["CreatedBy"] = Session["UserId"].ToString();
            dr19["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr19);
            DataRow dr20 = dt.NewRow();
            dr20["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr20["Type"] = "F";
            dr20["Question"] = Label19.Text;
            dr20["Answer"] = RFa5.SelectedValue;
            dr20["Remarks"] = TFa5.Text;
            dr20["CreatedBy"] = Session["UserId"].ToString();
            dr20["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr20);
            DataRow dr21 = dt.NewRow();
            dr21["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr21["Type"] = "F";
            dr21["Question"] = Label20.Text;
            dr21["Answer"] = RFa6.SelectedValue;
            dr21["Remarks"] = TFa6.Text;
            dr21["CreatedBy"] = Session["UserId"].ToString();
            dr21["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr21);
            DataRow dr22 = dt.NewRow();
            dr22["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr22["Type"] = "F";
            dr22["Question"] = Label21.Text;
            dr22["Answer"] = RFa7.SelectedValue;
            dr22["Remarks"] = TFa7.Text;
            dr22["CreatedBy"] = Session["UserId"].ToString();
            dr22["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr22);
            DataRow dr23 = dt.NewRow();
            dr23["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr23["Type"] = "F";
            dr23["Question"] = Label22.Text;
            dr23["Answer"] = RFa8.SelectedValue;
            dr23["Remarks"] = TFa8.Text;
            dr23["CreatedBy"] = Session["UserId"].ToString();
            dr23["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr23);
            DataRow dr24 = dt.NewRow();
            dr24["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr24["Type"] = "F";
            dr24["Question"] = Label23.Text;
            dr24["Answer"] = RFa9.SelectedValue;
            dr24["Remarks"] = TFa9.Text;
            dr24["CreatedBy"] = Session["UserId"].ToString();
            dr24["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr24);
            DataRow dr25 = dt.NewRow();
            dr25["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr25["Type"] = "F";
            dr25["Question"] = Label24.Text;
            dr25["Answer"] = RFa10.SelectedValue;
            dr25["Remarks"] = TFa10.Text;
            dr25["CreatedBy"] = Session["UserId"].ToString();
            dr25["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr25);
            DataRow dr26 = dt.NewRow();
            dr26["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr26["Type"] = "F";
            dr26["Question"] = Label25.Text;
            dr26["Answer"] = RFa11.SelectedValue;
            dr26["Remarks"] = TFa11.Text;
            dr26["CreatedBy"] = Session["UserId"].ToString();
            dr26["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr26);
            DataRow dr27 = dt.NewRow();
            dr27["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr27["Type"] = "F";
            dr27["Question"] = Label26.Text;
            dr27["Answer"] = RFa12.SelectedValue;
            dr27["Remarks"] = TFa12.Text;
            dr27["CreatedBy"] = Session["UserId"].ToString();
            dr27["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr27);
            DataRow dr28 = dt.NewRow();
            dr28["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr28["Type"] = "F";
            dr28["Question"] = Label27.Text;
            dr28["Answer"] = RFa13.SelectedValue;
            dr28["Remarks"] = TFa13.Text;
            dr28["CreatedBy"] = Session["UserId"].ToString();
            dr28["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr28);
            DataRow dr29 = dt.NewRow();
            dr29["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr29["Type"] = "F";
            dr29["Question"] = Label28.Text;
            dr29["Answer"] = RFa14.SelectedValue;
            dr29["Remarks"] = TFa14.Text;
            dr29["CreatedBy"] = Session["UserId"].ToString();
            dr29["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr29);
            DataRow dr30 = dt.NewRow();
            dr30["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr30["Type"] = "F";
            dr30["Question"] = Label29.Text;
            dr30["Answer"] = RFa15.SelectedValue;
            dr30["Remarks"] = TFa15.Text;
            dr30["CreatedBy"] = Session["UserId"].ToString();
            dr30["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr30);

            DataRow dr31 = dt.NewRow();
            dr31["UserCode"] = ViewState["CovidUserId"].ToString();// Session["UserId"].ToString();
            dr31["Type"] = "M";
            dr31["Question"] = Label30.Text;
            dr31["Answer"] = RMr1.SelectedValue;
            dr31["Remarks"] = TMr1.Text;
            dr31["CreatedBy"] = Session["UserId"].ToString();
            dr31["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr31);
            DataRow dr32 = dt.NewRow();
            dr32["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr32["Type"] = "M";
            dr32["Question"] = Label31.Text;
            dr32["Answer"] = RMr2.SelectedValue;
            dr32["Remarks"] = TMr2.Text;
            dr32["CreatedBy"] = Session["UserId"].ToString();
            dr32["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr32);
            DataRow dr33 = dt.NewRow();
            dr33["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr33["Type"] = "M";
            dr33["Question"] = Label32.Text;
            dr33["Answer"] = RMr3.SelectedValue;
            dr33["Remarks"] = TMr3.Text;
            dr33["CreatedBy"] = Session["UserId"].ToString();
            dr33["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr33);
            DataRow dr34 = dt.NewRow();
            dr34["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr34["Type"] = "M";
            dr34["Question"] = Label33.Text;
            dr34["Answer"] = RMr4.SelectedValue;
            dr34["Remarks"] = TMr4.Text;
            dr34["CreatedBy"] = Session["UserId"].ToString();
            dr34["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr34);
            DataRow dr35 = dt.NewRow();
            dr35["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr35["Type"] = "M";
            dr35["Question"] = Label34.Text;
            dr35["Answer"] = RMr5.SelectedValue;
            dr35["Remarks"] = TMr5.Text;
            dr35["CreatedBy"] = Session["UserId"].ToString();
            dr35["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr35);
            DataRow dr36 = dt.NewRow();
            dr36["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr36["Type"] = "M";
            dr36["Question"] = Label35.Text;
            dr36["Answer"] = RMr6.SelectedValue;
            dr36["Remarks"] = TMr6.Text;
            dr36["CreatedBy"] = Session["UserId"].ToString();
            dr36["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr36);
            DataRow dr37 = dt.NewRow();
            dr37["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr37["Type"] = "M";
            dr37["Question"] = Label36.Text;
            dr37["Answer"] = RMr7.SelectedValue;
            dr37["Remarks"] = TMr7.Text;
            dr37["CreatedBy"] = Session["UserId"].ToString();
            dr37["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr37);
            DataRow dr38 = dt.NewRow();
            dr38["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr38["Type"] = "M";
            dr38["Question"] = Label37.Text;
            dr38["Answer"] = RMr8.SelectedValue;
            dr38["Remarks"] = TMr8.Text;
            dr38["CreatedBy"] = Session["UserId"].ToString();
            dr38["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr38);
            DataRow dr39 = dt.NewRow();
            dr39["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr39["Type"] = "M";
            dr39["Question"] = Label38.Text;
            dr39["Answer"] = RMr9.SelectedValue;
            dr39["Remarks"] = TMr9.Text;
            dr39["CreatedBy"] = Session["UserId"].ToString();
            dr39["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr39);
            DataRow dr40 = dt.NewRow();
            dr40["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr40["Type"] = "M";
            dr40["Question"] = Label39.Text;
            dr40["Answer"] = RMr10.SelectedValue;
            dr40["Remarks"] = TMr10.Text;
            dr40["CreatedBy"] = Session["UserId"].ToString();
            dr40["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr40);
            DataRow dr41 = dt.NewRow();
            dr41["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr41["Type"] = "M";
            dr41["Question"] = Label40.Text;
            dr41["Answer"] = RMr11.SelectedValue;
            dr41["Remarks"] = TMr11.Text;
            dr41["CreatedBy"] = Session["UserId"].ToString();
            dr41["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr41);
            DataRow dr42 = dt.NewRow();
            dr42["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr42["Type"] = "M";
            dr42["Question"] = Label41.Text;
            dr42["Answer"] = RMr12.SelectedValue;
            dr42["Remarks"] = TMr12.Text;
            dr42["CreatedBy"] = Session["UserId"].ToString();
            dr42["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr42);
            DataRow dr43 = dt.NewRow();
            dr43["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr43["Type"] = "M";
            dr43["Question"] = Label42.Text;
            dr43["Answer"] = RMr13.SelectedValue;
            dr43["Remarks"] = TMr13.Text;
            dr43["CreatedBy"] = Session["UserId"].ToString();
            dr43["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr43);
            DataRow dr44 = dt.NewRow();
            dr44["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr44["Type"] = "M";
            dr44["Question"] = Label43.Text;
            dr44["Answer"] = RMr14.SelectedValue;
            dr44["Remarks"] = TMr14.Text;
            dr44["CreatedBy"] = Session["UserId"].ToString();
            dr44["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr44);
            DataRow dr45 = dt.NewRow();
            dr45["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr45["Type"] = "M";
            dr45["Question"] = Label44.Text;
            dr45["Answer"] = RMr15.SelectedValue;
            dr45["Remarks"] = TMr15.Text;
            dr45["CreatedBy"] = Session["UserId"].ToString();
            dr45["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr45);

            DataRow dr46 = dt.NewRow();
            dr46["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr46["Type"] = "W";
            dr46["Question"] = Label45.Text;
            dr46["Answer"] = RWf1.SelectedValue;
            dr46["Remarks"] = TWf1.Text;
            dr46["CreatedBy"] = Session["UserId"].ToString();
            dr46["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr46);
            DataRow dr47 = dt.NewRow();
            dr47["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr47["Type"] = "W";
            dr47["Question"] = Label46.Text;
            dr47["Answer"] = RWf2.SelectedValue;
            dr47["Remarks"] = TWf2.Text;
            dr47["CreatedBy"] = Session["UserId"].ToString();
            dr47["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr47);
            DataRow dr48 = dt.NewRow();
            dr48["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr48["Type"] = "W";
            dr48["Question"] = Label47.Text;
            dr48["Answer"] = RWf3.SelectedValue;
            dr48["Remarks"] = TWf3.Text;
            dr48["CreatedBy"] = Session["UserId"].ToString();
            dr48["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr48);
            DataRow dr49 = dt.NewRow();
            dr49["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr49["Type"] = "W";
            dr49["Question"] = Label48.Text;
            dr49["Answer"] = RWf4.SelectedValue;
            dr49["Remarks"] = TWf4.Text;
            dr49["CreatedBy"] = Session["UserId"].ToString();
            dr49["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr49);
            DataRow dr50 = dt.NewRow();
            dr50["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr50["Type"] = "W";
            dr50["Question"] = Label49.Text;
            dr50["Answer"] = RWf5.SelectedValue;
            dr50["Remarks"] = TWf5.Text;
            dr50["CreatedBy"] = Session["UserId"].ToString();
            dr50["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr50);
            DataRow dr51 = dt.NewRow();
            dr51["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr51["Type"] = "W";
            dr51["Question"] = Label50.Text;
            dr51["Answer"] = RWf6.SelectedValue;
            dr51["Remarks"] = TWf6.Text;
            dr51["CreatedBy"] = Session["UserId"].ToString();
            dr51["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr51);
            DataRow dr52 = dt.NewRow();
            dr52["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr52["Type"] = "W";
            dr52["Question"] = Label51.Text;
            dr52["Answer"] = RWf7.SelectedValue;
            dr52["Remarks"] = TWf7.Text;
            dr52["CreatedBy"] = Session["UserId"].ToString();
            dr52["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr52);
            DataRow dr53 = dt.NewRow();
            dr53["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr53["Type"] = "W";
            dr53["Question"] = Label52.Text;
            dr53["Answer"] = RWf8.SelectedValue;
            dr53["Remarks"] = TWf8.Text;
            dr53["CreatedBy"] = Session["UserId"].ToString();
            dr53["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr53);
            DataRow dr54 = dt.NewRow();
            dr54["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr54["Type"] = "W";
            dr54["Question"] = Label53.Text;
            dr54["Answer"] = RWf9.SelectedValue;
            dr54["Remarks"] = TWf9.Text;
            dr54["CreatedBy"] = Session["UserId"].ToString();
            dr54["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr54);
            DataRow dr55 = dt.NewRow();
            dr55["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr55["Type"] = "W";
            dr55["Question"] = Label54.Text;
            dr55["Answer"] = RWf10.SelectedValue;
            dr55["Remarks"] = TWf10.Text;
            dr55["CreatedBy"] = Session["UserId"].ToString();
            dr55["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr55);
            DataRow dr56 = dt.NewRow();
            dr56["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr56["Type"] = "W";
            dr56["Question"] = Label55.Text;
            dr56["Answer"] = RWf11.SelectedValue;
            dr56["Remarks"] = TWf11.Text;
            dr56["CreatedBy"] = Session["UserId"].ToString();
            dr56["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr56);
            DataRow dr57 = dt.NewRow();
            dr57["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr57["Type"] = "W";
            dr57["Question"] = Label56.Text;
            dr57["Answer"] = RWf12.SelectedValue;
            dr57["Remarks"] = TWf12.Text;
            dr57["CreatedBy"] = Session["UserId"].ToString();
            dr57["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr57);
            DataRow dr58 = dt.NewRow();
            dr58["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr58["Type"] = "W";
            dr58["Question"] = Label57.Text;
            dr58["Answer"] = RWf13.SelectedValue;
            dr58["Remarks"] = TWf13.Text;
            dr58["CreatedBy"] = Session["UserId"].ToString();
            dr58["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr58);
            DataRow dr59 = dt.NewRow();
            dr59["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr59["Type"] = "W";
            dr59["Question"] = Label58.Text;
            dr59["Answer"] = RWf14.SelectedValue;
            dr59["Remarks"] = TWf14.Text;
            dr59["CreatedBy"] = Session["UserId"].ToString();
            dr59["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr59);
            DataRow dr60 = dt.NewRow();
            dr60["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr60["Type"] = "W";
            dr60["Question"] = Label59.Text;
            dr60["Answer"] = RWf15.SelectedValue;
            dr60["Remarks"] = TWf15.Text;
            dr60["CreatedBy"] = Session["UserId"].ToString();
            dr60["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr60);

            DataRow dr61 = dt.NewRow();
            dr61["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr61["Type"] = "C1";
            dr61["Question"] = Label60.Text;
            dr61["Answer"] = Rch1.SelectedValue;
            dr61["Remarks"] = Tch1.Text;
            dr61["CreatedBy"] = Session["UserId"].ToString();
            dr61["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr61);
            DataRow dr62 = dt.NewRow();
            dr62["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr62["Type"] = "C1";
            dr62["Question"] = Label61.Text;
            dr62["Answer"] = Rch2.SelectedValue;
            dr62["Remarks"] = Tch2.Text;
            dr62["CreatedBy"] = Session["UserId"].ToString();
            dr62["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr62);
            DataRow dr63 = dt.NewRow();
            dr63["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr63["Type"] = "C1";
            dr63["Question"] = Label62.Text;
            dr63["Answer"] = Rch3.SelectedValue;
            dr63["Remarks"] = Tch3.Text;
            dr63["CreatedBy"] = Session["UserId"].ToString();
            dr63["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr63);
            DataRow dr64 = dt.NewRow();
            dr64["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr64["Type"] = "C1";
            dr64["Question"] = Label63.Text;
            dr64["Answer"] = Rch4.SelectedValue;
            dr64["Remarks"] = Tch4.Text;
            dr64["CreatedBy"] = Session["UserId"].ToString();
            dr64["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr64);
            DataRow dr65 = dt.NewRow();
            dr65["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr65["Type"] = "C1";
            dr65["Question"] = Label64.Text;
            dr65["Answer"] = Rch5.SelectedValue;
            dr65["Remarks"] = Tch5.Text;
            dr65["CreatedBy"] = Session["UserId"].ToString();
            dr65["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr65);
            DataRow dr66 = dt.NewRow();
            dr66["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr66["Type"] = "C1";
            dr66["Question"] = Label65.Text;
            dr66["Answer"] = Rch6.SelectedValue;
            dr66["Remarks"] = Tch6.Text;
            dr66["CreatedBy"] = Session["UserId"].ToString();
            dr66["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr66);
            DataRow dr67 = dt.NewRow();
            dr67["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr67["Type"] = "C1";
            dr67["Question"] = Label66.Text;
            dr67["Answer"] = Rch7.SelectedValue;
            dr67["Remarks"] = Tch7.Text;
            dr67["CreatedBy"] = Session["UserId"].ToString();
            dr67["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr67);
            DataRow dr68 = dt.NewRow();
            dr68["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr68["Type"] = "C1";
            dr68["Question"] = Label67.Text;
            dr68["Answer"] = Rch8.SelectedValue;
            dr68["Remarks"] = Tch8.Text;
            dr68["CreatedBy"] = Session["UserId"].ToString();
            dr68["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr68);
            DataRow dr69 = dt.NewRow();
            dr69["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr69["Type"] = "C1";
            dr69["Question"] = Label68.Text;
            dr69["Answer"] = Rch9.SelectedValue;
            dr69["Remarks"] = Tch9.Text;
            dr69["CreatedBy"] = Session["UserId"].ToString();
            dr69["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr69);
            DataRow dr70 = dt.NewRow();
            dr70["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr70["Type"] = "C1";
            dr70["Question"] = Label69.Text;
            dr70["Answer"] = Rch10.SelectedValue;
            dr70["Remarks"] = Tch10.Text;
            dr70["CreatedBy"] = Session["UserId"].ToString();
            dr70["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr70);
            DataRow dr71 = dt.NewRow();
            dr71["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr71["Type"] = "C1";
            dr71["Question"] = Label70.Text;
            dr71["Answer"] = Rch11.SelectedValue;
            dr71["Remarks"] = Tch11.Text;
            dr71["CreatedBy"] = Session["UserId"].ToString();
            dr71["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr71);
            DataRow dr72 = dt.NewRow();
            dr72["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr72["Type"] = "C1";
            dr72["Question"] = Label71.Text;
            dr72["Answer"] = Rch12.SelectedValue;
            dr72["Remarks"] = Tch12.Text;
            dr72["CreatedBy"] = Session["UserId"].ToString();
            dr72["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr72);
            DataRow dr73 = dt.NewRow();
            dr73["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr73["Type"] = "C1";
            dr73["Question"] = Label72.Text;
            dr73["Answer"] = Rch13.SelectedValue;
            dr73["Remarks"] = Tch13.Text;
            dr73["CreatedBy"] = Session["UserId"].ToString();
            dr73["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr73);
            DataRow dr74 = dt.NewRow();
            dr74["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr74["Type"] = "C1";
            dr74["Question"] = Label73.Text;
            dr74["Answer"] = Rch14.SelectedValue;
            dr74["Remarks"] = Tch14.Text;
            dr74["CreatedBy"] = Session["UserId"].ToString();
            dr74["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr74);
            DataRow dr75 = dt.NewRow();
            dr75["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr75["Type"] = "C1";
            dr75["Question"] = Label74.Text;
            dr75["Answer"] = Rch15.SelectedValue;
            dr75["Remarks"] = Tch15.Text;
            dr75["CreatedBy"] = Session["UserId"].ToString();
            dr75["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr75);

            DataRow dr76 = dt.NewRow();
            dr76["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr76["Type"] = "C2";
            dr76["Question"] = Label75.Text;
            dr76["Answer"] = Rchi1.SelectedValue;
            dr76["Remarks"] = Tchi1.Text;
            dr76["CreatedBy"] = Session["UserId"].ToString();
            dr76["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr76);
            DataRow dr77 = dt.NewRow();
            dr77["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr77["Type"] = "C2";
            dr77["Question"] = Label76.Text;
            dr77["Answer"] = Rchi2.SelectedValue;
            dr77["Remarks"] = Tchi2.Text;
            dr77["CreatedBy"] = Session["UserId"].ToString();
            dr77["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr77);
            DataRow dr78 = dt.NewRow();
            dr78["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr78["Type"] = "C2";
            dr78["Question"] = Label77.Text;
            dr78["Answer"] = Rchi3.SelectedValue;
            dr78["Remarks"] = Tchi3.Text;
            dr78["CreatedBy"] = Session["UserId"].ToString();
            dr78["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr78);
            DataRow dr79 = dt.NewRow();
            dr79["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr79["Type"] = "C2";
            dr79["Question"] = Label78.Text;
            dr79["Answer"] = Rchi4.SelectedValue;
            dr79["Remarks"] = Tchi4.Text;
            dr79["CreatedBy"] = Session["UserId"].ToString();
            dr79["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr79);
            DataRow dr80 = dt.NewRow();
            dr80["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr80["Type"] = "C2";
            dr80["Question"] = Label79.Text;
            dr80["Answer"] = Rchi5.SelectedValue;
            dr80["Remarks"] = Tchi5.Text;
            dr80["CreatedBy"] = Session["UserId"].ToString();
            dr80["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr80);
            DataRow dr81 = dt.NewRow();
            dr81["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr81["Type"] = "C2";
            dr81["Question"] = Label80.Text;
            dr81["Answer"] = Rchi6.SelectedValue;
            dr81["Remarks"] = Tchi6.Text;
            dr81["CreatedBy"] = Session["UserId"].ToString();
            dr81["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr81);
            DataRow dr82 = dt.NewRow();
            dr82["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr82["Type"] = "C2";
            dr82["Question"] = Label81.Text;
            dr82["Answer"] = Rchi7.SelectedValue;
            dr82["Remarks"] = Tchi7.Text;
            dr82["CreatedBy"] = Session["UserId"].ToString();
            dr82["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr82);
            DataRow dr83 = dt.NewRow();
            dr83["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr83["Type"] = "C2";
            dr83["Question"] = Label82.Text;
            dr83["Answer"] = Rchi8.SelectedValue;
            dr83["Remarks"] = Tchi8.Text;
            dr83["CreatedBy"] = Session["UserId"].ToString();
            dr83["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr83);
            DataRow dr84 = dt.NewRow();
            dr84["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr84["Type"] = "C2";
            dr84["Question"] = Label83.Text;
            dr84["Answer"] = Rchi9.SelectedValue;
            dr84["Remarks"] = Tchi9.Text;
            dr84["CreatedBy"] = Session["UserId"].ToString();
            dr84["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr84);
            DataRow dr85 = dt.NewRow();
            dr85["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr85["Type"] = "C2";
            dr85["Question"] = Label84.Text;
            dr85["Answer"] = Rchi10.SelectedValue;
            dr85["Remarks"] = Tchi10.Text;
            dr85["CreatedBy"] = Session["UserId"].ToString();
            dr85["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr85);
            DataRow dr86 = dt.NewRow();
            dr86["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr86["Type"] = "C2";
            dr86["Question"] = Label85.Text;
            dr86["Answer"] = Rchi11.SelectedValue;
            dr86["Remarks"] = Tchi11.Text;
            dr86["CreatedBy"] = Session["UserId"].ToString();
            dr86["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr86);
            DataRow dr87 = dt.NewRow();
            dr87["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr87["Type"] = "C2";
            dr87["Question"] = Label86.Text;
            dr87["Answer"] = Rchi12.SelectedValue;
            dr87["Remarks"] = Tchi12.Text;
            dr87["CreatedBy"] = Session["UserId"].ToString();
            dr87["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr87);
            DataRow dr88 = dt.NewRow();
            dr88["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr88["Type"] = "C2";
            dr88["Question"] = Label87.Text;
            dr88["Answer"] = Rchi13.SelectedValue;
            dr88["Remarks"] = Tchi13.Text;
            dr88["CreatedBy"] = Session["UserId"].ToString();
            dr88["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr88);
            DataRow dr89 = dt.NewRow();
            dr89["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr89["Type"] = "C2";
            dr89["Question"] = Label88.Text;
            dr89["Answer"] = Rchi14.SelectedValue;
            dr89["Remarks"] = Tchi14.Text;
            dr89["CreatedBy"] = Session["UserId"].ToString();
            dr89["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr89);
            DataRow dr90 = dt.NewRow();
            dr90["UserCode"] = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
            dr90["Type"] = "C2";
            dr90["Question"] = Label89.Text;
            dr90["Answer"] = Rchi15.SelectedValue;
            dr90["Remarks"] = Tchi15.Text;
            dr90["CreatedBy"] = Session["UserId"].ToString();
            dr90["UpdatedBy"] = Session["UserId"].ToString();
            dt.Rows.Add(dr90);

            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("Insert_Covid_User_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Dt", dt);
            con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                lblmsg.Text = "Record submitted Succesfully.!!";
                lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            }
            con.Close();
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }      
    private void FillFormonLink()
    {
        string UserCode = ViewState["CovidUserId"].ToString(); //Session["UserId"].ToString();
        try
        {
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("Get_Covid_User_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode","UserCode");
            cmd.Parameters.AddWithValue("@UserCode", UserCode);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            con.Open();
            //sda.Fill(ds);
            sda.Fill(FGds);
            if (FGds.Tables[0].Rows.Count > 0)
            {
               btnSave.Text = "Submit";
               FillForm();
            }
            con.Close();
            
            // FGds = null;
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }

    }
    private void FillForm()
    {
        try
        {
            string x1 = "PS", x2 = "Fa", x3 = "Mr", x4 = "Wf", x5 = "ch", x6 = "chi";
            int a = FGds.Tables[0].Rows.Count / 15;
            if (a == 0)
                return;
            string Tname = null, Rname = null, Type = null;
            TextBox T = new TextBox();
            RadioButtonList R = new RadioButtonList();
            for (int i = 1; i <= a; i++)
            {
                Type = FGds.Tables[0].Rows[(i - 1) * 15 + 1].ItemArray[2].ToString();
                if (Type == "P")
                {
                    Tname = "T" + x1;
                    Rname = "R" + x1;
                }
                else if (Type == "F")
                {
                    Tname = "T" + x2;
                    Rname = "R" + x2;
                }
                else if (Type == "M")
                {
                    Tname = "T" + x3;
                    Rname = "R" + x3;
                }

                else if (Type == "W")
                {
                    Tname = "T" + x4;
                    Rname = "R" + x4;
                }
                else if (Type == "C1")
                {
                    Tname = "T" + x5;
                    Rname = "R" + x5;
                }
                else if (Type == "C2")
                {
                    Tname = "T" + x6;
                    Rname = "R" + x6;
                }

                for (int j = 0; j < 15; j++)
                {
                    string Tname1 = Tname;
                    string Rname1 = Rname;
                    Tname1 = Tname1 + (j + 1).ToString();
                    Rname1 = Rname1 + (j + 1).ToString();
                    T = (TextBox)PnlFrom.FindControl(Tname1);
                    R = (RadioButtonList)PnlFrom.FindControl(Rname1);
                    R.SelectedValue = FGds.Tables[0].Rows[(i - 1) * 15 + j].ItemArray[0].ToString();
                    T.Text = FGds.Tables[0].Rows[(i - 1) * 15 + j].ItemArray[1].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }

    }
    public void GetEmpHeader(string EmpCode)
    {
        try
        {
            lblTCode.Text = "";
            lblName.Text = "";
            lblDsgntin.Text = "";
            lblDptmt.Text = "";
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("SP_GetEmpDegDept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", EmpCode);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sda.Fill(dt);
            lblTCode.Text = EmpCode;
            lblName.Text = dt.Rows[0]["EmployeeName"].ToString();
            lblDsgntin.Text = dt.Rows[0]["Designation"].ToString();
            lblDptmt.Text = dt.Rows[0]["Department"].ToString();
            con.Close();
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
    public void EnableRadiobuttonTrue()
    {
       
        RPS1.Enabled = true; RPS2.Enabled = true; RPS3.Enabled = true; RPS4.Enabled = true; RPS5.Enabled = true;
        RPS6.Enabled = true; RPS7.Enabled = true; RPS8.Enabled = true; RPS9.Enabled = true; RPS10.Enabled = true;
        RPS11.Enabled = true; RPS12.Enabled = true; RPS13.Enabled = true; RPS14.Enabled = true; RPS15.Enabled = true;

        TPS1.Enabled = true; TPS2.Enabled = true; TPS3.Enabled = true; TPS4.Enabled = true; TPS5.Enabled = true;
        TPS6.Enabled = true; TPS7.Enabled = true; TPS8.Enabled = true; TPS9.Enabled = true; TPS10.Enabled = true;
        TPS11.Enabled = true; TPS12.Enabled = true; TPS13.Enabled = true; TPS14.Enabled = true; TPS15.Enabled = true;

        RFa1.Enabled = true; RFa2.Enabled = true; RFa3.Enabled = true; RFa4.Enabled = true; RFa5.Enabled = true;
        RFa6.Enabled = true; RFa7.Enabled = true; RFa8.Enabled = true; RFa9.Enabled = true; RFa10.Enabled = true;
        RFa11.Enabled = true; RFa12.Enabled = true; RFa13.Enabled = true; RFa14.Enabled = true; RFa15.Enabled = true;

        TFa1.Enabled = true; TFa2.Enabled = true; TFa3.Enabled = true; TFa4.Enabled = true; TFa5.Enabled = true;
        TFa6.Enabled = true; TFa7.Enabled = true; TFa8.Enabled = true; TFa9.Enabled = true; TFa10.Enabled = true;
        TFa11.Enabled = true; TFa12.Enabled = true; TFa13.Enabled = true; TFa14.Enabled = true; TFa15.Enabled = true;

        RMr1.Enabled = true; RMr2.Enabled = true; RMr3.Enabled = true; RMr4.Enabled = true; RMr5.Enabled = true;
        RMr6.Enabled = true; RMr7.Enabled = true; RMr8.Enabled = true; RMr9.Enabled = true; RMr10.Enabled = true;
        RMr11.Enabled = true; RMr12.Enabled = true; RMr13.Enabled = true; RMr14.Enabled = true; RMr15.Enabled = true;

        TMr1.Enabled = true; TMr2.Enabled = true; TMr3.Enabled = true; TMr4.Enabled = true; TMr5.Enabled = true;
        TMr6.Enabled = true; TMr7.Enabled = true; TMr8.Enabled = true; TMr9.Enabled = true; TMr10.Enabled = true;
        TMr11.Enabled = true; TMr12.Enabled = true; TMr13.Enabled = true; TMr14.Enabled = true; TMr15.Enabled = true;

        RWf1.Enabled = true; RWf2.Enabled = true; RWf3.Enabled = true; RWf4.Enabled = true; RWf5.Enabled = true;
        RWf6.Enabled = true; RWf7.Enabled = true; RWf8.Enabled = true; RWf9.Enabled = true; RWf10.Enabled = true;
        RWf11.Enabled = true; RWf12.Enabled = true; RWf13.Enabled = true; RWf14.Enabled = true; RWf15.Enabled = true;

        TWf1.Enabled = true; TWf2.Enabled = true; TWf3.Enabled = true; TWf4.Enabled = true; TWf5.Enabled = true;
        TWf6.Enabled = true; TWf7.Enabled = true; TWf8.Enabled = true; TWf9.Enabled = true; TWf10.Enabled = true;
        TWf11.Enabled = true; TWf12.Enabled = true; TWf13.Enabled = true; TWf14.Enabled = true; TWf15.Enabled = true;

        Rch1.Enabled = true; Rch2.Enabled = true; Rch3.Enabled = true; Rch4.Enabled = true; Rch5.Enabled = true;
        Rch6.Enabled = true; Rch7.Enabled = true; Rch8.Enabled = true; Rch9.Enabled = true; Rch10.Enabled = true;
        Rch11.Enabled = true; Rch12.Enabled = true; Rch13.Enabled = true; Rch14.Enabled = true; Rch15.Enabled = true;

        Tch1.Enabled = true; Tch2.Enabled = true; Tch3.Enabled = true; Tch4.Enabled = true; Tch5.Enabled = true;
        Tch6.Enabled = true; Tch7.Enabled = true; Tch8.Enabled = true; Tch9.Enabled = true; Tch10.Enabled = true;
        Tch11.Enabled = true; Tch12.Enabled = true; Tch13.Enabled = true; Tch14.Enabled = true; Tch15.Enabled = true;

        Rchi1.Enabled = true; Rchi2.Enabled = true; Rchi3.Enabled = true; Rchi4.Enabled = true; Rchi5.Enabled = true;
        Rchi6.Enabled = true; Rchi7.Enabled = true; Rchi8.Enabled = true; Rchi9.Enabled = true; Rchi10.Enabled = true;
        Rchi11.Enabled = true; Rchi12.Enabled = true; Rchi13.Enabled = true; Rchi14.Enabled = true; Rchi15.Enabled = true;

        Tchi1.Enabled = true; Tchi2.Enabled = true; Tchi3.Enabled = true; Tchi4.Enabled = true; Tchi5.Enabled = true;
        Tchi6.Enabled = true; Tchi7.Enabled = true; Tchi8.Enabled = true; Tchi9.Enabled = true; Tchi10.Enabled = true;
        Tchi11.Enabled = true; Tchi12.Enabled = true; Tchi13.Enabled = true; Tchi14.Enabled = true; Tchi15.Enabled = true;
    }
    void CheckPermission()
    {
        ViewState["AllEmployeeAccess"] = ViewState["AllEmployeeAccess"] == null ? Session["AllEmployeeAccess"] : ViewState["AllEmployeeAccess"];
        ViewState["AllBranchAccess"] = ViewState["AllBranchAccess"] == null ? Session["AllBranchAccess"] : ViewState["AllBranchAccess"];
        if (ViewState["AllEmployeeAccess"] == null || Convert.ToInt32(ViewState["AllEmployeeAccess"]) == 0)
        {
            txtemployee.Text = Session["EmployeeNameCode"].ToString();
            txtemployee.Enabled = false;
        }
    }

    protected void txtemployee_TextChanged(object sender, EventArgs e)
    {
        string EmpCode = UtilityUI.GetEmpCode(txtemployee.Text.Trim());
        if (EmpCode.Length > 0)
        {

            ViewState["CovidUserId"] = EmpCode;
            GetEmpHeader(EmpCode);
            rblBlank();
            lblmsg.Text = "";
            FillFormonLink();
        }
    }
    public void rblBlank()
    {
        RdApp.SelectedIndex = 0; RdAppM.SelectedIndex = 0; RdAppW.SelectedIndex = 0; RdAppC.SelectedIndex = 0; RdAppC2.SelectedIndex = 0;
        Rchi1.ClearSelection();
        RFa1.ClearSelection(); RFa2.ClearSelection(); RFa3.ClearSelection(); RFa4.ClearSelection(); RFa5.ClearSelection(); RFa6.ClearSelection(); RFa7.ClearSelection(); RFa8.ClearSelection(); RFa9.ClearSelection(); RFa10.ClearSelection(); RFa11.ClearSelection(); RFa12.ClearSelection(); RFa13.ClearSelection(); RFa14.ClearSelection(); RFa15.ClearSelection();
        RMr1.ClearSelection(); RMr2.ClearSelection(); RMr3.ClearSelection(); RMr4.ClearSelection(); RMr5.ClearSelection(); RMr6.ClearSelection(); RMr7.ClearSelection(); RMr8.ClearSelection(); RMr9.ClearSelection(); RMr10.ClearSelection(); RMr11.ClearSelection(); RMr12.ClearSelection(); RMr13.ClearSelection(); RMr14.ClearSelection(); RMr15.ClearSelection();
        RWf1.ClearSelection(); RWf2.ClearSelection(); RWf3.ClearSelection(); RWf4.ClearSelection(); RWf5.ClearSelection(); RWf6.ClearSelection(); RWf7.ClearSelection(); RWf8.ClearSelection(); RWf9.ClearSelection(); RWf10.ClearSelection(); RWf11.ClearSelection(); RWf12.ClearSelection(); RWf13.ClearSelection(); RWf14.ClearSelection(); RWf15.ClearSelection();
        Rch1.ClearSelection(); Rch2.ClearSelection(); Rch3.ClearSelection(); Rch4.ClearSelection(); Rch5.ClearSelection(); Rch6.ClearSelection(); Rch7.ClearSelection(); Rch8.ClearSelection(); Rch9.ClearSelection(); Rch10.ClearSelection(); Rch11.ClearSelection(); Rch12.ClearSelection(); Rch13.ClearSelection(); Rch14.ClearSelection(); Rch15.ClearSelection();
        Rchi1.ClearSelection(); Rchi2.ClearSelection(); Rchi3.ClearSelection(); Rchi4.ClearSelection(); Rchi5.ClearSelection(); Rchi6.ClearSelection(); Rchi7.ClearSelection(); Rchi8.ClearSelection(); Rchi9.ClearSelection(); Rchi10.ClearSelection(); Rchi11.ClearSelection(); Rchi12.ClearSelection(); Rchi13.ClearSelection(); Rchi14.ClearSelection(); Rchi15.ClearSelection();
    }
}