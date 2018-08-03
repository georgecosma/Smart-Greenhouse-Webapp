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
    public class TemperatureController : Controller
    {
        private SmartGardenDbContext _db;
        public TemperatureController()
        {
            _db = new SmartGardenDbContext();
        }

        // GET: Temperature
        public ActionResult Index()
        {
            ViewData["temperatureValue"] = _db.TemperatureDatas.ToList().Last().Value.ToString();

            var allData = _db.TemperatureDatas.OrderByDescending(t => t.RegistrationDate).Take(30).ToList();

            var _tempetarureValuesList = new List<TemperatureDataViewModel>();
            
            foreach(var item in allData)
            {
                var _temp = new TemperatureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _tempetarureValuesList.Add(_temp);
            }

            ViewData["temperatureValuesList"] = _tempetarureValuesList;


            return View();
        }

        public JsonResult updateValues()
        {
            var allData = _db.TemperatureDatas.OrderByDescending(t => t.RegistrationDate).Take(30).ToList();

            var _tempetarureValuesList = new List<TemperatureDataViewModel>();

            foreach (var item in allData)
            {
                var _temp = new TemperatureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _tempetarureValuesList.Add(_temp);
            }

            var model = new
            {
                temperatureValue = _db.TemperatureDatas.ToList().Last().Value.ToString(),
                temperatureValuesList = _tempetarureValuesList
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}