using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeguridadAspMvc.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }

        public DateTime Fecha { get; set; }

        public float  Importe { get; set; }

        public float Saldo { get; set; }

        [Display(Name ="cliente")]
        public int  ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
