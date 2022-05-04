using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;

namespace Ankn_Morpork_MVC.NPCsBuilder
{
    public class NPCBuilder
    {
        private INPCBuilder _npcBuilder;

        public NPCBuilder(INPCBuilder npcBuilder)
        {
            _npcBuilder = npcBuilder;
        }

        public IGuildNPC CreateNPC()
        {
            _npcBuilder.NPCBuilder();
            return _npcBuilder.ReturnNPC();
        }
    }
}