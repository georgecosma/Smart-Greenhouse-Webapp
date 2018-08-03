using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class TemperatureData : BaseEntity
    {
        public TemperatureData()
        {

        }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}