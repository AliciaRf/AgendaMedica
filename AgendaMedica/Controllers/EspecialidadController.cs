using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;
namespace AgendaMedica.Controllers
{
    public class EspecialidadController : Controller
    {
        private BdagendaContext db = new();
        public IActionResult Index()
        {
            // return View(db.Sectors.ToList());
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Especialidad especialidad)
        {
            //EntityFramework
            //insert into marca(nombre) values('nombre marca')
            db.Add(especialidad);
            db.SaveChanges();
            // return View();
            return RedirectToAction("Create");
        }


    }
}
