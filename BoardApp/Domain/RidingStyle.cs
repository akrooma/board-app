using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RidingStyle
    {
        public int RidingStyleId { get; set; }

        [MaxLength(20)]
        public string RidingStyleName { get; set; }

        [MaxLength(300)]
        public string RidingStyleComment { get; set; } // make it nullable?

        public List<Board> Boards { get; set; } = new List<Board>(); 
    }
}
