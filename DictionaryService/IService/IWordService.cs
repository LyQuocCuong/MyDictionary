using DictionaryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.IService
{
    public interface IWordService
    {
        List<WordDto> GetWordList(string textSearch);
        WordDto FindDetailWord(Guid wordId);
        void CreateWord(WordDto wordDto);
        void UpdateWord(WordDto wordDto);
        void DeleteWord(Guid wordId);
    }
}
