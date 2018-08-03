using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class SoilMoistureDataViewModel : BaseEntity
    {
        public SoilMoistureDataViewModel()
        {

        }
        public string Value { get; set; }
        public string RegistrationDate { get; set; }
    }
}