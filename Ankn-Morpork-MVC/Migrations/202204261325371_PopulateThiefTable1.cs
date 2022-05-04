namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateThiefTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Thiefs SET acceptableAmountOfThefts = 6" +
                "WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
