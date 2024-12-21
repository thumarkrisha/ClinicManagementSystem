using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Laboratorian
{
    public partial class LaboratorianMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Trace.Write("Logout button clicked."); // Debug log
            Session.Clear();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}