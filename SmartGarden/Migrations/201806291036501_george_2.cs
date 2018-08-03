namespace SmartGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class george_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemModuleStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        ModuleState = c.Boolean(nullable: false),
                        LineNr = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SystemModuleStates");
        }
    }
}
