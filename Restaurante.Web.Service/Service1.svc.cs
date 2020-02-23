using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Restaurante.Datos;

namespace Restaurante.Web.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {      

        public bool reservarMesa(string nombre, string apellido, string rut, string email, int telefono, string fecha, string hora, string cantidad)
        {
            try
            {            
                string windowsTime = fecha + " " + hora;     
                DateTime date = DateTime.Parse(windowsTime); ;       
                using (var var = new EntitiesRestaurante())
                {
                    CLIENTE c1i1 = var.CLIENTE.Where(n => n.RUT_CLIENTE == rut).FirstOrDefault();

                    if (c1i1 != null)
                    {
                        var.INSERTRESERVA(c1i1.ID_CLIENTE, 0, date);
                        var.SaveChanges();
                        return true;
                    }
                    else {
                        var.INSERTCLIENTE(rut, nombre, apellido, email, telefono);
                        CLIENTE cli2 = var.CLIENTE.Where(n => n.RUT_CLIENTE == rut).FirstOrDefault();
                        var.INSERTRESERVA(cli2.ID_CLIENTE, 0, date);
                        var.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }
    }
}
