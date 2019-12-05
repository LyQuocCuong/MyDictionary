using DictionaryDto;
using DictionaryEntities.Entity.Context;
using DictionaryEntities.Entity.Models;
using DictionaryHelper;
using log4net;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Repository
{
    public class WordRepository : AbstractRepository<WORD>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WordRepository));

        public WordRepository(DictionaryRepository repository) : base(repository) { }

        public List<WordDto> GetWordList()
        {
            List<WordDto> wordList = new List<WordDto>();
            if (DataSet.FirstOrDefault(w => !w.DELETED) != null)
            {
                wordList.AddRange(
                    DataSet
                    .Where(w => !w.DELETED)
                    .OrderBy(w => w.TEXT)
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
            try
            {
                wordDto.WordId = Guid.NewGuid();
                WORD newWord = new WORD()
                {
                    ID = wordDto.WordId,
                    TYPE_WORD_ID = wordDto.TypeWordId,
                    TEXT = wordDto.WordText.Trim(),
                    PRONOUNCE = wordDto.Pronounce,
                    SOUND = wordDto.Sound,
                };
                DataSet.Add(newWord);
                Repository.SaveChanges();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void UpdateWord(WordDto wordDto)
        {
            WORD word = DataSet.FirstOrDefault(w => w.ID == wordDto.WordId);
            if (word != null)
            {
                word.TYPE_WORD_ID = wordDto.TypeWordId;
                word.TEXT = wordDto.WordText.Trim();
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
