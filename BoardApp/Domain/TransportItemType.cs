using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransportItemType
    {
        public int TransportItemTypeId { get; set; }

        [StringLength(50, ErrorMessage = "Name's length must be 1 to 50 characters long.", MinimumLength = 1)]
        public string TransportItemTypeName { get; set; }

        [MaxLength(300)]
        public string TransportItemTypeDescription { get; set; }

        public List<TransportItemTypeAttribute> TransportItemTypeAttributes { get; set; } = new List<TransportItemTypeAttribute>(); 
        public List<TransportItem> TransportItems { get; set; } = new List<TransportItem>(); 
    }
}
