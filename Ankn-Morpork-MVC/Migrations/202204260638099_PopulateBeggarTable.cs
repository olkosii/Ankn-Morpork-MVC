namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBeggarTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Twitcher',3)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Drooler',2)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Dribbler',1)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Mumbler',1)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Mutterer',0.9)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Shouter',0.8)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Demander',0.6)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Jimmy',0.5)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('HungryMan',0.08)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('TeaMan',0.02)");

            Sql("INSERT INTO Beggars (Name,PlayerRewardForNPC)" +
                "VALUES('Drinker',0)");
        }
        
        public override void Down()
        {
        }
    }
}
