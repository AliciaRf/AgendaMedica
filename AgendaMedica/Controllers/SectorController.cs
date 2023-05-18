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
           return View(db.Sectors.ToList());
            //return View();
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

        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
                //Find busca por la PK, es equivalente select * from sector where id = id
                var sector = db.Sectors.Find(id);
                //verifica si marca encontro datos
                if (sector != null)
                {
                    //retorna a la vista Edit con los datos encontrados
                    return View(sector);
                }
            }
            //en caso de error, volver al index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Sector sector)
        {
            db.Update(sector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var marca = db.Sectors.Find(id);
                if (marca != null)
                {
                    db.Sectors.Remove(marca);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


    }
}
