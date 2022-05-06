namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewPropertyInPlayerTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Players " +
                "SET IsInPub = 0");
        }
        
        public override void Down()
        {
        }
    }
}
