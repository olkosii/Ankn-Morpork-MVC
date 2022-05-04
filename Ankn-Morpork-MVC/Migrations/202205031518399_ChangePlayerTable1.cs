namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePlayerTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCId", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Players", "CurrentNpcTypeForPlay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "CurrentNpcTypeForPlay", c => c.Byte(nullable: false));
            DropColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCTypeId");
            DropColumn("dbo.Players", "CurrentNpcTypeForPlay_NPCId");
        }
    }
}
