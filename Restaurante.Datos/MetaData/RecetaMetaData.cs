using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos.MetaData
{
    public class RecetaMetaData
    {
        [Required]
        [Display(Name = "Cantidad")]
        [Range(0, 100000, ErrorMessage = "Ingrese numero valido")]
        public int CANTIDAD_UTILIZADO { get; set; }


    }
}
