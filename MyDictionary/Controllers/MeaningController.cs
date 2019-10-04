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
    public class MeaningController : Controller
    {
        private IMeaningService meaningService = null;

        public MeaningController()
        {
            meaningService = new MeaningService();
        }

        // GET: Meaning
        public ActionResult Index(Guid meaningId)
        {
            return View(meaningService.FindDetailMeaning(meaningId));
        }

    }
}