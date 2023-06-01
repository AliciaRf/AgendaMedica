using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class PacienteController : Controller
    {
        //instancia la clase que contiene la conexión a la db
        private BdagendaContext db = new();

        public IActionResult Index()
        {
            //select * from pacientes
            return View(db.Pacientes.ToList());
        }

        //método para crear
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paciente paciente)
        {
            //var existe = db.Usuarios.FirstOrDefault(x => x.NombreUs == usuario.NombreUs && x.Usuario1 == usuario.Usuario1);
            var existe = db.Pacientes.FirstOrDefault(x => x.RutPac == paciente.RutPac);
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            if (existe == null)

            {
                db.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "Ya existe este Paciente con ese rut.  " +
                                  "Ingrese un nuevo Paciente por favor";
            return View(paciente);
        }

        public IActionResult Edit(int? id)
        {
            
            if (id != null)
            {
                
                var paciente = db.Pacientes.Find(id);
             
                if (paciente != null)
                {
                    //retorna a la vista Edit con los datos encontrados
                    return View(paciente);
                }
            }
            //en caso de error, volver al index
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public IActionResult Edit(Paciente paciente)
        {
            try
            {
                //verifica si el modelo es válido
                if (!ModelState.IsValid)
                {

                    return View(paciente);
                }
                //actualiza los datos de la marca
                db.Update(paciente);
                //guarda los cambios
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(paciente);
            }
        }


        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var paciente = db.Pacientes.Find(id);
                if (paciente != null)
                {
                    db.Pacientes.Remove(paciente);
                    db.SaveChanges();
                    TempData["Mensaje1"] = "El Paciente fue eliminado Satisfactoriamente";
                }
            }
            return RedirectToAction("Index");
        }
    }
}