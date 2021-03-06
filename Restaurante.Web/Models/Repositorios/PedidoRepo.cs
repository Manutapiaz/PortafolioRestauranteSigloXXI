﻿using Restaurante.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.Web.Models.Repositorios
{
    public class PedidoRepo
    {
        private EntitiesRestaurante context;

        public PedidoRepo(EntitiesRestaurante _context)
        {
            this.context = _context;
        }

        public PedidoRepo()
        {
            this.context = new EntitiesRestaurante();
        }

        public List<PEDIDO> listarPedidos()
        {
            return this.context.PEDIDO.Where(n => n.ESTADO_PEDIDO != 2).ToList();
        }


        public List<PEDIDO_PLATOS> listarPedidosFull(int idPedido)
        {
            return this.context.PEDIDO_PLATOS.Where(n => n.PEDIDO_ID_PEDIDO == idPedido).ToList();
        }


        public PEDIDO buscarPedido(int id)
        {          
            return this.context.PEDIDO.Find(id);

        }

        public bool editarPedido(int id, int num)
        {
            try
            {
                PEDIDO ped = buscarPedido(id);
                if (ped != null)
                {
                    ped.ESTADO_PEDIDO = num;
                    this.context.SaveChanges();
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

        public bool eliminarPedido(int id)
        {
            try
            {
                List<PEDIDO_PLATOS> lista = this.context.PEDIDO_PLATOS.Where(n => n.PEDIDO_ID_PEDIDO == id).ToList();
                if (lista != null)
                {
                    foreach (var item in lista)
                    {
                        this.context.PEDIDO_PLATOS.Remove(item);
                    }
                    this.context.PEDIDO.Remove(buscarPedido(id));
                    this.context.SaveChanges();
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
    }
}