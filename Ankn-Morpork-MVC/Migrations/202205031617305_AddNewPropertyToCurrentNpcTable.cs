namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPropertyToCurrentNpcTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrentNpcs", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CurrentNpcs", "Id");
        }
    }
}
