using ClinicManagementSystem.Views.Receptionist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Doctors
{
    public partial class Reports : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack) // Only load data on the first page load
            {
                GetPatient();
            }
            if (Session["uid"] == null)
            {
                Response.Redirect("~/Views/Guest/Home.aspx");
            }
        }
        private void GetPatient()
        {
            string query = "select * from PatientTbl";
            ddlPatients.DataTextField = con.GetDatas(query).Columns["PatName"].ToString();
            ddlPatients.DataValueField = con.GetDatas(query).Columns["PatId"].ToString();
            ddlPatients.DataSource = con.GetDatas(query);
            ddlPatients.DataBind();
            ddlPatients.Items.Insert(0, new ListItem("Select Patient", "0"));
        }
        protected void ddlPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPatientId = ddlPatients.SelectedValue;
            if (selectedPatientId != "0")
            {
                LoadReportsForPatient(selectedPatientId);
            }
            else
            {
                gvReports.DataSource = null;
                gvReports.DataBind();
            }
        }
        private void LoadReportsForPatient(string patientId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HP\\Documents\\ClinicManagementDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string query = "SELECT Id, ReportName, ReportType, UploadDate, Description FROM PatientReportsTbl WHERE PatientId = @PatientId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PatientId", patientId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            gvReports.DataSource = reader;
                            gvReports.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading reports: " + ex.Message;
            }
        }
        protected void gvReports_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int reportId = Convert.ToInt32(e.CommandArgument);
                DownloadReport(reportId);
            }
        }

        private void DownloadReport(int reportId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HP\\Documents\\ClinicManagementDB.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    string query = "SELECT ReportName, ReportType, ReportData FROM PatientReportsTbl WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", reportId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fileName = reader["ReportName"].ToString();
                                string fileType = reader["ReportType"].ToString();
                                byte[] fileData = (byte[])reader["ReportData"];
                                Response.Write(fileData);
                                Response.Clear();
                                Response.ContentType = fileType;
                                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                                Response.BinaryWrite(fileData);
                                Response.End();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error downloading report: " + ex.Message;
            }
        }

    }
}