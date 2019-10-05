using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDto
{
    public class WordDto
    {
        public Guid WordId { get; set; }
        public Guid TypeWordId { get; set; }
        public string WordText { get; set; }
        public string TypeWordText { get; set; }
        public string Pronounce { get; set; }
        public string Sound { get; set; }
        public List<MeaningDto> MeaningList { get; set; }
    }
}
