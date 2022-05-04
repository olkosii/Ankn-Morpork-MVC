namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateThiefTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Thiefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerRewardForNPC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Thiefs");
        }
    }
}
