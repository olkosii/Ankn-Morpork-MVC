namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePlayersTablePropertyValue : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players (PlayerAction)" +
                "VALUES (1)");
        }
        
        public override void Down()
        {
        }
    }
}
