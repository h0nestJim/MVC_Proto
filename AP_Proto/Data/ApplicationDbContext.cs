using AP_Proto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AP_Proto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        

        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<MeetingModel> Meeting { get; set; }

        public DbSet<AssetModel> AssetModel { get; set; }
        public DbSet<TicketModel> Ticket{ get; set; }
        public DbSet<RoomModel> Room { get; set; }

        public DbSet<UpdateModel> Updates { get; set; }
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
