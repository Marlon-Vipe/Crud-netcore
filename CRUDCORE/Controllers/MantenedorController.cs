﻿using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            // Mostrar la lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            // Solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            // Recibe datos para guardarlos en la DB

            if (!ModelState.IsValid)
                return View();
            
            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

 
            var oLista = _ContactoDatos.Guardar(oContacto);
            return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            // Solo devuelve la vista
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }

        public IActionResult Eliminar(int IdContacto)
        {
            // Solo devuelve la vista
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {

            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }

    }
}
