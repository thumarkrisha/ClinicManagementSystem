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
            if (Session["uid"]==null)
            {
                Response.Redirect("~/Views/Guest/Home.aspx");
            }
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
        protected void DoctorsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the correct column index for DocDOB
                DateTime docDOB = Convert.ToDateTime(e.Row.Cells[8].Text); // Replace "7" with the column index of DocDOB
                e.Row.Cells[8].Text = docDOB.ToString("dd-MM-yyyy");
            }
        }


        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) { 
                try
                {
                    string DName = DocNameTb.Text.ToString();
                    string DPhone = DocPhoneTb.Text.ToString();
                    string DExp = DocExpTb.Text.ToString();
                    string DSpec = SpecialisationTb.Text.ToString();
                    string DGen = GenderCb.SelectedItem.ToString();
                    string DAdd = AddressTb.Text.ToString();
                    DateTime DDOB = DateTime.Parse(DOBTb.Text).Date;
                    string formattedDate = DDOB.ToString("dd-MM-yyyy");
                    string DPass = PasswordTb.Text.ToString();
                    string DEmail = EmailTb.Text.ToString();
                    //Response.Write(DDOB);
                    string Query = "insert into DoctorTbl values('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}')";
                    Query = string.Format(Query, DName, DPhone, DExp, DSpec, DGen, DAdd, formattedDate, DPass, DEmail);

                    con.SetDatas(Query);
                    ErrMsg.Text = "Doctor Added!!!";
                    showDoctors();
                    DocNameTb.Text = "";
                    DocPhoneTb.Text = "";
                    AddressTb.Text = "";
                    DocExpTb.Text = "";
                    PasswordTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                    SpecialisationTb.Text = "";
                    DOBTb.Text = "";
                    EmailTb.Text = "";
                }
                catch (Exception ex)
                {
                    ErrMsg.Text = ex.Message;
                }
        }
        }
        int key = 0;
        protected void DoctorsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocNameTb.Text = DoctorsGV.SelectedRow.Cells[2].Text;
            DocPhoneTb.Text = DoctorsGV.SelectedRow.Cells[3].Text;
            DocExpTb.Text = DoctorsGV.SelectedRow.Cells[4].Text;
            SpecialisationTb.Text = DoctorsGV.SelectedRow.Cells[5].Text;
            GenderCb.SelectedValue = DoctorsGV.SelectedRow.Cells[6].Text;
            AddressTb.Text = DoctorsGV.SelectedRow.Cells[7].Text;
            DateTime dob;
            if (DateTime.TryParse(Server.HtmlDecode(DoctorsGV.SelectedRow.Cells[8].Text), out dob))
            {
                DOBTb.Text = dob.ToString("yyyy-MM-dd"); // Set the date in ISO format
            }
            else
            {
                DOBTb.Text = ""; // Clear if date is invalid
            }
            PasswordTb.Text  = DoctorsGV.SelectedRow.Cells[9].Text;
            EmailTb.Text = DoctorsGV.SelectedRow.Cells[10].Text;
            if (DocNameTb.Text == "")
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
            if (Page.IsValid)
            {


                try
                {
                    if (DocNameTb.Text == "")
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
                        DocNameTb.Text = "";
                        DocPhoneTb.Text = "";
                        AddressTb.Text = "";
                        DocExpTb.Text = "";
                        PasswordTb.Text = "";
                        GenderCb.SelectedIndex = -1;
                        SpecialisationTb.Text = "";
                        DOBTb.Text = "";
                        EmailTb.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    ErrMsg.Text = ex.Message;
                }
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {


                try
                {
                    string DName = DocNameTb.Text.ToString();
                    string DPhone = DocPhoneTb.Text.ToString();
                    string DExp = DocExpTb.Text.ToString();
                    string DSpec = SpecialisationTb.Text.ToString();
                    string DGen = GenderCb.SelectedItem.Text;
                    string DAdd = AddressTb.Text.ToString();
                    string DDOB = DOBTb.Text.ToString();
                    string DPass = PasswordTb.Text.ToString();
                    string DEmail = EmailTb.Text.ToString();
                    //Response.Write(RName);
                    string Query = "update DoctorTbl set DocName = '{0}',DocPhone = '{1}' ,DocExp = {2},DocSpec = '{3}',DocGen = '{4}',DocAdd = '{5}',DocDOB = '{6}',DocPassword = '{7}',DocEmail = '{8}' where RecId = {9}";
                    Query = string.Format(Query, DName, DPhone, DExp, DSpec, DGen, DAdd, DDOB, DPass, DEmail, DoctorsGV.SelectedRow.Cells[1].Text);

                    con.SetDatas(Query);
                    ErrMsg.Text = "Doctor Updated!!!";
                    showDoctors();
                    DocNameTb.Text = "";
                    DocPhoneTb.Text = "";
                    AddressTb.Text = "";
                    DocExpTb.Text = "";
                    PasswordTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                    SpecialisationTb.Text = "";
                    DOBTb.Text = "";
                    EmailTb.Text = "";
                }
                catch (Exception ex)
                {
                    ErrMsg.Text = ex.Message;
                }
            }
        }
    }
}