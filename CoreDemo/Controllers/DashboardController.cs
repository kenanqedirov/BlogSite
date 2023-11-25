using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c= new Context();
            ViewBag.totalBlogCount = c.Blogs.Count().ToString();
            ViewBag.writerBlogCount = c.Blogs.Where(a=>a.WriterID== 1).Count().ToString();
            ViewBag.CategoryCount = c.Categories.Count().ToString();
            return View();
        }
    }
}
