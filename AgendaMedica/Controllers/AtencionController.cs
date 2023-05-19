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
            //EntityFramework
            //insert into marca(nombre) values('nombre marca')
            db.Add(atencion);
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
            db.Update(atencion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var atenciones = db.Atencions.Find(id);
                if (atenciones != null)
                {
                    db.Atencions.Remove(atenciones);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }



    }
}
