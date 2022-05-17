using Aspose.Cells;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using testapp.Data;
using testapp.Models;

namespace testapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestAppContext _context;

        public HomeController(ILogger<HomeController> logger, TestAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GenerateJSON()
        {
            var json = JsonConvert.SerializeObject(_context.Users.ToList(), Formatting.Indented);
            //json = json.Replace("[", "").Replace("]","").Replace("{","").Replace("}","").Replace("\"","").Replace(",","");
            var fileName = "test.txt";
            var mimeType = "text/plain";
            var fileBytes = Encoding.ASCII.GetBytes(json);
            return new FileContentResult(fileBytes, mimeType)
            {
                FileDownloadName = fileName
            };
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}