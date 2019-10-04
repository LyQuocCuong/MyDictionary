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
    public class MeaningService : IMeaningService
    {
        public void CreateMeaning(MeaningDto meaningDto)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.MEANING.CreateMeaning(meaningDto);
            }
        }

        public void DeleteMeaning(Guid meaningId)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.MEANING.DeleteMeaning(meaningId);
            }
        }

        public List<MeaningDto> FindMeaningListHaveExample(Guid wordId)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                return repository.MEANING.FindMeaningListHaveExample(wordId);
            }
        }

        public void UpdateMeaning(MeaningDto meaningDto)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.MEANING.UpdateMeaning(meaningDto);
            }
        }

        public MeaningDto FindDetailMeaning(Guid meaningId)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                return repository.MEANING.FindDetailMeaning(meaningId);
            }
        }

    }
}
