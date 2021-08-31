using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Portel.Models;
using Project_Portel.Services;


namespace Project_Portel.Controllers
{
    public class ManageRoleController : Controller

    {
        private ManageRoleService manageRoleService;
        // GET: ManageRole
        public ActionResult list()
        {
            manageRoleService = new ManageRoleService();
            var model = manageRoleService.GetRoles();
            return View(model);
        }

        public ActionResult ManageRole(int id)
        {
            ManageRoleService manageRoleService = new ManageRoleService();
            var model = manageRoleService.GetEmployeeById(id);
            return View(model);

        }
        [HttpPost]
            public ActionResult ManageRole(ManageRoleModel manageRoleModel) {
                manageRoleService = new ManageRoleService();
                manageRoleService.ManageRole(manageRoleModel);

                return RedirectToAction("list");
            }
        
    }
}