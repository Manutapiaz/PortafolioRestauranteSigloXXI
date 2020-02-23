using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos.MetaData
{
    public class PlatoMetaData
    {

        [Required]
        [StringLength(50, ErrorMessage = "Nombre plato no puede ser mayor a 50 caracteres")]
        [Display(Name = "Nombre plato")]
        public string NOMBRE_PLATO { get; set; }

        [Required]
        [Range(0, 50000, ErrorMessage = "Ingrese numero valido")]
        [Display(Name = "Precio costo")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int PRECIO_COSTO { get; set; }

        [Required]
        [Range(0, 100000, ErrorMessage = "Ingrese numero valido")]
        [Display(Name = "Precio venta")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int PRECIO_VENTA { get; set; }


        [Display(Name = "Imagen")]
        [StringLength(100, ErrorMessage = "Nombre imagen no puede ser mayor a 100 caracteres")]
        public string IMAGEURL { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Descripcion no puede ser mayor a 200 caracteres")]
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }

        [Required]
        [Range(0, 350, ErrorMessage = "Ingrese numero valido")]
        [Display(Name = "Tiempo Preparación")]
        public int TIEMPO_PREPARACION { get; set; }

    }
}
