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
                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                  </div>
                  <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Password</label>
                    <input type="password" class="form-control" id="exampleInputPassword1">
                  </div>
                  <div class="mb-3 form-check">
                    <input type="radio" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Check me out</label>
                  </div>

                    <div class="d-grid">
                        <button type="submit" class="btn btn-primary btn-block">Login</button>
                    </div>
                  
                </form>
            </div>
            <div class="col-md-6"></div>
        </div>
    </div>
    
</body>
</html>
