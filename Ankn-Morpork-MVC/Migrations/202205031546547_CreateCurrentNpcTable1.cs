namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCurrentNpcTable1 : DbMigration
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
            
            AlterColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId", c => c.Byte());
            CreateIndex("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId");
            AddForeignKey("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId", "dbo.CurrentNpcs", "NPCTypeId");
            DropColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId", "dbo.CurrentNpcs");
            DropIndex("dbo.Players", new[] { "CurrentNpcTypeForPlay_NPCTypeId" });
            AlterColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId", c => c.Byte(nullable: false));
            DropTable("dbo.CurrentNpcs");
        }
    }
}
