using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerManager;
        private readonly UserManager<AppUser> _userManager;

		public WriterAboutOnDashboard(IWriterService writerManager, UserManager<AppUser> userManager)
		{
			_writerManager = writerManager;
			_userManager = userManager;
		}
		Context c = new Context();
        public IViewComponentResult Invoke()
        { 
            var userName = User.Identity.Name;  
            var userMail = c.Users.Where(a=>a.UserName == userName).Select(b=>b.Email).FirstOrDefault();
            var writerID = c.Writers.Where(a => a.WriterMail == userName).Select(y => y.WriterID).FirstOrDefault();
            var values = _writerManager.GetWriterById(writerID);
            return View(values);
        }
    }
}