using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactValue { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
}
