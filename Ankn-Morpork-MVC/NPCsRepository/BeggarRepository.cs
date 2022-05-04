using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class BeggarRepository : INPCsRepository
    {
        public void PlayerMeetGuildNPC(Player player)
        {
            Beggar beggar = (Beggar)player.CurrentNpcForPlay;

            if (beggar.PlayerRewardForNPC < player.MoneyQuantity)
                player.MoneyQuantity -= (decimal)beggar.PlayerRewardForNPC;
            else
            {
                player.MoneyQuantity = 0;
                player.IsAlive = false;
            }

            if (player.MoneyQuantity < 0)
                player.MoneyQuantity = 0;
        }
    }
}