using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;


namespace AgendaMedica.Controllers
{
    public class PrevisionController : Controller
    {
        //instancia la clase que contiene la conexión a la db
        private BdagendaContext db = new();

        //método para listar todas las marcas
        public IActionResult Index()
        {
            //select * from prevision
            return View(db.Previsions.ToList());
        }

        //método para crear
        public IActionResult Create()
        {
            return View();
        }
    }
}
