﻿using ClinicManagementSystem.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicManagementSystem.Views.Laboratorian
{
    public partial class LabTest : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            showTests();
            if (Session["uid"] == null)
            {
                Response.Redirect("~/Views/Guest/Home.aspx");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
        private void showTests()
        {
            string query = "select * from LabTestTbl";
            LabTestGV.DataSource = con.GetDatas(query);
            LabTestGV.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TestName = TestNameTb.Text.ToString();
                string TestCost = TestCostTb.Text.ToString();
              
                string Query = "insert into LabTestTbl values('{0}','{1}',{2})";
                Query = string.Format(Query, TestName,TestCost, Session["uid"]);

                con.SetDatas(Query);
                ErrMsg.Text = "Test Added!!!";
                showTests();
                TestNameTb.Text = "";
                TestCostTb.Text = "";

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
        int key = 0;
        protected void LabTestGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestNameTb.Text = LabTestGV.SelectedRow.Cells[2].Text;
            TestCostTb.Text = LabTestGV.SelectedRow.Cells[3].Text;
           
            //Response.Write(GenderCb.SelectedItem.Value + " " + LaboratorianGV.SelectedRow.Cells[7].Text);

            if (TestNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LabTestGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TestName = TestNameTb.Text.ToString();
                string TestCost = TestCostTb.Text.ToString();
                //Response.Write(RName);
                string Query = "update LabTestTbl set TestName = '{0}',TestCost = {1} where TestId = {2}";
                Query = string.Format(Query,TestName,TestCost, LabTestGV.SelectedRow.Cells[1].Text);

                con.SetDatas(Query);
                ErrMsg.Text = "Test Updated!!!";
                showTests();
                TestNameTb.Text = "";
                TestCostTb.Text = "";
              

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
                if (TestNameTb.Text == "")
                {

                    ErrMsg.Text = "Select a Test";
                }
                else
                {
                    string query = "delete from LabTestTbl where TestId={0}";
                    query = string.Format(query, LabTestGV.SelectedRow.Cells[1].Text);
                    con.SetDatas(query);
                    showTests();
                    ErrMsg.Text = "Lab Test Deleted!!!";
                    key = 0;
                    TestNameTb.Text = "";
                    TestCostTb.Text = "";
                   
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}