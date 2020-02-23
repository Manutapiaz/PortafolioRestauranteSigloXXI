using Restaurante.Datos;
using Restaurante.Web.Models;
using Restaurante.Web.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Web.Controllers
{
   /* [Authorize(Roles = "Admin")]*/
    public class UsuarioController : Controller
    {

        private UsuarioRepo context = new UsuarioRepo();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(context.listarUsuarios());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            List<SelectListItem> item = context.listarRoles().ConvertAll(rol =>
            {
                return new SelectListItem()
                {
                    Text = rol.NOMBRE,
                    Value = rol.ID_ROL.ToString()
                };
            });
            ViewBag.items = item;
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(USUARIO model)
        {
            model.EMAIL_USUARIO = model.EMAIL_USUARIO.ToLower();
            model.PASSWORD = Seguridad.Encriptar(model.PASSWORD);
            if (ModelState.IsValid)
            {
                if (context.insertarUsuario(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario ya existe");
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var var = this.context.buscarUsuario(id);

            if (var != null)
            {        
                IEnumerable<SelectListItem> item = context.listarRoles().Select(rol => new SelectListItem
                {
                    Text = rol.NOMBRE,
                    Value = rol.ID_ROL.ToString()
                });
                ViewBag.items = item;
                var.PASSWORD = Seguridad.DesEncriptar(var.PASSWORD);
                return View(var);
            }
            else
            {
                return this.RedirectToAction("Index");
            }
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.EMAIL_USUARIO = usuario.EMAIL_USUARIO.ToLower();
                usuario.PASSWORD = Seguridad.Encriptar(usuario.PASSWORD);
                bool edit = this.context.editarUsuario(id, usuario);
                if (edit != false)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error en editar la mesa");
                    return View(usuario);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error en editar la mesa");
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            if (this.context.eliminarUsuario(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar usuario");
                return View("Index");
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
