using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
          
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (RoleCb.SelectedIndex == 0)
            {
                ErrMsg.Text = "Select a Role!!!";
            }
            else if (RoleCb.SelectedIndex == 1)
            {
                if(Email.Value=="admin@gmail.com" && Password.Value == "Admin")
                {
                    string role = "Admin";
                    Session["uid"] = 1;
                    Session["role"] = role;
                    Session.Timeout = 10;
                    string r_url = "{0}/Doctors.aspx";
                    r_url = string.Format(r_url, role);

                    Response.Redirect(r_url);
                }
                else
                {
                    ErrMsg.Text = "Invalid Admin";
                }
            }
            else if (RoleCb.SelectedIndex == 2)
            {
                string query = "select * from DoctorTbl where DocEmail = '{0}' and DocPassword = '{1}'";
                query = string.Format(query,Email.Text.ToString(),Password.Text.ToString());
                DataTable dt = con.GetDatas(query);
                if (dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "Invalid Doctor!!!";
                }
                else
                {
                    string role = "Doctors";
                    Session["uid"] = dt.Rows[0][0].ToString();
                    Session["role"] = role;
                    Session.Timeout = 10;
                    string r_url = "{0}/Prescriptions.aspx";
                    r_url = string.Format(r_url,role);

                    Response.Redirect(r_url);
                }
            }
            else if (RoleCb.SelectedIndex == 3)
            {
                string query = "select * from LaboratorianTbl where LabEmail = '{0}' and LabPassword = '{1}'";
                query = string.Format(query, Email.Text.ToString(), Password.Text.ToString());
                DataTable dt = con.GetDatas(query);
                if (dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "Invalid Laboratorian!!!";
                }
                else
                {
                    string role = "Laboratorian";
                    Session["uid"] = dt.Rows[0][0].ToString();
                    Session["role"] = role;
                    Session.Timeout = 10;
                    string r_url = "{0}/LabTest.aspx";
                    r_url = string.Format(r_url, role);

                    Response.Redirect(r_url);
                }
            }
            else if (RoleCb.SelectedIndex == 4)
            {
                string query = "select * from ReceptionistTbl where RecEmail = '{0}' and RecPassword = '{1}'";
                query = string.Format(query, Email.Text.ToString(), Password.Text.ToString());
                DataTable dt = con.GetDatas(query);
                if (dt.Rows.Count == 0)
                {
                    ErrMsg.Text = "Invalid Receptionist!!!";
                }
                else
                {
                    string role = "Receptionist";
                    Session["uid"] = dt.Rows[0][0].ToString();
                    Session["role"] = role;
                    Session.Timeout = 10;
                    string r_url = "{0}/Patients.aspx";
                    r_url = string.Format(r_url, role);

                    Response.Redirect(r_url);
                }
            }
        }
    }
}