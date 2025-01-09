<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClinicManagementSystem.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Libs/Bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../CSS/Login.css" />
</head>
<body style="background-image:url(../Assets/Images/login.jpg);background-size:cover">

    <div class="container-fluid">
        <div class="row" style="height:120px"></div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-5 form-container ">
                <h1 class="T text-center p-1">MedicoCare Clinic</h1>
                <form  id="form1" runat="server">
                  <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Email address</label>    
                      <asp:RequiredFieldValidator ID="EmailRequired" ControlToValidate="Email" runat="server" ErrorMessage="Email is required." CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailFormatValidator" ControlToValidate="Email" runat="server" ErrorMessage="Invalid email format." ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" CssClass="text-danger"></asp:RegularExpressionValidator>
                     <asp:TextBox ID="Email" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>
                  <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Password</label>
                    <asp:RequiredFieldValidator ID="PasswordRequired" ControlToValidate="Password" runat="server" ErrorMessage="Password is required." CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                  </div>
                  <div class="mb-3 form-check">
                   <label for="RoleCb" class="form-label">Role</label>
                      <asp:DropDownList runat="server" ID="RoleCb" class="form-control">
                          <asp:ListItem>---Select Role---</asp:ListItem>
                          <asp:ListItem>Admin</asp:ListItem>
                          <asp:ListItem>Doctor</asp:ListItem>
                          <asp:ListItem>Laboratorian</asp:ListItem>
                          <asp:ListItem>Receptionist</asp:ListItem>
                           <asp:ListItem>Patient</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                    <div class="d-grid">
                        <asp:Label ID="ErrMsg" runat="server" class="text-danger"></asp:Label><br />
                        <asp:Button ID="LoginBtn" runat="server" class="btn btn-primary btn-block" Text="Login" OnClick="LoginBtn_Click"></asp:Button>
              
                    </div>
                  
                </form>
            </div>
            <div class="col-md-6"></div>
        </div>
    </div>
    
</body>
</html>
