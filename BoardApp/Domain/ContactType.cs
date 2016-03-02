using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        public string ContactTypeValue { get; set; }

        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
