using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                CategoryName = "Technology",
                CategoryCount = 10
            });
            list.Add(new CategoryClass
            {
                CategoryName = "Software",
                CategoryCount = 15
            });
            list.Add(new CategoryClass
            {
                CategoryName = "Sport",
                CategoryCount = 5
            });
            list.Add(new CategoryClass
            {
                CategoryName = "Cinema",
                CategoryCount = 30
            });
            return Json(new { jsonList = list });
        }
    }
}
