using AddressBook.Interfaces;
using AddressBook.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _config;

        public EmployeeRepository(IConfiguration config)
        {

            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
            }
        }

        public  Employee GetEmployee(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Employee WHERE ID = @ID";
                conn.Open();
                return conn.Query<Employee>(sQuery, new { ID = id }).FirstOrDefault();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Employee";
                conn.Open();
                return conn.Query<Employee>(sQuery).ToList();

            }
        }

        public void AddEmployee(Employee emp)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "INSERT INTO Employee (Name,Email,Mobile,Landline,Website,Address) Values (@Name,@Email,@Mobile,@Landline,@Website,@Address);";
                conn.Open();
                var affectedRows = conn.Execute(sql, new { Name = emp.Name, Email = emp.Email,Mobile=emp.Mobile, Landline=emp.Landline, Website=emp.Website,Address=emp.Address });
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (IDbConnection conn = Connection)
            {
                string sqlquery = "UPDATE Employee set Name=@Name, Email=@Email,Mobile=@Mobile,Landline=@Landline,Website=@Website,Address=@Address WHERE ID= @ID";
                conn.Open();
                var affectedRows = conn.Execute(sqlquery, new { Name = emp.Name, Email = emp.Email, Mobile = emp.Mobile, Landline = emp.Landline, Website = emp.Website, Address = emp.Address,ID=emp.ID });
            }
        }

        public void DeleteEmployee(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "Delete FROM Employee where ID=@ID";
                conn.Open();
                conn.Query<Employee>(sQuery, new { ID = id });
            }

        }
    }
}
