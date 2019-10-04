using DictionaryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.IService
{
    public interface IMeaningService
    {
        List<MeaningDto> FindMeaningListHaveExample(Guid wordId);
        void CreateMeaning(MeaningDto meaningDto);
        void UpdateMeaning(MeaningDto meaningDto);
        void DeleteMeaning(Guid meaningId);
        MeaningDto FindDetailMeaning(Guid meaningId);
    }
}
