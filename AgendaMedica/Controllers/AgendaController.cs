using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaMedica.Models;
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Controllers
{
    
    public class AgendaController : Controller
    {
        private BdagendaContext db = new();

        public IActionResult Index()
        {
            var agendas = db.Agendars.Include(p => p.IdEspNavigation). Include(p => p.IdAteNavigation). Include(p => p.IdSectorNavigation).Include(p => p.IdPrevNavigation);
            return View(agendas);           
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
            //var existe = db.Usuarios.FirstOrDefault(x => x.NombreUs == usuario.NombreUs && x.Usuario1 == usuario.Usuario1);
            var existe = db.Agendars.FirstOrDefault(x => x.RutPac == agendar.RutPac);
            if (!ModelState.IsValid)
            {
                return View(agendar);
            }

            if (existe == null)

            {
                db.Add(agendar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "Ya existe este Paciente con ese rut.  " +
                                  "Agende un nuevo Paciente por favor";
            return View(agendar);
        }



        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var agendar = db.Agendars.Find(id);
                if (agendar != null)
                {
                    ViewData["IdEsp"] = new SelectList(db.Especialidads, "IdEsp","Especialidad1",agendar.IdEsp);
                    ViewData["IdAte"] = new SelectList(db.Atencions, "IdAte", "NombreAte", agendar.IdAte);
                    ViewData["IdSector"] = new SelectList(db.Sectors, "IdSector", "Sector1", agendar.IdSector);
                    ViewData["IdPrev"] = new SelectList(db.Previsions, "IdPrev", "NombrePrev", agendar.IdPrev);
                    return View(agendar);
                }

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Edit(Agendar agendar)
        {
            try
            {
                //verifica si el modelo es válido
                if (!ModelState.IsValid)
                {

                    return View(agendar);
                }
                //actualiza los datos de la marca
                db.Update(agendar);
                //guarda los cambios
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(agendar);
            }
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
                    TempData["Mensaje1"] = "La Hora Agendada fue eliminado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }
    }
}