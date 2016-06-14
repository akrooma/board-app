using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class TransportItem
    {
        public int TransportItemId { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        //[StringLength(50, ErrorMessage = "Name's length must be 1 to 50 characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public int TransportItemTypeId { get; set; }
        public virtual TransportItemType TransportItemType { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual UserInt Owner { get; set; }
    }
}
