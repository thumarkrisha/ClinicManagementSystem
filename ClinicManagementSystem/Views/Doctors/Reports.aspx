<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Doctors/DoctorMaster.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="ClinicManagementSystem.Views.Doctors.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        /* Custom border styling for the table */
        .table-bordered th, 
        .table-bordered td {
            border: 2px solid #dee2e6 !important; /* Slightly thicker border */
        }
        .table-hover tbody tr:hover {
            background-color: #f8f9fa; /* Light hover effect */
        }
        .gridview-container {
            overflow-x: auto; /* Ensure responsiveness for horizontal scroll */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container mt-5">
        <!-- Error Message -->
        <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

        <!-- Patient Selection Dropdown -->
        <div class="form-group row">
            <label for="ddlPatients" class="col-sm-3 col-form-label font-weight-bold">Select Patient:</label>
            <div class="col-sm-6">
                <asp:DropDownList ID="ddlPatients" runat="server" AutoPostBack="true" CssClass="form-control" 
                    OnSelectedIndexChanged="ddlPatients_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>

        <!-- Reports Table -->
        <div class="gridview-container mt-4">
            <h5 class="mb-3 font-weight-bold">Patient Reports</h5>
            <asp:GridView ID="gvReports" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvReports_RowCommand">
                <Columns>
                    
                    <asp:BoundField DataField="ReportName" HeaderText="Report Name" />
                    
                    <asp:BoundField DataField="ReportType" HeaderText="Report Type" />
                   
                    <asp:BoundField DataField="UploadDate" HeaderText="Upload Date" DataFormatString="{0:yyyy-MM-dd}" />
                   
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                   
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-primary btn-sm"
                                CommandName="Download" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
