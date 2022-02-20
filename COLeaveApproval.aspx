<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="COLeaveApproval.aspx.cs" Inherits="COLeaveApproval" %>
<%@ Register Assembly="AjaxControls" Namespace="AjaxControls" TagPrefix="cc1" %>
<%--<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<section class="content-header">
    <h1 class="AdProHead"> <i class="fa fa-calendar-times-o faa-pulse animated"></i>
            Compensatory off Approval
    </h1>
</section>
<div class="clearfix"></div>
<section class="content">
 <asp:UpdatePanel  ID="UpdPnl" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="box box-default box-body form-horizontal" style="background-color:rgba(255, 255, 255, 0.80);">
            <div class="table table-responsive">
                              <asp:GridView ID="gvCoLeave" runat="server" AutoGenerateColumns="False" CssClass="table table-responsive" CellPadding="4" DataKeyNames="SNo,ApprovedRejected"
                                  ForeColor="#333333" GridLines="None"
                                  EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large">
                                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                              <Columns>
                                 <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                <asp:BoundField DataField="EmpCode" HeaderText="Code" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="CODate" HeaderText="Date" />
                                  <asp:BoundField DataField="CODay" HeaderText="Day" />
                                  <asp:BoundField DataField="EmployeeRemarks" HeaderText="Employee Remarks" />
                                <asp:TemplateField HeaderText="Approve/Reject">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rdlist" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Approve" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Reject" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" runat="server" MaxLength="100" Placeholder="Remarks" Text='<%#Eval("Remarks")%>'></asp:TextBox>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                              </Columns>
                                  <EditRowStyle BackColor="#999999" />
                                  <EmptyDataRowStyle CssClass="AdProHead" Font-Size="Large" />
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
            <div class="col-md-1 btn-group pull-right" >
                       <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSave_Click" ValidationGroup="a">
                                 <i class="fa fa-save text-white faa-flash animated" ></i>
                                 Save
                      </asp:LinkButton>
                  </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
        <center>
        <cc1:ModalUpdateProgress ID="ModalUpdateProgress1" runat="server" DisplayAfter="0" BackgroundCssClass="modal"
            AssociatedUpdatePanelID="UpdPnl">
            <ProgressTemplate>
                <asp:Image ID="Image1" alt="" ImageUrl="~/images/progressbar1.gif" runat="server"
                    ImageAlign="Middle" />
            </ProgressTemplate>
        </cc1:ModalUpdateProgress>
    </center>
</asp:Content>

