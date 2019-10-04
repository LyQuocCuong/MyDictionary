using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Entity.Models
{
    [Table("MEANING")]
    public class MEANING
    {
        public MEANING()
        {
            EXAMPLE_LIST = new HashSet<EXAMPLE>();
        }

        public Guid ID { get; set; }

        public Guid WORD_ID { get; set; }

        public string TEXT { get; set; }

        public bool DELETED { get; set; }

        [ForeignKey("WORD_ID")]
        public virtual WORD WORD { get; set; }

        public virtual ICollection<EXAMPLE> EXAMPLE_LIST { get; set; }
    }
}
