using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;

namespace Ankn_Morpork_MVC.Models
{
    public class Clown : IGuildNPC
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? PlayerRewardForNPC { get; set; }
    }
}