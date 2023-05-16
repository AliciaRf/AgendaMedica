using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class AtencionController : Controller
    {

        private BdagendaContext db = new();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Atencion atencion)
        {
            //EntityFramework
            //insert into marca(nombre) values('nombre marca')
            db.Add(atencion);
            db.SaveChanges();
            // return View();
            return RedirectToAction("Create");
        }

    }
}
