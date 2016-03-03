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

        [MaxLength(20)]
        public string RouteCharacteristicName { get; set; }

        [MaxLength(300)]
        public string RouteCharacteristicComment { get; set; }

        public virtual List<RouteAndCharacteristic> Routes { get; set; } 
    }
}
