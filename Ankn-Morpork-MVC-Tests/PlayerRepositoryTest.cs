using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsRepository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ankn_Morpork_MVC_Tests
{
    public class PlayerRepositoryTest
    {
        private ApplicationDbContext _context;
        PlayerRepository _playerRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.Player = SetUpPlayers().Object;
            _context = fakeDBContext.Object;

            _playerRepository = new PlayerRepository(_context);
        }

        [Test]
        public void PlayerActionIsFalse_WhenCalled_PlayerActionIsFalse()
        {
            var player = _context.Player.FirstOrDefault();

            player.PlayerAction = true;

            _playerRepository.PlayerActionIsFalse();

            Assert.IsFalse(player.PlayerAction);
        }

        [Test]
        public void LeaveMendedDrum_PlayerIsInPub_PlayerLeavePub()
        {
            var player = _context.Player.FirstOrDefault();

            player.IsInPub = true;

            _playerRepository.LeaveMendedDrum();

            Assert.IsFalse(player.IsInPub);
        }

        [Test]
        public void GoToMendedDrum_PlayerAlreadyHasBeer_RetuenFalse()
        {
            var player = _context.Player.FirstOrDefault();

            player.BeerAmount = 1;

            var result = _playerRepository.GoToMendedDrum();

            Assert.That(result, Is.False);
        }

        [Test]
        public void CalculateBeerCost_PlayerBoughtOneBeer_RetuenTwo()
        {
            var result = PlayerRepository.CalculateBeerCost(1);

            Assert.That(result, Is.EqualTo(2));
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
