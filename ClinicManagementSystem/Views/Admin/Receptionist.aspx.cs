using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Admin
{
    public partial class Recepionist : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            showReceptionist();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }

        private void showReceptionist()
        {
            string query = "select * from ReceptionistTbl";
            ReceptionistGV.DataSource = con.GetDatas(query);
            ReceptionistGV.DataBind();
        }      
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RecNameTb.Value.ToString();
                string REmail = RecEmailTb.Value.ToString();
                string RAdd = AddressTb.Value.ToString();
                string RPhone = PhoneTb.Value.ToString();
                string RPass = PasswordTb.Value.ToString();
                //Response.Write(RName);
                string Query = "insert into ReceptionistTbl values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, RName, REmail, RAdd, RPhone, RPass);

                con.SetDatas(Query);
                ErrMsg.Text = "Receptionist Added!!!";
                showReceptionist();
                RecNameTb.Value = "";
                RecEmailTb.Value = "";
                AddressTb.Value = "";
                PhoneTb.Value = "";
                PasswordTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}