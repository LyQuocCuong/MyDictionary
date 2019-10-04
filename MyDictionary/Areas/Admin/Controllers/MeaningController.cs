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
    public class MeaningController : Controller
    {
        private IMeaningService meaningService = null;

        public MeaningController()
        {
            meaningService = new MeaningService();
        }

        // GET: Admin/Meaning
        public ActionResult Index(Guid meaningId)
        {
            return View(meaningService.FindDetailMeaning(meaningId));
        }

        public ActionResult UpdateMeaning(MeaningDto meaningDto)
        {
            if (meaningDto.MeaningId == Guid.Empty)
            {
                meaningService.CreateMeaning(meaningDto);
            }
            else
            {
                meaningService.UpdateMeaning(meaningDto);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteMeaning(Guid meaningId)
        {
            meaningService.DeleteMeaning(meaningId);
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}