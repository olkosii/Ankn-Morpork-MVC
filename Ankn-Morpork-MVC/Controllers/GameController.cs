using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using Ankn_Morpork_MVC.NPCsBuilder;
using Ankn_Morpork_MVC.NPCsRepository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Ankn_Morpork_MVC.Controllers
{
    public class GameController : Controller
    {
        private Player _player;
        private PlayerBuilder _builder;
        private ApplicationDbContext _context;
        private GameRepository _gameRepository;
        private PlayerRepository _playerRepository;
        private INPCsRepository _npcsRepository;

        public GameController()
        {
            _builder = new PlayerBuilder();
            _context = new ApplicationDbContext();
            _gameRepository = new GameRepository();
            _playerRepository = new PlayerRepository(); 
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Index()
        {
            _player = _builder.ReturnPlayer();
            if (_player != null && _player.IsAlive && _player.MoneyQuantity < 200 && _player.MoneyQuantity > 0)
            {
                _player.CurrentNpcForPlay = _gameRepository.GetNpc();
                _playerRepository.GetNPCType(_player);

                _context.SaveChanges();

                return View(_player);
            }
            else
                return RedirectToAction("GameEnd");
        }

        public ActionResult Continue()
        {
            _player = _builder.ReturnPlayer();
            _player.CurrentNpcTypeForPlay = _context.CurrentNpcs.FirstOrDefault();
            _playerRepository.GetNPCById(_player);
            _npcsRepository.PlayerMeetGuildNPC(_player);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Skip()
        {
            _player = _builder.ReturnPlayer();

            if (_player.CurrentNpcForPlay is Clown ||
               (_player.CurrentNpcForPlay is Beggar beggar && beggar.Name == "Drinker") ||
               (_player.CurrentNpcForPlay is Thief && ThiefRepository.CheckIfThiefCanStealPlayerMoney() == false))
                return RedirectToAction("Index");

            _player.PlayerAction = false;

            _context.SaveChanges();

            return RedirectToAction("GameEnd");
        }

        public ActionResult GameEnd()
        {
            return View(_player);
        }
    }
}