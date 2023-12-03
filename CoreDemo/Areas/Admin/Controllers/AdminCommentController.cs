using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        private readonly ICommentService _commentManager;

        public AdminCommentController(ICommentService commentManager)
        {
            _commentManager = commentManager;
        }

        public IActionResult Index()
        {
            var values = _commentManager.GetCommentsWithBlog();
            return View(values);
        }
    }
}
