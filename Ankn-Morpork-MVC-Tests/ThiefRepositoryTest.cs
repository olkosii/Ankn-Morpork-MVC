using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsRepository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ankn_Morpork_MVC_Tests
{
    public class ThiefRepositoryTest
    {
        private ApplicationDbContext _context;
        ThiefRepository _thiefRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.Thiefs = SetUpThiefs().Object;
            fakeDBContext.Object.Player = SetUpPlayers().Object;
            _context = fakeDBContext.Object;

            _thiefRepository = new ThiefRepository(_context);
            ThiefRepository.currentAmountOfThief = 1;
        }

        [Test]
        public void PlayerMeetGuildNPC_ThiefCanStealPlayerMoney_ThiefStealPlayerMoney()
        {
            var thief = _context.Thiefs.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            _thiefRepository.PlayerMeetGuildNPC(thief);

            Assert.That(player.MoneyQuantity, Is.EqualTo(90));
        }

        [Test]
        public void PlayerMeetGuildNPC_ThiefCanNOTStealPlayerMoney_ThiefDidNotStealPlayerMoney()
        {
            var thief = _context.Thiefs.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            //Thief Acceptable Amount Of Thefts = 6
            ThiefRepository.currentAmountOfThief = 7;
            _thiefRepository.PlayerMeetGuildNPC(thief);

            Assert.That(player.MoneyQuantity, Is.EqualTo(100));
        }

        private Mock<DbSet<Thief>> SetUpThiefs()
        {
            var sourceList = new List<Thief>
            {
                new Thief
                {
                    PlayerRewardForNPC = 10,
                    AcceptableAmountOfThefts = 6
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<Thief>>();
            eventsDbSet.As<IQueryable<Thief>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<Thief>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<Thief>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<Thief>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<Thief>())).Callback<Thief>((s) => sourceList.Add(s));
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
