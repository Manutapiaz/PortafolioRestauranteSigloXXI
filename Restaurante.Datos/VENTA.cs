//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurante.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENTA
    {
        public int ID_VENTA { get; set; }
        public int PEDIDO_ID_PEDIDO { get; set; }
        public int SUB_TOTAL { get; set; }
        public int IVA { get; set; }
        public int PROPINA { get; set; }
        public int TOTAL { get; set; }
        public System.DateTime FECHA_PEDIDO { get; set; }
        public string RUT_MESERO { get; set; }
        public int TIPOPAGO { get; set; }
    
        public virtual PEDIDO PEDIDO { get; set; }
    }
}
