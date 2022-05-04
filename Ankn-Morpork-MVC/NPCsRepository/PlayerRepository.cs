using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class PlayerRepository
    {
        private ApplicationDbContext _context;

        public PlayerRepository()
        {
            _context = new ApplicationDbContext();
        }
        public void GetNPCType(Player player)
        {
            var _currentNpc = _context.CurrentNpcs.FirstOrDefault();

            if (player.CurrentNpcForPlay.GetType().Name == NPCType.Assasin.ToString())
            {
                _currentNpc.NPCTypeId = (byte)NPCType.Assasin;

                _currentNpc.NPCId = player.CurrentNpcForPlay.Id;
            }
            else if (player.CurrentNpcForPlay.GetType().Name == NPCType.Thief.ToString())
            {
                _currentNpc.NPCTypeId = (byte)NPCType.Thief;

                _currentNpc.NPCId = player.CurrentNpcForPlay.Id;
            }
            else if (player.CurrentNpcForPlay.GetType().Name == NPCType.Beggar.ToString())
            {
                _currentNpc.NPCTypeId = (byte)NPCType.Beggar;

                _currentNpc.NPCId = player.CurrentNpcForPlay.Id;
            }
            else if (player.CurrentNpcForPlay.GetType().Name == NPCType.Clown.ToString())
            {
                _currentNpc.NPCTypeId = (byte)NPCType.Clown;

                _currentNpc.NPCId = player.CurrentNpcForPlay.Id;
            }

            _context.SaveChanges();
        }

        public void GetNPCById(Player player)
        {
            switch (player.CurrentNpcTypeForPlay.NPCTypeId)
            {
                case 1:
                    player.CurrentNpcForPlay = _context.Assasins.FirstOrDefault(a => a.Id == player.CurrentNpcTypeForPlay.NPCId);
                    break;
                case 2:
                    player.CurrentNpcForPlay = _context.Thiefs.FirstOrDefault(a => a.Id == player.CurrentNpcTypeForPlay.NPCId);
                    break;
                case 3:
                    player.CurrentNpcForPlay = _context.Beggars.FirstOrDefault(a => a.Id == player.CurrentNpcTypeForPlay.NPCId);
                    break;
                case 4:
                    player.CurrentNpcForPlay = _context.Clowns.FirstOrDefault(a => a.Id == player.CurrentNpcTypeForPlay.NPCId);
                    break;
                default:
                    break;
            }
        }
    }
}