using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransportItemTypeAttributeValue
    {
        public int TransportItemTypeAttributeValueId { get; set; }


        public string TransportItemTypeAttributeValueName { get; set; }


        public string TransportItemTypeAttributeValueDescription { get; set; }

        public int TransportItemTypeAttributeId { get; set; }
        public TransportItemTypeAttribute TransportItemTypeAttribute { get; set; } 
    }
}
