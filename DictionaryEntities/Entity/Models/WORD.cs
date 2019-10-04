using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Entity.Models
{
    [Table("WORD")]
    public class WORD
    {
        public WORD()
        {
            MEANING_LIST = new HashSet<MEANING>();
        }

        public Guid ID { get; set; }

        public string TEXT { get; set; }

        public string TYPE { get; set; }

        public string PRONOUNCE { get; set; }

        public bool DELETED { get; set; }

        public virtual ICollection<MEANING> MEANING_LIST { get; set; }
    }
}
