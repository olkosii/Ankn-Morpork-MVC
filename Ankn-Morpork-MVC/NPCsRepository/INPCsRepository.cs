using Ankn_Morpork_MVC.Models.ModelInterfaces;

namespace Ankn_Morpork_MVC.NPCsRepository
{
    public interface INPCsRepository
    {
        void PlayerMeetGuildNPC(IGuildNPC npc);
    }
}
