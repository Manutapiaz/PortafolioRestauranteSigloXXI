using Restaurante.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.Web.Models.Repositorios
{
    public class PlatoRepo
    {
        private EntitiesRestaurante context;

        public PlatoRepo(EntitiesRestaurante _context)
        {
            this.context = _context;
        }

        public PlatoRepo()
        {
            this.context = new EntitiesRestaurante();
        }



        public List<RECETA> listarRecetas(int idPlato)
        {
            return this.context.RECETA.Where(n => n.PLATO_ID_PLATO == idPlato).ToList();
        }


        public List<PLATO> listarPlatos()
        {
            return this.context.PLATO.ToList();
        }

        public List<INSUMO> listarInsumos()
        {
            return this.context.INSUMO.ToList();
        }



        public bool insertarPlato(PLATO usuario)
        {
            try
            {

                context.INSERTPLATO(usuario.NOMBRE_PLATO, usuario.PRECIO_COSTO, usuario.PRECIO_VENTA, usuario.TIPO_PLATO_ID_TIPO_PLATO, usuario.IMAGEURL, usuario.DESCRIPCION,usuario.TIEMPO_PREPARACION);
                context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool insertarReceta(RECETA receta)
        {
            try
            {

                context.INSERTRECETA(receta.PLATO_ID_PLATO, receta.INSUMO_ID_INSUMO, receta.CANTIDAD_UTILIZADO);
                context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }


        public PLATO buscarPlato(int idPlato)
        {
            return this.context.PLATO.Find(idPlato);

        }

        public RECETA buscarReceta(int idReceta)
        {

            return this.context.RECETA.Find(idReceta);

        }

        public bool buscarPlatoBool(int idPlato)
        {
            var res = this.context.PLATO.Find(idPlato);
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool buscarRecetaBool(int idPlato)
        {
            var res = this.context.RECETA.Where(n => n.PLATO_ID_PLATO == idPlato).FirstOrDefault();
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool editarPlato(int id, PLATO model)
        {
            try
            {
                PLATO var = buscarPlato(id);
                if (var != null)
                {
                    var.NOMBRE_PLATO = model.NOMBRE_PLATO;
                    var.PRECIO_COSTO = model.PRECIO_COSTO;
                    var.PRECIO_VENTA = model.PRECIO_VENTA;
                    if (model.IMAGEURL != null)
                    {
                        var.IMAGEURL = model.IMAGEURL;
                    }
                

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

                return false;
            }
        }

        /*
        public USUARIO UsuarioViewToUsuario(UsuarioViewModel model)
        {
            USUARIO user = new USUARIO();
            user.RUT_USUARIO = model.RUT_USUARIO;
            user.NOMBRE_USUARIO = model.NOMBRE_USUARIO;
            user.APELLIDO_USUARIO = model.APELLIDO_USUARIO;
            user.EMAIL_USUARIO = model.EMAIL_USUARIO;
            user.PASSWORD = model.Password;
            user.ROL_ID_ROL = model.Rol;

            return user;
        }
        */

        public bool eliminarPLato(int idPlato)
        {
            PLATO user = this.buscarPlato(idPlato);
            if (user != null)
            {
                if (this.buscarRecetaBool(idPlato) == true)
                {
                    this.eliminarRecetaPlato(idPlato);
                    this.context.PLATO.Remove(user);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    this.context.PLATO.Remove(user);
                    this.context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public bool eliminarRecetaPlato(int id)
        {
            var var = this.context.RECETA.Where(n => n.PLATO_ID_PLATO == id).ToList();

            foreach (var item in var)
            {
                this.context.RECETA.Remove(item);
                this.context.SaveChanges();
            }
            return true;
        }


        public bool eliminarReceta(int id)
        {

            RECETA user = this.buscarReceta(id);
            if (user != null)
            {
                this.context.RECETA.Remove(user);
                this.context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<TIPO_PLATO> listarTipoPlatos()
        {
            return this.context.TIPO_PLATO.ToList();
        }
    }
}