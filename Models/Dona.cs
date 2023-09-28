using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sl1_Front.Models
{
    public class Dona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public int Descripcion { get; set; }

    }
}