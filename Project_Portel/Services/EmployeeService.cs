using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Project_Portel.Models;
using System.Data.SqlClient;
using System.Data;
namespace Project_Portel.Services
{
    public class EmployeeService
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private SqlDataAdapter sqlDataAdapter;
        private DataSet dataSet;

        public IList<EmployeeModel> GetEmployeeList()
        {
            IList<EmployeeModel> getEmpList= new List<EmployeeModel>();
            dataSet = new DataSet();
            using(SqlConnection con = new SqlConnection(connect)) {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employee_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpList");
                sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        EmployeeModel obj = new EmployeeModel();
                        obj.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
                        obj.FirstName = Convert.ToString(dataSet.Tables[0].Rows[i]["FirstName"]);
                        obj.LastName = Convert.ToString(dataSet.Tables[0].Rows[i]["LastName"]);
                        obj.DOB = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["DOB"]);
                        obj.Contact = (long)Convert.ToInt64(dataSet.Tables[0].Rows[i]["Contact"]);
                        obj.RoleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["RoleId"]);
                        getEmpList.Add(obj);

                    }

                }
            }
           return getEmpList;
        }
        public void addEmployee(EmployeeModel model ) {
            using (SqlConnection con = new SqlConnection(connect)) {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employee_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddEmployee");
                cmd.Parameters.AddWithValue("@Id",model.Id);
                cmd.Parameters.AddWithValue("@FirstName",model.FirstName);
                cmd.Parameters.AddWithValue("@LastName",model.LastName);
                cmd.Parameters.AddWithValue("@DOB",model.DOB);
                cmd.Parameters.AddWithValue("@Contact",model.Contact);
                cmd.Parameters.AddWithValue("@RoleId",model.RoleId);
                cmd.ExecuteNonQuery();
            }
        }
        public EmployeeModel getEmpById(int Id)
        {
            var model = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employee_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpById");
                cmd.Parameters.AddWithValue("@Id", Id);
                sqlDataAdapter = new SqlDataAdapter(cmd);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables.Count>0 && dataSet.Tables[0].Rows.Count>0) {
                    model.Id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
                    model.FirstName = Convert.ToString(dataSet.Tables[0].Rows[0]["FirstName"]);
                    model.LastName = Convert.ToString(dataSet.Tables[0].Rows[0]["LastName"]);
                    model.DOB = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["DOB"]);
                    model.Contact = (long)Convert.ToInt64(dataSet.Tables[0].Rows[0]["Contact"]);
                    model.RoleId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["RoleId"]);
                }
            }
            return model;
        }


        public void UpdateEmp(EmployeeModel model) {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employee_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateEmp");
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@DOB", model.DOB);
                cmd.Parameters.AddWithValue("@Contact", model.Contact);
                cmd.Parameters.AddWithValue("@RoleId", model.RoleId);
                cmd.ExecuteNonQuery();
            }

        }

        
        
        
        
        
        public void DeleteEmp(int Id) {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employee_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteEmp");
                cmd.Parameters.AddWithValue("@Id", Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}