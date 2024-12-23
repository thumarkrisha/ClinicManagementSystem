using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Admin
{
    public partial class Laboratorians : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            showLaboratorians();
            if (Session["uid"] == null)
            {
                Response.Redirect("~/Views/Guest/Home.aspx");
            }
           
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
       
        private void showLaboratorians()
        {
            string query = "select * from LaboratorianTbl";
            LaboratorianGV.DataSource = con.GetDatas(query);
            LaboratorianGV.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string LName = LabNameTb.Text.ToString();
                string LEmail = LabEmailTb.Text.ToString();
                string LPass = PasswordTb.Text.ToString();
                string LPhone = PhoneTb.Text.ToString();
                string LAdd = AddressTb.Text.ToString();
                string LGen = GenderCb.SelectedItem.Text;
               
                //Response.Write(RName);
                string Query = "insert into LaboratorianTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, LName, LEmail, LPass,LPhone,LAdd,LGen);

                con.SetDatas(Query);
                ErrMsg.Text = "Laboratoraian Added!!!";
                showLaboratorians();
                LabNameTb.Text = "";
                LabEmailTb.Text = "";
                AddressTb.Text = "";
                PhoneTb.Text = "";
                PasswordTb.Text = "";
                GenderCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LabNameTb.Text == "")
                {

                    ErrMsg.Text = "Select a Laboratorian";
                }
                else
                {
                    string query = "delete from LaboratorianTbl where LabId={0}";
                    query = string.Format(query, LaboratorianGV.SelectedRow.Cells[1].Text);
                    con.SetDatas(query);
                    showLaboratorians();
                    ErrMsg.Text = "Receptionist Deleted!!!";
                    key = 0;
                    LabNameTb.Text = "";
                    LabEmailTb.Text = "";
                    AddressTb.Text = "";
                    PhoneTb.Text = "";
                    PasswordTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            } 
        }
        int key = 0;
        protected void LaboratorianGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabNameTb.Text = LaboratorianGV.SelectedRow.Cells[2].Text;
            LabEmailTb.Text = LaboratorianGV.SelectedRow.Cells[3].Text;
            PasswordTb.Text = LaboratorianGV.SelectedRow.Cells[4].Text;
            PhoneTb.Text = LaboratorianGV.SelectedRow.Cells[5].Text;
            AddressTb.Text = LaboratorianGV.SelectedRow.Cells[6].Text;
            GenderCb.SelectedValue = LaboratorianGV.SelectedRow.Cells[7].Text;
            
          //  Response.Write(GenderCb.SelectedItem.Value +" " + LaboratorianGV.SelectedRow.Cells[7].Text);

            if (LabNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LaboratorianGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string LName = LabNameTb.Text.ToString();
                string LEmail = LabEmailTb.Text.ToString();
                string LPass = PasswordTb.Text.ToString();
                string LPhone = PhoneTb.Text.ToString();
                string LAdd = AddressTb.Text.ToString();
                string LGen = GenderCb.SelectedItem.ToString();
                //Response.Write(RName);
                string Query = "update LaboratorianTbl set LabName = '{0}',LabEmail = '{1}' ,LabPassword = '{2}',LabPhone = '{3}',LabAddress = '{4}' , LabGen='{5}' where LabId = {6}";
                Query = string.Format(Query, LName, LEmail, LPass, LPhone, LAdd,LGen, LaboratorianGV.SelectedRow.Cells[1].Text);

                con.SetDatas(Query);
                ErrMsg.Text = "Laboratorian Updated!!!";
                showLaboratorians();
                LabNameTb.Text = "";
                LabEmailTb.Text = "";
                AddressTb.Text = "";
                PhoneTb.Text = "";
                PasswordTb.Text = "";
                GenderCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}