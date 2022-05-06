using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.Linq;
using System;

namespace Ankn_Morpork_MVC.NPCsBuilder
{
    public class PlayerBuilder
    {
        private Player _player;
        private ApplicationDbContext _context;

        public PlayerBuilder()
        {
            _context = new ApplicationDbContext();
        }

        public Player ReturnPlayer()
        {
            _player = _context.Player.FirstOrDefault();

            return _player;
        }
    }
}