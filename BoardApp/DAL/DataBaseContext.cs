using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=BoardAppDbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, DbMigrationConfiguration>());

#if DEBUG
            //Database.Log = Console.WriteLine;
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<DeckStyle> DeckStyles { get; set; }
        public DbSet<RidingStyle> RidingStyles { get; set; }
        public DbSet<MapPoint> MapPoints { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteComment> RouteComments { get; set; }
        public DbSet<RouteCharacteristic> RouteCharacteristics { get; set; }
        public DbSet<RouteAndCharacteristic> RouteAndCharacteristics { get; set; }
        public DbSet<RouteInEvent> RouteInEvents { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
