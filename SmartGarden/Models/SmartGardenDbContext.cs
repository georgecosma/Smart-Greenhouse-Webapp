using SmartGarden.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartGarden.Models
{
    public class SmartGardenDbContext : DbContext
    {
        public SmartGardenDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        static SmartGardenDbContext()
        {
            Database.SetInitializer<SmartGardenDbContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TemperatureData> TemperatureDatas { get; set; }
        public DbSet<LuminosityData> LuminosityDatas { get; set; }
        public DbSet<SoilMoistureData> SoilMoistureDatas { get; set; }
        public DbSet<SystemModuleState> SystemModuleStates { get; set; }
    }
}