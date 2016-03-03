using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class EventRepository : EFRepository<Event>, IEventRepository
    {
        public EventRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
