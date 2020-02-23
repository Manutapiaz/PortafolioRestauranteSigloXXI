using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos.MetaData
{
    public class MesaMetaData
    {
        [Required]
        [Display(Name = "Numero mesa")]
        [Range(0, 80, ErrorMessage = "Ingrese numero valido")]
        public int NUM_MESA { get; set; }
     
        [Display(Name = "Estado mesa")]
        public int ESTADO { get; set; }

        [Required]
        [Range(0, 11, ErrorMessage = "Ingrese numero valido")]
        [Display(Name = "Capacidad personas")]
        public int CANT_PERSONAS { get; set; }
    }
}
