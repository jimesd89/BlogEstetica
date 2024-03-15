using Microsoft.AspNetCore.Mvc;
using ProyectoEstetica.Models;
using ProyectoEstetica.Rules;
using ProyectoFinal.Rules;
using System.Data;
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
        public IActionResult Post(int id)
        {
            var rule = new PublicacionRule(_configuration);
            var post = rule.GetPostById(id);
            if (post == null)
            {
                var posts = rule.GetOnePostHome();
                return View("index",posts);
            }
            else
            {
                return View(post);
            }
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
        [HttpPost]
        public IActionResult Contacto(Contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                return View("Contacto", contacto);
            }
            var rule = new ContactoRule(_configuration);
            var mensaje = @"<h1>Gracias por contactarnos</h1>
                    <p>Hemos recibido tu correo exitosamente.</p>
                    <p>A la brevedad nos pondremos en contacto</p>
                    <hr/><p><b>Estética LeMoon</b></p>";
            rule.SendEmail(contacto.Email, mensaje, "Mensaje Recibido", "Estética LeMoon", "jime_389@hotmail.com");
            rule.SendEmail("jime_389@hotmail.com", contacto.Mensaje, "Nuevo contacto", contacto.Nombre, contacto.Email);

            return View("Contacto");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}