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
            //select * from usuario
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
            var existe = db.Pacientes.FirstOrDefault(x => x.RutPac == paciente.RutPac);
            if (existe == null)

            {
                db.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }
        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
                //Find busca por la PK, es equivalente select * from marca where id = id
                var paciente = db.Pacientes.Find(id);
                //verifica si marca encontro datos
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
            db.Update(paciente);
            db.SaveChanges();
            return RedirectToAction("Index");
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
                }
            }
            return RedirectToAction("Index");
        }

    }
}