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
    public class ChallengeService : IChallengeService
    {
        public ChallengeDto CreateQuestion()
        {
            using (DictionaryRepository rep = new DictionaryRepository())
            {
                return rep.MEANING.CreateQuestion();
            }
        }
    }
}
