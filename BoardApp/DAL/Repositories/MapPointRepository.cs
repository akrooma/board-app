﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class MapPointRepository : EFRepository<MapPoint>, IMapPointRepository
    {
        public MapPointRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
