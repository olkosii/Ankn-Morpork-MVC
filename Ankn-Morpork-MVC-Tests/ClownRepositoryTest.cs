using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsRepository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ankn_Morpork_MVC_Tests
{
    public class ClownRepositoryTest
    {
        private ApplicationDbContext _context;
        ClownRepository _clownRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.Clowns = SetUpClowns().Object;
            fakeDBContext.Object.Player = SetUpPlayers().Object;
            _context = fakeDBContext.Object;

            _clownRepository = new ClownRepository(_context);
        }

        [Test]
        public void PlayerMeetGuildNPC_PlayerMoneyIs100AndClownRewardIs10_PlayerMoneyIs110()
        {
            var clown = _context.Clowns.FirstOrDefault();
            var player = _context.Player.FirstOrDefault();

            _clownRepository.PlayerMeetGuildNPC(clown);

            Assert.That(player.MoneyQuantity, Is.EqualTo(110));
        }

        private Mock<DbSet<Clown>> SetUpClowns()
        {
            var sourceList = new List<Clown>
            {
                new Clown
                {
                    PlayerRewardForNPC = 10
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<Clown>>();
            eventsDbSet.As<IQueryable<Clown>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<Clown>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<Clown>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<Clown>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<Clown>())).Callback<Clown>((s) => sourceList.Add(s));
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