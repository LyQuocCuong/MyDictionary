using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryHelper
{
    public static class CommonVariable
    {
        public static readonly TypeWordHelper Type_Word_Verb = new TypeWordHelper()
        {
            Id = Guid.Parse("fde95811-f137-4758-a427-064bb2a29cc8"),
            Text = "Verb",
        };
        public static readonly TypeWordHelper Type_Word_Noun = new TypeWordHelper()
        {
            Id = Guid.Parse("46316c50-64ef-4e3e-b185-00706ec085d5"),
            Text = "Noun",
        };
        public static readonly TypeWordHelper Type_Word_Adj = new TypeWordHelper()
        {
            Id = Guid.Parse("4d35af57-f885-489b-bd5d-0092833dba1f"),
            Text = "Adj",
        };
        public static readonly TypeWordHelper Type_Word_Adv = new TypeWordHelper()
        {
            Id = Guid.Parse("7f8799cd-bd8d-4a5a-8bd9-0166e1cdcefa"),
            Text = "Adv",
        };
        public static readonly TypeWordHelper Type_Word_Prep = new TypeWordHelper()
        {
            Id = Guid.Parse("203c2f0a-5561-478e-b9ee-02367e56cb10"),
            Text = "Prep",
        };
        public static readonly TypeWordHelper Type_Word_Collocation = new TypeWordHelper()
        {
            Id = Guid.Parse("0d373fb9-85c4-47ad-bee5-031449b9ba21"),
            Text = "Collocation",
        };
        public static readonly TypeWordHelper Type_Word_Grammar = new TypeWordHelper()
        {
            Id = Guid.Parse("37ffc852-5158-44a9-b1a0-035d64454169"),
            Text = "Grammar",
        };

        public static readonly List<TypeWordHelper> Type_Word_List = new List<TypeWordHelper>()
        {
            Type_Word_Verb,
            Type_Word_Noun,
            Type_Word_Adj,
            Type_Word_Adv,
            Type_Word_Prep,
            Type_Word_Collocation,
            Type_Word_Grammar,
        };

    }
    
}
