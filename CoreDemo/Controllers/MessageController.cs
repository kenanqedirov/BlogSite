using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Manager;
        Context c = new Context();
        public MessageController(IMessage2Service message2Manager)
        {
            _message2Manager = message2Manager;
        }
        
        public IActionResult Inbox()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
            var writerID = c.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values =_message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
            var writerID = c.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = _message2Manager.GetSendboxListByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var messageValue = _message2Manager.GetById(id);
            return View(messageValue);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
            var writerID = c.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = 2;
            p.MessageStatus = true;
            p.MessageDate =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _message2Manager.TAdd(p);
            return RedirectToAction("Inbox");
        }
    }
}
