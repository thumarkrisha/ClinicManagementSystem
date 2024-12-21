using ClinicManagementSystem.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Receptionist
{
    public partial class Patients : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            showPatient();
        }
        private void showPatient()
        {
            string query = "select * from PatientTbl";
            PatientList.DataSource = con.GetDatas(query);
            PatientList.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string PName = PatNameTb.Text.ToString();
                string PPhone = PatPhoneTb.Text.ToString();
                string PGen = GenderCb.SelectedItem.Text;
                DateTime DDOB = DateTime.Parse(DOBTb.Text).Date;
                string formattedDate = DDOB.ToString("dd-MM-yyyy");
                string PAdd = AddressTb.Text.ToString();
                string PAllergy = AllergyTb.Value.ToString();

                //Response.Write(RName);
                string Query = "insert into PatientTbl values('{0}','{1}','{2}','{3}','{4}','{5}',{6})";
                Query = string.Format(Query, PName, PPhone, PGen, formattedDate, PAdd, PAllergy, Session["uid"]);

                con.SetDatas(Query);
                ErrMsg.Text = "Patient Added!!!";
                showPatient();
                PatNameTb.Text = "";
                PatPhoneTb.Text = "";
                AddressTb.Text = "";
                DOBTb.Text = "";
                AllergyTb.Value = "";
                GenderCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
        int key=0;
        protected void PatientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatNameTb.Text = PatientList.SelectedRow.Cells[2].Text;
            PatPhoneTb.Text = PatientList.SelectedRow.Cells[3].Text;
            GenderCb.SelectedValue = PatientList.SelectedRow.Cells[4].Text;
            DateTime dob;
            if (DateTime.TryParse(Server.HtmlDecode(PatientList.SelectedRow.Cells[5].Text), out dob))
            {
                DOBTb.Text = dob.ToString("yyyy-MM-dd"); // Set the date in ISO format
            }
            else
            {
                DOBTb.Text = ""; // Clear if date is invalid
            }
            AddressTb.Text = PatientList.SelectedRow.Cells[6].Text;
            AllergyTb.Value = PatientList.SelectedRow.Cells[7].Text;

            //Response.Write(GenderCb.SelectedItem.Value + " " + LaboratorianGV.SelectedRow.Cells[7].Text);

            if (PatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientList.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PatNameTb.Text == "")
                {

                    ErrMsg.Text = "Select a Patient";
                }
                else
                {
                    string query = "delete from PatientTbl where PatId={0}";
                    query = string.Format(query, PatientList.SelectedRow.Cells[1].Text);
                    con.SetDatas(query);
                    showPatient();
                    ErrMsg.Text = "Patient Deleted!!!";
                    key = 0;
                    PatNameTb.Text = "";
                    PatPhoneTb.Text = "";
                    AddressTb.Text = "";
                    DOBTb.Text = "";
                    AllergyTb.Value = "";
                    GenderCb.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string PName = PatNameTb.Text.ToString();
                string PPhone = PatPhoneTb.Text.ToString();
                string PGen = GenderCb.SelectedItem.Text;
                string PDOB = DOBTb.Text.ToString();
                string PAdd = AddressTb.Text.ToString();
                string PAllergy = AllergyTb.Value.ToString();
                //Response.Write(RName);
                string Query = "update PatientTbl set PatName = '{0}',PatPhone = '{1}' ,PatGen = '{2}',PatDOB = '{3}',PatAdd = '{4}' , PatAllergies ='{5}' where PatId = {6}";
                Query = string.Format(Query,PName,PPhone,PGen,PDOB,PAdd,PAllergy, PatientList.SelectedRow.Cells[1].Text);

                con.SetDatas(Query);
                ErrMsg.Text = "Patient Updated!!!";
                showPatient();
                PatNameTb.Text = "";
                PatPhoneTb.Text = "";
                AddressTb.Text = "";
                DOBTb.Text = "";
                AllergyTb.Value = "";
                GenderCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void PatientList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the correct column index for DocDOB
                DateTime docDOB = Convert.ToDateTime(e.Row.Cells[5].Text); // Replace "7" with the column index of DocDOB
                e.Row.Cells[5].Text = docDOB.ToString("dd-MM-yyyy");
            }
        }
    }
}