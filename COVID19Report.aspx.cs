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

public partial class COVID19Report : System.Web.UI.Page
{

    string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SProll"].ConnectionString;
    DataSet FGds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(!IsPostBack)
            {
                lblmsg.Text = "";
                //ViewState["Y"] = "";
                PnlGrid.Visible = true;
                PnlFrom.Visible = false;
                BindGrid();
                LoadComplete += TDSProjectionForm12BB_LoadComplete;
                btnSave.Visible = false;
            }                

        }       
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }      
    }
    private void TDSProjectionForm12BB_LoadComplete(object sender, EventArgs e)
    {
        FillForm();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (!(RFa1.SelectedValue == "" && RFa2.SelectedValue == "" && RFa3.SelectedValue == "" && RFa4.SelectedValue == "" && RFa5.SelectedValue == "" && RFa6.SelectedValue == "" && RFa7.SelectedValue == "" && RFa8.SelectedValue == "" && RFa9.SelectedValue == "" && RFa10.SelectedValue == "" && RFa11.SelectedValue == "" && RFa12.SelectedValue == "" && RFa13.SelectedValue == "" && RFa14.SelectedValue == "" && RFa15.SelectedValue == "") || (RFa1.SelectedValue != "" && RFa2.SelectedValue != "" && RFa3.SelectedValue != "" && RFa4.SelectedValue != "" && RFa5.SelectedValue != "" && RFa6.SelectedValue != "" && RFa7.SelectedValue != "" && RFa8.SelectedValue != "" && RFa9.SelectedValue != "" && RFa10.SelectedValue != "" && RFa11.SelectedValue != "" && RFa12.SelectedValue != "" && RFa13.SelectedValue != "" && RFa14.SelectedValue != "" && RFa15.SelectedValue != ""))
            {
                if (RFa1.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.1 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa2.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.2 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (RFa3.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.3 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa4.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.4 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa5.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.5 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa6.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.6 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa7.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.7 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa8.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.8 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa9.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.9 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa10.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.10 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa11.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.11 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa12.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.12 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa13.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.13 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa14.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.14 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa15.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.15 in Father tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RFa2.SelectedValue == "1")
                {
                    if (TFa2.Text == "" || TFa2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (RFa9.SelectedValue == "1")
                {
                    if (TFa9.Text == "" || TFa9.Text == null)
                    {
                        lblmsg.Text = "Questions No.9 Remarks in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (RFa10.SelectedValue == "1")
                {
                    if (TFa10.Text == "" || TFa10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in Father tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            if (!(RMr1.SelectedValue == "" && RMr2.SelectedValue == "" && RMr3.SelectedValue == "" && RMr4.SelectedValue == "" && RMr5.SelectedValue == "" && RMr6.SelectedValue == "" && RMr7.SelectedValue == "" && RMr8.SelectedValue == "" && RMr9.SelectedValue == "" && RMr10.SelectedValue == "" && RMr11.SelectedValue == "" && RMr12.SelectedValue == "" && RMr13.SelectedValue == "" && RMr14.SelectedValue == "" && RMr15.SelectedValue == "") || (RMr1.SelectedValue != "" && RMr2.SelectedValue != "" && RMr3.SelectedValue != "" && RMr4.SelectedValue != "" && RMr5.SelectedValue != "" && RMr6.SelectedValue != "" && RMr7.SelectedValue != "" && RMr8.SelectedValue != "" && RMr9.SelectedValue != "" && RMr10.SelectedValue != "" && RMr11.SelectedValue != "" && RMr12.SelectedValue != "" && RMr13.SelectedValue != "" && RMr14.SelectedValue != "" && RMr15.SelectedValue != ""))
            {
                if (RMr1.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.1 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr2.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.2 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (RMr3.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.3 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr4.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.4 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr5.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.5 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr6.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.6 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr7.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.7 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr8.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.8 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr9.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.9 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr10.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.10 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr11.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.11 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr12.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.12 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr13.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.13 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr14.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.14 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr15.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.15 in Mother tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RMr2.SelectedValue == "1")
                {
                    if (TMr2.Text == "" || TMr2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Mother tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (RMr9.SelectedValue == "1")
                {
                    if (TMr9.Text == "" || TMr9.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Mother tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (RMr10.SelectedValue == "1")
                {
                    if (TMr10.Text == "" || TMr10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in Mother tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            if (!(RWf1.SelectedValue == "" && RWf2.SelectedValue == "" && RWf3.SelectedValue == "" && RWf4.SelectedValue == "" && RWf5.SelectedValue == "" && RWf6.SelectedValue == "" && RWf7.SelectedValue == "" && RWf8.SelectedValue == "" && RWf9.SelectedValue == "" && RWf10.SelectedValue == "" && RWf11.SelectedValue == "" && RWf12.SelectedValue == "" && RWf13.SelectedValue == "" && RWf14.SelectedValue == "" && RWf15.SelectedValue == "") || (RWf1.SelectedValue != "" && RWf2.SelectedValue != "" && RWf3.SelectedValue != "" && RWf4.SelectedValue != "" && RWf5.SelectedValue != "" && RWf6.SelectedValue != "" && RWf7.SelectedValue != "" && RWf8.SelectedValue != "" && RWf9.SelectedValue != "" && RWf10.SelectedValue != "" && RWf11.SelectedValue != "" && RWf12.SelectedValue != "" && RWf13.SelectedValue != "" && RWf14.SelectedValue != "" && RWf15.SelectedValue != ""))
            {
                if (RWf1.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.1 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf2.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.2 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (RWf3.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.3 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf4.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.4 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf5.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.5 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf6.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.6 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf7.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.7 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf8.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.8 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf9.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.9 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf10.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.10 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf11.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.11 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf12.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.12 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf13.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.13 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf14.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.14 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf15.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.15 in Wife tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (RWf2.SelectedValue == "1")
                {
                    if (TWf2.Text == "" || TWf2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in Wife tab is mandatory."; ;
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (RWf9.SelectedValue == "1")
                {
                    if (TWf9.Text == "" || TWf9.Text == null)
                    {
                        lblmsg.Text = "Questions No.9 Remarks in Wife tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (RWf10.SelectedValue == "1")
                {
                    if (TWf10.Text == "" || TWf10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in Wife tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            if (!(Rch1.SelectedValue == "" && Rch2.SelectedValue == "" && Rch3.SelectedValue == "" && Rch4.SelectedValue == "" && Rch5.SelectedValue == "" && Rch6.SelectedValue == "" && Rch7.SelectedValue == "" && Rch8.SelectedValue == "" && Rch9.SelectedValue == "" && Rch10.SelectedValue == "" && Rch11.SelectedValue == "" && Rch12.SelectedValue == "" && Rch13.SelectedValue == "" && Rch14.SelectedValue == "" && Rch15.SelectedValue == "") || (Rch1.SelectedValue != "" && Rch2.SelectedValue != "" && Rch3.SelectedValue != "" && Rch4.SelectedValue != "" && Rch5.SelectedValue != "" && Rch6.SelectedValue != "" && Rch7.SelectedValue != "" && Rch8.SelectedValue != "" && Rch9.SelectedValue != "" && Rch10.SelectedValue != "" && Rch11.SelectedValue != "" && Rch12.SelectedValue != "" && Rch13.SelectedValue != "" && Rch14.SelectedValue != "" && Rch15.SelectedValue != ""))
            {
                if (Rch1.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.1 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch2.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.2 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Rch3.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.3 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch4.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.4 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch5.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.5 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch6.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.6 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch7.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.7 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch8.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.8 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch9.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.9 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch10.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.10 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch11.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.11 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch12.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.12 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch13.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.13 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch14.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.14 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rch15.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.15 in child-1 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Rch2.SelectedValue == "1")
                {
                    if (Tch2.Text == "" || Tch2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in child-1 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (Rch9.SelectedValue == "1")
                {
                    if (Tch9.Text == "" || Tch9.Text == null)
                    {
                        lblmsg.Text = "Questions No.9 Remarks in child-1 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (Rch10.SelectedValue == "1")
                {
                    if (Tch10.Text == "" || Tch10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in child-1 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            if (!(Rchi1.SelectedValue == "" && Rchi2.SelectedValue == "" && Rchi3.SelectedValue == "" && Rchi4.SelectedValue == "" && Rchi5.SelectedValue == "" && Rchi6.SelectedValue == "" && Rchi7.SelectedValue == "" && Rchi8.SelectedValue == "" && Rchi9.SelectedValue == "" && Rchi10.SelectedValue == "" && Rchi11.SelectedValue == "" && Rchi12.SelectedValue == "" && Rchi13.SelectedValue == "" && Rchi14.SelectedValue == "" && Rchi15.SelectedValue == "") || (Rchi1.SelectedValue != "" && Rchi2.SelectedValue != "" && Rchi3.SelectedValue != "" && Rchi4.SelectedValue != "" && Rchi5.SelectedValue != "" && Rchi6.SelectedValue != "" && Rchi7.SelectedValue != "" && Rchi8.SelectedValue != "" && Rchi9.SelectedValue != "" && Rchi10.SelectedValue != "" && Rchi11.SelectedValue != "" && Rchi12.SelectedValue != "" && Rchi13.SelectedValue != "" && Rchi14.SelectedValue != "" && Rchi15.SelectedValue != ""))
            {
                if (Rchi1.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.1 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi2.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.2 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Rchi3.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.3 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi4.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.4 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi5.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.5 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi6.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.6 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi7.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.7 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi8.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.8 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi9.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.9 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi10.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.10 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi11.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.11 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi12.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.12 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi13.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.13 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi14.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.14 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi15.SelectedValue == "")
                {
                    lblmsg.Text = "Questions No.15 in child-2 tab is mandatory.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Rchi2.SelectedValue == "1")
                {
                    if (Tchi2.Text == "" || Tchi2.Text == null)
                    {
                        lblmsg.Text = "Questions No.2 Remarks in child-2 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (Rchi9.SelectedValue == "1")
                {
                    if (Tchi9.Text == "" || Tchi9.Text == null)
                    {
                        lblmsg.Text = "Questions No.9 Remarks in child-2 tab is mandatory.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                if (Rchi10.SelectedValue == "1")
                {
                    if (Tchi10.Text == "" || Tchi10.Text == null)
                    {
                        lblmsg.Text = "Questions No.10 Remarks in child-2 tab is mandatory.";
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
            dr1["UserCode"] = "CSPL123";
            dr1["Type"] = "P";
            dr1["Question"] = lblcough.Text;
            dr1["Answer"] = RPS1.SelectedValue;
            dr1["Remarks"] = TPS1.Text;
            dr1["CreatedBy"] = "CSPL123";
            dr1["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["UserCode"] = "CSPL123";
            dr2["Type"] = "P";
            dr2["Question"] = Label1.Text;
            dr2["Answer"] = RPS2.SelectedValue;
            dr2["Remarks"] = TPS2.Text;
            dr2["CreatedBy"] = "CSPL123";
            dr2["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3["UserCode"] = "CSPL123";
            dr3["Type"] = "P";
            dr3["Question"] = Label2.Text;
            dr3["Answer"] = RPS3.SelectedValue;
            dr3["Remarks"] = TPS3.Text;
            dr3["CreatedBy"] = "CSPL123";
            dr3["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr3);
            DataRow dr4 = dt.NewRow();
            dr4["UserCode"] = "CSPL123";
            dr4["Type"] = "P";
            dr4["Question"] = Label3.Text;
            dr4["Answer"] = RPS4.SelectedValue;
            dr4["Remarks"] = TPS4.Text;
            dr4["CreatedBy"] = "CSPL123";
            dr4["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr4);
            DataRow dr5 = dt.NewRow();
            dr5["UserCode"] = "CSPL123";
            dr5["Type"] = "P";
            dr5["Question"] = Label4.Text;
            dr5["Answer"] = RPS5.SelectedValue;
            dr5["Remarks"] = TPS5.Text;
            dr5["CreatedBy"] = "CSPL123";
            dr5["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr5);
            DataRow dr6 = dt.NewRow();
            dr6["UserCode"] = "CSPL123";
            dr6["Type"] = "P";
            dr6["Question"] = Label5.Text;
            dr6["Answer"] = RPS6.SelectedValue;
            dr6["Remarks"] = TPS6.Text;
            dr6["CreatedBy"] = "CSPL123";
            dr6["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr6);
            DataRow dr7 = dt.NewRow();
            dr7["UserCode"] = "CSPL123";
            dr7["Type"] = "P";
            dr7["Question"] = Label6.Text;
            dr7["Answer"] = RPS7.SelectedValue;
            dr7["Remarks"] = TPS7.Text;
            dr7["CreatedBy"] = "CSPL123";
            dr7["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr7);
            DataRow dr8 = dt.NewRow();
            dr8["UserCode"] = "CSPL123";
            dr8["Type"] = "P";
            dr8["Question"] = Label7.Text;
            dr8["Answer"] = RPS8.SelectedValue;
            dr8["Remarks"] = TPS8.Text;
            dr8["CreatedBy"] = "CSPL123";
            dr8["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr8);
            DataRow dr9 = dt.NewRow();
            dr9["UserCode"] = "CSPL123";
            dr9["Type"] = "P";
            dr9["Question"] = Label8.Text;
            dr9["Answer"] = RPS9.SelectedValue;
            dr9["Remarks"] = TPS9.Text;
            dr9["CreatedBy"] = "CSPL123";
            dr9["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr9);
            DataRow dr10 = dt.NewRow();
            dr10["UserCode"] = "CSPL123";
            dr10["Type"] = "P";
            dr10["Question"] = Label9.Text;
            dr10["Answer"] = RPS10.SelectedValue;
            dr10["Remarks"] = TPS10.Text;
            dr10["CreatedBy"] = "CSPL123";
            dr10["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr10);
            DataRow dr11 = dt.NewRow();
            dr11["UserCode"] = "CSPL123";
            dr11["Type"] = "P";
            dr11["Question"] = Label10.Text;
            dr11["Answer"] = RPS11.SelectedValue;
            dr11["Remarks"] = TPS11.Text;
            dr11["CreatedBy"] = "CSPL123";
            dr11["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr11);
            DataRow dr12 = dt.NewRow();
            dr12["UserCode"] = "CSPL123";
            dr12["Type"] = "P";
            dr12["Question"] = Label11.Text;
            dr12["Answer"] = RPS12.SelectedValue;
            dr12["Remarks"] = TPS12.Text;
            dr12["CreatedBy"] = "CSPL123";
            dr12["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr12);
            DataRow dr13 = dt.NewRow();
            dr13["UserCode"] = "CSPL123";
            dr13["Type"] = "P";
            dr13["Question"] = Label12.Text;
            dr13["Answer"] = RPS13.SelectedValue;
            dr13["Remarks"] = TPS13.Text;
            dr13["CreatedBy"] = "CSPL123";
            dr13["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr13);
            DataRow dr14 = dt.NewRow();
            dr14["UserCode"] = "CSPL123";
            dr14["Type"] = "P";
            dr14["Question"] = Label13.Text;
            dr14["Answer"] = RPS14.SelectedValue;
            dr14["Remarks"] = TPS14.Text;
            dr14["CreatedBy"] = "CSPL123";
            dr14["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr14);
            DataRow dr15 = dt.NewRow();
            dr15["UserCode"] = "CSPL123";
            dr15["Type"] = "P";
            dr15["Question"] = Label14.Text;
            dr15["Answer"] = RPS15.SelectedValue;
            dr15["Remarks"] = TPS15.Text;
            dr15["CreatedBy"] = "CSPL123";
            dr15["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr15);

            DataRow dr16 = dt.NewRow();
            dr16["UserCode"] = "CSPL123";
            dr16["Type"] = "F";
            dr16["Question"] = Label15.Text;
            dr16["Answer"] = RFa1.SelectedValue;
            dr16["Remarks"] = TFa1.Text;
            dr16["CreatedBy"] = "CSPL123";
            dr16["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr16);
            DataRow dr17 = dt.NewRow();
            dr17["UserCode"] = "CSPL123";
            dr17["Type"] = "F";
            dr17["Question"] = Label16.Text;
            dr17["Answer"] = RFa2.SelectedValue;
            dr17["Remarks"] = TFa2.Text;
            dr17["CreatedBy"] = "CSPL123";
            dr17["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr17);
            DataRow dr18 = dt.NewRow();
            dr18["UserCode"] = "CSPL123";
            dr18["Type"] = "F";
            dr18["Question"] = Label17.Text;
            dr18["Answer"] = RFa3.SelectedValue;
            dr18["Remarks"] = TFa3.Text;
            dr18["CreatedBy"] = "CSPL123";
            dr18["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr18);
            DataRow dr19 = dt.NewRow();
            dr19["UserCode"] = "CSPL123";
            dr19["Type"] = "F";
            dr19["Question"] = Label18.Text;
            dr19["Answer"] = RFa4.SelectedValue;
            dr19["Remarks"] = TFa4.Text;
            dr19["CreatedBy"] = "CSPL123";
            dr19["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr19);
            DataRow dr20 = dt.NewRow();
            dr20["UserCode"] = "CSPL123";
            dr20["Type"] = "F";
            dr20["Question"] = Label19.Text;
            dr20["Answer"] = RFa5.SelectedValue;
            dr20["Remarks"] = TFa5.Text;
            dr20["CreatedBy"] = "CSPL123";
            dr20["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr20);
            DataRow dr21 = dt.NewRow();
            dr21["UserCode"] = "CSPL123";
            dr21["Type"] = "F";
            dr21["Question"] = Label20.Text;
            dr21["Answer"] = RFa6.SelectedValue;
            dr21["Remarks"] = TFa6.Text;
            dr21["CreatedBy"] = "CSPL123";
            dr21["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr21);
            DataRow dr22 = dt.NewRow();
            dr22["UserCode"] = "CSPL123";
            dr22["Type"] = "F";
            dr22["Question"] = Label21.Text;
            dr22["Answer"] = RFa7.SelectedValue;
            dr22["Remarks"] = TFa7.Text;
            dr22["CreatedBy"] = "CSPL123";
            dr22["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr22);
            DataRow dr23 = dt.NewRow();
            dr23["UserCode"] = "CSPL123";
            dr23["Type"] = "F";
            dr23["Question"] = Label22.Text;
            dr23["Answer"] = RFa8.SelectedValue;
            dr23["Remarks"] = TFa8.Text;
            dr23["CreatedBy"] = "CSPL123";
            dr23["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr23);
            DataRow dr24 = dt.NewRow();
            dr24["UserCode"] = "CSPL123";
            dr24["Type"] = "F";
            dr24["Question"] = Label23.Text;
            dr24["Answer"] = RFa9.SelectedValue;
            dr24["Remarks"] = TFa9.Text;
            dr24["CreatedBy"] = "CSPL123";
            dr24["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr24);
            DataRow dr25 = dt.NewRow();
            dr25["UserCode"] = "CSPL123";
            dr25["Type"] = "F";
            dr25["Question"] = Label24.Text;
            dr25["Answer"] = RFa10.SelectedValue;
            dr25["Remarks"] = TFa10.Text;
            dr25["CreatedBy"] = "CSPL123";
            dr25["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr25);
            DataRow dr26 = dt.NewRow();
            dr26["UserCode"] = "CSPL123";
            dr26["Type"] = "F";
            dr26["Question"] = Label25.Text;
            dr26["Answer"] = RFa11.SelectedValue;
            dr26["Remarks"] = TFa11.Text;
            dr26["CreatedBy"] = "CSPL123";
            dr26["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr26);
            DataRow dr27 = dt.NewRow();
            dr27["UserCode"] = "CSPL123";
            dr27["Type"] = "F";
            dr27["Question"] = Label26.Text;
            dr27["Answer"] = RFa12.SelectedValue;
            dr27["Remarks"] = TFa12.Text;
            dr27["CreatedBy"] = "CSPL123";
            dr27["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr27);
            DataRow dr28 = dt.NewRow();
            dr28["UserCode"] = "CSPL123";
            dr28["Type"] = "F";
            dr28["Question"] = Label27.Text;
            dr28["Answer"] = RFa13.SelectedValue;
            dr28["Remarks"] = TFa13.Text;
            dr28["CreatedBy"] = "CSPL123";
            dr28["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr28);
            DataRow dr29 = dt.NewRow();
            dr29["UserCode"] = "CSPL123";
            dr29["Type"] = "F";
            dr29["Question"] = Label28.Text;
            dr29["Answer"] = RFa14.SelectedValue;
            dr29["Remarks"] = TFa14.Text;
            dr29["CreatedBy"] = "CSPL123";
            dr29["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr29);
            DataRow dr30 = dt.NewRow();
            dr30["UserCode"] = "CSPL123";
            dr30["Type"] = "F";
            dr30["Question"] = Label29.Text;
            dr30["Answer"] = RFa15.SelectedValue;
            dr30["Remarks"] = TFa15.Text;
            dr30["CreatedBy"] = "CSPL123";
            dr30["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr30);

            DataRow dr31 = dt.NewRow();
            dr31["UserCode"] = "CSPL123";
            dr31["Type"] = "M";
            dr31["Question"] = Label30.Text;
            dr31["Answer"] = RMr1.SelectedValue;
            dr31["Remarks"] = TMr1.Text;
            dr31["CreatedBy"] = "CSPL123";
            dr31["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr31);
            DataRow dr32 = dt.NewRow();
            dr32["UserCode"] = "CSPL123";
            dr32["Type"] = "M";
            dr32["Question"] = Label31.Text;
            dr32["Answer"] = RMr2.SelectedValue;
            dr32["Remarks"] = TMr2.Text;
            dr32["CreatedBy"] = "CSPL123";
            dr32["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr32);
            DataRow dr33 = dt.NewRow();
            dr33["UserCode"] = "CSPL123";
            dr33["Type"] = "M";
            dr33["Question"] = Label32.Text;
            dr33["Answer"] = RMr3.SelectedValue;
            dr33["Remarks"] = TMr3.Text;
            dr33["CreatedBy"] = "CSPL123";
            dr33["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr33);
            DataRow dr34 = dt.NewRow();
            dr34["UserCode"] = "CSPL123";
            dr34["Type"] = "M";
            dr34["Question"] = Label33.Text;
            dr34["Answer"] = RMr4.SelectedValue;
            dr34["Remarks"] = TMr4.Text;
            dr34["CreatedBy"] = "CSPL123";
            dr34["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr34);
            DataRow dr35 = dt.NewRow();
            dr35["UserCode"] = "CSPL123";
            dr35["Type"] = "M";
            dr35["Question"] = Label34.Text;
            dr35["Answer"] = RMr5.SelectedValue;
            dr35["Remarks"] = TMr5.Text;
            dr35["CreatedBy"] = "CSPL123";
            dr35["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr35);
            DataRow dr36 = dt.NewRow();
            dr36["UserCode"] = "CSPL123";
            dr36["Type"] = "M";
            dr36["Question"] = Label35.Text;
            dr36["Answer"] = RMr6.SelectedValue;
            dr36["Remarks"] = TMr6.Text;
            dr36["CreatedBy"] = "CSPL123";
            dr36["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr36);
            DataRow dr37 = dt.NewRow();
            dr37["UserCode"] = "CSPL123";
            dr37["Type"] = "M";
            dr37["Question"] = Label36.Text;
            dr37["Answer"] = RMr7.SelectedValue;
            dr37["Remarks"] = TMr7.Text;
            dr37["CreatedBy"] = "CSPL123";
            dr37["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr37);
            DataRow dr38 = dt.NewRow();
            dr38["UserCode"] = "CSPL123";
            dr38["Type"] = "M";
            dr38["Question"] = Label37.Text;
            dr38["Answer"] = RMr8.SelectedValue;
            dr38["Remarks"] = TMr8.Text;
            dr38["CreatedBy"] = "CSPL123";
            dr38["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr38);
            DataRow dr39 = dt.NewRow();
            dr39["UserCode"] = "CSPL123";
            dr39["Type"] = "M";
            dr39["Question"] = Label38.Text;
            dr39["Answer"] = RMr9.SelectedValue;
            dr39["Remarks"] = TMr9.Text;
            dr39["CreatedBy"] = "CSPL123";
            dr39["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr39);
            DataRow dr40 = dt.NewRow();
            dr40["UserCode"] = "CSPL123";
            dr40["Type"] = "M";
            dr40["Question"] = Label39.Text;
            dr40["Answer"] = RMr10.SelectedValue;
            dr40["Remarks"] = TMr10.Text;
            dr40["CreatedBy"] = "CSPL123";
            dr40["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr40);
            DataRow dr41 = dt.NewRow();
            dr41["UserCode"] = "CSPL123";
            dr41["Type"] = "M";
            dr41["Question"] = Label40.Text;
            dr41["Answer"] = RMr11.SelectedValue;
            dr41["Remarks"] = TMr11.Text;
            dr41["CreatedBy"] = "CSPL123";
            dr41["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr41);
            DataRow dr42 = dt.NewRow();
            dr42["UserCode"] = "CSPL123";
            dr42["Type"] = "M";
            dr42["Question"] = Label41.Text;
            dr42["Answer"] = RMr12.SelectedValue;
            dr42["Remarks"] = TMr12.Text;
            dr42["CreatedBy"] = "CSPL123";
            dr42["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr42);
            DataRow dr43 = dt.NewRow();
            dr43["UserCode"] = "CSPL123";
            dr43["Type"] = "M";
            dr43["Question"] = Label42.Text;
            dr43["Answer"] = RMr13.SelectedValue;
            dr43["Remarks"] = TMr13.Text;
            dr43["CreatedBy"] = "CSPL123";
            dr43["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr43);
            DataRow dr44 = dt.NewRow();
            dr44["UserCode"] = "CSPL123";
            dr44["Type"] = "M";
            dr44["Question"] = Label43.Text;
            dr44["Answer"] = RMr14.SelectedValue;
            dr44["Remarks"] = TMr14.Text;
            dr44["CreatedBy"] = "CSPL123";
            dr44["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr44);
            DataRow dr45 = dt.NewRow();
            dr45["UserCode"] = "CSPL123";
            dr45["Type"] = "M";
            dr45["Question"] = Label44.Text;
            dr45["Answer"] = RMr15.SelectedValue;
            dr45["Remarks"] = TMr15.Text;
            dr45["CreatedBy"] = "CSPL123";
            dr45["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr45);

            DataRow dr46 = dt.NewRow();
            dr46["UserCode"] = "CSPL123";
            dr46["Type"] = "W";
            dr46["Question"] = Label45.Text;
            dr46["Answer"] = RWf1.SelectedValue;
            dr46["Remarks"] = TWf1.Text;
            dr46["CreatedBy"] = "CSPL123";
            dr46["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr46);
            DataRow dr47 = dt.NewRow();
            dr47["UserCode"] = "CSPL123";
            dr47["Type"] = "W";
            dr47["Question"] = Label46.Text;
            dr47["Answer"] = RWf2.SelectedValue;
            dr47["Remarks"] = TWf2.Text;
            dr47["CreatedBy"] = "CSPL123";
            dr47["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr47);
            DataRow dr48 = dt.NewRow();
            dr48["UserCode"] = "CSPL123";
            dr48["Type"] = "W";
            dr48["Question"] = Label47.Text;
            dr48["Answer"] = RWf3.SelectedValue;
            dr48["Remarks"] = TWf3.Text;
            dr48["CreatedBy"] = "CSPL123";
            dr48["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr48);
            DataRow dr49 = dt.NewRow();
            dr49["UserCode"] = "CSPL123";
            dr49["Type"] = "W";
            dr49["Question"] = Label48.Text;
            dr49["Answer"] = RWf4.SelectedValue;
            dr49["Remarks"] = TWf4.Text;
            dr49["CreatedBy"] = "CSPL123";
            dr49["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr49);
            DataRow dr50 = dt.NewRow();
            dr50["UserCode"] = "CSPL123";
            dr50["Type"] = "W";
            dr50["Question"] = Label49.Text;
            dr50["Answer"] = RWf5.SelectedValue;
            dr50["Remarks"] = TWf5.Text;
            dr50["CreatedBy"] = "CSPL123";
            dr50["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr50);
            DataRow dr51 = dt.NewRow();
            dr51["UserCode"] = "CSPL123";
            dr51["Type"] = "W";
            dr51["Question"] = Label50.Text;
            dr51["Answer"] = RWf6.SelectedValue;
            dr51["Remarks"] = TWf6.Text;
            dr51["CreatedBy"] = "CSPL123";
            dr51["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr51);
            DataRow dr52 = dt.NewRow();
            dr52["UserCode"] = "CSPL123";
            dr52["Type"] = "W";
            dr52["Question"] = Label51.Text;
            dr52["Answer"] = RWf7.SelectedValue;
            dr52["Remarks"] = TWf7.Text;
            dr52["CreatedBy"] = "CSPL123";
            dr52["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr52);
            DataRow dr53 = dt.NewRow();
            dr53["UserCode"] = "CSPL123";
            dr53["Type"] = "W";
            dr53["Question"] = Label52.Text;
            dr53["Answer"] = RWf8.SelectedValue;
            dr53["Remarks"] = TWf8.Text;
            dr53["CreatedBy"] = "CSPL123";
            dr53["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr53);
            DataRow dr54 = dt.NewRow();
            dr54["UserCode"] = "CSPL123";
            dr54["Type"] = "W";
            dr54["Question"] = Label53.Text;
            dr54["Answer"] = RWf9.SelectedValue;
            dr54["Remarks"] = TWf9.Text;
            dr54["CreatedBy"] = "CSPL123";
            dr54["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr54);
            DataRow dr55 = dt.NewRow();
            dr55["UserCode"] = "CSPL123";
            dr55["Type"] = "W";
            dr55["Question"] = Label54.Text;
            dr55["Answer"] = RWf10.SelectedValue;
            dr55["Remarks"] = TWf10.Text;
            dr55["CreatedBy"] = "CSPL123";
            dr55["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr55);
            DataRow dr56 = dt.NewRow();
            dr56["UserCode"] = "CSPL123";
            dr56["Type"] = "W";
            dr56["Question"] = Label55.Text;
            dr56["Answer"] = RWf11.SelectedValue;
            dr56["Remarks"] = TWf11.Text;
            dr56["CreatedBy"] = "CSPL123";
            dr56["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr56);
            DataRow dr57 = dt.NewRow();
            dr57["UserCode"] = "CSPL123";
            dr57["Type"] = "W";
            dr57["Question"] = Label56.Text;
            dr57["Answer"] = RWf12.SelectedValue;
            dr57["Remarks"] = TWf12.Text;
            dr57["CreatedBy"] = "CSPL123";
            dr57["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr57);
            DataRow dr58 = dt.NewRow();
            dr58["UserCode"] = "CSPL123";
            dr58["Type"] = "W";
            dr58["Question"] = Label57.Text;
            dr58["Answer"] = RWf13.SelectedValue;
            dr58["Remarks"] = TWf13.Text;
            dr58["CreatedBy"] = "CSPL123";
            dr58["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr58);
            DataRow dr59 = dt.NewRow();
            dr59["UserCode"] = "CSPL123";
            dr59["Type"] = "W";
            dr59["Question"] = Label58.Text;
            dr59["Answer"] = RWf14.SelectedValue;
            dr59["Remarks"] = TWf14.Text;
            dr59["CreatedBy"] = "CSPL123";
            dr59["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr59);
            DataRow dr60 = dt.NewRow();
            dr60["UserCode"] = "CSPL123";
            dr60["Type"] = "W";
            dr60["Question"] = Label59.Text;
            dr60["Answer"] = RWf15.SelectedValue;
            dr60["Remarks"] = TWf15.Text;
            dr60["CreatedBy"] = "CSPL123";
            dr60["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr60);

            DataRow dr61 = dt.NewRow();
            dr61["UserCode"] = "CSPL123";
            dr61["Type"] = "C1";
            dr61["Question"] = Label60.Text;
            dr61["Answer"] = Rch1.SelectedValue;
            dr61["Remarks"] = Tch1.Text;
            dr61["CreatedBy"] = "CSPL123";
            dr61["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr61);
            DataRow dr62 = dt.NewRow();
            dr62["UserCode"] = "CSPL123";
            dr62["Type"] = "C1";
            dr62["Question"] = Label61.Text;
            dr62["Answer"] = Rch2.SelectedValue;
            dr62["Remarks"] = Tch2.Text;
            dr62["CreatedBy"] = "CSPL123";
            dr62["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr62);
            DataRow dr63 = dt.NewRow();
            dr63["UserCode"] = "CSPL123";
            dr63["Type"] = "C1";
            dr63["Question"] = Label62.Text;
            dr63["Answer"] = Rch3.SelectedValue;
            dr63["Remarks"] = Tch3.Text;
            dr63["CreatedBy"] = "CSPL123";
            dr63["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr63);
            DataRow dr64 = dt.NewRow();
            dr64["UserCode"] = "CSPL123";
            dr64["Type"] = "C1";
            dr64["Question"] = Label63.Text;
            dr64["Answer"] = Rch4.SelectedValue;
            dr64["Remarks"] = Tch4.Text;
            dr64["CreatedBy"] = "CSPL123";
            dr64["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr64);
            DataRow dr65 = dt.NewRow();
            dr65["UserCode"] = "CSPL123";
            dr65["Type"] = "C1";
            dr65["Question"] = Label64.Text;
            dr65["Answer"] = Rch5.SelectedValue;
            dr65["Remarks"] = Tch5.Text;
            dr65["CreatedBy"] = "CSPL123";
            dr65["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr65);
            DataRow dr66 = dt.NewRow();
            dr66["UserCode"] = "CSPL123";
            dr66["Type"] = "C1";
            dr66["Question"] = Label65.Text;
            dr66["Answer"] = Rch6.SelectedValue;
            dr66["Remarks"] = Tch6.Text;
            dr66["CreatedBy"] = "CSPL123";
            dr66["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr66);
            DataRow dr67 = dt.NewRow();
            dr67["UserCode"] = "CSPL123";
            dr67["Type"] = "C1";
            dr67["Question"] = Label66.Text;
            dr67["Answer"] = Rch7.SelectedValue;
            dr67["Remarks"] = Tch7.Text;
            dr67["CreatedBy"] = "CSPL123";
            dr67["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr67);
            DataRow dr68 = dt.NewRow();
            dr68["UserCode"] = "CSPL123";
            dr68["Type"] = "C1";
            dr68["Question"] = Label67.Text;
            dr68["Answer"] = Rch8.SelectedValue;
            dr68["Remarks"] = Tch8.Text;
            dr68["CreatedBy"] = "CSPL123";
            dr68["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr68);
            DataRow dr69 = dt.NewRow();
            dr69["UserCode"] = "CSPL123";
            dr69["Type"] = "C1";
            dr69["Question"] = Label68.Text;
            dr69["Answer"] = Rch9.SelectedValue;
            dr69["Remarks"] = Tch9.Text;
            dr69["CreatedBy"] = "CSPL123";
            dr69["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr69);
            DataRow dr70 = dt.NewRow();
            dr70["UserCode"] = "CSPL123";
            dr70["Type"] = "C1";
            dr70["Question"] = Label69.Text;
            dr70["Answer"] = Rch10.SelectedValue;
            dr70["Remarks"] = Tch10.Text;
            dr70["CreatedBy"] = "CSPL123";
            dr70["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr70);
            DataRow dr71 = dt.NewRow();
            dr71["UserCode"] = "CSPL123";
            dr71["Type"] = "C1";
            dr71["Question"] = Label70.Text;
            dr71["Answer"] = Rch11.SelectedValue;
            dr71["Remarks"] = Tch11.Text;
            dr71["CreatedBy"] = "CSPL123";
            dr71["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr71);
            DataRow dr72 = dt.NewRow();
            dr72["UserCode"] = "CSPL123";
            dr72["Type"] = "C1";
            dr72["Question"] = Label71.Text;
            dr72["Answer"] = Rch12.SelectedValue;
            dr72["Remarks"] = Tch12.Text;
            dr72["CreatedBy"] = "CSPL123";
            dr72["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr72);
            DataRow dr73 = dt.NewRow();
            dr73["UserCode"] = "CSPL123";
            dr73["Type"] = "C1";
            dr73["Question"] = Label72.Text;
            dr73["Answer"] = Rch13.SelectedValue;
            dr73["Remarks"] = Tch13.Text;
            dr73["CreatedBy"] = "CSPL123";
            dr73["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr73);
            DataRow dr74 = dt.NewRow();
            dr74["UserCode"] = "CSPL123";
            dr74["Type"] = "C1";
            dr74["Question"] = Label73.Text;
            dr74["Answer"] = Rch14.SelectedValue;
            dr74["Remarks"] = Tch14.Text;
            dr74["CreatedBy"] = "CSPL123";
            dr74["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr74);
            DataRow dr75 = dt.NewRow();
            dr75["UserCode"] = "CSPL123";
            dr75["Type"] = "C1";
            dr75["Question"] = Label74.Text;
            dr75["Answer"] = Rch15.SelectedValue;
            dr75["Remarks"] = Tch15.Text;
            dr75["CreatedBy"] = "CSPL123";
            dr75["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr75);

            DataRow dr76 = dt.NewRow();
            dr76["UserCode"] = "CSPL123";
            dr76["Type"] = "C2";
            dr76["Question"] = Label75.Text;
            dr76["Answer"] = Rchi1.SelectedValue;
            dr76["Remarks"] = Tchi1.Text;
            dr76["CreatedBy"] = "CSPL123";
            dr76["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr76);
            DataRow dr77 = dt.NewRow();
            dr77["UserCode"] = "CSPL123";
            dr77["Type"] = "C2";
            dr77["Question"] = Label76.Text;
            dr77["Answer"] = Rchi2.SelectedValue;
            dr77["Remarks"] = Tchi2.Text;
            dr77["CreatedBy"] = "CSPL123";
            dr77["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr77);
            DataRow dr78 = dt.NewRow();
            dr78["UserCode"] = "CSPL123";
            dr78["Type"] = "C2";
            dr78["Question"] = Label77.Text;
            dr78["Answer"] = Rchi3.SelectedValue;
            dr78["Remarks"] = Tchi3.Text;
            dr78["CreatedBy"] = "CSPL123";
            dr78["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr78);
            DataRow dr79 = dt.NewRow();
            dr79["UserCode"] = "CSPL123";
            dr79["Type"] = "C2";
            dr79["Question"] = Label78.Text;
            dr79["Answer"] = Rchi4.SelectedValue;
            dr79["Remarks"] = Tchi4.Text;
            dr79["CreatedBy"] = "CSPL123";
            dr79["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr79);
            DataRow dr80 = dt.NewRow();
            dr80["UserCode"] = "CSPL123";
            dr80["Type"] = "C2";
            dr80["Question"] = Label79.Text;
            dr80["Answer"] = Rchi5.SelectedValue;
            dr80["Remarks"] = Tchi5.Text;
            dr80["CreatedBy"] = "CSPL123";
            dr80["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr80);
            DataRow dr81 = dt.NewRow();
            dr81["UserCode"] = "CSPL123";
            dr81["Type"] = "C2";
            dr81["Question"] = Label80.Text;
            dr81["Answer"] = Rchi6.SelectedValue;
            dr81["Remarks"] = Tchi6.Text;
            dr81["CreatedBy"] = "CSPL123";
            dr81["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr81);
            DataRow dr82 = dt.NewRow();
            dr82["UserCode"] = "CSPL123";
            dr82["Type"] = "C2";
            dr82["Question"] = Label81.Text;
            dr82["Answer"] = Rchi7.SelectedValue;
            dr82["Remarks"] = Tchi7.Text;
            dr82["CreatedBy"] = "CSPL123";
            dr82["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr82);
            DataRow dr83 = dt.NewRow();
            dr83["UserCode"] = "CSPL123";
            dr83["Type"] = "C2";
            dr83["Question"] = Label82.Text;
            dr83["Answer"] = Rchi8.SelectedValue;
            dr83["Remarks"] = Tchi8.Text;
            dr83["CreatedBy"] = "CSPL123";
            dr83["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr83);
            DataRow dr84 = dt.NewRow();
            dr84["UserCode"] = "CSPL123";
            dr84["Type"] = "C2";
            dr84["Question"] = Label83.Text;
            dr84["Answer"] = Rchi9.SelectedValue;
            dr84["Remarks"] = Tchi9.Text;
            dr84["CreatedBy"] = "CSPL123";
            dr84["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr84);
            DataRow dr85 = dt.NewRow();
            dr85["UserCode"] = "CSPL123";
            dr85["Type"] = "C2";
            dr85["Question"] = Label84.Text;
            dr85["Answer"] = Rchi10.SelectedValue;
            dr85["Remarks"] = Tchi10.Text;
            dr85["CreatedBy"] = "CSPL123";
            dr85["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr85);
            DataRow dr86 = dt.NewRow();
            dr86["UserCode"] = "CSPL123";
            dr86["Type"] = "C2";
            dr86["Question"] = Label85.Text;
            dr86["Answer"] = Rchi11.SelectedValue;
            dr86["Remarks"] = Tchi11.Text;
            dr86["CreatedBy"] = "CSPL123";
            dr86["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr86);
            DataRow dr87 = dt.NewRow();
            dr87["UserCode"] = "CSPL123";
            dr87["Type"] = "C2";
            dr87["Question"] = Label86.Text;
            dr87["Answer"] = Rchi12.SelectedValue;
            dr87["Remarks"] = Tchi12.Text;
            dr87["CreatedBy"] = "CSPL123";
            dr87["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr87);
            DataRow dr88 = dt.NewRow();
            dr88["UserCode"] = "CSPL123";
            dr88["Type"] = "C2";
            dr88["Question"] = Label87.Text;
            dr88["Answer"] = Rchi13.SelectedValue;
            dr88["Remarks"] = Tchi13.Text;
            dr88["CreatedBy"] = "CSPL123";
            dr88["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr88);
            DataRow dr89 = dt.NewRow();
            dr89["UserCode"] = "CSPL123";
            dr89["Type"] = "C2";
            dr89["Question"] = Label88.Text;
            dr89["Answer"] = Rchi14.SelectedValue;
            dr89["Remarks"] = Tchi14.Text;
            dr89["CreatedBy"] = "CSPL123";
            dr89["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr89);
            DataRow dr90 = dt.NewRow();
            dr90["UserCode"] = "CSPL123";
            dr90["Type"] = "C2";
            dr90["Question"] = Label89.Text;
            dr90["Answer"] = Rchi15.SelectedValue;
            dr90["Remarks"] = Tchi15.Text;
            dr90["CreatedBy"] = "CSPL123";
            dr90["UpdatedBy"] = "CSPL123";
            dt.Rows.Add(dr90);

            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("Insert_Covid_User_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Dt", dt);
            con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                lblmsg.Text = "Record Saved Succesfully.!!";
                lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            }
            con.Close();
        }       
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }        
    }
   
    protected void btnview_Click(string btnName, string date)
    {
        try
        {
            rblBlank();
            string Code = btnName;
            string dte = date;
            GetEmpHeader(Code);
            FillFormonLink(Code, dte);
            //GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            PnlGrid.Visible = false;
            PnlFrom.Visible = true;
            btnSave.Enabled = false;
            RPS1.Enabled = false;
            RPS2.Enabled = false;
            RPS3.Enabled = false;
            RPS4.Enabled = false;
            RPS5.Enabled = false;
            RPS6.Enabled = false;
            RPS7.Enabled = false;
            RPS8.Enabled = false;
            RPS9.Enabled = false;
            RPS10.Enabled = false;
            RPS11.Enabled = false;
            RPS12.Enabled = false;
            RPS13.Enabled = false;
            RPS14.Enabled = false;
            RPS15.Enabled = false;
            TPS1.Enabled = false;
            TPS2.Enabled = false;
            TPS3.Enabled = false;
            TPS4.Enabled = false;
            TPS5.Enabled = false;
            TPS6.Enabled = false;
            TPS7.Enabled = false;
            TPS8.Enabled = false;
            TPS9.Enabled = false;
            TPS10.Enabled = false;
            TPS11.Enabled = false;
            TPS12.Enabled = false;
            TPS13.Enabled = false;
            TPS14.Enabled = false;
            TPS15.Enabled = false;

            RFa1.Enabled = false;
            RFa2.Enabled = false;
            RFa3.Enabled = false;
            RFa4.Enabled = false;
            RFa5.Enabled = false;
            RFa6.Enabled = false;
            RFa7.Enabled = false;
            RFa8.Enabled = false;
            RFa9.Enabled = false;
            RFa10.Enabled = false;
            RFa11.Enabled = false;
            RFa12.Enabled = false;
            RFa13.Enabled = false;
            RFa14.Enabled = false;
            RFa15.Enabled = false;
            TFa1.Enabled = false;
            TFa2.Enabled = false;
            TFa3.Enabled = false;
            TFa4.Enabled = false;
            TFa5.Enabled = false;
            TFa6.Enabled = false;
            TFa7.Enabled = false;
            TFa8.Enabled = false;
            TFa9.Enabled = false;
            TFa10.Enabled = false;
            TFa11.Enabled = false;
            TFa12.Enabled = false;
            TFa13.Enabled = false;
            TFa14.Enabled = false;
            TFa15.Enabled = false;

            RMr1.Enabled = false;
            RMr2.Enabled = false;
            RMr3.Enabled = false;
            RMr4.Enabled = false;
            RMr5.Enabled = false;
            RMr6.Enabled = false;
            RMr7.Enabled = false;
            RMr8.Enabled = false;
            RMr9.Enabled = false;
            RMr10.Enabled = false;
            RMr11.Enabled = false;
            RMr12.Enabled = false;
            RMr13.Enabled = false;
            RMr14.Enabled = false;
            RMr15.Enabled = false;
            TMr1.Enabled = false;
            TMr2.Enabled = false;
            TMr3.Enabled = false;
            TMr4.Enabled = false;
            TMr5.Enabled = false;
            TMr6.Enabled = false;
            TMr7.Enabled = false;
            TMr8.Enabled = false;
            TMr9.Enabled = false;
            TMr10.Enabled = false;
            TMr11.Enabled = false;
            TMr12.Enabled = false;
            TMr13.Enabled = false;
            TMr14.Enabled = false;
            TMr15.Enabled = false;

            RWf1.Enabled = false;
            RWf2.Enabled = false;
            RWf3.Enabled = false;
            RWf4.Enabled = false;
            RWf5.Enabled = false;
            RWf6.Enabled = false;
            RWf7.Enabled = false;
            RWf8.Enabled = false;
            RWf9.Enabled = false;
            RWf10.Enabled = false;
            RWf11.Enabled = false;
            RWf12.Enabled = false;
            RWf13.Enabled = false;
            RWf14.Enabled = false;
            RWf15.Enabled = false;
            TWf1.Enabled = false;
            TWf2.Enabled = false;
            TWf3.Enabled = false;
            TWf4.Enabled = false;
            TWf5.Enabled = false;
            TWf6.Enabled = false;
            TWf7.Enabled = false;
            TWf8.Enabled = false;
            TWf9.Enabled = false;
            TWf10.Enabled = false;
            TWf11.Enabled = false;
            TWf12.Enabled = false;
            TWf13.Enabled = false;
            TWf14.Enabled = false;
            TWf15.Enabled = false;

            Rch1.Enabled = false;
            Rch2.Enabled = false;
            Rch3.Enabled = false;
            Rch4.Enabled = false;
            Rch5.Enabled = false;
            Rch6.Enabled = false;
            Rch7.Enabled = false;
            Rch8.Enabled = false;
            Rch9.Enabled = false;
            Rch10.Enabled = false;
            Rch11.Enabled = false;
            Rch12.Enabled = false;
            Rch13.Enabled = false;
            Rch14.Enabled = false;
            Rch15.Enabled = false;
            Tch1.Enabled = false;
            Tch2.Enabled = false;
            Tch3.Enabled = false;
            Tch4.Enabled = false;
            Tch5.Enabled = false;
            Tch6.Enabled = false;
            Tch7.Enabled = false;
            Tch8.Enabled = false;
            Tch9.Enabled = false;
            Tch10.Enabled = false;
            Tch11.Enabled = false;
            Tch12.Enabled = false;
            Tch13.Enabled = false;
            Tch14.Enabled = false;
            Tch15.Enabled = false;

            Rchi1.Enabled = false;
            Rchi2.Enabled = false;
            Rchi3.Enabled = false;
            Rchi4.Enabled = false;
            Rchi5.Enabled = false;
            Rchi6.Enabled = false;
            Rchi7.Enabled = false;
            Rchi8.Enabled = false;
            Rchi9.Enabled = false;
            Rchi10.Enabled = false;
            Rchi11.Enabled = false;
            Rchi12.Enabled = false;
            Rchi13.Enabled = false;
            Rchi14.Enabled = false;
            Rchi15.Enabled = false;
            Tchi1.Enabled = false;
            Tchi2.Enabled = false;
            Tchi3.Enabled = false;
            Tchi4.Enabled = false;
            Tchi5.Enabled = false;
            Tchi6.Enabled = false;
            Tchi7.Enabled = false;
            Tchi8.Enabled = false;
            Tchi9.Enabled = false;
            Tchi10.Enabled = false;
            Tchi11.Enabled = false;
            Tchi12.Enabled = false;
            Tchi13.Enabled = false;
            Tchi14.Enabled = false;
            Tchi15.Enabled = false;

           

        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        try
        {
            PnlGrid.Visible = true;
            PnlFrom.Visible = false;
            
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
        SqlConnection con = new SqlConnection(connetionString);
        SqlCommand cmd = new SqlCommand("SP_GetCovidUserDetails", con);//Get_Covid_User_Details
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Mode", "Get");
        cmd.Parameters.AddWithValue("@UserCode", Session["UserId"].ToString());
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        con.Open();
        //sda.Fill(ds);
        sda.Fill(FGds);
        if (FGds.Tables[0].Rows.Count > 0)
        {
            btnSave.Text = "Update";
            GrCovid.DataSource = FGds;
            GrCovid.DataBind();
            GrCovid.DataSource = null;

        }       

        con.Close();
        // FGds = null;
       }       
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }      
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    private void FillFormonLink(string x,string d)
    {
        try
        {                     
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("SP_GetCovidUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "Search");
            cmd.Parameters.AddWithValue("@UserCode", x);
            cmd.Parameters.AddWithValue("@Date", d);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);                                  
            con.Open();                                
            sda.Fill(FGds);
            con.Close();
            FillForm();
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
        int a=  FGds.Tables[1].Rows.Count / 15;
        if (a == 0)
            return;
        string Tname = null,Rname=null,Type = null;
        TextBox T = new TextBox();
        RadioButtonList R = new RadioButtonList();
        for (int i = 1; i <= a; i++)
        {
            Type= FGds.Tables[1].Rows[(i - 1) * 15 + 1].ItemArray[2].ToString();
           if (Type== "P")
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
                Tname1 = Tname1 + (j+1).ToString();
                Rname1 = Rname1 + (j+1).ToString();
                T= (TextBox)PnlFrom.FindControl(Tname1);
                R = (RadioButtonList)PnlFrom.FindControl(Rname1);
                R.SelectedValue = FGds.Tables[1].Rows[(i - 1) * 15 + j].ItemArray[0].ToString();
                T.Text = FGds.Tables[1].Rows[(i - 1) * 15 + j].ItemArray[1].ToString();
            }
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
        string UserCode = UtilityUI.GetEmpCode(txtEmployee.Text.Trim());
        SqlConnection con = new SqlConnection(connetionString);
        SqlCommand cmd = new SqlCommand("SP_GetCovidUserDetails", con);  // SqlCommand cmd = new SqlCommand("Get_Covid_User_Details", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Mode", "Search");
        cmd.Parameters.AddWithValue("@UserCode", UserCode);
        cmd.Parameters.AddWithValue("@Date", txtSearchDate.Text.Trim());
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        con.Open();
        sda.Fill(ds);
        //sda.Fill(FGds);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
            
            GrCovid.DataSource = ds;
            GrCovid.DataBind();
            
        //}
        //else
        //{
        //    lblmsg.Text = "No Data found.";
        //    lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
        //}
        con.Close();
        }       
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }      
    }
    protected void btnResetSearch_Click(object sender, EventArgs e)
    {
        txtEmployee.Text = "";txtSearchDate.Text = "";
        BindGrid();
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
    public void GetEmpHeader(string EmpCode)
    {
        try
        {
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
            lblDsgntin.Text =dt.Rows[0]["Designation"].ToString();
            lblDptmt.Text = dt.Rows[0]["Department"].ToString();
            con.Close();           
        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
    protected void GrCovid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                string temp = e.CommandArgument.ToString();
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GrCovid.Rows[rowIndex];
                string name = (row.FindControl("btnview") as LinkButton).Text;
                string fillFormDate = row.Cells[12].Text;
                btnview_Click(name, fillFormDate);              
            }

        }
        catch (Exception ex)
        {
            UtilityUI.ShowAlert(this, "w", ex.Message);
        }
    }
    public void rblBlank()
    {
        Rchi1.ClearSelection();
        RFa1.ClearSelection(); RFa2.ClearSelection(); RFa3.ClearSelection(); RFa4.ClearSelection(); RFa5.ClearSelection(); RFa6.ClearSelection(); RFa7.ClearSelection(); RFa8.ClearSelection(); RFa9.ClearSelection(); RFa10.ClearSelection(); RFa11.ClearSelection(); RFa12.ClearSelection(); RFa13.ClearSelection(); RFa14.ClearSelection(); RFa15.ClearSelection();
        RMr1.ClearSelection(); RMr2.ClearSelection(); RMr3.ClearSelection(); RMr4.ClearSelection(); RMr5.ClearSelection(); RMr6.ClearSelection(); RMr7.ClearSelection(); RMr8.ClearSelection(); RMr9.ClearSelection(); RMr10.ClearSelection(); RMr11.ClearSelection(); RMr12.ClearSelection(); RMr13.ClearSelection(); RMr14.ClearSelection(); RMr15.ClearSelection();
        RWf1.ClearSelection(); RWf2.ClearSelection(); RWf3.ClearSelection(); RWf4.ClearSelection(); RWf5.ClearSelection(); RWf6.ClearSelection(); RWf7.ClearSelection(); RWf8.ClearSelection(); RWf9.ClearSelection(); RWf10.ClearSelection(); RWf11.ClearSelection(); RWf12.ClearSelection(); RWf13.ClearSelection(); RWf14.ClearSelection(); RWf15.ClearSelection();
        Rch1.ClearSelection(); Rch2.ClearSelection(); Rch3.ClearSelection(); Rch4.ClearSelection(); Rch5.ClearSelection(); Rch6.ClearSelection(); Rch7.ClearSelection(); Rch8.ClearSelection(); Rch9.ClearSelection(); Rch10.ClearSelection(); Rch11.ClearSelection(); Rch12.ClearSelection(); Rch13.ClearSelection(); Rch14.ClearSelection(); Rch15.ClearSelection();
        Rchi1.ClearSelection(); Rchi2.ClearSelection(); Rchi3.ClearSelection(); Rchi4.ClearSelection(); Rchi5.ClearSelection(); Rchi6.ClearSelection(); Rchi7.ClearSelection(); Rchi8.ClearSelection(); Rchi9.ClearSelection(); Rchi10.ClearSelection(); Rchi11.ClearSelection(); Rchi12.ClearSelection(); Rchi13.ClearSelection(); Rchi14.ClearSelection(); Rchi15.ClearSelection();
    }


}