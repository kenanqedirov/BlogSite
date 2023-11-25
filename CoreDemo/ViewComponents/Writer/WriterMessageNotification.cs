using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessage2Service _message2Manager;

        public WriterMessageNotification(IMessage2Service message2Manager)
        {
            _message2Manager = message2Manager;
        }

        public IViewComponentResult Invoke()
        {
            int id = 1; 
            var values = _message2Manager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
