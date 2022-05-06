using Ankn_Morpork_MVC.Models;
using System.Web.Mvc;

namespace Ankn_Morpork_MVC.Controllers
{
    public class AssasinController : Controller
    {
        public ActionResult GetAssasinReward()
        {
            return View();
        }

        public ActionResult ReturnReward(Assasin assasin)
        {
            if(!ModelState.IsValid)
                return View("GetAssasinReward");

            return RedirectToAction("Continue", "Game", assasin);
        }
    }
}