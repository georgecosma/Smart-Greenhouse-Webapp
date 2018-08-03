using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class TemperatureDataViewModel : BaseEntity
    {
        public TemperatureDataViewModel()
        {

        }
        public string Value { get; set; }
        public string RegistrationDate { get; set; }
    }
}