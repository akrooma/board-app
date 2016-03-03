using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DeckStyle
    {
        public int DeckStyleId { get; set; }

        [MaxLength(20)]
        public string DeckStyleName { get; set; }

        [MaxLength(300)]
        public string DeckStyleComment { get; set; } // nullable field ???

        public List<Board> Boards { get; set; } = new List<Board>();
    }
}
