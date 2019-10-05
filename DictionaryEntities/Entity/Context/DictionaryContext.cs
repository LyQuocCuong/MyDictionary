using DictionaryEntities.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Entity.Context
{
    public class DictionaryContext : DbContext
    {
        public DictionaryContext() : base("name=DictionaryContext")
        {
            Database.SetInitializer<DictionaryContext>(new CreateDatabaseIfNotExists<DictionaryContext>());
        }
            
        public DbSet<WORD> WORD { get; set; }
        public DbSet<MEANING> MEANING { get; set; }
        public DbSet<EXAMPLE> EXAMPLE { get; set; }
        public DbSet<TYPE_WORD> TYPE_WORD { get; set; }
    }
}
