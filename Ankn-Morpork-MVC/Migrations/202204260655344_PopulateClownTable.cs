namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateClownTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('Muggins',0.5)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('Gull',1)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('Dupe',2)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('Butt',3)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('Fool',5)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('Tomfool',6)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('StupidFool',7)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('ArchFool',8)");

            Sql("INSERT INTO Clowns (Name,PlayerRewardForNPC)" +
                "VALUES('CompleteFool',10)");

        }
        
        public override void Down()
        {
        }
    }
}
