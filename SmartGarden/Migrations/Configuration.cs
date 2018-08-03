namespace SmartGarden.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.DbModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartGarden.Models.SmartGardenDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartGarden.Models.SmartGardenDbContext context)
        {
            context.Roles.AddOrUpdate(
                    new Role() { Id = 1, Name = "Admin" },
                    new Role() { Id = 2, Name = "Utilizator" }
                   );
        }
    }
}
