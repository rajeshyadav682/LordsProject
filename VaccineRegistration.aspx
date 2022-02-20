<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="VaccineRegistration.aspx.cs" Inherits="VaccineRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .divheight {
            height: 450px;
            overflow: auto;
        }

        .text-Padding {
            padding-left: 5px;
            padding-right: 5px;
        }
        .Space label
        {
           margin-left: 8px;
        }
    </style>
    <script type="text/javascript">
        function fn80C() {
            document.getElementById("fn80C").click();
            return false;
        }
        function fnVIA() {
            document.getElementById("fnVIA").click();
            return false;
        }
        function fnIntHousingLoan() {
            document.getElementById("fnIntHousingLoan").click();
            return false;
        }
        function fnOtherInCome() {
            document.getElementById("fnOtherInCome").click();
            return false;
        }
        function fn1017() {
            document.getElementById("fn1017").click();
            return false;
        }
        function fnOther() {
            document.getElementById("fnOther").click();
        }
        function fnOtherHRA() {
            fnOther();
            document.getElementById("btnHRA").click();
            return false;
        }
        function fnOtherCEA() {
            fnOther();
            document.getElementById("btnCEA").click();
            return false;
        }
        function fnOtherCHA() {
            fnOther();
            document.getElementById("btnCHA").click();
            return false;
        }
        function fncertificate() {
            document.getElementById("fncertificate").click();
            return false;
        }
        
        var acc = document.getElementsByClassName("btn btn-box-tool");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var panel = this.nextElementSibling;
                if (panel.style.display === "block") {
                    panel.style.display = "none";
                } else {
                    panel.style.display = "block";
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
<h1 class="AdProHead" style="text-align:center" >COVID-19 VACCINATION FORM</h1>
</section>
    <div class="clearfix"></div>
    <div runat="server" align="center">
        <h5>For the health and safety of our staff, family members, etc. declaration of Vaccination is mandatory </h5>
        <h5>Be sure that the information you'll provide is accurate  </h5>
        <h5>Please get immediate Vaccinated if not yet</h5>
    </div>
    <section class="content">
        
<asp:UpdatePanel  ID="u1" runat="server" >  
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
        <asp:PostBackTrigger ControlID="P_LnkBtn" />
        <asp:PostBackTrigger ControlID="F_LnkBtn" />
        <asp:PostBackTrigger ControlID="M_LnkBtn" />
        <asp:PostBackTrigger ControlID="S_LnkBtn" />
        <asp:PostBackTrigger ControlID="CH1_LnkBtn" />
        <asp:PostBackTrigger ControlID="CH2_LnkBtn" />
        
    </Triggers>
    <ContentTemplate> 
        <asp:Panel ID="PnlFrom" runat="server" Visible="true">       
            <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                <div class="form-horizontal" >
                    <div class="box-body">
                            <div class="form-group">
                                <div class="col-md-4">
                    <label class="control-label">Employee</label>
                    <div id="listPlacement"  class="gradientBoxesWithOuterShadows" ></div>
                        <asp:TextBox ID="txtemployee" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Type Employee Name or Code"  OnTextChanged="txtemployee_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtemployee" ServiceMethod="GetALLEmployee"
                            ServicePath="~/GetEmployeeDetails.asmx" MinimumPrefixLength="1" CompletionInterval="1"
                            CompletionSetCount="1000" EnableCaching="false" Enabled="true" CompletionListElementID="listPlacement" CompletionListItemCssClass="ListItemCssClass" CompletionListHighlightedItemCssClass="ListHighlightedItemCssClass" CompletionListCssClass="ListCssClass">
                        </cc1:AutoCompleteExtender>
                </div>
                             <div class="col-md-8"></div>   
                                 <div class="col-md-6">
                                     <table>
                                    <tr >
                                         <td style="width:25% ;height:40px" >
                                        <asp:label ID="Label91" runat="server" Text="Tei Code " CssClass="control-label" Font-Bold="true"></asp:label>
                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:&nbsp&nbsp
                                        <asp:label ID="lblTCode" runat="server" Text="" CssClass="control-label" ></asp:label>
                                         </td>  
                                         <td style="width:25%">
                                        <asp:label ID="Label90" runat="server" Text="Name " CssClass="control-label" Font-Bold="true" ></asp:label>
                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:&nbsp&nbsp
                                       <asp:label ID="lblName" runat="server" Text="" CssClass="control-label" ></asp:label>
                                        
                                         </td>   
                                        </tr>
                                    <tr>
                                        <td style="width:25%">
                                        <asp:label ID="Label93" runat="server" Text="Designation " CssClass="control-label" Font-Bold="true" ></asp:label>
                                        &nbsp&nbsp:&nbsp&nbsp<asp:label ID="lblDsgntin" runat="server" Text="" CssClass="control-label" ></asp:label>
                                         </td>  
                                         <td style="width:25%">
                                        <asp:label ID="Label95" runat="server" Text="Department  " CssClass="control-label" Font-Bold="true" ></asp:label>
                                        &nbsp&nbsp:&nbsp&nbsp
                                        <asp:label ID="lblDptmt" runat="server" Text="" CssClass="control-label" ></asp:label>
                                         </td>            
                                    </tr>                                   
                                </table>                                 
                                 
                                </div>
                                <div>
                                    <asp:label ID="lblmsg" runat="server" CssClass="control-label danger font-weight-bold" ></asp:label>
                                    </div>                            
                            </div>
                        <div></div>
                        <label style="margin-left:400px;color:red;margin-top:40px;font-size:medium">Please Attached required certificate in the end</label>
                            <div class="btn-group pull-right" >                                                            
                                   <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSave_Click">
                                             <i class="fa fa-save text-white faa-flash animated" ></i>
                                             Submit
                                  </asp:LinkButton>                                                                                          
                            </div>  
                         <div class="btn-group pull-right margin-r-5" >                                                            
                                    <asp:LinkButton ID="btnref" runat="server"  CssClass="btn btn-default faa-parent animated-hover" onclick="btnref_Click">
                                             <i class="fa fa-refresh text-white faa-flash animated" ></i>
                                             Refresh
                                  </asp:LinkButton>                                                                                         
                            </div>  
                        </div>
                    </div>
                </div>
            <ul class="nav nav-tabs">
                <li class="nav active"><a id="fn80C" href="#ctl00_ContentPlaceHolder1_Div80C" data-toggle="tab" >Personal</a></li>
                <li class="nav"><a id="fnVIA" href="#ctl00_ContentPlaceHolder1_DivVIA" data-toggle="tab">Father</a></li>
                <li class="nav"><a id="fnIntHousingLoan" href="#ctl00_ContentPlaceHolder1_DivINTHousingLoan" data-toggle="tab">Mother</a></li>
                <li class="nav"><a id="fnOtherInCome" href="#ctl00_ContentPlaceHolder1_DivOtherInCome" data-toggle="tab">Spouse</a></li>
                <li class="nav"><a id="fn1017" href="#ctl00_ContentPlaceHolder1_Div1017" data-toggle="tab">Brother/Sister/Child - 1</a></li>
                <li class="nav"><a id="fnOther" href="#ctl00_ContentPlaceHolder1_DivOther" data-toggle="tab">Brother/Sister/Child - 2</a></li>
                <li class="nav"><a id="fncertificate" href="#ctl00_ContentPlaceHolder1_Divcertificate" data-toggle="tab">Certificate Upload</a></li>
            </ul>
            <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                <div class="form-horizontal" >
                    <div class="box-body">
                        <div class="tab-content">
                              <%--  Personal div start here--%>
                            <div class="tab-pane fade in active" id="Div80C" runat="server">  
                                <h3></h3>
                                <asp:RadioButtonList ID="P_applicability" AutoPostBack="true" OnSelectedIndexChanged="P_applicability_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Applicable" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Not Applicable" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                 <div class="form-group">
                        <div class="col-md-12">
                           <div class="col-md-3">
                               <label class="control-label">Vaccine <span class="text-danger">*</span> </label>
                               <asp:DropDownList ID="P_ddlvaccine" runat="server"  CssClass="form-control"   ></asp:DropDownList>     
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Dose Taken<span class="text-danger">*</span> </label>
                                <asp:RadioButtonList ID="P_rbndose" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Dose 1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Dose 2" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="col-md-3">
                                <label class="control-label" >Date of Dose <span class="text-danger">*</span></label>
                                <asp:TextBox ID="P_txtdosedate" runat="server" CssClass=" form-control" placeholder="Date of Dose" onkeydown="return DateKeyDown();"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="P_txtdosedate" Display="Dynamic" ErrorMessage="Date of Dose" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="P_txtdosedate">
                                </cc1:CalendarExtender>
                            </div>
                            <%--<div class="col-md-3">
                                
                                <label class="control-label">Upload Certificate  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="P_fileupload" runat="server" CssClass="form-control" />

                            </div>--%>
                        </div>
                    </div>
                               
                            <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label class="control-label"> Remarks <span class="text-danger">*</span> </label>
                                <asp:TextBox TextMode="MultiLine" ID="P_txtRemarks" runat="server"  CssClass=" form-control" placeholder="Enter Remarks"></asp:TextBox>
                            </div>
                             <div class="col-md-5">
                                 <asp:Panel ID="P_pnlcertificate" runat="server" Visible="false">
                                <label class="control-label"> Download Certificate <span class="text-danger"></span> </label>
                                 <asp:LinkButton ID="P_LnkBtn" Visible="false" runat="server" OnClick="P_LnkBtn_Click" >Download Certifate</asp:LinkButton>  
                                 <asp:HiddenField ID="P_hdnvalue" runat="server" />
                                     </asp:Panel>
                            </div>
                        </div>
                               
                  </div>                                  
                             </div>  
                              <%--  Father div start here--%>                                      
                            <div class="tab-pane fade" id="DivVIA" runat="server">
                              <h3></h3>
                                <asp:RadioButtonList ID="F_applicability" AutoPostBack="true" OnSelectedIndexChanged="F_applicability_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Applicable" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Not Applicable" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                 <div class="form-group">
                           <div class="col-md-12">
                            <div class="col-md-3">
                               <label class="control-label">Vaccine <span class="text-danger">*</span> </label>
                               <asp:DropDownList ID="F_ddlvaccine" runat="server"  CssClass="form-control"   ></asp:DropDownList>     
                            </div>

                            <div class="col-md-3">
                                <label class="control-label">Dose Taken<span class="text-danger">*</span> </label>
                                <asp:RadioButtonList ID="F_rbndose" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Dose 1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Dose 2" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="col-md-3">
                                <label class="control-label" >Date of Dose <span class="text-danger">*</span></label>
                                <asp:TextBox ID="F_txtdosedate" runat="server" CssClass=" form-control" placeholder="Date of Dose" onkeydown="return DateKeyDown();"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="F_txtdosedate" Display="Dynamic" ErrorMessage="Date of Dose" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="F_txtdosedate">
                                </cc1:CalendarExtender>
                            </div>
                           <%-- <div class="col-md-3">
                                <label class="control-label">Upload Certificate  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="F_fileupload" runat="server" CssClass="form-control" />
                            </div>--%>
                        </div>
                         </div>
                               
                                 <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label class="control-label"> Remarks <span class="text-danger">*</span> </label>
                                <asp:TextBox TextMode="MultiLine" ID="F_txtRemarks" runat="server"  CssClass=" form-control" placeholder="Enter Remarks"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Panel ID="F_pnlcerificate" runat="server" Visible="false">
                                <label class="control-label"> Download Certificate <span class="text-danger"></span> </label>
                                 <asp:LinkButton ID="F_LnkBtn" Visible="false" runat="server" OnClick="F_LnkBtn_Click" >Download Certifate</asp:LinkButton>  
                                 <asp:HiddenField ID="F_hdnvalue" runat="server" />
                                    </asp:Panel>

                            </div>
                        </div>
                  </div>  
                                
                            </div>
                              <%--  Mother div start here--%>
                            <div class="tab-pane fade" id="DivINTHousingLoan" runat="server">
                             <h3></h3>
                                <asp:RadioButtonList ID="M_applicability" AutoPostBack="true" OnSelectedIndexChanged="M_applicability_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Applicable" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Not Applicable" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                 <div class="form-group">
                           <div class="col-md-12">
                            <div class="col-md-3">
                               <label class="control-label">Vaccine <span class="text-danger">*</span> </label>
                               <asp:DropDownList ID="M_ddlvaccine" runat="server"  CssClass="form-control"   ></asp:DropDownList>     
                            </div>

                            <div class="col-md-3">
                                <label class="control-label">Dose Taken<span class="text-danger">*</span> </label>
                                <asp:RadioButtonList ID="M_rbndose" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Dose 1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Dose 2" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="col-md-3">
                                <label class="control-label" >Date of Dose <span class="text-danger">*</span></label>
                                <asp:TextBox ID="M_txtdosedate" runat="server" CssClass=" form-control" placeholder="Date of Dose" onkeydown="return DateKeyDown();"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="M_txtdosedate" Display="Dynamic" ErrorMessage="Date of Dose" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="M_txtdosedate">
                                </cc1:CalendarExtender>
                            </div>
                            <%--<div class="col-md-3">
                                <label class="control-label">Upload Certificate  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="M_fileupload" runat="server" CssClass="form-control" />
                            </div>--%>
                        </div>
                         </div>
                               
                                 <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label class="control-label"> Remarks <span class="text-danger">*</span> </label>
                                <asp:TextBox TextMode="MultiLine" ID="M_txtRemarks" runat="server"  CssClass=" form-control" placeholder="Enter Remarks"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <asp:Panel ID="M_pnlcerificate" runat="server" Visible="false">
                                <label class="control-label"> Download Certificate <span class="text-danger"></span> </label>
                                 <asp:LinkButton ID="M_LnkBtn" Visible="false" runat="server" OnClick="M_LnkBtn_Click" >Download Certifate</asp:LinkButton>  
                                 <asp:HiddenField ID="M_hdnvalue" runat="server" />
                                     </asp:Panel>
                            </div>
                        </div>
                  </div>      
                            </div>
                               <%--  Wife div start here--%>
                               <div class="tab-pane fade" id="DivOtherInCome" runat="server">
                             <h3></h3>
                                <asp:RadioButtonList ID="S_applicability" AutoPostBack="true" OnSelectedIndexChanged="S_applicability_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Applicable" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Not Applicable" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                 <div class="form-group">
                           <div class="col-md-12">
                            <div class="col-md-3">
                               <label class="control-label">Vaccine <span class="text-danger">*</span> </label>
                               <asp:DropDownList ID="S_ddlvaccine" runat="server"  CssClass="form-control"   ></asp:DropDownList>     
                            </div>

                            <div class="col-md-3">
                                <label class="control-label">Dose Taken<span class="text-danger">*</span> </label>
                                <asp:RadioButtonList ID="S_rbndose" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Dose 1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Dose 2" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="col-md-3">
                                <label class="control-label" >Date of Dose <span class="text-danger">*</span></label>
                                <asp:TextBox ID="S_txtdosedate" runat="server" CssClass=" form-control" placeholder="Date of Dose" onkeydown="return DateKeyDown();"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="S_txtdosedate" Display="Dynamic" ErrorMessage="Date of Dose" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="S_txtdosedate">
                                </cc1:CalendarExtender>
                            </div>
                            <%--<div class="col-md-3">
                                <label class="control-label">Upload Certificate  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="S_fileupload" runat="server" CssClass="form-control" />
                            </div>--%>
                        </div>
                         </div>
                               
                                 <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label class="control-label"> Remarks <span class="text-danger">*</span> </label>
                                <asp:TextBox TextMode="MultiLine" ID="S_txtRemarks" runat="server"  CssClass=" form-control" placeholder="Enter Remarks"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <asp:Panel ID="S_pnlcerificate" runat="server" Visible="false">
                                <label class="control-label"> Download Certificate <span class="text-danger"></span> </label>
                                 <asp:LinkButton ID="S_LnkBtn" Visible="false" runat="server" OnClick="S_LnkBtn_Click" >Download Certifate</asp:LinkButton>  
                                 <asp:HiddenField ID="S_hdnvalue" runat="server" />
                                     </asp:Panel>
                            </div>
                        </div>
                  </div>      
                            </div>
                               <%--  child-1 div start here--%>
                            <div class="tab-pane fade" id="Div1017" runat="server">
                              <h3></h3>
                                <asp:RadioButtonList ID="CH1_applicability" AutoPostBack="true" OnSelectedIndexChanged="CH1_applicability_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Applicable" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Not Applicable" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                 <div class="form-group">
                           <div class="col-md-12">
                            <div class="col-md-3">
                               <label class="control-label">Vaccine <span class="text-danger">*</span> </label>
                               <asp:DropDownList ID="CH1_ddlvaccine" runat="server"  CssClass="form-control"   ></asp:DropDownList>     
                            </div>

                            <div class="col-md-3">
                                <label class="control-label">Dose Taken<span class="text-danger">*</span> </label>
                                <asp:RadioButtonList ID="CH1_rbndose" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Dose 1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Dose 2" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="col-md-3">
                                <label class="control-label" >Date of Dose <span class="text-danger">*</span></label>
                                <asp:TextBox ID="CH1_txtdosedate" runat="server" CssClass=" form-control" placeholder="Date of Dose" onkeydown="return DateKeyDown();"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="CH1_txtdosedate" Display="Dynamic" ErrorMessage="Date of Dose" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="CH1_txtdosedate">
                                </cc1:CalendarExtender>
                            </div>
                           <%-- <div class="col-md-3">
                                <label class="control-label">Upload Certificate  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="CH1_fileupload" runat="server" CssClass="form-control" />
                            </div>--%>
                        </div>
                         </div>
                               
                                 <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label class="control-label"> Remarks <span class="text-danger">*</span> </label>
                                <asp:TextBox TextMode="MultiLine" ID="CH1_txtRemarks" runat="server"  CssClass=" form-control" placeholder="Enter Remarks"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <asp:Panel ID="CH1_pnlcerificate" runat="server" Visible="false">
                                <label class="control-label"> Download Certificate <span class="text-danger"></span> </label>
                                 <asp:LinkButton ID="CH1_LnkBtn" Visible="false" runat="server" OnClick="CH1_LnkBtn_Click" >Download Certifate</asp:LinkButton>  
                                 <asp:HiddenField ID="CH1_hdnvalue" runat="server" />
                                     </asp:Panel>
                            </div>
                        </div>
                  </div>      
                            </div>
                               <%--  child-2 div start here--%>
                               <div class="tab-pane fade" id="DivOther" runat="server">
                              <h3></h3>
                                <asp:RadioButtonList ID="CH2_applicability" AutoPostBack="true" OnSelectedIndexChanged="CH2_applicability_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Applicable" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Not Applicable" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                 <div class="form-group">
                           <div class="col-md-12">
                            <div class="col-md-3">
                               <label class="control-label">Vaccine <span class="text-danger">*</span> </label>
                               <asp:DropDownList ID="CH2_ddlvaccine" runat="server"  CssClass="form-control"   ></asp:DropDownList>     
                            </div>

                            <div class="col-md-3">
                                <label class="control-label">Dose Taken<span class="text-danger">*</span> </label>
                                <asp:RadioButtonList ID="CH2_rbndose" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Dose 1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Dose 2" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="col-md-3">
                                <label class="control-label" >Date of Dose <span class="text-danger">*</span></label>
                                <asp:TextBox ID="CH2_txtdosedate" runat="server" CssClass=" form-control" placeholder="Date of Dose" onkeydown="return DateKeyDown();"  ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CH2_txtdosedate" Display="Dynamic" ErrorMessage="Date of Dose" 
                                ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" Format="dd/MMM/yyyy" TargetControlID="CH2_txtdosedate">
                                </cc1:CalendarExtender>
                            </div>
                            <%--<div class="col-md-3">
                                <label class="control-label">Upload Certificate  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="CH2_fileupload" runat="server" CssClass="form-control" />
                            </div>--%>
                        </div>
                         </div>
                               
                                 <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label class="control-label"> Remarks <span class="text-danger">*</span> </label>
                                <asp:TextBox TextMode="MultiLine" ID="CH2_txtRemarks" runat="server"  CssClass=" form-control" placeholder="Enter Remarks"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <asp:Panel ID="CH2_pnlcerificate" runat="server" Visible="false">
                                <label class="control-label"> Download Certificate <span class="text-danger"></span> </label>
                                 <asp:LinkButton ID="CH2_LnkBtn" Visible="false" runat="server" OnClick="CH2_LnkBtn_Click" >Download Certifate</asp:LinkButton>  
                                 <asp:HiddenField ID="CH2_hdnvalue" runat="server" />
                                     </asp:Panel>
                            </div>
                        </div>
                  </div>      
                            </div>
                       
                            <div class="tab-pane fade" id="Divcertificate" runat="server">
                              <h3></h3>
                                 <div class="form-group">
                           <div class="col-md-12">
                  
                            <div class="col-md-3">
                                <label class="control-label">Upload Certificate(Personal)  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="P_fileupload" runat="server" CssClass="form-control" />
                            </div>
                                <div class="col-md-3">
                                <label class="control-label">Upload Certificate (Father) <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="F_fileupload" runat="server" CssClass="form-control" />
                            </div>
                                <div class="col-md-3">
                                <label class="control-label">Upload Certificate (Mother) <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="M_fileupload" runat="server" CssClass="form-control" />
                            </div>
                                <div class="col-md-3">
                                <label class="control-label">Upload Certificate (Spouce)  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="S_fileupload" runat="server" CssClass="form-control" />
                            </div>
                                <div class="col-md-3">
                                <label class="control-label">Upload Certificate (Child-1)  <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="CH1_fileupload" runat="server" CssClass="form-control" />
                            </div>
                                <div class="col-md-3">
                                <label class="control-label">Upload Certificate (Child 2) <span class="text-danger">*</span> </label>
                               <asp:FileUpload ID="CH2_fileupload" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                         </div>
                               
                                       
                            </div>
                        </div>
                    </div>
                </div>
            </div> 
         </asp:Panel>              
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



