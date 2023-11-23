using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
		private readonly IWriterService _writerManager;

        public WriterController(IWriterService writerManager)
        {
            _writerManager = writerManager;
        }

        public IActionResult Index()
		{
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
		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writerValues = _writerManager.GetById(1);
			return View(writerValues);
		}
		[AllowAnonymous]
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
    }
}
