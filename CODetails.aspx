<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="CODetails.aspx.cs" Inherits="CODetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
    <h1 class="AdProHead"> <i class="fa fa-file-text faa-pulse animated"></i>
            Comp Off Details
    </h1>
</section>
<div class="clearfix"></div>
<asp:UpdatePanel ID="upd" runat="server">
<Triggers>
    <asp:PostBackTrigger ControlID="btnExport"/>
</Triggers>
    <ContentTemplate>
        <section class="content">
            <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
            <div class="form-horizontal" >
            <div class="box-body" >
                <div class="form-group">
                   <div class="col-md-4">
                       <label class="control-label">Employee</label>
                       <div id="listPlacementadd" class="gradientBoxesWithOuterShadows" ></div>
                         <asp:TextBox ID="txtSEmployee" runat="server" CssClass="form-control" placeholder="Type Employee Name"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSEmployee" ServiceMethod="GetEmployeeNameAndEmpCode"
                            ServicePath="~/GetEmployeeDetails.asmx" MinimumPrefixLength="1" CompletionInterval="1"
                            CompletionSetCount="1000" EnableCaching="false" Enabled="true" CompletionListElementID="listPlacementadd" CompletionListItemCssClass="ListItemCssClass" CompletionListHighlightedItemCssClass="ListHighlightedItemCssClass" CompletionListCssClass="ListCssClass">
                        </cc1:AutoCompleteExtender>
                      </div>
                    <div class="col-md-2">
                        <label class="control-label">From Date</label>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" placeholder="From Date" MaxLength="15"></asp:TextBox>
                        <cc1:calendarextender id="Calendarextender1" targetcontrolid="txtFromDate" format="dd/MMM/yyyy" runat="server"  enabled="True"></cc1:calendarextender>
                    </div>
                    <div class="col-md-2">
                        <label class="control-label">To Date</label>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" placeholder="To Date" MaxLength="15"></asp:TextBox>
                        <cc1:calendarextender id="Calendarextender2" targetcontrolid="txtToDate" format="dd/MMM/yyyy" runat="server"  enabled="True"></cc1:calendarextender>
                    </div>
                    <div class="col-md-2">
                        <label class="control-label">Status</label>
                        <asp:DropDownList ID="ddlSStatus" runat="server" CssClass="form-control">
                            <asp:ListItem>ALL</asp:ListItem>
                            <asp:ListItem>PENDING</asp:ListItem>
                            <asp:ListItem>APPROVED</asp:ListItem>
                            <asp:ListItem>REJECTED</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="btn-group pull-right">

                        <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSearch_Click">
                            <i class="fa fa-search text-white faa-wrench animated" ></i>
                            Search
                        </asp:LinkButton>

                         <asp:LinkButton ID="btnViewAll" runat="server"  CssClass="btn btn-primary faa-parent animated-hover"  onclick="btnViewAll_Click">
                            <i class="fa fa-eye text-white faa-pulse animated"></i>
                            View All
                        </asp:LinkButton>

                        <asp:LinkButton ID="btnExport" runat="server"  CssClass="btn btn-primary faa-parent animated-hover"  onclick="btnExport_Click">
                            <i class="fa fa-file-excel-o text-white faa-passing animated"></i>
                            Export To Excel
                        </asp:LinkButton>
                        
                        <asp:LinkButton ID="btnPrint" runat="server"  CssClass="btn btn-primary faa-parent animated-hover"  onclick="btnPrint_Click">
                                <i class="fa fa-print text-white faa-passing animated"></i>
                                Print
                            </asp:LinkButton>

                    </div>
                <div class="table table-responsive">
                    <asp:GridView ID="gvCODetails" runat="server" CssClass="table table-responsive" AllowPaging="false" PageSize="5" AllowSorting="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <%--<asp:BoundField DataField="EmpCode" HeaderText="Code" SortExpression="EmpCode" />
                                <asp:BoundField DataField="Name" HeaderText="Emp Name" SortExpression="Name" />
                                <asp:BoundField DataField="BranchName" HeaderText="Branch Name" SortExpression="BranchName" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"/>
                                <asp:BoundField DataField="TimeIn" HeaderText="TimeIn" SortExpression="TimeIn" />
                                <asp:BoundField DataField="timeout" HeaderText="TimeOut" SortExpression="timeout"/>
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remark"/>
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status"/>--%>
                                <%--<asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server"  CssClass=" btn btn-success faa-parent animated-hover" onclick="lnkEdit_Click">
                                        <i class="fa fa-edit text-white faa-flash " ></i>
                                        Edit
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
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
        </section>
    </ContentTemplate>
</asp:UpdatePanel>
<center>
<cc1:ModalUpdateProgress ID="ModalUpdateProgress1" runat="server" DisplayAfter="0" BackgroundCssClass="modal" AssociatedUpdatePanelID="upd">
    <ProgressTemplate>
        <asp:Image ID="Image1" alt="" ImageUrl="~/images/progressbar1.gif" runat="server" ImageAlign="Middle" />
    </ProgressTemplate>
</cc1:ModalUpdateProgress>
</center>
</asp:Content>