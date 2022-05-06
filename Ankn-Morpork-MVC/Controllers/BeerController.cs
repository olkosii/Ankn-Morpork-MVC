using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.NPCsRepository;
using System.Linq;
using System.Web.Mvc;

namespace Ankn_Morpork_MVC.Controllers
{
    public class BeerController : Controller
    {
        private ApplicationDbContext _context;

        public BeerController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult MendedDrumPub()
        {
            return View();
        }

        public ActionResult ReturnBeerResult(Player player)
        {
            if (!ModelState.IsValid)
                return View("MendedDrumPub");

            var realPlayer = _context.Player.FirstOrDefault();

            realPlayer.BeerAmount += player.BeerAmount;
            realPlayer.MoneyQuantity -= PlayerRepository.CalculateBeerCost(player.BeerAmount);
            realPlayer.IsInPub = false;

            _context.SaveChanges();

            return RedirectToAction("Index", "Game");
        }
    }
}