using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDto
{
    public class MeaningDto
    {
        public Guid MeaningId { get; set; }
        public Guid WordId { get; set; }
        public string WordText { get; set; }
        public string MeaningText { get; set; }
        public List<ExampleDto> ExampleList { get; set; }
    }
}
