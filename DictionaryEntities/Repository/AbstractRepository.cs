using DictionaryEntities.Entity.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Repository
{
    public abstract class AbstractRepository<T> where T : class
    {
        protected DbSet<T> DataSet { get; set; }
        protected DictionaryRepository Repository { get; set; }

        public AbstractRepository()
        {

        }

        public AbstractRepository(DictionaryRepository repository)
        {
            Repository = repository;
            DataSet = repository.Context.Set<T>();
        }
    }
}
