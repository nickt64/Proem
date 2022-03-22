using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeguridadAspMvc.Models
{
    public class BaseAuditoria
    {
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }


        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
