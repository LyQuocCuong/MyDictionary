using DictionaryDto;
using DictionaryService.IService;
using DictionaryService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDictionary.Controllers
{
    public class ExampleController : Controller
    {
        private IExampleService exampleService = null;

        public ExampleController()
        {
            exampleService = new ExampleService();
        }

        // GET: Example
        public ActionResult Index()
        {
            return View();
        }

    }
}