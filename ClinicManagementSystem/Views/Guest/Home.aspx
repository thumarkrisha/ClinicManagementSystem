<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClinicManagementSystem.Views.Guest.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../Libs/Bootstrap/css/bootstrap.min.css"/>
</head>
<body>
    <%--<form id="form1" runat="server">
        <div>
        </div>
    </form>--%>


        <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">Clinic</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item">
        <a class="nav-link" href="">Doctors</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="">Laboratorian</a>
      </li>
        <li class="nav-item">
         <a class="nav-link" href="">Receptionist</a>
      </li>
      <li class="nav-item">
         <a class="nav-link" href="../Login.aspx">Login</a>
      </li>
      
    </ul>
    
  </div>
</nav>
     <div class="container-fluid">
        <div class="row" style="background-image:url(../../Assets/Images/home.jpg);height:435px;background-size:cover">
             <div class="col-md-1">

             </div>
            <div class="col-md-5">
                <div class="row" style="height:100px"></div>
                <h2>Your Health is our only Priority</h2>
                <h2>Always Serving You and Taking Care</h2>
                <p class="h6">Our Clinic has been created in 2019 by a group of persons </p>
                <p class="h6">who wanted to really take care of the health of the population.</p><br />
                <button class="btn btn-primary">Contact Us</button>
                <button class="btn border-primary text-primary bg-transparent">Feed Back</button>
            </div>
        </div>
        <div class="row bg-primary">
            <div class="row" style="height:20px"></div>
                <div class="row">
                    <div class="col-md-3 bg-light offset-1 rounded-3">
                       <div class="row ">
                           <div class="col-2">
                               <img src="../../Assets/Images/surgery.png" style="width: 40px; height: 40px; object-fit: contain;" />
                           </div>
                           <div class="col-7">
                               <h5 class="text-center">Surgery</h5>
                               <p class="h6">The Clinic has a Surgery Department with heighly qualified Doctors.</p>
                           </div>
                       </div>
                   </div>
                   <div class="col-md-3 bg-light offset-1 rounded-3">
                       <div class="row ">
                            <div class="col-2">
                                <img src="../../Assets/Images/surgery.png" style="width: 40px; height: 40px; object-fit: contain;" />
                            </div>
                            <div class="col-7">
                                <h5 class="text-center">Urology</h5>
                                <p class="h6">The Clinic has a Surgery Department with heighly qualified Doctors.</p>
                            </div>
                        </div>
                   </div>
                   <div class="col-md-3 bg-light offset-1 rounded-3">
                       <div class="row ">
                            <div class="col-2">
                                <img src="../../Assets/Images/surgery.png" style="width: 40px; height: 40px; object-fit: contain;" />
                            </div>
                            <div class="col-7">
                                <h5 class="text-center">Ophtalmology</h5>
                                <p class="h6">The Clinic has a Surgery Department with heighly qualified Doctors.</p>
                            </div>
                        </div>
                   </div>
                 </div>
         
            <div class="row" style="height:20px"></div>

        </div>
    </div>
</body>
</html>
