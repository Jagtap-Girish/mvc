using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Portel.Models;
using Project_Portel.Services;

namespace Project_Portel.Controllers
{

    public class ManageProjectsController : Controller
    {
        private ManageProjectsService manageProjectsService;
        // GET: ManageProjects
        public ActionResult list()
        {
            manageProjectsService = new ManageProjectsService();
            var model = manageProjectsService.Getlist();
            return View(model);
        }
    }
}