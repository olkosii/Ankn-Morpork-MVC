using Ankn_Morpork_MVC.Models;
using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankn_Morpork_MVC.NPCsBuilder
{
    public class ClownBuilder : INPCBuilder
    {
        private Clown _clown;
        private ApplicationDbContext _context;

        public void NPCBuilder()
        {
            _clown = new Clown();
            _context = new ApplicationDbContext();
            GetClown();
        }

        private void GetClown()
        {
            Random rand = new Random();

            var clownId = rand.Next(1, _context.Clowns.ToList().Count);

            _clown = _context.Clowns.FirstOrDefault(c => c.Id == clownId);
        }

        public IGuildNPC ReturnNPC()
        {
            return _clown;
        }
    }
}