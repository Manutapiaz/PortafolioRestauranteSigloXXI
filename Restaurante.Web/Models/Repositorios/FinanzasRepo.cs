using Restaurante.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.Web.Models.Repositorios
{
    public class FinanzasRepo
    {

        private EntitiesRestaurante context;

        public FinanzasRepo(EntitiesRestaurante _context)
        {
            this.context = _context;
        }

        public FinanzasRepo()
        {
            this.context = new EntitiesRestaurante();
        }

        public List<PEDIDO> listarPedidos()
        {
            return this.context.PEDIDO.Where(m => m.ESTADO_PEDIDO == 2).ToList();
        }


        public PEDIDO buscarPedido(int id)
        {
            return this.context.PEDIDO.Find(id);

        }

        public bool editarPedido(int id)
        {
            try
            {
                PEDIDO ped = buscarPedido(id);
                if (ped != null)
                {
                    ped.ESTADO_PEDIDO = 3;
                    this.context.SaveChanges();

                    var var = listarPlatos(id);
                    int total = 0;
                    foreach (var item in var)
                    {
                        total += item.PLATO.PRECIO_VENTA * item.CANTIDAD;
                    }

                    int iva = Convert.ToInt32(total * 0.19);
                    int subtotal = Convert.ToInt32(total - iva);
                    int propina = Convert.ToInt32(total * 0.1);
                    total = Convert.ToInt32(total + propina);

                    this.context.INSERTVENTA(id, subtotal, iva, propina, total, DateTime.Now, "no",1);

                    var listaPedidos = this.context.PEDIDO_PLATOS.Where(n => n.PEDIDO_ID_PEDIDO == ped.ID_PEDIDO).ToList();
                    foreach (var item in listaPedidos)
                    {
                        var receta = buscarReceta(item.PLATO.ID_PLATO);
                        int cant = item.CANTIDAD;
                        foreach (var list in receta)
                        {
                            cant = cant * list.CANTIDAD_UTILIZADO;

                            INSUMO insumo = buscarInsumo(list.INSUMO_ID_INSUMO);
                            insumo.STOCK_INSUMO = insumo.STOCK_INSUMO - cant;
                            this.context.SaveChanges();

                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public INSUMO buscarInsumo(int id)
        {
            return this.context.INSUMO.Where(n => n.ID_INSUMO == id).FirstOrDefault();
        }

        public List<RECETA> buscarReceta(int id)
        {
            return this.context.RECETA.Where(n => n.PLATO_ID_PLATO == id).ToList();
        }

        public List<PEDIDO_PLATOS> listarPlatos(int id)
        {
            return this.context.PEDIDO_PLATOS.Where(n => n.PEDIDO_ID_PEDIDO == id).ToList();
        }

        public VENTA buscarventa(int id)
        {
            return this.context.VENTA.Where(n => n.PEDIDO_ID_PEDIDO == id).FirstOrDefault();
        }

        public List<PEDIDO_PLATOS> buscarPedidos(int id)
        {
            return this.context.PEDIDO_PLATOS.Where(n => n.PEDIDO_ID_PEDIDO == id).ToList();
        }

        public int totalPedido()
        {
            try
            {
                return this.context.VENTA.Select(n => n.TOTAL).Sum();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int totalPedido(DateTime fechaInicial, DateTime fechaFinal)
        {
            return this.context.VENTA.Where(n => n.FECHA_PEDIDO >= fechaInicial && n.FECHA_PEDIDO <= fechaFinal).Select(n => n.TOTAL).Sum();
        }


        public List<VENTA> listarVentas()
        {
            return this.context.VENTA.ToList();
        }

        public List<VENTA> listarVentas(DateTime fechaInicial, DateTime fechaFinal)
        {
            return this.context.VENTA.Where(n => n.FECHA_PEDIDO >= fechaInicial && n.FECHA_PEDIDO <= fechaFinal).ToList();
        }
    }
}
