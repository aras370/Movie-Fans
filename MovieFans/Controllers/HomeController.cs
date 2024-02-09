using Application.Interfaces;
using DataLayer.Models;
using HotNews.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace HotNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IUser _user;


        public HomeController(ILogger<HomeController> logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }

        public IActionResult Index()
        {
            try
            {
                throw new Exception();
            }
            catch
            {



                _logger.Log(LogLevel.Critical, "لاگ خططططططططططططططااااااااااااا");

                _logger.LogTrace("نداررررررررررررررددددددد");

            }


            return View();

        }

        [Authorize(Policy = "AdminOrUser")]
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