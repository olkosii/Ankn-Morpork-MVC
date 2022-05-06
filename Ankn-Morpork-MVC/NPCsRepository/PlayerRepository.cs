using Ankn_Morpork_MVC.Models;
using System;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class PlayerRepository
    {
        private ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public static int CalculateBeerCost(int beerAmount)
        {
            return beerAmount * 2;
        }

        public bool GoToMendedDrum()
        {
            var player = _context.Player.FirstOrDefault();

            if (player.BeerAmount < 1)
            {
                Random random = new Random();
                var result = random.Next(1, 4);
                if (result == 1)
                {
                    player.IsInPub = true;

                    _context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public void LeaveMendedDrum()
        {
            var player = _context.Player.FirstOrDefault();
            player.IsInPub = false;
            _context.SaveChanges();
        }

        public void PlayerActionIsFalse()
        {
            var player = _context.Player.FirstOrDefault();

            player.PlayerAction = false;

            _context.SaveChanges();
        }
    }
}