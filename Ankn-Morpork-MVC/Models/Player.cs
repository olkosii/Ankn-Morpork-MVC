using Ankn_Morpork_MVC.Models.ModelInterfaces;
using Ankn_Morpork_MVC.Models;

namespace Ankn_Morpork_MVC.Models
{
    public class Player : IPlayer
    {
        public int Id { get; set; }

        public decimal MoneyQuantity { get; set; }

        public bool PlayerAction { get; set; } = true;

        public bool IsAlive { get; set; }

        public IGuildNPC CurrentNpcForPlay { get; set; }

        public CurrentNpc CurrentNpcTypeForPlay { get; set; }
    }
}