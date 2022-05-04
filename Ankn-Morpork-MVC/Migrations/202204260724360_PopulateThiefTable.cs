namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateThiefTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Thiefs (PlayerRewardForNpc)" +
                "VALUES(10)");
        }
        
        public override void Down()
        {
        }
    }
}
