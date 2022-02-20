<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="content-header">
    <h1 class="AdProHead"> <i class="fa fa-key faa-pulse animated"></i> Employee TimeSheet </h1>
</section>
<div class="clearfix"></div>
<section class="content">
    <asp:UpdatePanel  ID="UpdPnl" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-md-offset-2 col-md-8">
                <div class="box box-default" style="background-color:rgba(255, 255, 255, 0.80);">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-md-offset-1 col-md-8">
                                <label class="control-label">Old Password <span class="text-red">*</span></label>
                                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" placeholder="Enter Old Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-1 col-md-8">
                                <label class="control-label">New Password <span class="text-red">*</span></label>
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="Enter New Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-1 col-md-8">
                                <label class="control-label">Confirm Password <span class="text-red">*</span></label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm New Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="box-footer">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            <asp:LinkButton ID="btnChangePassword" runat="server" CssClass="btn btn-info pull-right" onclick="btnChangePassword_Click"  >
                                <i class="fa fa-key"></i> Change password
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
<center>
    <cc1:modalupdateprogress ID="ModalUpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdPnl">
        <ProgressTemplate>
            <asp:Image ID="Image1" alt="" ImageUrl="~/Images/progressbar1.gif" runat="server" ImageAlign="Middle" />
        </ProgressTemplate>
    </cc1:modalupdateprogress>
</center>

<%--
<div style="float:left; width:100%; background-color:#d9ffff; min-height:675px; height:auto; padding-left:11px; padding-right:11px; ">
<div class='group-header'>
    <div class='row-fluid'>
        <div class='span6 offset3'>
            <div class='text-center'>
                <h2>Change Password</h2>
                
            </div>
        </div>
    </div>
</div>
<div class="col-md-12">
<div class="col-md-2"></div>
<div class="col-md-8">
              <!-- Horizontal Form -->
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">All field Are Required</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form class="form-horizontal">
                  <div class="box-body">
                    <div class="form-group">
                      <label for="inputEmail3" class="col-sm-4 control-label">Enter Old Password</label>
                      <div class="col-sm-8">
                      <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" placeholder="Enter Old Password" TextMode="Password"></asp:TextBox>
                       
                      </div>
                    </div>
                     <br />
                    <br />
                    <div class="form-group">
                      <label for="inputPassword3" class="col-sm-4 control-label">Enter New Password</label>
                      <div class="col-sm-8">
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="Enter New Password" TextMode="Password"></asp:TextBox>
                      </div>
                    </div>
                    <br />
                    <br />
                   
                     <div class="form-group">
                      <label for="inputPassword3" class="col-sm-4 control-label">Re-Enter New Password</label>
                      <div class="col-sm-8">
                        <asp:TextBox ID="txtReEnter" runat="server" CssClass="form-control" placeholder="Re-Enter New Password" TextMode="Password"></asp:TextBox>
                      </div>
                    </div>
                    
                  </div><!-- /.box-body -->
                  <div class="box-footer">
                      <asp:Label ID="lblMessage" runat="server"></asp:Label>
                   <asp:LinkButton ID="lnkSearch" runat="server" CssClass="btn btn-info pull-right" onclick="lnkSearch_Click"  >
                        <i class="fa fa-key"></i>
                        Change password
                     </asp:LinkButton>
                    
                  </div><!-- /.box-footer -->
                </form>
              </div><!-- /.box -->
              <!-- general form elements disabled -->
              <!-- /.box -->
            </div>

</div>



</div> 

</ContentTemplate>
</asp:UpdatePanel>--%>

</asp:Content>

