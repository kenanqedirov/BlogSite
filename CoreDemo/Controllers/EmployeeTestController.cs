using BlogApi.DataAccessLayer;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public EmployeeTestController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<MyEmployees>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(MyEmployees p)
        {
            if (p is null)
                return View(p);
            else
            {
                var client = _httpClient.CreateClient();
                var jsonEmployee = JsonConvert.SerializeObject(p);
                StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
                var responseMessage =await client.PostAsync("https://localhost:5001/api/Default", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(responseMessage);
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<MyEmployees>(jsonString);
                return View(employee);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(MyEmployees p)
        {
            var client = _httpClient.CreateClient();
            var myData = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(myData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:5001/api/Default/",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:5001/api/Default" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
                return View(id);
        }
    }
    public class MyEmployees   // This class  must be moved to Model class
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
