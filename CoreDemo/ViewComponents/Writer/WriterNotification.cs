using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private readonly INotificationService _notificationManager;

        public WriterNotification(INotificationService notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.GetList();
            return View(values);
        }
    }
}
