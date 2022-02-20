<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="CompanywiseSetup.aspx.cs" Inherits="CompanywiseSetup" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="CloudeJS/CloudeJs.js" type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <section class="content-header">
        <h1 class="AdProHead"> <i class="fa fa-cog  fa-spin"></i>
            Company Wise Setup
        </h1>
  </section>
<div class="clearfix"></div>

    <section class="content">
    <asp:UpdatePanel ID="UpdPnl" runat="server" UpdateMode="Conditional">
       <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>--%>
<ContentTemplate>
    
       
            <%--<div class="form-horizontal" >--%>
            <div class="box-body" >
             <%--<div id="divView" runat="server"  class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
             <div class="form-horizontal" >
                      <div class="form-group">
                           <div class="col-md-2">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary"  Width="70%" OnClick="btnAdd_Click"  ></asp:Button>
                            </div>
                      </div>
</div>
            </div>--%>
           <%-- </div>--%>
       
        <div id="divSave" runat="server">
         <div class="row">
        <div class="col-md-12">
          <div id="divgeneral" runat="server" style="visibility:visible"> 
            <div class="row">
            <div class="col-md-12">
              <div class="box box-info" style="background-color:rgba(255, 255, 255, 0.80);">
               <div class="box-header with-border">
                  <h3 class="box-title">General</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus "></i></button>
                    <%--<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                  </div>
                </div>
                <div id="divgeneraldisplay" runat="server" class="box-body" style="display:Block;" >
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                   
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Employer's PF Contribution Salary Limit:</label></div>
                         <div class="col-lg-2">
                            <asp:TextBox ID="txtemployerpfcon" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rvDecimal" ControlToValidate="txtemployerpfcon" runat="server"
ErrorMessage="Please enter a valid PF." ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">VPF Percentage limit:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtVPFpercentage" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtVPFpercentage" runat="server"
ErrorMessage="Please enter a valid VPF Percentage." ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">VPF Amount limit:</label></div>
                         <div class="col-lg-2">
                                <asp:TextBox ID="txtVPFamountlimit" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtVPFamountlimit" runat="server"
ErrorMessage="Please enter a valid VPF Amount." ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>

                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">PF %:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtPF" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtPF" runat="server"
ErrorMessage="Please enter a valid PF %" ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">VPF %:</label></div>
                         <div class="col-lg-2">
                                <asp:TextBox ID="txtVPF" runat="server"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtVPF" runat="server"
ErrorMessage="Please enter a valid VPF %" ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">VPF Amount:</label></div>
                         <div class="col-lg-2">
                            <asp:TextBox ID="txtVPFamount" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtVPFamount" runat="server"
ErrorMessage="Please enter a valid VPF Amount%" ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>
           
              <%--<h4 id="h4Selectproduct" runat="server">Select Product Group:</h4>--%>
            <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">

                  <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Employer's PF Deduction on Actual Salary:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkemployer" runat="server" />
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Employee's PF Deduction on Actual Salary:</label></div>
                         <div class="col-lg-2">
                                <asp:CheckBox ID="chkemployee" runat="server" />
                         </div>
                 <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;"></label></div>
                         <div class="col-lg-2">
                         </div>
                 </div>
            
            </div>
              </div><!-- /.box -->
              </div>
              </div>
              </div>
            
          <div id="divbonus" runat="server" style="visibility:visible"> 
          <div class="row">
            <div class="col-md-12">
              <div class="box box-info" style="background-color:rgba(255, 255, 255, 0.80);">
               <div class="box-header with-border">
                  <h3 class="box-title">Bonus </h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                    <%--<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                  </div>
                </div>
                <div id="divBonusDisplay" runat="server" class="box-body" style="display:none;" >
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Bonus Declaration Date:</label></div>
              <div class="col-lg-2">
                           <asp:TextBox ID="txtbonusdeclarationdate" runat="server"></asp:TextBox>
                           <asp:calendarextender id="Calendarextender3" targetcontrolid="txtbonusdeclarationdate" format="dd/MMM/yyyy"
                    runat="server" cssclass="red" enabled="True"></asp:calendarextender>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Bonus %:</label></div>
                         <div class="col-lg-2">
                                <asp:TextBox ID="txtbonus" runat="server"></asp:TextBox>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtbonus" runat="server"
ErrorMessage="Please enter a valid Bonus %" ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Bonus Salary Maximum Limit:</label></div>
                         <div class="col-lg-2">
                            <asp:TextBox ID="txtbonussalarymaximum" runat="server"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtbonussalarymaximum" runat="server"
ErrorMessage="Please enter a valid Bonus limit %" ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>

                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Exgratia Salary Maximum Limit:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtexgratiasalarymaxilimit" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtexgratiasalarymaxilimit" runat="server"
ErrorMessage="Please enter a valid Exgratia limit " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">ExExgratia Salary Exceed Limit
:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtexexgratiasalaryexceedlimit" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtexexgratiasalaryexceedlimit" runat="server"
ErrorMessage="Please enter a valid Exgratia Exceed limit " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Min. Working Days :</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtminworkingdays" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtminworkingdays" runat="server"
ErrorMessage="Please enter a valid Working Days " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>
           
              <%--<h4 id="h4Selectproduct" runat="server">Select Product Group:</h4>--%>
            
            
            </div>
              </div><!-- /.box -->

            </div><!-- /.col (left) -->

          </div>
          </div> 
          <!-- /.col (left) -->
          <div id="divleaves" runat="server" style="visibility:visible"> 
          <div class="row">
            <div class="col-md-12">
              <div class="box box-info" style="background-color:rgba(255, 255, 255, 0.80);">
               <div class="box-header with-border">
                  <h3 class="box-title">Leaves</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus "></i></button>
                    <%--<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                  </div>
                </div>
                <div id="divleavesdisplay" runat="server" class="box-body" style="display:none;" >
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Duration of Short Leave (In hrs):</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtdurationofshortleave" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtdurationofshortleave" runat="server"
ErrorMessage="Please enter a valid Leave " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">No of hours in Half-Day:</label></div>
                         <div class="col-lg-2">
                                <asp:TextBox ID="txtnoofhoursinhalfday" runat="server"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtnoofhoursinhalfday" runat="server"
ErrorMessage="Please enter a valid hours " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">No. of Short Leaves in a month:</label></div>
                         <div class="col-lg-2">
                            <asp:TextBox ID="txtnoOfshortleavesinamonth" runat="server"></asp:TextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ControlToValidate="txtnoOfshortleavesinamonth" runat="server"
ErrorMessage="Please enter a valid Leave " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>

                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Compensatory Leaves to be credited against:</label></div>
                         <div class="col-lg-2">
                          <%-- <asp:DropDownList ID="ddlcompenagainst" runat="server" Width="100%">
                           <asp:ListItem>select</asp:ListItem>
                           <asp:ListItem></asp:ListItem>
                           <asp:ListItem></asp:ListItem>
                           </asp:DropDownList>--%>
                           <asp:TextBox ID="txtcompensatoryleaves" runat="server"></asp:TextBox>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Continuous Leaves to include Holidays/Off-Days:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkcontinuleave" runat="server" />
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;"></label></div>
                         <div class="col-lg-2">
                        
                         </div>
                 </div>
           
              <%--<h4 id="h4Selectproduct" runat="server">Select Product Group:</h4>--%>
            
            
            </div>
              </div><!-- /.box -->

            </div><!-- /.col (left) -->

          </div>
          </div>
          <div id="divattendance" runat="server" style="visibility:visible"> 
          <div class="row">
            <div class="col-md-12">
              <div class="box box-info" style="background-color:rgba(255, 255, 255, 0.80);">
               <div class="box-header with-border">
                  <h3 class="box-title">Attendance </h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus "></i></button>
                    <%--<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                  </div>
                </div>
                <div id="divattendancedisplay" runat="server" class="box-body" style="display:none;" >
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Payroll System (Based on):</label></div>
                         <div class="col-lg-2">
                           <asp:DropDownList ID="ddlpayrollsystem" runat="server" Width="100%">
                           <asp:ListItem>select</asp:ListItem>
                           <asp:ListItem>Company-Based</asp:ListItem>
                           <asp:ListItem>Branch-Based</asp:ListItem>
                           </asp:DropDownList>
                           
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Attendance System (Based On):</label></div>
                         <div class="col-lg-2">
                                <asp:DropDownList ID="ddlattendancesystm" runat="server" Width="100%">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Flexi Hours</asp:ListItem>
                                <asp:ListItem>Rigid hours</asp:ListItem>
                                </asp:DropDownList>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Pending Leave Application Check:</label></div>
                         <div class="col-lg-2">
                            <asp:CheckBox ID="chkpendingleaveappli" runat="server" />
                         </div>
                 </div>

                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Number Of Hours Per Day :</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtnoofhrperday" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtnoofhrperday" runat="server"
ErrorMessage="Please enter a valid Hours " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Late Coming Applicable:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="checklatecomingapplicable" runat="server" />
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">OT Multiplier:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtotmultiplier" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtotmultiplier" runat="server"
ErrorMessage="Please enter a valid Multiplier " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>
           
              <%--<h4 id="h4Selectproduct" runat="server">Select Product Group:</h4>--%>
            
            
            </div>
                <div class="box-body" style="display:none;">
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Default Attendance Status:</label></div>
                         <div class="col-lg-2">
                           <asp:DropDownList ID="ddldefultattendncestatus" runat="server" Width="100%">
                           <asp:ListItem>Select</asp:ListItem>
                           <asp:ListItem>Present</asp:ListItem>
                           <asp:ListItem>Holiday</asp:ListItem>
                           <asp:ListItem>Off-Day</asp:ListItem>
                           <asp:ListItem>Leave</asp:ListItem>
                           <asp:ListItem>LWP(Half-Day)</asp:ListItem>
                           <asp:ListItem>LWP(Full-Day)</asp:ListItem>
                           </asp:DropDownList>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">OT Applicable:</label></div>
                         <div class="col-lg-2">
                                <asp:CheckBox ID="chkOTapllicable" runat="server" />
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Monthly Attendance Processed:</label></div>
                         <div class="col-lg-2">
                            <asp:CheckBox ID="chkmonthlyattendance" runat="server" />
                         </div>
                 </div>

                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Core Timing Start:</label></div>
                         <div class="col-lg-2">
                           <cc1:TimeSelector ID="txtcoretimingstart" runat="server" AllowSecondEditing="true">
                 </cc1:TimeSelector>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Core Timing End:</label></div>
                         <div class="col-lg-2">
                         <cc1:TimeSelector ID="txtcoretimimgend" runat="server" AllowSecondEditing="true">
                 </cc1:TimeSelector>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Consider Core for Flexi Half-Days:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkconsidercoreforflexihalfdays" runat="server" />
                         </div>
                 </div>
           
              <%--<h4 id="h4Selectproduct" runat="server">Select Product Group:</h4>--%>
            
            
            </div>
            <div class="box-body" style="display:none;">
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Start Time:</label></div>
                         <div class="col-lg-2">
                         <cc1:TimeSelector ID="txtstarttime" runat="server" AllowSecondEditing="true">
                 </cc1:TimeSelector>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">End Time:</label></div>
                         <div class="col-lg-2">
                         <cc1:TimeSelector ID="txtendtime" runat="server" AllowSecondEditing="true">
                 </cc1:TimeSelector>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Start Time (Including Grace):</label></div>
                         <div class="col-lg-2">
                         <cc1:TimeSelector ID="txtstarttimegrace" runat="server" AllowSecondEditing="true">
                 </cc1:TimeSelector>
                         </div>
                 </div>

                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">No. of Late Comings in a month:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtnoOFlatecomingmonth" runat="server"></asp:TextBox>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">OT Approval Check:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkOtapproval" runat="server" />
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Timesheet Information Check:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chktimesheetinfo" runat="server" />
                         </div>
                 </div>
           
              <%--<h4 id="h4Selectproduct" runat="server">Select Product Group:</h4>--%>
            
            
            </div>
              </div><!-- /.box -->

            </div><!-- /.col (left) -->

          </div>
          </div>
          <div id="divgratutity" runat="server" style="visibility:visible"> 
          <div class="row">
            <div class="col-md-12">
              <div class="box box-info" style="background-color:rgba(255, 255, 255, 0.80);">
               <div class="box-header with-border">
                  <h3 class="box-title">Gratutity </h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus "></i></button>
                    <%--<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                  </div>
                </div>
                <div id="divgratutitydisplay" runat="server" class="box-body" style="display:none;" >
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Min No Of Years:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtminnoOFyear" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtminnoOFyear" runat="server"
ErrorMessage="Please enter a valid Years " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">NoOfDaysSalary:</label></div>
                         <div class="col-lg-2">
                                <asp:TextBox ID="txtNoOfdayssalary" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" ControlToValidate="txtNoOfdayssalary" runat="server"
ErrorMessage="Please enter a valid Days " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">NoOfDaysInMonth Bal:</label></div>
                         <div class="col-lg-2">
                            <asp:TextBox ID="txtnoOfdaysinmonth" runat="server"></asp:TextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtnoOfdaysinmonth" runat="server"
ErrorMessage="Please enter a valid Month " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>
            </div>
              </div><!-- /.box -->

            </div><!-- /.col (left) -->

          </div>
          </div>
          <div id="divindustrial" runat="server" style="visibility:visible"> 
          <div class="row">
            <div class="col-md-12">
              <div class="box box-info" style="background-color:rgba(255, 255, 255, 0.80);">
               <div class="box-header with-border">
                  <h3 class="box-title">Industrial disputes</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus "></i></button>
                    <%--<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                  </div>
                </div>
                <div id="divindustrialdisplay" runat="server" class="box-body" style="display:none;" >
                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">NoofDaysForRetenchment Compensation:</label></div>
                         <div class="col-lg-2">
                           <asp:TextBox ID="txtnoOfdaysformentcompensation" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" ControlToValidate="txtnoOfdaysformentcompensation" runat="server"
ErrorMessage="Please enter a valid Days " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">NoofDaysInMonthForRetenchment Compensation:</label></div>
                         <div class="col-lg-2">
                                <asp:TextBox ID="txtnoOfdaysformentmonthcompensation" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator20" ControlToValidate="txtnoOfdaysformentmonthcompensation" runat="server"
ErrorMessage="Please enter a valid Days " ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Min.Age for Employment Limit Days:</label></div>
                         <div class="col-lg-2">
                            <asp:TextBox ID="txtminageforemployment" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator21" ControlToValidate="txtminageforemployment" runat="server"
ErrorMessage="Please enter a valid Age" ValidationExpression="^(-)?\d+(\.\d\d)?$">
</asp:RegularExpressionValidator>
                         </div>
                 </div>
           
              <%--<h4 id="h4Selectproduct" runat="server">Select Product Group:</h4>--%>
            
            
            </div>
              </div><!-- /.box -->

            </div><!-- /.col (left) -->

          </div>
          </div>
          <div id="divpolicy" runat="server" style="visibility:visible"> 
          <div class="row">
            <div class="col-md-12">
              <div class="box box-info" style="background-color:rgba(255, 255, 255, 0.80);">
               <div class="box-header with-border">
                  <h3 class="box-title">Policy</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus "></i></button>
                    <%--<button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                  </div>
                </div>
                <div id="divpolicydisplay" runat="server" class="box-body" style="display:none;" >
                  <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Revised Amt Editable in Pay Revision:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkrevisedamteditableinpay" runat="server" />
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">LEAR Based on Leaving Date:</label></div>
                         <div class="col-lg-2">
                                <asp:CheckBox ID="chklearbasedonleavingdate" runat="server" />
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Full &Final Salary calculation to be based on Leaving Date:</label></div>
                         <div class="col-lg-2">
                            <asp:CheckBox ID="chkfullandfinalsalary" runat="server" />
                         </div>
                 </div>

                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Allow TDS manually in F&F:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkallowTDSmanually" runat="server" />
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Check Leave Bal. available upto Year End:</label></div>
                         <div class="col-lg-2">
                                <asp:CheckBox ID="chkleavebalavailble" runat="server" />
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">PTDS only on Monthly elements:</label></div>
                         <div class="col-lg-2">
                            <asp:CheckBox ID="chkPTDSonlyonmonthlyelement" runat="server" />
                         </div>
                 </div>
                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Calculate Variable Pay Element:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkcalculatevariable" runat="server" />
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Calculate Prev Mnt LeaveArrear:</label></div>
                         <div class="col-lg-2">
                                <asp:CheckBox ID="chkcalculateprevmnt" runat="server" />
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Round each pay element:</label></div>
                         <div class="col-lg-2">
                            <asp:CheckBox ID="chkroundeachpayelement" runat="server" />
                         </div>
                 </div>
                 <div class="col-lg-12" style="margin-bottom:11px; border-bottom:1px solid #f4f4f4; padding-bottom:11px;">
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">Employee selection allowed during Monthly Salary Posting:</label></div>
                         <div class="col-lg-2">
                           <asp:CheckBox ID="chkemployeeselection" runat="server" />
                         </div>
                        <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;">LE Percent dep on Basic:</label></div>
                         <div class="col-lg-2">
                             <asp:TextBox ID="txtLEpercentdeponbasic" runat="server"></asp:TextBox>
                         </div>
                         <div class="col-lg-2" style="text-align:left; padding-top:7px;"><label style="font-weight:normal;"></label></div>
                         <div class="col-lg-2">
                         </div>
                 </div>
            </div>
              </div><!-- /.box -->

            </div><!-- /.col (left) -->

          </div>
          </div>
       
          <div class="col-md-2 btn-group pull-right" >

                    <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-primary faa-parent animated-hover" onclick="btnSave_Click1"  Width="50%">
                                 <i class="fa fa-save text-white faa-flash animated" ></i>
                                 Save
                      </asp:LinkButton>

                      <asp:LinkButton ID="btnBack" runat="server"  CssClass=" btn btn-warning faa-parent animated-hover" onclick="btnBack_Click" Width="50%">
                                 <i class="fa fa-arrow-left text-white faa-passing-reverse animated" ></i>
                                 Back
                      </asp:LinkButton>

               <%-- <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"  
                    Width="50%" onclick="btnSave_Click1" ></asp:Button>
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary"  
                    Width="50%" onclick="btnBack_Click"   ></asp:Button>--%>
                </div>
        </div>
      </div>
   </div>
   </div>
    </section>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

