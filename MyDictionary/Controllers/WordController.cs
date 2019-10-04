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
    public class WordController : Controller
    {
        private readonly IWordService wordService = null;

        public WordController()
        {
            wordService = new WordService();
        }

        // GET: Word
        public ActionResult Index(Guid wordId)
        {
            return View(wordService.FindDetailWord(wordId));
        }

        public ActionResult WordList()
        {
            return View(wordService.GetWordList());
        }

    }
}