using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Doctors
{
    public partial class Prescriptions : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack) // Only load data on the first page load
            {
                showPrescription();
                GetTest();
                GetPatient();
            }
        }
        private void showPrescription()
        {
            string query = "select * from PrescriptionTbl";
            PrescriptionGV.DataSource = con.GetDatas(query);
            PrescriptionGV.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void GetTest()
        {
            string query = "select * from LabTestTbl";
            LabTestCb.DataTextField = con.GetDatas(query).Columns["TestName"].ToString();
            LabTestCb.DataValueField = con.GetDatas(query).Columns["TestId"].ToString();
            LabTestCb.DataSource = con.GetDatas(query);
            LabTestCb.DataBind();
            LabTestCb.Items.Insert(0, new ListItem("Select Test", "0"));
        }

        private void GetPatient()
        {
            string query = "select * from PatientTbl";
            PatientCb.DataTextField = con.GetDatas(query).Columns["PatName"].ToString();
            PatientCb.DataValueField = con.GetDatas(query).Columns["PatId"].ToString();
            PatientCb.DataSource = con.GetDatas(query);
            PatientCb.DataBind();
            PatientCb.Items.Insert(0, new ListItem("Select Patient", "0"));
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PatientCb.SelectedIndex == 0 || LabTestCb.SelectedIndex == 0)
                {
                    ErrMsg.Text = "Please select both a patient and a test.";
                    return;
                }


                string Patient = PatientCb.SelectedValue;
                string Medicines = MedicinesTb.Text.ToString();
                string Test = LabTestCb.SelectedValue;
                string Cost = CostTb.Text.Trim();
               

                //Response.Write(Patient/);
                string Query = "insert into PrescriptionTbl values({0},'{1}','{2}','{3}',{4})";
                Query = string.Format(Query, Session["uid"].ToString(), Patient,Medicines,Test,Cost);

                con.SetDatas(Query);
                ErrMsg.Text = "Prescription Added!!!";
                showPrescription();
                MedicinesTb.Text = "";
                CostTb.Text = "";
                LabTestCb.SelectedIndex = -1;
                PatientCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}