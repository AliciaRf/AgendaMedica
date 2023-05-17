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
            var agendas=db.Agendars.Include(p => p.IdEspNavigation). Include(p => p.IdAteNavigation). Include(p => p.IdSectorNavigation).Include(p => p.IdPrevNavigation).Include(p => p.RutPacNavigation);
            return View(agendas);
        }


        public IActionResult Create()
        {
            //select id,nombre from marca 
            ViewData["IdEspecialidad"] = new SelectList(db.Especialidads, "IdEsp", "Especialidad1");
            ViewData["IdAtenciones"] = new SelectList(db.Atencions, "IdAte", "NombreAte");
            ViewData["IdSectores"] = new SelectList(db.Sectors, "IdSector", "Sector1");
            ViewData["IdPrevision"] = new SelectList(db.Previsions, "IdPrev", "NombrePrev");
            ViewData["IdPaciente"] = new SelectList(db.Pacientes, "RutPac", "RutPac");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Agendar agenda)
        {
            db.Agendars.Add(agenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
