using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class AtencionController : Controller
    {

        private BdagendaContext db = new();
        public IActionResult Index()
        {
            return View(db.Atencions.ToList());
            //return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Atencion atencion)
        {

            var existe = db.Atencions.FirstOrDefault(x => x.NombreAte == atencion.NombreAte);
            if (!ModelState.IsValid)
            {
                return View(atencion);
            }

            if (existe == null)

            {
                db.Add(atencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "Ya existe esta Atencion con ese nombre.  " +
                                  "Ingrese una nueva atencion por favor";
            return View(atencion);
        }

        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
                //Find busca por la PK, es equivalente select * from sector where id = id
                var atenciones = db.Atencions.Find(id);
                //verifica si marca encontro datos
                if (atenciones != null)
                {
                    //retorna a la vista Edit con los datos encontrados
                    return View(atenciones);
                }
            }
            //en caso de error, volver al index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Atencion atencion)
        {
            try
            {
                //verifica si el modelo es válido
                if (!ModelState.IsValid)
                {

                    return View(atencion);
                }
                //actualiza los datos de la marca
                db.Update(atencion);
                //guarda los cambios
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(atencion);
            }
        }


        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var atencion = db.Atencions.Find(id);
                if (atencion != null)
                {
                    db.Atencions.Remove(atencion);
                    db.SaveChanges();
                    TempData["Mensaje1"] = "La atencion fue eliminado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }
    }
}


