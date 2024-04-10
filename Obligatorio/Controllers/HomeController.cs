using Obligatorio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Obligatorio.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Ingresar() {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(IngresarViewModel model) {
            if (!ModelState.IsValid) {
                ViewBag.Error = "Email o Contraseña no pueden ser vacíos";
                return View();
            }

            //if (Sistema.Instancia.AutenticarUsuario(model.Email, model.Password, out Usuario usuario)) {
            //    HttpContext.Session.SetString("EMAIL", model.Email);
            //    HttpContext.Session.SetString("TIPOUSUARIO", usuario.ObtenerTipoDeUsuario());
            //    return RedirectToAction("Index");
            //}

            HttpContext.Session.Clear();

            ViewBag.Error = "Las credenciales no son correctas.";
            return View();
        }
    }
}
