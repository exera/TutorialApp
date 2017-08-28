namespace Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web.Models.TutorialAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Web.Models.TutorialAppContext";
        }

        protected override void Seed(Web.Models.TutorialAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Cities.AddOrUpdate(p => p.Name,
                new Models.City { Name = "Ýstanbul" },
                new Models.City { Name = "Ankara" },
                new Models.City { Name = "Ýzmir" }
            );

            // while assigning FK
            // use CityId instead of City nav. property
            context.SaveChanges();
            context.Districts.AddOrUpdate(p => p.Name,
                new Models.District { Name = "Pendik", CityId = context.Cities.FirstOrDefault(c => c.Name == "Ýstanbul").Id },
                new Models.District { Name = "Kartal", CityId = context.Cities.FirstOrDefault(c => c.Name == "Ýstanbul").Id },
                new Models.District { Name = "Sancaktepe", CityId = context.Cities.FirstOrDefault(c => c.Name == "Ýstanbul").Id },
                new Models.District { Name = "Çankaya", CityId = context.Cities.FirstOrDefault(c => c.Name == "Ankara").Id },
                new Models.District { Name = "Mamak", CityId = context.Cities.FirstOrDefault(c => c.Name == "Ankara").Id },
                new Models.District { Name = "Alsancak", CityId = context.Cities.FirstOrDefault(c => c.Name == "Ýzmir").Id },
                new Models.District { Name = "Seferihisar", CityId = context.Cities.FirstOrDefault(c => c.Name == "Ýzmir").Id }
            );
        }
        
    }
}
