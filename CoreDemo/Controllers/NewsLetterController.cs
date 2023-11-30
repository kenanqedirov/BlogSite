using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterManager;
       
        public NewsLetterController(INewsLetterService newsLetterManager)
        {
            _newsLetterManager = newsLetterManager;
        }

        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            _newsLetterManager.TAdd(p);
            return RedirectToAction("Index","Blog");
        }
    }
}
