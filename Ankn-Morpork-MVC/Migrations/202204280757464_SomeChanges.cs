namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assasins", "PlayerRewardForNPC", c => c.Decimal(nullable: true, precision: 18, scale: 2));
            AlterColumn("dbo.Thiefs", "PlayerRewardForNPC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Thiefs", "PlayerRewardForNPC", c => c.Int(nullable: false));
            DropColumn("dbo.Assasins", "PlayerRewardForNPC");
        }
    }
}
