using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Entity.Models
{
    [Table("EXAMPLE")]
    public class EXAMPLE
    {
        public Guid ID { get; set; }

        public Guid MEANING_ID { get; set; }

        public string TEXT { get; set; }

        public bool DELETED { get; set; }

        [ForeignKey("MEANING_ID")]
        public virtual MEANING MEANING { get; set; }
    }
}
