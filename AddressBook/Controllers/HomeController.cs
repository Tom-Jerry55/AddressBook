using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using AddressBook.Interfaces;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(employeeRepository.GetAllEmployees());
        }

        
        [HttpGet]
        public IActionResult GetEmployeeDetails(int id)
        {
            return PartialView("Details", employeeRepository.GetEmployee(id)); ;
        }

        
        public IActionResult EmployeeForm()
        {
            return PartialView(); 
        }

        
        [HttpPost]
        public IActionResult GetEmpUpdateForm(int id)
        {
            var x = employeeRepository.GetEmployee(id);
            return PartialView("EmployeeForm", x);
        }

        [HttpPost]
        public IActionResult SaveEmployeeDetails(Employee emp)
        {
            if (emp.ID > 0)
            {
                employeeRepository.UpdateEmployee(emp);
            }
            else
            {
                employeeRepository.AddEmployee(emp);
            }
           
            return RedirectToAction("Index");
        }

     

        public IActionResult DeleteEmployee(int id)
        {
            employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetEmployees()
        {
            return View(employeeRepository.GetAllEmployees());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
