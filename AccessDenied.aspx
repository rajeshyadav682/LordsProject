<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="AccessDenied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            401 Error Page
          </h1>
        </section>
           <!-- Main content -->
        <section class="content">
          <div class="error-page">
            <h2 class="headline text-yellow"> 401</h2>
            <div class="error-content">
              <h3><i class="fa fa-warning text-yellow"></i> Oops! Access Denied.</h3>
                  <h4>
                      It seems like you don't have permission to access this page.
                  </h4>
            </div><!-- /.error-content -->
          </div><!-- /.error-page -->
        </section><!-- /.content -->
        </div>
    <%--<section class="content">
          <div class="error-content">
            <h1 class="headline text-yellow"> No Record Available For Month</h1>
          </div><!-- /.error-page -->
        </section><!-- /.content -->--%>
</asp:Content>

