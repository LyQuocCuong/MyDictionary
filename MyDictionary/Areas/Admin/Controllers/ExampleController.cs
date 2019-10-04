using DictionaryDto;
using DictionaryService.IService;
using DictionaryService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDictionary.Areas.Admin.Controllers
{
    public class ExampleController : Controller
    {
        private IExampleService exampleService = null;

        public ExampleController()
        {
            exampleService = new ExampleService();
        }

        // GET: Admin/Example
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateExample(ExampleDto exampleDto)
        {
            if (exampleDto.ExampleId == Guid.Empty)
            {
                exampleService.CreateExample(exampleDto);
            }
            else
            {
                exampleService.UpdateExample(exampleDto);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteExample(Guid exampleId)
        {
            exampleService.DeleteExample(exampleId);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}