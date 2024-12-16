using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Admin
{
    public partial class Doctors : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            showDoctors();
        }
        private void showDoctors()
        {
            string query = "select * from DoctorTbl";
            DoctorsGV.DataSource = con.GetDatas(query);
            DoctorsGV.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string DName = DocNameTb.Value.ToString();
                string DPhone = DocPhoneTb.Value.ToString();
                string DExp = DocExpTb.Value.ToString();
                string DSpec = SpecialisationTb.Value.ToString();
                string DGen = GenderCb.SelectedItem.ToString();
                string DAdd = AddressTb.Value.ToString();
                DateTime DDOB = (DateTime.Parse(DOBTb.Value)).Date;
                string DPass = PasswordTb.Value.ToString();
                string DEmail = EmailTb.Value.ToString();
                //Response.Write(DDOB);
                string Query = "insert into DoctorTbl values('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}')";
                Query = string.Format(Query, DName,DPhone,DExp,DSpec,DGen,DAdd,DDOB,DPass,DEmail);

                con.SetDatas(Query);
                ErrMsg.Text = "Doctor Added!!!";
                showDoctors();
                DocNameTb.Value = "";
                DocPhoneTb.Value = "";
                AddressTb.Value = "";
                DocExpTb.Value = "";
                PasswordTb.Value = "";
                GenderCb.SelectedIndex = -1;
                SpecialisationTb.Value = "";
                DOBTb.Value = "";
                EmailTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
        int key = 0;
        protected void DoctorsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocNameTb.Value = DoctorsGV.SelectedRow.Cells[2].Text;
            DocPhoneTb.Value = DoctorsGV.SelectedRow.Cells[3].Text;
            DocExpTb.Value = DoctorsGV.SelectedRow.Cells[4].Text;
            SpecialisationTb.Value = DoctorsGV.SelectedRow.Cells[5].Text;
            GenderCb.SelectedValue = DoctorsGV.SelectedRow.Cells[6].Text;
            AddressTb.Value = DoctorsGV.SelectedRow.Cells[7].Text;
            DOBTb.Value= DoctorsGV.SelectedRow.Cells[8].Text;
            PasswordTb.Value = DoctorsGV.SelectedRow.Cells[9].Text;
            EmailTb.Value = DoctorsGV.SelectedRow.Cells[10].Text;
            if (DocNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DoctorsGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DocNameTb.Value == "")
                {

                    ErrMsg.Text = "Select a Doctor";
                }
                else
                {
                    string query = "delete from DoctorTbl where DocId={0}";
                    query = string.Format(query, DoctorsGV.SelectedRow.Cells[1].Text);
                    con.SetDatas(query);
                    showDoctors();
                    ErrMsg.Text = "Doctor Deleted!!!";
                    key = 0;
                    DocNameTb.Value = "";
                    DocPhoneTb.Value = "";
                    AddressTb.Value = "";
                    DocExpTb.Value = "";
                    PasswordTb.Value = "";
                    GenderCb.SelectedIndex = -1;
                    SpecialisationTb.Value = "";
                    DOBTb.Value = "";
                    EmailTb.Value = "";
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
                string DName = DocNameTb.Value.ToString();
                string DPhone = DocPhoneTb.Value.ToString();
                string DExp = DocExpTb.Value.ToString();
                string DSpec = SpecialisationTb.Value.ToString();
                string DGen = GenderCb.SelectedItem.Value;
                string DAdd = AddressTb.Value.ToString();
                string DDOB = DOBTb.Value.ToString();
                string DPass = PasswordTb.Value.ToString();
                string DEmail = EmailTb.Value.ToString();
                //Response.Write(RName);
                string Query = "update DoctorTbl set DocName = '{0}',DocPhone = '{1}' ,DocExp = {2},DocSpec = '{3}',DocGen = '{4}',DocAdd = '{5}',DocDOB = '{6}',DocPassword = '{7}',DocEmail = '{8}' where RecId = {9}";
                Query = string.Format(Query, DName, DPhone, DExp, DSpec, DGen, DAdd, DDOB, DPass,DEmail, DoctorsGV.SelectedRow.Cells[1].Text);

                con.SetDatas(Query);
                ErrMsg.Text = "Doctor Updated!!!";
                showDoctors();
                DocNameTb.Value = "";
                DocPhoneTb.Value = "";
                AddressTb.Value = "";
                DocExpTb.Value = "";
                PasswordTb.Value = "";
                GenderCb.SelectedIndex = -1;
                SpecialisationTb.Value = "";
                DOBTb.Value = "";
                EmailTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}