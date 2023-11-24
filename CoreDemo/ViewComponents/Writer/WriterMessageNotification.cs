using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessageService _messageManager;

        public WriterMessageNotification(IMessageService messageManager)
        {
            _messageManager = messageManager;
        }

        public IViewComponentResult Invoke()
        {
            string p = "kenan@gmail.com";
            var values = _messageManager.GetInboxListByWriter(p);
            return View(values);
        }
    }
}
