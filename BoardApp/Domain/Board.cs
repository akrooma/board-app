using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Board
    {
        public int BoardId { get; set; }

        [MaxLength(50)]
        public string BoardName { get; set; }

        [MaxLength(300)]
        public string BoardDescription { get; set; }

        public int OwnerId { get; set; }
        public UserAccount Owner { get; set; }

        public int RidingStyleId { get; set; }
        public virtual RidingStyle RidingStyle { get; set; }

        public int DeckStyleId { get; set; }
        public DeckStyle DeckStyle { get; set; }

        // universaalsemaks.
    }
}
