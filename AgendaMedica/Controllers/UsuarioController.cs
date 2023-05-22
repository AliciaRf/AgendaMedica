using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Controllers
{
    public class UsuarioController : Controller
    {
        //instancia la clase que contiene la conexión a la db
        private BdagendaContext db = new();

        //método para listar todas las Previsiones
        public IActionResult Index()
        {
            //select * from usuario
            return View(db.Usuarios.ToList());
        }

        //método para crear
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            var existe = db.Usuarios.FirstOrDefault(x => x.NombreUs == usuario.NombreUs);
            if (existe == null)

            {
                db.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        private void MessageProcessingHandler(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(int? id)
        {
            //verifica si el id es distinto de null
            if (id != null)
            {
               
                var usuario = db.Usuarios.Find(id);
                //verifica si marca encontro datos
                if (usuario != null)
                {
                    //retorna a la vista Edit con los datos encontrados
                    return View(usuario);
                }
            }
            //en caso de error, volver al index
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            try
            {
                //verifica si el modelo es válido
                if (!ModelState.IsValid)
                {

                    return View(usuario);
                }
                //actualiza los datos de la marca
                db.Update(usuario);
                //guarda los cambios
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    TempData["Mensaje1"] = "El Usuario fue eliminado Satisfactoriamente!";
                }            
            }
            return RedirectToAction("Index");
        }
    }
}