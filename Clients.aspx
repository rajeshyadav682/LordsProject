<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="Clients.aspx.cs" Inherits="Clients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="content-header">
    <h1 class="AdProHead"> <i class="fa fa-search faa-burst animated"></i> Find Clients </h1>
</section>
<div class="clearfix"></div>
<section class="content">
<asp:UpdatePanel  ID="u1" runat="server" UpdateMode="Conditional">
<Triggers>
    <asp:PostBackTrigger ControlID="btnExport" />
</Triggers>
<ContentTemplate>
    <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
        <div class="form-horizontal" >
            <div class="box-body" >
                <div class="form-group">
                    <div class="col-md-2">
                        <asp:LinkButton ID="btnAdd" runat="server"  CssClass=" btn btn-info faa-parent animated-hover" onclick="btnAdd_Click">
                            <i class="fa fa-user text-white faa-burst" ></i>
                                Add Client
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-3">
                        <label class="control-label">Name</label>
                            <div id="listPlacement"  class="gradientBoxesWithOuterShadows" ></div>
                        <asp:TextBox ID="txtSearchEmpName" runat="server" CssClass="form-control" placeholder="Type Name"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="At1" runat="server" TargetControlID="txtSearchEmpName" ServiceMethod="GetALLEmployee"
                            ServicePath="~/GetEmployeeDetails.asmx" MinimumPrefixLength="1" CompletionInterval="1"
                            CompletionSetCount="1000" EnableCaching="false" Enabled="true" CompletionListElementID="listPlacement" CompletionListItemCssClass="ListItemCssClass" CompletionListHighlightedItemCssClass="ListHighlightedItemCssClass" CompletionListCssClass="ListCssClass">
                        </cc1:AutoCompleteExtender>
                            <%--       FirstRowSelected="false"  
                     DelimiterCharacters=","  
                 ShowOnlyCurrentWordInCompletionListItem="true"  --%>
                    </div>                               
                    <div class="col-md-2">
                        <label class="control-label">Date Of Joining</label>
                        <asp:TextBox ID="txtSearchDOJ" runat="server" CssClass="form-control" placeholder="Date of joining"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd-MMM-yyyy" TargetControlID="txtSearchDOJ">
                        </cc1:CalendarExtender>
                    </div>                    
                </div>
                <div class="btn-group pull-right">
                    <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSearch_Click">
                        <i class="fa fa-search text-white faa-wrench animated" ></i>
                        Search
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnViewAll" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnViewAll_Click">
                        <i class="fa fa-eye text-white faa-pulse animated" ></i>
                        View All
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnExport" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnExport_Click">
                        <i class="fa fa-file-excel-o text-white faa-passing animated" ></i>
                        Export To Excel
                    </asp:LinkButton>
                </div>
                <div class="table table-responsive">
                    <asp:GridView ID="gvFindEmployee" runat="server" AutoGenerateColumns="False" DataKeyNames="ClientCode, Name, DateOfJoining, IsActive, navEditEmployee, navPayElement" CssClass="table table-responsive" 
                            AllowPaging="false" AllowSorting="True" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridEmployee_RowDataBound"
                            OnPageIndexChanging="gvFindEmployee_PageIndexChanging" EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="User Name" SortExpression="username" />
                        <asp:BoundField DataField="ClientCode" HeaderText="Client Code" SortExpression="ClientCode" />
                        <%--<asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px" ItemStyle-Wrap="true"  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href="CreateEmployee.aspx?Edit=<%#Eval("EmpCode")%>" target="_blank" style="color:#0b48f3"> <%#Eval("EmpName")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px" ItemStyle-Wrap="true"  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href="<%#Eval("navEditEmployee")%>" target="_blank" style="color:#0b48f3"> <%#Eval("Name")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="DateOfJoining" HeaderText="DOJ" SortExpression="DateOfJoining" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No" SortExpression="ContactNo" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CssClass=" btn btn-success faa-parent animated-hover" onclick="lnkEdit_Click"  >
                                    <i class="fa fa-edit text-white faa-flash " ></i>
                                    Edit
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkpay" runat="server"  CssClass=" btn btn-info faa-parent animated-hover" onclick="lnkpay_Click"  >
                                    <i class="fa fa-money text-white faa-flash " ></i>
                                    Payment Status
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
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
</ContentTemplate>
</asp:UpdatePanel>
</section>
<center>
<cc1:ModalUpdateProgress ID="ModalUpdateProgress1" runat="server" DisplayAfter="0" BackgroundCssClass="modal" AssociatedUpdatePanelID="u1">
    <ProgressTemplate>
        <asp:Image ID="Image1" alt="" ImageUrl="~/images/progressbar1.gif" runat="server" ImageAlign="Middle" />
    </ProgressTemplate>
</cc1:ModalUpdateProgress>
</center> 

</asp:Content>
