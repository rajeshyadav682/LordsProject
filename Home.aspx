<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Payroll</title>

    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/common.css" rel="stylesheet" />
    <link href="css/backgroundSlider.css" rel="stylesheet" />
    <script type ="text/javascript">  
        window.onload = window.history.forward(0);  //calling function on window onload
    </script>
  
</head>
<body class="login_page">
    <div class="login_header"><a href="#" target="_blank"><%--<img src="images/logo.png"/>--%> Payroll</a></div>
    <ul class="cb-slideshow">
        <li><span>Image 01</span><div><h3></h3></div></li>
        <li><span>Image 02</span><div><h3></h3></div></li>
        <li><span>Image 03</span><div><h3></h3></div></li>
        <li><span>Image 04</span><div><h3></h3></div></li>
        <li><span>Image 05</span><div><h3></h3></div></li>
        <li><span>Image 06</span><div><h3></h3></div></li>       
    </ul>
    <div class="login_form">
        <p class="m-0 p-5">Sign in to your account</p>
        <form id="form1" runat="server">
            <div class="form-group mt-15 mb-15">
                <asp:TextBox ID="txtUserName" runat="server" Placeholder="User ID" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group mb-15">
                <asp:TextBox ID="txtPassword" runat="server" Placeholder="Password" TextMode="Password" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group text-c">
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary signin " OnClick="btnLogin_Click" Text="Login" />
            </div>
        </form>
    </div>
    <div class="login_footer p-10">Copyright @ 2018 <a href="http://corporateserve.com/" target="_blank"> Corporate Serve </a>. All rights reserved</div>
    
    <script type ="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
</body>
</html>
