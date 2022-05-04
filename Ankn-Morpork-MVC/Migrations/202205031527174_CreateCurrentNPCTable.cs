namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCurrentNPCTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentNPC",
                c => new
                {
                    NPCId = c.Int(nullable: false),
                    NPCTypeId = c.Int(nullable: false)
                });
        }
        
        public override void Down()
        {
        }
    }
}
