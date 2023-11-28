using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context _context =new Context();
        public IViewComponentResult Invoke()
        {
            var blog = _context.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).FirstOrDefault();
            @ViewBag.lastBlogs = blog;
            return View();
        }
    }
}
