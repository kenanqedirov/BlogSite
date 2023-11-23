using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerManager;

        public WriterAboutOnDashboard(IWriterService writerManager)
        {
            _writerManager = writerManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _writerManager.GetWriterById(1);
            return View(values);
        }
    }
}
