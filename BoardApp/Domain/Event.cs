using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Event
    {
        public int EventId { get; set; }

        [MaxLength(50)]
        public string EventName { get; set; }
        public DateTime EventCreationDate { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }

        [MaxLength(1000)]
        public string EventDescription { get; set; }

        public virtual List<RouteInEvent> Routes { get; set; } = new List<RouteInEvent>(); 

        public UserAccount EventCreator { get; set; }
        // Invite list

    }
}
