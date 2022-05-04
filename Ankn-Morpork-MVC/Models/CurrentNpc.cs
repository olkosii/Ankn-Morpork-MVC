using Ankn_Morpork_MVC.Models.ModelInterfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ankn_Morpork_MVC.Models
{
    public class CurrentNpc
    {
        public int Id { get; set; }
        public int NPCId { get; set; }
        public byte NPCTypeId { get; set; }
    }
}