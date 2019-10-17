using DictionaryDto;
using DictionaryEntities.Entity.Context;
using DictionaryEntities.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Repository
{
    public class ExampleRepository : AbstractRepository<EXAMPLE>
    {
        public ExampleRepository(DictionaryRepository repository):base(repository)
        {

        }

        public List<ExampleDto> FindExampleList(Guid meaningId)
        {
            List<ExampleDto> exampleList = new List<ExampleDto>();
            if (DataSet.FirstOrDefault(e => e.MEANING_ID == meaningId && !e.DELETED && !e.MEANING.DELETED) != null)
            {
                exampleList.AddRange(DataSet.Where(e => e.MEANING_ID == meaningId && !e.DELETED && !e.MEANING.DELETED)
                                            .OrderBy(e => e.TEXT)
                                            .Select(example => new ExampleDto()
                                            {
                                                ExampleId = example.ID,
                                                ExampleText = example.TEXT,
                                                MeaningId = meaningId,
                                            })
                                    );
            }
            return exampleList;
        }

        public void CreateExample(ExampleDto exampleDto)
        {
            EXAMPLE newExample = new EXAMPLE()
            {
                ID = Guid.NewGuid(),
                MEANING_ID = exampleDto.MeaningId,
                TEXT = exampleDto.ExampleText,
            };
            DataSet.Add(newExample);
            Repository.SaveChanges();
        }

        public void UpdateExample(ExampleDto exampleDto)
        {
            EXAMPLE example = DataSet.FirstOrDefault(m => m.ID == exampleDto.ExampleId);
            if (example != null)
            {
                example.TEXT = exampleDto.ExampleText;
                Repository.SaveChanges();
            }
        }

        public void DeleteExample(Guid exampleId)
        {
            EXAMPLE example = DataSet.FirstOrDefault(m => m.ID == exampleId);
            if (example != null)
            {
                example.DELETED = true;
                Repository.SaveChanges();
            }
        }

    }
}
