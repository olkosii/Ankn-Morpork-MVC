using Ankn_Morpork_MVC.Models.ModelInterfaces;
using Ankn_Morpork_MVC.NPCsBuilder;
using System;
using System.Linq;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public class GameRepository
    {
        private NPCBuilder _npcBuilder;
        private INPCBuilder _InpcBuilder;
        public GameRepository()
        {
            _InpcBuilder = GetNpcBuilder();
            _npcBuilder = new NPCBuilder(_InpcBuilder);
        }

        private INPCBuilder GetNpcBuilder()
        {
            Random random = new Random();
            int builderId = random.Next(1,5);

            switch (builderId)
            {
                case 1:
                    return new AssasinBuilder();
                case 2:
                    return new BeggarBuilder();
                case 3:
                    return new ClownBuilder();
                case 4:
                    return new ThiefBuilder();
                default:
                    return null;
            }
        }

        public IGuildNPC GetNpc()
        {
            var npc = _npcBuilder.CreateNPC();

            return npc;
        }

    }
}