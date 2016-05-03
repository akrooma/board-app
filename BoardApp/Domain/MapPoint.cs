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
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        //public int UserAccountId { get; set; }
        public int CreatorId { get; set; }
        public UserAccount Creator { get; set; }
    }
}
