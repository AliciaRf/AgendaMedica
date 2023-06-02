using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace AgendaMedica.Controllers
{
    
    public class AgendaController : Controller
    {
        private BdagendaContext db = new();

        public IActionResult Index()
        {
            var agendar = db.Agendars.Include(p => p.IdEspNavigation)
                                     .Include(p => p.IdAteNavigation)
                                     .Include(p => p.IdSectorNavigation)
                                     .Include(p => p.IdPrevNavigation);
            return View(agendar);           
        }


        public IActionResult Create()
        {
            //select id,nombre from marca 
            ViewData["IdEsp"] = new SelectList(db.Especialidads, "IdEsp", "Especialidad1");
            ViewData["IdAte"] = new SelectList(db.Atencions, "IdAte", "NombreAte");
            ViewData["IdSector"] = new SelectList(db.Sectors, "IdSector", "Sector1");
            ViewData["IdPrev"] = new SelectList(db.Previsions, "IdPrev", "NombrePrev");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Agendar agendar)
        {
            //var existe = db.Agendars.FirstOrDefault(x => x.FechaAg == agendar.FechaAg && x.HoraAg == agendar.HoraAg);
            //var existe = db.Agendars.FirstOrDefault(x => x.HoraAg == agendar.HoraAg);
            //if (!ModelState.IsValid)
          //  {
            //    return View(agendar);
          //  }

          //  if (existe == null)

        //  {
                db.Add(agendar);
                db.SaveChanges();
                return RedirectToAction("Index");
           // }
        //TempData["Mensaje"] = "Ya existe este Paciente con ese rut.  " +
         //                     "Agende un nuevo Paciente por favor";
         //  return View(agendar);
        }



        public IActionResult Edit(int? id)
        {
            ViewData["IdEsp"] = new SelectList(db.Especialidads, "IdEsp", "Especialidad1");
            ViewData["IdAte"] = new SelectList(db.Atencions, "IdAte", "NombreAte");
            ViewData["IdSector"] = new SelectList(db.Sectors, "IdSector", "Sector1");
            ViewData["IdPrev"] = new SelectList(db.Previsions, "IdPrev", "NombrePrev");
           
            if (id != null)
            {
                var agendar = db.Agendars.Find(id);
                if (agendar != null)
                {
                    return View(agendar);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Agendar agendar)
        {
            //actualiza los datos de la marca
            db.Update(agendar);
            //guarda los cambios
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var agendar = db.Agendars.Find(id);
                if (agendar != null)
                {
                    db.Agendars.Remove(agendar);
                    db.SaveChanges();
                    TempData["Mensaje1"] = "La Hora Agendada fue eliminada Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }
    }
}