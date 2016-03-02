using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();

        public virtual List<UserAccount> UserAccounts { get; set; }
    }
}
