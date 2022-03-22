using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeguridadAspMvc.Data;
using SeguridadAspMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SeguridadAspMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext myDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _myDbContext)
        {
            _logger = logger;
            myDbContext = _myDbContext;
        }

        public IActionResult Index()
        {
            

            return View();
        }

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
