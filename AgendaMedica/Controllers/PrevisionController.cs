using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;


namespace AgendaMedica.Controllers
{
    public class PrevisionController : Controller
    {
        //instancia la clase que contiene la conexión a la db
        private BdagendaContext db = new();

        //método para listar todas las Previsiones
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

        [HttpPost]
        public IActionResult Create(Prevision prevision)
        {
            var existe = db.Previsions.FirstOrDefault(x => x.NombrePrev == prevision.NombrePrev);
            if (existe == null)
            {
                //EntityFramework
                //insert into marca(nombre) values('nombre marca')
                db.Add(prevision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prevision);
        }
        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
                //Find busca por la PK, es equivalente select * from marca where id = id
                var prevision = db.Previsions.Find(id);
                //verifica si marca encontro datos
                if (prevision != null)
                {
                    //retorna a la vista Edit con los datos encontrados
                    return View(prevision);
                }
            }
            //en caso de error, volver al index
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Prevision prevision)
        {
            db.Update(prevision);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var prevision = db.Previsions.Find(id);
                if (prevision != null)
                {
                    db.Previsions.Remove(prevision);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}
