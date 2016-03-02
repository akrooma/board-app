using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserGroup
    {
        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public DateTime CreationDateTime { get; set; }

        public int CreatorId { get; set; }
        public UserAccount Creator { get; set; }
    }
}
