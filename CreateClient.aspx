<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="CreateClient.aspx.cs" Inherits="CreateEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/jscript">
        function Confirm() {
            return confirm('Are you Sure !');
        }
        function pageLoad() {
            //Initialize Select2 Elements
            $(".select2").select2();
        }
    </script>
    <script language="javascript" type="text/javascript">
        function upper(ustr) {
            var str = ustr.value;
            ustr.value = str.toUpperCase();
        }
        function lower(ustr) {
            var str = ustr.value;
            ustr.value = str.toLowerCase();
        }
        function ActiveTab(thisId) {
            alert(thisId.id);
        }
    </script>
    <script type="text/javascript">
        function jsGeneralDetail() {
            document.getElementById("fnGeneralDetail").click();
            return false;
        }
        function jsPersonal() {
            document.getElementById("fnPersonal").click();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<section class="content-header">
        <h1 class="AdProHead"> <i class="fa fa-user faa-pulse animated"></i>
             Create Client
        </h1>
  </section>
<div class="clearfix"></div>
<section class="content">
<asp:UpdatePanel  ID="u1" runat="server" UpdateMode="Conditional">
<Triggers>
    <asp:PostBackTrigger ControlID="btnImgSubmit" />
</Triggers>
<ContentTemplate>
<div class="form-group">
    <div id="ShowEmpCode" runat="server" class="col-md-11" style="display:none;">
        <div class="col-md-2">
            <b>Code&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblclientcode" runat="server" class="control-label"></asp:Label></b>
        </div>
        <div class="col-md-5">
            <b>Name&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblClientName" runat="server" class="control-label" ></asp:Label></b>
        </div> 
        <div class="col-md-2" style="float:right">
            <asp:Button ID="btnPayelement" runat="server" Text="Payment Details" CssClass="btn btn-info" OnClick="btnPayelement_Click" />
        </div> 
    </div>      
</div> 
<%--<div id="CodePrefix" runat="server" class="form-group" style="display:none;">
    <div class="col-md-11">
        <div class="col-md-9" style="padding-left:40px">
            <asp:Panel ID="pnlcodeprifix" runat="server" ScrollBars="Auto"  Font-Bold="true">
                <asp:RadioButtonList ID ="rdbtnlistcode" runat="server" RepeatColumns="10"  RepeatDirection="Horizontal" Width="250px"></asp:RadioButtonList>
            </asp:Panel>
        </div>
    </div>
</div>--%>
<br /><hr />
<div>
<ul class="nav nav-tabs">
    <li class="nav active"><a id="fnGeneralDetail" href="#A" data-toggle="tab" >General&nbsp;Detail</a></li>
    <%--<li class="nav" ><a id="fnPersonal" href="#C" data-toggle="tab">Personal</a></li>--%>
    <asp:Panel ID="pnldiscount" runat="server" Visible="false">
        <b style="float:right;color:green;">Discount&nbsp;:&nbsp;&nbsp;<asp:Label ID="lbldiscount" runat="server" class="control-label"></asp:Label></b>
        <br />
        <b style="float:right;color:green;">Expire Date&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblexpiredate" runat="server" class="control-label"></asp:Label></b>
    </asp:Panel>
</ul>
<div class="tab-content">
    <div class="tab-pane fade in active" id="A" style="width:100%">
        <div class="box box-default box-body" style="background-color:rgba(255, 255, 255, 0.80);">
            <div class="form-horizontal" >
                    <div class="form-group">
                            <div class="col-md-2">
                                <label class="control-label">FullName<span style="color:Red">*</span></label>
                                <asp:TextBox ID="txtfullName" runat="server" CssClass="form-control" placeholder="Full Name" onkeyup="upper(this)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtfullName" Display="Dynamic" ErrorMessage="Full Name" 
                                    ForeColor="Red" ValidationGroup="a" ></asp:RequiredFieldValidator>
                                <%--<ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFirstName" FilterType="UppercaseLetters,LowercaseLetters,Custom"></ajaxtoolkit:FilteredTextBoxExtender>--%>
                            </div>                                                               
                                                        
                            <div class="col-md-2">
                                <label class="control-label">Date of Joining<span style="color:Red">*</span></label>
                                <asp:TextBox ID="txtDOJ" runat="server" CssClass="form-control" placeholder="Date of Joining" onkeydown="return DateKeyDown();"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtDOJ" Display="Dynamic" ErrorMessage="Date of Joining" 
                                    ForeColor="Red" ValidationGroup="a" ></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="txtDOJ">
                                </cc1:CalendarExtender>
                            </div>
                         <div class="col-md-2">
                                <label class="control-label">Age<span style="color:Red">*</span></label>
                                <asp:TextBox ID="txtage" runat="server" CssClass="form-control" placeholder="Age" MaxLength="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtage" Display="Dynamic" ErrorMessage="Contact Number" 
                                    ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtage" ValidChars="+0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                          <div class="col-md-2">
                                <label class="control-label">Contact No<span style="color:Red">*</span></label>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Contact Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Contact Number" 
                                    ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtMobileNo" ValidChars="+0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                          <div class="col-md-2">
                                <label class="control-label">Plan Type<span style="color:Red">*</span></label>
                                <asp:DropDownList ID="ddlplan" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlplan_SelectedIndexChanged"> </asp:DropDownList>
                            </div>
                        
                        <div class="col-md-2">
                                <label class="control-label">Role<span style="color:Red">*</span></label>
                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control"> </asp:DropDownList>
                            </div>
                    </div>
                    <div class="form-group">  
                         <div class="col-md-4">
                                <label class="control-label">Comment<span style="color:Red">*</span></label>
                                <asp:TextBox ID="txtcomment" runat="server" CssClass="form-control"  placeholder="Comment" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtcomment" Display="Dynamic" ErrorMessage="Current Address" 
                                    ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div> 
                          <div class="col-md-4">
                                <label class="control-label">Address<span style="color:Red">*</span></label>
                                <asp:TextBox ID="txtCurrentAddress" runat="server" CssClass="form-control"  placeholder="Current Address" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="txtCurrentAddress" Display="Dynamic" ErrorMessage="Current Address" 
                                    ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div> 
                         <div class="col-md-3">
                                <asp:CheckBox ID="chkisactive" runat="server" Text="IsActive" Checked="true"></asp:CheckBox>
                            </div>
                        
                    </div>
               
                <hr />
                <b>Payment Details</b>
                   <div class="table table-responsive">
                       
                       <asp:gridview ID="gridviewpayment" runat="server"  ShowFooter="true" AutoGenerateColumns="false" OnRowCreated="gridviewpayment_RowCreated" CssClass="table table-responsive"
                           EmptyDataRowStyle-CssClass="AdProHead" GridLines="None" EmptyDataRowStyle-Font-Size="Large"> 
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />                           
    <Columns>  
        <asp:BoundField DataField="Sno" HeaderText="Sno." />  
        <asp:TemplateField HeaderText="Amount">  
            <ItemTemplate>  
                <asp:TextBox ID="txtamount" placeholder="Amount" CssClass="form-control" runat="server"></asp:TextBox>  
            </ItemTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Payment Mode">  
            <ItemTemplate>  
                <asp:TextBox ID="txtpaymentMode" placeholder="Payment Mode" CssClass="form-control" runat="server"></asp:TextBox>  
            </ItemTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField  HeaderText="Payment Date">  
            <ItemTemplate>  
                <asp:TextBox ID="txtpaymentdate" runat="server" CssClass="form-control" placeholder="Date of Payment"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd-MMM-yyyy" TargetControlID="txtpaymentdate">
                        </cc1:CalendarExtender>  
            </ItemTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Header">  
            <ItemTemplate>  
                <asp:DropDownList ID="DropDownList2" runat="server"  
                                          AppendDataBoundItems="true">  
                    <asp:ListItem Value="-1">Select</asp:ListItem>  
                </asp:DropDownList>  
            </ItemTemplate>  
            <FooterStyle HorizontalAlign="Right" />  
            <FooterTemplate>  
                <asp:Button ID="BtnpaymentrowAdd" runat="server"   
                                     Text="Add New Row"   
                                     onclick="BtnpaymentrowAdd_Click" />  
            </FooterTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField>  
            <ItemTemplate>  
                <asp:LinkButton ID="Btnpaymentrowdelete" runat="server"   
                                        onclick="Btnpaymentrowdelete_Click">Remove</asp:LinkButton>  
            </ItemTemplate>  
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
</asp:gridview>  
                       </div>
                     
                <hr/>
                    <div id="divSave" runat="server" style="height:211px;margin-left:20px">
                    <div class="form-group">
                        <div class="panel-body thumbnail " style="width:350px" >
                            <table >
                                <tr>
                                    <td style="padding-left:50px">
                                        <asp:Image  ID="EmpImg" runat="server" Width="170px" Height="150px" GenerateEmptyAlternateText="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:170px;height:20px">
                                        <asp:Label ID="lblimageName" runat="server"  Width="170px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width:251px;">
                                                        <asp:FileUpload ID="FileUpload1" runat="server"  Width="250px" accept="image/*" CssClass="btn btn-success" />
                                                </td>
                                                <td style="padding-left:0px">
                                                    <asp:Button ID="btnImgSubmit" runat="server"  Height="40px" Text="Upload" CssClass="btn btn-success" OnClick="btnImgSubmit_Click"/>
                                                </td>
                                            </tr>
                                        </table>
                                        </td> 
                                </tr>
                            </table>
                        </div> 
                    </div>
                </div>
                <hr />
                    <div class="btn-group pull-right" style="margin-right:90px">
                    <asp:Button ID="btnGeneral" runat="server" Text="Create" CssClass="btn btn-primary"   
                        Width="110%"  OnClick="btnCreate_Click" >
                    </asp:Button> 
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
