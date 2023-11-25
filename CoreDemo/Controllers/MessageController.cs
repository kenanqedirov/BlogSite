using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Manager;

        public MessageController(IMessage2Service message2Manager)
        {
            _message2Manager = message2Manager;
        }

        public IActionResult Inbox()
        {
            int id = 1;
            var values =_message2Manager.GetInboxListByWriter(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var messageValue = _message2Manager.GetById(id);
            return View(messageValue);
        }
    }
}
