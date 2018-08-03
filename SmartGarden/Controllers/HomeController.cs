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
    public class HomeController : Controller
    {
        private SmartGardenDbContext _db;
        public HomeController()
        {
            _db = new SmartGardenDbContext();
        }

        public ActionResult Index()
        {
            ViewData["temperatureValue"] = _db.TemperatureDatas.ToList().Last().Value.ToString();
            ViewData["luminosityValue"] = _db.LuminosityDatas.ToList().Last().Value.ToString();

            ViewData["soilMoisture1"] = _db.SoilMoistureDatas.Where(s => s.LineNr == 1).ToList().Last().Value.ToString();
            ViewData["soilMoisture2"] = _db.SoilMoistureDatas.Where(s => s.LineNr == 2).ToList().Last().Value.ToString();
            ViewData["soilMoisture3"] = _db.SoilMoistureDatas.Where(s => s.LineNr == 3).ToList().Last().Value.ToString();
            return View();
        }

        public ActionResult Statistics()
        {
            return View();
        }

        public ActionResult SystemControl()
        {
            var model = new SystemControlViewModel();

            model.AirVentInterval = _db.SystemModuleStates.Single(sms => sms.ModuleName == "AIR_VENT_INTERVAL").Value;
            model.FansInterval = _db.SystemModuleStates.Single(sms => sms.ModuleName == "FANS_INTERVAL").Value;
            model.HygroInterval = _db.SystemModuleStates.Single(sms => sms.ModuleName == "HYGRO_INTERVAL").Value;
            model.SoilMoistureLimit = _db.SystemModuleStates.Single(sms => sms.ModuleName == "SOIL_MOISTURE_LIMIT").Value;
            model.TemperatureLimit = _db.SystemModuleStates.Single(sms => sms.ModuleName == "TEMPERATURE_LIMIT").Value;


            ViewData["manualFansState"] = _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_FANS").ModuleState;
            ViewData["manualHygrosState"] = _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_HYGROS").ModuleState;
            ViewData["manualAirVentState"] = _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_AIR_VENT").ModuleState;         

            return View(model);
        }
        [HttpPost]
        public ActionResult SystemControl(SystemControlViewModel model)
        {
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "AIR_VENT_INTERVAL").Value = model.AirVentInterval;
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "FANS_INTERVAL").Value = model.FansInterval;
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "HYGRO_INTERVAL").Value = model.HygroInterval;
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "SOIL_MOISTURE_LIMIT").Value = model.SoilMoistureLimit;
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "TEMPERATURE_LIMIT").Value = model.TemperatureLimit;

            _db.SaveChanges();

            return View(model);
        }

        public JsonResult updateValues()
        {
            var model = new
            {
                temperatureValue = _db.TemperatureDatas.ToList().Last().Value.ToString(),
                luminosityValue = _db.LuminosityDatas.ToList().Last().Value.ToString(),
                soilMoisture1 = _db.SoilMoistureDatas.Where(s => s.LineNr == 1).ToList().Last().Value.ToString(),
                soilMoisture2 = _db.SoilMoistureDatas.Where(s => s.LineNr == 2).ToList().Last().Value.ToString(),
                soilMoisture3 = _db.SoilMoistureDatas.Where(s => s.LineNr == 3).ToList().Last().Value.ToString()
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult toggleFans()
        {
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_FANS").ModuleState = !_db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_FANS").ModuleState;
            _db.SaveChanges();

            return Json(_db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_FANS").ModuleState, JsonRequestBehavior.AllowGet);
        }

        public JsonResult toggleAirVent()
        {
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_AIR_VENT").ModuleState = !_db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_AIR_VENT").ModuleState;
            _db.SaveChanges();

            return Json(_db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_AIR_VENT").ModuleState, JsonRequestBehavior.AllowGet);
        }

        public JsonResult toggleHygros()
        {
            _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_HYGROS").ModuleState = !_db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_HYGROS").ModuleState;
            _db.SaveChanges();

            return Json(_db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_HYGROS").ModuleState, JsonRequestBehavior.AllowGet);
        }
    }
}