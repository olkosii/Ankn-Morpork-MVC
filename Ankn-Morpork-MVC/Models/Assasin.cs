using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.ComponentModel.DataAnnotations;

namespace Ankn_Morpork_MVC.Models
{
    public class Assasin : IGuildNPC
    {
        public int Id { get; set; }

        public int MinReward { get; set; }

        public int MaxReward { get; set; }

        public bool IsBusy { get; set; } 

        [Required(ErrorMessage = "Please enter numbers")]
        [Display(Name = "Reward")]
        public decimal PlayerRewardForNPC { get; set; }
    }
}