using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {      
        public IViewComponentResult Invoke()
        {
            Context _context = new Context();
            ViewBag.adminName = _context.Admins.Where(a => a.AdminID == 1).Select(a => a.Name).FirstOrDefault();
            ViewBag.adminImage = _context.Admins.Where(a => a.AdminID == 1).Select(a => a.ImageUrl).FirstOrDefault();
            ViewBag.adminDescription = _context.Admins.Where(a => a.AdminID == 1).Select(a => a.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}