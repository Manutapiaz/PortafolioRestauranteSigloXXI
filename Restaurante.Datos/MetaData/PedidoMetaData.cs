using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos.MetaData
{
    public class PedidoMetaData
    {      

        [Display(Name = "Fecha Pedido")]
        public System.DateTime FECHA_PEDIDO { get; set; }

        [Display(Name = "Estado Pedido")]
        [Range(0, 11, ErrorMessage = "Ingrese numero valido")]
        public int ESTADO_PEDIDO { get; set; }
       
    }
}
