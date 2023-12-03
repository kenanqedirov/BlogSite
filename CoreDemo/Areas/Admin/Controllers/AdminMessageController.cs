using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IMessage2Service _message2Manager;

        public AdminMessageController(IMessage2Service message2Manager)
        {
            _message2Manager = message2Manager;
        }

        Context _context = new Context();
        public IActionResult Inbox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
            var writerID = _context.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = _message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
            var writerID = _context.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = _message2Manager.GetSendboxListByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 p)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
            var writerID = _context.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = 2;
            p.MessageDate =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            _message2Manager.TAdd(p);
            return RedirectToAction("Sendbox");
        }
    }
}
