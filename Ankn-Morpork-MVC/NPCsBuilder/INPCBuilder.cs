using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;

namespace Ankn_Morpork_MVC.NPCsBuilder
{
    public interface INPCBuilder
    {
        IGuildNPC ReturnNPC();
        void NPCBuilder();
    }
}
