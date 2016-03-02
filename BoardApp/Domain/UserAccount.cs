﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int OwnerId { get; set; }
        public virtual Person Owner { get; set; }
    }
}
