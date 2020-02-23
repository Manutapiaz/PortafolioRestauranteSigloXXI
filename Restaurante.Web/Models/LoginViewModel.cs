using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}