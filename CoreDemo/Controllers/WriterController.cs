using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace CoreDemo.Controllers
{
	[Authorize]
	public class WriterController : Controller
	{
		private readonly IWriterService _writerManager;

        public WriterController(IWriterService writerManager)
        {
            _writerManager = writerManager;
        }
        public IActionResult Index()
		{
			var userName = User.Identity.Name;
			ViewBag.userName = userName;
			Context c = new Context();
			var writerName = c.Writers.Where(a => a.WriterName == userName).Select(y => y.WriterName).FirstOrDefault();
			ViewBag.writerName = writerName;
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult WriterMail()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}

		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var c = new Context();
            var userName = User.Identity.Name;
			var userMail =c.Users.Where(x=>x.UserName==userName).Select(x=>x.Email).FirstOrDefault();
            var writerID = c.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = _writerManager.GetWriterById(writerID);
            var writerValues = _writerManager.GetById(writerID);
			return View(writerValues);
		}

		[HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
			WriterValidator validationRules = new WriterValidator();
			ValidationResult validationResult = validationRules.Validate(p);
			if (validationResult.IsValid)
			{
				_writerManager.TUpdate(p);
				return RedirectToAction("Index","Dashboard");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
            return View(p);
        }
		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
			Writer writer = new Writer();
			if (p.WriterImage != null)
			{
				var extensions = Path.GetExtension(p.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extensions;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				p.WriterImage.CopyTo(stream);
				writer.WriterImage = newImageName;
			}
			writer.WriterMail = p.WriterMail;
			writer.WriterName = p.WriterName;
			writer.WriterPassword = p.WriterPassword;
			writer.WriterStatus = true;
			writer.WriterAbout	= p.WriterAbout;
			_writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
