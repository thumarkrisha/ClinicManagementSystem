<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Doctors/DoctorMaster.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="ClinicManagementSystem.Views.Doctors.Prescriptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
        <div class="container-fluid">
    <div class="row">
         <div class="col-md-4">
             <h2>Prescription Detail</h2>
             <form>
              <div class="mb-3">
                <label for="PatientCb" class="form-label">Patient</label>
                <asp:DropDownList ID="PatientCb" class="form-control" runat="server">
                     
                 </asp:DropDownList>
              </div>

              <div class="mb-3">
                <label for="MedicinesTb" class="form-label">Medicines</label>
                <input type="text" class="form-control" id="MedicinesTb" runat="server"/>
              </div>

              <div class="mb-3">
                <label for="LabTestCb" class="form-label">LabTest</label>
                <asp:DropDownList ID="LabTestCb" class="form-control" runat="server">
     
                 </asp:DropDownList>
              </div>

             <div class="mb-3">
                  <label for="CostTb" class="form-label">Cost</label>
                  <input type="text" class="form-control" id="CostTb" runat="server"/>
             </div>
               
            <div class="d-grid">
               <asp:Label ID="ErrMsg" runat="server" class="text-danger"></asp:Label><br />
                  <asp:Button ID="SaveBtn" runat="server" class="btn btn-warning btn-block text-white" Text="Save Prescription" OnClick="SaveBtn_Click"  ></asp:Button>
              </div>
            </form>
         </div>
         <div class="col-md-8">
             
             <div class="row">
                  <div class="col">
                     <h1>Presciption Details</h1>
                      <asp:GridView ID="PrescriptionGV" class="table table-hover" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" >
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
