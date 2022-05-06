namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPropertyToPlayerTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "IsInPub", c => c.Boolean(nullable: false));
            DropColumn("dbo.Players", "InPub");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "InPub", c => c.Boolean(nullable: false));
            DropColumn("dbo.Players", "IsInPub");
        }
    }
}
