namespace Ankn_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAssasinTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (5,30,1)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (5,15,0)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (7,25,0)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (10,30,0)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (8,20,1)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (6,10,0)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (5,30,1)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (5,17,0)");

            Sql("INSERT INTO Assasins (MinReward,MaxReward,IsBusy)" +
                "VALUES (9,20,0)");
        }
        
        public override void Down()
        {
        }
    }
}
