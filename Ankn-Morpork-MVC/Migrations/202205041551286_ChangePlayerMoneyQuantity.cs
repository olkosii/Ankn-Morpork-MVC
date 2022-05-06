namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePlayerMoneyQuantity : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Players " +
                "SET MoneyQuantity = 100");
        }
        
        public override void Down()
        {
        }
    }
}
