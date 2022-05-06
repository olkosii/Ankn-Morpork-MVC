using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsRepository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ankn_Morpork_MVC_Tests
{
    public class BeggarRepositoryTest
    {
        private ApplicationDbContext _context;
        BeggarRepository _beggarRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.Beggars = SetUpBeggars().Object;
            fakeDBContext.Object.Player = SetUpPlayers().Object;
            _context = fakeDBContext.Object;

            _beggarRepository = new BeggarRepository(_context);
        }

        [Test]
        public void PlayerMeetGuildNPC_BeggarRewardIsLessThanPlayerMoney_BeggarTakePlayerMoney()
        {
            var beggar = _context.Beggars.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            _beggarRepository.PlayerMeetGuildNPC(beggar);

            Assert.That(player.MoneyQuantity, Is.EqualTo(99));
        }

        [Test]
        public void PlayerMeetGuildNPC_BeggarRewardIsMoreThanPlayerMoney_PlayerDied()
        {
            var beggar = _context.Beggars.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            player.MoneyQuantity = 0;
            _beggarRepository.PlayerMeetGuildNPC(beggar);

            Assert.That(!player.IsAlive);
        }

        [Test]
        public void PlayerMeetGuildNPC_BeggarIsDrinkerPlayerHasBeer_BeggarTakeBeer()
        {
            var beggar = _context.Beggars.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            player.BeerAmount = 2;
            beggar.Name = "Drinker";

            _beggarRepository.PlayerMeetGuildNPC(beggar);

            Assert.That(player.BeerAmount,Is.EqualTo(1));
        }

        [Test]
        public void PlayerMeetGuildNPC_BeggarIsDrinkerPlayerDoesNotHaveBeer_PlayerDied()
        {
            var beggar = _context.Beggars.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();
            beggar.Name = "Drinker";

            _beggarRepository.PlayerMeetGuildNPC(beggar);

            Assert.That(!player.IsAlive);
        }

        private Mock<DbSet<Beggar>> SetUpBeggars()
        {
            var sourceList = new List<Beggar>
            {
                new Beggar
                {
                    PlayerRewardForNPC = 1
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<Beggar>>();
            eventsDbSet.As<IQueryable<Beggar>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<Beggar>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<Beggar>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<Beggar>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<Beggar>())).Callback<Beggar>((s) => sourceList.Add(s));
            return eventsDbSet;
        }

        private Mock<DbSet<Player>> SetUpPlayers()
        {
            var sourceList = new List<Player>
            {
                new Player
                {
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
