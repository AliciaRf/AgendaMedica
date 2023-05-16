using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
