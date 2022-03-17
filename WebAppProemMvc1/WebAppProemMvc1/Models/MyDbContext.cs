using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProemMvc1.Models
{
    public class MyDbContext: DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Factura> Facturas { get; set; }
        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }


       
    }
}
