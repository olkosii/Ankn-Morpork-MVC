using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsRepository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ankn_Morpork_MVC_Tests
{
    public class NPCRepositoryTest
    {
        private ApplicationDbContext _context;
        NPCRepository _npcRepository;

        [SetUp]
        public void Setup()
        {
            var fakeDBContext = new Mock<ApplicationDbContext>();
            fakeDBContext.Object.Player = SetUpPlayers().Object;
            fakeDBContext.Object.Assasins = SetUpAssasins().Object;
            fakeDBContext.Object.Beggars = SetUpBeggars().Object;
            fakeDBContext.Object.Clowns = SetUpClowns().Object;
            fakeDBContext.Object.Thiefs = SetUpThiefs().Object;
            fakeDBContext.Object.CurrentNpcs = SetUpCurrentNPC().Object;
            _context = fakeDBContext.Object;

            _npcRepository = new NPCRepository(_context);
        }

        [Test]
        public void GetNPCType_CurrentNpcForPlayIsAssasin_CurrentNPCNPCTypeIdIsOneNPCIdIsOne()
        {
            var player = _context.Player.FirstOrDefault();
            var currentNpc = _context.CurrentNpcs.FirstOrDefault();

            player.CurrentNpcForPlay = new Assasin() { Id = 1 };
            _npcRepository.GetNPCType(player);

            Assert.That(currentNpc.NPCTypeId == (byte)NPCType.Assasin);
            Assert.That(currentNpc.NPCId == player.CurrentNpcForPlay.Id);
        }

        [Test]
        public void GetNPCType_CurrentNpcForPlayIsThief_CurrentNPCNPCTypeIdIsOneNPCIdIsOne()
        {
            var player = _context.Player.FirstOrDefault();
            var currentNpc = _context.CurrentNpcs.FirstOrDefault();

            player.CurrentNpcForPlay = new Thief() { Id = 1 };
            _npcRepository.GetNPCType(player);

            Assert.That(currentNpc.NPCTypeId == (byte)NPCType.Thief);
            Assert.That(currentNpc.NPCId == player.CurrentNpcForPlay.Id);
        }

        [Test]
        public void GetNPCType_CurrentNpcForPlayIsClown_CurrentNPCNPCTypeIdIsOneNPCIdIsOne()
        {
            var player = _context.Player.FirstOrDefault();
            var currentNpc = _context.CurrentNpcs.FirstOrDefault();

            player.CurrentNpcForPlay = new Clown() { Id = 1 };
            _npcRepository.GetNPCType(player);

            Assert.That(currentNpc.NPCTypeId == (byte)NPCType.Clown);
            Assert.That(currentNpc.NPCId == player.CurrentNpcForPlay.Id);
        }

        [Test]
        public void GetNPCType_CurrentNpcForPlayIsBeggar_CurrentNPCNPCTypeIdIsOneNPCIdIsOne()
        {
            var player = _context.Player.FirstOrDefault();
            var currentNpc = _context.CurrentNpcs.FirstOrDefault();

            player.CurrentNpcForPlay = new Beggar() { Id = 1 };
            _npcRepository.GetNPCType(player);

            Assert.That(currentNpc.NPCTypeId == (byte)NPCType.Beggar);
            Assert.That(currentNpc.NPCId == player.CurrentNpcForPlay.Id);
        }

        [Test]
        public void GetNPCById_PlayerCurrentNpcTypeForPlayNPCTypeIdIsOne_PlayerCurrentNpcForPlayIsAssasinWithIdOne()
        {
            var player = _context.Player.FirstOrDefault();
            player.CurrentNpcTypeForPlay = _context.CurrentNpcs.FirstOrDefault();

            _npcRepository.GetNPCById(player);

            Assert.That(player.CurrentNpcForPlay is Assasin assasin && assasin.Id == player.CurrentNpcTypeForPlay.NPCId);
        }

        [Test]
        public void GetNPCById_PlayerCurrentNpcTypeForPlayNPCTypeIdIsTwo_PlayerCurrentNpcForPlayIsThiefWithIdOne()
        {
            var player = _context.Player.FirstOrDefault();
            var currentNpc = _context.CurrentNpcs.FirstOrDefault();
            currentNpc.NPCTypeId = (byte)NPCType.Thief;
            player.CurrentNpcTypeForPlay = currentNpc;

            _npcRepository.GetNPCById(player);

            Assert.That(player.CurrentNpcForPlay is Thief thief && thief.Id == player.CurrentNpcTypeForPlay.NPCId);
        }

        [Test]
        public void GetNPCById_PlayerCurrentNpcTypeForPlayNPCTypeIdIsThree_PlayerCurrentNpcForPlayIsBeggarWithIdOne()
        {
            var player = _context.Player.FirstOrDefault();
            var currentNpc = _context.CurrentNpcs.FirstOrDefault();
            currentNpc.NPCTypeId = (byte)NPCType.Beggar;
            player.CurrentNpcTypeForPlay = currentNpc;

            _npcRepository.GetNPCById(player);

            Assert.That(player.CurrentNpcForPlay is Beggar beggar && beggar.Id == player.CurrentNpcTypeForPlay.NPCId);
        }

        [Test]
        public void GetNPCById_PlayerCurrentNpcTypeForPlayNPCTypeIdIsFour_PlayerCurrentNpcForPlayIsClownWithIdOne()
        {
            var player = _context.Player.FirstOrDefault();
            var currentNpc = _context.CurrentNpcs.FirstOrDefault();
            currentNpc.NPCTypeId = (byte)NPCType.Clown;
            player.CurrentNpcTypeForPlay = currentNpc;

            _npcRepository.GetNPCById(player);

            Assert.That(player.CurrentNpcForPlay is Clown clown && clown.Id == player.CurrentNpcTypeForPlay.NPCId);
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

        private Mock<DbSet<Assasin>> SetUpAssasins()
        {
            var sourceList = new List<Assasin>
            {
                new Assasin
                {
                    Id = 1
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

        private Mock<DbSet<Beggar>> SetUpBeggars()
        {
            var sourceList = new List<Beggar>
            {
                new Beggar
                {
                    Id = 1
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

        private Mock<DbSet<Clown>> SetUpClowns()
        {
            var sourceList = new List<Clown>
            {
                new Clown
                {
                    Id = 1
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

        private Mock<DbSet<Thief>> SetUpThiefs()
        {
            var sourceList = new List<Thief>
            {
                new Thief
                {
                    Id = 1
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

        private Mock<DbSet<CurrentNpc>> SetUpCurrentNPC()
        {
            var sourceList = new List<CurrentNpc>
            {
                new CurrentNpc
                {
                    NPCId = 1,
                    NPCTypeId = 1,
                }
            };
            var queryable = sourceList.AsQueryable();
            var eventsDbSet = new Mock<DbSet<CurrentNpc>>();
            eventsDbSet.As<IQueryable<CurrentNpc>>().Setup(m => m.Provider).Returns(queryable.Provider);
            eventsDbSet.As<IQueryable<CurrentNpc>>().Setup(m => m.Expression).Returns(queryable.Expression);
            eventsDbSet.As<IQueryable<CurrentNpc>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            eventsDbSet.As<IQueryable<CurrentNpc>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            eventsDbSet.Setup(d => d.Add(It.IsAny<CurrentNpc>())).Callback<CurrentNpc>((s) => sourceList.Add(s));
            return eventsDbSet;
        }
    }
}
