using DictionaryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.IService
{
    public interface IChallengeService
    {
        ChallengeDto CreateQuestion();
    }
}
