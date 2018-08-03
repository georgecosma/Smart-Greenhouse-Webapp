using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class SystemModuleState : BaseEntity
    {
        public SystemModuleState()
        {

        }
        public string ModuleName { get; set; }
        public bool ModuleState { get; set; }
        public Nullable<int> LineNr { get; set; }
        public int Value { get; set; }
    }
}