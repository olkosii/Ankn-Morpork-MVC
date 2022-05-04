namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForeignKeyInCurrentNpcTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId", "dbo.CurrentNpcs");
            DropIndex("dbo.Players", new[] { "CurrentNpcTypeForPlay_NPCTypeId" });
            RenameColumn(table: "dbo.Players", name: "CurrentNpcTypeForPlay_NPCTypeId", newName: "CurrentNpcTypeForPlay_Id");
            DropPrimaryKey("dbo.CurrentNpcs");
            AlterColumn("dbo.CurrentNpcs", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Players", "CurrentNpcTypeForPlay_Id", c => c.Int());
            AddPrimaryKey("dbo.CurrentNpcs", "Id");
            CreateIndex("dbo.Players", "CurrentNpcTypeForPlay_Id");
            AddForeignKey("dbo.Players", "CurrentNpcTypeForPlay_Id", "dbo.CurrentNpcs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "CurrentNpcTypeForPlay_Id", "dbo.CurrentNpcs");
            DropIndex("dbo.Players", new[] { "CurrentNpcTypeForPlay_Id" });
            DropPrimaryKey("dbo.CurrentNpcs");
            AlterColumn("dbo.Players", "CurrentNpcTypeForPlay_Id", c => c.Byte());
            AlterColumn("dbo.CurrentNpcs", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CurrentNpcs", "NPCTypeId");
            RenameColumn(table: "dbo.Players", name: "CurrentNpcTypeForPlay_Id", newName: "CurrentNpcTypeForPlay_NPCTypeId");
            CreateIndex("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId");
            AddForeignKey("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId", "dbo.CurrentNpcs", "NPCTypeId");
        }
    }
}
