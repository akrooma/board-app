using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RouteCharacteristic
    {
        public int RouteCharacteristicId { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Comment { get; set; }

        public virtual List<RouteAndCharacteristic> RoutesWithCharacteristic { get; set; } 
    }
}
