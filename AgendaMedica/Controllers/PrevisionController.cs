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
            if (!ModelState.IsValid)
            {
                return View(prevision);
            }

            if (existe == null)

            {
                db.Add(prevision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "Ya existe esta Prevision con ese nombre. " +
                                  "Ingrese una nueva Prevision por favor";
            return View(prevision);
        }

        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
                //Find busca por la PK, es equivalente select * from prevision where id = id
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
            try
            {
                //verifica si el modelo es válido
                if (!ModelState.IsValid)
                {

                    return View(prevision);
                }
                //actualiza los datos de la marca
                db.Update(prevision);
                //guarda los cambios
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(prevision);
            }
        }

              
        public IActionResult Delete(int? id )
        {
            if (id != null)
            {
               var prevision = db.Previsions.Find(id);
               if (prevision != null)
               { 
                    db.Previsions.Remove(prevision);
                    db.SaveChanges();
                    TempData["Mensaje1"] = "La Prevision fue eliminada satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }
    }
}