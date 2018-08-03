using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class SystemControlViewModel : BaseEntity
    {
        public SystemControlViewModel()
        {

        }
        public int FansInterval { get; set; }
        public int AirVentInterval { get; set; }
        public int HygroInterval { get; set; }
        public int TemperatureLimit { get; set; }
        public int SoilMoistureLimit { get; set; }
    }
}