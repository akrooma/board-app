using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransportItemTypeAttributeValue
    {
        public int TransportItemTypeAttributeValueId { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public int TransportItemTypeAttributeId { get; set; }
        public virtual TransportItemTypeAttribute TransportItemTypeAttribute { get; set; } 
    }
}
