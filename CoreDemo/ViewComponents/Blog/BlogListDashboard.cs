using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        private readonly IBlogService _blogManager;

        public BlogListDashboard(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
