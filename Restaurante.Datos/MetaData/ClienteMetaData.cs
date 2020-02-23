using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos
{
    public class ClienteMetaData
    {


        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 9, ErrorMessage = "Error rut invalido")]
        [Display(Name = "Rut")]
        public string RUT_CLIENTE { get; set; }

        [Required]
        [StringLength(maximumLength: 50,ErrorMessage = "Nombre no puede ser mayor a 50 caracteres")]
        [Display(Name = "Nombre")]
        public string NOMBRE_CLIENTE { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Apellido no puede ser mayor a 50 caracteres")]
        [Display(Name = "Apellido")]
        public string APELLIDO_CLIENTE { get; set; }


        [StringLength(50, ErrorMessage = "Correo no puede ser mayor a 50 caracteres")]
        [Display(Name = "Correo")]
        public string CORREO { get; set; }

        [Range(0, 9999999999, ErrorMessage = "Ingrese numero valido")]
        [Display(Name = "Telefono")]
        public int TELEFONO { get; set; }

     
    }
}
