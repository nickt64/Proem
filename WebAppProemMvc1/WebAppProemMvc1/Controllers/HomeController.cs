using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppProemMvc1.Models;

namespace WebAppProemMvc1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyDbContext myDbContext;

       

        public HomeController(ILogger<HomeController> logger, MyDbContext _myDbContext)
        {
            _logger = logger;
            myDbContext = _myDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        //---------------------------------------CARGA DE ARCHIVOS-------------------------------------------

        [HttpGet]
        public IActionResult TestArchivo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TestArchivo(IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                

            }
            return  View();
        }


        //----------------------------------------------------------------------------------------------------


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
