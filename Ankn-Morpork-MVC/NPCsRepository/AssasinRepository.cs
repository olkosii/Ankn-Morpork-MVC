using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class AssasinRepository : INPCsRepository
    {
        public void PlayerMeetGuildNPC(Player player)
        {
            Assasin assasin = (Assasin)player.CurrentNpcForPlay;

            if (assasin.MinReward <= assasin.PlayerRewardForNPC && assasin.PlayerRewardForNPC <= assasin.MaxReward)
            {
                player.MoneyQuantity -= (decimal)assasin.PlayerRewardForNPC;
                if (player.MoneyQuantity < 0)
                    player.MoneyQuantity = 0;
            }
            else
            {
                player.MoneyQuantity = 0;
                player.IsAlive = false;
            }
        }
    }
}