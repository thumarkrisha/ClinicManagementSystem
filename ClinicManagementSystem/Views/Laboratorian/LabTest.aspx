<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Laboratorian/LaboratorianMaster.Master" AutoEventWireup="true" CodeBehind="LabTest.aspx.cs" Inherits="ClinicManagementSystem.Views.Laboratorian.LabTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
        <div class="container-fluid">
            <div class="row" style="height:50px"></div>
    <div class="row">
         <div class="col-md-4">
             <h2>Laboratory Test Detail</h2>
             <form>
              <div class="mb-3">
                <label for="LabNameTb" class="form-label">Name</label>
                <asp:RequiredFieldValidator ID="NameRequiredValidator" runat="server" ControlToValidate="TestNameTb" ErrorMessage="Name is required." CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TestNameTb" runat="server" CssClass="form-control"></asp:TextBox>

              </div>

              <div class="mb-3">
                <label for="TestCostTb" class="form-label">Test Cost</label>
                  <asp:RequiredFieldValidator ID="CostRequiredValidator" runat="server" ControlToValidate="TestCostTb" ErrorMessage="Cost is required." CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="CostRegexValidator" runat="server" ControlToValidate="TestCostTb" 
                            ErrorMessage="Cost must be a valid number." CssClass="text-danger" 
                            ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="TestCostTb" runat="server" CssClass="form-control"></asp:TextBox>

              </div>

            <div class="row" style="height:50px"></div>
            

               <asp:Label ID="ErrMsg" runat="server" class="text-danger"></asp:Label><br />
                 <asp:Button ID="EditBtn" runat="server" class="btn btn-warning" Text=" Edit " OnClick="EditBtn_Click" ></asp:Button>
                 <asp:Button ID="SaveBtn" runat="server" class="btn btn-primary" Text=" Save " OnClick="SaveBtn_Click" ></asp:Button>
                 <asp:Button ID="DeleteBtn" runat="server" class="btn btn-danger" Text=" Delete " OnClick="DeleteBtn_Click"  ></asp:Button>
              
            </form>
         </div>
         <div class="col-md-8">
             <div class="row">
                 <div class="col">
                     <img src="../../Assets/Images/lab.png" width="100%" height="300px" class="rounded-3"/>
                 </div>
             </div>
             <div class="row">
                  <div class="col">
                     <h1>Laborator Test Details</h1>
                      <asp:GridView ID="LabTestGV" class="table table-hover" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="LabTestGV_SelectedIndexChanged" >
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
