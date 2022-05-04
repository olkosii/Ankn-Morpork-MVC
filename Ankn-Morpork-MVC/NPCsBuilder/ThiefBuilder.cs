using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsBuilder
{
    public class ThiefBuilder : INPCBuilder
    {
        private Thief _thief;
        private ApplicationDbContext _context;

        public void NPCBuilder()
        {
            _thief = new Thief();
            _context = new ApplicationDbContext();
            GetThief();
        }

        private void GetThief()
        {
            _thief = _context.Thiefs.FirstOrDefault();
        }

        public IGuildNPC ReturnNPC()
        {
            return _thief;
        }
    }
}