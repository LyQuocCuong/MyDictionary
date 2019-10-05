namespace DictionaryEntities.Migrations
{
    using DictionaryEntities.Entity.Models;
    using DictionaryHelper;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DictionaryEntities.Entity.Context.DictionaryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DictionaryEntities.Entity.Context.DictionaryContext context)
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
            
            //Init TypeWord data
            foreach(TypeWordHelper typeWord in CommonVariable.Type_Word_List)
            {
                context.TYPE_WORD.AddOrUpdate(new TYPE_WORD { ID = typeWord.Id, TYPE_TEXT = typeWord.Text, DELETED = false });
            }

        }
    }
}
