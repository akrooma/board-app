using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransportItemTypeAttribute
    {
        public int TransportItemTypeAttributeId { get; set; }


        public string TransportItemTypeAttributeName { get; set; }


        public string TransportItemTypeAttributeDescription { get; set; }

        public int TransportItemTypeId { get; set; }
        public TransportItemType TransportItemType { get; set; }

        public List<TransportItemTypeAttributeValue> TransportItemTypeAttributeValues { get; set; } = new List<TransportItemTypeAttributeValue>(); 
    }
}
