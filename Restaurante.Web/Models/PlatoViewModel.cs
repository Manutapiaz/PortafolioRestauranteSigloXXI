using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurante.Datos;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Web.Models
{
    public class PlatoViewModel : PLATO
    {      
        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}