using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Interfaces;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers.API
{
    [Produces("application/json")]
    [Route("api/EmployeeAPI")]
    public class EmployeeAPIController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAPIController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // GET: api/EmployeeAPI
        [HttpGet]
        public List<Employee> Get()
        {
            return employeeRepository.GetAllEmployees();
        }

      
        //[HttpGet("{email}", Name = "Get")]
        //public Employee Get(string email)
        //{
        //    return employeeRepository.Get(email);
        //}


        // POST: api/EmployeeAPI
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/EmployeeAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
