namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentNpcs",
                c => new
                    {
                        NPCTypeId = c.Byte(nullable: false),
                        NPCId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NPCTypeId);
            
        }
        
        public override void Down()
        {
        }
    }
}
