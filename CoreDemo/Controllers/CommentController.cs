using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentManager;

		public CommentController(ICommentService commentManager)
		{
			_commentManager = commentManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
			p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogID = 2;
			_commentManager.TAdd(p);
			return RedirectToAction("Index","Blog");
        }
        public PartialViewResult CommentListByBlog(int id)
		{
			var values = _commentManager.GetList(id);
			return PartialView(values);
		}
	}
}
