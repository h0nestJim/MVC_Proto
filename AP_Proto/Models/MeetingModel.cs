using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Proto.Models
{
    public class MeetingModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Notes { get; set; }

        public DateTime Start {get; set;}
        public DateTime End { get; set; }

    }
}
