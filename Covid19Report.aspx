<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="COVID19Report.aspx.cs" Inherits="COVID19Report" %>

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
<h1 class="AdProHead" style="text-align:center" >COVID-19  SELF HEALTH DECLARATION FORM</h1>
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
        <asp:Panel ID="PnlFrom" runat="server" Visible="false">
            <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                <div class="form-horizontal" >
                    <div class="box-body">
                            <div class="form-group">
                                <div class="col-md-6">
                                     <table>
                                   <%-- <tr>
                                         <td style="width:25%">
                                         <asp:label ID="Label91" runat="server" Text="Tei Code: " CssClass="control-label" Font-Bold="true"></asp:label>
                                        <asp:label ID="lblTCode" runat="server" Text="" CssClass="control-label" ></asp:label>
                                        
                                         </td>  
                                         <td style="width:25%">
                                        <asp:label ID="Label90" runat="server" Text="Name:" CssClass="control-label" Font-Bold="true" ></asp:label>
                                        <asp:label ID="lblName" runat="server" Text="" CssClass="control-label" ></asp:label>
                                         </td>   
                                        </tr>
                                         <tr>
                                        <td style="width:25%">
                                        <asp:label ID="Label93" runat="server" Text="Designation: " CssClass="control-label" Font-Bold="true" ></asp:label>
                                        <asp:label ID="lblDsgntin" runat="server" Text="" CssClass="control-label" ></asp:label>
                                         </td>  
                                         <td style="width:25%">
                                        <asp:label ID="Label95" runat="server" Text="Department: " CssClass="control-label" Font-Bold="true" ></asp:label>
                                        <asp:label ID="lblDptmt" runat="server" Text="" CssClass="control-label" ></asp:label>
                                         </td>            
                                    </tr>--%> 
                                          <tr>
                                         <td style="width:25%; height:50px">
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
                                    <asp:label ID="lblmsg" runat="server" Text="" CssClass="control-label" ></asp:label>
                                    </div>                            
                            </div>
                        <div></div>
                            <div class="btn-group pull-right" >                                                            
                                   <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSave_Click">
                                             <i class="fa fa-save text-white faa-flash animated" ></i>
                                             Save
                                  </asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:LinkButton ID="btnLink" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnback_Click">
                                             <i class="fa fa-save text-white faa-flash animated" ></i>
                                             Back 
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
            </ul>
            <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                <div class="form-horizontal" >
                    <div class="box-body">
                        <div class="tab-content">
                              <%--  Personal div start here--%>
                            <div class="tab-pane fade in active" id="Div80C" runat="server">                                                                           
                                 <div class="col-md-3">
                                 <table width="1000px">
                                     <tr>
                                         <td>
                                                <h3 style="font:100;">SYMPTOMS</h3>     
                                         </td>
                                     </tr>
                                     <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>1.</span>
                                    <asp:label ID="lblcough" runat="server" Text="Cough" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td>
                                             <asp:RadioButtonList ID="RPS1" runat="server" RepeatDirection="Vertical" CssClass="Space" >                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TPS1" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>2.</span>
                                    <asp:label ID="Label1" runat="server" Text="Fever (>100° F) if there is fever, how much? " CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS2" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS2" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>3.</span>
                                    <asp:label ID="Label2" runat="server" Text="Difficulty in Breathing, if Yes Give Reason " CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS3" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS3" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>4.</span>
                                    <asp:label ID="Label3" runat="server" Text="Persistent Pain in the Chest" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS4" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS4" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <h3 style="font:100;">SUFFERING WITH DISEASE</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>5.</span>
                                    <asp:label ID="Label4" runat="server" Text="Diabities" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS5" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TPS5" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>6.</span>
                                    <asp:label ID="Label5" runat="server" Text="Hypertension" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS6" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS6" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>7.</span>
                                    <asp:label ID="Label6" runat="server" Text="Lung Disease" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS7" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS7" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>8.</span>
                                    <asp:label ID="Label7" runat="server" Text="Heart Disease" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS8" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS8" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>9.</span>
                                    <asp:label ID="Label8" runat="server" Text="Any Other Disease, Please specify " CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS9" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS9" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr> 
                                        <tr>
                                       <td>
                                           <h3 style="font:100;">TRAVEL HISTORY</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>10.</span>
                                    <asp:label ID="Label9" runat="server" Text="Have you travel anywhere in last 14 days, please specify" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS10" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TPS10" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>11.</span>
                                    <asp:label ID="Label10" runat="server" Text="Have you recently in contacted or lived with someone who has tested positive for COVID-19" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS11" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS11" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>12.</span>
                                    <asp:label ID="Label11" runat="server" Text="In your family is there any healthcare worker & he / she examined CVOID - 19 patient without protective gear" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS12" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS12" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>13.</span>
                                    <asp:label ID="Label12" runat="server" Text="Present Residing Location is your Present address ?" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS13" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS13" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>14.</span>
                                    <asp:label ID="Label13" runat="server" Text="Downloaded Aarogya Setu App in your Mobile Phone" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS14" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS14" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                     <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>15.</span>
                                    <asp:label ID="Label14" runat="server" Text="Will you travel to office with your own conveyance" CssClass="control-label" ></asp:label>
                                             </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RPS15" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TPS15" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>                                               
                                 </table>
                                </div>                                  
                             </div>  
                              <%--  Father div start here--%>                                      
                            <div class="tab-pane fade" id="DivVIA" runat="server">
                              <div class="col-md-3">
                                 <table width="1000px">
                                     <tr>
                                         <td>
                                                <h3 style="font:100;">SYMPTOMS</h3>     
                                         </td>
                                     </tr>                                                                
                                     <tr style="width:1000px">
                                         <td  style="width:1000px" colspan="2"><span>1.</span>
                                    <asp:label ID="Label15" runat="server" Text="Cough" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RFa1" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TFa1" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>2.</span>
                                    <asp:label ID="Label16" runat="server" Text="Fever (>100° F) if there is fever, how much?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RFa2" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa2" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>3.</span>
                                    <asp:label ID="Label17" runat="server" Text="Difficulty in Breathing, if Yes Give Reason" CssClass="control-label" ></asp:label>
                                              </td></tr><tr><td>
                                    <asp:RadioButtonList ID="RFa3" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa3" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>4.</span>
                                    <asp:label ID="Label18" runat="server" Text="Persistent Pain in the Chest" CssClass="control-label" ></asp:label>
                                              </td></tr><tr><td>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa4" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa4" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <h3 style="font:100;">SUFFERING WITH DISEASE</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>5.</span>
                                    <asp:label ID="Label19" runat="server" Text="Diabities" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa5" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TFa5" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>6.</span>
                                    <asp:label ID="Label20" runat="server" Text="Hypertension" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa6" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa6" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>7.</span>
                                    <asp:label ID="Label21" runat="server" Text="Lung Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa7" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa7" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>8.</span>
                                    <asp:label ID="Label22" runat="server" Text="Heart Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa8" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa8" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>9.</span>
                                    <asp:label ID="Label23" runat="server" Text="Any Other Disease, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa9" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa9" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr> 
                                        <tr>
                                       <td>
                                           <h3 style="font:100;">TRAVEL HISTORY</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>10.</span>
                                    <asp:label ID="Label24" runat="server" Text="Have you travel anywhere in last 14 days, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa10" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TFa10" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>11.</span>
                                    <asp:label ID="Label25" runat="server" Text="Have you recently in contacted or lived with someone who has tested positive for COVID-19" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa11" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa11" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>12.</span>
                                    <asp:label ID="Label26" runat="server" Text="In your family is there any healthcare worker & he / she examined CVOID - 19 patient without protective gear" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa12" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa12" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>13.</span>
                                    <asp:label ID="Label27" runat="server" Text="Present Residing Location is your Present address ?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa13" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa13" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>14.</span>
                                    <asp:label ID="Label28" runat="server" Text="Downloaded Aarogya Setu App in your Mobile Phone" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa14" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa14" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>15.</span>
                                    <asp:label ID="Label29" runat="server" Text="Will you travel to office with your own conveyance" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RFa15" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" N/A " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TFa15" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>                                               
                                 </table>
                                </div>    
                            </div>
                              <%--  Mother div start here--%>
                            <div class="tab-pane fade" id="DivINTHousingLoan" runat="server">
                             <div class="col-md-3">
                                 <table width="1000px">
                                     <tr>
                                         <td>
                                                <h3 style="font:100;">SYMPTOMS</h3>     
                                         </td>
                                     </tr>                                   
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>1.</span>
                                    <asp:label ID="Label30" runat="server" Text="Cough" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr1" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TMr1" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>2.</span>
                                    <asp:label ID="Label31" runat="server" Text="Fever (>100° F) if there is fever, how much?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr2" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr2" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>3.</span>
                                    <asp:label ID="Label32" runat="server" Text="Difficulty in Breathing, if Yes Give Reason" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr3" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr3" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>4.</span>
                                    <asp:label ID="Label33" runat="server" Text="Persistent Pain in the Chest" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr4" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr4" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <h3 style="font:100;">SUFFERING WITH DISEASE</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>5.</span>
                                    <asp:label ID="Label34" runat="server" Text="Diabities" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr5" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TMr5" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>6.</span>
                                    <asp:label ID="Label35" runat="server" Text="Hypertension" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr6" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr6" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>7.</span>
                                    <asp:label ID="Label36" runat="server" Text="Lung Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr7" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr7" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>8.</span>
                                    <asp:label ID="Label37" runat="server" Text="Heart Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr8" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr8" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>9.</span>
                                    <asp:label ID="Label38" runat="server" Text="Any Other Disease, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr9" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr9" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr> 
                                        <tr>
                                       <td>
                                           <h3 style="font:100;">TRAVEL HISTORY</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>10.</span>
                                    <asp:label ID="Label39" runat="server" Text="Have you travel anywhere in last 14 days, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr10" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TMr10" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>11.</span>
                                    <asp:label ID="Label40" runat="server" Text="Have you recently in contacted or lived with someone who has tested positive for COVID-19" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr11" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr11" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>12.</span>
                                    <asp:label ID="Label41" runat="server" Text="In your family is there any healthcare worker & he / she examined CVOID - 19 patient without protective gear" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr12" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr12" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>13.</span>
                                    <asp:label ID="Label42" runat="server" Text="Present Residing Location is your Present address ?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr13" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr13" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>14.</span>
                                    <asp:label ID="Label43" runat="server" Text="Downloaded Aarogya Setu App in your Mobile Phone" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr14" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr14" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>15.</span>
                                    <asp:label ID="Label44" runat="server" Text="Will you travel to office with your own conveyance" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RMr15" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" N/A " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TMr15" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>                                               
                                 </table>
                                </div>    
                            </div>
                               <%--  Wife div start here--%>
                            <div class="tab-pane fade" id="DivOtherInCome" runat="server">
                             <div class="col-md-3">
                                 <table width="1000px">
                                     <tr>
                                         <td>
                                                <h3 style="font:100;">SYMPTOMS</h3>     
                                         </td>
                                     </tr>                                  
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>1.</span>
                                    <asp:label ID="Label45" runat="server" Text="Cough" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf1" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TWf1" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>2.</span>
                                    <asp:label ID="Label46" runat="server" Text="Fever (>100° F) if there is fever, how much?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf2" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf2" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>3.</span>
                                    <asp:label ID="Label47" runat="server" Text="Difficulty in Breathing, if Yes Give Reason" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf3" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf3" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>4.</span>
                                    <asp:label ID="Label48" runat="server" Text="Persistent Pain in the Chest" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf4" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf4" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <h3 style="font:100;">SUFFERING WITH DISEASE</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>5.</span>
                                    <asp:label ID="Label49" runat="server" Text="Diabities" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf5" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TWf5" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>6.</span>
                                    <asp:label ID="Label50" runat="server" Text="Hypertension" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf6" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf6" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>7.</span>
                                    <asp:label ID="Label51" runat="server" Text="Lung Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf7" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf7" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>8.</span>
                                    <asp:label ID="Label52" runat="server" Text="Heart Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf8" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf8" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>9.</span>
                                    <asp:label ID="Label53" runat="server" Text="Any Other Disease, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf9" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf9" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr> 
                                        <tr>
                                       <td>
                                           <h3 style="font:100;">TRAVEL HISTORY</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>10.</span>
                                    <asp:label ID="Label54" runat="server" Text="Have you travel anywhere in last 14 days, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf10" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="TWf10" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>11.</span>
                                    <asp:label ID="Label55" runat="server" Text="Have you recently in contacted or lived with someone who has tested positive for COVID-19" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf11" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf11" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>12.</span>
                                    <asp:label ID="Label56" runat="server" Text="In your family is there any healthcare worker & he / she examined CVOID - 19 patient without protective gear" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf12" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf12" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>13.</span>
                                    <asp:label ID="Label57" runat="server" Text="Present Residing Location is your Present address ?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf13" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf13" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>14.</span>
                                    <asp:label ID="Label58" runat="server" Text="Downloaded Aarogya Setu App in your Mobile Phone" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf14" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf14" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>15.</span>
                                    <asp:label ID="Label59" runat="server" Text="Will you travel to office with your own conveyance" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="RWf15" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" N/A " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="TWf15" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>                                               
                                 </table>
                                </div>    
                            </div>
                               <%--  child-1 div start here--%>
                            <div class="tab-pane fade" id="Div1017" runat="server">
                                <div class="col-md-3">
                                 <table width="1000px">
                                     <tr>
                                         <td>
                                                <h3 style="font:100;">SYMPTOMS</h3>     
                                         </td>
                                     </tr>                                      
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>1.</span>
                                    <asp:label ID="Label60" runat="server" Text="Cough" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch1" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="Tch1" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>2.</span>
                                    <asp:label ID="Label61" runat="server" Text="Fever (>100° F) if there is fever, how much?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch2" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch2" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>3.</span>
                                    <asp:label ID="Label62" runat="server" Text="Difficulty in Breathing, if Yes Give Reason" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch3" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch3" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>4.</span>
                                    <asp:label ID="Label63" runat="server" Text="Persistent Pain in the Chest" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch4" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch4" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <h3 style="font:100;">SUFFERING WITH DISEASE</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>5.</span>
                                    <asp:label ID="Label64" runat="server" Text="Diabities" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch5" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="Tch5" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>6.</span>
                                    <asp:label ID="Label65" runat="server" Text="Hypertension" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch6" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch6" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>7.</span>
                                    <asp:label ID="Label66" runat="server" Text="Lung Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch7" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch7" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>8.</span>
                                    <asp:label ID="Label67" runat="server" Text="Heart Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch8" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch8" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>9.</span>
                                    <asp:label ID="Label68" runat="server" Text="Any Other Disease, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch9" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch9" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr> 
                                        <tr>
                                       <td>
                                           <h3 style="font:100;">TRAVEL HISTORY</h3>    
                                       </td>
                                   </tr>                                     
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>10.</span>
                                    <asp:label ID="Label69" runat="server" Text="Have you travel anywhere in last 14 days, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch10" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="Tch10" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>11.</span>
                                    <asp:label ID="Label70" runat="server" Text="Have you recently in contacted or lived with someone who has tested positive for COVID-19" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch11" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch11" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>12.</span>
                                    <asp:label ID="Label71" runat="server" Text="In your family is there any healthcare worker & he / she examined CVOID - 19 patient without protective gear" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch12" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch12" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>13.</span>
                                    <asp:label ID="Label72" runat="server" Text="Present Residing Location is your Present address ?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch13" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch13" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>14.</span>
                                    <asp:label ID="Label73" runat="server" Text="Downloaded Aarogya Setu App in your Mobile Phone" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch14" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch14" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                       <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>15.</span>
                                    <asp:label ID="Label74" runat="server" Text="How Will you travel to office with your own conveyance" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rch15" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" N/A " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tch15" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>                                               
                                 </table>
                                </div>    
                            </div>
                               <%--  child-2 div start here--%>
                            <div class="tab-pane fade" id="DivOther" runat="server">
                             <div class="col-md-3">
                                 <table width="1000px">
                                     <tr>
                                         <td>
                                                <h3 style="font:100;">SYMPTOMS</h3>     
                                         </td>
                                     </tr>                                    
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>1.</span>
                                    <asp:label ID="Label75" runat="server" Text="Cough" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi1" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="Tchi1" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>2.</span>
                                    <asp:label ID="Label76" runat="server" Text="Fever (>100° F) if there is fever, how much?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi2" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi2" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>3.</span>
                                    <asp:label ID="Label77" runat="server" Text="Difficulty in Breathing, if Yes Give Reason" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi3" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi3" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>4.</span>
                                    <asp:label ID="Label78" runat="server" Text="Persistent Pain in the Chest" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi4" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi4" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <h3 style="font:100;">SUFFERING WITH DISEASE</h3>    
                                       </td>
                                   </tr>                                     
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>5.</span>
                                    <asp:label ID="Label79" runat="server" Text="Diabities" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi5" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="Tchi5" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>6.</span>
                                    <asp:label ID="Label80" runat="server" Text="Hypertension" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi6" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi6" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>7.</span>
                                    <asp:label ID="Label81" runat="server" Text="Lung Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi7" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi7" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>8.</span>
                                    <asp:label ID="Label82" runat="server" Text="Heart Disease" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi8" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi8" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>9.</span>
                                    <asp:label ID="Label83" runat="server" Text="Any Other Disease, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi9" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi9" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr> 
                                      <tr>
                                       <td>
                                           <h3 style="font:100;">TRAVEL HISTORY</h3>    
                                       </td>
                                   </tr>                                     
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>10.</span>
                                    <asp:label ID="Label84" runat="server" Text="Have you travel anywhere in last 14 days, Please specify" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi10" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:500px">
                                           <asp:TextBox ID="Tchi10" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>11.</span>
                                    <asp:label ID="Label85" runat="server" Text="Have you recently in contacted or lived with someone who has tested positive for COVID-19" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi11" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi11" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>12.</span>
                                    <asp:label ID="Label86" runat="server" Text="In your family is there any healthcare worker & he / she examined CVOID - 19 patient without protective gear" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi12" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi12" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>13.</span>
                                    <asp:label ID="Label87" runat="server" Text="Present Residing Location is your Present address ?" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi13" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi13" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                      <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>14.</span>
                                    <asp:label ID="Label88" runat="server" Text="Downloaded Aarogya Setu App in your Mobile Phone" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi14" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" No " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi14" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>
                                      <tr>
                                       <td>
                                           <br />
                                       </td>
                                   </tr>
                                     <tr style="width:1000px">
                                          <td  style="width:1000px" colspan="2"><span>15.</span>
                                    <asp:label ID="Label89" runat="server" Text="Will you travel to office with your own conveyance" CssClass="control-label" ></asp:label>
                                    </td></tr><tr><td><asp:RadioButtonList ID="Rchi15" runat="server" RepeatDirection="Vertical" CssClass="Space">                                                       
                                                        <asp:ListItem Text=" Yes " Value="1" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text=" N/A " Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                         </td>                                         
                                         <td  style="width:200px">
                                           <asp:TextBox ID="Tchi15" runat="server" placeholder="Remarks" TextMode="MultiLine" Height="60px" Width="500px" ></asp:TextBox>
                                         </td>
                                     </tr>                                               
                                 </table>
                                </div>    
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </asp:Panel>
         <asp:Panel ID="PnlGrid" runat="server" Visible="false">
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
                                     <div class="col-md-5">
                                        <label class="control-label">Date</label>
                                        <asp:TextBox ID="txtSearchDate" runat="server" CssClass="form-control" placeholder="Fill Up Date"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd-MMM-yyyy" TargetControlID="txtSearchDate">
                                        </cc1:CalendarExtender>
                                    </div>   
                                    <div>
                                        <asp:label ID="Label92" runat="server" Text="" CssClass="control-label" ></asp:label>
                                    </div>                              
                                </div>                        
                                <div class="btn-group pull-right" >                                                                                                   
                                      <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSearch_Click">
                                                 <i class="fa fa-save text-white faa-flash animated" ></i>
                                                 Search
                                      </asp:LinkButton>  
                                     <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnResetSearch_Click">
                                                 <i class="fa fa-save text-white faa-flash animated" ></i>
                                                Reset 
                                      </asp:LinkButton>                                                               
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
                                             ForeColor="#333333" GridLines="None"  OnPageIndexChanging="GrCovid_PageIndexChanging" AllowPaging="true" PageSize="1500"  OnRowCommand="GrCovid_RowCommand">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />                                         
                                             <Columns>
                                              <asp:TemplateField HeaderText="SNo" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                             <HeaderStyle CssClass="table_04" HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle CssClass="table_02" HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>                                                   
                                                <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                       <asp:LinkButton ID="btnview"  Font-Bold="true" runat="server" CausesValidation="false" Text='<%# Eval("UserCode") %>' CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>   
                                                </ItemTemplate>                   
                                            </asp:TemplateField>
                                                  <asp:BoundField DataField="EmployeeName" HeaderText="Name" />   
                                                  <asp:BoundField DataField="Personal" HeaderText="Personal" />  
                                                  <asp:BoundField DataField="Father" HeaderText="Father" />   
                                                  <asp:BoundField DataField="Mother" HeaderText="Mother" />   
                                                  <asp:BoundField DataField="Wife" HeaderText="Spouse"  /> 
                                                  <asp:BoundField DataField="Child-1" HeaderText="Bro/Sis/Ch-1" />   
                                                  <asp:BoundField DataField="Child-2" HeaderText="Bro/Sis/Chi-2" /> 
                                                 <asp:BoundField DataField="CovidApp" HeaderText="App installed" />   
                                                 <asp:BoundField DataField="TravelByOwnConv" HeaderText="Travel Own Conv" />   
                                                 <asp:BoundField DataField="ResidingAtPresentAddress" HeaderText="Residing Pres Address" />   
                                                  <asp:BoundField DataField="FromFillDate" HeaderText="Date" /> 
                                                  <%--<asp:BoundField DataField="Close" HeaderText="Close" />  --%>                                                                                     
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
