using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class AssasinRepository : INPCsRepository
    {
        private ApplicationDbContext _context;

        public AssasinRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public void PlayerMeetGuildNPC(IGuildNPC npc)
        {
            var player = _context.Player.FirstOrDefault();

            Assasin assasin = (Assasin)npc;

            if (assasin.MinReward <= assasin.PlayerRewardForNPC && assasin.PlayerRewardForNPC <= assasin.MaxReward)
            {
                player.MoneyQuantity -= assasin.PlayerRewardForNPC;
                if (player.MoneyQuantity < 0)
                    player.MoneyQuantity = 0;
            }
            else
            {
                player.MoneyQuantity = 0;
                player.IsAlive = false;
            }

            assasin.PlayerRewardForNPC = 0;

            _context.SaveChanges();
        }
    }
}