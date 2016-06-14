using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class TransportItemRepository : EFRepository<TransportItem>, ITransportItemRepository
    {
        public TransportItemRepository(IDbContext dbContext) : base(dbContext)
        {
        }

	    public TransportItem GetForUser(int transportItemId, int userId)
	    {
			return DbSet.FirstOrDefault(t => t.TransportItemId == transportItemId && t.OwnerId == userId);
	    }
    }
}
