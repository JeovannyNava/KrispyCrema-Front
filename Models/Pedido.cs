using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sl1_Front.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        public int Cantidad { get; set; }
       
        public virtual Dona Dona { get; set; }
        [Required]
        public int IdDona { get; set; }
    }

}
