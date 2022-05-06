using Ankn_Morpork_MVC.Models;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class NPCRepository
    {
        private INPCsRepository _npcsRepository;
        private ApplicationDbContext _context;

        public NPCRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private INPCsRepository GetRepository(Player player)
        {
           if(player.CurrentNpcForPlay is Assasin)
                return new AssasinRepository(_context);
           else if(player.CurrentNpcForPlay is Beggar)
                return new BeggarRepository(_context);
           else if (player.CurrentNpcForPlay is Thief)
                return new ThiefRepository(_context);
           else if (player.CurrentNpcForPlay is Clown)
                return new ClownRepository(_context);

            return null;
        }

        public void PlayWith(Player player)
        {
            _npcsRepository = GetRepository(player);

            _npcsRepository.PlayerMeetGuildNPC(player.CurrentNpcForPlay);
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