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
    
    public partial class RESERVA
    {
        public int ID_RESERVA { get; set; }
        public int CLIENTE_ID_CLIENTE { get; set; }
        public int MESA_NUM_MESA { get; set; }
        public System.DateTime FECHA { get; set; }
        public int ESTADO { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual MESA MESA { get; set; }
    }
}
