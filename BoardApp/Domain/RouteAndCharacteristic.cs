using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RouteAndCharacteristic
    {
        public int RouteAndCharacteristicId { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        public int RouteCharacteristicId { get; set; }
        public virtual RouteCharacteristic RouteCharacteristic { get; set; }
    }
}
