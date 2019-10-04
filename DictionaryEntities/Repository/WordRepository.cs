using DictionaryDto;
using DictionaryEntities.Entity.Context;
using DictionaryEntities.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Repository
{
    public class WordRepository : AbstractRepository<WORD>
    {
        public WordRepository(DictionaryRepository repository) : base(repository)
        {

        }

        public List<WordDto> GetWordList()
        {
            List<WordDto> wordList = new List<WordDto>();
            if (DataSet.FirstOrDefault(w => !w.DELETED) != null)
            {
                wordList.AddRange(
                    DataSet
                    .Where(w => !w.DELETED)
                    .Select(w => new WordDto()
                    {
                        WordId = w.ID,
                        Text = w.TEXT,
                        Type = w.TYPE,
                        Pronounce = w.PRONOUNCE,
                    }));
            }
            return wordList;
        }

        public WordDto FindDetailWord(Guid wordId)
        {
            WordDto wordDto = new WordDto();
            WORD word = DataSet.FirstOrDefault(w => w.ID == wordId && !w.DELETED);
            if (word != null)
            {
                wordDto.WordId = wordId;
                wordDto.Text = word.TEXT;
                wordDto.Type = word.TYPE;
                wordDto.Pronounce = word.PRONOUNCE;
                wordDto.MeaningList = Repository.MEANING.FindMeaningListHaveExample(wordId);
            }
            return wordDto;
        }

        public void CreateWord(WordDto wordDto)
        {
            wordDto.WordId = Guid.NewGuid();
            WORD newWord = new WORD()
            {
                ID = wordDto.WordId,
                TEXT = wordDto.Text,
                TYPE = wordDto.Type,
                PRONOUNCE = wordDto.Pronounce,
            };
            DataSet.Add(newWord);
            Repository.SaveChanges();
        }

        public void UpdateWord(WordDto wordDto)
        {
            WORD word = DataSet.FirstOrDefault(w => w.ID == wordDto.WordId);
            if (word != null)
            {
                word.TEXT = wordDto.Text;
                word.TYPE = wordDto.Type;
                word.PRONOUNCE = wordDto.Pronounce;
                Repository.SaveChanges();
            }
        }

        public void DeleteWord(Guid wordId)
        {
            WORD word = DataSet.FirstOrDefault(w => w.ID == wordId);
            if (word != null)
            {
                word.DELETED = true;
                Repository.SaveChanges();
            }
        }

    }
}
