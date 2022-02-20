<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="COApplication.aspx.cs" Inherits="COApplication" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControls" Namespace="AjaxControls" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
    <h1 class="AdProHead"> <i class="fa fa-file-text faa-pulse animated"></i> CO Application </h1>
</section>
    <div class="clearfix"></div>
    <section class="content">    
    <asp:UpdatePanel  ID="u1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="box box-default box-body" style="background-color:rgba(255, 255, 255, 0.80);">
                <div class="form-horizontal" >
                    <div class="form-group">
                        <div class="col-md-6">
                            <label class="control-label">Employee Name</label>
                            <div id="listPlacementaddd" class="gradientBoxesWithOuterShadows" ></div>
                                <asp:TextBox ID="txtEmployee" runat="server" CssClass="form-control" placeholder="Type Employee Name or Code"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtEmployee" ServiceMethod="GetEmployeeNameAndEmpCode"
                                ServicePath="~/GetEmployeeDetails.asmx" MinimumPrefixLength="1" CompletionInterval="1"
                                CompletionSetCount="1000" EnableCaching="false" Enabled="true" CompletionListElementID="listPlacementaddd"  CompletionListItemCssClass="ListItemCssClass" CompletionListHighlightedItemCssClass="ListHighlightedItemCssClass" CompletionListCssClass="ListCssClass">
                            </cc1:AutoCompleteExtender>
                            </div>
                            <div class="col-md-2">
                                <label class="control-label">CODate</label>
                                <asp:TextBox ID="txtCoDate" runat="server" CssClass="form-control" placeholder="CO Date" onkeydown="return DateKeyDown();"></asp:TextBox>
                                <cc1:calendarextender ID="Calendarextender2" runat="server" Enabled="True" FirstDayOfWeek="Monday" Format="dd/MMM/yyyy" TargetControlID="txtCoDate">
                                </cc1:calendarextender>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Remarks</label>
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Remarks" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                            </div>
                    </div>
                    <div class="btn-group pull-right" >
                                  <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSave_Click"  Width="50%">
                                             <i class="fa fa-save text-white faa-flash animated" ></i>
                                             Save
                                  </asp:LinkButton>
                                  <asp:LinkButton ID="btnBack" runat="server"  CssClass=" btn btn-warning faa-parent animated-hover" onclick="btnBack_Click" UseSubmitBehavior="false" Width="50%">
                                             <i class="fa fa-arrow-left text-white faa-passing-reverse animated" ></i>
                                             Back
                                  </asp:LinkButton>
                            </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
 <center>
        <cc1:ModalUpdateProgress ID="ModalUpdateProgress1" runat="server" DisplayAfter="0" BackgroundCssClass="modal"
            AssociatedUpdatePanelID="u1">
            <ProgressTemplate>
                <asp:Image ID="Image1" alt="" ImageUrl="~/images/progressbar1.gif" runat="server"
                    ImageAlign="Middle" />
            </ProgressTemplate>
        </cc1:ModalUpdateProgress>
    </center>
</asp:Content>