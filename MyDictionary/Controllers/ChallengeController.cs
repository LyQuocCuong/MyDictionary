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
    public class ChallengeController : Controller
    {
        private IChallengeService challengeService = null;

        public ChallengeController()
        {
            challengeService = new ChallengeService();
        }

        // GET: Challenge
        public ActionResult Index()
        {
            return View(challengeService.CreateQuestion());
        }

        [HttpPost]
        public ActionResult CreateQuestion()
        {
            return View("Index", challengeService.CreateQuestion());
        }

    }
}