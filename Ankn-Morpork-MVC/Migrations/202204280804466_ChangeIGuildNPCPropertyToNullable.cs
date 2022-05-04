namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIGuildNPCPropertyToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assasins", "PlayerRewardForNPC", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Beggars", "PlayerRewardForNPC", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Clowns", "PlayerRewardForNPC", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Thiefs", "PlayerRewardForNPC", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Thiefs", "PlayerRewardForNPC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Clowns", "PlayerRewardForNPC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Beggars", "PlayerRewardForNPC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Assasins", "PlayerRewardForNPC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
