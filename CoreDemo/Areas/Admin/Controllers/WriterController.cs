using CoreDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterById(int writerId)
        {
            var writer =writers.FirstOrDefault(x => x.Id == writerId);
            var jsonWriters =JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer); 
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer= writers.FirstOrDefault(x=>x.Id == w.Id);
            writer.Name= w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name="Maria"
            },
            new WriterClass
            {
                Id=2,
                Name="John"
            },
            new WriterClass
            {
                Id = 3, 
                Name= "Tom"
            }
        };
    }
}