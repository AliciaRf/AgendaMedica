using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    
    public class AgendaController : Controller
    {
        private BdagendaContext db = new();

        public IActionResult Index()
        {
            var agendas=db.Agendars.Include(p => p.IdEspNavigation). Include(p => p.IdAteNavigation). Include(p => p.IdSectorNavigation).Include(p => p.IdPrevNavigation);
            return View(agendas);
            //return View(db.Atencions.ToList()); 
        }


        public IActionResult Create()
        {
            //select id,nombre from marca 
            ViewData["IdEspecialidad"] = new SelectList(db.Especialidads, "IdEsp", "Especialidad1");
            ViewData["IdAtenciones"] = new SelectList(db.Atencions, "IdAte", "NombreAte");
            ViewData["IdSectores"] = new SelectList(db.Sectors, "IdSector", "Sector1");
            ViewData["IdPrevision"] = new SelectList(db.Previsions, "IdPrev", "NombrePrev");
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Agendar agenda)
        {
            
            db.Agendars.Add(agenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
                //Find busca por la PK, es equivalente select * from sector where id = id
                var agen= db.Agendars.Find(id);
                //verifica si marca encontro datos
                if (agen != null)
                {
                    //retorna a la vista Edit con los datos encontrados
                    return View(agen);
                }
            }
            //en caso de error, volver al index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Agendar agenda)
        {
            db.Update(agenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var agen = db.Agendars.Find(id);
                if (agen != null)
                {
                    db.Agendars.Remove(agen);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }




    }
}
