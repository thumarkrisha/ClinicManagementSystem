﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Patient
{
    public partial class PatientMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {

            Session.Clear(); // Clears the session
            Session.Abandon(); // Marks session for deletion
            Response.Redirect("~/Views/Login.aspx"); // Redirects to the login page


        }
    }
}