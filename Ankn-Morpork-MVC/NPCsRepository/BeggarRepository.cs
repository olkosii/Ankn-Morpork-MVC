using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class BeggarRepository : INPCsRepository
    {
        private ApplicationDbContext _context;

        public BeggarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void PlayerMeetGuildNPC(IGuildNPC npc)
        {
            var player = _context.Player.FirstOrDefault();

            Beggar beggar = (Beggar)npc;

            if(beggar.Name == "Drinker" && player.BeerAmount > 0)
            {
                player.BeerAmount -= 1;

                _context.SaveChanges();

                return;
            }
            else if(beggar.Name == "Drinker" && player.BeerAmount <= 0)
            {
                player.IsAlive = false;

                _context.SaveChanges();

                return;
            }


            if (beggar.PlayerRewardForNPC < player.MoneyQuantity)
                player.MoneyQuantity -= beggar.PlayerRewardForNPC;
            else
            {
                player.MoneyQuantity = 0;
                player.IsAlive = false;
            }

            if (player.MoneyQuantity < 0)
                player.MoneyQuantity = 0;

            _context.SaveChanges();
        }
    }
}