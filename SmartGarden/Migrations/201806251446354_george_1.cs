namespace SmartGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class george_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LuminosityDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SoilMoistureDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegistrationDate = c.DateTime(nullable: false),
                        LineNr = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemperatureDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TemperatureDatas");
            DropTable("dbo.SoilMoistureDatas");
            DropTable("dbo.LuminosityDatas");
        }
    }
}
