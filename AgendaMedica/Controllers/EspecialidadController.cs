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
            //EntityFramework
            //insert into especialidad(nombre) values('nombre especialidad')
            db.Add(especialidad);
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
            db.Update(especialidad);
            db.SaveChanges();
            return RedirectToAction("Index");
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
                }
            }
            return RedirectToAction("Index");
        }




    }
}
