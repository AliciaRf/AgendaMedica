using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

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
            
            var existe = db.Sectors.FirstOrDefault(x => x.Sector1 == sector.Sector1);
            if (!ModelState.IsValid)
            {
                return View(sector);
            }

            if (existe == null)

            {
                db.Add(sector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "Ya existe este Sector con ese nombre.  " +
                                  "Ingrese un nuevo Sector por favor";
            return View(sector);
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
            try
            {
                //verifica si el modelo es válido
                if (!ModelState.IsValid)
                {

                    return View(sector);
                }
                //actualiza los datos de la marca
                db.Update(sector);
                //guarda los cambios
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(sector);
            }
        }


        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var usuario = db.Sectors.Find(id);
                if (usuario != null)
                {
                    db.Sectors.Remove(usuario);
                    db.SaveChanges();
                    TempData["Mensaje1"] = "El Sector fue eliminado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }
    }
}

    