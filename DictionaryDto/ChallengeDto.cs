using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDto
{
    public class AnswerDto
    {
        public Guid WordId { get; set; }

        public Guid MeaningId { get; set; }

        public string MeaningText { get; set; }

        public bool IsCorrected { get; set; }
    }

    public class ChallengeDto
    {
        public ChallengeDto()
        {
            Question = new WordDto();
            AnswersList = new List<AnswerDto>();
        }

        public WordDto Question { get; set; }

        public List<AnswerDto> AnswersList { get; set; }
    }
}
