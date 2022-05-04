namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePlayerTableProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "CurrentNpcForPlay", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "CurrentNpcForPlay", c => c.Byte(nullable: false));
        }
    }
}
