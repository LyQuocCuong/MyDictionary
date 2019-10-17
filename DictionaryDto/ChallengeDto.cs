using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDto
{
    public class AnswerDto
    {
        public Guid AnswerId { get; set; }
        public string AnswerText { get; set; }
    }

    public class ChallengeDto
    {
        public int CurrentLevel { get; set; }
        public int MaxLevel { get; set; }
        public Guid RightAnswerId { get; set; }
        public string QuestionText { get; set; }
        public string TypeWordText { get; set; }
        public string Pronounce { get; set; }
        public string Sound { get; set; }
        public List<AnswerDto> AnswersList { get; set; }
        public List<ExampleDto> ExampleList { get; set; }
        public ChallengeDto()
        {
            AnswersList = new List<AnswerDto>();
            ExampleList = new List<ExampleDto>();
        }
    }
}
