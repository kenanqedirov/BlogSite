using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminBlogController : Controller
    {
        private readonly IBlogService _blogManager;

        public AdminBlogController(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IActionResult Index()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
