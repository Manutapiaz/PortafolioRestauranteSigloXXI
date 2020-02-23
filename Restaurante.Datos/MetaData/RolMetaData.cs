using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Datos
{
    public class RolMetaData
    {


        public int ID_ROL { get; set; }        

        [Required]
        [StringLength(50)]
        [Display(Name = "nombre")]
        public string NOMBRE { get; set; }
    }
}
