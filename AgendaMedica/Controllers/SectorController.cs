using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;
using System.Text.RegularExpressions;

namespace AgendaMedica.Controllers
{
    public class SectorController : Controller
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
        public IActionResult Create(Sector sector)
        {
            //EntityFramework
            //insert into marca(nombre) values('nombre marca')
            db.Add(sector);
            db.SaveChanges();
            // return View();
            return RedirectToAction("Index");
        }


    }
}
