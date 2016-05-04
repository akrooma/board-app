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

        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual List<RouteInEvent> RoutesInEvent { get; set; } = new List<RouteInEvent>(); 

        // Picture?

        //public int UserAccountId { get; set; }
        //public UserAccount EventCreator { get; set; }
        //Invite list
    }
}
