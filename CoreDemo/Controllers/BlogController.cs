using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogManager;
        private ICategoryService _categoryManager;
        Context c = new Context();
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogManager = blogService;
            _categoryManager = categoryService;

        }

        public IActionResult Index()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var values = _blogManager.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var c = new Context();
            var userName = User.Identity.Name;
            var writerID = c.Writers.Where(a => a.WriterMail == userName).Select(y => y.WriterID).FirstOrDefault();
            var values = _blogManager.TGetListWithCategoryByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
               
                var userName = User.Identity.Name;
                var writerID = c.Writers.Where(a => a.WriterMail == userName).Select(y => y.WriterID).FirstOrDefault();
                p.BlogStatus = true;
                p.BLogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                _blogManager.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(p);
        }
        public IActionResult BlogDelete(int id)
        {
            var blogValue = _blogManager.GetById(id);
            _blogManager.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = _blogManager.GetById(id);
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryValues = categoryValues;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userName = User.Identity.Name;
            var writerID = c.Writers.Where(a => a.WriterMail == userName).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID = writerID;
            blog.BLogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            _blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
