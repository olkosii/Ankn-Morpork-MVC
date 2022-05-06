using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsRepository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ankn_Morpork_MVC_Tests
{
    public class AssasinRepositoryTest
    {
        private ApplicationDbContext _context;
        AssasinRepository _assasinRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.Assasins = SetUpAssasins().Object;
            fakeDBContext.Object.Player = SetUpPlayers().Object;
            _context = fakeDBContext.Object;

            _assasinRepository = new AssasinRepository(_context);
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerProposedRewardAreSuitableForAnAssassin_PlayerIsAliveAssasinTakeMoneyFromPlayer()
        {
            var assasin = _context.Assasins.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            _assasinRepository.PlayerMeetGuildNPC(assasin);

            Assert.That(player.MoneyQuantity, Is.EqualTo(90));
            Assert.That(player.IsAlive);
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerProposedRewardAreNOTSuitableForAnAssassin_PlayerDied()
        {
            var assasin = _context.Assasins.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            //Not suitable reward for this assasin(his minreward wrote in Mock<DbSet<Assasin>>
            assasin.PlayerRewardForNPC = 4;

            _assasinRepository.PlayerMeetGuildNPC(assasin);

            Assert.That(player.MoneyQuantity, Is.EqualTo(0));
            Assert.That(!player.IsAlive);
        }

        private Mock<DbSet<Assasin>> SetUpAssasins()
        {
            var sourceList = new List<Assasin>
            {
                new Assasin
                {
                    MinReward = 5,
                    MaxReward = 15,
                    PlayerRewardForNPC = 10
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<Assasin>>();
            eventsDbSet.As<IQueryable<Assasin>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<Assasin>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<Assasin>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<Assasin>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<Assasin>())).Callback<Assasin>((s) => sourceList.Add(s));
            return eventsDbSet;
        }

        private Mock<DbSet<Player>> SetUpPlayers()
        {
            var sourceList = new List<Player>
            {
                new Player
                {
                    IsAlive = true,
                    MoneyQuantity = 100
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<Player>>();
            eventsDbSet.As<IQueryable<Player>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<Player>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<Player>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<Player>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<Player>())).Callback<Player>((s) => sourceList.Add(s));
            return eventsDbSet;
        }
    }
}
