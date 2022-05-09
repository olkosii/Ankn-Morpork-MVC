using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsBuilder;
using Ankn_Morpork_MVC.NPCsRepository;
using System.Linq;
using System.Web.Mvc;

namespace Ankn_Morpork_MVC.Controllers
{
    public class AssasinController : Controller
    {
        private ApplicationDbContext _context;
        private NPCRepository _npcRepository;
        private Player _player;
        private PlayerBuilder _builder;

        public AssasinController()
        {
            _context = new ApplicationDbContext();
            _npcRepository = new NPCRepository(_context);
            _builder = new PlayerBuilder();
        }

        public ActionResult GetAssasinReward()
        {
            return View();
        }

        public ActionResult ReturnReward(Assasin assasin)
        {
            if(!ModelState.IsValid)
                return View("GetAssasinReward");

            _player = _builder.ReturnPlayer();
            _player.CurrentNpcTypeForPlay = _context.CurrentNpcs.FirstOrDefault();
            _npcRepository.GetNPCById(_player);

            _player.CurrentNpcForPlay.PlayerRewardForNPC = assasin.PlayerRewardForNPC;

            _context.SaveChanges();

            return RedirectToAction("Continue", "Game");
        }
    }
}