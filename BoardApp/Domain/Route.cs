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
        public string RouteDescription { get; set; }

        public virtual List<MapPoint> MapPoints { get; set; } 
    }
}
