namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToPlayerTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "BeerAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "BeerAmount");
        }
    }
}
