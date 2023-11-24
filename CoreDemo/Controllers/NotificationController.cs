using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationManager;

        public NotificationController(INotificationService notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values = _notificationManager.GetList();
            return View(values);
        }
    }
}
