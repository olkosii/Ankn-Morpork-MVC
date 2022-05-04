using System;

namespace Ankn_Morpork_MVC.Models.ModelInterfaces
{
    public interface IGuildNPC
    {
        int Id { get; set; }
        decimal? PlayerRewardForNPC { get; set; }
    }
}
