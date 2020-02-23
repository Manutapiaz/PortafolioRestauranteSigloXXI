using Restaurante.Datos;
using Restaurante.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Restaurante.Web.Controllers
{
    public class CuentaController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {

                if (User.IsInRole("Admin"))
                {
                    return this.RedirectToAction("Index", "Usuario");
                }
                else if (User.IsInRole("Bodega"))
                {
                    return this.RedirectToAction("Index", "Insumo");
                }
                else if (User.IsInRole("Cocina"))
                {
                    return this.RedirectToAction("Index", "Pedido");
                }
                else if (User.IsInRole("Finanzas"))
                {
                    return this.RedirectToAction("Index", "Finanzas");
                }
                else
                {
                    return this.RedirectToAction("Index", "Cuenta");
                }

            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                string password = Seguridad.Encriptar(model.Password);
                using (var var = new EntitiesRestaurante())
                {
                    var resultado = var.USUARIO.Where(n => n.EMAIL_USUARIO == model.Username.ToLower() && n.PASSWORD == password).FirstOrDefault();

                    if (resultado != null)
                    {
                        FormsAuthentication.SetAuthCookie(resultado.NOMBRE_USUARIO, false);
                        int id = resultado.ROL_ID_ROL;
                        if (id.Equals(1))
                        {
                            return RedirectToAction("Index", "Usuario");
                        }
                        else if (id.Equals(2))
                        {
                            return RedirectToAction("Index", "Insumo");
                        }
                        else if (id.Equals(3))
                        {
                            return RedirectToAction("Index", "Pedido");
                        }
                        else if (id.Equals(4))
                        {
                            return RedirectToAction("Index", "Finanzas");
                        }
                        else
                        {
                            this.ModelState.AddModelError(string.Empty, "Credenciales invalidas");
                            return this.View(model);
                        }

                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, "Credenciales invalidas");
                        return this.View(model);

                    }

                }
            }
            else
            {

                return this.View(model);
            }

        }

        [Authorize]
        public ActionResult SingOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return this.RedirectToAction("Login", "Cuenta");

        }

    }
}