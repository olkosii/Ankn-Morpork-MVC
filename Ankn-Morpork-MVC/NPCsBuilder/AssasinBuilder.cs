using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsBuilder
{
    public class AssasinBuilder : INPCBuilder
    {
        private Assasin _assasin;
        private ApplicationDbContext _context;

        public void NPCBuilder()
        {
            _assasin = new Assasin();
            _context = new ApplicationDbContext();
            GetAssasin();
        }

        private int[] GetNotBusyAssasinsId()
        {
            var assasinsArray = _context.Assasins.Where(a => a.IsBusy == false).ToArray();

            var assasinsIdArray = assasinsArray.Select(a => a.Id).ToArray();

            return assasinsIdArray;
        }

        private int GetRandomAssasinId()
        {
            Random rand = new Random();

            int[] assasinsIdArray = GetNotBusyAssasinsId();

            var randomIndex = rand.Next(1,assasinsIdArray.Length);

            return assasinsIdArray[randomIndex];
        }

        private void GetAssasin()
        {
            var assasinId = GetRandomAssasinId();

            _assasin = _context.Assasins.FirstOrDefault(a => a.Id == assasinId);
        }

        public IGuildNPC ReturnNPC()
        {
            return _assasin;
        }
    }
}