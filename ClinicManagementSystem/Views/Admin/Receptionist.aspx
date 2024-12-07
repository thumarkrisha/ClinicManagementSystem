﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Receptionist.aspx.cs" Inherits="ClinicManagementSystem.Views.Admin.Recepionist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
        <div class="container-fluid">
    <div class="row">
         <div class="col-md-4">
             <h2>Receptionist Detail</h2>
             <form>
              <div class="mb-3">
                <label for="RecNameb" class="form-label">Name</label>
                <input type="text" runat="server" class="form-control" id="RecNameTb" required="required"/>
              </div>

              <div class="mb-3">
                <label for="RecEmailTb" class="form-label">Email</label>
                <input type="text" runat="server" class="form-control" id="RecEmailTb" required="required"/>
              </div>

              <div class="mb-3">
                <label for="PasswordTb" class="form-label">Password</label>
                <input type="password" runat="server" class="form-control" id="PasswordTb" required="required"/>
              </div>

              <div class="mb-3">
                 <label for="PhoneTb" class="form-label">Phone</label>
                 <input type="text" runat="server" class="form-control" id="PhoneTb" required="required"/>
              </div>

              <div class="mb-3">
                  <label for="AddressTb" class="form-label">Address</label>
                  <input type="text" runat="server" class="form-control" id="AddressTb" required="required"/>
              </div>

              <asp:Label ID="ErrMsg" runat="server" class="text-danger"></asp:Label><br />
              <asp:Button ID="EditBtn" runat="server" class="btn btn-warning" Text="Edit"></asp:Button>
              <asp:Button ID="SaveBtn" runat="server" class="btn btn-primary" Text="Save" OnClick="SaveBtn_Click"></asp:Button>
              <asp:Button ID="DeleteBtn" runat="server" class="btn btn-danger" Text="Delete"></asp:Button>
            </form>
         </div> 
         <div class="col-md-8">
             <div class="row">
                 <div class="col">
                     <img src="../../Assets/Images/receptionist.jpg" width="100%" height="300px" class="rounded-3"/>
                 </div>
             </div>
             <div class="row">
                  <div class="col">
                     <h1>Receptionist Details</h1>
                      <asp:GridView ID="ReceptionistGV" class="table table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                          <AlternatingRowStyle BackColor="White" />
                          <EditRowStyle BackColor="#2461BF" />
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#EFF3FB" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#F5F7FB" />
                          <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                          <SortedDescendingCellStyle BackColor="#E9EBEF" />
                          <SortedDescendingHeaderStyle BackColor="#4870BE" />
                      </asp:GridView>
                 </div>
             </div>
         </div>
    </div>
</div>
</asp:Content>
