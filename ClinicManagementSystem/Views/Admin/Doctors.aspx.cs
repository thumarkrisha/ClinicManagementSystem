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
                string DDOB = DOBTb.Value.ToString();
                string DPass = PasswordTb.Value.ToString();
                //Response.Write(RName);
                string Query = "insert into DoctorTbl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                Query = string.Format(Query, DName,DPhone,DExp,DSpec,DGen,DAdd,DDOB,DPass);

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

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void DoctorsGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}