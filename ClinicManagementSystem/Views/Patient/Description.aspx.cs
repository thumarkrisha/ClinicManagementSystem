using ClinicManagementSystem.Views.Receptionist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Patient
{
    public partial class Description : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions(); 
            if (Session["uid"] == null)
            {
                Response.Redirect("~/Views/Guest/Home.aspx");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    
                    if (FileUpload1.HasFile)
                    {
                        string fileName = FileUpload1.FileName;
                        string fileType = FileUpload1.PostedFile.ContentType;

                        // Convert file to byte array
                        byte[] fileData;
                        using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                        }


                        DateTime UploadDate = DateTime.Now; // Current date
                        string formattedDate = UploadDate.ToString("yyyy-MM-dd");

                        // Save file details to the database
                        string patientID = Session["uid"].ToString();
                        string description = txtDescription.Text.Trim();

                        //Response.Write(RName);
                        string query = "INSERT INTO PatientReportsTbl (PatientId, ReportName, ReportType, ReportData, UploadDate, Description) " +
                                "VALUES (@PatientId, @ReportName, @ReportType, @ReportData, @UploadDate, @Description)";

                        // Execute query with parameters
                        using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HP\\Documents\\ClinicManagementDB.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@PatientId", patientID);
                                cmd.Parameters.AddWithValue("@ReportName", fileName);
                                cmd.Parameters.AddWithValue("@ReportType", fileType);
                                cmd.Parameters.AddWithValue("@ReportData", fileData);
                                cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Description", description);

                                cmd.ExecuteNonQuery();
                            }
                        }


                        lblMessage.Text = "Report uploaded successfully!";
                    }
                    else
                    {
                        lblMessage.Text = "Please select a report to upload.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        

        protected void ValidateFileType(object source, ServerValidateEventArgs args)
        {
            string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (fileExtension == ".pdf" || fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}