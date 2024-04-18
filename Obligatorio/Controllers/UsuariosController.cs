using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Obligatorio.Models;

namespace Obligatorio.Controllers {
    public class UsuariosController : Controller {
        public ICUAlta<Usuario> CUAlta { get; set; }
        public ICUAutenticarUsuario CUAutenticarUsuario { get; set; }

        public UsuariosController(ICUAutenticarUsuario cuAutenticarUsuario, ICUAlta<Usuario> cuAlta) {
            CUAutenticarUsuario = cuAutenticarUsuario;
            CUAlta = cuAlta;
        }
        public IActionResult Index() {
            return View();
        }

        //--------------------------------------------------------------------------
        //---------------------------- INGRESAR ------------------------------------
        //--------------------------------------------------------------------------
        public IActionResult Ingresar() {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(IngresarViewModel model) {
            if (!ModelState.IsValid) {
                ViewBag.Error = "Email o Contraseña no pueden ser vacíos";
                return View();
            }

            if (CUAutenticarUsuario.Autenticar(model.Email, model.Password, out Usuario u)) {
                HttpContext.Session.SetString("EMAIL", model.Email);
                HttpContext.Session.SetString("TIPOUSUARIO", u.Tipo);
                return RedirectToAction("Index","Home");
            }

            HttpContext.Session.Clear();

            ViewBag.Error = "Las credenciales no son correctas.";
            return View();
        }

        public IActionResult CerrarSesion() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario nuevo) {
            try {
                CUAlta.Alta(nuevo);
                return RedirectToAction(nameof(Index));
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.ToString();
            }

            return View();
        }
    }
}
