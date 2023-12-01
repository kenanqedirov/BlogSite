using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessage2Service _message2Manager;
        Context c = new Context();
        public WriterMessageNotification(IMessage2Service message2Manager)
        {
            _message2Manager = message2Manager;
        }

        public IViewComponentResult Invoke()
        {          
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
            var writerID = c.Writers.Where(a => a.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = _message2Manager.GetInboxListByWriter(writerID);
            return View(values);
        }
    }
}
