using Restaurante.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.Web.Models.Repositorios
{
    public class MesaRepo
    {
        private EntitiesRestaurante context;

        public MesaRepo(EntitiesRestaurante _context)
        {
            this.context = _context;
        }

        public MesaRepo()
        {
            this.context = new EntitiesRestaurante();
        }

        public List<MESA> listMesas()
        {
            return this.context.MESA.Where(n => n.NUM_MESA>0).ToList();
        }

        public bool InsertarMesa(MESA mesa)
        {
            try
            {         
                context.INSERTMESA(mesa.NUM_MESA, mesa.CANT_PERSONAS);
                context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }

        public MESA buscarMesa(int num)
        {
            return this.context.MESA.Find(num);

        }

        public bool EditMesa(int id, MESA model)
        {
            try
            {
                MESA var = buscarMesa(id);
                if (var != null)
                {
                    var.ESTADO = model.ESTADO;
                    var.NUM_MESA = model.NUM_MESA;
                    var.CANT_PERSONAS = model.CANT_PERSONAS;
                    this.context.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }
        }

        public bool buscarMesaBool(int num)
        {     
            var res = this.context.MESA.Find(num);
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool eliminarMesa(int num)
        {
            MESA user = this.buscarMesa(num);
            if (user != null)
            {
                this.context.MESA.Remove(user);
                this.context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}