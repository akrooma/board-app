using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RouteInEvent
    {
        public int RouteInEventId { get; set; }

        [MaxLength(300)]
        public string RouteInEventComment { get; set; }
        
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
