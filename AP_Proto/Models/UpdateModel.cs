using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Proto.Models
{
    public class UpdateModel
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Updated { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Details { get; set; }


        public TicketModel ticket { get; set; }
    }
}
