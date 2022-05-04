namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePlayerTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players (MoneyQuantity,IsAlive,PlayerAction)" +
                "VALUES(100,1,0)");
        }
        
        public override void Down()
        {
        }
    }
}
