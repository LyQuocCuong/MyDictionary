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
        public string Text { get; set; }
        public string Type { get; set; }
        public string Pronounce { get; set; }
        public List<MeaningDto> MeaningList { get; set; }
    }
}
