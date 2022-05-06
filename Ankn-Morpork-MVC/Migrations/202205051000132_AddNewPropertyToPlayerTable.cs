namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPropertyToPlayerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "InPub", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "InPub");
        }
    }
}
