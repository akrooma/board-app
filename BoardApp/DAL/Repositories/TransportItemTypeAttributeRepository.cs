using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class TransportItemTypeAttributeRepository : EFRepository<TransportItemTypeAttribute>, ITransportItemTypeAttributeRepository
    {
        public TransportItemTypeAttributeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
