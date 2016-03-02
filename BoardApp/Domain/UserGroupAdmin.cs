using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserGroupAdmin
    {
        public int UserGroupAdminId { get; set; }
        public DateTime AcceptanceDate { get; set; }

        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }

        public int UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
