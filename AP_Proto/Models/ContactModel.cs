using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Proto.Models
{
    public class ContactModel
    {   
        //class structure for contacts. 
        [Key]
        public int Id { get; set; }

        [Required]
        public string Fname { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(13)]
        public string Tel { get; set; }
    }
}
