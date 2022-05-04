using System;

namespace Ankn_Morpork_MVC.Models.ModelInterfaces
{
    public interface IPlayer
    {
        bool IsAlive { get; set; }

        decimal MoneyQuantity { get; set; }

        bool PlayerAction { get; set; }
    }
}
