using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Proto.Models
{
    public class AdminDashboardModel
    {
        public List<AssetModel> Assets { get; set; }

        public List<TicketModel> Tickets { get; set; }

    }
}
