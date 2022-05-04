using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class ThiefRepository : INPCsRepository
    {
        private static Thief _thief;

        public static int currentAmountOfThief;

        public ThiefRepository(Thief thief)
        {
            currentAmountOfThief++;
            _thief = thief;
        }

        public static bool CheckIfThiefCanStealPlayerMoney()
        {
            if (currentAmountOfThief <= _thief.AcceptableAmountOfThefts)
                return true;
            else
                return false;
        }

        public void PlayerMeetGuildNPC(Player player)
        {
            Thief thief = (Thief)player.CurrentNpcForPlay;

            if (currentAmountOfThief <= thief.AcceptableAmountOfThefts)
                player.MoneyQuantity -= (decimal)thief.PlayerRewardForNPC;
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
        }
    }
}