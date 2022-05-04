using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ankn_Morpork_MVC.Controllers
{
    public class PlayerController : Controller
    {
        private Player _player;
        private PlayerBuilder _builder;
        private ApplicationDbContext _context;

        public PlayerController()
        {
            _builder = new PlayerBuilder();
            _context = new ApplicationDbContext();

            _player = _builder.ReturnPlayer();
        }

    }
}