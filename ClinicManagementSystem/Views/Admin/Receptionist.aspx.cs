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
        int key = 0;
        protected void ReceptionistGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecNameTb.Value = ReceptionistGV.SelectedRow.Cells[2].Text;
            RecEmailTb.Value = ReceptionistGV.SelectedRow.Cells[3].Text;
            AddressTb.Value = ReceptionistGV.SelectedRow.Cells[4].Text;
            PhoneTb.Value = ReceptionistGV.SelectedRow.Cells[5].Text;
            PasswordTb.Value = ReceptionistGV.SelectedRow.Cells[6].Text;

            if(RecNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ReceptionistGV.SelectedRow.Cells[1].Text);   
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecNameTb.Value == "")
                {

                    ErrMsg.Text = "Select a Receptionist";
                }
                else
                {
                    string query = "delete from ReceptionistTbl where RecId={0}";
                    query = string.Format(query, ReceptionistGV.SelectedRow.Cells[1].Text);
                    con.SetDatas(query);
                    showReceptionist();
                    ErrMsg.Text = "Receptionist Deleted!!!";
                    key = 0;
                    RecNameTb.Value = "";
                    RecEmailTb.Value = "";
                    AddressTb.Value = "";
                    PhoneTb.Value = "";
                    PasswordTb.Value = "";
                }

            }
            catch(Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }        
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RecNameTb.Value.ToString();
                string REmail = RecEmailTb.Value.ToString();
                string RAdd = AddressTb.Value.ToString();
                string RPhone = PhoneTb.Value.ToString();
                string RPass = PasswordTb.Value.ToString();
                //Response.Write(RName);
                string Query = "update ReceptionistTbl set RecName = '{0}',RecEmail = '{1}' ,RecAdd = '{2}',RecPhone = '{3}',RecPassword = '{4}' where RecId = {5}";
                Query = string.Format(Query, RName, REmail, RAdd, RPhone, RPass, ReceptionistGV.SelectedRow.Cells[1].Text);

                con.SetDatas(Query);
                ErrMsg.Text = "Receptionist Updated!!!";
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