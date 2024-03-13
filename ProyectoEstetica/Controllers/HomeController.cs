using Microsoft.AspNetCore.Mvc;
using ProyectoEstetica.Models;
using ProyectoEstetica.Rules;
using System.Diagnostics;

namespace ProyectoEstetica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var rule = new PublicacionRule(_configuration);
            var posts = rule.GetOnePostHome();   
            return View(posts);
        }
        public IActionResult AcercaDe()
        {
            return View();
        }
        public IActionResult Equipo()
        {
            return View();
        }
        public IActionResult Contacto()
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