using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotations;
using DAL.EFConfiguration;
using DAL.Helpers;
using DAL.Migrations;
using Domain;
using DAL.Interfaces;
using Domain.Identity;

namespace DAL
{
    public class DataBaseContext : DbContext, IDbContext
    {
        public DataBaseContext() : base("name=BoardAppDbConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, DbMigrationConfiguration>());

            Database.SetInitializer(new DatabaseInitializer());

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

        // Identity tables, PK - int

        public IDbSet<RoleInt> RolesInt { get; set; }
        public IDbSet<UserClaimInt> UserClaimsInt { get; set; }
        public IDbSet<UserLoginInt> UserLoginsInt { get; set; }
        public IDbSet<UserInt> UsersInt { get; set; }
        public IDbSet<UserRoleInt> UserRolesInt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // remove tablename pluralizing
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // remove cascade delete
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Identity, PK - string 
            //modelBuilder.Configurations.Add(new RoleMap());
            //modelBuilder.Configurations.Add(new UserClaimMap());
            //modelBuilder.Configurations.Add(new UserLoginMap());
            //modelBuilder.Configurations.Add(new UserMap());
            //modelBuilder.Configurations.Add(new UserRoleMap());

            // Identity, PK - int 
            modelBuilder.Configurations.Add(new RoleIntMap());
            modelBuilder.Configurations.Add(new UserClaimIntMap());
            modelBuilder.Configurations.Add(new UserLoginIntMap());
            modelBuilder.Configurations.Add(new UserIntMap());
            modelBuilder.Configurations.Add(new UserRoleIntMap());

            Precision.ConfigureModelBuilder(modelBuilder);

            // convert all datetime and datetime? properties to datetime2 in ms sql
            // ms sql datetime has min value of 1753-01-01 00:00:00.000
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            // use Date type in ms sql, where [DataType(DataType.Date)] attribute is used
            modelBuilder.Properties<DateTime>()
               .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
               .Any(a => a.DataType == DataType.Date))
               .Configure(c => c.HasColumnType("date"));

        }

        public override int SaveChanges()
        {
            // or watch this inside exception ((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        protected override void Dispose(bool disposing)
        {
            //_logger.Info("Disposing: " + disposing + " _instanceId: " + _instanceId);
            base.Dispose(disposing);
        }
    }
}
