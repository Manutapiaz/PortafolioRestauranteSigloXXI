using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos
{
    public class InsumoMetaData
    {
        [Required]
        [Display(Name = "Nombre insumo")]
        [StringLength(50, ErrorMessage = "Nombre no puede ser mayor a 50 caracteres")]
        public string NOMBRE_INSUMO { get; set; }

        [Required]
        [Display(Name = "Stock")]
        [Range(0, 100000, ErrorMessage = "Ingrese numero valido")]
        public int STOCK_INSUMO { get; set; }

        [Required]
        [Display(Name = "Unidad medida")]
        [StringLength(50, ErrorMessage = "Unidad medida no puede ser mayor a 50 caracteres")]
        public string UNIDADMEDIDA_INSUMO { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [Range(0, 50000, ErrorMessage = "Ingrese numero valido")]
        public int PRECIO { get; set; }

        [Display(Name = "Imagen")]
        [StringLength(100, ErrorMessage = "Largo maximo permitido 100")]
        public string IMAGEURL { get; set; }
    }
}
