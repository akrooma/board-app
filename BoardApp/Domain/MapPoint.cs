using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MapPoint
    {
        public int MapPointId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}
