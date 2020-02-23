using Restaurante.Web.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Web.Controllers
{
    public class PedidoInsumosController : Controller
    {
        // GET: PedidoInsumos
        private InsumosRepo context = new InsumosRepo();
        // GET: Insumo
        public ActionResult Index()
        {
            return View(this.context.listarPedidosInsumos());
        }

        // GET: PedidoInsumos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoInsumos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoInsumos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoInsumos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoInsumos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoInsumos/Delete/5
        public ActionResult Delete(int id)
        {
            if (this.context.marcarPedidoComprado(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: PedidoInsumos/Delete/5
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
