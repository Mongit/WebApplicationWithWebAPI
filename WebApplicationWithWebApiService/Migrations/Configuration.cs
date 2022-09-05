namespace WebApplicationWithWebApiService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplicationWithWebApiService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplicationWithWebApiService.Data.WebApplicationWithWebApiServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplicationWithWebApiService.Data.WebApplicationWithWebApiServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Contacts.AddOrUpdate( new Contact[] {
                new Contact { Id = 1, FirstName = "Andrew", LastName = "Peters" },
                new Contact { Id = 2, FirstName = "Brice", LastName = "Lambson" },
                new Contact { Id = 3, FirstName = "Rowan", LastName = "Miller" }
            });
        }
    }
}
