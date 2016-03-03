using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Route
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public virtual List<MapPoint> MapPoints { get; set; } = new List<MapPoint>();
        public virtual List<RouteAndCharacteristic> Characteristics { get; set; } = new List<RouteAndCharacteristic>();
    }
}
