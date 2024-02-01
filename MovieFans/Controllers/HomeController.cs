using DataLayer.Models;
using HotNews.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                throw new Exception();
            }
            catch 
            {

               

                _logger.Log(LogLevel.Critical,"لاگ خططططططططططططططااااااااااااا");

                _logger.LogTrace("نداررررررررررررررددددددد");

                return View();
            }
          

        }


        public IActionResult Privacy(User user)
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