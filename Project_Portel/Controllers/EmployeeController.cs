using Project_Portel.Models;
using Project_Portel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Portel.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService;
        // GET: Employee
        public ActionResult list()
        {
            employeeService = new EmployeeService();
            var model = employeeService.GetEmployeeList();
            return View(model);
        }
        public ActionResult addEmployee() {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult addEmployee(EmployeeModel model)
        {
            employeeService = new EmployeeService();
            employeeService.addEmployee(model);
            return RedirectToAction("list");
        }
       
        public ActionResult updateEmploye(int Id)
        {
            employeeService = new EmployeeService();
            var model = employeeService.getEmpById(Id);
            return View(model);
        }
        public ActionResult updateEmployee(int Id)
        {
            employeeService = new EmployeeService();
            var model = employeeService.getEmpById(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult updateEmployee(EmployeeModel model) {

            employeeService = new EmployeeService();
            employeeService.UpdateEmp(model);



            return RedirectToAction("list");
        
        }

        public ActionResult deleteEmployee(int Id)
        {
            employeeService = new EmployeeService();
            employeeService.DeleteEmp(Id);
            return RedirectToAction("list");
        }
    }
}