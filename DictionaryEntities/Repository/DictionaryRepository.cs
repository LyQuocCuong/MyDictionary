using DictionaryEntities.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Repository
{
    public class DictionaryRepository : IDisposable
    {
        private DictionaryContext _context { get; }

        public DictionaryContext Context
        {
            get
            {
                return _context;
            }
        }

        public DictionaryRepository()
        {
            _context = new DictionaryContext();
        }

        public Int32 SaveChanges()
        {
            return _context.SaveChanges();
        }

        private WordRepository _WORD { get; set; }
        public WordRepository WORD
        {
            get
            {
                if (_WORD == null)
                    _WORD = new WordRepository(this);
                return _WORD;
            }
        }

        private MeaningRepository _MEANING { get; set; }
        public MeaningRepository MEANING
        {
            get
            {
                if (_MEANING == null)
                    _MEANING = new MeaningRepository(this);
                return _MEANING;
            }
        }

        private ExampleRepository _EXAMPLE { get; set; }
        public ExampleRepository EXAMPLE
        {
            get
            {
                if (_EXAMPLE == null)
                    _EXAMPLE = new ExampleRepository(this);
                return _EXAMPLE;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
            }
        }
    }
}
