    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Receptionist/ReceptionistMaster.Master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="ClinicManagementSystem.Views.Receptionist.Patients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
        <div class="container-fluid">
    <div class="row">
         <div class="col-md-3">
             <h2>Patient Detail</h2>
             <form>
              <div class="mb-3">
                <label for="PatNameTb" class="form-label">Name</label>
               <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="PatNameTb" ErrorMessage="Name is required." CssClass="text-danger" Display="Dynamic" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                <asp:TextBox ID="PatNameTb" runat="server" CssClass="form-control"></asp:TextBox>
              </div>

              <div class="mb-3">
                <label for="PatPhoneTb" class="form-label">Phone</label>
                    <asp:RequiredFieldValidator ID="PhoneRequired" runat="server" ControlToValidate="PatPhoneTb" ErrorMessage="Phone number is required." CssClass="text-danger" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="PhoneRegex" runat="server" ControlToValidate="PatPhoneTb" ErrorMessage="Invalid phone number. Must be 10 digits." Display="Dynamic" SetFocusOnError="true" CssClass="text-danger" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="PatPhoneTb" runat="server" CssClass="form-control"></asp:TextBox>          
              </div>

               <div class="mb-3">
                  <label for="GenderCb" class="form-label">Gender</label>
                    <asp:RequiredFieldValidator ID="GenderRequired" runat="server" ControlToValidate="GenderCb" Display="Dynamic" SetFocusOnError="true" InitialValue="" ErrorMessage="Gender is required." CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="GenderCb" CssClass="form-control" runat="server">
                            <asp:ListItem Value="" Text="Select Gender"></asp:ListItem>
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                    </asp:DropDownList>

              <div class="mb-3">
               <label for="DOBTb" class="form-label">DOB</label>
               <asp:RequiredFieldValidator ID="DOBRequired" runat="server" ControlToValidate="DOBTb" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Date of Birth is required." CssClass="text-danger"></asp:RequiredFieldValidator>
              <asp:TextBox ID="DOBTb" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>

              <div class="mb-3">
                 <label for="AddressTb" class="form-label">Address</label>
                  <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="AddressTb" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Address is required." CssClass="text-danger"></asp:RequiredFieldValidator>
                 <asp:TextBox ID="AddressTb" runat="server" CssClass="form-control"></asp:TextBox>
              </div>

             <div class="mb-3">
                  <label for="AllergyTb" class="form-label">Allergies</label>
                  <asp:TextBox  CssClass="form-control" ID="AllergyTb" runat="server"/>
                </div>
             
              <div class="mb-3">
               <label for="EmailTb" class="form-label">Email</label>
                    <asp:RequiredFieldValidator ID="ReqEmail" ControlToValidate="EmailTb" SetFocusOnError="True" Display="Dynamic" ErrorMessage="Email is required" CssClass="text-danger" runat="server" />
                    <asp:RegularExpressionValidator ID="RegEmail" ControlToValidate="EmailTb" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" ErrorMessage="Invalid email address" CssClass="text-danger" runat="server" />
                     <asp:TextBox ID="EmailTb" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
            
            </div>

                  <div class="mb-3">
                   <label for="PasswordTb" class="form-label">Password</label>
  
                       <asp:RequiredFieldValidator ID="ReqPassword" ControlToValidate="PasswordTb" SetFocusOnError="True" ErrorMessage="Password is required" CssClass="text-danger" runat="server" Display="Dynamic"/>
                       <asp:RegularExpressionValidator ID="RegPassword" ControlToValidate="PasswordTb" SetFocusOnError="True" ValidationExpression=".{6,}" Display="Dynamic" ErrorMessage="Password must be at least 6 characters" CssClass="text-danger" runat="server" />
                        <asp:TextBox ID="PasswordTb" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>

               <asp:Label ID="ErrMsg" runat="server" class="text-danger"></asp:Label><br />
                 <asp:Button ID="EditBtn" runat="server" class="btn btn-warning" Text="Edit" OnClick="EditBtn_Click"   ></asp:Button>
                 <asp:Button ID="SaveBtn" runat="server" class="btn btn-primary" Text="Save" OnClick="SaveBtn_Click"  ></asp:Button>
                 <asp:Button ID="DeleteBtn" runat="server" class="btn btn-danger" Text="Delete" OnClick="DeleteBtn_Click" ></asp:Button>
              
            </form>
         </div>
         <div class="col-md-9">
             
             <div class="row">
                  <div class="col">
                     <h1>Patient List</h1>
                      <asp:GridView ID="PatientList" class="table table-hover" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PatientList_SelectedIndexChanged" OnRowDataBound="PatientList_RowDataBound">
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
