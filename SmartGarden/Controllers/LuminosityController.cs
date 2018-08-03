using SmartGarden.Models;
using SmartGarden.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartGarden.Controllers
{
    [Authorize]
    public class LuminosityController : Controller
    {
        private SmartGardenDbContext _db;
        public LuminosityController()
        {
            _db = new SmartGardenDbContext();
        }
        
        // GET: Luminosity
        public ActionResult Index()
        {
            ViewData["luminosityValue"] = _db.LuminosityDatas.ToList().Last().Value.ToString();

            var allData = _db.LuminosityDatas.OrderByDescending(t => t.RegistrationDate).Take(30).ToList();

            var _luminosityValuesList = new List<LuminosityDataViewModel>();

            foreach (var item in allData)
            {
                var _temp = new LuminosityDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _luminosityValuesList.Add(_temp);
            }

            ViewData["luminosityValuesList"] = _luminosityValuesList;


            return View();
        }

        public JsonResult updateValues()
        {
            var allData = _db.LuminosityDatas.OrderByDescending(t => t.RegistrationDate).Take(30).ToList();

            var _luminosityValuesList = new List<LuminosityDataViewModel>();

            foreach (var item in allData)
            {
                var _temp = new LuminosityDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _luminosityValuesList.Add(_temp);
            }

            var model = new
            {
                luminosityValue = _db.LuminosityDatas.ToList().Last().Value.ToString(),
                luminosityValuesList = _luminosityValuesList
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}