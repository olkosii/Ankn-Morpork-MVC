using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using Ankn_Morpork_MVC.NPCsBuilder;
using Ankn_Morpork_MVC.NPCsRepository;
using System.Linq;
using System.Web.Mvc;

namespace Ankn_Morpork_MVC.Controllers
{
    public class GameController : Controller
    {
        private Player _player;
        private PlayerBuilder _builder;
        private PlayerRepository _playerRepository;
        private GameRepository _gameRepository;
        private ApplicationDbContext _context;
        private NPCRepository _npcRepository;
        
        
        public GameController()
        {
            _builder = new PlayerBuilder();
            _context = new ApplicationDbContext();
            _gameRepository = new GameRepository();
            _playerRepository = new PlayerRepository(_context); 
            _npcRepository = new NPCRepository(_context);
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
                if (_playerRepository.GoToMendedDrum())
                    return View(_player);
                    
                _player.CurrentNpcForPlay = _gameRepository.GetNpc();
                _npcRepository.GetNPCType(_player);

                return View(_player);
            }
            else
                return RedirectToAction("GameEnd");
        }

        public ActionResult Continue()
        {
            _player = _builder.ReturnPlayer();
            _player.CurrentNpcTypeForPlay = _context.CurrentNpcs.FirstOrDefault();
            _npcRepository.GetNPCById(_player);

            if (_player.CurrentNpcForPlay is Assasin assasin && assasin.PlayerRewardForNPC == 0)
                 return RedirectToAction("GetAssasinReward", "Assasin");

            if (_player.IsInPub)
                return RedirectToAction("MendedDrumPub", "Beer");

            _npcRepository.PlayWith(_player);
            return RedirectToAction("Index");
        }

        public ActionResult Skip()
        {
            _player = _builder.ReturnPlayer();
            _player.CurrentNpcTypeForPlay = _context.CurrentNpcs.FirstOrDefault();
            _npcRepository.GetNPCById(_player);

            if (_player.IsInPub)
            {
                _playerRepository.LeaveMendedDrum();

                return RedirectToAction("Index");
            }

            if (_player.CurrentNpcForPlay is Clown ||
               (_player.CurrentNpcForPlay is Thief && ThiefRepository.CheckIfThiefCanStealPlayerMoney() == false) ||
               (_player.CurrentNpcForPlay == null))
                 return RedirectToAction("Index");

            _playerRepository.PlayerActionIsFalse();

            return RedirectToAction("GameEnd",_player);
        }

        public ActionResult GameEnd(Player player)
        {
            player.CurrentNpcTypeForPlay = _context.CurrentNpcs.FirstOrDefault();
            _npcRepository.GetNPCById(player);

            return View(player);
        }
    }
}