<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="COVID19DelayReport.aspx.cs" Inherits="COVID19DelayReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <script type="text/javascript" language="javascript">
    function onCalendarShown(sender,args){
        sender._switchMode("years", true);
        if (sender.get_selectedDate()==null){
            sender.set_selectedDate("01/01/1980");
        }
    }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
<h1 class="AdProHead" style="text-align:center" ><i class="fa fa-money faa-pulse animated"></i>COVID-19 SELF HEALTH DECLARATION REPORT</h1>
</section>
    <div class="clearfix"></div>
    <div runat="server" align="center">
        <h5>For the health and safety of our staff members, declaration of illness is mandatory </h5>
        <h5>Be sure that the information you'll give is accurate and complete  </h5>
        <h5>Please get immediate medical attention if you have any of the COVID-19 signs</h5>
    </div>
    <section class="content">
<asp:UpdatePanel  ID="u1" runat="server" >  
    <ContentTemplate> 
        <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                    <div class="form-horizontal" >
                        <div class="box-body">
                                <div class="form-group">
                                   <div class="col-md-5">                                                                         
                                        <label class="control-label">Employee Code</label>
                                        <div id="listPlacementaddd" class="gradientBoxesWithOuterShadows"></div>
                                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="form-control" placeholder="Type Employee Code" AutoPostBack="true"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtEmployee" ServiceMethod="GetEmployeeFNFActive"
                                            ServicePath="~/GetEmployeeDetails.asmx" MinimumPrefixLength="1" CompletionInterval="1"
                                            CompletionSetCount="1000" EnableCaching="false" Enabled="true" CompletionListElementID="listPlacementaddd"  CompletionListItemCssClass="ListItemCssClass" CompletionListHighlightedItemCssClass="ListHighlightedItemCssClass" CompletionListCssClass="ListCssClass">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                     <div class="col-md-3">                                                                         
                                        <label class="control-label">Date</label>                                       
                                        <%--<asp:TextBox ID="TxtDate" runat="server" CssClass="form-control" Width="350px" placeholder="dd-MM-yyyy" AutoPostBack="true"></asp:TextBox> 
                                          <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtDate" Format="dd-MM-yyyy" Enabled="True" SelectedDate="<%#DateTime.Now %>" >  </cc1:CalendarExtender> --%>
                                         <asp:TextBox ID="TxtDate" runat="server" CssClass=" form-control" placeholder="Start date" ></asp:TextBox>
                               
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="TxtDate">
                                </cc1:CalendarExtender>
                                        <%-- <cc1:CalendarExtender ID="Calendar1" runat="server" Enabled="True" TargetControlID="TxtDate" Format="dd/MM/yyyy" ></cc1:CalendarExtender>   --%>                                   
                                    </div>                                                                 
                                </div> 
                                 <div>
                                 <asp:label ID="lblmsg" runat="server" Text="" CssClass="control-label" ></asp:label>
                                </div>                        
                                <div class="btn-group pull-right" >                                                                                                   
                                      <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSearch_Click">
                                                 <i class="fa fa-save text-white faa-flash animated" ></i>
                                                 Search
                                      </asp:LinkButton>  
                                     <%--<asp:LinkButton ID="LinkButton3" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnResetSearch_Click">
                                                 <i class="fa fa-save text-white faa-flash animated" ></i>
                                                Reset 
                                      </asp:LinkButton>    --%>                                                           
                                </div>                           
                            </div>
                        </div>
                    </div>  
             <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                    <div class="form-horizontal" >
                        <div class="box-body">
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="Div1" runat="server">
                                    <div class="table table-responsive divheight">
                                        <asp:GridView ID="GrCovid" AutoGenerateColumns="false" runat="server" CssClass="table table-responsive" CellPadding="60"
                                             ForeColor="#333333" GridLines="None" OnPageIndexChanging="GrCovid_PageIndexChanging" PageSize="15" AllowPaging="True">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                              <asp:TemplateField HeaderText="SNo" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                             <HeaderStyle CssClass="table_04" HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle CssClass="table_02" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>                                                 
                                                  <asp:BoundField DataField="UserCode" HeaderText="UserCode" />  
                                               <%-- <asp:TemplateField HeaderText="UserCode">
                                                <ItemTemplate>
                                                       <asp:LinkButton ID="btnview" Font-Bold="true" runat="server" CausesValidation="false" Text='<%# Eval("UserCode") %>' OnClick="btnview_Click"></asp:LinkButton>   
                                                </ItemTemplate>                   
                                            </asp:TemplateField> --%>
                                                  <asp:BoundField DataField="Formdate" HeaderText="LastForm_Filldate" />  
                                                  <asp:BoundField DataField="DelayDays" HeaderText="DelayDays" />
                                                                                                                               
                                            </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  CssClass="GVFixedHeader" />
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

