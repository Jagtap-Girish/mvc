using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Portel.Models;
using Project_Portel.Services;


namespace Project_Portel.Controllers
{
    public class ManageProjectsEmpController : Controller
    {
        private ManageProjectsEmpServices manageProjectsEmpServices;

        // GET: ManageProjectsEmp
        public ActionResult list()
        {
            manageProjectsEmpServices = new ManageProjectsEmpServices();
            var model = manageProjectsEmpServices.GetAllProjectEmp();
            return View(model);
        }
        [HttpGet]
        public ActionResult getAllEmployeeByProjectId(int Id)
        {
             manageProjectsEmpServices = new ManageProjectsEmpServices();
            var model = manageProjectsEmpServices.GetAllEmployeeByProjectId(Id);
            return View(model);
        }

    }
}