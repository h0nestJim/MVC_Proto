using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Proto.Models
{
    public class TicketModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Status Ticketstatus {get;set;}

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime RaisedDate { get; set; }

        public DateTime ClosedDate { get; set; }


        public ICollection<UpdateModel> Updates { get; set; }

    }

    public enum Status
    {
        Open=1,
        Closed=2
    }

    public enum TicketType
    {
        Technical=1,
        General=2
    }
}
