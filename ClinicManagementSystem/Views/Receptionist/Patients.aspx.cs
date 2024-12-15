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
                string PName = PatNameTb.Value.ToString();
                string PPhone = PatPhoneTb.Value.ToString();
                string PGen = GenderCb.SelectedItem.Value;
                string PDOB = DOBTb.Value.ToString();
                string PAdd = AddressTb.Value.ToString();
                string PAllergy = AllergyTb.Value.ToString();

                //Response.Write(RName);
                string Query = "insert into PatientTbl values('{0}','{1}','{2}','{3}','{4}','{5}',{6})";
                Query = string.Format(Query, PName, PPhone, PGen, PDOB, PAdd, PAllergy,101);

                con.SetDatas(Query);
                ErrMsg.Text = "Patient Added!!!";
                showPatient();
                PatNameTb.Value = "";
                PatPhoneTb.Value = "";
                AddressTb.Value = "";
                DOBTb.Value = "";
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
            PatNameTb.Value = PatientList.SelectedRow.Cells[2].Text;
            PatPhoneTb.Value = PatientList.SelectedRow.Cells[3].Text;
            GenderCb.SelectedValue = PatientList.SelectedRow.Cells[4].Text;
            DOBTb.Value = PatientList.SelectedRow.Cells[5].Text;
            AddressTb.Value = PatientList.SelectedRow.Cells[6].Text;
            AllergyTb.Value = PatientList.SelectedRow.Cells[7].Text;

            //Response.Write(GenderCb.SelectedItem.Value + " " + LaboratorianGV.SelectedRow.Cells[7].Text);

            if (PatNameTb.Value == "")
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
                if (PatNameTb.Value == "")
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
                    PatNameTb.Value = "";
                    PatPhoneTb.Value = "";
                    AddressTb.Value = "";
                    DOBTb.Value = "";
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
                string PName = PatNameTb.Value.ToString();
                string PPhone = PatPhoneTb.Value.ToString();
                string PGen = GenderCb.SelectedItem.Value;
                string PDOB = DOBTb.Value.ToString();
                string PAdd = AddressTb.Value.ToString();
                string PAllergy = AllergyTb.Value.ToString();
                //Response.Write(RName);
                string Query = "update PatientTbl set PatName = '{0}',PatPhone = '{1}' ,PatGen = '{2}',PatDOB = '{3}',PatAdd = '{4}' , PatAllergies ='{5}' where PatId = {6}";
                Query = string.Format(Query,PName,PPhone,PGen,PDOB,PAdd,PAllergy, PatientList.SelectedRow.Cells[1].Text);

                con.SetDatas(Query);
                ErrMsg.Text = "Patient Updated!!!";
                showPatient();
                PatNameTb.Value = "";
                PatPhoneTb.Value = "";
                AddressTb.Value = "";
                DOBTb.Value = "";
                AllergyTb.Value = "";
                GenderCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}