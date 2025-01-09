<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="Description.aspx.cs" Inherits="ClinicManagementSystem.Views.Patient.Description" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    
        <div class="container mt-5">
            <h3 class="text-center">Upload Medical Report</h3>
            <div class="card shadow-lg p-4">
                <div class="form-group">
                    <label for="Description">Description:</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"
                        placeholder="Describe the issue or purpose of the report"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="DescriptionValidator" runat="server" ControlToValidate="txtDescription"
                        ErrorMessage="Description is required." CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="FileUpload">Upload Report:</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                    <asp:RequiredFieldValidator ID="FileUploadValidator" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="Please select a report to upload." CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="FileTypeValidator" runat="server" ErrorMessage="Only PDF, PNG, or JPEG files are allowed."
                        CssClass="text-danger" ControlToValidate="FileUpload1" OnServerValidate="ValidateFileType"></asp:CustomValidator>
                </div>

                <div class="text-center">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload Report" CssClass="btn btn-primary" OnClick="btnUpload_Click" />
                </div>

                <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3"></asp:Label>
            </div>
        </div>
    
</asp:Content>
