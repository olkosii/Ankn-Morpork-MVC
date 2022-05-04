using Ankn_Morpork_MVC.Models;
using System;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class ClownRepository : INPCsRepository
    {
        public void PlayerMeetGuildNPC(Player player)
        {
            Clown clown = (Clown)player.CurrentNpcForPlay;

            player.MoneyQuantity += (decimal)clown.PlayerRewardForNPC;
        }
    }
}