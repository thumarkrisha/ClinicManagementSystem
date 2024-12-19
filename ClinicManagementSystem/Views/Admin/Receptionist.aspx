<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Receptionist.aspx.cs" Inherits="ClinicManagementSystem.Views.Admin.Recepionist" %>
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
                  <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="RecNameTb"
                        ErrorMessage="Name is required" CssClass="text-danger" Display="Dynamic" setFocusOnError="True" />
                   <asp:TextBox ID="RecNameTb" CssClass="form-control" runat="server"></asp:TextBox>

              </div>

              <div class="mb-3">
                <label for="RecEmailTb" class="form-label">Email</label>
                   <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="RecEmailTb"
                        ErrorMessage="Email is required" CssClass="text-danger" Display="Dynamic" setFocusOnError="True" />
                    <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="RecEmailTb"
                        ErrorMessage="Invalid email format" CssClass="text-danger" Display="Dynamic"
                        ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" setFocusOnError="True" />
                    <asp:TextBox ID="RecEmailTb" CssClass="form-control" runat="server"></asp:TextBox>

              </div>

              <div class="mb-3">
                <label for="PasswordTb" class="form-label">Password</label>
                   <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="PasswordTb"
                        ErrorMessage="Password is required" CssClass="text-danger" Display="Dynamic" setFocusOnError="True" />
                    <asp:RegularExpressionValidator ID="PasswordValidator" runat="server" ControlToValidate="PasswordTb"
                        ErrorMessage="Password must be at least 6 characters long" setFocusOnError="True"
                        ValidationExpression="^.{6,}$" CssClass="text-danger" Display="Dynamic" />
                    <asp:TextBox ID="PasswordTb" CssClass="form-control" runat="server" ></asp:TextBox>
              </div>

              <div class="mb-3">
                 <label for="PhoneTb" class="form-label">Phone</label>
                  <asp:RequiredFieldValidator ID="PhoneRequired" runat="server" ControlToValidate="PhoneTb"
                        ErrorMessage="Phone number is required" CssClass="text-danger" Display="Dynamic" setFocusOnError="True" />
                    <asp:RegularExpressionValidator ID="PhoneValidator" runat="server" ControlToValidate="PhoneTb"
                        ErrorMessage="Phone number must be 10 digits" setFocusOnError="True"
                        ValidationExpression="^\d{10}$" CssClass="text-danger" Display="Dynamic" />
                    <asp:TextBox ID="PhoneTb" CssClass="form-control" runat="server"></asp:TextBox>

              </div>

              <div class="mb-3">
                  <label for="AddressTb" class="form-label">Address</label>
                  <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="AddressTb"
                        ErrorMessage="Address is required" CssClass="text-danger" Display="Dynamic" setFocusOnError="True" />
                 <asp:TextBox ID="AddressTb" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <asp:Label ID="ErrMsg" runat="server" class="text-danger"></asp:Label><br />
              <asp:Button ID="EditBtn" runat="server" class="btn btn-warning" Text="Edit" OnClick="EditBtn_Click" ></asp:Button>
              <asp:Button ID="SaveBtn" runat="server" class="btn btn-primary" Text="Save" OnClick="SaveBtn_Click"></asp:Button>
              <asp:Button ID="DeleteBtn" runat="server" class="btn btn-danger" Text="Delete" OnClick="DeleteBtn_Click"></asp:Button>
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
                      <asp:GridView ID="ReceptionistGV" class="table table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ReceptionistGV_SelectedIndexChanged">
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
