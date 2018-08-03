using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartGarden.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SystemSettingsController : Controller
    {
        // GET: SystemSettings
        public ActionResult Index()
        {
            return View();
        }
    }
}