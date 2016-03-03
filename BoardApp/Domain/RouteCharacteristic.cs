using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RouteCharacteristic
    {
        public int RouteCharacteristicId { get; set; }
        public string RouteCharacteristicName { get; set; }
        public string RouteCharacteristicComment { get; set; }

        public virtual List<RouteAndCharacteristic> Routes { get; set; } 
    }
}
