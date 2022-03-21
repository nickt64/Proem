using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeguridadAspMvc.Models
{

    public class Cliente : BaseAuditoria
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        [Required]
        [Range(1000000000, 9999999999)]
        public string Cuit { get; set; }
    }
}
