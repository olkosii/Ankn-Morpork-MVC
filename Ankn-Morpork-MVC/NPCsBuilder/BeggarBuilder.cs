using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System.Linq;
using System;

namespace Ankn_Morpork_MVC.NPCsBuilder
{
    public class BeggarBuilder : INPCBuilder
    {
        private Beggar _beggar;
        private ApplicationDbContext _context;

        public void NPCBuilder()
        {
            _beggar = new Beggar();
            _context = new ApplicationDbContext();
            GetBeggar();
        }

        private void GetBeggar()
        {
            Random rand = new Random();

            var beggarId = rand.Next(1, _context.Beggars.ToList().Count);

            _beggar = _context.Beggars.FirstOrDefault(b => b.Id == beggarId);
        }

        public IGuildNPC ReturnNPC()
        {
            return _beggar;
        }
    }
}