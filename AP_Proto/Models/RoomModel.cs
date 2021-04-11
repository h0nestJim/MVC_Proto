using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Proto.Models
{
    public class RoomModel
    {
        [Key]
        public string RoomNumber { get; set; }
        [Required]
        public Campus campus { get; set; }
        [Required]
        public string Description { get; set; }
        
    }

   public enum Campus
    {
        Bridgwater=1,
        Taunton=2,
        Cannington=3
    }

}
