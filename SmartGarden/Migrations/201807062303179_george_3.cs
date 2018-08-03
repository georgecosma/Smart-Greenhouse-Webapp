namespace SmartGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class george_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SystemModuleStates", "Value", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SystemModuleStates", "Value");
        }
    }
}
