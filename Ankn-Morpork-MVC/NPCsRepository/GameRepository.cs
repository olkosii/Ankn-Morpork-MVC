using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using Ankn_Morpork_MVC.NPCsBuilder;
using System;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class GameRepository
    {
        private NPCBuilder _npcBuilder;
        private INPCBuilder _InpcBuilder;
        private ApplicationDbContext _context;
        public GameRepository()
        {
            _InpcBuilder = GetNpcBuilder();
            _context = new ApplicationDbContext();
            _npcBuilder = new NPCBuilder(_InpcBuilder);
        }

        private INPCBuilder GetNpcBuilder()
        {
            Random random = new Random();
            int builderId = random.Next(1,5);

            switch (builderId)
            {
                case 1:
                    return new AssasinBuilder();
                case 2:
                    return new BeggarBuilder();
                case 3:
                    return new ClownBuilder();
                case 4:
                    return new ThiefBuilder();
                default:
                    return null;
            }
        }

        public IGuildNPC GetNpc()
        {
            var npc = _npcBuilder.CreateNPC();

            return npc;
        }

        internal void StartGameState()
        {
            var startGamePlayer = _context.Player.FirstOrDefault();
            var currentNpcForGame = _context.CurrentNpcs.FirstOrDefault();
            var assasinsList = _context.Assasins.ToList();
            ThiefRepository.currentAmountOfThief = 0;

            currentNpcForGame.NPCId = 0;
            currentNpcForGame.NPCTypeId = 0;

            startGamePlayer.MoneyQuantity = 100;
            startGamePlayer.IsAlive = true;
            startGamePlayer.PlayerAction = true;
            startGamePlayer.BeerAmount = 0;
            startGamePlayer.IsInPub = false;

            foreach (var assasin in assasinsList)
            {
                assasin.PlayerRewardForNPC = 0;
            }

            _context.SaveChanges();
        }
    }
}