using SmartGarden.Models;
using SmartGarden.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartGarden.Controllers
{
    public class ApiController : Controller
    {
        private SmartGardenDbContext _db;
        public ApiController()
        {
            _db = new SmartGardenDbContext();
        }

        public string add(float temperature, int luminosity, int soilMoisture1, int soilMoisture2, int soilMoisture3)
        {
            var modelTemperature = new TemperatureData();
            modelTemperature.RegistrationDate = DateTime.Now;
            modelTemperature.Value = (decimal)temperature;
            _db.TemperatureDatas.Add(modelTemperature);

            var modelLuminosity = new LuminosityData();
            modelLuminosity.RegistrationDate = DateTime.Now;
            modelLuminosity.Value = luminosity;
            _db.LuminosityDatas.Add(modelLuminosity);

            var modelSoilMoisture1 = new SoilMoistureData();
            modelSoilMoisture1.RegistrationDate = DateTime.Now;
            modelSoilMoisture1.LineNr = 1;
            modelSoilMoisture1.Value = soilMoisture1;
            _db.SoilMoistureDatas.Add(modelSoilMoisture1);

            var modelSoilMoisture2 = new SoilMoistureData();
            modelSoilMoisture2.RegistrationDate = DateTime.Now;
            modelSoilMoisture2.LineNr = 2;
            modelSoilMoisture2.Value = soilMoisture2;
            _db.SoilMoistureDatas.Add(modelSoilMoisture2);

            var modelSoilMoisture3 = new SoilMoistureData();
            modelSoilMoisture3.RegistrationDate = DateTime.Now;
            modelSoilMoisture3.LineNr = 3;
            modelSoilMoisture3.Value = soilMoisture3;
            _db.SoilMoistureDatas.Add(modelSoilMoisture3);

            _db.SaveChanges();

            bool manualFansState = _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_FANS").ModuleState;
            bool manualHygrosState = _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_HYGROS").ModuleState;
            bool manualVentState = _db.SystemModuleStates.Single(sms => sms.ModuleName == "MANUAL_AIR_VENT").ModuleState;

            string response = "";

            if (manualFansState)
            {
                response += "sfx ";
            }
            if (manualHygrosState)
            {
                response += "shx ";
            }
            if (manualVentState)
            {
                response += "ovx ";
            }

            return response;
        }
    }
}