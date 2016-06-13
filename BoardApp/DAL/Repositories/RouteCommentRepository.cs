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
    public class RouteCommentRepository : EFRepository<RouteComment>, IRouteCommentRepository
    {
        public RouteCommentRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<RouteComment> GetAllCommentsForRoute(int id)
        {
            return this.All.Where(route => route.RouteId == id).ToList();
        }
    }
}
