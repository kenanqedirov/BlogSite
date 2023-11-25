using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerManager;

        public WriterAboutOnDashboard(IWriterService writerManager)
        {
            _writerManager = writerManager;
        }
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;  
            var writerID = c.Writers.Where(a => a.WriterMail == userName).Select(y => y.WriterID).FirstOrDefault();
            var values = _writerManager.GetWriterById(writerID);
            return View(values);
        }
    }
}
