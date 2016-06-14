using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // attributes a transport item type has. 
    // for example. A longboard (transport item type) has these attributes: deckstyle, ridingstyle etc
    public class TransportItemTypeAttribute
    {
        public int TransportItemTypeAttributeId { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        public string TransportItemTypeAttributeName { get; set; }

        [MaxLength(300)]
        public string TransportItemTypeAttributeDescription { get; set; }

        public int TransportItemTypeId { get; set; }
        public virtual TransportItemType TransportItemType { get; set; }

        public List<TransportItemTypeAttributeValue> Values { get; set; } = new List<TransportItemTypeAttributeValue>(); 
    }
}
