using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogService;

        public BlogController(BlogManager blogService)
        {
            _blogService = blogService;
        }



       // BlogManager _blogService = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            var values = _blogService.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            var values = _blogService.GetBlogById(id);
            return View(values);
        }
        
    }
}
