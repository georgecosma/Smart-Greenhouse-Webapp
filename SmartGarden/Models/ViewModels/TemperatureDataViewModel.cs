using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class LuminosityDataViewModel : BaseEntity
    {
        public LuminosityDataViewModel()
        {

        }
        public string Value { get; set; }
        public string RegistrationDate { get; set; }
    }
}