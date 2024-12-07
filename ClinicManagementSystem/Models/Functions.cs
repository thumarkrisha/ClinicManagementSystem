using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private string ConStr;
        private DataTable dt;
        private SqlDataAdapter sda;
        public Functions() 
        {
            ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HP\\Documents\\ClinicManagementDB.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = con;

        }

        public int SetDatas(string sql)
        {
            int cnt = 0;

            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = sql;
            cnt = cmd.ExecuteNonQuery();
            con.Close();
            return cnt; 
        }
        public DataTable GetDatas(string query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(query,ConStr);
            sda.Fill(dt);
            return dt;

        }
    }
}