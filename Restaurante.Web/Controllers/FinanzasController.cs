using iTextSharp.text;
using iTextSharp.text.pdf;
using Restaurante.Datos;
using Restaurante.Web.Models;
using Restaurante.Web.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Restaurante.Web.Controllers
{
    public class FinanzasController : Controller
    {
        private FinanzasRepo context = new FinanzasRepo();
        // GET: Insumo
        public ActionResult Index()
        {

            return View(this.context.listarPedidos());

        }

        // GET: Prueba/Details/5
        public ActionResult Details(int id)
        {

            return View(this.context.buscarPedidos(id));
        }

        public ActionResult DetallePedido(int id)
        {
            ViewBag.id = id;
            return View(this.context.buscarPedidos(id));
        }





        public ActionResult Pagado(int id)
        {
            if (this.context.editarPedido(id))
            {
                pdf(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public void pdf(int id)
        {
            try
            {


                var var = this.context.buscarventa(id);

                Ticket ticket = new Ticket();
                ticket.Path = "C://PDF/";
                ticket.FileName = $"boleta{var.ID_VENTA}.pdf";
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("RESTAURANTE SIGLO XXI");

                ticket.AddSubHeaderLine("Caja # 1" + " - Ticket # " + var.ID_VENTA + "");
                ticket.AddSubHeaderLine("Le atendió: ADMINISTRADOR");
                ticket.AddSubHeaderLine("Fecha y Hora: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.AddSubHeaderLine("Cliente: " + var.PEDIDO.CLIENTE.NOMBRE_CLIENTE + " " + var.PEDIDO.CLIENTE.APELLIDO_CLIENTE + "");

                var listaPedidos = this.context.buscarPedidos(id);

                foreach (var item in listaPedidos)
                {
                    int valor = item.CANTIDAD * item.PLATO.PRECIO_VENTA;
                    ticket.AddItem(item.CANTIDAD.ToString(), item.PLATO.NOMBRE_PLATO.ToString(), valor.ToString("C"));
                }

                ticket.AddTotal("SUBTOTAL", var.SUB_TOTAL.ToString("C"));
                ticket.AddTotal("IVA", var.IVA.ToString("C"));
                ticket.AddTotal("10% PROPINA", var.PROPINA.ToString("C"));
                ticket.AddTotal("", "");
                ticket.AddTotal("TOTAL", var.TOTAL.ToString("C"));
                ticket.AddTotal("", "");
                ticket.AddFooterLine("GRACIAS POR SU COMPRA");
                //Generamos
                ticket.Print();
                System.Diagnostics.Process.Start(ticket.Path + ticket.FileName);
            }
            catch (Exception ex) { throw (ex); }
        }

        [HttpGet]
        public ActionResult Ventas()
        {
            ViewBag.total = this.context.totalPedido();
            return View(this.context.listarVentas());
        }


        // GET: Prueba/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Prueba/Create
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

        // GET: Prueba/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prueba/Edit/5
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

        // GET: Prueba/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prueba/Delete/5
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