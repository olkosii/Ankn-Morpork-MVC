namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerTableChange : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Players " +
                "SET IsAlive = 1");
        }
        
        public override void Down()
        {
        }
    }
}
