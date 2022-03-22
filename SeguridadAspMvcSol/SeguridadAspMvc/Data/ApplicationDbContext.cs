using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeguridadAspMvc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeguridadAspMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Factura> Facturas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
