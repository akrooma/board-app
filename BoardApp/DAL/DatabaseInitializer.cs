using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;
using Microsoft.AspNet.Identity;

namespace DAL
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            var passwordHasher = new PasswordHasher();

            // Roles
            context.RolesInt.Add(new RoleInt()
            {
                Name = "Admin"
            });

            context.SaveChanges();

            context.RolesInt.Add(new RoleInt()
            {
                Name = "Regular"
            });

            context.SaveChanges();

            // Users
            context.UsersInt.Add(new UserInt()
            {
                UserName = "1@eesti.ee",
                Email = "1@eesti.ee",
                FirstName = "Super",
                LastName = "User",
                PasswordHash = passwordHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.SaveChanges();

            context.UsersInt.Add(new UserInt()
            {
                UserName = "1001@eesti.ee",
                Email = "1001@eesti.ee",
                FirstName = "Pööbel",
                LastName = "User",
                PasswordHash = passwordHasher.HashPassword("b"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.SaveChanges();

            // Users in Roles
            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "1@eesti.ee"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Admin")
            });

            context.SaveChanges();

            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "1001@eesti.ee"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Regular")
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
