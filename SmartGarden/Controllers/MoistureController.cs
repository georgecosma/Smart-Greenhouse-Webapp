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
    public class MoistureController : Controller
    {
        private SmartGardenDbContext _db;
        public MoistureController()
        {
            _db = new SmartGardenDbContext();
        }

        // GET: Moisture
        public ActionResult Index()
        {
            ViewData["soilMoisture1"] = _db.SoilMoistureDatas.Where(s => s.LineNr == 1).OrderByDescending(t => t.RegistrationDate).Take(30).ToList().First().Value.ToString();
            ViewData["soilMoisture2"] = _db.SoilMoistureDatas.Where(s => s.LineNr == 2).OrderByDescending(t => t.RegistrationDate).Take(30).ToList().First().Value.ToString();
            ViewData["soilMoisture3"] = _db.SoilMoistureDatas.Where(s => s.LineNr == 3).OrderByDescending(t => t.RegistrationDate).Take(30).ToList().First().Value.ToString();

            var allData1 = _db.SoilMoistureDatas.Where(s => s.LineNr == 1).OrderByDescending(t => t.RegistrationDate).Take(30).ToList();
            var allData2 = _db.SoilMoistureDatas.Where(s => s.LineNr == 2).OrderByDescending(t => t.RegistrationDate).Take(30).ToList();
            var allData3 = _db.SoilMoistureDatas.Where(s => s.LineNr == 3).OrderByDescending(t => t.RegistrationDate).Take(30).ToList();

            var _sm1ValuesList = new List<SoilMoistureDataViewModel>();
            var _sm2ValuesList = new List<SoilMoistureDataViewModel>();
            var _sm3ValuesList = new List<SoilMoistureDataViewModel>();

            foreach (var item in allData1)
            {
                var _temp = new SoilMoistureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _sm1ValuesList.Add(_temp);

            }
            foreach (var item in allData2)
            {
                var _temp = new SoilMoistureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _sm2ValuesList.Add(_temp);

            }
            foreach (var item in allData3)
            {
                var _temp = new SoilMoistureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _sm3ValuesList.Add(_temp);

            }

            ViewData["sm1ValuesList"] = _sm1ValuesList;
            ViewData["sm2ValuesList"] = _sm2ValuesList;
            ViewData["sm3ValuesList"] = _sm3ValuesList;

            return View();
        }

        public JsonResult updateValues()
        {
            var allData1 = _db.SoilMoistureDatas.Where(s => s.LineNr == 1).OrderByDescending(t => t.RegistrationDate).Take(30).ToList();
            var allData2 = _db.SoilMoistureDatas.Where(s => s.LineNr == 2).OrderByDescending(t => t.RegistrationDate).Take(30).ToList();
            var allData3 = _db.SoilMoistureDatas.Where(s => s.LineNr == 3).OrderByDescending(t => t.RegistrationDate).Take(30).ToList();

            var _sm1ValuesList = new List<SoilMoistureDataViewModel>();
            var _sm2ValuesList = new List<SoilMoistureDataViewModel>();
            var _sm3ValuesList = new List<SoilMoistureDataViewModel>();

            foreach (var item in allData1)
            {
                var _temp = new SoilMoistureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _sm1ValuesList.Add(_temp);

            }
            foreach (var item in allData2)
            {
                var _temp = new SoilMoistureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _sm2ValuesList.Add(_temp);

            }
            foreach (var item in allData3)
            {
                var _temp = new SoilMoistureDataViewModel();
                _temp.Value = item.Value.ToString();
                _temp.RegistrationDate = item.RegistrationDate.ToString("dd-MM-yyyy HH:mm");
                _sm3ValuesList.Add(_temp);

            }

            var model = new
            {
                soilMoisture1 = _db.SoilMoistureDatas.Where(s => s.LineNr == 1).OrderByDescending(t => t.RegistrationDate).Take(30).ToList().First().Value.ToString(),
                soilMoisture2 = _db.SoilMoistureDatas.Where(s => s.LineNr == 2).OrderByDescending(t => t.RegistrationDate).Take(30).ToList().First().Value.ToString(),
                soilMoisture3 = _db.SoilMoistureDatas.Where(s => s.LineNr == 3).OrderByDescending(t => t.RegistrationDate).Take(30).ToList().First().Value.ToString(),
                sm1ValuesList = _sm1ValuesList,
                sm2ValuesList = _sm2ValuesList,
                sm3ValuesList = _sm3ValuesList
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}