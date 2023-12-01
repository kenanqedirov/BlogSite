using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        private readonly IWriterService _writerManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _MyUserManager;
        public WriterController(IWriterService writerManager, UserManager<AppUser> userManager, IUserService myUserManager)
        {
            _writerManager = writerManager;
            _userManager = userManager;
            _MyUserManager = myUserManager;
        }
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            ViewBag.userName = userName;
            Context c = new Context();
            var writerName = c.Writers.Where(a => a.WriterName == userName).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel
            {
                Mail = values.Email,
                NameSurname = values.NameSurname,
                ImageUrl = values.ImageUrl,
                Username = values.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                values.Email = model.Mail;
                values.NameSurname = model.NameSurname;
                values.ImageUrl = model.ImageUrl;
                values.UserName = model.Username;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                return View(model);
            }
            else
            {
                return View(model);
            }                 
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if (p.WriterImage != null)
            {
                var extensions = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extensions;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = p.WriterMail;
            writer.WriterName = p.WriterName;
            writer.WriterPassword = p.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = p.WriterAbout;
            _writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
