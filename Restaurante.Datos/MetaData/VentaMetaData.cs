using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos.MetaData
{
    public class VentaMetaData
    {       

        [Display(Name = "Sub Total")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int SUB_TOTAL { get; set; }

        [Display(Name = "Iva")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int IVA { get; set; }

        [Display(Name = "Propina")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int PROPINA { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int TOTAL { get; set; }

        [Display(Name = "Fecha Pedido")]
        public System.DateTime FECHA_PEDIDO { get; set; }

        [Display(Name = "Rut Mesero")]
        public string RUT_MESERO { get; set; }

    }
}
