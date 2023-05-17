using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class UsuarioController : Controller
    {
        //instancia la clase que contiene la conexión a la db
        private BdagendaContext db = new();

        //método para listar todas las marcas
        public IActionResult Index()
        {
            //select * from usuario
            return View(db.Usuarios.ToList());
        }

        //método para crear
        public IActionResult Create()
        {
            return View();
        }
    }
}
