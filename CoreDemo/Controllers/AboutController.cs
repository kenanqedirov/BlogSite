using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutManager;

		public AboutController(IAboutService aboutManager)
		{
			_aboutManager = aboutManager;
		}

		public IActionResult Index()
		{
			var values = _aboutManager.GetList();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			
			return PartialView();
		}
	}
}
