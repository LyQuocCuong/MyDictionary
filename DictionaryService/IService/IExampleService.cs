using DictionaryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.IService
{
    public interface IExampleService
    {
        void CreateExample(ExampleDto exampleDto);
        void UpdateExample(ExampleDto exampleDto);
        void DeleteExample(Guid exampleId);
        List<ExampleDto> FindExampleList(Guid meaningId);
    }
}
