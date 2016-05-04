using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Migrations;
using Domain;
using DAL.Interfaces;

namespace DAL
{
    public class DataBaseContext : DbContext, IDbContext
    {
        public DataBaseContext() : base("name=BoardAppDbConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, DbMigrationConfiguration>());

            Database.SetInitializer(new DropCreateDatabaseAlways<DataBaseContext>());

#if DEBUG
            //Database.Log = Console.WriteLine;
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<MapPoint> MapPoints { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteComment> RouteComments { get; set; }
        public DbSet<RouteCharacteristic> RouteCharacteristics { get; set; }
        public DbSet<RouteAndCharacteristic> RouteAndCharacteristics { get; set; }
        public DbSet<RouteInEvent> RouteInEvents { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<TransportItem> TransportItems { get; set; }
        public DbSet<TransportItemType> TransportItemTypes { get; set; }
        public DbSet<TransportItemTypeAttribute> TransportItemTypeAttributes { get; set; }
        public DbSet<TransportItemTypeAttributeValue> TransportItemTypeAttributeValues { get; set; }
}
}
