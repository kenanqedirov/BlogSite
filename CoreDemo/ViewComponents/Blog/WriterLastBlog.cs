using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		private readonly IBlogService _blogManager;

		public WriterLastBlog(IBlogService blogManager)
		{
			_blogManager = blogManager;
		}

		public IViewComponentResult Invoke()
		{
			var values = _blogManager.GetBlogListByWriter(1);
			return View(values);
		}
	}
}
