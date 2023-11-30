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
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x=>x.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(x=>x.WriterID).FirstOrDefault();


            ViewBag.totalBlogCount = c.Blogs.Count().ToString();
            ViewBag.writerBlogCount = c.Blogs.Where(a=>a.WriterID== writerId).Count().ToString();
            ViewBag.CategoryCount = c.Categories.Count().ToString();
            return View();
        }
    }
}
