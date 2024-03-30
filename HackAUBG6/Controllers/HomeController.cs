using HackAUBG6.Core.Contracts;
using HackAUBG6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace HackAUBG6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IGetDataService service;

        public HomeController(ILogger<HomeController> _logger, IGetDataService _service)
        {
            logger = _logger;
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Data()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    string jsonData = await reader.ReadToEndAsync();

                    var items = await service.AllBillAsync(jsonData);

                    
                }
                return Ok("Data received successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return BadRequest("Error processing data: " + ex.Message);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}