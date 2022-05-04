namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePlayerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "CurrentNpcTypeForPlay", c => c.Byte());
            DropColumn("dbo.Players", "CurrentNpcForPlay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "CurrentNpcForPlay", c => c.Byte());
            DropColumn("dbo.Players", "CurrentNpcTypeForPlay");
        }
    }
}
