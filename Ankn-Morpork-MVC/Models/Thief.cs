using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;

namespace Ankn_Morpork_MVC.Models
{
    public class Thief : IGuildNPC
    {
        public int Id { get; set; }

        public decimal? PlayerRewardForNPC { get; set; }

        public int AcceptableAmountOfThefts { get; set; }
    }
}