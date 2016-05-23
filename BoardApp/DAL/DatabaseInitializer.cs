using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Identity;
using Microsoft.AspNet.Identity;

namespace DAL
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            seedIdentity(context);
            seedArticles(context);

            base.Seed(context);
        }

        private void seedIdentity(DataBaseContext context)
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
        }

        private void seedArticles(DataBaseContext context)
        {
            var articleHeadLine = "<h1>ASP.NET</h1>";
            var articleBody =
                "<p class=\"lead\">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.<br/>" +
                "As a demo, here is simple Contact application - log in and save your contacts!</p>";
            var article = new Article()
            {
                ArticleName = "HomeIndex",
                ArticleHeadline =
                    new MultiLangString(articleHeadLine, "en", articleHeadLine, "Article.HomeIndex.ArticleHeadline"),
                ArticleBody = new MultiLangString(articleBody, "en", articleBody, "Article.HomeIndex.ArticleBody")
            };
            context.Articles.Add(article);
            context.SaveChanges();

            context.Translations.Add(new Translation()
            {
                Value = "<h1>ASP.NET on suurepärane!</h1>",
                Culture = "et",
                MultiLangString = article.ArticleHeadline
            });

            context.Translations.Add(new Translation()
            {
                Value =
                    "<p class=\"lead\">ASP.NET on tasuta veebiraamistik suurepäraste veebide arendamiseks kasutades HTML-i, CSS-i, ja JavaScript-i.<br/>" +
                    "Demona on siin lihtne Kontaktirakendus - logi sisse ja salvesta enda kontakte</p>",
                Culture = "et",
                MultiLangString = article.ArticleBody
            });
            context.SaveChanges();
        }
    }
}
