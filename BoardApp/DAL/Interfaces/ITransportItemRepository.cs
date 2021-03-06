﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface ITransportItemRepository : IEFRepository<TransportItem>
    {
	    TransportItem GetForUser(int transportItemId, int userId);
    }
}
