using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class EspecialidadController : Controller
    {
        private BdagendaContext db = new();
        public IActionResult Index()
        {
             return View(db.Especialidads.ToList());
            //return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Especialidad especialidad)
        {

            var existe = db.Especialidads.FirstOrDefault(x => x.Especialidad1 == especialidad.Especialidad1);
            if (!ModelState.IsValid)
            {
                return View(especialidad);
            }

            if (existe == null)

            {
                db.Add(especialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "Ya existe esta Especialidad con ese nombre.  " +
                                  "Ingrese una nueva Especialidad por favor";
            return View(especialidad);
        }

        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
                //Find busca por la PK, es equivalente select * from sector where id = id
                var especialidad = db.Especialidads.Find(id);
                //verifica si marca encontro datos
                if (especialidad != null)
                {
                    //retorna a la vista Edit con los datos encontrados
                    return View(especialidad);
                }
            }
            //en caso de error, volver al index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Especialidad especialidad)
        {
                try
                {
                    //verifica si el modelo es válido
                    if (!ModelState.IsValid)
                    {

                        return View(especialidad);
                    }
                    //actualiza los datos de la marca
                    db.Update(especialidad);
                    //guarda los cambios
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(especialidad);
                }
            }


            public IActionResult Delete(int? id)
            {
                if (id != null)
                {
                    var especialidad = db.Especialidads.Find(id);
                    if (especialidad != null)
                    {
                        db.Especialidads.Remove(especialidad);
                        db.SaveChanges();
                        TempData["Mensaje1"] = "La Especialidad fue eliminada Satisfactoriamente";
                    }
                }
                return RedirectToAction("Index");
            }
        }
    }

    