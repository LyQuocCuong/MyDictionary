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

        public Guid TYPE_WORD_ID { get; set; }

        public string TEXT { get; set; }

        public string PRONOUNCE { get; set; }

        public string SOUND { get; set; }

        public bool DELETED { get; set; }

        [ForeignKey("TYPE_WORD_ID")]
        public virtual TYPE_WORD TYPE_WORD { get; set; }

        public virtual ICollection<MEANING> MEANING_LIST { get; set; }
    }
}
