using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Route
    {
        public int RouteId { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        public int Rating { get; set; }

        public virtual List<MapPoint> MapPoints { get; set; } = new List<MapPoint>();
        public virtual List<RouteAndCharacteristic> Characteristics { get; set; } = new List<RouteAndCharacteristic>();
        public virtual List<RouteComment> Comments { get; set; } = new List<RouteComment>(); 
        public virtual List<RouteInEvent> InEvents { get; set; } = new List<RouteInEvent>(); 

        /*
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public UserAccount Creator { get; set; }
        */
    }
}
