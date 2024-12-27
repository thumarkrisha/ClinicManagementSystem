<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="ClinicManagementSystem.Views.Admin.Doctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
             <div class="col-md-3">
                 <h2>Doctors Detail</h2>
                 <form>
                  <div class="mb-3">
                    <label for="DocNameb" class="form-label">Doctor Name</label>
                    <asp:RequiredFieldValidator ID="ReqName" ControlToValidate="DocNameTb" SetFocusOnError="True" ErrorMessage="Name is required" CssClass="text-danger" runat="server" Display="Dynamic" />
                    <asp:TextBox ID="DocNameTb" runat="server" CssClass="form-control"></asp:TextBox>

                  </div>

                  <div class="mb-3">
                    <label for="DocPhoneTb" class="form-label">Phone Number</label>
                      <asp:RequiredFieldValidator ID="ReqPhone" ControlToValidate="DocPhoneTb" SetFocusOnError="True" ErrorMessage="Phone number is required" CssClass="text-danger" runat="server" Display="Dynamic" />
                      <asp:RegularExpressionValidator ID="RegPhone" ControlToValidate="DocPhoneTb" SetFocusOnError="True" ValidationExpression="^\d{10}$" Display="Dynamic" ErrorMessage="Invalid phone number" CssClass="text-danger" runat="server" />       
                    <asp:TextBox ID="DocPhoneTb" runat="server" CssClass="form-control"></asp:TextBox>
                         
                  </div>

                  <div class="mb-3">
                    <label for="DocExptb" class="form-label">Experience</label>
                        <asp:RequiredFieldValidator ID="ReqExp" ControlToValidate="DocExpTb" SetFocusOnError="True" ErrorMessage="Experience is required" CssClass="text-danger" runat="server" Display="Dynamic" />
                        <asp:RangeValidator ID="RangeExp" ControlToValidate="DocExpTb" SetFocusOnError="True" MinimumValue="0" MaximumValue="100" Type="Integer" ErrorMessage="Experience must be between 0 and 100" CssClass="text-danger" runat="server" Display="Dynamic"/>
                        <asp:TextBox ID="DocExpTb" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="mb-3">
                     <label for="SpecialisationTb" class="form-label">Specialisation</label>
                        <asp:RequiredFieldValidator ID="ReqSpecialisation" ControlToValidate="SpecialisationTb" SetFocusOnError="True" ErrorMessage="Specialisation is required" CssClass="text-danger" runat="server" Display="Dynamic"/>
                 <asp:TextBox ID="SpecialisationTb" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="mb-3">
                    <label for="PasswordTb" class="form-label">Password</label>
                   
                        <asp:RequiredFieldValidator ID="ReqPassword" ControlToValidate="PasswordTb" SetFocusOnError="True" ErrorMessage="Password is required" CssClass="text-danger" runat="server" Display="Dynamic"/>
                        <asp:RegularExpressionValidator ID="RegPassword" ControlToValidate="PasswordTb" SetFocusOnError="True" ValidationExpression=".{6,}" Display="Dynamic" ErrorMessage="Password must be at least 6 characters" CssClass="text-danger" runat="server" />
                         <asp:TextBox ID="PasswordTb" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                <div class="mb-3">
                  <label for="GenderCb" class="form-label">Gender</label>
                     <asp:RequiredFieldValidator ID="ReqGender" ControlToValidate="GenderCb" SetFocusOnError="True" Display="Dynamic" InitialValue="" ErrorMessage="Please select a gender" CssClass="text-danger" runat="server" />
                    <asp:DropDownList ID="GenderCb" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Select Gender" Value="" />
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                        </asp:DropDownList>
                       
                </div>

                <div class="mb-3">
                  <label for="AddressTb" class="form-label">Address</label>
                  
                        <asp:RequiredFieldValidator ID="ReqAddress" ControlToValidate="AddressTb" SetFocusOnError="True" Display="Dynamic" ErrorMessage="Address is required" CssClass="text-danger" runat="server" />
               <asp:TextBox ID="AddressTb" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                  <label for="DOBTb" class="form-label">Date of Birth</label>
                        <asp:RequiredFieldValidator ID="ReqDOB" ControlToValidate="DOBTb" SetFocusOnError="True" Display="Dynamic" ErrorMessage="Date of Birth is required" CssClass="text-danger" runat="server" />
                                     <asp:TextBox ID="DOBTb" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="mb-3">
                   <label for="EmailTb" class="form-label">Email</label>
                        <asp:RequiredFieldValidator ID="ReqEmail" ControlToValidate="EmailTb" SetFocusOnError="True" Display="Dynamic" ErrorMessage="Email is required" CssClass="text-danger" runat="server" />
                        <asp:RegularExpressionValidator ID="RegEmail" ControlToValidate="EmailTb" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" ErrorMessage="Invalid email address" CssClass="text-danger" runat="server" />
                <asp:TextBox ID="EmailTb" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
                  
              <asp:Label ID="ErrMsg" runat="server" class="text-danger"></asp:Label><br />
              <asp:Button ID="EditBtn" runat="server" class="btn btn-warning" Text="Edit" OnClick="EditBtn_Click"  ></asp:Button>
              <asp:Button ID="SaveBtn" runat="server" class="btn btn-primary" Text="Save" OnClick="SaveBtn_Click" ></asp:Button>
              <asp:Button ID="DeleteBtn" runat="server" class="btn btn-danger" Text="Delete" OnClick="DeleteBtn_Click"></asp:Button>
                </form>
             </div>
             <div class="col-md-9">
                 <div class="row">
                     <div class="col">
                         <img src="../../Assets/Images/doctor2.jpg" width="100%" height="300px" class="rounded-3"/>
                     </div>
                 </div>
                 <div class="row">
                      <div class="col">
                         <h1>Doctors Details</h1>
                          <asp:GridView ID="DoctorsGV" class="table table-hover" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="DoctorsGV_SelectedIndexChanged" OnRowDataBound="DoctorsGV_RowDataBound">
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
