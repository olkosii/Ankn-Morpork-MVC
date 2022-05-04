namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeThiefTableColumnName : DbMigration
    {
        public override void Up()
        {
            Sql("EXEC sp_rename 'Thiefs.[acceptableAmountOfThefts]','AcceptableAmountOfThefts','COLUMN'");
        }
        
        public override void Down()
        {
        }
    }
}
