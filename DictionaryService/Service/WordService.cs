using DictionaryDto;
using DictionaryEntities.Repository;
using DictionaryService.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.Service
{
    public class WordService : IWordService
    {
        public List<WordDto> GetWordList(string textSearch)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                return repository.WORD.GetWordList(textSearch);
            }
        }
        
        public WordDto FindDetailWord(Guid wordId)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                return repository.WORD.FindDetailWord(wordId);
            }
        }

        public void CreateWord(WordDto wordDto)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.WORD.CreateWord(wordDto);
            }
        }
        
        public void UpdateWord(WordDto wordDto)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.WORD.UpdateWord(wordDto);
            }
        }

        public void DeleteWord(Guid wordId)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.WORD.DeleteWord(wordId);
            }
        }

    }
}
