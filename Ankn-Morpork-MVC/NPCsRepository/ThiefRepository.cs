using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class ThiefRepository : INPCsRepository
    {
        private ApplicationDbContext _context;
        public static int currentAmountOfThief;

        public ThiefRepository(ApplicationDbContext context)
        {
            currentAmountOfThief++;
            _context = context;
        }

        public static bool CheckIfThiefCanStealPlayerMoney()
        {
            if (currentAmountOfThief <= 6)
                return true;
            else
                return false;
        }

        public void PlayerMeetGuildNPC(IGuildNPC npc)
        {
            var player = _context.Player.FirstOrDefault();

            Thief thief = (Thief)npc;

            if (currentAmountOfThief <= thief.AcceptableAmountOfThefts)
                player.MoneyQuantity -= thief.PlayerRewardForNPC;
            else if (thief.PlayerRewardForNPC > player.MoneyQuantity)
            {
                player.MoneyQuantity = 0;
                player.IsAlive = false;
            }

            if (player.MoneyQuantity < 0)
            {
                player.MoneyQuantity = 0;
                player.IsAlive = false;
            }

            _context.SaveChanges();
        }
    }
}