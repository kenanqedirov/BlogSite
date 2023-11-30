using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IContactService _contactManager;

		public ContactController(IContactService contactManager)
		{
			_contactManager = contactManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact p)
		{
			p.ContactStatus = true;
			p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			_contactManager.TAdd(p);
			return RedirectToAction("Index","Blog");
		}
	}
}
