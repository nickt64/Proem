using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProemMvc1.Models
{
    public class Cliente
    {
       
        
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public int Cuit { get; set; }


    }
}
