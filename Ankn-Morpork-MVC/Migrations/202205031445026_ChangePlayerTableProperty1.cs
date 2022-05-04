namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePlayerTableProperty1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "CurrentNpcTypeForPlay", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "CurrentNpcTypeForPlay", c => c.Byte());
        }
    }
}
