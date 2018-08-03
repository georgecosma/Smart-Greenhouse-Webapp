using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class SoilMoistureData : BaseEntity
    {
        public SoilMoistureData()
        {

        }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Nullable<int> LineNr { get; set; }
    }
}