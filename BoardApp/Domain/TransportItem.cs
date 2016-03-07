using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TransportItem
    {
        public int TransportItemId { get; set; }

        [StringLength(50, ErrorMessage = "Name's length must be 1 to 50 characters long.", MinimumLength = 1)]
        public string TransportItemName { get; set; }

        [MaxLength(300)]
        public string TransportItemDescription { get; set; }

        public int TransportItemTypeId { get; set; }
        public TransportItemType TransportItemType { get; set; }


        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public UserAccount Owner { get; set; }
    }
}
