using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace WebElectronicCashCounter.Models
{
    public class Control_UserAccountModel
    {

        string connectionString = ConfigurationManager.ConnectionStrings["OurDbContext"].ConnectionString;
        private object userAccountModel;

        public void AddUserAccount(UserAccountModel userAccountModel)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["OurDbContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter PFirstName = new SqlParameter();
                PFirstName.ParameterName = "@FirstName";
                PFirstName.Value = userAccountModel.FirstName;
                cmd.Parameters.Add(PFirstName);

                SqlParameter PLastName = new SqlParameter();
                PLastName.ParameterName = "@LastName";
                PLastName.Value = userAccountModel.LastName;
                cmd.Parameters.Add(PLastName);

                SqlParameter Pemail = new SqlParameter();
                Pemail.ParameterName = "@email";
                Pemail.Value = userAccountModel.email;
                cmd.Parameters.Add(Pemail);

                SqlParameter PPassword = new SqlParameter();
                PPassword.ParameterName = "@Password";
                PPassword.Value = userAccountModel.Password;
                cmd.Parameters.Add(PPassword);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public int ExecuteQuery(UserAccountModel userAccountModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //string query = @"select * from UserAccountTable where email=@email and Password=@Passwoed";
                SqlCommand cmd = new SqlCommand("select * from UserAccountTable where email=@email and Password=@Passwoed", con);
                //cmd.Parameters.AddWithValue("@email",)
                SqlParameter email = new SqlParameter();
                email.ParameterName = "@email";
                email.Value = userAccountModel.email;
                cmd.Parameters.Add(email);

                SqlParameter PPassword = new SqlParameter();
                PPassword.ParameterName = "@passwprd";
                PPassword.Value = userAccountModel.Password;
                cmd.Parameters.Add(PPassword);
                try
                {
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (SqlException sqlex)
                {
                    return 0;
                }
            }
        }




        public DataTable GetDataTable(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

        }

    }
}