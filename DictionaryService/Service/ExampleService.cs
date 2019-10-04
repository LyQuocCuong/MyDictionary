using DictionaryDto;
using DictionaryEntities.Repository;
using DictionaryService.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.Service
{
    public class ExampleService : IExampleService
    {
        public void CreateExample(ExampleDto exampleDto)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.EXAMPLE.CreateExample(exampleDto);
            }
        }

        public void DeleteExample(Guid exampleId)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.EXAMPLE.DeleteExample(exampleId);
            }
        }
        
        public void UpdateExample(ExampleDto exampleDto)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                repository.EXAMPLE.UpdateExample(exampleDto);
            }
        }
        
        public List<ExampleDto> FindExampleList(Guid meaningId)
        {
            using (DictionaryRepository repository = new DictionaryRepository())
            {
                return repository.EXAMPLE.FindExampleList(meaningId);
            }
        }

    }
}
