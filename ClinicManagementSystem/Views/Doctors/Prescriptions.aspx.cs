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
            showPrescription();
            GetTest();
            GetPatient();
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
        }

        private void GetPatient()
        {
            string query = "select * from PatientTbl";
            PatientCb.DataTextField = con.GetDatas(query).Columns["PatName"].ToString();
            PatientCb.DataValueField = con.GetDatas(query).Columns["PatId"].ToString();
            PatientCb.DataSource = con.GetDatas(query);
            PatientCb.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int Doctor = 300;
                string Patient = PatientCb.SelectedValue.ToString();
                string Medicines = MedicinesTb.Value.ToString();
                string Test = LabTestCb.SelectedValue.ToString();
                string Cost = CostTb.Value.ToString();
               

                //Response.Write(RName);
                string Query = "insert into PrescriptionTbl values({0},{1},'{2}',{3},{4})";
                Query = string.Format(Query, Doctor,Patient,Medicines,Test,Cost);

                con.SetDatas(Query);
                ErrMsg.Text = "Prescription Added!!!";
                showPrescription();
                MedicinesTb.Value = "";
                CostTb.Value = "";
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