using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        private readonly IBlogService _blogManager;
        private readonly IContactService _contactManager;
        private readonly ICommentService _commentManager;

        public Statistic1(IBlogService blogManager, IContactService contactManager, ICommentService commentManager)
        {
            _blogManager = blogManager;
            _contactManager = contactManager;
            _commentManager = commentManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.blogCount = _blogManager.GetList().Count;
            ViewBag.messageCount = _contactManager.GetList().Count;
            ViewBag.commentCount = _commentManager.GetList().Count;

            string api = "21942bdd231e0b408aedbb507b0af835";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=baku&mode=xml&lang=eng&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}