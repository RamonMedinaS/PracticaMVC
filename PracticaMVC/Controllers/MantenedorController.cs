using Microsoft.AspNetCore.Mvc;
using PracticaMVC.Datos;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //La vista mostrara una lista de contactos
            var oLista = _contactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //Metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactosModel oContactos)
        {
            //Motodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _contactoDatos.Guardar(oContactos);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int Id)
        {
            var oContacto = _contactoDatos.Obtener(Id);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactosModel oContacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _contactoDatos.Editar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int Id)
        {
            var oContacto = _contactoDatos.Obtener(Id);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactosModel oContacto)
        {
            var respuesta = _contactoDatos.Eliminar(oContacto.Id);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
