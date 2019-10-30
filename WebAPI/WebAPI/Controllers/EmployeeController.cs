using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebAPI.Models;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            //return new string[] { "employee" };

            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<Employee> output = new List<Employee>();

            try
            {
                conn.Open();

                query = "select * from employee";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new Employee(Int32.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString()));
                }
            }

            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;

        }

        //GET: api/Employee/S
        public Employee Get(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            Employee output = new Employee();

            try
            {
                conn.Open();

                query = "select * from employee where StaffId = " + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = new Employee(Int32.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;

        }


        //POST: api/Employee


        public string Post([FromBody]Employee emp)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            String query;
            string output = "Not Assigned";
            try
            {
                conn.Open();
                query = "insert employee(StaffId, GivenName, Surname)" + "values(" + emp.StaffId + ", '" + emp.GivenName + "' , ' " + emp.SurName + "')";

                output = "Insert Successful";

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }

        //PUT: api/Employee

        public string Put(int id, [FromBody]Employee emp)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            String query;
            string output = "Not Assigned";
            try
            {
                conn.Open();
                query = "update employee set GivenName = '" + emp.GivenName + "', Surname = '" + emp.SurName + "' where StaffId = " + id;


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }


        //DELETE: api/Employee

        public string Delete(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            String query;
            string output = "Not Assigned";
            try
            {
                conn.Open();

                query = "delete from employee where StaffId = " + id;

                cmd = new SqlCommand(query, conn);

                int res = cmd.ExecuteNonQuery();

                output = res.ToString() + " rows deleted";


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }





    }

}
