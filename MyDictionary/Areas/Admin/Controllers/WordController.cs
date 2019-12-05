using DictionaryDto;
using DictionaryHelper;
using DictionaryService.IService;
using DictionaryService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MyDictionary.Areas.Admin.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordService wordService = null;
        public WordController()
        {
            wordService = new WordService();
        }

        // GET: Admin/Word
        public ActionResult Index(Guid wordId)
        {
            return View(wordService.FindDetailWord(wordId));
        }

        public ActionResult WordList(int pageNumber = 1)
        {
            return View(wordService.GetWordList().ToPagedList(pageNumber, CommonVariable.Page_Size));
        }

        public ActionResult UpdateWord(WordDto wordDto)
        {
            if (wordDto.WordId == Guid.Empty)
            {
                wordService.CreateWord(wordDto);
            }
            else
            {
                wordService.UpdateWord(wordDto);
            }
            return RedirectToAction("WordList");
        }

        public ActionResult DeleteWord(Guid wordId)
        {
            wordService.DeleteWord(wordId);
            return RedirectToAction("WordList");
        }

    }
}