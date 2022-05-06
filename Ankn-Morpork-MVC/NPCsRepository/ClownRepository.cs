using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class ClownRepository : INPCsRepository
    {
        private ApplicationDbContext _context;

        public ClownRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void PlayerMeetGuildNPC(IGuildNPC npc)
        {
            var player = _context.Player.FirstOrDefault();

            Clown clown = (Clown)npc;

            player.MoneyQuantity += clown.PlayerRewardForNPC;

            _context.SaveChanges();
        }
    }
}