using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Entity.Models
{
    [Table("TYPE_WORD")]
    public class TYPE_WORD
    {
        public TYPE_WORD()
        {
            this.WORD_LIST = new HashSet<WORD>();
        }

        public Guid ID { get; set; }

        public string TYPE_TEXT { get; set; }

        public bool DELETED { get; set; }

        public virtual ICollection<WORD> WORD_LIST { get; set; }
    }
}
