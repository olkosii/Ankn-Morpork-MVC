namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToPlayerTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "CurrentNpcForPlay", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "CurrentNpcForPlay");
        }
    }
}
