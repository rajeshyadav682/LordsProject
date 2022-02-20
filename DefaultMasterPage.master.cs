using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DefaultMasterPage : System.Web.UI.MasterPage
{
    protected void Page_InIt(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null || Session["UserName"].ToString() == "")
            {
                Response.Redirect("home.aspx");
                return;
            }
            if (!IsPostBack)
            {
              //  aHome.HRef = aDefault.HRef = Session["DefaultPage"].ToString();
                lbluser.Text = Session["Name"].ToString();
                lbluserName.Text = Session["Name"].ToString();
                string DateofJoining = Convert.ToString(Session["DateOfJoining"]);
                if (UtilityUI.IsValidDate(DateofJoining))
                {
                    lblDOJ.InnerText = "Member since " + DateofJoining.Substring(3, DateofJoining.Length - 3);
                }
                imgProffile2.ImageUrl = imgProffile.ImageUrl = "";
                createMenu();
                // Creating/Updating My Own Session and Application
               
            }
        }
        catch (Exception)
        {

        }
    }
    public void createMenu()
    {
        try
        {
            SqlCommand comd = DBM.GetCommandSP("sp_GetMenues");
            comd.Parameters.AddWithValue("@UserName", Session["UserName"].ToString());
            DataTable MenuTable = DBM.GetDataTable(comd);
            ViewState["MenuTable"] = MenuTable;
            string StrMenues = "";
            if (MenuTable.Rows.Count > 0)
            {
                StrMenues += "<aside class='hold-transition main-sidebar' >";
                StrMenues += "<section class='sidebar'>";
                StrMenues += "<ul class='sidebar-menu'>";
                foreach (DataRow drMenu in MenuTable.Select("PARENT_ID='Blank' and CreateMenu = 1"))
                {
                    DataRow[] drArraySubMenu = MenuTable.Select("PARENT_ID='" + drMenu["id"] + "' and CreateMenu = 1");
                    StrMenues += (drArraySubMenu.Length > 0 ? "<li class='treeview'>" : "<li >")+
                                    "<a href='" + drMenu["LINK"] + "' class='faa-parent animated-hover'>" +
                                        "<i class='" + drMenu["leftcss"] + "'></i> <span>" + drMenu["Menu_Name"] + "</span>" +
                                        (drArraySubMenu.Length > 0 ? "<span class='pull-right-container'><i class='" + drMenu["rightcss"] + "'></i></span>" : "") +
                                    "</a>";
                    StrMenues += (drArraySubMenu.Length > 0 ? "<ul class='treeview-menu'>" : "");
                    foreach (DataRow drSubMenu in drArraySubMenu)
                    {
                        DataRow[] drArraySubMenuLevelTwo = MenuTable.Select("PARENT_ID='" + drSubMenu["id"] + "' and CreateMenu = 1");
                            //"<li><a href='#'><i class='fa fa-circle-o'></i> Level One</a></li>" +
                        StrMenues += "<li>" +
                                         "<a href='" + drSubMenu["LINK"] + "'  class='faa-parent animated-hover'>" +
                                            "<i class='" + drSubMenu["leftcss"] + "'></i> " + drSubMenu["Menu_Name"] +
                                            (drArraySubMenuLevelTwo.Length > 0 ? "<span class='pull-right-container'><i class='" + drSubMenu["rightcss"] + "'></i></span>" : "") +
                                        "</a>";
                        StrMenues += (drArraySubMenuLevelTwo.Length > 0 ? "<ul class='treeview-menu'>" : "");
                        foreach (DataRow drSubMenuLevelTwo in drArraySubMenuLevelTwo)
                        {
                            StrMenues += "<li><a href='" + drSubMenuLevelTwo["LINK"] + "' class='faa-parent animated-hover'>" +
                                         "<i class='" + drSubMenuLevelTwo["leftcss"] + "'></i>" + drSubMenuLevelTwo["Menu_Name"] + "</a></li>";
                        }
                        StrMenues += (drArraySubMenuLevelTwo.Length > 0 ? "</ul></li>" : "</li>");    
                    }
                    StrMenues += (drArraySubMenu.Length > 0 ? "</ul></li>" : "</li>");
                }
                StrMenues += "</ul>";
                StrMenues += "</section>";
                StrMenues += "</aside>";

                divMenus.InnerHtml = StrMenues;

                string CurrentPageName = this.ContentPlaceHolder1.Page.GetType().Name.Replace("_aspx", ".aspx");
                if (MenuTable.Select("Link = '" + CurrentPageName + "'").Length == 0)
                {
                    Response.Redirect("AccessDenied.aspx", true);
                }
                else
                {
                    Session["AllUserAccess"] = MenuTable.Select("Link = '" + CurrentPageName + "'")[0]["AllUserAccess"];
                    Session["ReportName"] = MenuTable.Select("Link = '" + CurrentPageName + "'")[0]["ReportName"];
                    Session["ReportType"] = MenuTable.Select("Link = '" + CurrentPageName + "'")[0]["ReportType"];
                    bool ExportAccess = Convert.ToBoolean(MenuTable.Select("Link = '" + CurrentPageName + "'")[0]["ExportAccess"]);
                    bool PrintAccess = Convert.ToBoolean(MenuTable.Select("Link = '" + CurrentPageName + "'")[0]["PrintAccess"]);
                    LinkButton btnExport = (LinkButton)ContentPlaceHolder1.FindControl("btnExport");
                    LinkButton btnPrint = (LinkButton)ContentPlaceHolder1.FindControl("btnPrint");
                    if (btnExport != null)
                    {
                        btnExport.Visible = ExportAccess;
                    }
                    if (btnPrint != null)
                    {
                        btnPrint.Visible = PrintAccess;
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }
}
