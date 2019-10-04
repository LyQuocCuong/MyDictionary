using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDto
{
    public class ExampleDto
    {
        public Guid ExampleId { get; set; }
        public Guid MeaningId { get; set; }
        public string ExampleText { get; set; }
        public string MeaningText { get; set; }
    }
}
