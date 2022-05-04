namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBeggarTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beggars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlayerRewardForNPC = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Beggars");
        }
    }
}
