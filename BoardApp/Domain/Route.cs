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
        public string RouteName { get; set; }

        [MaxLength(1000)]
        public string RouteDescription { get; set; }
        public int RouteRating { get; set; }

        public virtual List<MapPoint> MapPoints { get; set; } = new List<MapPoint>();
        public virtual List<RouteAndCharacteristic> RouteCharacteristics { get; set; } = new List<RouteAndCharacteristic>();
        public virtual List<RouteComment> RouteComments { get; set; } = new List<RouteComment>(); 
        public virtual List<RouteInEvent> RouteInEvents { get; set; } = new List<RouteInEvent>(); 

        /*
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public UserAccount Creator { get; set; }
        */
    }
}
