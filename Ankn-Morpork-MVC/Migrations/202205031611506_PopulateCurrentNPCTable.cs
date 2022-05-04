namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCurrentNPCTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CurrentNpcs (NPCId,NPCTypeId)" +
                "VALUES (1,1)");
        }
        
        public override void Down()
        {
        }
    }
}
