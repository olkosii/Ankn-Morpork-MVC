using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.ComponentModel.DataAnnotations;

namespace Ankn_Morpork_MVC.Models
{
    public class Player : IPlayer
    {
        public int Id { get; set; }

        public decimal MoneyQuantity { get; set; } = 100;

        public bool PlayerAction { get; set; } = true;

        public bool IsAlive { get; set; } = true;

        public IGuildNPC CurrentNpcForPlay { get; set; }

        public CurrentNpc CurrentNpcTypeForPlay { get; set; }

        [RegularExpression("[0-2]", ErrorMessage = "You can have maximum 2 pints of beer")]
        [Required(ErrorMessage = "Please enter how many pints of beer you want to buy")]
        [Display(Name ="Glasses amount")]
        public int BeerAmount { get; set; }

        public bool IsInPub { get; set; }
    }
}