<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="CostCenter.aspx.cs" Inherits="CostCenter" %>
<%@ Register Assembly="AjaxControls" Namespace="AjaxControls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="content-header">
        <h1 class="AdProHead"> <i class="fa fa-connectdevelop faa-pulse animated"></i>
             Cost Center
        </h1>
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
                <div id="divView" runat="server">
                    <div class="form-group">
                        <div class="col-md-2">
                             <asp:LinkButton ID="btnAdd" runat="server"  CssClass=" btn btn-info faa-parent animated-hover" onclick="btnAdd_Click">
                                <i class="fa fa-plus text-white faa-burst" ></i>
                                 Add
                            </asp:LinkButton>
                           <%-- <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary"  
                                Width="70%" onclick="btnAdd_Click"  ></asp:Button>--%>
                        </div>
                    </div>
                    <hr />
                     <div class="form-group">
                    <div class="col-md-9">
                    <label class="col-md-2 control-label">Code</label>
                   <div class="col-md-3">
                   <asp:TextBox ID="txtSearchCatId" runat="server" CssClass=" form-control" placeholder="Code" ></asp:TextBox>
                      </div>
                    <label class="col-md-3 control-label">Description</label>
                   <div class="col-md-4">
              <asp:TextBox ID="txtSearchCatName" runat="server" CssClass=" form-control" placeholder="Description" ></asp:TextBox>
                     </div>
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

                        <asp:LinkButton ID="btnExport" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnExport_Click">
                            <i class="fa fa-file-excel-o text-white faa-passing animated" ></i>
                            Export To Excel
                        </asp:LinkButton>

                      <%--  <asp:Button ID="btnSearch" runat="server" Text="Search" 
                            CssClass="btn btn-primary" onclick="btnSearch_Click"  ></asp:Button>
                        <asp:Button ID="btnViewAll" runat="server" Text="View All" 
                            CssClass="btn  btn-primary" onclick="btnViewAll_Click"   ></asp:Button>
                        <asp:LinkButton ID="btnExport" runat="server" Text="Export" 
                            CssClass="btn  btn-primary" OnClick="btnExport_Click"></asp:LinkButton>--%>
                    </div>
                    
                    <br /><br />
                    <div class="table table-responsive">
                         <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False" CssClass="table table-responsive" 
                    AllowPaging="false" AllowSorting="True" DataKeyNames="Code" PageSize="5" EmptyDataText="No Records Found" EmptyDataRowStyle-CssClass="AdProHead" EmptyDataRowStyle-Font-Size="Large"
                    CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvCategory_PageIndexChanging"  
                             >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                                 <asp:LinkButton ID="lnkEdit" runat="server"  CssClass=" btn btn-success faa-parent animated-hover" onclick="lnkEdit_Click"  >
                                 <i class="fa fa-edit text-white faa-flash " ></i>
                                    Edit
                                 </asp:LinkButton>

                                    <%--<asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-primary" onclick="lnkEdit_Click" 
                                        >
                                    <i class="fa fa-edit" ></i>
                                    Edit


                                </asp:LinkButton>--%>
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
               
               
               <div id="divSave" runat="server" visible="false">
                  <hr />
                  <div class="form-group">
                   <div class="col-md-6">
                        <label class="col-md-4 control-label">Code<span style="color:red">*</span></label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCatCode" runat="server" CssClass="form-control" placeholder="Code" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtCatCode" Display="Dynamic" ErrorMessage="Please Enter Code" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                        </div>
                  </div>
                   <div class="col-md-6">
                        <label class="col-md-4 control-label">Description<span style="color:red">*</span></label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCatName" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtCatName" Display="Dynamic" ErrorMessage="Please Enter Name" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                        </div>
                  </div>
                   <br /><br />
                  <div class="col-md-2 btn-group pull-right" >

                      <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSave_Click" ValidationGroup="a" >
                                 <i class="fa fa-save text-white faa-flash animated" ></i>
                                 Save
                      </asp:LinkButton>

                      <asp:LinkButton ID="btnBack" runat="server"  CssClass=" btn btn-warning faa-parent animated-hover" onclick="btnBack_Click" UseSubmitBehavior="false">
                                 <i class="fa fa-arrow-left text-white faa-passing-reverse animated" ></i>
                                 Back
                      </asp:LinkButton>

                       <%-- <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"  
                            Width="50%" onclick="btnSave_Click" ValidationGroup="a"  ></asp:Button>
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary"  
                            Width="50%" UseSubmitBehavior="false" onclick="btnBack_Click"  ></asp:Button>--%>
                  </div>
               </div> 
             </div>           
           </div>
         </div>
       </div>
    </ContentTemplate>
    </asp:UpdatePanel>
        <center>
        <cc1:ModalUpdateProgress ID="ModalUpdateProgress1" runat="server" DisplayAfter="0" BackgroundCssClass="modal"
            AssociatedUpdatePanelID="u1">
            <ProgressTemplate>
                <asp:Image ID="Image1" alt="" ImageUrl="~/images/progressbar1.gif" runat="server"
                    ImageAlign="Middle" />
            </ProgressTemplate>
        </cc1:ModalUpdateProgress>
    </center>
</section>
</asp:Content>