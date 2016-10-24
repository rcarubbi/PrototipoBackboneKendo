namespace PrototipoPOC.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PrototipoPOC.DAL.EntitiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PrototipoPOC.DAL.EntitiesContext context)
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


            context.Pessoas.AddOrUpdate(p => p.Nome, new Pessoa { Nome = "Raphael" }, 
                new Pessoa { Nome = "Ricardo" }, 
                new Pessoa { Nome = "Marcus" }, 
                new Pessoa { Nome = "Samantha" }, 
                new Pessoa { Nome = "Nicholas" });

        }
    }
}
