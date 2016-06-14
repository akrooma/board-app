using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
	public class TransportItemAndAttributeValueRepository : EFRepository<TransportItemAndAttributeValue>, ITransportItemAndAttributeValueRepository
	{
		public TransportItemAndAttributeValueRepository(IDbContext dbContext) : base(dbContext)
        {
		}

		public bool CombinationNotExists(int transportItemId, int attributeValueId)
		{
			return DbSet.SingleOrDefault(
				t => t.TransportItemId == transportItemId && 
				t.TransportItemTypeAttributeValueId == attributeValueId) == null;
		}
	}
}