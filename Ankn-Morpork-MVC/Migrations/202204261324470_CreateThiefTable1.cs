namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateThiefTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thiefs", "acceptableAmountOfThefts", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Thiefs", "acceptableAmountOfThefts");
        }
    }
}
