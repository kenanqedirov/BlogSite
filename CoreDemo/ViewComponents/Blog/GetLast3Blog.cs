using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class GetLast3Blog : ViewComponent
	{
		private readonly IBlogService _blogManager;
		public GetLast3Blog(IBlogService blogManager)
		{
			_blogManager = blogManager;
		}
		public IViewComponentResult Invoke() 
		{
			var blogs = _blogManager.GetLastThreeBlog();
			return View(blogs); 
		}

	}
}
