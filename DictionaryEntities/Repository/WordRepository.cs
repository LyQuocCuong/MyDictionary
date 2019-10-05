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
                        TypeWordId = w.TYPE_WORD_ID,
                        WordText = w.TEXT,
                        TypeWordText = w.TYPE_WORD.TYPE_TEXT,
                        Pronounce = w.PRONOUNCE,
                        Sound = w.SOUND,
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
                wordDto.WordText = word.TEXT;
                wordDto.TypeWordId = word.TYPE_WORD_ID;
                wordDto.TypeWordText = word.TYPE_WORD.TYPE_TEXT;
                wordDto.Pronounce = word.PRONOUNCE;
                wordDto.Sound = word.SOUND;
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
                TYPE_WORD_ID = wordDto.TypeWordId,
                TEXT = wordDto.WordText,
                PRONOUNCE = wordDto.Pronounce,
                SOUND = wordDto.Sound,
            };
            DataSet.Add(newWord);
            Repository.SaveChanges();
        }

        public void UpdateWord(WordDto wordDto)
        {
            WORD word = DataSet.FirstOrDefault(w => w.ID == wordDto.WordId);
            if (word != null)
            {
                word.TYPE_WORD_ID = wordDto.TypeWordId;
                word.TEXT = wordDto.WordText;
                word.PRONOUNCE = wordDto.Pronounce;
                word.SOUND = wordDto.Sound;
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
