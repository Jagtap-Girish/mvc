using Project_Portel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Portel.Controllers
{
    public class RoleController : Controller
    {
        private RoleService roleService;
        // GET: Role
        public ActionResult list()
        {
            roleService = new RoleService();
            var model = roleService.GetAllRoles();
            return View(model);
        }
    }
}