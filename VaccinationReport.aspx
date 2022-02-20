<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="VaccinationReport.aspx.cs" Inherits="VaccinationReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControls" Namespace="AjaxControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
<h1 class="AdProHead"> <i class="fa fa-calendar faa-pulse animated"></i> Vaccination Report</h1>
</section>
    <div class="clearfix"></div>
    <section class="content">
    <%--<asp:UpdatePanel  ID="UpdPnl" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
        <ContentTemplate>
    --%>        <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                <div class="form-horizontal" >
                    <div class="box-body" >
                        <div class="form-group">
                           
                            <div class="col-md-6">
                                <label class="control-label">Employee</label>
                                <div id="listPlacement" class="gradientBoxesWithOuterShadows" ></div>
                                <asp:TextBox ID="txtemployeename" runat="server" CssClass="form-control" placeholder="Employee Name or Code" />
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtemployeename" ServiceMethod="GetEmployeeNameAndEmpCode"
                                        ServicePath="~/GetEmployeeDetails.asmx" MinimumPrefixLength="1" CompletionInterval="1"
                                        CompletionSetCount="1000" EnableCaching="false" Enabled="true"
                                         CompletionListElementID="listPlacement" CompletionListItemCssClass="ListItemCssClass" CompletionListHighlightedItemCssClass="ListHighlightedItemCssClass" CompletionListCssClass="ListCssClass">
                                    </cc1:AutoCompleteExtender>
                            </div>
                        </div>
                        <div class="btn-group pull-right">
                            <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSearch_Click">
                                    <i class="fa fa-search text-white faa-wrench animated" ></i> Search
                            </asp:LinkButton>
                           <%-- <asp:LinkButton ID="btnViewAll" runat="server"  CssClass="btn btn-primary faa-parent animated-hover"  onclick="btnViewAll_Click">
                                    <i class="fa fa-eye text-white faa-pulse animated"></i> View All
                            </asp:LinkButton>--%>
                            <asp:LinkButton ID="btnExport" runat="server"  CssClass="btn btn-primary faa-parent animated-hover"  onclick="btnExport_Click">
                                    <i class="fa fa-file-excel-o text-white faa-passing animated"></i> Export To Excel
                                </asp:LinkButton>
                        </div>
                        <div class="table table-responsive">
                            <asp:GridView ID="gvrpt" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive" AllowPaging="false"
                                          DataKeyNames="id,EmpCode" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No Record Found" OnPageIndexChanging="gvTimeSheet_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo."> 
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="id" HeaderText="id" />--%>
                    <asp:BoundField DataField="EmpCode" HeaderText="Employee Code" />
                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                    <%--<asp:BoundField DataField="Relation" HeaderText="Relation" />--%>
                    <asp:BoundField DataField="Dose Status" HeaderText="Dose Status" />
                    <asp:BoundField DataField="Dose" HeaderText="Dose" />
                    <asp:BoundField DataField="Entry On" HeaderText="Entry On" />
                    <asp:BoundField DataField="Updated On" HeaderText="Updated On" />
                    <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                                <asp:LinkButton ID="lnkView" runat="server" CssClass="btn btn-warning" onclick="lnkView_Click" >
                                <i class="fa fa-eye" ></i>
                                View
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>   
                                </Columns> 
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>


            <center>
         <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender1" TargetControlID="lblpopupEMI" DropShadow="true" 
                    PopupControlID="DivEMI" RepositionMode="RepositionOnWindowScroll" CancelControlID="BtnHideEMI" PopupDragHandleControlID="divEMIHandler" Drag="true">
        </cc1:ModalPopupExtender>
        <label id="lblpopupEMI" runat="server" style="display:none"></label>

         <div id="DivEMI" runat="Server" style="display: none; width:1100px;height:500px;background-color:#ffffff;margin-left:200px; ">
           <div id="divEMIHandler"></div>
            <div style="background-color:#808080;">
                    <asp:Button ID="BtnHideEMI" runat="server" Text="Close" Width="100%" CssClass="btn btn-success"></asp:Button>
                </div>
            <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80); width:100%;height:100%; overflow-y:scroll;">
            <div class="form-horizontal" >
            <div class="box-body" >
                    <div class="table table-responsive">
                        <asp:GridView ID="gridchild" runat="server" OnRowDataBound="gridchild_RowDataBound" AutoGenerateColumns="false" CssClass="table table-responsive"  
                            CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="id,Empcode">
                              <Columns>
                                    <asp:TemplateField HeaderText="SNo."> 
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                    <asp:BoundField DataField="EmpCode" HeaderText="Employee Code" />
                                   <asp:TemplateField HeaderText="Applicable">
                                      <ItemTemplate>
                                  <asp:CheckBox ID="chkapplcbl" Visible="true" runat="server" Enabled="false" Checked='<%# Bind("Applicable")%>'></asp:CheckBox>      
                                      </ItemTemplate>
                                  </asp:TemplateField>
                    <asp:BoundField DataField="Relation" HeaderText="Relation" />
                    <asp:BoundField DataField="vaccine" HeaderText="Name Of Vaccine" />
                                  <asp:TemplateField HeaderText="Dose 1">
                                      <ItemTemplate>
                                  <asp:CheckBox ID="chkdose1" Visible="true" runat="server" Enabled="false" Checked='<%# Bind("Dose1")%>'></asp:CheckBox>      
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  
                                  <asp:BoundField DataField="Dose1date" HeaderText="Dose1date" />

                                  <asp:TemplateField HeaderText="Dose 2">
                                      <ItemTemplate>
                                  <asp:CheckBox ID="chkdose2" Visible="true" runat="server" Enabled="false" Checked='<%# Bind("Dose2")%>'></asp:CheckBox>      
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:BoundField DataField="Dose2date" HeaderText="Dose2date" />
                                  <asp:BoundField DataField="FileName" Visible="false" HeaderText="FileName" />
                                   
                                  <asp:TemplateField>
                                      <ItemTemplate>
                                        <asp:Label ID="ldlfilename" Visible="false" runat="server" Text='<%# Bind("FileName")%>'></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                    <asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderText="Certificate Download">
                        <ItemTemplate>
                                <asp:LinkButton ID="lnkdownload" runat="server" CssClass="btn btn-warning" onclick="lnkdownload_Click" >
                                <i class="fa fa-download" ></i>
                                Download
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>   
                                </Columns> 
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                      <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                      <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                      <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                      <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                        </div>
                </div>
            </div>
            </div>
         </div>
    </center>

            <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</section>
</asp:Content>

